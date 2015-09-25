/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 20:42
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace 练习四
{
	class Program
	{
		public static void Main(string[] args)
		{
			//练习：把123转换为：壹贰叁。Dictionary<char,char>
			//“”
			Dictionary<char,char> d=new Dictionary<char, char>();
			string str="1一 2二 3三 4四 5五 6六 7七 8八 9九";
			string []strs=str.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < strs.Length; i++) {
				d.Add(strs[i][0],strs[i][1]);
			}
			Console.WriteLine("输入");
			string input=Console.ReadLine();
			for (int i = 0; i < input.Length; i++) {
				if (d.ContainsKey(input[i])) {
					Console.Write(d[input[i]]);
				}
				else
				{
					Console.Write(input[i]);
				}
			}
			Console.ReadKey(true);
		}
	}
}