using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlexibleEyeController
{
    public partial class EditablePanel : UserControl
    {
        public event EventHandler OnChange = null;
        public EditablePanel()
        {
            InitializeComponent();
        }

        public void PopulatePanel<T>(T Item)
        {
            Controls.Clear();

            int h = 20;
            int hSpace = 12;
            System.Reflection.FieldInfo[] fields = Item.GetType().GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                Label label = new Label()
                {
                    Size = new Size(Width / 3, h),
                    Location = new Point(12, (h + hSpace) * i + 12),
                    Text = fields[i].Name.Replace('_', ' ').Replace("PS", "(").Replace("PE", ")"),
                };
                Controls.Add(label);
                object value = fields[i].GetValue(Item);
                Control control = null;
                if (value.GetType() == typeof(string))
                {
                    TextBox txt = new TextBox() { Text = (string)value };
                    txt.TextChanged += (nud_s, nud_e) =>
                    {
                        Change((System.Reflection.FieldInfo)txt.Tag, txt.Text, Item);
                    };
                    control = txt;
                }
                else if (value.GetType() == typeof(float))
                {
                    NumericUpDown nud = new NumericUpDown()
                    {
                        Minimum = decimal.MinValue,
                        Maximum = decimal.MaxValue,
                        Value = (decimal)(float)value,
                        DecimalPlaces = 2,
                        Increment = (decimal)0.1
                    };
                    nud.MouseWheel += (nud_s, nud_e) =>
                    {
                        ((HandledMouseEventArgs)nud_e).Handled = true;
                    };
                    nud.ValueChanged += (nud_s, nud_e) =>
                    {
                        Change((System.Reflection.FieldInfo)nud.Tag, (float)nud.Value, Item);
                    };
                    control = nud;
                }
                else if (value.GetType() == typeof(int))
                {
                    NumericUpDown nud = new NumericUpDown()
                    {
                        Minimum = decimal.MinValue,
                        Maximum = decimal.MaxValue,
                        Value = (int)value,
                    };
                    nud.MouseWheel += (nud_s, nud_e) =>
                    {
                        ((HandledMouseEventArgs)nud_e).Handled = true;
                    };
                    nud.ValueChanged += (nud_s, nud_e) =>
                    {
                        Change((System.Reflection.FieldInfo)nud.Tag, (int)nud.Value, Item);
                    };
                    control = nud;
                }
                else if (value.GetType() == typeof(bool))
                {
                    CheckBox chk = new CheckBox()
                    {
                        Checked = (bool)value,
                    };
                    chk.CheckedChanged += (chk_s, chk_e) =>
                    {
                        Change((System.Reflection.FieldInfo)chk.Tag, chk.Checked, Item);
                    };
                    control = chk;
                }
                else if (value.GetType() == typeof(Color))
                {
                    ComboBox cmbColor = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList };
                    cmbColor.Items.Add(Color.Red);
                    cmbColor.Items.Add(Color.Green);
                    cmbColor.Items.Add(Color.Blue);
                    cmbColor.Items.Add(Color.Magenta);
                    cmbColor.Items.Add(Color.Cyan);
                    cmbColor.Items.Add(Color.Yellow);
                    cmbColor.Items.Add(Color.Transparent);
                    cmbColor.Items.Add(Color.Black);
                    cmbColor.SelectedItem = (Color)value;
                    cmbColor.SelectedIndexChanged += (cmb_s, cmb_e) =>
                    {
                        Change((System.Reflection.FieldInfo)cmbColor.Tag, cmbColor.SelectedItem, Item);
                    };
                    cmbColor.MouseWheel += (cmb_s, cmb_e) =>
                    {
                        ((HandledMouseEventArgs)cmb_e).Handled = true;
                    };
                    control = cmbColor;
                }
                else if (value.GetType() == typeof(Keys))
                {
                    Button cmdKey = new Button() { Text = value.ToString() };
                    cmdKey.Click += (cmd_s, cmd_e) =>
                    {
                        int H = Screen.PrimaryScreen.Bounds.Height / 8;
                        int W = Screen.PrimaryScreen.Bounds.Width / 8;
                        Font font = new Font(FontFamily.GenericSansSerif, 10f);
                        Bitmap bmp = new Bitmap(256, 256);
                        MDOL.Helper.DrawCenteredString(bmp, "Press a Key");
                        Form frm = new Form()
                        {
                            StartPosition = FormStartPosition.CenterParent,
                            FormBorderStyle = FormBorderStyle.None,
                            Height = H,
                            Width = W,
                            TopMost = true,
                            BackgroundImageLayout = ImageLayout.Stretch,
                            BackgroundImage = bmp
                        };

                        frm.KeyDown += (frm_s, frm_e) =>
                        {
                            cmdKey.Text = frm_e.KeyCode.ToString();
                            Change((System.Reflection.FieldInfo)cmdKey.Tag, frm_e.KeyCode, Item);
                            frm.Close();
                        };
                        frm.ShowDialog();
                    };
                    control = cmdKey;
                }
                else if (value.GetType().IsEnum)
                {
                    ComboBox cmbEnum = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList };
                    Array array = Enum.GetValues(value.GetType());
                    foreach (object obj in Enum.GetValues(value.GetType()))
                        cmbEnum.Items.Add(obj);
                    cmbEnum.SelectedItem = value;
                    cmbEnum.SelectedIndexChanged += (cmb_s, cmb_e) =>
                    {
                        Change((System.Reflection.FieldInfo)cmbEnum.Tag, cmbEnum.SelectedItem, Item);
                    };
                    cmbEnum.MouseWheel += (cmb_s, cmb_e) =>
                    {
                        ((HandledMouseEventArgs)cmb_e).Handled = true;
                    };
                    control = cmbEnum;
                }
                else if (value.GetType() == typeof(OpenFileDialog))
                {
                    Button cmdOFD = new Button() { Text = ((OpenFileDialog)value).SafeFileName };
                    cmdOFD.Click += (s, e) =>
                    {
                        if (((OpenFileDialog)value).ShowDialog() == DialogResult.OK)
                        {
                            cmdOFD.Text = ((OpenFileDialog)value).SafeFileName;
                            Change((System.Reflection.FieldInfo)cmdOFD.Tag, value, Item);
                        }

                    };
                    control = cmdOFD;
                }
                else
                {
                    label.ForeColor = Color.Red;
                }

                if (control != null)
                {
                    control.Tag = fields[i];
                    control.Size = new Size(Width / 3, h);
                    control.Location = new Point((int)(12 + Width / 3 * 1.5), (h + hSpace) * i + 12);
                    Controls.Add(control);
                }
            }
        }

        void Change<T>(System.Reflection.FieldInfo fieldInfo, object value, T Item)
        {
            fieldInfo.SetValue(Item, value);
            OnChange?.Invoke(this, null);
        }
    }
}
