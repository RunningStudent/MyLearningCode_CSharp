/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 7:14
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 变量轮换2
{
	class Program
	{
		public static void Change(ref int n1,ref int n2)
		{
			n1+=n2;
			n2=n1-n2;
			n1-=n2;
		}
		public static void Main(string[] args)
		{
			int n1=10,n2=20;
			Change(ref n1,ref n2);
			Console.WriteLine("{0} {1}",n1,n2);
			Console.ReadKey(true);
		}
	}
}