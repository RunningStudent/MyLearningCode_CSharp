/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-4
 * 时间: 10:48
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Text;
namespace 文件流练习
{
	class Program
	{
		public static void Main(string[] args)
		{
			string []str=File.ReadAllLines("工资.txt",Encoding.Default);
			string []newstr;
			for (int i = 0; i < str.Length; i++)
			{
				newstr=str[i].Split(new char[]{'|'},StringSplitOptions.RemoveEmptyEntries);
				str[i]=newstr[0]+(int.Parse(newstr[1])*2).ToString();
			}
			for (int i = 0; i < str.Length; i++) {
				File.WriteAllLines("新工资.txt",str,Encoding.Default);
			}
//			for (int i = 0; i < str.Length; i++) {
//				newstr=str[i].Split(new char[]{'|'},StringSplitOptions.RemoveEmptyEntries);
//				File.AppendAllText("新工资.txt",newstr[0]+"|"+(int.Parse(newstr[1])*2).ToString(),Encoding.Default);
//			}
			
			
			Console.ReadKey(true);
		}
	}
}