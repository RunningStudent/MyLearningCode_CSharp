/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 20:54
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace 练习五
{
	class Program
	{
		public static void Main(string[] args)
		{
			//练习：计算字符串中每种字符出现的次数（面试题）。 “Welcome to Chinaworld”，
			//不区分大小写，打印“W2”“e 2”“o 3”……
			//提示：Dictionary<char,int>,char的很多静态方法。char.IsLetter()
			string str="Welcome to Chinaworld";
			Dictionary<char,int>d=new Dictionary<char, int>();
			for (int i = 0; i < str.Length; i++) {
				if (str[i]==' ') {
					continue;
				}
				if (d.ContainsKey(str[i])) {
					d[str[i]]++;
				}
				else
				{
					d[str[i]]=1;
				}
			}
			foreach ( KeyValuePair<char,int>e in d) {
				Console.WriteLine("{0} {1}",e.Key,e.Value);
			}
			Console.ReadKey(true);
		}
	}
}