
namespace ALF
{
    partial class Form1
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
            this.cmdAddOverlay = new System.Windows.Forms.Button();
            this.chkEnableOverlays = new System.Windows.Forms.CheckBox();
            this.chkMouseAsGaze = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpPage = new System.Windows.Forms.GroupBox();
            this.txtPageName = new System.Windows.Forms.TextBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lstPages = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.grpPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAddOverlay
            // 
            this.cmdAddOverlay.Location = new System.Drawing.Point(16, 33);
            this.cmdAddOverlay.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAddOverlay.Name = "cmdAddOverlay";
            this.cmdAddOverlay.Size = new System.Drawing.Size(100, 28);
            this.cmdAddOverlay.TabIndex = 0;
            this.cmdAddOverlay.Text = "Add Overlay";
            this.cmdAddOverlay.UseVisualStyleBackColor = true;
            this.cmdAddOverlay.Click += new System.EventHandler(this.cmdAddOverlay_Click);
            // 
            // chkEnableOverlays
            // 
            this.chkEnableOverlays.AutoSize = true;
            this.chkEnableOverlays.Location = new System.Drawing.Point(16, 69);
            this.chkEnableOverlays.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnableOverlays.Name = "chkEnableOverlays";
            this.chkEnableOverlays.Size = new System.Drawing.Size(204, 20);
            this.chkEnableOverlays.TabIndex = 2;
            this.chkEnableOverlays.Text = "Enable Overlays (Alt+Shift+Q)";
            this.chkEnableOverlays.UseVisualStyleBackColor = true;
            this.chkEnableOverlays.CheckedChanged += new System.EventHandler(this.chkEnableOverlays_CheckedChanged);
            // 
            // chkMouseAsGaze
            // 
            this.chkMouseAsGaze.AutoSize = true;
            this.chkMouseAsGaze.Location = new System.Drawing.Point(16, 97);
            this.chkMouseAsGaze.Margin = new System.Windows.Forms.Padding(4);
            this.chkMouseAsGaze.Name = "chkMouseAsGaze";
            this.chkMouseAsGaze.Size = new System.Drawing.Size(149, 20);
            this.chkMouseAsGaze.TabIndex = 3;
            this.chkMouseAsGaze.Text = "Use mouse as gaze";
            this.chkMouseAsGaze.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(472, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // grpPage
            // 
            this.grpPage.Controls.Add(this.txtPageName);
            this.grpPage.Controls.Add(this.cmdAdd);
            this.grpPage.Controls.Add(this.lstPages);
            this.grpPage.Location = new System.Drawing.Point(16, 126);
            this.grpPage.Margin = new System.Windows.Forms.Padding(4);
            this.grpPage.Name = "grpPage";
            this.grpPage.Padding = new System.Windows.Forms.Padding(4);
            this.grpPage.Size = new System.Drawing.Size(440, 279);
            this.grpPage.TabIndex = 5;
            this.grpPage.TabStop = false;
            this.grpPage.Text = "Pages";
            // 
            // txtPageName
            // 
            this.txtPageName.Location = new System.Drawing.Point(13, 58);
            this.txtPageName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPageName.Name = "txtPageName";
            this.txtPageName.Size = new System.Drawing.Size(417, 22);
            this.txtPageName.TabIndex = 8;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(13, 22);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(35, 28);
            this.cmdAdd.TabIndex = 7;
            this.cmdAdd.Text = "+";
            this.cmdAdd.UseVisualStyleBackColor = true;
            // 
            // lstPages
            // 
            this.lstPages.FormattingEnabled = true;
            this.lstPages.ItemHeight = 16;
            this.lstPages.Location = new System.Drawing.Point(13, 90);
            this.lstPages.Margin = new System.Windows.Forms.Padding(4);
            this.lstPages.Name = "lstPages";
            this.lstPages.Size = new System.Drawing.Size(417, 180);
            this.lstPages.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 417);
            this.Controls.Add(this.grpPage);
            this.Controls.Add(this.chkMouseAsGaze);
            this.Controls.Add(this.chkEnableOverlays);
            this.Controls.Add(this.cmdAddOverlay);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ALF";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpPage.ResumeLayout(false);
            this.grpPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAddOverlay;
        private System.Windows.Forms.CheckBox chkEnableOverlays;
        private System.Windows.Forms.CheckBox chkMouseAsGaze;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpPage;
        private System.Windows.Forms.ListBox lstPages;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.TextBox txtPageName;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

