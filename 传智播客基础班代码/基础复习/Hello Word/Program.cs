/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 10:01
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Hello_Word
{
	class Program
	{
		public static void Main(string[] args)
		{
			string str="  hello      world,你  好 世界   !    ";
			str=str.Trim();
			string []strs=str.Split(new char []{' '},StringSplitOptions.RemoveEmptyEntries);
			str=string.Join(" ",strs);
			Console.WriteLine(str);
			Console.ReadKey(true);
		}
	}
}