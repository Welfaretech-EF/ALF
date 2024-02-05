using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
namespace FlexibleEyeController
{
    public class Overlay
    {
        public bool ToggleOnActivation = false;
        public MouseButtons mouseButton = MouseButtons.None;
        public string Description = "";
        public MDOL.IO.XML toXML(string name)
        {
            MDOL.IO.XML[] outputs_xml = outputs.Select((output, i) => output.toXML("Output_" + i)).ToArray();
            return new MDOL.IO.XML(name, new MDOL.IO.XML[] {
                new MDOL.IO.XML("Bounds",
                    new MDOL.IO.XML("X",MDOL.Extension.ToStringF(Bounds.X)),
                    new MDOL.IO.XML("Y",MDOL.Extension.ToStringF(Bounds.Y)),
                    new MDOL.IO.XML("Width",MDOL.Extension.ToStringF(Bounds.Width)),
                    new MDOL.IO.XML("Height",MDOL.Extension.ToStringF(Bounds.Height))
                ),
                new MDOL.IO.XML("UnlockTime", UnlockTime.ToString()),
                new MDOL.IO.XML("ToggleOnActivation", ToggleOnActivation.ToString()),
                new MDOL.IO.XML("Circular", Circular.ToString()),
                new MDOL.IO.XML("Description", Description),
                new MDOL.IO.XML("nOutputs", outputs.Length.ToString())
            }.Concat(outputs_xml).ToArray());
        }

        DateTime startWatch = DateTime.MinValue;
        DateTime goalWatch = DateTime.MinValue;

        public RectangleF Bounds = new RectangleF();
        public int UnlockTime = 0;
        public bool Circular;
        public Output[] outputs = new Output[0];
        public Overlay(MDOL.IO.XML xml = null)
        {
            Bounds = new RectangleF(1 / 8f, 1 / 8f, 1 / 8f, 1 / 8f);
            if (xml != null)
            {
                UnlockTime = xml.getInt("UnlockTime", 0);
                ToggleOnActivation = xml.getBool("ToggleOnActivation", false);
                Circular = xml.getBool("Circular", false);
                Description = xml.getString("Description", "");
                int nOutputs = xml.getInt("nOutputs", 0);
                outputs = new Output[nOutputs];
                for (int i = 0; i < nOutputs; i++)
                    outputs[i] = Output.fromXML(xml.getElement("Output_" + i));
                MDOL.IO.XML roi = xml.getElement("Bounds");
                if (roi != null)
                {
                    Bounds = new RectangleF(
                        roi.getFloat("X", 0),
                        roi.getFloat("Y", 0),
                        roi.getFloat("Width", 0),
                        roi.getFloat("Height", 0));
                }
            }
        }

