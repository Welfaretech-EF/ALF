using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using static ALF.XYDevice;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ALF
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
            if (currentFile != "")
            {
                MDOL.IO.XML[] pages_xml = lstPages.Items.Cast<Page>().Select((page, i) => page.toXML("Page_" + i)).ToArray();
                MDOL.IO.XML xml = new MDOL.IO.XML("Pages",
                    new MDOL.IO.XML[] {
                    new MDOL.IO.XML("nPages",lstPages.Items.Count.ToString())
                    }.Concat(pages_xml).ToArray());
                System.IO.File.WriteAllText(currentFile, xml.ToString(0));
            }
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

        public static Form1 FORM1;
        public static Nefarius.ViGEm.Client.Targets.IXbox360Controller xbox360Controller;
        bool OverlaysHidden = false;
        XYDevice XYDevice = null;

        static string foundUrl = null;
        static void DeviceUrlReceiver(IntPtr urlPtr, IntPtr userData)
        {
            // Convert C string → C#
            foundUrl = Marshal.PtrToStringAnsi(urlPtr);
        }

        public Form1()
        {
            InitializeComponent();
            cmdHideOverlays.Click += (s, e) =>
            {
                OverlaysHidden = !OverlaysHidden;
                if (OverlaysHidden)
                {
                    if (lstPages.SelectedItem != null)
                        ((Page)lstPages.SelectedItem).Close();
                    cmdHideOverlays.Text = "Show Overlays";
                }
                else
                {
                    if (lstPages.SelectedItem != null)
                        ((Page)lstPages.SelectedItem).Show();
                    cmdHideOverlays.Text = "Hide Overlays";
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
                            MessageBox.Show("Something went wrong - the driver is still missing!\r\n" + exNew.Message);
                        }
                    }
                }
            }
            FORM1 = this;
            
            WinAPI.SetProcessDPIAware();

            double dpiScale = Screen.PrimaryScreen.Bounds.Width / System.Windows.SystemParameters.PrimaryScreenWidth;

            Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height-Height) * 2 / 3);

            /*
             * BeamEyeTracker.API api = new BeamEyeTracker.API(
                "DeleteMe",
                new BeamEyeTracker.ViewportGeometry());
            Timer tmr = new Timer();
            tmr.Interval = 100;
            BackgroundImageLayout = ImageLayout.Stretch;
            tmr.Tick += (s, e) =>
            {
                Bitmap bmp = new Bitmap(512, 512);
                using(Graphics g = Graphics.FromImage(bmp))
                {
                    BeamEyeTracker.TrackingStateSet trackingStateSet = api.GetLatestTrackingStateSet();
                    int X = (int)(trackingStateSet.UserState.UnifiedScreenGaze.PointOfRegard.X*512/Screen.PrimaryScreen.Bounds.Width*0.8);
                    int Y =(int)(trackingStateSet.UserState.UnifiedScreenGaze.PointOfRegard.Y * 512 / Screen.PrimaryScreen.Bounds.Height*0.8);
                    g.FillEllipse(Brushes.Red, new RectangleF(X, Y, 10, 10));
                }
                if (BackgroundImage != null)
                    BackgroundImage.Dispose();
                BackgroundImage = bmp;
            };
            tmr.Start();
             */

            FormClosing += (s, e) =>
            {
                if (xbox360Controller != null)
                    xbox360Controller.Disconnect();
                if (XYDevice != null)
                    XYDevice.Dispose();
            };

            XYDevice = new XYDevice.Tobii5();
            XYDevice.XYRecieved += XYDevice_XYRecieved;

            ToolStripMenuItem tobiiTracker5ToolStripMenuItem = (ToolStripMenuItem)deviceToolStripMenuItem.DropDownItems.Add("Tobii Tracker 5");
            tobiiTracker5ToolStripMenuItem.Checked = true;
            tobiiTracker5ToolStripMenuItem.Click += (s, e) =>
            {
                foreach (ToolStripMenuItem toolStripMenuItem in deviceToolStripMenuItem.DropDownItems)
                    toolStripMenuItem.Checked = toolStripMenuItem == s;
                XYDevice.Dispose();
                XYDevice = null;
                XYDevice = new XYDevice.Tobii5();
                XYDevice.XYRecieved += XYDevice_XYRecieved;
            };
            ToolStripMenuItem tobiiTracker5StreamToolStripMenuItem = (ToolStripMenuItem)deviceToolStripMenuItem.DropDownItems.Add("Tobii Tracker 5 (Stream)");
            tobiiTracker5StreamToolStripMenuItem.Click += (s, e) =>
            {
                foreach (ToolStripMenuItem toolStripMenuItem in deviceToolStripMenuItem.DropDownItems)
                    toolStripMenuItem.Checked = toolStripMenuItem == s;
                XYDevice.Dispose();
                XYDevice = null;
                XYDevice = new XYDevice.TobiiStreamEngine();
                XYDevice.XYRecieved += XYDevice_XYRecieved;
            };
            ToolStripMenuItem mouseToolStripMenuItem = (ToolStripMenuItem)deviceToolStripMenuItem.DropDownItems.Add("Mouse");
            mouseToolStripMenuItem.Click += (s, e) =>
            {
                foreach (ToolStripMenuItem toolStripMenuItem in deviceToolStripMenuItem.DropDownItems)
                    toolStripMenuItem.Checked = toolStripMenuItem == s;
                XYDevice.Dispose();
                XYDevice = null;
                XYDevice = new XYDevice.Mouse();
                XYDevice.XYRecieved += XYDevice_XYRecieved;
            };
            ToolStripMenuItem relativeMouseToolStripMenuItem = (ToolStripMenuItem)deviceToolStripMenuItem.DropDownItems.Add("Relative Mouse");
            relativeMouseToolStripMenuItem.Click += (s, e) =>
            {
                foreach (ToolStripMenuItem toolStripMenuItem in deviceToolStripMenuItem.DropDownItems)
                    toolStripMenuItem.Checked = toolStripMenuItem == s;
                XYDevice.Dispose();
                XYDevice = null;
                XYDevice = new XYDevice.RelativeMouse();
                XYDevice.XYRecieved += XYDevice_XYRecieved;
            };
            //AForge.Video.DirectShow.FilterInfoCollection videoDevices = new AForge.Video.DirectShow.FilterInfoCollection(AForge.Video.DirectShow.FilterCategory.VideoInputDevice);
            //XYDevice = new XYDevice.Face(videoDevices[2].MonikerString);

            bool AltShiftQ = false;
            bool Ctrl = false;

            Timer tmr = new Timer();
            tmr.Interval = 30;
            tmr.Tick += (s, e) =>
            {
                CtrlDown = Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl);
                if (!Overlay.isEditing)
                {
                    if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftAlt) &&
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
                    if (!chkEnableOverlays.Checked && CtrlDown)
                    {
                        if (!Ctrl)
                        {
                            Ctrl = true;
                            if (lstPages.SelectedItem != null)
                                ((Page)lstPages.SelectedItem).CtrlDown(System.Windows.Forms.Cursor.Position);
                        }
                        else
                        {
                            if (lstPages.SelectedItem != null)
                                ((Page)lstPages.SelectedItem).CtrlMove(System.Windows.Forms.Cursor.Position);
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
                if (lstPages.SelectedItem != null)
                {
                    Page page = (Page)lstPages.SelectedItem;
                    if (chkEnableOverlays.Checked)
                        page.Tobii(XY);
                    else
                        foreach (Overlay overlay in page.Overlays)
                            if (overlay.AlwaysReady)
                                overlay.XYPoint(XY);
                }
            };
            tmr.Start();
            cmdAdd.Click += (s, e) =>
            {
                if(currentFile != "")
                    NewPage();
                else
                    MessageBox.Show("No file selected - create or open a file from the File-menu");
            };
            cmdUp.Click += (s, e) =>
            {
                if(lstPages.SelectedItem != null && lstPages.SelectedIndex>0)
                {
                    object obj1 = lstPages.Items[lstPages.SelectedIndex - 1];
                    object obj2 = lstPages.Items[lstPages.SelectedIndex];
                    lstPages.Items[lstPages.SelectedIndex - 1] = obj2;
                    lstPages.Items[lstPages.SelectedIndex] = obj1;
                    lstPages.SelectedIndex = lstPages.SelectedIndex - 1;
                }
            };
            cmdDown.Click += (s, e) =>
            {
                if (lstPages.SelectedItem != null && lstPages.SelectedIndex < lstPages.Items.Count - 1)
                {
                    object obj1 = lstPages.Items[lstPages.SelectedIndex];
                    object obj2 = lstPages.Items[lstPages.SelectedIndex + 1];
                    lstPages.Items[lstPages.SelectedIndex] = obj2;
                    lstPages.Items[lstPages.SelectedIndex + 1] = obj1;
                    lstPages.SelectedIndex = lstPages.SelectedIndex + 1;
                }
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

            aboutToolStripMenuItem.Click += (s, e) =>
            {
                Form frm = new Form();
                RichTextBox rtb = new RichTextBox()
                {
                    Text = "ALF\r\nDeveloped By: The Elsass Foundation\r\nGitHub:https://github.com/Welfaretech-EF\r\nContact: mdol@elsassfonden.dk",
                    ReadOnly = true,
                    Bounds = new Rectangle(10, 10, 380, 200),
                };
                rtb.LinkClicked+= (s2, e2) =>
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e2.LinkText) { UseShellExecute = true });
                };
                frm.Controls.Add(rtb);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Size= new Size(410, 250);
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm.ShowDialog();
            };

            frmSettings.LoadSettings();
            if (frmSettings.StartupFile != "" && System.IO.File.Exists(frmSettings.StartupFile))
                LoadFile(frmSettings.StartupFile);
            if (frmSettings.EnableOverlaysOnStartup)
                chkEnableOverlays.Checked = true;

            //xyForm = new XYForm();
            //xyForm.Show();
        }
        //XYForm xyForm;

        bool CtrlDown = false;
        private void XYDevice_XYRecieved(object sender, XYPoint e)
        {
            XY = e;
            if(XY.Relative)
            {
                XY.X = XY.X * Screen.PrimaryScreen.Bounds.Width;
                XY.Y = XY.Y * Screen.PrimaryScreen.Bounds.Height;
            }
            if (frmSettings.MouseAssist && CtrlDown)
                XY = new XYPoint(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);
            if(XYDevice.FollowUser)
            {
                int diffX = (int)XY.X - Screen.PrimaryScreen.Bounds.Width / 2;
                int diffY = (int)XY.Y - Screen.PrimaryScreen.Bounds.Height / 2;
                int newX = Math.Sign(diffX) * Math.Abs(diffX) * FollowUserX / 1000 + System.Windows.Forms.Cursor.Position.X;
                int newY = Math.Sign(diffY) * Math.Abs(diffY) * FollowUserY / 1000 + System.Windows.Forms.Cursor.Position.Y;
                System.Windows.Forms.Cursor.Position = new Point(newX, newY);
            }
            //xyForm.SetXY(e.X, e.Y);
        }

        XYPoint XY = new XYPoint();

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
            public List<Overlay> Overlays = new List<Overlay>();
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
            public void Tobii(XYPoint XY)
            {
                foreach (Overlay overlay in Overlays)
                {
                    overlay.XYPoint(XY);
                }
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
                    overlay.XYPoint(new XYPoint());
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
                overlay.Change();
        }
        public List<Overlay> CurrentOverlays()
        {
            if (lstPages.SelectedItem != null)
                return ((Page)lstPages.SelectedItem).Overlays;
            else
                return null;
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
        SaveFileDialog sfd = new SaveFileDialog() { Filter = "ALF Files|*.alf",InitialDirectory = Application.StartupPath};
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

        OpenFileDialog ofd = new OpenFileDialog() { Filter = "ALF Files|*.alf;*.xml" };
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadFile(ofd.FileName);
            }
        }
    }
}
