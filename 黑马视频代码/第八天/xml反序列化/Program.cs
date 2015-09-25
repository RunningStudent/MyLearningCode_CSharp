using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using xml序列化;
namespace xml反序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Person));
            using (FileStream fs=File.OpenRead("已序列化的人.txt"))
            {
                object o=xs.Deserialize(fs);
                Person p=o as Person ;
                Console.WriteLine("{0} {1} {2} ",p.name ,p.sex ,p.age );
                Console .ReadKey ();
            }
        }
    }
}
