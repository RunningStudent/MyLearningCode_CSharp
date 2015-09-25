/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 7:57
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 计算平均值
{
	class Program
	{
		public static void Main(string[] args)
		{
			int []n={1, 3, 5, 7, 93, 33, 4, 4, 6, 8, 10};
			double sum=0.0;
			
			avg(n, ref sum);
			Console.WriteLine("{0:0.00}",sum);
			Console.ReadKey(true);
		}

		static void   avg(int[] n, ref double sum)
		{
			for (int i = 0; i < n.Length; i++) {
				sum += n[i];
			}
			  sum = sum / n.Length * 1.0;
		}
	}
}