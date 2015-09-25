/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 18:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 练习2
{
	class Program
	{
		public static void Main(string[] args)
		{
			//课上练习2：接收用户输入的一句英文，将其中的单词以反序输出。      “I love you"→“i evol uoy"
			string str="I love you";
			string []s=str.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < s.Length; i++) {
				StrProess(ref s[i]);
			}
			str=String.Join(" ",s);
			Console.WriteLine(str);
			Console.ReadKey(true);
		}
		public static string StrProess(ref string str)
		{
			char []c=str.ToCharArray();
			Array.Reverse(c);
			str=new String(c);
			return str;
		}
			
	}
}