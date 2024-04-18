using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Rainmetrist
{
    internal class XMLWorker
    {
        public XMLWorker() { }

        public TwOptions LoadConfig(string xmlFile)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);
            // получим корневой элемент
            XmlElement? xRoot = doc.DocumentElement;
            TwOptions opt = new TwOptions();
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach (XmlElement xnode in xRoot)
                {
                    if (xnode.Name == "key") // city name
                    {
                        opt.key = xnode.InnerText;
                    }
                    if (xnode.Name == "q")   // city id 1 gismeteo
                    {
                        opt.q = xnode.InnerText;
                    }
                    if (xnode.Name == "rph") // run per hour
                    {
                        opt.rph = xnode.InnerText;
                    }
                    if (xnode.Name == "dhi") // default host item
                    {
                        opt.dhi = xnode.InnerText;
                    }
                    if (xnode.Name == "icl") // icon color
                    {
                        opt.icl = xnode.InnerText;
                    }
                }
            }
            return opt;
        }

        public void SaveConfig(string xmlFile, TwOptions opt)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml($"<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<opt>\r\n    <key>{opt.key}</key>\r\n    <q>{opt.q}</q>\r\n    <rph>{opt.rph}</rph>\r\n    <dhi>{opt.dhi}</dhi>    <icl>{opt.icl}</icl>\r\n</opt>");
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true; // отступы
                // Save the document to a file and auto-indent the output.
                XmlWriter writer = XmlWriter.Create(xmlFile, settings);
                doc.Save(writer);
                writer.Close(); // закроем файл!
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LoadConfig2(string xmlFile, out List<TwHosts> lth)
        {
            lth = new List<TwHosts>();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);
            // получим корневой элемент
            XmlElement? xRoot = doc.DocumentElement;
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе <opt>
                foreach (XmlElement xnode in xRoot)
                {
                    TwHosts twHosts = new TwHosts();
                    foreach (XmlNode xnode2 in xnode.ChildNodes)
                    {
                        if (xnode2.Name == "hst")
                        {
                            twHosts.hst = xnode2.InnerText;
                        }
                        if (xnode2.Name == "cls")
                        {
                            twHosts.cls = xnode2.InnerText;
                        }
                        /*if (xnode2.Name == "end")
                        {
                            twHosts.end = xnode2.InnerText;
                        }
                        if (xnode2.Name == "trm")
                        {
                            twHosts.trm = xnode2.InnerText;
                        }*/
                    }
                    lth.Add(twHosts);
                }
            }
        }

        public void SaveConfig2(string xmlFile, List<TwHosts> lth)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                string xmlStr = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                    $"<opt>\r\n  <url>\r\n    <hst>{lth[0].hst}</hst>\r\n    " +
                    $"<cls>{lth[0].cls}</cls>\r\n  </url>\r\n\r\n  <url>\r\n" +
                    $"    <hst>{lth[1].hst}</hst>\r\n    <cls>{lth[1].cls}</cls>\r\n" +
                    $"  </url>\r\n\r\n  <url>\r\n    <hst>{lth[2].hst}</hst>\r\n" +
                    $"    <cls>{lth[2].cls}</cls>\r\n  </url>\r\n\r\n  <url>\r\n" +
                    $"    <hst>{lth[3].hst}</hst>\r\n    " +
                    $"<cls>{lth[3].cls}</cls>\r\n  </url>\r\n</opt>";

                doc.LoadXml(xmlStr);
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true; // отступы
                // Save the document to a file and auto-indent the output.
                XmlWriter writer = XmlWriter.Create(xmlFile, settings);
                doc.Save(writer);
                writer.Close(); // закроем файл!
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
