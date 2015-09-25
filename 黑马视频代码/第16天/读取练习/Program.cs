using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace 读取练习
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建文档,以读取xml
            XDocument document = XDocument.Load("orders.xml");
            //重点是获得根节点
            XElement rootNode = document.Root;
            foreach (var item in rootNode.Elements())
            {
                switch (item.Name.ToString())
                {
                    case "CustomerName": Console.WriteLine("客户名称--{0}", item.Value);
                        break;
                    case "OrderNumber": Console.WriteLine("订单编号--{0}", item.Value);
                        break;
                    case "Item": Console.WriteLine("清单如下:");
                        break;
                }
                //尝试遍历子节点的子节点,如果无子节点,则下面代码无效果
                foreach (var son in item.Elements())
                {
                    PrintAttribute(son);//打印属性
                }
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }

        private static void PrintAttribute(XElement son)
        {
            foreach (var attribute in son.Attributes())
            {
                switch (attribute.Name.ToString())
                {
                    case "Name": Console.Write("物品名:{0}  ", attribute.Value);
                        break;
                    case "Count": Console.Write("数量:{0}", attribute.Value);
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}
