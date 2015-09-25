/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-4
 * 时间: 14:24
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Text;
namespace FileStream练习
{
	class Program
	{
		public static void Main(string[] args)
		{
			using (FileStream infile=new FileStream("工资.txt",FileMode.OpenOrCreate,FileAccess.Read) )
			{
				byte []bt=new byte[1024*1024];
				int count=infile.Read(bt,0,bt.Length);
				string str=Encoding.Default.GetString(bt,0,count);
				Console.WriteLine(str);
			}
			Console.ReadKey(true);
		}
	}
}