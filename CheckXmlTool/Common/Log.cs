using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckXmlTool.Common
{
    public class Log
    {
        public void Write(string fileName, string msg, bool isAppend = true)
        {
            string logPath = Properties.Settings.Default.LogPath;
            string logFileName = string.Format("checkorderxml_{0}.csv", fileName);
            string logFilePath = Path.Combine(logPath, logFileName);
            //UTF8で書き込む
            using (StreamWriter sw = new StreamWriter(logFilePath, isAppend, Encoding.UTF8))
            {
                sw.WriteLine(msg);
                //閉じる
                sw.Close();
            }
        }
    }
}
