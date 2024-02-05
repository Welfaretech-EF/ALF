
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
            this.pnlOutput = new MDOL.EditablePanel();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lstOutputs = new System.Windows.Forms.ListBox();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpUnlockTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnlockTime)).BeginInit();
            this.grpOutput.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkCircular
            // 
            this.chkCircular.AutoSize = true;
            this.chkCircular.Location = new System.Drawing.Point(12, 98);
            this.chkCircular.Name = "chkCircular";
            this.chkCircular.Size = new System.Drawing.Size(61, 17);
            this.chkCircular.TabIndex = 7;
            this.chkCircular.Text = "Circular";
            this.chkCircular.UseVisualStyleBackColor = true;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(6, 121);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 6;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(6, 19);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(152, 20);
            this.txtDescription.TabIndex = 5;
            // 
            // chkToggleOnActivation
            // 
            this.chkToggleOnActivation.AutoSize = true;
            this.chkToggleOnActivation.Location = new System.Drawing.Point(12, 75);
            this.chkToggleOnActivation.Name = "chkToggleOnActivation";
            this.chkToggleOnActivation.Size = new System.Drawing.Size(112, 17);
            this.chkToggleOnActivation.TabIndex = 4;
            this.chkToggleOnActivation.Text = "Hold on activation";
            this.chkToggleOnActivation.UseVisualStyleBackColor = true;
            // 
            // grpUnlockTime
            // 
            this.grpUnlockTime.Controls.Add(this.nudUnlockTime);
            this.grpUnlockTime.Location = new System.Drawing.Point(6, 19);
            this.grpUnlockTime.Name = "grpUnlockTime";
            this.grpUnlockTime.Size = new System.Drawing.Size(140, 50);
            this.grpUnlockTime.TabIndex = 3;
            this.grpUnlockTime.TabStop = false;
            this.grpUnlockTime.Text = "Time to unlock";
            // 
            // nudUnlockTime
            // 
            this.nudUnlockTime.DecimalPlaces = 1;
            this.nudUnlockTime.Location = new System.Drawing.Point(6, 19);
            this.nudUnlockTime.Name = "nudUnlockTime";
            this.nudUnlockTime.Size = new System.Drawing.Size(120, 20);
            this.nudUnlockTime.TabIndex = 1;
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.txtFieldInfo);
            this.grpOutput.Controls.Add(this.pnlOutput);
            this.grpOutput.Controls.Add(this.cmdAdd);
            this.grpOutput.Controls.Add(this.lstOutputs);
            this.grpOutput.Location = new System.Drawing.Point(182, 12);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(545, 320);
            this.grpOutput.TabIndex = 2;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output";
            // 
            // txtFieldInfo
            // 
            this.txtFieldInfo.Location = new System.Drawing.Point(213, 9);
            this.txtFieldInfo.Multiline = true;
            this.txtFieldInfo.Name = "txtFieldInfo";
            this.txtFieldInfo.ReadOnly = true;
            this.txtFieldInfo.Size = new System.Drawing.Size(326, 60);
            this.txtFieldInfo.TabIndex = 8;
            // 
            // pnlOutput
            // 
            this.pnlOutput.Location = new System.Drawing.Point(213, 75);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(326, 239);
            this.pnlOutput.TabIndex = 7;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(6, 21);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(26, 23);
            this.cmdAdd.TabIndex = 6;
            this.cmdAdd.Text = "+";
            this.cmdAdd.UseVisualStyleBackColor = true;
            // 
            // lstOutputs
            // 
            this.lstOutputs.FormattingEnabled = true;
            this.lstOutputs.Location = new System.Drawing.Point(6, 50);
            this.lstOutputs.Name = "lstOutputs";
            this.lstOutputs.Size = new System.Drawing.Size(201, 264);
            this.lstOutputs.TabIndex = 5;
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.grpUnlockTime);
            this.grpInput.Controls.Add(this.chkCircular);
            this.grpInput.Controls.Add(this.chkToggleOnActivation);
            this.grpInput.Controls.Add(this.cmdDelete);
            this.grpInput.Location = new System.Drawing.Point(12, 73);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(164, 259);
            this.grpInput.TabIndex = 3;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 55);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // OverlaySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 338);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.grpOutput);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private MDOL.EditablePanel pnlOutput;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ListBox lstOutputs;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TextBox txtFieldInfo;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}