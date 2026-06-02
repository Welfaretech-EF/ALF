using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Tobii.Interaction.Model;

namespace ALF
{
    public abstract class Output
    {
        public override string ToString()
        {
            return GetType().Name + ": " + DefaultToString();
        }
        public MDOL.IO.XML toXML(string name)
        {
            return new MDOL.IO.XML(name,
                new MDOL.IO.XML[] { new MDOL.IO.XML("Type", GetType().Name) }.Concat(toxml()).ToArray());
        }
        public abstract string InfoString();
        public abstract string DefaultToString();
        protected abstract MDOL.IO.XML[] toxml();
        public static Dictionary<string, Func<MDOL.IO.XML, Output>> Outputs = new Dictionary<string, Func<MDOL.IO.XML, Output>>() {
            {
                "MouseMove",xml=>xml == null ? new MouseMove() : new MouseMove()
                {
                    X = xml.getInt("X", 0),
                    Y = xml.getInt("Y", 0),
                    FollowUser = xml.getBool("FollowUser", false)
                }
            },
            {
                "MouseClick",xml=>xml == null ? new MouseClick() : new MouseClick()
                {
                    X = xml.getInt("X", -1),
                    Y = xml.getInt("Y", -1),
                    CenterClick = xml.getBool("CenterClick",false),
                    DoubleClick = xml.getBool("DoubleClick", false),
                    Button = (System.Windows.Forms.MouseButtons)xml.getInt("Button", 0)
                }
            },
            {
                "MouseWheel",xml=>xml == null ? new MouseWheel() : new MouseWheel()
                {
                    Value = xml.getInt("Value", 0),
                }
            },
            {
                "KeyPress",xml=>xml == null ? new KeyPress() : new KeyPress()
                {
                    Key = (System.Windows.Forms.Keys)xml.getInt("Key", 0),
                    ExtendedKey = xml.getBool("ExtendedKey", false),
                    Circular_KeyLeft = (System.Windows.Forms.Keys)xml.getInt("Circular_KeyLeft", (int)Keys.Left),
                    Circular_KeyUp= (System.Windows.Forms.Keys)xml.getInt("Circular_KeyUp", (int)Keys.Up),
                    Circular_KeyRight = (System.Windows.Forms.Keys)xml.getInt("Circular_KeyRight", (int)Keys.Right),
                    Circular_KeyDown = (System.Windows.Forms.Keys)xml.getInt("Circular_KeyDown", (int)Keys.Down)
                }
            },
            {
                "ChangeFile",xml=>xml == null ? new ChangeFile() : new ChangeFile()
                {
                    File = new System.Windows.Forms.OpenFileDialog()
                    {
                        Filter = "ALF Files|*.alf;*.xml",
                        FileName = xml.getString("File", "")
                    }
                }
            },
            {
                "ChangePage",xml => xml == null ? new ChangePage() : new ChangePage()
                {
                    Page = xml.getInt("Page", 0),
                }
            },
            {
                "Joystick",xml=>xml == null ? new Joystick() : new Joystick()
                {
                    JoystickAction = (Joystick.JoystickActions)xml.getInt("JoystickAction", 0),
                }
            },
            {
                "Text2Speech",xml => xml == null ? new Text2Speech() : new Text2Speech()
                {
                    Text = xml.getString("Text",""),
                }
            },
            {
                "Sound",xml => xml == null ? new Sound() : new Sound()
                {
                    File = new System.Windows.Forms.OpenFileDialog()
                    {
                        Filter = "Sound Files|*.wav;*.mp3",
                        FileName = xml.getString("File", "")
                    }
                }
            },
            {
                "ToogleOverlays",xml => new ToogleOverlays()
            },
            {
                "UsbSwitch",xml => new UsbSwitch()
            }
        };
        public static Output fromXML(MDOL.IO.XML xml)
        {
            string type = xml.getString("Type", "");
            if (Outputs.ContainsKey(type))
                return Outputs[xml.getString("Type", "")](xml);
            return null;
        }
        bool Activated = false;
        protected abstract void activate();
        Overlay overlay;
        public void Activate(Overlay overlay)
        {
            this.overlay = overlay;
            if (!Activated)
            {
                Activated = true;
                activate();
            }
        }
        protected virtual void deactivate() { }
        public void Deactivate()
        {
            if (Activated)
            {
                Activated = false;
                deactivate();
            }
        }
        public void CircularActivate(PointF Direction)
        {
            Activated = true;
            circularActivate(Direction);
        }
        protected virtual void circularActivate(System.Drawing.PointF Direction) { }

