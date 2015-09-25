/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-1-31
 * 时间: 23:45
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 字符串练习
{
	class Program
	{
		
		public static string Change(string str)
		{
			string a=str.Substring(0,1);
			string b=str.Substring(1);
			a=a.ToLower();
			return a+b;
			
		}
		public static void Main(string[] args)
		{
			/*4.	编写一个函数,接收一个字符串,把用户输入的字符串中的第一个字母转换成小写然后返回(命名规范  骆驼命名)
			 *    name       s.SubString(0,1)      s.SubString(1);*
			*/
			Console.WriteLine("输入一个字符串");
			string str;
			str=Console.ReadLine();
			Console.WriteLine(Change(str));
			Console.ReadKey(true);
		}
	}
}