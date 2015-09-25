using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace 读取属性
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("xml文档.xml");
            XmlNode node=doc.SelectSingleNode("/根节点/带属性的标签");
            Console.WriteLine(node.Attributes["这是我的属性名"].Value);
            Console.ReadKey();
        }
    }
}
