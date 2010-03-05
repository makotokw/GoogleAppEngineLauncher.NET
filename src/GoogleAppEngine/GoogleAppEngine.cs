using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GoogleAppEngine
{
    public class GoogleAppEngine
    {
        public const string HomeUrl = "http://code.google.com/appengine/";
        public const string PythonExe = "python.exe";
        public const string AppcfgFileName = "appcfg.py";

        public string PythonPath { get; set; }
        public string InstallPath { get; set; }
        public string BrowserPath { get; set; }
        public string EMail { get; set; }

        private GoogleAppEngine()
        {
            PythonPath = @"C:\Python25\"+PythonExe;
            InstallPath = @"C:\Program Files\Google\google_appengine";
        }

        // singleton
        static protected GoogleAppEngine instance;
        static public GoogleAppEngine CreateInstance()
        {
            if (instance == null)
            {
                instance = new GoogleAppEngine();
            }
            return instance;
        }
        static public GoogleAppEngine Current { get { return CreateInstance(); } }

        public bool Initialize()
        {
            SearchPyathonPathes();
            return true;
        }

        public bool IsPythonInstalled
        {
            get
            {
                bool ret = false;
                try
                {
                    ret = System.IO.File.Exists(PythonPath);
                }
                catch (Exception) { }
                return ret;
            }
        }

        public bool IsInstalled
        {
            get
            {
                bool ret = false;
                try
                {
                    ret = System.IO.Directory.Exists(InstallPath);
                }
                catch (Exception) { }
                return ret;
            }
        }

        static public void NavigateUrl(string url)
        {
            try
            {
                string path = Current.BrowserPath;
                if (path != null && System.IO.File.Exists(path))
                {
                    System.Diagnostics.Process.Start(path, url);
                }
                else
                {
                    System.Diagnostics.Process.Start(url);
                }
            }
            catch (Exception)
            {

            }
        }

        public void SearchPyathonPathes()
        {
            ArrayList pathes = new ArrayList();
            try
            {
                pathes.AddRange(getPythonPathes(@"C:\"));
            }
            catch (Exception) { }
        }

        public string[] getPythonPathes(string path)
        {
            return System.IO.Directory.GetDirectories(path, "Python*");
        }
    }
}
