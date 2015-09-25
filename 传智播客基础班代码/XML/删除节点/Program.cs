using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace 删除节点
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("xml文档.xml");
            XmlNode node=doc.SelectSingleNode("/根节点");
            node.RemoveAll();
            doc.Save("xml文档.xml");
        }
    }
}
