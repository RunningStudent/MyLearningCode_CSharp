using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Xml练习_XDocument_
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument document = new XDocument();
            //第三个参数为yes,说明这个xml是单纯的xml无任何规定,能随意写标签
            XDeclaration delaration = new XDeclaration("1.0", "utf-8", "yes");
            //文档声明写入文档
            document.Declaration = delaration;
            
            //XElement rootNode = new XElement("根节点", "这是根节点的内容,但是一般不放文字");
            XElement rootNode = new XElement("根节点");


            //在根节点内加入两个有内容的子节点
            XElement sonNode1 = new XElement("子节点1", "我是有文字内容的");
            rootNode.Add(sonNode1);
            XElement sonNode2 = new XElement("子节点2", "我是有文字内容的");
            rootNode.Add(sonNode2);


            //加入有子节点的子节点
            XElement sonNode3 = new XElement("子节点3");
            //这个节点加入子节点
            XElement sunNode1 = new XElement("孙节点", "我有文字内容和属性");
            //给这个节点设置属性
            sunNode1.SetAttributeValue("id", "孙节点1好");
            sonNode3.Add(sunNode1);
            rootNode.Add(sonNode3);

            //直接在根节点添加子节点,但是这样拿不到子节点对象
            rootNode.SetElementValue("子节点4", "我有文字内容");
            //设置属性
            rootNode.SetAttributeValue("id", "唯一的根节点");


            document.Add(rootNode);
            document.Save("xml文档.xml");
            Console.WriteLine("ok");
            Console.ReadKey();

        }
    }
}
