
namespace ALF
{
    partial class OverlaySettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdDelete = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClone = new System.Windows.Forms.Button();
            this.cmdImage = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInput = new System.Windows.Forms.TabPage();
            this.chkActivateOnBlink = new System.Windows.Forms.CheckBox();
            this.chkAlwaysReady = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nudMaxActivationTime = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudCircularY = new System.Windows.Forms.NumericUpDown();
            this.nudCircularX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpUnlockTime = new System.Windows.Forms.GroupBox();
            this.nudUnlockTime = new System.Windows.Forms.NumericUpDown();
            this.chkCircular = new System.Windows.Forms.CheckBox();
            this.chkToggleOnActivation = new System.Windows.Forms.CheckBox();
            this.tabAppearence = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudTransaparency = new System.Windows.Forms.NumericUpDown();
            this.grpIdleColor = new System.Windows.Forms.GroupBox();
            this.cmbIdleColor = new System.Windows.Forms.ComboBox();
            this.grpWaitColor = new System.Windows.Forms.GroupBox();
            this.cmbWaitColor = new System.Windows.Forms.ComboBox();
            this.grpActivationColor = new System.Windows.Forms.GroupBox();
            this.cmbActivationColor = new System.Windows.Forms.ComboBox();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.txtFieldInfo = new System.Windows.Forms.TextBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lstOutputs = new System.Windows.Forms.ListBox();
            this.cmdSplit = new System.Windows.Forms.Button();
            this.pnlOutput = new ALF.EditablePanel();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabInput.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxActivationTime)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCircularY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCircularX)).BeginInit();
            this.grpUnlockTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnlockTime)).BeginInit();
            this.tabAppearence.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTransaparency)).BeginInit();
            this.grpIdleColor.SuspendLayout();
            this.grpWaitColor.SuspendLayout();
            this.grpActivationColor.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.Color.Red;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Location = new System.Drawing.Point(166, 461);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(142, 54);
            this.cmdDelete.TabIndex = 6;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(6, 34);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(279, 34);
            this.txtDescription.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 86);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(12, 104);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(148, 62);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = false;
            // 
            // cmdClone
            // 
            this.cmdClone.BackColor = System.Drawing.Color.Blue;
            this.cmdClone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClone.ForeColor = System.Drawing.Color.White;
            this.cmdClone.Location = new System.Drawing.Point(166, 104);
            this.cmdClone.Name = "cmdClone";
            this.cmdClone.Size = new System.Drawing.Size(140, 62);
            this.cmdClone.TabIndex = 9;
            this.cmdClone.Text = "Clone";
            this.cmdClone.UseVisualStyleBackColor = false;
            // 
            // cmdImage
            // 
            this.cmdImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cmdImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImage.Location = new System.Drawing.Point(12, 172);
            this.cmdImage.Name = "cmdImage";
            this.cmdImage.Size = new System.Drawing.Size(148, 55);
            this.cmdImage.TabIndex = 10;
            this.cmdImage.Text = "Image";
            this.cmdImage.UseVisualStyleBackColor = false;
            this.cmdImage.Click += new System.EventHandler(this.cmdImage_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInput);
            this.tabControl1.Controls.Add(this.tabAppearence);
            this.tabControl1.Controls.Add(this.tabOutput);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(312, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(594, 503);
            this.tabControl1.TabIndex = 12;
            // 
            // tabInput
            // 
            this.tabInput.Controls.Add(this.chkActivateOnBlink);
            this.tabInput.Controls.Add(this.chkAlwaysReady);
            this.tabInput.Controls.Add(this.groupBox4);
            this.tabInput.Controls.Add(this.groupBox2);
            this.tabInput.Controls.Add(this.grpUnlockTime);
            this.tabInput.Controls.Add(this.chkCircular);
            this.tabInput.Controls.Add(this.chkToggleOnActivation);
            this.tabInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInput.Location = new System.Drawing.Point(4, 38);
            this.tabInput.Name = "tabInput";
            this.tabInput.Size = new System.Drawing.Size(586, 461);
            this.tabInput.TabIndex = 2;
            this.tabInput.Text = "Input";
            this.tabInput.UseVisualStyleBackColor = true;
            // 
            // chkActivateOnBlink
            // 
            this.chkActivateOnBlink.AutoSize = true;
            this.chkActivateOnBlink.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivateOnBlink.Location = new System.Drawing.Point(9, 409);
            this.chkActivateOnBlink.Name = "chkActivateOnBlink";
            this.chkActivateOnBlink.Size = new System.Drawing.Size(212, 33);
            this.chkActivateOnBlink.TabIndex = 18;
            this.chkActivateOnBlink.Text = "Activate On Blink";
            this.chkActivateOnBlink.UseVisualStyleBackColor = true;
            // 
            // chkAlwaysReady
            // 
            this.chkAlwaysReady.AutoSize = true;
            this.chkAlwaysReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAlwaysReady.Location = new System.Drawing.Point(9, 370);
            this.chkAlwaysReady.Name = "chkAlwaysReady";
            this.chkAlwaysReady.Size = new System.Drawing.Size(173, 33);
            this.chkAlwaysReady.TabIndex = 17;
            this.chkAlwaysReady.Text = "Always ready";
            this.chkAlwaysReady.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudMaxActivationTime);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(3, 86);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(410, 78);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Max Activation Time (0.0=disabled)";
            // 
            // nudMaxActivationTime
            // 
            this.nudMaxActivationTime.DecimalPlaces = 1;
            this.nudMaxActivationTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMaxActivationTime.Location = new System.Drawing.Point(6, 33);
            this.nudMaxActivationTime.Name = "nudMaxActivationTime";
            this.nudMaxActivationTime.Size = new System.Drawing.Size(150, 34);
            this.nudMaxActivationTime.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudCircularY);
            this.groupBox2.Controls.Add(this.nudCircularX);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 116);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CircularScale in %";
            // 
            // nudCircularY
            // 
            this.nudCircularY.DecimalPlaces = 1;
            this.nudCircularY.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCircularY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCircularY.Location = new System.Drawing.Point(48, 76);
            this.nudCircularY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCircularY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudCircularY.Name = "nudCircularY";
            this.nudCircularY.Size = new System.Drawing.Size(128, 34);
            this.nudCircularY.TabIndex = 11;
            this.nudCircularY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudCircularX
            // 
            this.nudCircularX.DecimalPlaces = 1;
            this.nudCircularX.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCircularX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCircularX.Location = new System.Drawing.Point(48, 36);
            this.nudCircularX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCircularX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudCircularX.Name = "nudCircularX";
            this.nudCircularX.Size = new System.Drawing.Size(128, 34);
            this.nudCircularX.TabIndex = 2;
            this.nudCircularX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "X";
            // 
            // grpUnlockTime
            // 
            this.grpUnlockTime.Controls.Add(this.nudUnlockTime);
            this.grpUnlockTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUnlockTime.Location = new System.Drawing.Point(3, 3);
            this.grpUnlockTime.Name = "grpUnlockTime";
            this.grpUnlockTime.Size = new System.Drawing.Size(345, 77);
            this.grpUnlockTime.TabIndex = 12;
            this.grpUnlockTime.TabStop = false;
            this.grpUnlockTime.Text = "Time to unlock";
            // 
            // nudUnlockTime
            // 
            this.nudUnlockTime.DecimalPlaces = 1;
            this.nudUnlockTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudUnlockTime.Location = new System.Drawing.Point(6, 33);
            this.nudUnlockTime.Name = "nudUnlockTime";
            this.nudUnlockTime.Size = new System.Drawing.Size(150, 34);
            this.nudUnlockTime.TabIndex = 1;
            // 
            // chkCircular
            // 
            this.chkCircular.AutoSize = true;
            this.chkCircular.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCircular.Location = new System.Drawing.Point(9, 209);
            this.chkCircular.Name = "chkCircular";
            this.chkCircular.Size = new System.Drawing.Size(115, 33);
            this.chkCircular.TabIndex = 15;
            this.chkCircular.Text = "Circular";
            this.chkCircular.UseVisualStyleBackColor = true;
            // 
            // chkToggleOnActivation
            // 
            this.chkToggleOnActivation.AutoSize = true;
            this.chkToggleOnActivation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkToggleOnActivation.Location = new System.Drawing.Point(9, 170);
            this.chkToggleOnActivation.Name = "chkToggleOnActivation";
            this.chkToggleOnActivation.Size = new System.Drawing.Size(222, 33);
            this.chkToggleOnActivation.TabIndex = 14;
            this.chkToggleOnActivation.Text = "Hold on activation";
            this.chkToggleOnActivation.UseVisualStyleBackColor = true;
            // 
            // tabAppearence
            // 
            this.tabAppearence.Controls.Add(this.groupBox3);
            this.tabAppearence.Controls.Add(this.grpIdleColor);
            this.tabAppearence.Controls.Add(this.grpWaitColor);
            this.tabAppearence.Controls.Add(this.grpActivationColor);
            this.tabAppearence.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAppearence.Location = new System.Drawing.Point(4, 38);
            this.tabAppearence.Name = "tabAppearence";
            this.tabAppearence.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppearence.Size = new System.Drawing.Size(586, 461);
            this.tabAppearence.TabIndex = 0;
            this.tabAppearence.Text = "Appearence";
            this.tabAppearence.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudTransaparency);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 283);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 79);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transparency (%)";
            // 
            // nudTransaparency
            // 
            this.nudTransaparency.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTransaparency.Location = new System.Drawing.Point(6, 33);
            this.nudTransaparency.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudTransaparency.Name = "nudTransaparency";
            this.nudTransaparency.Size = new System.Drawing.Size(223, 34);
            this.nudTransaparency.TabIndex = 4;
            this.nudTransaparency.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // grpIdleColor
            // 
            this.grpIdleColor.Controls.Add(this.cmbIdleColor);
            this.grpIdleColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpIdleColor.Location = new System.Drawing.Point(6, 17);
            this.grpIdleColor.Name = "grpIdleColor";
            this.grpIdleColor.Size = new System.Drawing.Size(252, 79);
            this.grpIdleColor.TabIndex = 8;
            this.grpIdleColor.TabStop = false;
            this.grpIdleColor.Text = "Idle Color";
            // 
            // cmbIdleColor
            // 
            this.cmbIdleColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdleColor.FormattingEnabled = true;
            this.cmbIdleColor.Location = new System.Drawing.Point(6, 29);
            this.cmbIdleColor.Name = "cmbIdleColor";
            this.cmbIdleColor.Size = new System.Drawing.Size(223, 37);
            this.cmbIdleColor.TabIndex = 0;
            // 
            // grpWaitColor
            // 
            this.grpWaitColor.Controls.Add(this.cmbWaitColor);
            this.grpWaitColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpWaitColor.Location = new System.Drawing.Point(6, 192);
            this.grpWaitColor.Name = "grpWaitColor";
            this.grpWaitColor.Size = new System.Drawing.Size(252, 85);
            this.grpWaitColor.TabIndex = 7;
            this.grpWaitColor.TabStop = false;
            this.grpWaitColor.Text = "Waiting Color";
            // 
            // cmbWaitColor
            // 
            this.cmbWaitColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWaitColor.FormattingEnabled = true;
            this.cmbWaitColor.Location = new System.Drawing.Point(6, 33);
            this.cmbWaitColor.Name = "cmbWaitColor";
            this.cmbWaitColor.Size = new System.Drawing.Size(223, 37);
            this.cmbWaitColor.TabIndex = 0;
            // 
            // grpActivationColor
            // 
            this.grpActivationColor.Controls.Add(this.cmbActivationColor);
            this.grpActivationColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpActivationColor.Location = new System.Drawing.Point(6, 102);
            this.grpActivationColor.Name = "grpActivationColor";
            this.grpActivationColor.Size = new System.Drawing.Size(252, 84);
            this.grpActivationColor.TabIndex = 6;
            this.grpActivationColor.TabStop = false;
            this.grpActivationColor.Text = "Activation Color";
            // 
            // cmbActivationColor
            // 
            this.cmbActivationColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbActivationColor.FormattingEnabled = true;
            this.cmbActivationColor.Location = new System.Drawing.Point(6, 33);
            this.cmbActivationColor.Name = "cmbActivationColor";
            this.cmbActivationColor.Size = new System.Drawing.Size(229, 37);
            this.cmbActivationColor.TabIndex = 0;
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.pnlOutput);
            this.tabOutput.Controls.Add(this.txtFieldInfo);
            this.tabOutput.Controls.Add(this.cmdAdd);
            this.tabOutput.Controls.Add(this.lstOutputs);
            this.tabOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOutput.Location = new System.Drawing.Point(4, 38);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutput.Size = new System.Drawing.Size(586, 461);
            this.tabOutput.TabIndex = 1;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // txtFieldInfo
            // 
            this.txtFieldInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFieldInfo.Location = new System.Drawing.Point(57, 6);
            this.txtFieldInfo.Multiline = true;
            this.txtFieldInfo.Name = "txtFieldInfo";
            this.txtFieldInfo.ReadOnly = true;
            this.txtFieldInfo.Size = new System.Drawing.Size(144, 184);
            this.txtFieldInfo.TabIndex = 11;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Location = new System.Drawing.Point(6, 6);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(45, 42);
            this.cmdAdd.TabIndex = 10;
            this.cmdAdd.Text = "+";
            this.cmdAdd.UseVisualStyleBackColor = true;
            // 
            // lstOutputs
            // 
            this.lstOutputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOutputs.FormattingEnabled = true;
            this.lstOutputs.ItemHeight = 29;
            this.lstOutputs.Location = new System.Drawing.Point(6, 219);
            this.lstOutputs.Name = "lstOutputs";
            this.lstOutputs.Size = new System.Drawing.Size(195, 236);
            this.lstOutputs.TabIndex = 9;
            // 
            // cmdSplit
            // 
            this.cmdSplit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmdSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSplit.Location = new System.Drawing.Point(166, 172);
            this.cmdSplit.Name = "cmdSplit";
            this.cmdSplit.Size = new System.Drawing.Size(140, 55);
            this.cmdSplit.TabIndex = 13;
            this.cmdSplit.Text = "Split";
            this.cmdSplit.UseVisualStyleBackColor = false;
            // 
            // pnlOutput
            // 
            this.pnlOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlOutput.Location = new System.Drawing.Point(207, 6);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(373, 449);
            this.pnlOutput.TabIndex = 12;
            // 
            // OverlaySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 521);
            this.Controls.Add(this.cmdSplit);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdImage);
            this.Controls.Add(this.cmdClone);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdDelete);
            this.Name = "OverlaySettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OverlaySettings";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabInput.ResumeLayout(false);
            this.tabInput.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxActivationTime)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCircularY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCircularX)).EndInit();
            this.grpUnlockTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudUnlockTime)).EndInit();
            this.tabAppearence.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTransaparency)).EndInit();
            this.grpIdleColor.ResumeLayout(false);
            this.grpWaitColor.ResumeLayout(false);
            this.grpActivationColor.ResumeLayout(false);
            this.tabOutput.ResumeLayout(false);
            this.tabOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdClone;
        private System.Windows.Forms.Button cmdImage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInput;
        private System.Windows.Forms.TabPage tabAppearence;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudTransaparency;
        private System.Windows.Forms.GroupBox grpIdleColor;
        private System.Windows.Forms.ComboBox cmbIdleColor;
        private System.Windows.Forms.GroupBox grpWaitColor;
        private System.Windows.Forms.ComboBox cmbWaitColor;
        private System.Windows.Forms.GroupBox grpActivationColor;
        private System.Windows.Forms.ComboBox cmbActivationColor;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.TextBox txtFieldInfo;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ListBox lstOutputs;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown nudMaxActivationTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudCircularY;
        private System.Windows.Forms.NumericUpDown nudCircularX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpUnlockTime;
        private System.Windows.Forms.NumericUpDown nudUnlockTime;
        private System.Windows.Forms.CheckBox chkCircular;
        private System.Windows.Forms.CheckBox chkToggleOnActivation;
        private System.Windows.Forms.Button cmdSplit;
        private EditablePanel pnlOutput;
        private System.Windows.Forms.CheckBox chkAlwaysReady;
        private System.Windows.Forms.CheckBox chkActivateOnBlink;
    }
}