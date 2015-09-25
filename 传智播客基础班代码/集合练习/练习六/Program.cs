/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 22:04
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace 练习六
{
	static class A
	{
		static  A()
		{}
	}
	struct Aa
	{
		int a;
		int b;
		Aa()
		{
			a=0;
			b=1;
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			//案例：两个（ArrayList）集合{ “a”,“b”,“c”,“d”,“e”}和
			//{ “d”, “e”, “f”, “g”, “h” }，把这两个集合去除重复项合并成一个。
			List<string>A=new List<string>(){"a","b","c","d","e"};
			List<string>B=new List<string>(){"d","e","f","g","h"};
			for (int i = 0; i < B.Count; i++) {
				if (!A.Contains(B[i])) {
					A.Add(B[i]);
				}
			}
			foreach (var e in A) {
				Console.Write("{0} ",e);
			}
			Console.ReadKey(true);
		}
	}
}