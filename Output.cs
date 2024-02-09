using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Drawing;

namespace FlexibleEyeController
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
        public static Output fromXML(MDOL.IO.XML xml)
        {
            switch (xml.getString("Type", ""))
            {
                case "MouseMove":
                    return new MouseMove()
                    {
                        X = xml.getInt("X", 0),
                        Y = xml.getInt("Y", 0),
                    };
                case "MouseClick":
                    return new MouseClick()
                    {
                        X = xml.getInt("X", -1),
                        Y = xml.getInt("Y", -1),
                        Button = (System.Windows.Forms.MouseButtons)xml.getInt("mouseButton", 0)
                    };
                case "KeyPress":
                    return new KeyPress()
                    {
                        Key = (System.Windows.Forms.Keys)xml.getInt("Key", 0)
                    };
                case "ChangeFile":
                    return new ChangeFile()
                    {
                        File = new System.Windows.Forms.OpenFileDialog()
                        {
                            Filter = "XML Files | *.xml",
                            FileName = xml.getString("File", "")
                        }
                    };
                case "ChangePage":
                    return new ChangePage()
                    {
                        Page = xml.getInt("Page", 0),
                    };
                case "Joystick":
                    return new Joystick();
            }
            return null;
        }
        bool Activated = false;
        protected abstract void activate();
        public void Activate()
        {
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
        protected virtual void circularActivate(System.Drawing.PointF Direction) {}

        public class MouseMove : Output
        {
            public override string InfoString()
            {
                return "Choose the relative movement of the mouse";
            }
            public int X = 0;
            public int Y = 0;
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[] { new MDOL.IO.XML("X", X.ToString()), new MDOL.IO.XML("Y", Y.ToString())};
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
                WinAPI.mouse_event(WinAPI.MOUSEEVENT_MOVE, X, -Y, 0, 0);
                Activated = false;
            }
            protected override void circularActivate(PointF Direction)
            {
                WinAPI.mouse_event(WinAPI.MOUSEEVENT_MOVE, (int)(Direction.X * X), (int)(Direction.Y * -Y), 0, 0);
            }
        }
        public class Joystick : Output
        {
            public override string InfoString()
            {
                return "Choose joystick action";
            }
            public enum JoystickActions { LeftAnalog,RightAnalog};
            public JoystickActions JoystickAction = JoystickActions.LeftAnalog;
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[]{new MDOL.IO.XML("JoystickAction", ((int)JoystickAction).ToString())};
            }
            public override string DefaultToString()
            { 
                return "";
            }
            protected override void activate()
            {
            }
            protected override void deactivate()
            {
                switch (JoystickAction)
                {
                    case JoystickActions.LeftAnalog:
                        Form1.xbox360Controller.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.LeftThumbX, 0);
                        Form1.xbox360Controller.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.LeftThumbY, 0);
                        break;
                    case JoystickActions.RightAnalog:
                        Form1.xbox360Controller.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.RightThumbX, 0);
                        Form1.xbox360Controller.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.RightThumbY, 0);
                        break;
                }
            }
            protected override void circularActivate(PointF Direction)
            {
                switch (JoystickAction)
                {
                    case JoystickActions.LeftAnalog:
                        Form1.xbox360Controller.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.LeftThumbX, (short)(Direction.X * 32768));
                        Form1.xbox360Controller.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.LeftThumbY, (short)(-Direction.Y * 32768));
                        break;
                    case JoystickActions.RightAnalog:
                        Form1.xbox360Controller.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.RightThumbX, (short)(Direction.X * 32768));
                        Form1.xbox360Controller.SetAxisValue(Nefarius.ViGEm.Client.Targets.Xbox360.Xbox360Axis.RightThumbY, (short)(-Direction.Y * 32768));
                        break;
                }
            }
        }
        public class MouseClick : Output
        {
            public override string InfoString()
            {
                return "Choose the button, which should be activated. The (X,Y)-values indicates where the click should happen. If a value of '-1' is chosen, the click will happen on the current mouse location. Otherwise, the mouse will be moved to the chosen location, before the click.";
            }
            public int X = -1;
            public int Y = -1;
            int down = -1;
            int up = -1;
            public System.Windows.Forms.MouseButtons Button = System.Windows.Forms.MouseButtons.Left;
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[]{
                    new MDOL.IO.XML("X", X.ToString()), new MDOL.IO.XML("Y", Y.ToString()),
                    new MDOL.IO.XML("Button", ((int)Button).ToString())};
            }
            public override string DefaultToString()
            {
                return Button.ToString();
            }
            void Update()
            {
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
                if (down != -1)
                {
                    int X = this.X == -1 ? System.Windows.Forms.Cursor.Position.X : this.X;
                    int Y = this.Y == -1 ? System.Windows.Forms.Cursor.Position.Y : this.Y;
                    WinAPI.mouse_event(down, X, Y, 0, 0);
                }
            }
            protected override void deactivate()
            {
                Update();
                int X = this.X;
                int Y = this.Y;
                if (X == -1 && Y == -1)
                {
                    X = System.Windows.Forms.Cursor.Position.X;
                    Y = System.Windows.Forms.Cursor.Position.Y;
                }
                WinAPI.mouse_event(up, X, Y, 0, 0);
            }
        }
        public class ChangeFile : Output
        {
            public override string InfoString()
            {
                return "Click on the button, to choose which overlay-file is loaded";
            }
            public System.Windows.Forms.OpenFileDialog File = new System.Windows.Forms.OpenFileDialog() { Filter = "XML Files | *.xml" };
            protected override void activate()
            {
                Form1.FORM1.Load(File.FileName);
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
                return (Page>0 ? "+" : "") + Page.ToString();
            }
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[] { new MDOL.IO.XML("Page", Page.ToString())};
            }
        }
        public class KeyPress : Output
        {
            public override string InfoString()
            {
                return "Click on the button, to choose which key is pressed on activiation";
            }
            public System.Windows.Forms.Keys Key = System.Windows.Forms.Keys.None;
            protected override MDOL.IO.XML[] toxml()
            {
                return new MDOL.IO.XML[] { new MDOL.IO.XML("Key", ((int)Key).ToString()) };
            }
            public override string DefaultToString()
            {
                return Key.ToString();
            }
            protected override void activate()
            {
                WinAPI.keybd_event((byte)Key, 0, WinAPI.KEYEVENT_KEYDOWN, 0);
            }
            protected override void deactivate()
            {
                WinAPI.keybd_event((byte)Key, 0, WinAPI.KEYEVENT_KEYUP, 0);
            }
        }
    }
}
