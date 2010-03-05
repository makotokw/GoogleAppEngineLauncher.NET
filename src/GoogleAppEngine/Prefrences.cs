using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

namespace GoogleAppEngine
{
    public class Preferences
    {
        static private XmlSerializer xmlSerializer;
        static private Preferences singleToneInstance = null;

        private string pathName;

        [XmlElement("python_path", Namespace = "")]
        public string PythonPath = @"C:\Python25\"+GoogleAppEngine.PythonExe;

        [XmlElement("install_path", Namespace = "")]
        public string InstallPath = @"C:\Program Files\Google\google_appengine";

        [XmlElement("browser_path", Namespace = "")]
        public string BrowserPath = @"";

        [XmlElement("email", Namespace = "")]
        public string EMail = @"";

        [XmlArray("apps", Namespace = "")]
        [XmlArrayItem("appsetings", Type = typeof(Application), Namespace = "")]
        public ArrayList Applications = new ArrayList();
        
        static public bool Open(string pathName)
        {
            singleToneInstance = new Preferences();
            return singleToneInstance.Load(pathName);
        }
        static public Preferences GetInstance()
        {
            System.Diagnostics.Debug.Assert(singleToneInstance != null);
            return singleToneInstance;
        }

        public Preferences()
        {
        }

        /// <summary>
        /// ファイルからインスタンスを生成する
        /// </summary>
        static public Preferences FromFile(string pathName)
        {
            Preferences instance = null;
            try
            {
                if (xmlSerializer == null)
                {
                    xmlSerializer = new XmlSerializer(typeof(Preferences));
                }
                using (FileStream s = new FileStream(pathName, FileMode.Open, FileAccess.Read))
                {
                    instance = (Preferences)xmlSerializer.Deserialize(s);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return instance;
        }

        public void CopyFrom(Preferences source)
        {
            if (source == null) return;

            this.PythonPath = source.PythonPath;
            this.InstallPath = source.InstallPath;
            this.BrowserPath = source.BrowserPath;
            this.EMail = source.EMail;
            this.Applications = source.Applications;
        }

        /// <summary>
        /// ファイルから読み込む
        /// </summary>
        public bool Load(string pathName)
        {
            bool ret = false;
            try
            {
                Preferences source = FromFile(pathName);
                if (source != null)
                {
                    CopyFrom(source);
                    ret = true;
                }
                this.pathName = pathName;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return ret;
        }

        /// <summary>
        /// ファイルへ保存する
        /// </summary>
        public bool Save()
        {
            try
            {
                // 開くファイルがなく、PathNameが設定されていないケースがある
                if (this.pathName != null && this.pathName != "")
                {
                    if (xmlSerializer == null)
                    {
                        xmlSerializer = new XmlSerializer(typeof(Preferences));
                    }

                    // 親ディレクトリ名の作成
                    string stParentName = System.IO.Path.GetDirectoryName(this.pathName);
                    Directory.CreateDirectory(stParentName);

                    // ファイルオープン
                    FileStream fs = new FileStream(this.pathName, FileMode.Create, FileAccess.Write);
                    // シリアル化し、XMLファイルに保存する
                    xmlSerializer.Serialize(fs, this);
                    // 閉じる
                    fs.Close();


                }
            }
            catch (Exception)
            {
            }

            return true;
        }

        /// <summary>
        /// 設定変更イベント
        /// </summary>
        public class PreferencesChangedEventArgs : EventArgs
        {
            public PreferencesChangedEventArgs()
            {
            }
        }
        public delegate void PreferencesChangedEnventHandler(object sender, PreferencesChangedEventArgs e);
        public event PreferencesChangedEnventHandler PreferencesChanged;
        public void FirePreferencesChanged()
        {
            if (PreferencesChanged != null)
            {
                PreferencesChangedEventArgs args = new PreferencesChangedEventArgs();
                PreferencesChanged(this, args);
            }

        }
    }
}
