namespace GoogleAppEngineLauncher
{
    partial class FmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmAbout));
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.llblHome = new System.Windows.Forms.LinkLabel();
            this.llblProjectSite = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(14, 127);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(451, 23);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Location = new System.Drawing.Point(12, 192);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(451, 23);
            this.lblCopyright.TabIndex = 2;
            this.lblCopyright.Text = "Copyright (c) 2009 makoto_kw (makoto.kw@gmail.com)";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::GoogleAppEngineLauncher.Properties.Resources.AppEngine;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 104);
            this.label1.TabIndex = 0;
            this.label1.Text = "GoogleAppEngineLauncher for Windows";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // llblHome
            // 
            this.llblHome.Location = new System.Drawing.Point(14, 150);
            this.llblHome.Name = "llblHome";
            this.llblHome.Size = new System.Drawing.Size(449, 23);
            this.llblHome.TabIndex = 3;
            this.llblHome.TabStop = true;
            this.llblHome.Text = "Google App Engine Home";
            this.llblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llblHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // llblProjectSite
            // 
            this.llblProjectSite.Location = new System.Drawing.Point(10, 169);
            this.llblProjectSite.Name = "llblProjectSite";
            this.llblProjectSite.Size = new System.Drawing.Size(453, 23);
            this.llblProjectSite.TabIndex = 4;
            this.llblProjectSite.TabStop = true;
            this.llblProjectSite.Text = "GoogleAppEngineLauncher for Windows Project Site";
            this.llblProjectSite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llblProjectSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblProjectSite_LinkClicked);
            // 
            // FmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 224);
            this.Controls.Add(this.llblProjectSite);
            this.Controls.Add(this.llblHome);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FmAbout";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GoogleAppEngineLauncher for Windows";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.LinkLabel llblHome;
        private System.Windows.Forms.LinkLabel llblProjectSite;
    }
}