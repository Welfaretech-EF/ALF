
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpPage = new System.Windows.Forms.GroupBox();
            this.cmdUp = new System.Windows.Forms.Button();
            this.cmdDown = new System.Windows.Forms.Button();
            this.txtPageName = new System.Windows.Forms.TextBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lstPages = new System.Windows.Forms.ListBox();
            this.cmdHideOverlays = new System.Windows.Forms.Button();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.grpPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAddOverlay
            // 
            this.cmdAddOverlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddOverlay.Location = new System.Drawing.Point(12, 43);
            this.cmdAddOverlay.Name = "cmdAddOverlay";
            this.cmdAddOverlay.Size = new System.Drawing.Size(170, 37);
            this.cmdAddOverlay.TabIndex = 0;
            this.cmdAddOverlay.Text = "Add Overlay";
            this.cmdAddOverlay.UseVisualStyleBackColor = true;
            this.cmdAddOverlay.Click += new System.EventHandler(this.cmdAddOverlay_Click);
            // 
            // chkEnableOverlays
            // 
            this.chkEnableOverlays.AutoSize = true;
            this.chkEnableOverlays.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableOverlays.Location = new System.Drawing.Point(12, 95);
            this.chkEnableOverlays.Name = "chkEnableOverlays";
            this.chkEnableOverlays.Size = new System.Drawing.Size(351, 33);
            this.chkEnableOverlays.TabIndex = 2;
            this.chkEnableOverlays.Text = "Enable Overlays (Alt+Shift+Q)";
            this.chkEnableOverlays.UseVisualStyleBackColor = true;
            this.chkEnableOverlays.CheckedChanged += new System.EventHandler(this.chkEnableOverlays_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.deviceToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(451, 37);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(68, 33);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(160, 34);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(160, 34);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(114, 33);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(101, 33);
            this.deviceToolStripMenuItem.Text = "Device";
            // 
            // grpPage
            // 
            this.grpPage.Controls.Add(this.cmdUp);
            this.grpPage.Controls.Add(this.cmdDown);
            this.grpPage.Controls.Add(this.txtPageName);
            this.grpPage.Controls.Add(this.cmdAdd);
            this.grpPage.Controls.Add(this.lstPages);
            this.grpPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPage.Location = new System.Drawing.Point(12, 144);
            this.grpPage.Name = "grpPage";
            this.grpPage.Size = new System.Drawing.Size(429, 371);
            this.grpPage.TabIndex = 5;
            this.grpPage.TabStop = false;
            this.grpPage.Text = "Pages";
            // 
            // cmdUp
            // 
            this.cmdUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUp.Location = new System.Drawing.Point(278, 33);
            this.cmdUp.Name = "cmdUp";
            this.cmdUp.Size = new System.Drawing.Size(58, 54);
            this.cmdUp.TabIndex = 10;
            this.cmdUp.Text = "˄";
            this.cmdUp.UseVisualStyleBackColor = true;
            // 
            // cmdDown
            // 
            this.cmdDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDown.Location = new System.Drawing.Point(348, 33);
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(55, 54);
            this.cmdDown.TabIndex = 9;
            this.cmdDown.Text = "˅";
            this.cmdDown.UseVisualStyleBackColor = true;
            // 
            // txtPageName
            // 
            this.txtPageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageName.Location = new System.Drawing.Point(10, 93);
            this.txtPageName.Name = "txtPageName";
            this.txtPageName.Size = new System.Drawing.Size(393, 34);
            this.txtPageName.TabIndex = 8;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Location = new System.Drawing.Point(10, 33);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(54, 54);
            this.cmdAdd.TabIndex = 7;
            this.cmdAdd.Text = "+";
            this.cmdAdd.UseVisualStyleBackColor = true;
            // 
            // lstPages
            // 
            this.lstPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPages.FormattingEnabled = true;
            this.lstPages.ItemHeight = 29;
            this.lstPages.Location = new System.Drawing.Point(10, 128);
            this.lstPages.Name = "lstPages";
            this.lstPages.Size = new System.Drawing.Size(393, 236);
            this.lstPages.TabIndex = 6;
            // 
            // cmdHideOverlays
            // 
            this.cmdHideOverlays.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdHideOverlays.Location = new System.Drawing.Point(244, 43);
            this.cmdHideOverlays.Name = "cmdHideOverlays";
            this.cmdHideOverlays.Size = new System.Drawing.Size(191, 37);
            this.cmdHideOverlays.TabIndex = 6;
            this.cmdHideOverlays.Text = "Hide Overlays";
            this.cmdHideOverlays.UseVisualStyleBackColor = true;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(89, 33);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 527);
            this.Controls.Add(this.cmdHideOverlays);
            this.Controls.Add(this.grpPage);
            this.Controls.Add(this.chkEnableOverlays);
            this.Controls.Add(this.cmdAddOverlay);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
        public System.Windows.Forms.CheckBox chkEnableOverlays;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpPage;
        private System.Windows.Forms.ListBox lstPages;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.TextBox txtPageName;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button cmdUp;
        private System.Windows.Forms.Button cmdDown;
        private System.Windows.Forms.Button cmdHideOverlays;
        private System.Windows.Forms.ToolStripMenuItem deviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

