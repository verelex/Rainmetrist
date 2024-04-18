using System.IO;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace WeatherWorker1
{
    internal class LogWriter
    {
        public LogWriter()
        {
        }

        public void LogWrite(string pathAndFileName, string logMessage)
        {
            try
            {
                StreamWriter w = new StreamWriter(pathAndFileName, false); // false = перезапись, true = добавление
                //w = File.AppendText(pathAndFileName);
                w.Write(logMessage);
                w.Close(); // закрываем файл после записи, иначе ошибка
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
