using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace GoogleAppEngineLauncher
{
    public partial class FmAbout : Form
    {
        public FmAbout()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Load += new EventHandler(FmAbout_Load);
        }

        void FmAbout_Load(object sender, EventArgs e)
        {
            Assembly mainAssembly = Assembly.GetEntryAssembly();
            AssemblyName mainAssemName = mainAssembly.GetName();
            Version v = mainAssemName.Version;
            this.lblVersion.Text = "Version " + string.Format("{0}.{1}.{3} ({0}.{1}.{2}.{3})", v.Major, v.Minor, v.Build, v.Revision);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoogleAppEngine.GoogleAppEngine.NavigateUrl(GoogleAppEngine.GoogleAppEngine.HomeUrl);
        }

        private void llblProjectSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoogleAppEngine.GoogleAppEngine.NavigateUrl(Launcher.ProjectSiteUrl);
        }
    }
}
