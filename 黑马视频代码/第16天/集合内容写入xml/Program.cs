using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace 集合内容写入xml
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建集合
            List<Person> list = new List<Person>(){
                new Person(){_age=12,_name="傻逼1号",_sex="男" },
                new Person(){_age=13,_name="傻逼2号",_sex="女"},
                new Person(){_age=14,_name="二逼1号",_sex="未知"}
            };
            //创建文档
            XDocument document = new XDocument();
            document.Declaration = new XDeclaration("1.0", "utf-8", "yes");
            XElement rootNode = new XElement("人的集合");
            document.Add(rootNode);
            foreach (var item in list)
            {
                XElement personNode = new XElement("Person");
                XElement name = new XElement("Name", item._name);
                XElement age = new XElement("Age", item._age);
                XElement sex = new XElement("Sex", item._sex);
                personNode.Add(name, age, sex);
                rootNode.Add(personNode);
            }
            document.Save("人的list集合.xml");
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
    class Person
    {
        public string _name;
        public int _age;
        public string _sex;
    }
}
