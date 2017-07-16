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
        public void Write(string fileName, string msg)
        {
            string logPath = Properties.Settings.Default.LogPath;
            string logFileName = string.Format("checkorderxml_{0}.log", fileName);
            string logFilePath = Path.Combine(logPath, logFileName);
            //UTF8で書き込む
            //書き込むファイルが既に存在している場合は、上書きする
            using (StreamWriter sw = new StreamWriter(logFilePath, true, Encoding.UTF8))
            {
                sw.WriteLine(msg);
                //閉じる
                sw.Close();
            }
        }
    }
}
