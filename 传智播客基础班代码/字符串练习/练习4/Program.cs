/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 18:37
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 练习4
{
	class Program
	{
		public static void Main(string[] args)
		{
			//练习5：123-456---789-----123-2把类似的字符串中重复符号去掉
			//，既得到123-456-789-123-2. split()、StringSplitOptions.RemoveEmptyEntries   Join()
			string str="123-456---789-----123-2";
			string []s=str.Split(new char[]{'-'},StringSplitOptions.RemoveEmptyEntries);
			str=string.Join("-",s);
			Console.WriteLine(str);
			Console.ReadKey(true);
		}
	}
}