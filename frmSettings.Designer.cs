namespace ALF
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
            this.grpLoadFileOnStartup = new System.Windows.Forms.GroupBox();
            this.lblFixed = new System.Windows.Forms.Label();
            this.cmdSetFile = new System.Windows.Forms.Button();
            this.rdbLoadFixed = new System.Windows.Forms.RadioButton();
            this.chkGridSnap = new System.Windows.Forms.CheckBox();
            this.cmbVoices = new System.Windows.Forms.ComboBox();
            this.grpSpeechVoice = new System.Windows.Forms.GroupBox();
            this.nudGazeScale = new System.Windows.Forms.NumericUpDown();
            this.grpGazeScale = new System.Windows.Forms.GroupBox();
            this.chkMouseAssist = new System.Windows.Forms.CheckBox();
            this.grpLoadFileOnStartup.SuspendLayout();
            this.grpSpeechVoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGazeScale)).BeginInit();
            this.grpGazeScale.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEnableGazeOnStartup
            // 
            this.chkEnableGazeOnStartup.AutoSize = true;
            this.chkEnableGazeOnStartup.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableGazeOnStartup.Location = new System.Drawing.Point(9, 10);
            this.chkEnableGazeOnStartup.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnableGazeOnStartup.Name = "chkEnableGazeOnStartup";
            this.chkEnableGazeOnStartup.Size = new System.Drawing.Size(225, 28);
            this.chkEnableGazeOnStartup.TabIndex = 0;
            this.chkEnableGazeOnStartup.Text = "Enable Gaze on startup";
            this.chkEnableGazeOnStartup.UseVisualStyleBackColor = true;
            // 
            // rdbLoadPrevious
            // 
            this.rdbLoadPrevious.AutoSize = true;
            this.rdbLoadPrevious.Checked = true;
            this.rdbLoadPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLoadPrevious.Location = new System.Drawing.Point(6, 31);
            this.rdbLoadPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.rdbLoadPrevious.Name = "rdbLoadPrevious";
            this.rdbLoadPrevious.Size = new System.Drawing.Size(175, 28);
            this.rdbLoadPrevious.TabIndex = 2;
            this.rdbLoadPrevious.TabStop = true;
            this.rdbLoadPrevious.Text = "Load previous file";
            this.rdbLoadPrevious.UseVisualStyleBackColor = true;
            // 
            // grpLoadFileOnStartup
            // 
            this.grpLoadFileOnStartup.Controls.Add(this.lblFixed);
            this.grpLoadFileOnStartup.Controls.Add(this.cmdSetFile);
            this.grpLoadFileOnStartup.Controls.Add(this.rdbLoadFixed);
            this.grpLoadFileOnStartup.Controls.Add(this.rdbLoadPrevious);
            this.grpLoadFileOnStartup.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLoadFileOnStartup.Location = new System.Drawing.Point(9, 134);
            this.grpLoadFileOnStartup.Margin = new System.Windows.Forms.Padding(2);
            this.grpLoadFileOnStartup.Name = "grpLoadFileOnStartup";
            this.grpLoadFileOnStartup.Padding = new System.Windows.Forms.Padding(2);
            this.grpLoadFileOnStartup.Size = new System.Drawing.Size(320, 163);
            this.grpLoadFileOnStartup.TabIndex = 3;
            this.grpLoadFileOnStartup.TabStop = false;
            this.grpLoadFileOnStartup.Text = "Load file on startup";
            // 
            // lblFixed
            // 
            this.lblFixed.AutoSize = true;
            this.lblFixed.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixed.Location = new System.Drawing.Point(4, 103);
            this.lblFixed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFixed.Name = "lblFixed";
            this.lblFixed.Size = new System.Drawing.Size(46, 24);
            this.lblFixed.TabIndex = 5;
            this.lblFixed.Text = "File:";
            // 
            // cmdSetFile
            // 
            this.cmdSetFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSetFile.Location = new System.Drawing.Point(190, 68);
            this.cmdSetFile.Margin = new System.Windows.Forms.Padding(2);
            this.cmdSetFile.Name = "cmdSetFile";
            this.cmdSetFile.Size = new System.Drawing.Size(116, 37);
            this.cmdSetFile.TabIndex = 4;
            this.cmdSetFile.Text = "SetFile";
            this.cmdSetFile.UseVisualStyleBackColor = true;
            // 
            // rdbLoadFixed
            // 
            this.rdbLoadFixed.AutoSize = true;
            this.rdbLoadFixed.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLoadFixed.Location = new System.Drawing.Point(6, 68);
            this.rdbLoadFixed.Margin = new System.Windows.Forms.Padding(2);
            this.rdbLoadFixed.Name = "rdbLoadFixed";
            this.rdbLoadFixed.Size = new System.Drawing.Size(143, 28);
            this.rdbLoadFixed.TabIndex = 3;
            this.rdbLoadFixed.Text = "Load fixed file";
            this.rdbLoadFixed.UseVisualStyleBackColor = true;
            // 
            // chkGridSnap
            // 
            this.chkGridSnap.AutoSize = true;
            this.chkGridSnap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGridSnap.Location = new System.Drawing.Point(9, 42);
            this.chkGridSnap.Margin = new System.Windows.Forms.Padding(2);
            this.chkGridSnap.Name = "chkGridSnap";
            this.chkGridSnap.Size = new System.Drawing.Size(108, 28);
            this.chkGridSnap.TabIndex = 4;
            this.chkGridSnap.Text = "GridSnap";
            this.chkGridSnap.UseVisualStyleBackColor = true;
            // 
            // cmbVoices
            // 
            this.cmbVoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVoices.FormattingEnabled = true;
            this.cmbVoices.Location = new System.Drawing.Point(9, 31);
            this.cmbVoices.Margin = new System.Windows.Forms.Padding(2);
            this.cmbVoices.Name = "cmbVoices";
            this.cmbVoices.Size = new System.Drawing.Size(294, 30);
            this.cmbVoices.TabIndex = 5;
            // 
            // grpSpeechVoice
            // 
            this.grpSpeechVoice.Controls.Add(this.cmbVoices);
            this.grpSpeechVoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSpeechVoice.Location = new System.Drawing.Point(9, 322);
            this.grpSpeechVoice.Margin = new System.Windows.Forms.Padding(2);
            this.grpSpeechVoice.Name = "grpSpeechVoice";
            this.grpSpeechVoice.Padding = new System.Windows.Forms.Padding(2);
            this.grpSpeechVoice.Size = new System.Drawing.Size(320, 84);
            this.grpSpeechVoice.TabIndex = 6;
            this.grpSpeechVoice.TabStop = false;
            this.grpSpeechVoice.Text = "Speech Synthesis Voice";
            // 
            // nudGazeScale
            // 
            this.nudGazeScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGazeScale.Location = new System.Drawing.Point(9, 45);
            this.nudGazeScale.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGazeScale.Name = "nudGazeScale";
            this.nudGazeScale.Size = new System.Drawing.Size(297, 28);
            this.nudGazeScale.TabIndex = 7;
            this.nudGazeScale.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // grpGazeScale
            // 
            this.grpGazeScale.Controls.Add(this.nudGazeScale);
            this.grpGazeScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGazeScale.Location = new System.Drawing.Point(9, 434);
            this.grpGazeScale.Name = "grpGazeScale";
            this.grpGazeScale.Size = new System.Drawing.Size(317, 85);
            this.grpGazeScale.TabIndex = 8;
            this.grpGazeScale.TabStop = false;
            this.grpGazeScale.Text = "GazeScale (%)";
            // 
            // chkMouseAssist
            // 
            this.chkMouseAssist.AutoSize = true;
            this.chkMouseAssist.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMouseAssist.Location = new System.Drawing.Point(9, 74);
            this.chkMouseAssist.Margin = new System.Windows.Forms.Padding(2);
            this.chkMouseAssist.Name = "chkMouseAssist";
            this.chkMouseAssist.Size = new System.Drawing.Size(218, 28);
            this.chkMouseAssist.TabIndex = 9;
            this.chkMouseAssist.Text = "Mouse Assist (Left Ctrl)";
            this.chkMouseAssist.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 572);
            this.Controls.Add(this.chkMouseAssist);
            this.Controls.Add(this.grpGazeScale);
            this.Controls.Add(this.grpSpeechVoice);
            this.Controls.Add(this.chkGridSnap);
            this.Controls.Add(this.grpLoadFileOnStartup);
            this.Controls.Add(this.chkEnableGazeOnStartup);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSettings";
            this.Text = "Global Settings";
            this.grpLoadFileOnStartup.ResumeLayout(false);
            this.grpLoadFileOnStartup.PerformLayout();
            this.grpSpeechVoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudGazeScale)).EndInit();
            this.grpGazeScale.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnableGazeOnStartup;
        private System.Windows.Forms.RadioButton rdbLoadPrevious;
        private System.Windows.Forms.GroupBox grpLoadFileOnStartup;
        private System.Windows.Forms.Button cmdSetFile;
        private System.Windows.Forms.RadioButton rdbLoadFixed;
        private System.Windows.Forms.Label lblFixed;
        private System.Windows.Forms.CheckBox chkGridSnap;
        private System.Windows.Forms.ComboBox cmbVoices;
        private System.Windows.Forms.GroupBox grpSpeechVoice;
        private System.Windows.Forms.NumericUpDown nudGazeScale;
        private System.Windows.Forms.GroupBox grpGazeScale;
        private System.Windows.Forms.CheckBox chkMouseAssist;
    }
}