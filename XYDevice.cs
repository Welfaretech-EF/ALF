using AForge.Video;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Windows.Forms;
using Tobii.Interaction;

namespace ALF
{
    public abstract class XYDevice : IDisposable
    {
        public static bool FollowUser = false;
        public static int FollowUserX = 0;
        public static int FollowUserY = 0;
        public class XYPoint
        {
            public float X = float.PositiveInfinity, Y = float.PositiveInfinity;
            public bool Relative = false;
            public long lastBlink = 0;

            public XYPoint() { }
            public XYPoint(float X,float Y,long lastBlink = 0, bool Relative = false)
            {
                this.X = X;
                this.Y = Y;
                this.lastBlink = lastBlink;
                this.Relative = Relative;
            }
        }

        public abstract void Dispose();
        public event EventHandler<XYPoint> XYRecieved;
        public class Tobii5: XYDevice
        {
            Tobii.Interaction.Host host = null;
            Tobii.Interaction.GazePointDataStream gazePointDataStream;
            public Tobii5()
            {
                try
                {
                    host = new Tobii.Interaction.Host();
                    long lastGaze = DateTime.Now.Ticks;
                    long[] GazeDiff = new long[5];
                    long lastBlink = 0;
                    int k = 0;
                    gazePointDataStream = host.Streams.CreateGazePointDataStream();
                    gazePointDataStream.IsEnabled = true;
                    gazePointDataStream.GazePoint((gazePointX, gazePointY, _) =>
                    {
                        long gazeDiff = DateTime.Now.Ticks - lastGaze;
                        lastGaze = DateTime.Now.Ticks;
                        if (gazeDiff > 2 * GazeDiff.Max())
                            lastBlink = DateTime.Now.Ticks;
                        GazeDiff[k] = gazeDiff;
                        if (++k == GazeDiff.Length)
                            k = 0;

                        float X = (float)(gazePointX * frmSettings.GazeScale / 100f);
                        float Y = (float)(gazePointY * frmSettings.GazeScale / 100f);
                        if (XYRecieved != null)
                            XYRecieved?.Invoke(this, new XYPoint(X, Y, lastBlink));
                    });
                }
                catch (Exception ex)
                {
                    host = null;
                    if (ex.GetType().Equals(typeof(DllNotFoundException)))
                    {
                        MessageBox.Show("Tobii.EyeX.Client.dll or one of its dependices are missing\r\nCould be one the following:\r\nvcruntime140.dll\r\nvcruntime140_1.dll\r\nTobii.Tech.NETCommon.ClrExtensions.dll");
                    }
                    else if (ex.GetType().Equals(typeof(BadImageFormatException)))
                    {
                        MessageBox.Show("The application seems to be compiled for the wrong version of Tobii.EyeX.Client.dll (32/64 bit)");
                    }
                    else
                        MessageBox.Show(ex.Message);
                }
            }

