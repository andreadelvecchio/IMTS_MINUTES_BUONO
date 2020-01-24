namespace IMTS_MINUTES.Forms.Minutes
{
    partial class StartMinutes
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMinutes));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.minutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printMinuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testgrigliaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.exportMinuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMinuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minutesToolStripMenuItem,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1264, 42);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // minutesToolStripMenuItem
            // 
            this.minutesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.writeMinutesToolStripMenuItem,
            this.printMinuteToolStripMenuItem,
            this.testgrigliaToolStripMenuItem,
            this.exportMinuteToolStripMenuItem,
            this.importMinuteToolStripMenuItem});
            this.minutesToolStripMenuItem.Name = "minutesToolStripMenuItem";
            this.minutesToolStripMenuItem.Size = new System.Drawing.Size(122, 38);
            this.minutesToolStripMenuItem.Text = "Minutes";
            // 
            // writeMinutesToolStripMenuItem
            // 
            this.writeMinutesToolStripMenuItem.Name = "writeMinutesToolStripMenuItem";
            this.writeMinutesToolStripMenuItem.Size = new System.Drawing.Size(300, 44);
            this.writeMinutesToolStripMenuItem.Text = "Write Minutes";
            this.writeMinutesToolStripMenuItem.Click += new System.EventHandler(this.WriteMinutesToolStripMenuItem_Click);
            // 
            // printMinuteToolStripMenuItem
            // 
            this.printMinuteToolStripMenuItem.Name = "printMinuteToolStripMenuItem";
            this.printMinuteToolStripMenuItem.Size = new System.Drawing.Size(300, 44);
            this.printMinuteToolStripMenuItem.Text = "Print Minute";
            this.printMinuteToolStripMenuItem.Click += new System.EventHandler(this.PrintMinuteToolStripMenuItem_Click);
            // 
            // testgrigliaToolStripMenuItem
            // 
            this.testgrigliaToolStripMenuItem.Name = "testgrigliaToolStripMenuItem";
            this.testgrigliaToolStripMenuItem.Size = new System.Drawing.Size(300, 44);
            this.testgrigliaToolStripMenuItem.Text = "testgriglia";
            this.testgrigliaToolStripMenuItem.Click += new System.EventHandler(this.TestgrigliaToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(46, 36);
            this.helpMenu.Text = "&?";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(367, 44);
            this.contentsToolStripMenuItem.Text = "&Sommario";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
            this.indexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(367, 44);
            this.indexToolStripMenuItem.Text = "&Indice";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(367, 44);
            this.searchToolStripMenuItem.Text = "&Cerca";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(364, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(367, 44);
            this.aboutToolStripMenuItem.Text = "&Informazioni su... ...";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 829);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip.Size = new System.Drawing.Size(1264, 42);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(69, 32);
            this.toolStripStatusLabel.Text = "Stato";
            // 
            // exportMinuteToolStripMenuItem
            // 
            this.exportMinuteToolStripMenuItem.Name = "exportMinuteToolStripMenuItem";
            this.exportMinuteToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.exportMinuteToolStripMenuItem.Text = "ExportMinute";
            this.exportMinuteToolStripMenuItem.Click += new System.EventHandler(this.ExportMinuteToolStripMenuItem_Click);
            // 
            // importMinuteToolStripMenuItem
            // 
            this.importMinuteToolStripMenuItem.Name = "importMinuteToolStripMenuItem";
            this.importMinuteToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.importMinuteToolStripMenuItem.Text = "ImportMinute";
            this.importMinuteToolStripMenuItem.Click += new System.EventHandler(this.ImportMinuteToolStripMenuItem_Click);
            // 
            // StartMinutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 871);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "StartMinutes";
            this.Text = "StartMinutes";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeMinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printMinuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testgrigliaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMinuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMinuteToolStripMenuItem;
    }
}



