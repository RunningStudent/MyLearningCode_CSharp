/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 7:19
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 计算最大值
{
	class Program
	{
		public static int FindMax(params int []a)
		{
			int max=a[0];
			for(int i=1;i<a.Length;i++)
			{
				if (max<a[i]) {
					max=a[i];
				}
			}
			return max;
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("输入你要几个数字");
			int n;
			n=Convert.ToInt16((Console.ReadLine()));
			int []a=new int[n];
			for(int i=0;i<n;i++)
			{
				a[i]=Convert.ToInt16(Console.ReadLine());
			}
			int max=FindMax(a);
			Console.WriteLine("这个几个数字中最大值为"+max);
			Console.ReadKey(true);
		}
	}
}