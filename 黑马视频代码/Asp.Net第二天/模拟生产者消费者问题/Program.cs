using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace 模拟生产者消费者问题
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //创建一百个容量的连接池
            MyConnectionPool[] pools = new MyConnectionPool[100];
            //创建索引,默认为-1
            int index = 0;

            //创建5个生产者
            for (int i = 0; i < 5;i++ )
            {
                //在每个生产者不断地创建一个连接对象,保存到连接池
                Thread td = new Thread(() =>
                {
                    while (true)
                    {

                        if (index < 99)
                        {
                            pools[index] = new MyConnectionPool();
                            Console.WriteLine("生产者{0},创建了连接{1}", i, index);
                            index++;

                        }
                        Thread.Sleep(200);
                    }
                });
                td.IsBackground = true;
                td.Start();
            }

            //创建10个消费者
            for (int j = 0; j < 10;j++ )
            {
                //在每个消费者不断地消费连接
                Thread td = new Thread(() =>
                {
                    while (true)
                    {
                        if (index > 0)
                        {
                            pools[index] = null;
                            index--;
                            Console.WriteLine("消费者{0},消费了连接{1}", j, index);
                        }
                        Thread.Sleep(200);
                    }
                });
                td.IsBackground = true;
                td.Start();
            }
            //会出现问题:消费者同时消费最后一个连接,导致index<0,导致生产者生产抛异常
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 连接池对象
    /// </summary>
    class MyConnectionPool
    {

    }
}
