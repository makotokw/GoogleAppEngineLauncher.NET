namespace GoogleAppEngineLauncher
{
    partial class FmPreferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmPreferences));
            this.label1 = new System.Windows.Forms.Label();
            this.tbPythonPath = new System.Windows.Forms.TextBox();
            this.tbInstallPath = new System.Windows.Forms.TextBox();
            this.btnChoosePython = new System.Windows.Forms.Button();
            this.btnChooseInstall = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBrowserPath = new System.Windows.Forms.TextBox();
            this.btnChooseBrowser = new System.Windows.Forms.Button();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Python Path:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPythonPath
            // 
            this.tbPythonPath.Location = new System.Drawing.Point(101, 6);
            this.tbPythonPath.Name = "tbPythonPath";
            this.tbPythonPath.Size = new System.Drawing.Size(345, 19);
            this.tbPythonPath.TabIndex = 1;
            // 
            // tbInstallPath
            // 
            this.tbInstallPath.Location = new System.Drawing.Point(101, 31);
            this.tbInstallPath.Name = "tbInstallPath";
            this.tbInstallPath.Size = new System.Drawing.Size(345, 19);
            this.tbInstallPath.TabIndex = 2;
            // 
            // btnChoosePython
            // 
            this.btnChoosePython.Location = new System.Drawing.Point(452, 4);
            this.btnChoosePython.Name = "btnChoosePython";
            this.btnChoosePython.Size = new System.Drawing.Size(75, 23);
            this.btnChoosePython.TabIndex = 3;
            this.btnChoosePython.Text = "Choose";
            this.btnChoosePython.UseVisualStyleBackColor = true;
            this.btnChoosePython.Click += new System.EventHandler(this.btnChoosePython_Click);
            // 
            // btnChooseInstall
            // 
            this.btnChooseInstall.Location = new System.Drawing.Point(452, 29);
            this.btnChooseInstall.Name = "btnChooseInstall";
            this.btnChooseInstall.Size = new System.Drawing.Size(75, 23);
            this.btnChooseInstall.TabIndex = 4;
            this.btnChooseInstall.Text = "Choose";
            this.btnChooseInstall.UseVisualStyleBackColor = true;
            this.btnChooseInstall.Click += new System.EventHandler(this.btnChooseInstall_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Install Path:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(371, 145);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button4.Location = new System.Drawing.Point(452, 145);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "OK";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Browser:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbBrowserPath
            // 
            this.tbBrowserPath.Location = new System.Drawing.Point(101, 56);
            this.tbBrowserPath.Name = "tbBrowserPath";
            this.tbBrowserPath.Size = new System.Drawing.Size(345, 19);
            this.tbBrowserPath.TabIndex = 8;
            // 
            // btnChooseBrowser
            // 
            this.btnChooseBrowser.Location = new System.Drawing.Point(452, 54);
            this.btnChooseBrowser.Name = "btnChooseBrowser";
            this.btnChooseBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnChooseBrowser.TabIndex = 10;
            this.btnChooseBrowser.Text = "Choose";
            this.btnChooseBrowser.UseVisualStyleBackColor = true;
            this.btnChooseBrowser.Click += new System.EventHandler(this.btnChooseBrowser_Click);
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(101, 82);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(345, 19);
            this.tbMail.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "E-Mail:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FmPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 180);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.btnChooseBrowser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBrowserPath);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChooseInstall);
            this.Controls.Add(this.btnChoosePython);
            this.Controls.Add(this.tbInstallPath);
            this.Controls.Add(this.tbPythonPath);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FmPreferences";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPythonPath;
        private System.Windows.Forms.TextBox tbInstallPath;
        private System.Windows.Forms.Button btnChoosePython;
        private System.Windows.Forms.Button btnChooseInstall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBrowserPath;
        private System.Windows.Forms.Button btnChooseBrowser;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label label4;
    }
}