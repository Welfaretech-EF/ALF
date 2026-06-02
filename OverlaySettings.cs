using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static ALF.MDOL.IO;

namespace ALF
{
    public partial class OverlaySettings : Form
    {
        List<Overlay> Overlays = new List<Overlay>();
        public OverlaySettings(Overlay overlay)
        {
            InitializeComponent();
            Overlays.Add(overlay);
            overlay.UpdateGUI(true);

            Timer tmrSelect = new Timer();
            tmrSelect.Interval = 50;
            bool MouseDown = false;
            tmrSelect.Tick += (s, e) =>
            {
                if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl) && MouseButtons == MouseButtons.Left)
                {
                    if (!MouseDown)
                    {
                        MouseDown = true;
                        foreach (Overlay candidate in Form1.FORM1.CurrentOverlays())
                        {
                            if (candidate.InsideForm(Cursor.Position.X, Cursor.Position.Y))
                            {
                                if (Overlays.Contains(candidate))
                                {
                                    Overlays.Remove(candidate);
                                    candidate.UpdateGUI();
                                }
                                else
                                {
                                    Overlays.Add(candidate);
                                    candidate.UpdateGUI(true);
                                }
                            }
                        }
                    }
                }
                else
                    MouseDown = false;
            };
            tmrSelect.Start();

            cmdSave.Click += (s, e) =>
              {
                  Close();
              };
            Color[] colors = new Color[] { Color.Black, Color.Gray, Color.Red, Color.Green, Color.Blue, Color.Cyan, Color.Magenta, Color.Yellow };
            cmbActivationColor.Items.AddRange(colors.Cast<object>().ToArray());
            cmbWaitColor.Items.AddRange(colors.Cast<object>().ToArray());
            cmbIdleColor.Items.AddRange(colors.Cast<object>().ToArray());

            cmbActivationColor.SelectedItem = overlay.ColorActive;
            cmbWaitColor.SelectedItem = overlay.ColorWaiting;
            cmbIdleColor.SelectedItem = overlay.ColorIdle;

            cmbWaitColor.SelectedIndexChanged += (s, e) => { overlay.ColorWaiting = (Color)cmbWaitColor.SelectedItem; };
            cmbIdleColor.SelectedIndexChanged += (s, e) => { overlay.ColorIdle = (Color)cmbIdleColor.SelectedItem; };
            cmbActivationColor.SelectedIndexChanged += (s, e) => { overlay.ColorActive = (Color)cmbActivationColor.SelectedItem; };

            nudTransaparency.Value = overlay.Transparency;
            nudTransaparency.ValueChanged += (s, e) => { overlay.Transparency = (int)nudTransaparency.Value; };

            Timer tmrCursor = new Timer();
            tmrCursor.Interval = 100;
            tmrCursor.Tick += (s, e) =>
            {
                Text = "Cursor position: (" + Cursor.Position.X + "," + Cursor.Position.Y + ")";
            };
            tmrCursor.Start();

            nudUnlockTime.Value = (decimal)(overlay.UnlockTime / 1000.0);
            nudMaxActivationTime.Value = (decimal)(overlay.MaxActivationTime / 1000.0);
            chkToggleOnActivation.Checked = overlay.ToggleOnActivation;
            chkAlwaysReady.Checked = overlay.AlwaysReady;
            chkActivateOnBlink.Checked = overlay.ActivateOnBlink;
            chkCircular.Checked = overlay.Circular;
            nudCircularX.Value = overlay.CircularX;
            nudCircularY.Value = overlay.CircularY;
            txtDescription.Text = overlay.Description;

            lstOutputs.Items.Clear();
            lstOutputs.Items.AddRange(overlay.outputs);