            public override void Dispose()
            {
                if (host != null)
                    host.Dispose();
            }
        }
        public class TobiiStreamEngine : XYDevice
        {
            [DllImport("tobii_stream_engine.dll")]
            private static extern int tobii_api_create(out IntPtr api, IntPtr customAlloc, IntPtr customFree);
            [DllImport("tobii_stream_engine.dll")]
            private static extern int tobii_api_destroy(IntPtr api);
            [DllImport("tobii_stream_engine.dll")]
            private static extern int tobii_enumerate_local_device_urls(
                IntPtr api,
                DeviceUrlCallback callback,
                IntPtr userData);
            private delegate void DeviceUrlCallback(string url, IntPtr userData);
            [DllImport("tobii_stream_engine.dll")]
            private static extern int tobii_device_create(IntPtr api, string url, int field_of_use, out IntPtr device);
            [DllImport("tobii_stream_engine.dll")]
            private static extern int tobii_device_destroy(IntPtr device);
            [DllImport("tobii_stream_engine.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int tobii_wait_for_callbacks(int deviceCount, [In] IntPtr[] devices);
            [DllImport("tobii_stream_engine.dll")]
            private static extern int tobii_device_process_callbacks(IntPtr device);

            private delegate void GazePointCallback(ref TobiiGazePoint gazePoint, IntPtr userData);
            [DllImport("tobii_stream_engine.dll")]
            private static extern int tobii_gaze_point_subscribe(IntPtr device, GazePointCallback callback, IntPtr userData);
            [DllImport("tobii_stream_engine.dll")]
            private static extern int tobii_gaze_point_unsubscribe(IntPtr device);

            [StructLayout(LayoutKind.Sequential)]
            public struct TobiiGazePoint
            {
                public long timestamp_us;
                public int validity;
                public float x;
                public float y;
            }

            IntPtr api;
            IntPtr device;
            bool stop = false;
            System.Threading.Thread thread;
            public TobiiStreamEngine() {
                thread = new System.Threading.Thread(() =>
                {
                    try
                    {
                        tobii_api_create(out api, IntPtr.Zero, IntPtr.Zero);
                    }
                    catch(BadImageFormatException ex)
                    {
                        MessageBox.Show("The application seems to be compiled for the wrong version of Tobii_Stream_Engine.dll (32/64 bit)");
                        return;
                    }
                    string deviceUrl = null;
                    tobii_enumerate_local_device_urls(api, (url, userData) =>
                    {
                        deviceUrl = url;
                    }, IntPtr.Zero);

                    if (deviceUrl == null)
                        return;
                    tobii_device_create(api, deviceUrl, 1, out device);

                    tobii_gaze_point_subscribe(device, (ref TobiiGazePoint tobiiGazePoint, IntPtr userdata) =>
                    {
                        if (tobiiGazePoint.validity == 1)
                            XYRecieved?.Invoke(this, new XYPoint(tobiiGazePoint.x, tobiiGazePoint.y, 0, true));
                    }, IntPtr.Zero);

                    IntPtr[] deviceArray = new[] { device };
                    while (!stop)
                    {
                        tobii_wait_for_callbacks(deviceArray.Length, deviceArray);
                        tobii_device_process_callbacks(device);
                    }
                });
                thread.Start();
            }

            public override void Dispose()
            {
                stop = true;
                thread.Join();
                if (device != IntPtr.Zero)
                {
                    tobii_gaze_point_unsubscribe(device);
                    tobii_device_destroy(device);
                    tobii_api_destroy(api);
                }
            }
        }

        public class RelativeMouse : XYDevice
        {
            Timer tmr = null;
            public RelativeMouse()
            {
                tmr = new Timer() { Interval = 30 };
                Point prevCursor = new Point();
                SharpHook.EventLoopGlobalHook a = new SharpHook.EventLoopGlobalHook();
                a.MouseMoved += (s,e)=> {
                    Point Cursor = new Point(e.Data.X,e.Data.Y);
                    if (Cursor.X != prevCursor.X || Cursor.Y != prevCursor.Y)
                    {
                        if (XYRecieved != null)
                            XYRecieved.Invoke(this, new XYPoint(Cursor.X - prevCursor.X, Cursor.Y - prevCursor.Y, 0, true));
                        prevCursor = Cursor;
                    }
                };
                a.RunAsync();
            }

            private void A_MouseMoved(object sender, SharpHook.MouseHookEventArgs e)
            {
                Console.WriteLine(e.Data.X);
            }

            public override void Dispose()
            {
                if (tmr != null)
                    tmr.Stop();
            }
        }


        public class Mouse : XYDevice
        {
            Timer tmr = new Timer()
            {
                Interval = 40
            };
            public Mouse()
            {
                tmr.Tick += (s, e) =>
                {
                    XYRecieved?.Invoke(this, new XYPoint(Cursor.Position.X, Cursor.Position.Y));
                };
                tmr.Start();
            }
            public override void Dispose()
            {
                tmr.Stop();
                tmr = null;
            }
        }

        public class Face : XYDevice
        {
            AForge.Video.DirectShow.VideoCaptureDevice videoSource;
            public override void Dispose()
            {
                if(videoSource != null)
                    videoSource.SignalToStop();
            }
            public Face(string MonikerString)
            {
                if (videoSource != null)
                    videoSource.SignalToStop();
                videoSource = new AForge.Video.DirectShow.VideoCaptureDevice(MonikerString);
                int maxRes = videoSource.VideoCapabilities.Min(res => res.FrameSize.Width * res.FrameSize.Height);
                videoSource.VideoResolution = videoSource.VideoCapabilities.FirstOrDefault(res => res.FrameSize.Width * res.FrameSize.Height == maxRes);
                videoSource.NewFrame += (s, e) =>
                {
                    DetectDlib(e.Frame);
                };
                videoSource.Start();
            }

            Dictionary<int, DlibDotNet.FrontalFaceDetector> frontalFaceDetectors = new Dictionary<int, DlibDotNet.FrontalFaceDetector>();
            DlibDotNet.ShapePredictor shapePredictor = DlibDotNet.ShapePredictor.Deserialize("shape_predictor_68_face_landmarks.dat");
            Point[] xyHist = new Point[10];
            int kHist = 0;
            void DetectDlib(Bitmap bmp)
            {
                int threadID = System.Threading.Thread.CurrentThread.ManagedThreadId;
                if (!frontalFaceDetectors.ContainsKey(threadID))
                    frontalFaceDetectors.Add(threadID, DlibDotNet.Dlib.GetFrontalFaceDetector());
                DlibDotNet.FrontalFaceDetector frontalFaceDetector = frontalFaceDetectors[threadID];
                byte[] rgb = MDOL.Extension.ToByte(bmp);
                DlibDotNet.Array2D<DlibDotNet.RgbPixel> img = DlibDotNet.Dlib.LoadImageData<DlibDotNet.RgbPixel>(DlibDotNet.ImagePixelFormat.Rgb, rgb, (uint)bmp.Height, (uint)bmp.Width, (uint)bmp.Width * 3);
                DlibDotNet.Rectangle[] faces = frontalFaceDetector.Operator(img);
                for (int i = 0; i < faces.Length; i++)
                {
                    DlibDotNet.FullObjectDetection shape = shapePredictor.Detect(img, faces[i]);

                    DlibDotNet.Point NoseTop = shape.GetPart(27);
                    DlibDotNet.Point NoseBottom = shape.GetPart(30);
                    DlibDotNet.Point diff = NoseTop - NoseBottom + new DlibDotNet.Point(0, 33);
                    /*using (System.IO.BinaryWriter BW = new System.IO.BinaryWriter(System.IO.File.OpenWrite("Ny mappe/" + DateTime.Now.Ticks)))
                        for (var j = 0; j < shape.Parts; j++)
                        {
                            DlibDotNet.Point point = shape.GetPart((uint)j);
                            BW.Write(point.X);
                            BW.Write(point.Y);
                            //Points[j] = new Point(point.X, point.Y);
                        }*/
                    //XYRecieved?.Invoke(this, new Point((int)(Screen.PrimaryScreen.Bounds.Width/2+x* Screen.PrimaryScreen.Bounds.Width/2), Screen.PrimaryScreen.Bounds.Height/2));
                    xyHist[kHist++] = new Point((int)((1 + diff.X / 10.0) * Screen.PrimaryScreen.Bounds.Width / 2), (int)((1 - diff.Y / 10.0) * Screen.PrimaryScreen.Bounds.Height / 2));
                    if (kHist == xyHist.Length)
                        kHist = 0;
                    double x = 0;
                    double y = 0;
                    foreach (Point p in xyHist)
                    {
                        x += p.X;
                        y += p.Y;
                    }
                    XYRecieved?.Invoke(this, new XYPoint((int)(x / xyHist.Length), (int)(y / xyHist.Length)));
                }
            }
        }
    }
}
