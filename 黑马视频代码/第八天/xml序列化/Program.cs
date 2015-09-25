using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace xml序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建序列化执行者
            Person p=new Person{ age=2 ,name ="2b",sex="公"};
            //只能序列化对象的字段 属性;
            XmlSerializer xs = new XmlSerializer(typeof(Person));
            using (FileStream fs = File.OpenWrite("已序列化的人.txt"))
            {
                xs.Serialize(fs, p);
            }
            Console.WriteLine("ok");
        }
    }
}
