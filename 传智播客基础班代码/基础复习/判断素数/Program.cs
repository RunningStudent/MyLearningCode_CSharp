/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 7:30
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 判断素数
{
	class Program
	{
		public static bool Judge(int n)
		{
			int i;
			for (i = 2; 2 < n; i++) {
				if (n%i==0) {
					break;
				}
			}
			if (i>=n) {
				return true;
			}
			else
			{
				return false;
			}
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("输入一个素数");
			int n=Convert.ToInt16(Console.ReadLine());
			if (Judge(n)) {
				Console.WriteLine("这个数是素数");
			}
			else
			{
				Console.WriteLine("这个数不是素数");
			}
			Console.ReadKey(true);
		}
	}
}