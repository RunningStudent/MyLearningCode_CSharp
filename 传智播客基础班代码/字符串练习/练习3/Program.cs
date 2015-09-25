/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 18:34
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 练习3
{
	class Program
	{
		public static void Main(string[] args)
		{
			//课上练习3：””从日期字符串中把年月日分别取出来，打印到控制台
			string str="2012年12月21日";
			string []s=str.Split(new char[]{'年','月','日'});
			Console.Write("{0} {1} {2}",s[0],s[1],s[2]);
			Console.ReadKey(true);
		}
	}
}