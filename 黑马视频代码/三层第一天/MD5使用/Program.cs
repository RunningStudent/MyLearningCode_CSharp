using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace MD5使用
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 字符MD5
            Console.WriteLine("输入字符串");
            string str = Console.ReadLine();
            Console.WriteLine(GetMD5FromString(str));
            #endregion

            #region 文件MD5
            string path = @"D:\学习\工具\未分类工具\MD5\CalcMD5\CalcMD5.exe";
            Console.WriteLine(GetMD5FromFile(path));
            #endregion

            Console.ReadKey();
        }


        /// <summary>
        /// 生成文件MD5
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetMD5FromFile(string path)
        {
            using (MD5 md = MD5.Create())
            {
                using (FileStream sr = File.OpenRead(path))
                {
                    //传入文件的流给MD5处理(循环读取什么的)
                    byte[] md5byte = md.ComputeHash(sr);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < md5byte.Length; i++)
                    {
                        //x代表转化成16进制,x2代表生成的16进制保留两位
                        //如果为大写X,生成16进制也是大写
                        sb.Append(md5byte[i].ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
        }


        /// <summary>
        /// 为字符串生成MD5
        /// </summary>
        /// <param name="str">被转换的字符串</param>
        public static string GetMD5FromString(string str)
        {


            using (MD5 md = MD5.Create())
            {
                //MD5要用字节来生成,因此能够为任何文件生成MD5
                //不同编码生成的字节数组不同,因此输入汉字且编码不一致,可能造成生成的MD5不同
                byte[] bytes = Encoding.Default.GetBytes(str);
                //会生成16个字节,要把它们转化成16进制的一条字符串
                byte[] md5bytes = md.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < md5bytes.Length; i++)
                {
                    //x代表转化成16进制,x2代表生成的16进制保留两位
                    //如果为大写X,生成16进制也是大写
                    sb.Append(md5bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }

}
