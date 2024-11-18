namespace FlexibleEyeController
{
    partial class frmSettings
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
            this.chkEnableGazeOnStartup = new System.Windows.Forms.CheckBox();
            this.rdbLoadPrevious = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFixed = new System.Windows.Forms.Label();
            this.cmdSetFile = new System.Windows.Forms.Button();
            this.rdbLoadFixed = new System.Windows.Forms.RadioButton();
            this.chkGridSnap = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEnableGazeOnStartup
            // 
            this.chkEnableGazeOnStartup.AutoSize = true;
            this.chkEnableGazeOnStartup.Location = new System.Drawing.Point(12, 12);
            this.chkEnableGazeOnStartup.Name = "chkEnableGazeOnStartup";
            this.chkEnableGazeOnStartup.Size = new System.Drawing.Size(168, 20);
            this.chkEnableGazeOnStartup.TabIndex = 0;
            this.chkEnableGazeOnStartup.Text = "Enable Gaze on startup";
            this.chkEnableGazeOnStartup.UseVisualStyleBackColor = true;
            // 
            // rdbLoadPrevious
            // 
            this.rdbLoadPrevious.AutoSize = true;
            this.rdbLoadPrevious.Checked = true;
            this.rdbLoadPrevious.Location = new System.Drawing.Point(6, 21);
            this.rdbLoadPrevious.Name = "rdbLoadPrevious";
            this.rdbLoadPrevious.Size = new System.Drawing.Size(134, 20);
            this.rdbLoadPrevious.TabIndex = 2;
            this.rdbLoadPrevious.TabStop = true;
            this.rdbLoadPrevious.Text = "Load previous file";
            this.rdbLoadPrevious.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFixed);
            this.groupBox1.Controls.Add(this.cmdSetFile);
            this.groupBox1.Controls.Add(this.rdbLoadFixed);
            this.groupBox1.Controls.Add(this.rdbLoadPrevious);
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 96);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load file on startup";
            // 
            // lblFixed
            // 
            this.lblFixed.AutoSize = true;
            this.lblFixed.Location = new System.Drawing.Point(6, 70);
            this.lblFixed.Name = "lblFixed";
            this.lblFixed.Size = new System.Drawing.Size(32, 16);
            this.lblFixed.TabIndex = 5;
            this.lblFixed.Text = "File:";
            // 
            // cmdSetFile
            // 
            this.cmdSetFile.Location = new System.Drawing.Point(122, 47);
            this.cmdSetFile.Name = "cmdSetFile";
            this.cmdSetFile.Size = new System.Drawing.Size(75, 23);
            this.cmdSetFile.TabIndex = 4;
            this.cmdSetFile.Text = "SetFile";
            this.cmdSetFile.UseVisualStyleBackColor = true;
            // 
            // rdbLoadFixed
            // 
            this.rdbLoadFixed.AutoSize = true;
            this.rdbLoadFixed.Location = new System.Drawing.Point(6, 47);
            this.rdbLoadFixed.Name = "rdbLoadFixed";
            this.rdbLoadFixed.Size = new System.Drawing.Size(110, 20);
            this.rdbLoadFixed.TabIndex = 3;
            this.rdbLoadFixed.Text = "Load fixed file";
            this.rdbLoadFixed.UseVisualStyleBackColor = true;
            // 
            // chkGridSnap
            // 
            this.chkGridSnap.AutoSize = true;
            this.chkGridSnap.Location = new System.Drawing.Point(12, 38);
            this.chkGridSnap.Name = "chkGridSnap";
            this.chkGridSnap.Size = new System.Drawing.Size(86, 20);
            this.chkGridSnap.TabIndex = 4;
            this.chkGridSnap.Text = "GridSnap";
            this.chkGridSnap.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 172);
            this.Controls.Add(this.chkGridSnap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkEnableGazeOnStartup);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnableGazeOnStartup;
        private System.Windows.Forms.RadioButton rdbLoadPrevious;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdSetFile;
        private System.Windows.Forms.RadioButton rdbLoadFixed;
        private System.Windows.Forms.Label lblFixed;
        private System.Windows.Forms.CheckBox chkGridSnap;
    }
}