        public class MouseMove : Output
        {
            public override string InfoString()
            {
                return "Choose the relative movement of the mouse";
            }
            public int X = 0;
            public int Y = 0;
            public bool FollowUser = false;
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[] { new MDOL.IO.XML("X", X.ToString()), new MDOL.IO.XML("Y", Y.ToString()), new MDOL.IO.XML("FollowUser", FollowUser.ToString()) };
            }
            public override string DefaultToString()
            {
                if (X == 0 && Y != 0)
                    return Y > 0 ? "Down" : "Up";
                else if (X != 0 && Y == 0)
                    return X > 0 ? "Right" : "Left";
                else
                    return "";
            }
            protected override void activate()
            {
                if (FollowUser)
                { 
                    XYDevice.FollowUser = true;
                    XYDevice.FollowUserX = X;
                    XYDevice.FollowUserY = Y;
                }
                else
                {
                    WinAPI.mouse_event(WinAPI.MOUSEEVENT_MOVE, X, -Y, 0, 0);
                    Activated = false;
                }
            }
            protected override void circularActivate(PointF Direction)
            {
                WinAPI.mouse_event(WinAPI.MOUSEEVENT_MOVE, (int)(Direction.X * X), (int)(Direction.Y * Y), 0, 0);
            }
            protected override void deactivate()
            {
                if(FollowUser)
                    XYDevice.FollowUser = false;
            }
        }