            cmdAdd.ContextMenu = new ContextMenu();
            foreach(KeyValuePair<string,Func<MDOL.IO.XML,Output>> output in Output.Outputs)
                cmdAdd.ContextMenu.MenuItems.Add(output.Key).Click += (s, e) =>
                {
                    AddOutput(output.Value(null));
                };
            pnlOutput.OnChange += (s, e) =>
              {
                  ignoreChange = true;
                  for (int i = 0; i < lstOutputs.Items.Count; i++)
                      lstOutputs.Items[i] = lstOutputs.Items[i];
                  ignoreChange = false;
              };
            FormClosing += (s, e) =>
              {
                  tmrSelect.Stop();
                  MDOL.IO.XML[] outputs_xml = lstOutputs.Items.Cast<Output>().Select((output, i) => output.toXML("Output_" + i)).ToArray();
                  foreach (Overlay overlays in Overlays)
                  {
                      Output[] outputs = new Output[outputs_xml.Length];
                      for (int i = 0; i < outputs.Length; i++)
                          outputs[i] = Output.fromXML(outputs_xml[i]);
                      overlays.outputs = outputs;
                      overlays.UpdateGUI();
                  }
                  Overlays.Clear();
                  Form1.FORM1.Save();
              };
            chkToggleOnActivation.CheckedChanged += (s, e) =>
              {
                  foreach (Overlay overlays in Overlays)
                      overlays.ToggleOnActivation = chkToggleOnActivation.Checked;
              };
            chkAlwaysReady.CheckedChanged += (s, e) =>
            {
                foreach (Overlay overlays in Overlays)
                    overlays.AlwaysReady = chkAlwaysReady.Checked;
            };
            chkActivateOnBlink.CheckedChanged += (s, e) =>
            {
                foreach (Overlay overlays in Overlays)
                    overlays.ActivateOnBlink = chkActivateOnBlink.Checked;
            };
            chkCircular.CheckedChanged += (s, e) =>
            {
                foreach (Overlay overlays in Overlays)
                    overlays.Circular = chkCircular.Checked;
            };
            nudCircularX.ValueChanged += (s, e) =>
            {
                foreach (Overlay overlays in Overlays)
                    overlays.CircularX = (int)nudCircularX.Value;
            };
            nudCircularY.ValueChanged += (s, e) =>
            {
                foreach (Overlay overlays in Overlays)
                    overlays.CircularY = (int)nudCircularY.Value;
            };
            nudUnlockTime.ValueChanged += (s, e) =>
            {
                foreach (Overlay overlays in Overlays)
                    overlays.UnlockTime = (int)(nudUnlockTime.Value * 1000);
            };
            nudMaxActivationTime.ValueChanged += (s, e) =>
            {
                foreach (Overlay overlays in Overlays)
                    overlays.MaxActivationTime = (int)(nudMaxActivationTime.Value * 1000);
            };
            txtDescription.TextChanged += (s, e) =>
            {
                foreach (Overlay overlays in Overlays)
                    overlays.Description = txtDescription.Text;
            };
            cmdDelete.Click += (s, e) =>
              {
                  if (MessageBox.Show("Are you sure you want to remove this overlay?", "Remove Overlay?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                  {
                      foreach (Overlay overlays in Overlays)
                          Form1.FORM1.DeleteOverlay(overlays);
                      Close();
                  }
              };
            lstOutputs.SelectedIndexChanged += (s, e) =>
            {
                if (ignoreChange)
                    return;
                if (lstOutputs.SelectedItem != null)
                {
                    txtFieldInfo.Text = ((Output)lstOutputs.SelectedItem).InfoString();
                    pnlOutput.PopulatePanel(lstOutputs.SelectedItem);
                }
            };
            lstOutputs.KeyDown += (s, e) =>
              {
                  if (e.KeyCode == Keys.Delete && lstOutputs.SelectedItem != null)
                  {
                      lstOutputs.Items.RemoveAt(lstOutputs.SelectedIndex);
                  }
              };
            cmdAdd.Click += (s, e) =>
              {
                  cmdAdd.ContextMenu.Show(cmdAdd, Point.Empty);
              };
            cmdClone.Click += (s, e) =>
            {
                foreach (Overlay overlays in Overlays)
                {
                    Overlay clone = new Overlay(overlays.toXML("overlay"));
                    clone.Bounds.X += 0.1f;
                    clone.Bounds.Y += 0.1f;
                    Form1.FORM1.AddOverlay(clone);
                }
            };
            cmdSplit.Click += (s, e) =>
            {
                Form frm = new Form();
                frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                frm.Bounds = new Rectangle(Screen.PrimaryScreen.Bounds.Width / 4, Screen.PrimaryScreen.Bounds.Height / 4, Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
                int W = frm.Bounds.Width / 10;
                int H = frm.Bounds.Height / 10;
                Button[,] buttons = new Button[10, 10];
                for (int R = 0; R < 10;R++)
                    for (int C = 0; C < 10; C++)
                    {
                        buttons[R, C] = new Button()
                        {
                            Bounds = new Rectangle(C * W, R * H, W, H),
                            Tag = new int[2] { R, C }
                        };
                        buttons[R, C].Click += (ss, ee) =>
                        {
                            int[] RC = (int[])((Button)ss).Tag;
                            RectangleF bounds = overlay.Bounds;
                            float w = bounds.Width / (RC[1] + 1);
                            float h = bounds.Height / (RC[0] + 1);
                            Overlays.Clear();
                            for (int r = 0; r <= RC[0];r++)
                                for (int c = 0; c <= RC[1]; c++)
                                {
                                    if (r == 0 && c == 0)
                                    {
                                        overlay.Bounds = new RectangleF(bounds.X, bounds.Y, w, h);
                                        overlay.frm.Bounds = overlay.screenBounds();
                                        Overlays.Add(overlay);
                                    }
                                    else
                                    {
                                        Overlay clone = new Overlay(overlay.toXML("overlay"));
                                        clone.Bounds = new RectangleF(bounds.X + c * w, bounds.Y + r * h, w, h);
                                        Form1.FORM1.AddOverlay(clone);
                                        Overlays.Add(clone);
                                    }
                                }
                            //Overlay overlay = new Overlay();
                            frm.Close();
                        };
                        buttons[R, C].MouseMove += (ss, ee) =>
                        {
                            int[] RC = (int[])((Button)ss).Tag;
                            for (int r = 0; r < 10;r++)
                                for (int c = 0; c < 10; c++)
                                {
                                    int[] rc = (int[])buttons[r, c].Tag;
                                    buttons[r, c].BackColor = rc[0] <= RC[0] && rc[1] <= RC[1] ? Color.Blue : SystemColors.Control;
                                }
                        };
                        frm.Controls.Add(buttons[R,C]);
                    }
                frm.TopMost = true;
                frm.ShowDialog();
            };
        }
        bool ignoreChange = false;
        void AddOutput(Output output)
        {
            lstOutputs.Items.Add(output);
            lstOutputs.SelectedIndex = lstOutputs.Items.Count - 1;
        }

        OpenFileDialog ofd = new OpenFileDialog()
        {
            Filter = "Image Files|*.png;*.jpg",
        };
        private void cmdImage_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (Overlay overlays in Overlays)
                    overlays.ImageFile = ofd.FileName;
            }
            else
            {
                foreach (Overlay overlays in Overlays)
                    overlays.ImageFile = null;
            }
        }
    }
}