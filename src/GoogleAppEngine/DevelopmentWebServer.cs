using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GoogleAppEngine
{
    public class DevelopmentWebServer
    {
        private const string Script = "dev_appserver.py";
        private Process process;

        public DevelopmentWebServer()
        {
        }

        virtual public bool IsRunning
        {
            get
            {
                try
                {
                    return (process != null && !process.HasExited);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Write(ex);
                }
                return false;
            }            
        }

        virtual public bool Run(string path, int port)
        {
            bool ret = false;
            if (process != null) return false;
            try
            {
                process = new Process();
                process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
                process.Exited += new EventHandler(process_Exited);
                process.StartInfo.FileName = GoogleAppEngine.Current.PythonPath;
                process.StartInfo.Arguments = string.Format("\"{0}\" --port {1} \"{2}\"", GoogleAppEngine.Current.InstallPath + @"\" + Script, port, path); ;
                ret = process.Start();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }
 
            return ret;
        }

        void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            
        }
        
        virtual public void Stop()
        {
            try
            {
                if (process != null)
                {
                    if (!process.HasExited)
                    {
                        process.Kill();
                        process = null;
                        this.doFireExited();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }
        }

        void process_Exited(object sender, EventArgs e)
        {
            process = null;
            this.doFireExited();
        }

        public delegate void ExitedEnventHandler(object sender, EventArgs e);
        public event ExitedEnventHandler Exited;
        protected void doFireExited()
        {
            if (Exited != null)
            {
                EventArgs args = new EventArgs();
                Exited(this, args);
            }

        }
    }
}
