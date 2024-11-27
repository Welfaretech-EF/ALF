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
    public partial class frmSettings : Form
    {
        public static bool EnableOverlaysOnStartup = false;
        public static bool GridSnap = false;
        public static bool LoadPrevious = true;
        public static string PrevFile = "";
        static string FixedFile = "";
        public static string StartupFile
        {
            get { return LoadPrevious ? PrevFile : FixedFile; }
        }
        OpenFileDialog ofd = new OpenFileDialog()
        {
            Filter = "ALF Files|*.alf"
        };
        public static void LoadSettings()
        {
            if (System.IO.File.Exists("Settings.conf"))
            {
                string[] lines = System.IO.File.ReadAllLines("Settings.conf");
                foreach(string line in lines)
                {
                    string[] elements = line.Split(';');
                    switch (elements[0].ToLower())
                    {
                        case "enableoverlaysonstartup":
                            EnableOverlaysOnStartup = bool.Parse(elements[1]);
                            break;
                        case "gridsnap":
                            GridSnap = bool.Parse(elements[1]);
                            break;
                        case "loadprevious":
                            LoadPrevious = bool.Parse(elements[1]);
                            break;
                        case "prevfile":
                            PrevFile = elements[1];
                            break;
                        case "fixedfile":
                            FixedFile = elements[1];
                            break;
                    }
                }
            }
        }
        public static void SaveSettings()
        {
            System.IO.File.WriteAllLines("Settings.conf", new string[] {
                "EnableOverlaysOnStartup;" + EnableOverlaysOnStartup.ToString(),
                "GridSnap;" + GridSnap.ToString(),
                "LoadPrevious;" + LoadPrevious.ToString(),
                "PrevFile;" + PrevFile,
                "FixedFile;" + FixedFile
            });
        }
        public frmSettings()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;

            chkEnableGazeOnStartup.Checked = EnableOverlaysOnStartup;
            chkEnableGazeOnStartup.CheckedChanged += (s, e) =>
            {
                EnableOverlaysOnStartup = chkEnableGazeOnStartup.Checked;
            };
            chkGridSnap.Checked = GridSnap;
            chkGridSnap.CheckedChanged += (s, e) =>
            {
                GridSnap = chkGridSnap.Checked;
            };
            rdbLoadPrevious.Checked = LoadPrevious;
            rdbLoadFixed.Checked = !LoadPrevious;
            rdbLoadPrevious.CheckedChanged += (s, e) =>
            {
                LoadPrevious = rdbLoadPrevious.Checked;
            };
            lblFixed.Text = FixedFile;
            cmdSetFile.Click += (s, e) =>
            {
                if(ofd.ShowDialog()== DialogResult.OK)
                {
                    FixedFile = ofd.FileName;
                    lblFixed.Text = FixedFile;
                }
            };
            FormClosing += (s, e) =>
            {
                SaveSettings();
            };
        }
    }
}
