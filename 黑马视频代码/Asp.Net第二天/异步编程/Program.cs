using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace 异步编程
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, string> del = new Func<int, int, string>((a, b) =>
            {
                Thread.Sleep(1111);
                Console.WriteLine("该委托调用的线程Id是" + Thread.CurrentThread.ManagedThreadId);
                return (a + b).ToString();
                //打印当前线程Id
            });
            #region 无回调函数的委托异步调用

            ////该BeginInvoke是vs反编译出来的
            ////传入参数: 方法传入参数若干,回调函数,回调函数参数
            ////返回值:IAsyncResult表示异步状态的接口
            //IAsyncResult result = del.BeginInvoke(3, 4, null, null);
            ////内部原理:用线程池中的一个线程调用该方法

            ////EndInvoke 方法检索异步调用的结果。 在调用 BeginInvoke 之后随时可以调用该方法。 如果异步调用尚未完成，则 EndInvoke 会一直阻止调用线程，直到异步调用完成。 
            //string resultValue = del.EndInvoke(result);
            //Console.WriteLine("委托结果是{0},当前线程是{1}", resultValue, Thread.CurrentThread.ManagedThreadId);

            #endregion

            #region 有回调函数的委托异步调用

            #region 第一种调用法
            ////回调函数的执行线程与异步委托的执行线程一样
            //del.BeginInvoke(3, 4, MyAsyncCallback, "我是回调函数传入参数");
            #endregion

            #region 第二中调用法
            //把异步执行的委托作为回调函数参数
            del.BeginInvoke(3, 4, MyAsyncCallback, del);
            #endregion

            #endregion

            Console.ReadKey();
        }
        /// <summary>
        /// 我的回调函数2
        /// </summary>
        /// <param name="ar"></param>
        public static void MyAsyncCallback(IAsyncResult ar)
        {
            //获得回调函数参数,这里它是委托类型
            var del = (Func<int, int, string>)ar.AsyncState;

        }


        ///// <summary>
        ///// 我的回调函数1
        ///// </summary>
        ///// <param name="ar"></param>
        //public static void MyAsyncCallback(IAsyncResult ar)
        //{
        //    #region 获得异步执行返回值
        //    //拿到异步执行结果
        //    AsyncResult result = (AsyncResult)ar;
        //    //拿到执行的委托方法,其类型为object要强制转换
        //    var del = (Func<int, int, string>)result.AsyncDelegate;
        //    //获得结果
        //    string resultValue = del.EndInvoke(result);

        //    Console.WriteLine("异步执行的结果是" + resultValue);
        //    #endregion

        //    #region 获得回调函数的传入参数
        //    string parameter = (string)result.AsyncState;
        //    Console.WriteLine("回调函数获得的参数是:" + parameter);
        //    #endregion
        //}
    }
}
