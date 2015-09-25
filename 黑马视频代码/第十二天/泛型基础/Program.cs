using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace 泛型基础
{
    #region 人类与比较器
    //class Person : IComparer<Person>
    //    {
    //        public string _name { get; set; }
    //        public int _age { get; set; }
    //        public double _height { get; set; }
    //        public int Compare(Person x, Person y)//按照身高来比较
    //        {
    //            return x._age - y._age;
    //        }
    //    }
    //    class HeigtCompare : IComparer<Person>
    //    {
    //        public int Compare(Person x, Person y)
    //        {
    //            return (int)(x._height - y._height);
    //        }
    //    }
    #endregion
    #region 实现
    //List<Person> list = new List<Person>();
    //Person p1 = new Person() { _height = 100, _age = 10, _name = "A" };
    //Person p2 = new Person() { _height = 110, _age = 12, _name = "B" };
    //Person p3 = new Person() { _height = 120, _age = 13, _name = "C" };
    //list.Add(p1);
    //list.Add(p3);
    //list.Add(p2);
    //list.Sort(new HeigtCompare());
    //foreach (var item in list)
    //{
    //    Console.WriteLine(item._height);
    //}
    //Console.ReadKey();
    #endregion

    class Program
    {
        
        
        #region 方法泛型
        //public static void m<T>(T a)
        //{
        //    Console.WriteLine(a);
        //}
        #endregion

    }

    #region 弱弱的解释
    //class Generic<T>
    //{
    //    public void A(T b)
    //    {
    //        Console.WriteLine(s + b);
    //    }
    //    public static string s = "这里根据T的不同而传入不同类型的值:";
    //}
    #endregion

    #region 模拟栈
    //class Stack<T>
    //{
    //    const int maxLength = 10;
    //    private T[] datas;
    //    public int dataPoint;
    //    public void Push(T d)
    //    {
    //        if (!isFull)
    //        {
    //            datas[dataPoint++] = d;
    //        }
    //    }
    //    public T Pop()
    //    {
    //        if (!isEmpty)
    //        {
    //            return datas[--dataPoint];
    //        }
    //        else
    //        {
    //            return datas[dataPoint];
    //        }
    //    }
    //    public Stack()//不用加T
    //    {
    //        datas = new T[maxLength];
    //    }
    //    public bool isFull { get { return dataPoint >= maxLength; } }
    //    //用属性来代表isFull,每次访问属性都会更新数据
    //    public bool isEmpty { get { return dataPoint <= 0; } }
    //}
    #endregion
   
    
}
