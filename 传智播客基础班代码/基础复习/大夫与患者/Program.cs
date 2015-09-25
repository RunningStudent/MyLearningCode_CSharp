/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 9:48
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 大夫与患者
{
	class Program
	{
		public static void Main(string[] args)
		{
			string str="患者：“大夫，我咳嗽得很重。”     大夫：“你多大年记？”     " +
				"患者：“七十五岁。”     大夫：“二十岁咳嗽吗”患者：“不咳嗽。”     " +
				"大夫：“四十岁时咳嗽吗？”     患者：“也不咳嗽。”     " +
				"大夫：“那现在不咳嗽，还要等到什么时咳嗽？”";
			int i=1,t=1;
			while (true) {
				t=str.IndexOf("咳嗽",t);
				if (t==-1) {
					break;
				}
				Console.Write("{0} ",t);
				t++;
				
			}
			Console.ReadKey(true);
		}
	}
}