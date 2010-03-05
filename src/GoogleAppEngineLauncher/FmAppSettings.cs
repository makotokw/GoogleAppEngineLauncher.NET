using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoogleAppEngineLauncher
{
    public partial class FmAppSettings : Form
    {
        public FmAppSettings()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        public void CreateMode()
        {
            this.Text = "New Applicatoin Settings";
            this.btnOk.Text = "Create";
        }

        public void EditMode()
        {
            this.Text = "Edit Applicatoin Settings";
            this.btnOk.Text = "Edit";
        }

        public string ApplicatonName
        {
            set { tbName.Text = value; }
            get { return this.tbName.Text; }
        }

        public string Directory
        {
            set { tbDirectory.Text = value; }
            get { return this.tbDirectory.Text; }
        }

        public int Port
        {
            set { tbPort.Text = value.ToString(); }
            get
            {
                int p = 0;
                Int32.TryParse(tbPort.Text, out p);
                return p;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                DialogResult = DialogResult.OK;
                Hide();
                return;
            }
            MessageBox.Show("input is invalid");
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.tbDirectory.Text = fbd.SelectedPath;
            }
        }

        public override bool ValidateChildren()
        {
            if (tbName.Text.Trim().Length == 0) return false;
            if (tbDirectory.Text.Trim().Length == 0) return false;
            if (Port<=0 || Port>65535) return false;
            return true;
        }

        private void tbPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(e.KeyChar == (char)Keys.Back || System.Char.IsNumber(e.KeyChar));
        }
    }
}