        OverlayForm frm = null;
        public void Show()
        {
            if (frm != null)
                return;
            frm = new OverlayForm();
            frm.Load += (s, e) =>
            {
                frm.Bounds = screenBounds();
                UpdateGUI();
            };
            frm.Show();

            Action saveBounds = new Action(() =>
            {
                Bounds = new RectangleF((float)frm.Bounds.X / Screen.PrimaryScreen.Bounds.Width,
                      (float)frm.Bounds.Y / Screen.PrimaryScreen.Bounds.Height,
                      (float)frm.Bounds.Width / Screen.PrimaryScreen.Bounds.Width,
                      (float)frm.Bounds.Height / Screen.PrimaryScreen.Bounds.Height);
                Form1.FORM1.Save();
            });

            bool mouseDownHeight = false, mouseDownWidth = false;
            Point mouseDownOffset = Point.Empty;
            tmrMove.Tick += (s, e) =>
            {
                if (mouseDownOffset != Point.Empty)
                    frm.Location = new Point(Cursor.Position.X - mouseDownOffset.X, Cursor.Position.Y - mouseDownOffset.Y);
                else if (mouseDownHeight && mouseDownWidth)
                {
                    double w = Cursor.Position.X - frm.Left;
                    //w = Math.Round(w / Screen.PrimaryScreen.Bounds.Width * 20) / 20 * Screen.PrimaryScreen.Bounds.Width;
                    frm.Width = (int)w;

                    double h = Cursor.Position.Y - frm.Top;
                    //h = Math.Round(h / Screen.PrimaryScreen.Bounds.Height * 20) / 20 * Screen.PrimaryScreen.Bounds.Height;
                    frm.Height = (int)h;
                }
                else if (mouseDownHeight)
                    frm.Height = Cursor.Position.Y - frm.Top;
                else if (mouseDownWidth)
                    frm.Width = Cursor.Position.X - frm.Left;
            };
            double border = 0.05;
            frm.MouseMove += (s, e) =>
            {
                float x = (float)e.Location.X / frm.Width;
                float y = (float)e.Location.Y / frm.Height;
                if (x > 1 - border && y > 1 - border)
                    frm.Cursor = Cursors.SizeNWSE;
                else if (x > 1 - border)
                    frm.Cursor = Cursors.SizeWE;
                else if (y > 1 - border)
                    frm.Cursor = Cursors.SizeNS;
                else
                    frm.Cursor = Cursors.SizeAll;
                UpdateGUI();
            };
            frm.MouseDown += (s, e) =>
            {
                float x = (float)e.Location.X / frm.Width;
                float y = (float)e.Location.Y / frm.Height;
                Point mouseDownScreen = frm.PointToScreen(e.Location);
                if (x > 1 - border && y > 1 - border)
                {
                    mouseDownWidth = true;
                    mouseDownHeight = true;
                }
                else if (x > 1 - border)
                    mouseDownWidth = true;
                else if (y > 1 - border)
                    mouseDownHeight = true;
                else
                    mouseDownOffset = new Point(mouseDownScreen.X - frm.Left, mouseDownScreen.Y - frm.Top);
                tmrMove.Start();
            };
            frm.MouseUp += (s, e) =>
            {
                tmrMove.Stop();
                mouseDownOffset = Point.Empty;
                mouseDownHeight = false;
                mouseDownWidth = false;
                if (frm == null)
                    return;
                Bounds = new RectangleF((float)frm.Bounds.X / Screen.PrimaryScreen.Bounds.Width,
                    (float)frm.Bounds.Y / Screen.PrimaryScreen.Bounds.Height,
                    (float)frm.Bounds.Width / Screen.PrimaryScreen.Bounds.Width,
                    (float)frm.Bounds.Height / Screen.PrimaryScreen.Bounds.Height);
                saveBounds();
            };
            frm.DoubleClick += (s, e) =>
            {
                Change();
            };
        }
        public void Close()
        {
            if (frm != null)
            {
                Active = false;
                isEditing = false;
                fixation = false;
                startWatch = DateTime.MinValue;
                frm.Close();
                frm = null;
            }
        }

        Timer tmrMove = new Timer() { Interval = 30 };
        public static bool isEditing = false;
        public void Change()
        {
            tmrMove.Stop();
            isEditing = true;
            new OverlaySettings(this).ShowDialog();
            isEditing = false;
            UpdateGUI();
        }
        Rectangle screenBounds()
        {
            return new Rectangle(
                (int)(Bounds.X * Screen.PrimaryScreen.Bounds.Width),
                (int)(Bounds.Y * Screen.PrimaryScreen.Bounds.Height),
                (int)(Bounds.Width * Screen.PrimaryScreen.Bounds.Width),
                (int)(Bounds.Height * Screen.PrimaryScreen.Bounds.Height));
        }
        void UpdateGUI()
        {
            if (frm == null)
                return;
            frm.SetLabel(Description == "" && outputs.Length != 0 ? outputs[0].DefaultToString() : Description);

            Bitmap bmp = new Bitmap(256, 256);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                if (Circular)
                    g.FillEllipse(BrushInactive, 0, 0, 255, 255);
                else
                    g.Clear(ColorInactive);
            }
            MDOL.Helper.SetImage(frm, bmp);
        }

