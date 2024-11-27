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
    public partial class OverlayForm : Form
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
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        public OverlayForm()
        {
            InitializeComponent();
            lblDescription.MouseDown += (s, e) =>
            {
                OnMouseDown(new MouseEventArgs(e.Button, e.Clicks, e.X + lblDescription.Left, e.Y + lblDescription.Top, e.Delta));
            };
            lblDescription.MouseUp += (s, e) =>
            {
                OnMouseUp(e);
            };
            lblDescription.DoubleClick += (s, e) =>
            {
                OnDoubleClick(e);
            };
        }
        public void SetLabel(string str)
        {
            lblDescription.Text = str;
            int x = (Width - lblDescription.Width) / 2;
            int y = (Height - lblDescription.Height) / 2;
            lblDescription.Location = new Point(x, y);
        }
    }
}
