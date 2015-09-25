/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 7:27
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 计算整数和1_100
{
	class Program
	{
		public static void Main(string[] args)
		{
			int sum=0;
			CountSum(ref sum);
			Console.WriteLine("1到100的和为"+sum);
			Console.ReadKey(true);
		}

		static void CountSum(ref int sum)
		{
			for (int i = 1; i < 101; i++) {
				sum += i;
			}
		}
	}
}