        public class MouseWheel : Output
        {
            public override string InfoString()
            {
                return "Choose the relative movement of the mousewheel (positive or negative)";
            }
            public int Value = 0;
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[] { new MDOL.IO.XML("Value", Value.ToString()) };
            }
            public override string DefaultToString()
            {
                return Value > 0 ? "Wheel Up" : "Wheel Down";
            }
            protected override void activate()
            {
                WinAPI.mouse_event(WinAPI.MOUSEEVENTF_WHEEL, 0, 0, 10 * Value, 0);
                Activated = false;
            }
        }

        public class Text2Speech : Output
        {
            static System.Speech.Synthesis.SpeechSynthesizer speechSynthesizer = new System.Speech.Synthesis.SpeechSynthesizer();
            public static System.Speech.Synthesis.InstalledVoice[] GetVoices()
            {
                return speechSynthesizer.GetInstalledVoices().ToArray();
            }
            public static void SelectVoice(string Name)
            {
                try
                {
                    speechSynthesizer.SelectVoice(Name);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Selected voice is not installed");
                }
            }
            public static System.Speech.Synthesis.VoiceInfo GetVoice()
            {
                return speechSynthesizer.Voice;
            }
            public string Text = "";
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[] { new MDOL.IO.XML("Text", Text) };
            }
            public override string DefaultToString()
            {
                return Text == "" ? "Stop Speech" : Text;
            }
            public override string InfoString()
            {
                return "Write text or input an empty string, to send a stop-command on activation)";
            }
            protected override void activate()
            {
                if (Text == "")
                    speechSynthesizer.SpeakAsyncCancelAll();
                else
                    speechSynthesizer.SpeakAsync(Text);
            }
        }
        public class Sound : Output
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            public override string InfoString()
            {
                return "Click on the button, to choose which overlay-file is loaded";
            }
            public System.Windows.Forms.OpenFileDialog File = new System.Windows.Forms.OpenFileDialog() { Filter = "Sound Files|*.wav;*.mp3" };
            protected override void activate()
            {
                if (mediaPlayer.Source == null || !Path.GetFullPath(mediaPlayer.Source.AbsolutePath).ToLower().Equals(Path.GetFullPath(File.FileName)))
                    mediaPlayer.Open(new Uri(File.FileName));
                mediaPlayer.Play();
            }
            public override string DefaultToString()
            {
                return System.IO.Path.GetFileNameWithoutExtension(File.FileName);
            }
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[] { new MDOL.IO.XML("File", File.FileName) };
            }
        }
        public class Joystick : Output
        {
            public override string InfoString()
            {
                return "Choose joystick action";
            }
            public enum JoystickActions
            {
                LeftAnalog, RightAnalog,
                A,
                B,
                Back,
                Down,
                Guide,
                Left,
                LeftShoulder,
                LeftThumb,
                Right,
                RightShoulder,
                RightThumb,
                Start,
                Up,
                X,
                Y
            };
            Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button[] buttons = new Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button[] {
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.A,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.B,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.Back,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.Down,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.Guide,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.Left,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.LeftShoulder,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.LeftThumb,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.Right,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.RightShoulder,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.RightThumb,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.Start,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.Up,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.X,
                Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Button.Y
            };

            public JoystickActions JoystickAction = JoystickActions.LeftAnalog;
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[] { new MDOL.IO.XML("JoystickAction", ((int)JoystickAction).ToString()) };
            }
            public override string DefaultToString()
            {
                return Form1.xbox360Controller == null ? "Disabled" : JoystickAction.ToString();
            }
            protected override void activate()
            {
                int i = (int)JoystickAction - 2;
                if (i >= 0)
                    Form1.xbox360Controller?.SetButtonState(buttons[i], true);
            }
            protected override void deactivate()
            {
                int i = (int)JoystickAction - 2;
                if (i == -2)
                {
                    Form1.xbox360Controller?.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.LeftThumbX, 0);
                    Form1.xbox360Controller?.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.LeftThumbY, 0);
                }
                else if (i == -1)
                {
                    Form1.xbox360Controller?.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.RightThumbX, 0);
                    Form1.xbox360Controller?.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.RightThumbY, 0);
                }
                else
                    Form1.xbox360Controller?.SetButtonState(buttons[i], false);
            }
            protected override void circularActivate(PointF Direction)
            {
                switch (JoystickAction)
                {
                    case JoystickActions.LeftAnalog:
                        Form1.xbox360Controller?.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.LeftThumbX, (short)(Direction.X * 32767));
                        Form1.xbox360Controller?.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.LeftThumbY, (short)(-Direction.Y * 32767));
                        break;
                    case JoystickActions.RightAnalog:
                        Form1.xbox360Controller?.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.RightThumbX, (short)(Direction.X * 32767));
                        Form1.xbox360Controller?.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.RightThumbY, (short)(-Direction.Y * 32767));
                        break;
                }
            }
        }
        public class MouseClick : Output
        {
            public override string InfoString()
            {
                return "Choose the button, which should be activated. " +
                    "The (X,Y)-values indicates where the click should happen. " +
                    "If a value of '-1' is chosen, the click will happen on the current mouse location. " +
                    "Otherwise, the mouse will be moved to the chosen location, before the click. " +
                    "Centerclick will move the mouse to the center of the overlay";
            }
            public int X = -1;
            public int Y = -1;
            public bool CenterClick = false;
            public bool DoubleClick = false;
            int down, up;
            public System.Windows.Forms.MouseButtons Button = System.Windows.Forms.MouseButtons.Left;
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[]{
                    new MDOL.IO.XML("X", X.ToString()), new MDOL.IO.XML("Y", Y.ToString()),
                    new MDOL.IO.XML("CenterClick", CenterClick.ToString()),
                    new MDOL.IO.XML("DoubleClick", DoubleClick.ToString()),
                    new MDOL.IO.XML("Button", ((int)Button).ToString())};
            }
            public override string DefaultToString()
            {
                return Button.ToString();
            }
            void Update()
            {
                down = -1;
                up = -1;
                switch (Button)
                {
                    case System.Windows.Forms.MouseButtons.Left:
                        down = WinAPI.MOUSEEVENT_LEFTDOWN;
                        up = WinAPI.MOUSEEVENT_LEFTUP;
                        break;
                    case System.Windows.Forms.MouseButtons.Right:
                        down = WinAPI.MOUSEEVENT_RIGHTDOWN;
                        up = WinAPI.MOUSEEVENT_RIGHTUP;
                        break;
                    case System.Windows.Forms.MouseButtons.Middle:
                        down = WinAPI.MOUSEEVENT_MIDDLEDOWN;
                        up = WinAPI.MOUSEEVENT_MIDDLEUP;
                        break;
                }
            }
            protected override void activate()
            {
                Update();
                int X = this.X;
                int Y = this.Y;
                if (X == -1)
                    X = System.Windows.Forms.Cursor.Position.X;
                if (Y == -1)
                    Y = System.Windows.Forms.Cursor.Position.Y;
                if (CenterClick)
                {
                    X = (overlay.frm.Bounds.Left + overlay.frm.Bounds.Right) / 2;
                    Y = (overlay.frm.Bounds.Bottom + overlay.frm.Bounds.Top) / 2;
                }
                WinAPI.SetCursorPos(X, Y);
                if (down != -1)
                {
                    WinAPI.mouse_event(down, X, Y, 0, 0);
                    if (DoubleClick)
                    {
                        WinAPI.mouse_event(up, X, Y, 0, 0);
                        Thread.Sleep(50);
                        WinAPI.mouse_event(down, X, Y, 0, 0);
                    }
                }
            }
            protected override void deactivate()
            {
                if (up != -1)
                {
                    int X = this.X;
                    int Y = this.Y;
                    if (X == -1)
                        X = System.Windows.Forms.Cursor.Position.X;
                    if (Y == -1)
                        Y = System.Windows.Forms.Cursor.Position.Y;
                    if (CenterClick)
                    {
                        X = (overlay.frm.Bounds.Left + overlay.frm.Bounds.Right) / 2;
                        Y = (overlay.frm.Bounds.Bottom + overlay.frm.Bounds.Top) / 2;
                    }
                    WinAPI.mouse_event(up, X, Y, 0, 0);
                }
            }
        }
        public class ChangeFile : Output
        {
            public override string InfoString()
            {
                return "Click on the button, to choose which overlay-file is loaded";
            }
            public System.Windows.Forms.OpenFileDialog File = new System.Windows.Forms.OpenFileDialog() { Filter = "ALF Files|*.alf;*.xml" };
            protected override void activate()
            {
                Form1.FORM1.LoadFile(File.FileName);
            }
            public override string DefaultToString()
            {
                return System.IO.Path.GetFileNameWithoutExtension(File.FileName);
            }
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[] { new MDOL.IO.XML("File", File.FileName) };
            }
        }
        public class ChangePage : Output
        {
            public override string InfoString()
            {
                return "The user can go 'Page' pages back (negative) or forward (positive)";
            }
            public int Page = 0;
            protected override void activate()
            {
                Form1.FORM1.ChangePage(Page);
            }
            public override string DefaultToString()
            {
                return (Page > 0 ? "+" : "") + Page.ToString();
            }
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[] { new MDOL.IO.XML("Page", Page.ToString()) };
            }
        }
        public class KeyPress : Output
        {
            public override string InfoString()
            {
                return "Click on the button, to choose which key is pressed on activiation\r\n" +
                    "If circular is chosen, choose the four keys being pressed, when 50% of the circle is reached in one of the four directions";
            }
            public System.Windows.Forms.Keys Key = System.Windows.Forms.Keys.None;
            public bool ExtendedKey = false;
            public System.Windows.Forms.Keys Circular_KeyLeft = System.Windows.Forms.Keys.Left;
            public System.Windows.Forms.Keys Circular_KeyUp = System.Windows.Forms.Keys.Up;
            public System.Windows.Forms.Keys Circular_KeyRight = System.Windows.Forms.Keys.Right;
            public System.Windows.Forms.Keys Circular_KeyDown = System.Windows.Forms.Keys.Down;

            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[] {
                    new MDOL.IO.XML("Key", ((int)Key).ToString()),
                    new MDOL.IO.XML("ExtendedKey", ExtendedKey.ToString()),
                    new MDOL.IO.XML("Circular_KeyLeft", ((int)Circular_KeyLeft).ToString()),
                    new MDOL.IO.XML("Circular_KeyUp", ((int)Circular_KeyUp).ToString()),
                    new MDOL.IO.XML("Circular_KeyRight", ((int)Circular_KeyRight).ToString()),
                    new MDOL.IO.XML("Circular_KeyDown", ((int)Circular_KeyDown).ToString())
                };
            }
            public override string DefaultToString()
            {
                return Key.ToString();
            }
            protected override void activate()
            {
                WinAPI.keybd_event((int)Key, WinAPI.MapVirtualKey((int)Key, 0), WinAPI.KEYEVENT_KEYDOWN | (ExtendedKey ? WinAPI.KEYEVENTF_EXTENDEDKEY : 0), 0);
            }
            protected override void deactivate()
            {
                WinAPI.keybd_event((int)Key, WinAPI.MapVirtualKey((int)Key, 0), WinAPI.KEYEVENT_KEYUP | (ExtendedKey ? WinAPI.KEYEVENTF_EXTENDEDKEY : 0), 0);
            }
            protected override void circularActivate(PointF Direction)
            {
                if(Direction.X>0.5)
                    WinAPI.keybd_event((int)Circular_KeyRight, WinAPI.MapVirtualKey((int)Circular_KeyRight, 0), WinAPI.KEYEVENT_KEYDOWN | (ExtendedKey ? WinAPI.KEYEVENTF_EXTENDEDKEY : 0), 0);
                else if(Direction.X<-0.5)
                    WinAPI.keybd_event((int)Circular_KeyLeft, WinAPI.MapVirtualKey((int)Circular_KeyLeft, 0), WinAPI.KEYEVENT_KEYDOWN | (ExtendedKey ? WinAPI.KEYEVENTF_EXTENDEDKEY : 0), 0);
                if (Direction.Y > 0.5)
                    WinAPI.keybd_event((int)Circular_KeyDown, WinAPI.MapVirtualKey((int)Circular_KeyDown, 0), WinAPI.KEYEVENT_KEYDOWN | (ExtendedKey ? WinAPI.KEYEVENTF_EXTENDEDKEY : 0), 0);
                else if (Direction.Y < -0.5)
                    WinAPI.keybd_event((int)Circular_KeyUp, WinAPI.MapVirtualKey((int)Circular_KeyUp, 0), WinAPI.KEYEVENT_KEYDOWN | (ExtendedKey ? WinAPI.KEYEVENTF_EXTENDEDKEY : 0), 0);
            }
        }

        public class ToogleOverlays : Output
        {
            public override string InfoString()
            {
                return "Toggles overlays on and off";
            }
            bool LostFocus = true;
            protected override void activate()
            {
                if (LostFocus)
                    Form1.FORM1.chkEnableOverlays.Checked = !Form1.FORM1.chkEnableOverlays.Checked;
                LostFocus = false;
            }
            protected override void deactivate()
            {
                LostFocus = true;
            }
            public override string DefaultToString()
            {
                return "Toogle Overlays";
            }
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[] { new MDOL.IO.XML("ToogleOverlays", "") };
            }
        }

        public class UsbSwitch : Output
        {
            static SerialPort serialPort = null;
            public static void openPort()
            {
                new Thread(() =>
                {
                    if (serialPort == null)
                    {
                        List<int> ports = new List<int>();
                        System.Management.ManagementClass processClass = new System.Management.ManagementClass("Win32_PnPEntity");
                        System.Management.ManagementObjectCollection Ports = processClass.GetInstances();
                        foreach (System.Management.ManagementObject property in Ports)
                            if (property.GetPropertyValue("Name") != null)
                                if (property.GetPropertyValue("Name").ToString().Contains("Silicon Labs CP210x USB to UART Bridge"))
                                {
                                    string name = property.GetPropertyValue("Name").ToString();
                                    string[] elements = name.Split(new string[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                                    if (elements.Length > 1 && elements[1].Contains("COM"))
                                        ports.Add(int.Parse(elements[1].Replace("COM", "")));
                                }
                        if (ports.Count > 0)
                        {
                            serialPort = new SerialPort("COM" + ports[0]);
                            serialPort.Open();
                        }
                    }
                }).Start();
            }
            public UsbSwitch()
            {
                openPort();
            }
            protected override void activate()
            {
                if (serialPort != null)
                { 
                    serialPort.Write("AT+CH1=1");
                }
            }
            protected override void deactivate()
            {
                if (serialPort != null)
                    serialPort.Write("AT+CH1=0");
            }
            public override string InfoString()
            {
                return "Toggles a USB-switch";
            }
            public override string DefaultToString()
            {
                return "Toogle USB-switch";
            }
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[0];
            }
        }
    }
}
