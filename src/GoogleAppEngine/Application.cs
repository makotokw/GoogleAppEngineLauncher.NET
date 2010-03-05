using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace GoogleAppEngine
{
    public enum ApplicationStatus
    {
        Off,
        On,
        Starting,
        ProdOn,
        Died,
    }

    public class Application
    {
        const string ConfigFileName = "app.yaml";

        private ApplicationStatus status = ApplicationStatus.Off;
        private string id = "";
        private string version = "";
        private string runtime = "python";
        private string api_version = "";
        private DevelopmentWebServer webServer;

        [XmlIgnore]
        public string Id { get { return this.id; } }
        [XmlIgnore]
        public string Version { get { return this.version; } }
        [XmlIgnore]
        public string Runtime { get { return this.runtime; } }
        [XmlIgnore]
        public string ApiVersion { get { return this.api_version; } }

        [XmlAttribute(AttributeName = "name")]
        public string Name = "";
        [XmlAttribute(AttributeName = "path")]
        public string Directory = "";
        [XmlAttribute(AttributeName = "port")]
        public int Port = 0;

        [XmlIgnore]
        public ApplicationStatus Status
        {
            get { return this.status; }
            set
            {
                if (this.status != value)
                {
                    this.status = value;
                    this.FireStatusChanged();
                }
            }
        }

        [XmlIgnore]
        public string Url
        {
            get
            {
                return "http://localhost:" + this.Port.ToString();
            }
        }

        [XmlIgnore]
        public string ServiceUrl
        {
            get
            {
                return "http://" + this.Id.ToString() + ".appspot.com";
            }
        }

        [XmlIgnore]
        public string AdminUrl
        {
            get
            {
                return "http://localhost:" + this.Port.ToString()+"/_ah/admin/";
            }
        }


        public Application()
        {
        }

        public Application(string name, string directory, int port)
        {
            this.Set(name, directory, port);
        }

        public void Set(string name, string directory, int port)
        {
            id = Name = name;
            Directory = directory;
            Port = port;
            this.FromConfig();
            this.FirePropertyChanged();
        }

        public void FromConfig()
        {
            string path = this.Directory + @"\" + ConfigFileName;
            this.FromConfig(path);
        }

        Regex regex = new Regex("application[\\s]*:[\\s]*([\\w_-]+)");
        public void FromConfig(string pathName)
        {            
            try
            {
                // TODO: require YamlParser
                string text = System.IO.File.ReadAllText(pathName);                
                Match match = regex.Match(text);
                if (match.Success)
                {
                    id = match.Groups[1].Value;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        virtual public DevelopmentWebServer CreateWebServer()
        {
            return new DevelopmentWebServer();
        }

        virtual public void RunAppServer()
        {
            this.StopAppServer();
            this.webServer = new DevelopmentWebServer();
            this.webServer.Exited += new DevelopmentWebServer.ExitedEnventHandler(webServer_Exited);
            this.webServer.Run(this.Directory, this.Port);
            this.UpdateStatus();
        }

        virtual public void UpdateStatus()
        {
            if (this.webServer != null && webServer.IsRunning) this.Status = ApplicationStatus.On;
            else this.Status = ApplicationStatus.Off;
        }

        void webServer_Exited(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        virtual public void StopAppServer()
        {
            if (this.webServer != null)
            {
                this.webServer.Stop();
            }
        }

        virtual public void Browse()
        {
            GoogleAppEngine.NavigateUrl(Url);
        }

        virtual public void BrowseServer()
        {
            GoogleAppEngine.NavigateUrl(this.ServiceUrl);
        }

        virtual public void Console()
        {
            GoogleAppEngine.NavigateUrl(AdminUrl);
        }

        virtual public void Deploy()
        {
            try
            {
                string options = "";
                if (GoogleAppEngine.Current.EMail.Length > 0)
                {
                    options += "--email=" + GoogleAppEngine.Current.EMail;
                }
                Process p = new Process();
                p.StartInfo.FileName = GoogleAppEngine.Current.PythonPath;
                p.StartInfo.Arguments = string.Format("\"{0}\" {1} update \"{2}\"", GoogleAppEngine.Current.InstallPath + @"\" + GoogleAppEngine.AppcfgFileName, options, Directory);
                if (p.Start())
                {
                }                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }
        }

        virtual public void Rollback()
        {
            try
            {
                string options = "";
                if (GoogleAppEngine.Current.EMail.Length > 0)
                {
                    options += "--email=" + GoogleAppEngine.Current.EMail;
                }
                Process p = new Process();
                p.StartInfo.FileName = GoogleAppEngine.Current.PythonPath;
                p.StartInfo.Arguments = string.Format("\"{0}\" {1} rollback \"{2}\"", GoogleAppEngine.Current.InstallPath + @"\" + GoogleAppEngine.AppcfgFileName, options, Directory);
                if (p.Start())
                {
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }
        }

        virtual public void Terminal()
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.WorkingDirectory = this.Directory;
                if (p.Start())
                {
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }
        }

        virtual public void Dashboard()
        {
            GoogleAppEngine.NavigateUrl("http://appengine.google.com/dashboard?&app_id=" + Id);
        }

        public delegate void PreferencesChangedEnventHandler(object sender, EventArgs e);
        public event PreferencesChangedEnventHandler PropertyChanged;
        public void FirePropertyChanged()
        {
            if (PropertyChanged != null)
            {
                EventArgs args = new EventArgs();
                PropertyChanged(this, args);
            }
        }

        public delegate void StatusChangedEnventHandler(object sender, EventArgs e);
        public event StatusChangedEnventHandler StatusChanged;
        public void FireStatusChanged()
        {
            if (StatusChanged != null)
            {
                EventArgs args = new EventArgs();
                StatusChanged(this, args);
            }
        }
    }
}
