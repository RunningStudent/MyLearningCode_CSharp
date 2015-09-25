/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-1-31
 * 时间: 23:01
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 基础复习
{
	class Program
	{
		public static string Jude(int s)
		{
			s/=10;
			switch (s) {
				case 9:
					return "优秀";
				case 8:
					return "良";
				case 6:
					return "中";
				default:
					return "差";
			}
		}
		public static void Main(string[] args)
		{
		 /*1.	编写一段程序，运行时向用户提问“你考了多少分？（0~100）”，
		 * 接受输入后判断其等级并显示出来。判断依据如下：等级={优 （90~100分）；
		* 良 （80~89分）；中 （60~69分）；差 （0~59分）；}*/
		int score;
		Console.WriteLine("请输入您的成绩");
		score=Convert.ToInt16(Console.ReadLine());
		Console.WriteLine(Jude(score));
		Console.ReadKey();
		}
	}
}