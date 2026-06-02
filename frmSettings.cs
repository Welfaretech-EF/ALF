using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ALF
{
    public partial class frmSettings : Form
    {
        public static bool EnableOverlaysOnStartup = false;
        public static bool GridSnap = false;
        public static bool MouseAssist = false;
        public static bool LoadPrevious = true;
        public static string PrevFile = "";
        public static int GazeScale = 100;
        static string FixedFile = "";
        public static string StartupFile
        {
            get { return LoadPrevious ? PrevFile : FixedFile; }
        }
        OpenFileDialog ofd = new OpenFileDialog()
        {
            Filter = "ALF Files|*.alf;*.xml"
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
                        case "mouseassist":
                            MouseAssist = bool.Parse(elements[1]);
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
                        case "speechvoice":
                            Output.Text2Speech.SelectVoice(elements[1]);
                            break;
                        case "gazescale":
                            GazeScale = int.Parse(elements[1]);
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
                "MouseAssist;" + MouseAssist.ToString(),
                "LoadPrevious;" + LoadPrevious.ToString(),
                "PrevFile;" + PrevFile,
                "FixedFile;" + FixedFile,
                "SpeechVoice;" + Output.Text2Speech.GetVoice().Name,
                "GazeScale;" + GazeScale
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
            chkMouseAssist.Checked = MouseAssist;
            chkMouseAssist.CheckedChanged += (s, e) =>
            {
                MouseAssist = chkMouseAssist.Checked;
            };

            rdbLoadPrevious.Checked = LoadPrevious;
            rdbLoadFixed.Checked = !LoadPrevious;
            rdbLoadPrevious.CheckedChanged += (s, e) =>
            {
                LoadPrevious = rdbLoadPrevious.Checked;
            };
            lblFixed.Text = System.IO.Path.GetFileName(FixedFile);
            cmdSetFile.Click += (s, e) =>
            {
                if(ofd.ShowDialog()== DialogResult.OK)
                {
                    FixedFile = ofd.FileName;
                    lblFixed.Text = System.IO.Path.GetFileName(FixedFile);
                }
            };
            FormClosing += (s, e) =>
            {
                SaveSettings();
            };
            System.Speech.Synthesis.InstalledVoice[] voices = Output.Text2Speech.GetVoices();
            if (voices.Length > 0)
            {
                cmbVoices.Items.AddRange(voices.Select(voice => voice.VoiceInfo.Name + "(" + voice.VoiceInfo.Culture.Name + ")").ToArray());
                for (int i = 0; i < voices.Length; i++)
                    if (Output.Text2Speech.GetVoice().Name == voices[i].VoiceInfo.Name)
                    {
                        cmbVoices.SelectedIndex = i;
                        break;
                    }
                cmbVoices.SelectedIndexChanged += (s, e) =>
                {
                    Output.Text2Speech.SelectVoice(voices[cmbVoices.SelectedIndex].VoiceInfo.Name);
                };
            }
            nudGazeScale.Value = GazeScale;
            nudGazeScale.ValueChanged += (s, e) =>
            {
                GazeScale = (int)nudGazeScale.Value;
            };  
        }
    }
}
