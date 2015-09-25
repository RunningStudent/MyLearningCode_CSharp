using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 委托
{
    class Program
    {
        #region 委托申明

        //申明委托变量
        //关键字 返回类型 委托名 参数列表
        delegate int weituo(int a, int b);
        //静态方法
        static int M1(int a, int b)
        {
            return 1;
        }
        //实例方法
        public int M2(int a, int b)
        {
            return 2;
        }
        #endregion

        static void Main(string[] args)
        {
            #region 委托语法
            //weituo w = new weituo(M1);
            ////实例方法需要对象
            //Program p = new Program();
            //w += p.M2; 
            #endregion

            #region where案例
            //List<string> list = new List<string>(){
            //    "1","4","7","33","123"
            //};

            //var result=list.Where(x=>x.CompareTo("6")>0);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.ReadKey();
            #endregion


            #region 扩展方法:自定义where
            List<string> list = new List<string>(){
                "1","4","7","33","123"
            };

            var result = list.MyWhere(x => x.CompareTo("6") > 0);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
            #endregion
        }
    }




    //扩展方法
    public static class MyWhereExt
    {
        public static List<string> MyWhere(this List<string> list, Func<string, bool> method)
        {
            List<string> newlist = new List<string>();
            foreach (var item in list)
            {
                if (method(item))
                {
                    newlist.Add(item);
                }
            }
            return newlist;
        }
    }
}
