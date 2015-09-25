using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace Demo.Common
{
    public class LogHelper
    {
        //保存错误消息的队列,队列等待着被写入磁盘
        public static Queue<string> ExcpetionInfoQueue = new Queue<string>();

        //保存日志的根目录路径
        public static string LogBasePath;

        //这什么鬼
        static LogHelper()
        {
            //开启线程写日志
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    //如果队列不为空
                    if (ExcpetionInfoQueue.Count > 0)
                    {
                        //获得错误信息
                        string str = ExcpetionInfoQueue.Dequeue();

                        //根据日期创建文件名
                        string strFileName = DateTime.Now.ToString(@"yyyy-MM-dd") + ".txt";

                        //创建文件绝对路径
                        string absoluteFileName = Path.Combine(LogBasePath, strFileName);

                        //加个锁,防止并发请求的产生的问题
                        lock (ExcpetionInfoQueue)
                        {
                            using (FileStream fs = new FileStream(absoluteFileName, FileMode.Append, FileAccess.Write))
                            {
                                byte[] data = Encoding.Default.GetBytes(str);
                                fs.Write(data, 0, data.Length);
                            }
                        }
                    }
                }
            });
        }

    }
}