        public const int WS_EX_LAYERED = 0x00080000;
        public const int WS_EX_TRANSPARENT = 0x00000020;
        Timer tmr = new Timer();
        public void Play(bool play)
        {
            if (frm == null)
                return;
            int initialStyle = WinAPI.GetWindowLong(frm.Handle, -20);
            // Ignore click on forms
            if (play)
            {
                frm.BackColor = Color.White;
                WinAPI.SetWindowLong(frm.Handle, -20, initialStyle | WS_EX_TRANSPARENT);
                //WinAPI.SetWindowLong(Handle, -20, WinAPI.GetWindowLong(Handle, -20) | 134217728);
                tmr = new Timer() { Interval = 100 };
                tmr.Tick += (tmr_s, tmr_e) =>
                {
                    WinAPI.SetWindowPos(frm.Handle, -1, 0, 0, 0, 0, WinAPI.SetWindowPosEnum.SWP_NOACTIVATE |
                         WinAPI.SetWindowPosEnum.SWP_NOMOVE |
                         WinAPI.SetWindowPosEnum.SWP_NOSENDCHANGING |
                         WinAPI.SetWindowPosEnum.SWP_NOSIZE |
                         WinAPI.SetWindowPosEnum.SWP_SHOWWINDOW);
                };
                tmr.Start();
            }
            else
            {
                tmr = null;
                Active = false;
                frm.BackColor = Color.Black;
                WinAPI.SetWindowLong(frm.Handle, -20, initialStyle & ~WS_EX_TRANSPARENT);
            }
        }

        bool fixation = false;
        bool Active = false;
        void Activate()
        {
            if (ToggleOnActivation)
                Active = !Active;
            else
                Active = true;
        }
        void onEnter()
        {
            startWatch = DateTime.Now;
            goalWatch = startWatch.AddMilliseconds(UnlockTime);
        }
        void onFocus(Graphics g)
        {
            fixation = true;
            if (startWatch != DateTime.MinValue)
            {
                float missingPct = UnlockTime == 0 ? 0 : (float)Math.Min(1, Math.Max(0, (goalWatch - DateTime.Now).TotalMilliseconds / UnlockTime));
                if (missingPct == 0)
                {
                    Activate();
                    startWatch = DateTime.MinValue;
                }
                else
                {
                    if (Circular)
                        g.FillEllipse(BrushWaiting, 256 * missingPct / 2, 256 * missingPct / 2, 256 * (1 - missingPct), 256 * (1 - missingPct));
                    else
                        g.FillRectangle(BrushWaiting, 0, 256 * missingPct, 256, 256 * (1 - missingPct));
                }
            }
        }
        void onExit()
        {
            fixation = false;
            startWatch = DateTime.MinValue;
            if (!ToggleOnActivation)
                Active = false;
        }
        Color ColorInactive = Color.Gray;
        Color ColorActive = Color.Blue;
        Color ColorWaiting = Color.Green;
        Brush BrushInactive = Brushes.Gray;
        Brush BrushActive = Brushes.Blue;
        Brush BrushWaiting = Brushes.Green;
        Pen CircularLine = new Pen(Brushes.White, 4);
        public void Tobii(double X, double Y)
        {
            if (frm == null)
                return;
            Bitmap bmp = new Bitmap(256, 256);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                if (Circular)
                    g.FillEllipse(Active ? BrushActive : BrushInactive, 0, 0, 255, 255);
                else
                    g.Clear(Active ? ColorActive : ColorInactive);
                if ((Circular && (MDOL.Extension.Sqr((X - (frm.Left + frm.Width / 2)) / (frm.Width / 2)) + MDOL.Extension.Sqr((Y - (frm.Top + frm.Height / 2)) / (frm.Height / 2))) < 1) ||
                    (!Circular && Y >= frm.Top && Y <= frm.Bottom && X >= frm.Left && X <= frm.Right))
                {
                    if (!fixation)
                        onEnter();
                    onFocus(g);
                }
                else if(fixation)
                    onExit();
                if (Active)
                {
                    if (Circular)
                    {
                        g.DrawLine(CircularLine, 127, 127, (float)(X - frm.Left) / frm.Width * 256, (float)(Y - frm.Top) / frm.Height * 256);
                        PointF direction = new PointF((float)(X - frm.Left - frm.Width / 2) / (frm.Width / 2), (float)(Y - frm.Top - frm.Height / 2) / (frm.Height / 2));
                        foreach (Output output in outputs)
                            output.CircularActivate(direction);
                    }
                    else
                    {
                        foreach (Output output in outputs)
                            output.Activate();
                    }
                }
                else
                    foreach (Output output in outputs)
                        output.Deactivate();
            }
            if (frm != null)
                MDOL.Helper.SetImage(frm, bmp);
        }
    }
}
