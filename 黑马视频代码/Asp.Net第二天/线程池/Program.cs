using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace 线程池
{
    class Program
    {
        static void Main(string[] args)
        {
            //线程池:TreedPool
            //默认后台线程
            //特点:能线程重用,即完成任务的线程不会被销毁,会被放到池中等待其他任务
            //因此不需耗费大量资源创建过多线程
            //给线程池添加回调函数
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine(s);

            }, "测试文本1");

            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine(s);

            }, "测试文本2");

            //获得线程最大的线程数据
            int numMax = 0;
            int runNumMax = 0;
            ThreadPool.GetMaxThreads(out numMax, out runNumMax);
            Console.WriteLine("最大线程数{0},当前设置最大为{1}", numMax, runNumMax);

            //获得线程最小的线程数据
            ThreadPool.GetMinThreads(out numMax, out runNumMax);
            Console.WriteLine("最小线程数{0},当前设置最小为{1}", numMax, runNumMax);


            Console.Read();

        }
    }
}
