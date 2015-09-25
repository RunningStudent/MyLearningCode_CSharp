/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 7:36
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 计算素数和1_100
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
		public static int CountSum(int n)
		{
			int sum=0;
			for (int i = 1; i < n+1; i++) {
				if(Judge(i))
				{
					sum+=i;
				}
			}
			return sum;
		}
		public static void Main(string[] args)
		{
			int n;
			Console.WriteLine("输入一个数");
			n=Convert.ToInt16(Console.ReadLine());
			int sum=CountSum(n);
			Console.WriteLine("素数和为{0}",sum);
			Console.ReadKey(true);
		}
	}
}