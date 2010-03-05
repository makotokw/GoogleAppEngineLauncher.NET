using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GoogleAppEngineLauncher
{
    class ListViewAppItem : ListViewItem
    {
        public GoogleAppEngine.Application app;
        public ListViewAppItem(GoogleAppEngine.Application app)
        {
            app.PropertyChanged += new GoogleAppEngine.Application.PreferencesChangedEnventHandler(app_PropertyChanged);
            app.StatusChanged += new GoogleAppEngine.Application.StatusChangedEnventHandler(app_StatusChanged);
            this.app = app;
            this.Tag = app;
            this.Update();
        }

        void app_StatusChanged(object sender, EventArgs e)
        {
            this.UpdateStatus();
        }

        void app_PropertyChanged(object sender, EventArgs e)
        {
            this.Update();
        }

        public void UpdateStatus()
        {
            this.ImageKey = app.Status.ToString();
        }

        public void Update()
        {
            this.SubItems.Clear();
            this.SubItems.Add(app.Name);
            this.SubItems.Add(app.Directory);
            this.SubItems.Add(app.Port.ToString());
            UpdateStatus();
        }
        public override string ToString()
        {
            return app.Name;
        }
    }
}
