/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 9:45
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 教师成绩
{
	class Program
	{
		public static void Main(string[] args)
		{
			int []stu=new int[50];
			Random r=new Random();
			for(int i=0;i<50;i++)
			{
				stu[i]=r.Next(1,101);
			}
			foreach(int ele in stu)
			{
				Console.Write("{0} ",ele);
			}
			Console.ReadKey(true);
		}
	}
}