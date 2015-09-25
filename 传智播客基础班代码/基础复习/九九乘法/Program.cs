/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-1-31
 * 时间: 23:19
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 九九乘法
{
	class Program
	{
		public static void Main(string[] args)
		{
			for (int i = 1; i < 10; i++) {
				for (int j = 1; j <=i; j++) {
					Console.Write("{0}*{1}={2} ",i,j,i*j);
				}
				Console.WriteLine();
			}
			Console.ReadKey();
		}
	}
}