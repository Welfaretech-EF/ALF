using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlexibleEyeController
{
    public partial class Form1 : Form
    {
        string currentFile = "";
        public void ChangePage(int Page)
        {
            lstPages.SelectedIndex = MDOL.Extension.mod(lstPages.SelectedIndex + Page, lstPages.Items.Count);
        }
        public void DeleteOverlay(Overlay overlay)
        {
            ((Page)lstPages.SelectedItem).Delete(overlay);
        }
        public int nPages
        {
            get
            {
                return lstPages.Items.Count;
            }
        }
        public void Save()
        {
            MDOL.IO.XML[] pages_xml = lstPages.Items.Cast<Page>().Select((page, i) => page.toXML("Page_" + i)).ToArray();
            MDOL.IO.XML xml = new MDOL.IO.XML("Pages",
                new MDOL.IO.XML[] {
                    new MDOL.IO.XML("nPages",lstPages.Items.Count.ToString())
                }.Concat(pages_xml).ToArray());
            System.IO.File.WriteAllText(currentFile, xml.ToString(0));
        }
        public void LoadFile(string File)
        {
            if (System.IO.File.Exists(File))
            {
                if (lstPages.SelectedItem != null)
                    ((Page)lstPages.SelectedItem).Close();
                lstPages.Items.Clear();
                currentFile = File;
                Text = System.IO.Path.GetFileNameWithoutExtension(currentFile);
                MDOL.IO.XML xml_pages = MDOL.IO.XML.Read(File);
                if (xml_pages != null)
                {
                    int nPages = xml_pages.getInt("nPages", 0);
                    for (int i = 0; i < nPages; i++)
                    {
                        Page page = new Page(xml_pages.getElement("Page_" + i));
                        lstPages.Items.Add(page);
                    }
                    if (lstPages.Items.Count > 0)
                        lstPages.SelectedIndex = 0;
                }
                frmSettings.PrevFile = currentFile;
                frmSettings.SaveSettings();
            }
        }

        Tobii.Interaction.Host host = null;
        Tobii.Interaction.GazePointDataStream gazePointDataStream;
        public static Form1 FORM1;
        public static Nefarius.ViGEm.Client.Targets.IXbox360Controller xbox360Controller;
        public Form1()
        {
            Resize += (s, e) =>
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    if (lstPages.SelectedItem != null)
                        ((Page)lstPages.SelectedItem).Close();
                }
                else
                {
                    if (lstPages.SelectedItem != null)
                        ((Page)lstPages.SelectedItem).Show();
                }
            };

            try
            {
                xbox360Controller = new Nefarius.ViGEm.Client.ViGEmClient().CreateXbox360Controller();
                xbox360Controller.Connect();
            }
            catch (Nefarius.ViGEm.Client.Exceptions.VigemBusNotFoundException ex)
            {
                System.IO.File.AppendAllText("Debug.txt", ex.Message);
                if (MessageBox.Show("In order to simulate joysticks, the ViGEm Bus Driver must be installed - click yes to download and install version 1.22.0 (November, 2023)", "ViGEm Bus Driver not found!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (var client = new System.Net.WebClient())
                    {
                        client.DownloadFile("https://github.com/nefarius/ViGEmBus/releases/download/v1.22.0/ViGEmBus_1.22.0_x64_x86_arm64.exe", "ViGEmBus_1.22.0_x64_x86_arm64.exe");
                        var process = new System.Diagnostics.Process();
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.RedirectStandardError = true;
                        process.StartInfo.FileName = "ViGEmBus_1.22.0_x64_x86_arm64.exe";

                        process.Start();
                        process.WaitForExit();
                        process.Dispose();

                        try
                        {
                            xbox360Controller = new Nefarius.ViGEm.Client.ViGEmClient().CreateXbox360Controller();
                            xbox360Controller.Connect();
                        }
                        catch (Nefarius.ViGEm.Client.Exceptions.VigemBusNotFoundException exNew)
                        {
                            MessageBox.Show("Something went wrong - the driver is still missing!");
                        }
                    }
                }
            }
            FORM1 = this;
            InitializeComponent();
            WinAPI.SetProcessDPIAware();

            Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height-Height) * 2 / 3);

            FormClosing += (s, e) =>
            {
                if (xbox360Controller != null)
                    xbox360Controller.Disconnect();
                if (host != null)
                    host.Dispose();
            };

            try
            {
                host = new Tobii.Interaction.Host();
                gazePointDataStream = host.Streams.CreateGazePointDataStream();
                gazePointDataStream.GazePoint((gazePointX, gazePointY, _) =>
                {
                    double X = gazePointX;
                    double Y = gazePointY;
                    XY[0] = X;
                    XY[1] = Y;
                });
            }
            catch (Exception ex)
            {
                host = null;
                if (ex.GetType().Equals(typeof(DllNotFoundException)))
                {
                    MessageBox.Show("Tobii.EyeX.Client.dll is missing!");
                }
                else if (ex.GetType().Equals(typeof(BadImageFormatException)))
                {
                    MessageBox.Show("The application seems to be compiled for the wrong version of Tobii.EyeX.Client.dll (32/64 bit)");
                }
                else
                    MessageBox.Show(ex.Message);
            }

            bool AltShiftQ = false;
            bool Ctrl = false;

            Timer tmr = new Timer();
            tmr.Interval = 40;
            tmr.Tick += (s, e) =>
            {
                if (!Overlay.isEditing)
                {
                    if (
                    System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftAlt) &&
                    System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftShift) &&
                    System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Q))
                    {
                        if (!AltShiftQ)
                        {
                            chkEnableOverlays.Checked = !chkEnableOverlays.Checked;
                            AltShiftQ = true;
                        }
                    }
                    else
                        AltShiftQ = false;
                    if (!chkEnableOverlays.Checked && System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl))
                    {
                        if (!Ctrl)
                        {
                            Ctrl = true;
                            if (lstPages.SelectedItem != null)
                                ((Page)lstPages.SelectedItem).CtrlDown(Cursor.Position);
                        }
                        else
                        {
                            if (lstPages.SelectedItem != null)
                                ((Page)lstPages.SelectedItem).CtrlMove(Cursor.Position);
                        }
                    }
                    else if (Ctrl)
                    { 
                        if (lstPages.SelectedItem != null)
                            ((Page)lstPages.SelectedItem).CtrlUp();
                        Ctrl = false;
                    }
                }
                else
                {
                    AltShiftQ = false;
                    Ctrl = false;
                }
                if (chkEnableOverlays.Checked)
                {
                    if (chkMouseAsGaze.Checked)
                    {
                        XY[0] = Cursor.Position.X;
                        XY[1] = Cursor.Position.Y;
                    }
                    if(lstPages.SelectedItem != null)
                        ((Page)lstPages.SelectedItem).Tobii(XY);
                }
            };
            tmr.Start();
            cmdAdd.Click += (s, e) =>
            {
                NewPage();
            };
            bool ignorePageChange = false;
            txtPageName.TextChanged += (s, e) =>
            {
                if (lstPages.SelectedItem != null)
                {
                    ignorePageChange = true;
                    ((Page)lstPages.SelectedItem).Name = txtPageName.Text;
                    lstPages.Items[lstPages.SelectedIndex] = lstPages.SelectedItem;
                    ignorePageChange = false;
                    Save();
                }
            };
            lstPages.SelectedIndexChanged += (s, e) =>
            {
                if (lstPages.SelectedItem == null || ignorePageChange)
                    return;
                txtPageName.Text = ((Page)lstPages.SelectedItem).Name;
                foreach (Page page in lstPages.Items)
                    page.Close();
                ((Page)lstPages.SelectedItem).Show();
                if (!chkEnableOverlays.Checked)
                    Focus();
                ((Page)lstPages.SelectedItem).Play(chkEnableOverlays.Checked);
            };
            lstPages.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Delete && lstPages.SelectedItem != null)
                {
                    ((Page)lstPages.SelectedItem).Close();
                    lstPages.Items.RemoveAt(lstPages.SelectedIndex);
                }
            };

            settingsToolStripMenuItem.Click += (s, e) =>
            {
                new frmSettings().ShowDialog();
            };

            frmSettings.LoadSettings();
            if (frmSettings.StartupFile != "" && System.IO.File.Exists(frmSettings.StartupFile))
                LoadFile(frmSettings.StartupFile);
            if (frmSettings.EnableOverlaysOnStartup)
                chkEnableOverlays.Checked = true;
        }
        double[] XY = new double[2] { double.PositiveInfinity, double.PositiveInfinity };

        void NewPage()
        {
            lstPages.Items.Add(new Page());
            lstPages.SelectedIndex = lstPages.Items.Count - 1;
            Save();
        }

        class Page
        {
            public string Name = "Unnamed";
            public override string ToString()
            {
                return Name;
            }
            List<Overlay> Overlays = new List<Overlay>();
            public Page()
            {
                Overlay prev = new Overlay()
                {
                    UnlockTime = 1500,
                    Description = "Prev",
                    Bounds = new RectangleF(
                        0,
                        0,
                        1 / 8f,
                        1 / 8f)
                };
                prev.outputs = new Output[1] {
                    new Output.ChangePage()
                    {
                        Page = -1,
                    }
                };
                Add(prev);
                Overlay next = new Overlay()
                {
                    UnlockTime = 1500,
                    Description = "Next",
                    Bounds = new RectangleF(
                        7 / 8f,
                        0,
                        1 / 8f,
                        1 / 8f)
                };
                next.outputs = new Output[1] {
                    new Output.ChangePage()
                    {
                        Page = 1,
                    }
                };
                Add(next);
            }
            public Page(MDOL.IO.XML xml_page)
            {
                Name = xml_page.getString("Name", "Unnamed");
                int nOverlays = xml_page.getInt("nOverlays", 0);
                for (int i = 0; i < nOverlays; i++)
                {
                    Overlay overlay = new Overlay(xml_page.getElement("Overlay_" + i));
                    if (overlay != null)
                        Overlays.Add(overlay);
                }
            }
            public void Add(Overlay overlay)
            {
                Overlays.Add(overlay);
            }
            public void Delete(Overlay overlay)
            {
                overlay.Close();
                Overlays.Remove(overlay);
            }
            public void Show()
            {
                foreach (Overlay overlay in Overlays)
                    overlay.Show();
            }
            public void Hide()
            {
                foreach (Overlay overlay in Overlays)
                    overlay.Hide();
            }
            public void Close()
            {
                foreach (Overlay overlay in Overlays)
                    overlay.Close();
            }
            public void Tobii(double[] XY)
            {
                foreach (Overlay overlay in Overlays)
                    overlay.Tobii(XY[0], XY[1]);
            }
            Overlay overlayCtrl = null;
            public void CtrlDown(Point XY)
            {
                foreach (Overlay overlay in Overlays)
                    if (overlay.CtrlDown(XY))
                    {
                        overlayCtrl = overlay;
                        return;
                    }
            }
            public void CtrlMove(Point XY)
            {
                if (overlayCtrl != null)
                    overlayCtrl.CtrlMove(XY);
            }
            public void CtrlUp()
            {
                if (overlayCtrl != null)
                    overlayCtrl.CtrlUp();
                overlayCtrl = null;
            }
            public void Play(bool Enabled)
            {
                foreach (Overlay overlay in Overlays)
                {
                    overlay.Play(Enabled);
                    overlay.Tobii(double.PositiveInfinity, double.PositiveInfinity);
                }
            }
            public MDOL.IO.XML toXML(string name)
            {
                MDOL.IO.XML[] overlays_xml = Overlays.Select((overlay, i) => overlay.toXML("Overlay_" + i)).ToArray();
                return new MDOL.IO.XML(name,
                    new MDOL.IO.XML[] {
                        new MDOL.IO.XML("Name",Name),
                        new MDOL.IO.XML("nOverlays",Overlays.Count.ToString())
                    }.Concat(overlays_xml).ToArray());
            }
        }

        private void cmdAddOverlay_Click(object sender, EventArgs e)
        {
            Overlay overlay = new Overlay();
            if (AddOverlay(overlay))
            {
                ((Page)lstPages.SelectedItem).Add(overlay);
                overlay.Change();
            }
        }
        public bool AddOverlay(Overlay overlay)
        {
            if (lstPages.SelectedItem != null)
            {
                ((Page)lstPages.SelectedItem).Add(overlay);
                overlay.Show();
                return true;
            }
            return false;
        }

        private void chkEnableOverlays_CheckedChanged(object sender, EventArgs e)
        {
            grpPage.Enabled = !chkEnableOverlays.Checked;
            if (lstPages.SelectedItem != null)
                ((Page)lstPages.SelectedItem).Play(chkEnableOverlays.Checked);
        }
        SaveFileDialog sfd = new SaveFileDialog() { Filter = "XML Files | *.xml",InitialDirectory = Application.StartupPath};
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                foreach (Page page in lstPages.Items)
                    page.Close();
                lstPages.Items.Clear();
                currentFile = sfd.FileName;
                Text = System.IO.Path.GetFileNameWithoutExtension(currentFile);
                NewPage();
            }
        }

        OpenFileDialog ofd = new OpenFileDialog() { Filter = "XML Files | *.xml" };
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
                LoadFile(ofd.FileName);
        }
    }
}
