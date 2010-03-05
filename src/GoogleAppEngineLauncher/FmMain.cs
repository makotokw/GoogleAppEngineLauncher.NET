using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoogleAppEngine;

namespace GoogleAppEngineLauncher
{
    public partial class FmMain : Form
    {
        protected GoogleAppEngine.GoogleAppEngine engine;
        protected Preferences pref;

        public FmMain()
        {
            InitializeComponent();
            this.Load += new EventHandler(FmMain_Load);
        }

        void FmMain_Load(object sender, EventArgs e)
        {
            ImageList stImageList = new ImageList();
            stImageList.Images.Add(ApplicationStatus.Off.ToString(), GoogleAppEngineLauncher.Properties.Resources.Off);
            stImageList.Images.Add(ApplicationStatus.On.ToString(), GoogleAppEngineLauncher.Properties.Resources.On);
            this.listApp.FullRowSelect = true;
            this.listApp.SmallImageList = stImageList;
            this.listApp.SelectedIndexChanged += new EventHandler(listApp_SelectedIndexChanged);

            engine = GoogleAppEngine.GoogleAppEngine.CreateInstance();
            string path = System.Windows.Forms.Application.StartupPath + @"\pref.xml";
            pref = new Preferences();
            pref.PreferencesChanged += new Preferences.PreferencesChangedEnventHandler(pref_PreferencesChanged);
            pref.Load(path);
            doAppyPreferences();
            updateApplicationList();            
        }

        void listApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        void doAppyPreferences()
        {
            engine.PythonPath = pref.PythonPath;
            engine.InstallPath = pref.InstallPath;
            engine.BrowserPath = pref.BrowserPath;
            engine.EMail = pref.EMail;
            doValidateEnviroment();
        }

        public GoogleAppEngine.Application SelectedApplication
        {
            get
            {
                GoogleAppEngine.Application app = null;
                if (this.listApp.SelectedItems != null && this.listApp.SelectedItems.Count > 0)
                {
                    ListViewItem item = this.listApp.SelectedItems[0];
                    app = (GoogleAppEngine.Application)item.Tag;
                }
                return app;
            }
        }

        void doValidateEnviroment()
        {
            string str = "";
            if (!GoogleAppEngine.GoogleAppEngine.Current.IsInstalled)
            {
                str += "\nGoogle App Engine is not installed.";
            }
            if (!GoogleAppEngine.GoogleAppEngine.Current.IsPythonInstalled)
            {
                str += "\npython is not installed.";
            }
            if (str.Length > 0)
            {
                MessageBox.Show(str);
                doOpenPreference();
            }
        }

        void pref_PreferencesChanged(object sender, Preferences.PreferencesChangedEventArgs e)
        {
            doAppyPreferences();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        void updateApplicationList()
        {
            this.listApp.Items.Clear();
            foreach (GoogleAppEngine.Application app in this.pref.Applications)
            {
                app.FromConfig();
                this.listApp.Items.Add(new ListViewAppItem(app));
            }
        }

        void doOpenPreference()
        {
            FmPreferences dlg = new FmPreferences();
            dlg.PythonPath = pref.PythonPath;
            dlg.InstallPath = pref.InstallPath;
            dlg.BrowserPath = pref.BrowserPath;
            dlg.EMail = pref.EMail;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pref.PythonPath = dlg.PythonPath;
                pref.InstallPath = dlg.InstallPath;
                pref.BrowserPath = dlg.BrowserPath;
                pref.EMail = dlg.EMail;
                pref.FirePreferencesChanged();
                pref.Save();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FmAppSettings dlg = new FmAppSettings();
            dlg.CreateMode();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                GoogleAppEngine.Application app = new GoogleAppEngine.Application();
                app.Set(dlg.ApplicatonName, dlg.Directory, dlg.Port);
                this.pref.Applications.Add(app);
                this.pref.Save();
                this.updateApplicationList();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.listApp.SelectedItems != null && this.listApp.SelectedItems.Count > 0)
            {
                string message = string.Format("Remove {0} items from the project? (The on-disk content will not be modified.)",this.listApp.SelectedItems.Count);
                if (MessageBox.Show(message, "Remove Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in this.listApp.SelectedItems)
                    {
                        this.pref.Applications.Remove(item.Tag);
                    }
                    this.updateApplicationList();
                }
            }
        }

        private void btnPref_Click(object sender, EventArgs e)
        {
            doOpenPreference();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GoogleAppEngine.Application app = SelectedApplication;
            if (app != null)
            {
                FmAppSettings dlg = new FmAppSettings();
                dlg.EditMode();
                dlg.ApplicatonName = app.Name;
                dlg.Directory = app.Directory;
                dlg.Port = app.Port;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    app.Set(dlg.ApplicatonName, dlg.Directory, dlg.Port);
                    this.pref.Save();
                    // Hack!:
                    this.Focus();
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
             GoogleAppEngine.Application app = SelectedApplication;
             if (app != null)
             {
                 app.RunAppServer();
             }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            GoogleAppEngine.Application app = SelectedApplication;
            if (app != null)
            {
                app.StopAppServer();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            GoogleAppEngine.Application app = SelectedApplication;
             if (app != null)
             {
                 app.Browse();
             }
        }

        private void btnDeploy_Click(object sender, EventArgs e)
        {
            GoogleAppEngine.Application app = SelectedApplication;
            if (app != null)
            {
                app.Deploy();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            GoogleAppEngine.Application app = SelectedApplication;
             if (app != null)
             {
                 app.Dashboard();
             }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            FmAbout dlg = new FmAbout();    
            dlg.ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoogleAppEngine.GoogleAppEngine.NavigateUrl(Launcher.ProjectSiteUrl);
        }

        private void openApplicationDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GoogleAppEngine.Application app = SelectedApplication;
                if (app != null)
                {
                    System.Diagnostics.Process.Start(app.Directory);
                }                
            }
            catch (Exception)
            {

            }
        }

        private void sDKConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoogleAppEngine.Application app = SelectedApplication;
            if (app != null)
            {
                app.Console();
            }
        }

        private void btnConsole_Click(object sender, EventArgs e)
        {
            GoogleAppEngine.Application app = SelectedApplication;
            if (app != null)
            {
                app.Console();
            }
        }

        private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GoogleAppEngine.Application app = SelectedApplication;
                if (app != null)
                {
                    app.Terminal();
                }
                else
                {
                    System.Diagnostics.Process.Start("cmd.exe");
                }
            }
            catch (Exception)
            {

            }
        }

        private void rollbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoogleAppEngine.Application app = SelectedApplication;
            if (app != null)
            {
                app.Rollback();
            }
        }

        private void browseAppspotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoogleAppEngine.Application app = SelectedApplication;
            if (app != null)
            {
                app.BrowseServer();
            }
        }

        
    }
}
