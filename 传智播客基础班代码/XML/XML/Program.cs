using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XML
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);//专门用来写入第一条信息
            doc.AppendChild(dec);
            XmlElement gen = doc.CreateElement( "根节点");
            doc.AppendChild(gen);
            XmlElement zi1 = doc.CreateElement("子节点");
            gen.AppendChild(zi1);

            XmlElement zi2 = doc.CreateElement("带具体内容的子节点");
            zi2.InnerText = "这是我的具体内容";
            gen.AppendChild(zi2);

            XmlElement zi3 = doc.CreateElement("InnerText载入标签会是转义");
            zi3.InnerText = "<p>我是一个p</p>";
            gen.AppendChild(zi3);

            XmlElement zi4 = doc.CreateElement("所以用Innerxml");
            zi4.InnerXml="<p>我是一个p</p>";
            gen.AppendChild(zi4);

            XmlElement zi5 = doc.CreateElement("带属性的标签");
            zi5.SetAttribute("这是我的属性名", "这是我的值");
            gen.AppendChild(zi5);
            doc.Save("xml文档.xml");
        }
    }
}
