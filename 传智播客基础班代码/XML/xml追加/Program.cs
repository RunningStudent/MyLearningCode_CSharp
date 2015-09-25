using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
namespace xml追加
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(@"D:\学习\代码\XML\XML\bin\Debug\xml文档.xml"))
            {
                doc.Load(@"D:\学习\代码\XML\XML\bin\Debug\xml文档.xml");
                XmlElement gen = doc.DocumentElement;

                XmlElement xinzi1 = doc.CreateElement("新节点");
                xinzi1.InnerText = "新节点的内容";
                gen.AppendChild(xinzi1);
            }
            else
            {
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(dec);
                XmlElement gen = doc.CreateElement("根节点");
              
                doc.AppendChild(gen);
            }
            doc.Save("xml文档.xml");
            Console.WriteLine("保存成功");
            Console.ReadKey();

        }
    }
}
