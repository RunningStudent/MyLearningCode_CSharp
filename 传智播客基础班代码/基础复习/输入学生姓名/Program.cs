/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 10:42
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
namespace 输入学生姓名
{
	class Program
	{
		public static void Main(string[] args)
		{
			List<string> name=new List<string>();
			string str;
			
			while (true) {
				str=Console.ReadLine();
				str.ToLower();
				if(str=="quit")
					break;
				name.Add(str);
				
			}
			Console.WriteLine("你一共输入了{0}个学生的姓名",name.Count);
			Console.WriteLine("他们是:");
			foreach (var element in name) {
				Console.WriteLine(element );
			}
			Console.ReadKey(true);
		}
	}
}