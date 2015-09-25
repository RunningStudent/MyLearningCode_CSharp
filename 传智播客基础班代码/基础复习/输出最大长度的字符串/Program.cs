/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 7:46
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 输出最大长度的字符串
{
	class Program
	{
		public static void Main(string[] args)
		{
			string []str={"马龙", "迈克尔乔丹", "雷吉米勒", "蒂姆邓肯", "科比布莱恩特"};
			string maxstr=str[0];
			int t=maxstr.Length;
			for (int i = 1; i < str.Length; i++) {
				if (str[i].Length>t) {
					maxstr=str[i];
					t=maxstr.Length;
				}
			}
			Console.WriteLine("最长的字符串为{0}",maxstr);
			Console.ReadKey(true);
		}
	}
}