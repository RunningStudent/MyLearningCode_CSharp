/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 20:32
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace 练习三
{
	class Program
	{
		public static void Main(string[] args)
		{
			//从一个整数的List<int>中取出最大数（找最大值）。
			List<int> n=new List<int>(){1,2,3,4,5,6,7,8};
			int max=n[0];
			foreach (var element in n) {
				if (element>max) {
					max=element;
				}
			}
			Console.WriteLine("The Max is {0}",max);
			Console.ReadKey(true);
		}
	}
}