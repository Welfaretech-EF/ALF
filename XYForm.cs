using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALF
{
    public partial class XYForm : Form
    {

        protected override CreateParams CreateParams
        {
            get
            {
                int WS_EX_TOOLWINDOW = 0x00000080;
                var Params = base.CreateParams;
                Params.ExStyle |= WS_EX_TOOLWINDOW;
                return Params;
            }
        }

        public const int WS_EX_LAYERED = 0x00080000;
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public XYForm()
        {
            InitializeComponent();

            BackColor = Color.White;
            int initialStyle = WinAPI.GetWindowLong(Handle, -20);
            WinAPI.SetWindowLong(Handle, -20, initialStyle | WS_EX_TRANSPARENT);

            Size = new Size(Screen.PrimaryScreen.Bounds.Width / 20, Screen.PrimaryScreen.Bounds.Width / 20);

            Timer tmr = new Timer() { Interval = 1000 };
            tmr.Tick += (s, e) =>
            {
                WinAPI.SetWindowPos(Handle, -1, 0, 0, 0, 0, WinAPI.SetWindowPosEnum.SWP_NOACTIVATE |
                         WinAPI.SetWindowPosEnum.SWP_NOMOVE |
                         WinAPI.SetWindowPosEnum.SWP_NOSENDCHANGING |
                         WinAPI.SetWindowPosEnum.SWP_NOSIZE |
                         WinAPI.SetWindowPosEnum.SWP_SHOWWINDOW);
            };
            tmr.Start();
        }
        public void SetXY(float x, float y)
        {
            Location = new Point((int)(x - Width / 2), (int)(y - Height / 2));
        }
    }
}
