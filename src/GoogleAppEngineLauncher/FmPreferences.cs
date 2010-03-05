using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoogleAppEngineLauncher
{
    public partial class FmPreferences : Form
    {
        public FmPreferences()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        public string PythonPath
        {
            get { return this.tbPythonPath.Text; }
            set { this.tbPythonPath.Text = value; }
        }

        public string InstallPath
        {
            get { return this.tbInstallPath.Text; }
            set { this.tbInstallPath.Text = value; }
        }

        public string BrowserPath
        {
            get { return this.tbBrowserPath.Text; }
            set { this.tbBrowserPath.Text = value; }
        }

        public string EMail
        {
            get { return this.tbMail.Text; }
            set { this.tbMail.Text = value; }
        }

        private void btnChoosePython_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.tbPythonPath.Text = fbd.SelectedPath + @"\"+GoogleAppEngine.GoogleAppEngine.PythonExe;
            }
        }

        private void btnChooseInstall_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.tbInstallPath.Text = fbd.SelectedPath;
            }
        }

        private void btnChooseBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.CheckFileExists = true;
            fd.CheckPathExists = true;
            fd.DefaultExt = "exe";
            fd.Filter = "exe file(*.exe)|*.exe|all files(*.*)|*.*";
            fd.FilterIndex = 1;
            fd.Multiselect = false;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.tbBrowserPath.Text = fd.FileName;
            }
        }
    }
}
