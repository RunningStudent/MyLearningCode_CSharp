/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 0:22
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 变量轮换
{
	class Program
	{
		public static void Main(string[] args)
		{
			/*6.	声明两个变量：int n1 = 10, n2 = 20;要求将两个变量交换，最后输出n1为20,n2为10。
			 * 扩展（*）：不使用第三个变量如何交换？*/
			int n1=10,n2=20;
			n1+=n2;
			n2=n1-n2;
			n1-=n2;
			Console.WriteLine("{0} {1}",n1,n2);
			Console.ReadKey(true);
		}
	}
}