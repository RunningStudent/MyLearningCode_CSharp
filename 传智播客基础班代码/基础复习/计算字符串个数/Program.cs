/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 7:17
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 计算字符串个数
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Console.WriteLine("输入一个字符串");
			string str;
			str=Console.ReadLine();
			Console.WriteLine("这个字符串一个有{0}个字符",str.Length);
			Console.ReadKey(true);
		}
	}
}