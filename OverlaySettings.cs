using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FlexibleEyeController
{
    public partial class OverlaySettings : Form
    {
        public OverlaySettings(Overlay overlay)
        {
            InitializeComponent();

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
            chkToggleOnActivation.Checked = overlay.ToggleOnActivation;
            chkCircular.Checked = overlay.Circular;
            nudCircularX.Value = overlay.CircularX;
            nudCircularY.Value = overlay.CircularY;
            txtDescription.Text = overlay.Description;

            lstOutputs.Items.Clear();
            lstOutputs.Items.AddRange(overlay.outputs);

            cmdAdd.ContextMenu = new ContextMenu();
            cmdAdd.ContextMenu.MenuItems.Add("MouseMove").Click += (s, e) =>
              {
                  AddOutput(new Output.MouseMove());
              };
            cmdAdd.ContextMenu.MenuItems.Add("MouseClick").Click += (s, e) =>
            {
                AddOutput(new Output.MouseClick());
            };
            cmdAdd.ContextMenu.MenuItems.Add("Key").Click += (s, e) =>
            {
                AddOutput(new Output.KeyPress());
            };
            cmdAdd.ContextMenu.MenuItems.Add("ChangeFile").Click += (s, e) =>
            {
                AddOutput(new Output.ChangeFile());
            };
            cmdAdd.ContextMenu.MenuItems.Add("ChangePage").Click += (s, e) =>
            {
                AddOutput(new Output.ChangePage());
            };
            cmdAdd.ContextMenu.MenuItems.Add("Joystick").Click += (s, e) =>
            {
                AddOutput(new Output.Joystick());
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
                  overlay.outputs = lstOutputs.Items.Cast<Output>().ToArray();
              };
            chkToggleOnActivation.CheckedChanged += (s, e) =>
              {
                  overlay.ToggleOnActivation = chkToggleOnActivation.Checked;
              };
            chkCircular.CheckedChanged += (s, e) =>
            {
                overlay.Circular = chkCircular.Checked;
            };
            nudCircularX.ValueChanged+=(s,e)=>
            {
                overlay.CircularX = (int)nudCircularX.Value;
            };
            nudCircularY.ValueChanged += (s, e) =>
            {
                overlay.CircularY = (int)nudCircularY.Value;
            };
            nudUnlockTime.ValueChanged += (s, e) =>
            {
                overlay.UnlockTime = (int)(nudUnlockTime.Value * 1000);
            };
            txtDescription.TextChanged += (s, e) =>
            {
                overlay.Description = txtDescription.Text;
            };
            cmdDelete.Click += (s, e) =>
              {
                  if (MessageBox.Show("Are you sure you want to remove this overlay?", "Remove Overlay?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                  {
                      Form1.FORM1.DeleteOverlay(overlay);
                      Form1.FORM1.Save();
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
                Overlay clone = new Overlay(overlay.toXML("overlay"));
                clone.Bounds.X += 0.1f;
                clone.Bounds.Y += 0.1f;
                Form1.FORM1.AddOverlay(clone);
            };
        }
        bool ignoreChange = false;
        void AddOutput(Output output)
        {
            lstOutputs.Items.Add(output);
            lstOutputs.SelectedIndex = lstOutputs.Items.Count - 1;
        }
    }
}