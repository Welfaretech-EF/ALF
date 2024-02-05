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
            System.IO.File.WriteAllText("latestFile.txt", currentFile);
        }
        public void Load(string File)
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
            }
        }

        Tobii.Interaction.Host host = null;
        Tobii.Interaction.GazePointDataStream gazePointDataStream;
        public static Form1 FORM1;
        public static Nefarius.ViGEm.Client.Targets.IXbox360Controller xbox360Controller;
        public Form1()
        {
            xbox360Controller = new Nefarius.ViGEm.Client.ViGEmClient().CreateXbox360Controller();
            xbox360Controller.Connect();
            FORM1 = this;
            InitializeComponent();
            WinAPI.SetProcessDPIAware();
            
            FormClosing += (s, e) =>
            {
                if (xbox360Controller != null)
                    xbox360Controller.Disconnect();
                if (host != null)
                    host.Dispose();
            };

            host = new Tobii.Interaction.Host();
            gazePointDataStream = host.Streams.CreateGazePointDataStream();

            gazePointDataStream.GazePoint((gazePointX, gazePointY, _) =>
            {
                double X = gazePointX;
                double Y = gazePointY;
                XY[0] = X;
                XY[1] = Y;
            });

            bool CtrlShiftQ = false;
            Timer tmr = new Timer();
            tmr.Interval = 20;
            tmr.Tick += (s, e) =>
            {
                if (!Overlay.isEditing &&
                System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftShift) &&
                System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl) &&
                System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Q))
                {
                    if (!CtrlShiftQ)
                    {
                        chkEnableOverlays.Checked = !chkEnableOverlays.Checked;
                        CtrlShiftQ = true;
                    }
                }
                else
                    CtrlShiftQ = false;
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
                lstPages.Items.Add(new Page());
                lstPages.SelectedIndex = lstPages.Items.Count - 1;
                Save();
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

            string latestFile = "";
            if (System.IO.File.Exists("latestFile.txt"))
                latestFile = System.IO.File.ReadAllText("latestFile.txt");
            if (latestFile != "" && System.IO.File.Exists(latestFile))
                Load(latestFile);
            else
                newToolStripMenuItem_Click(null, null);
        }
        double[] XY = new double[2] { -1, -1 };

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
            public void Play(bool Enabled)
            {
                foreach (Overlay overlay in Overlays)
                {
                    overlay.Play(Enabled);
                    overlay.Tobii(-1, -1);
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
            if (lstPages.SelectedItem != null)
            {
                Overlay overlay = new Overlay();
                ((Page)lstPages.SelectedItem).Add(overlay);
                overlay.Show();
                overlay.Change();
            }
        }

        private void chkEnableOverlays_CheckedChanged(object sender, EventArgs e)
        {
            grpPage.Enabled = !chkEnableOverlays.Checked;
            if (lstPages.SelectedItem != null)
                ((Page)lstPages.SelectedItem).Play(chkEnableOverlays.Checked);
        }
        SaveFileDialog sfd = new SaveFileDialog() { Filter = "XML Files | *.xml" };
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                foreach (Page page in lstPages.Items)
                    page.Close();
                lstPages.Items.Clear();
                currentFile = sfd.FileName;
                Text = System.IO.Path.GetFileNameWithoutExtension(currentFile);
                cmdAdd.PerformClick();
            }
        }

        OpenFileDialog ofd = new OpenFileDialog() { Filter = "XML Files | *.xml" };
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
                Load(ofd.FileName);
        }
    }
}
