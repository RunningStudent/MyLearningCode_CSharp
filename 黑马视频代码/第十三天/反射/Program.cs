using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace 反射
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 获得类的Type
            ////方法一:无实例对象
            ////Type personType = typeof(Person);
            ////方法二:有实例对象
            //Person p=new Person();
            //Type personType = p.GetType();

            ////输出类名,会输出反射.Person
            //Console.WriteLine(personType);
            #endregion

            #region 获得外部程序集,以及里面的类
            //Assembly assembly = Assembly.LoadFile(@"D:\学习\黑马学习\黑马视频代码\第十三天\给反射载入的程序集\bin\Debug\给反射载入的程序集.dll");
            ////获得程序集中的所有类
            //Type[] types = assembly.GetTypes();
            #endregion

            #region 获得类的方法,这里只能获得public的方法,private有另外的方式
            //Type personType = typeof(Person);
            //MethodInfo[]methods=personType.GetMethods();
            //会得到所有非私有的方法,包括继承下来的,属性的
            ////打印方法名
            //foreach (var item in methods)
            //{
            //    Console.WriteLine(item.Name);
            //}
            #endregion

            #region 获得字段,非私有
            //Type personType = typeof(Person);
            //FieldInfo []fields=personType.GetFields();
            //foreach (var item in fields)
            //{
            //    Console.WriteLine(item.Name);
            //}
            #endregion

            #region 获得属性,非私有
            //Type personType = typeof(Person);
            //PropertyInfo[] properties=personType.GetProperties();
            //foreach (var item in properties)
            //{
            //    Console.WriteLine(item.Name);
            //}
            #endregion

            #region 获得所有成员,非私有
            //Type personType = typeof(Person);
            //MemberInfo []menbers=personType.GetMembers();
            //foreach (var item in menbers)
            //{
            //    Console.WriteLine(item.Name);
            //}
            #endregion

            #region 获得构造函数
            //Type personType = typeof(Person);
            //ConstructorInfo constructor = personType.GetConstructor(new Type[] { typeof(double), typeof(double), typeof(int) });
            #endregion

            #region 创建对象:用type创建,用构造函数创建,获得指定方法并调用方法
            //Type personType = typeof(Person);
            //object p = Activator.CreateInstance(personType);
            //ConstructorInfo constructor = personType.GetConstructor(new Type[] { typeof(double), typeof(double), typeof(int) });
            //object pp=constructor.Invoke(new object[]{123,1234,12345});
            ////测试下,于是调用ShowMyself()来测试
            //MethodInfo meth = personType.GetMethod("ShowMyself");
            //meth.Invoke(pp,null);//需要传入方法的调用者对象,和方法参数

            #endregion

            #region 获得指定重载方法,并调用之
            Type personType = typeof(Person);
            //MethodInfo method = personType.GetMethod("SayHello", new Type[] { typeof(string) });
            //object p = Activator.CreateInstance(personType);
            //method.Invoke(p, new object[] { "二逼你好" });
            #endregion
            Console.ReadKey();
        }
    }
    public class Person
    {
        public double Height { get; set; }
        public double _weight;
        private int _age;
        public Person()
        { }
        public Person(double h, double w, int a)
        {
            this.Height = h;
            this._weight = w;
            this._age = a;
        }
        public void SayHi()
        {
            Console.WriteLine("Hi~~~");
        }
        private void SayHello()
        {
            Console.WriteLine("Hello~~!");
        }
        public void SayHello(string str)
        {
            Console.WriteLine(str);
        }
        public void ShowMyself()
        {
            Console.WriteLine(Height);
            Console.WriteLine(_weight);
            Console.WriteLine(_age);
        }
    }
}
