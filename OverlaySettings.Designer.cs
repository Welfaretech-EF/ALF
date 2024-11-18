
namespace FlexibleEyeController
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
            this.chkCircular = new System.Windows.Forms.CheckBox();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkToggleOnActivation = new System.Windows.Forms.CheckBox();
            this.grpUnlockTime = new System.Windows.Forms.GroupBox();
            this.nudUnlockTime = new System.Windows.Forms.NumericUpDown();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.txtFieldInfo = new System.Windows.Forms.TextBox();
            this.pnlOutput = new FlexibleEyeController.EditablePanel();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lstOutputs = new System.Windows.Forms.ListBox();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudCircularY = new System.Windows.Forms.NumericUpDown();
            this.nudCircularX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.grpAppearence = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudTransaparency = new System.Windows.Forms.NumericUpDown();
            this.grpIdleColor = new System.Windows.Forms.GroupBox();
            this.cmbIdleColor = new System.Windows.Forms.ComboBox();
            this.grpWaitColor = new System.Windows.Forms.GroupBox();
            this.cmbWaitColor = new System.Windows.Forms.ComboBox();
            this.grpActivationColor = new System.Windows.Forms.GroupBox();
            this.cmbActivationColor = new System.Windows.Forms.ComboBox();
            this.cmdClone = new System.Windows.Forms.Button();
            this.grpUnlockTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnlockTime)).BeginInit();
            this.grpOutput.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCircularY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCircularX)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpAppearence.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTransaparency)).BeginInit();
            this.grpIdleColor.SuspendLayout();
            this.grpWaitColor.SuspendLayout();
            this.grpActivationColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkCircular
            // 
            this.chkCircular.AutoSize = true;
            this.chkCircular.Location = new System.Drawing.Point(16, 121);
            this.chkCircular.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCircular.Name = "chkCircular";
            this.chkCircular.Size = new System.Drawing.Size(74, 20);
            this.chkCircular.TabIndex = 7;
            this.chkCircular.Text = "Circular";
            this.chkCircular.UseVisualStyleBackColor = true;
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.Color.Red;
            this.cmdDelete.Location = new System.Drawing.Point(16, 351);
            this.cmdDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(131, 38);
            this.cmdDelete.TabIndex = 6;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(8, 23);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(201, 22);
            this.txtDescription.TabIndex = 5;
            // 
            // chkToggleOnActivation
            // 
            this.chkToggleOnActivation.AutoSize = true;
            this.chkToggleOnActivation.Location = new System.Drawing.Point(16, 92);
            this.chkToggleOnActivation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkToggleOnActivation.Name = "chkToggleOnActivation";
            this.chkToggleOnActivation.Size = new System.Drawing.Size(136, 20);
            this.chkToggleOnActivation.TabIndex = 4;
            this.chkToggleOnActivation.Text = "Hold on activation";
            this.chkToggleOnActivation.UseVisualStyleBackColor = true;
            // 
            // grpUnlockTime
            // 
            this.grpUnlockTime.Controls.Add(this.nudUnlockTime);
            this.grpUnlockTime.Location = new System.Drawing.Point(8, 23);
            this.grpUnlockTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpUnlockTime.Name = "grpUnlockTime";
            this.grpUnlockTime.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpUnlockTime.Size = new System.Drawing.Size(187, 62);
            this.grpUnlockTime.TabIndex = 3;
            this.grpUnlockTime.TabStop = false;
            this.grpUnlockTime.Text = "Time to unlock";
            // 
            // nudUnlockTime
            // 
            this.nudUnlockTime.DecimalPlaces = 1;
            this.nudUnlockTime.Location = new System.Drawing.Point(8, 23);
            this.nudUnlockTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudUnlockTime.Name = "nudUnlockTime";
            this.nudUnlockTime.Size = new System.Drawing.Size(160, 22);
            this.nudUnlockTime.TabIndex = 1;
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.txtFieldInfo);
            this.grpOutput.Controls.Add(this.pnlOutput);
            this.grpOutput.Controls.Add(this.cmdAdd);
            this.grpOutput.Controls.Add(this.lstOutputs);
            this.grpOutput.Location = new System.Drawing.Point(469, 15);
            this.grpOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpOutput.Size = new System.Drawing.Size(500, 374);
            this.grpOutput.TabIndex = 2;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output";
            // 
            // txtFieldInfo
            // 
            this.txtFieldInfo.Location = new System.Drawing.Point(196, 11);
            this.txtFieldInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFieldInfo.Multiline = true;
            this.txtFieldInfo.Name = "txtFieldInfo";
            this.txtFieldInfo.ReadOnly = true;
            this.txtFieldInfo.Size = new System.Drawing.Size(295, 73);
            this.txtFieldInfo.TabIndex = 8;
            // 
            // pnlOutput
            // 
            this.pnlOutput.Location = new System.Drawing.Point(196, 92);
            this.pnlOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(296, 198);
            this.pnlOutput.TabIndex = 7;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(8, 21);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(35, 28);
            this.cmdAdd.TabIndex = 6;
            this.cmdAdd.Text = "+";
            this.cmdAdd.UseVisualStyleBackColor = true;
            // 
            // lstOutputs
            // 
            this.lstOutputs.FormattingEnabled = true;
            this.lstOutputs.ItemHeight = 16;
            this.lstOutputs.Location = new System.Drawing.Point(8, 62);
            this.lstOutputs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstOutputs.Name = "lstOutputs";
            this.lstOutputs.Size = new System.Drawing.Size(179, 228);
            this.lstOutputs.TabIndex = 5;
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.groupBox2);
            this.grpInput.Controls.Add(this.grpUnlockTime);
            this.grpInput.Controls.Add(this.chkCircular);
            this.grpInput.Controls.Add(this.chkToggleOnActivation);
            this.grpInput.Location = new System.Drawing.Point(16, 90);
            this.grpInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpInput.Name = "grpInput";
            this.grpInput.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpInput.Size = new System.Drawing.Size(219, 254);
            this.grpInput.TabIndex = 3;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudCircularY);
            this.groupBox2.Controls.Add(this.nudCircularX);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(16, 149);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(195, 86);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CircularScale in %";
            // 
            // nudCircularY
            // 
            this.nudCircularY.DecimalPlaces = 1;
            this.nudCircularY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCircularY.Location = new System.Drawing.Point(43, 54);
            this.nudCircularY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.nudCircularY.Size = new System.Drawing.Size(136, 22);
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
            this.nudCircularX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCircularX.Location = new System.Drawing.Point(43, 23);
            this.nudCircularX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.nudCircularX.Size = new System.Drawing.Size(136, 22);
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
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "X";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(219, 68);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cmdSave.Location = new System.Drawing.Point(333, 351);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(131, 38);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = false;
            // 
            // grpAppearence
            // 
            this.grpAppearence.Controls.Add(this.groupBox3);
            this.grpAppearence.Controls.Add(this.grpIdleColor);
            this.grpAppearence.Controls.Add(this.grpWaitColor);
            this.grpAppearence.Controls.Add(this.grpActivationColor);
            this.grpAppearence.Location = new System.Drawing.Point(243, 15);
            this.grpAppearence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAppearence.Name = "grpAppearence";
            this.grpAppearence.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAppearence.Size = new System.Drawing.Size(221, 329);
            this.grpAppearence.TabIndex = 7;
            this.grpAppearence.TabStop = false;
            this.grpAppearence.Text = "Appearence";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudTransaparency);
            this.groupBox3.Location = new System.Drawing.Point(8, 234);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(205, 64);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transparency (%)";
            // 
            // nudTransaparency
            // 
            this.nudTransaparency.Location = new System.Drawing.Point(8, 23);
            this.nudTransaparency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudTransaparency.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudTransaparency.Name = "nudTransaparency";
            this.nudTransaparency.Size = new System.Drawing.Size(189, 22);
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
            this.grpIdleColor.Location = new System.Drawing.Point(8, 23);
            this.grpIdleColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpIdleColor.Name = "grpIdleColor";
            this.grpIdleColor.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpIdleColor.Size = new System.Drawing.Size(205, 63);
            this.grpIdleColor.TabIndex = 3;
            this.grpIdleColor.TabStop = false;
            this.grpIdleColor.Text = "Idle Color";
            // 
            // cmbIdleColor
            // 
            this.cmbIdleColor.FormattingEnabled = true;
            this.cmbIdleColor.Location = new System.Drawing.Point(8, 23);
            this.cmbIdleColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbIdleColor.Name = "cmbIdleColor";
            this.cmbIdleColor.Size = new System.Drawing.Size(188, 24);
            this.cmbIdleColor.TabIndex = 0;
            // 
            // grpWaitColor
            // 
            this.grpWaitColor.Controls.Add(this.cmbWaitColor);
            this.grpWaitColor.Location = new System.Drawing.Point(8, 164);
            this.grpWaitColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpWaitColor.Name = "grpWaitColor";
            this.grpWaitColor.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpWaitColor.Size = new System.Drawing.Size(205, 63);
            this.grpWaitColor.TabIndex = 2;
            this.grpWaitColor.TabStop = false;
            this.grpWaitColor.Text = "Waiting Color";
            // 
            // cmbWaitColor
            // 
            this.cmbWaitColor.FormattingEnabled = true;
            this.cmbWaitColor.Location = new System.Drawing.Point(8, 23);
            this.cmbWaitColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbWaitColor.Name = "cmbWaitColor";
            this.cmbWaitColor.Size = new System.Drawing.Size(188, 24);
            this.cmbWaitColor.TabIndex = 0;
            // 
            // grpActivationColor
            // 
            this.grpActivationColor.Controls.Add(this.cmbActivationColor);
            this.grpActivationColor.Location = new System.Drawing.Point(8, 94);
            this.grpActivationColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpActivationColor.Name = "grpActivationColor";
            this.grpActivationColor.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpActivationColor.Size = new System.Drawing.Size(205, 63);
            this.grpActivationColor.TabIndex = 1;
            this.grpActivationColor.TabStop = false;
            this.grpActivationColor.Text = "Activation Color";
            // 
            // cmbActivationColor
            // 
            this.cmbActivationColor.FormattingEnabled = true;
            this.cmbActivationColor.Location = new System.Drawing.Point(8, 23);
            this.cmbActivationColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbActivationColor.Name = "cmbActivationColor";
            this.cmbActivationColor.Size = new System.Drawing.Size(188, 24);
            this.cmbActivationColor.TabIndex = 0;
            // 
            // cmdClone
            // 
            this.cmdClone.BackColor = System.Drawing.Color.Blue;
            this.cmdClone.Location = new System.Drawing.Point(180, 351);
            this.cmdClone.Margin = new System.Windows.Forms.Padding(4);
            this.cmdClone.Name = "cmdClone";
            this.cmdClone.Size = new System.Drawing.Size(131, 38);
            this.cmdClone.TabIndex = 9;
            this.cmdClone.Text = "Clone";
            this.cmdClone.UseVisualStyleBackColor = false;
            // 
            // OverlaySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 404);
            this.Controls.Add(this.cmdClone);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.grpAppearence);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.cmdDelete);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "OverlaySettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OverlaySettings";
            this.TopMost = true;
            this.grpUnlockTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudUnlockTime)).EndInit();
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCircularY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCircularX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpAppearence.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTransaparency)).EndInit();
            this.grpIdleColor.ResumeLayout(false);
            this.grpWaitColor.ResumeLayout(false);
            this.grpActivationColor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nudUnlockTime;
        private System.Windows.Forms.GroupBox grpUnlockTime;
        private System.Windows.Forms.CheckBox chkToggleOnActivation;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.CheckBox chkCircular;
        private System.Windows.Forms.GroupBox grpOutput;
        private EditablePanel pnlOutput;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ListBox lstOutputs;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TextBox txtFieldInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.GroupBox grpAppearence;
        private System.Windows.Forms.GroupBox grpActivationColor;
        private System.Windows.Forms.ComboBox cmbActivationColor;
        private System.Windows.Forms.GroupBox grpWaitColor;
        private System.Windows.Forms.ComboBox cmbWaitColor;
        private System.Windows.Forms.GroupBox grpIdleColor;
        private System.Windows.Forms.ComboBox cmbIdleColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudCircularY;
        private System.Windows.Forms.NumericUpDown nudCircularX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudTransaparency;
        private System.Windows.Forms.Button cmdClone;
    }
}