/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-1-31
 * 时间: 23:24
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 随机数
{
	class Program
	{
		public static void Main(string[] args)
		{
			/*3.	定义长度50的数组,随机给数组赋值,并可以让用户输入一个数字n,
			 * 按一行n个数输出数组  int[]  array = new int[50];
			 * Random r = new Random();  r.Next();*/
			Random r=new Random();
			int []a=new int[50];
			for (int i = 0; i < 50; i++) {
				a[i]=r.Next(1,10);
			}
			int n;
			Console.WriteLine("输入一个数字");
			n=Convert.ToInt16(Console.ReadLine());
			for (int i = 0; i < 50; i++) {
				for (int j = 0; j < n; j++,i++) {
					if(i>=50)
						break;
					Console.Write(a[i]);
					Console.Write(' ');
				}
				Console.WriteLine();
			}
			Console.ReadKey(true);
		}
	}
}