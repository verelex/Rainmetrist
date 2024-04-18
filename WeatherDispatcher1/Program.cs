using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace WeatherDispatcher1
{
    internal class Program
    {
        private string AppName = "Weather Dispatcher";

        private string versionPrg = "1.0";

        private static List<TwHosts>? twHostsList;

        static void Main(string[] args)
        {
            if ( !args[0].Equals("VXNKL") )
            {
                return; // чтобы просто так не запускали
            }

            // загрузить конфиг
            string pathToCfgFile = System.AppContext.BaseDirectory + "disp.conf";
            XMLWorker xmlWorker = new XMLWorker();
            xmlWorker.LoadConfig2(pathToCfgFile, out twHostsList);

            string pathWithExe = System.AppContext.BaseDirectory + "WeatherWorker1.exe";

            //string arguments = "\"https://yandex.ru/pogoda/nizhnevartovsk?lat=60.938545&lon=76.558902\" \"C:\\_SHLAK\\data1.log\"";

            try
            {
                int i = 0;
                foreach (TwHosts twHost in twHostsList)
                {
                    using (Process myProcess = Process.Start(pathWithExe, $"\"{twHost.hst}\" \"{twHost.cls}\""))
                    {
                        do
                        {
                            myProcess.Refresh();
                        }
                        while (!myProcess.WaitForExit(5000));
                        int exitcode = myProcess.ExitCode;

                        if (exitcode == 777)
                        {
                            Console.WriteLine($"{++i} отработал\n");
                        }
                    }
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
