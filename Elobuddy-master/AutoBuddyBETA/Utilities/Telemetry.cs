using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace AutoBuddy.Utilities
{
    static class Telemetry
    {
        private static string id;
        private static string dir;
        static Telemetry()
        {

        }

        public static void Init(string directory)
        {
            
            dir = directory;
            setId();
        }

        private static void setId()
        {
            if (!File.Exists(dir + "\\profile"))
                getId();
            else
            {
                string content = File.ReadAllText(dir + "\\profile");
                if (content.Equals(string.Empty))
                    getId();
                id = content;
            }
        }
        public static void SendEvent(string type, Dictionary<string, string>data )
        {
            BackgroundWorker bw3 = new BackgroundWorker();          
            bw3.RunWorkerAsync(new object[] { type, data });
        }
               

        public static void SendFileAndDelete(string file, string name)
        {

            BackgroundWorker bw2 = new BackgroundWorker();        
            bw2.RunWorkerAsync(new[]{file, name});
        }

     

        private static void getId()
        {
            BackgroundWorker bw = new BackgroundWorker();         
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }
      

        private static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            id = (string) e.Result;
            File.WriteAllText(dir + "\\profile", id);
        }


    }
}
