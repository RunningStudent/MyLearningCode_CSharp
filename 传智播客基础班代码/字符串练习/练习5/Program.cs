/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 18:40
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Text;
namespace 练习5
{
	class Program
	{
		public static void Main(string[] args)
		{
			//练习7：求员工工资文件中，员工的最高工资、最低工资、平均工资
			//张三,100
			//李四,200
			//王五,20
			//赵六,190
			//田七,980
			string []str=File.ReadAllLines(@"money.txt",Encoding.Default);
			int max=int.MinValue;
			int min=int.MaxValue;
			int sum=0;
			string [] newStr=null;
			for (int i = 0; i < str.Length; i++) {
				newStr=str[i].Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
				if (Convert.ToInt16(newStr[1])>max) {
					max=Convert.ToInt16(newStr[1]);
				}
				if(Convert.ToInt16(newStr[1])<min)
				{
					min=Convert.ToInt16(newStr[1]);
				}
				sum+=int.Parse(newStr[1]);
			}
			Console.WriteLine("{0} {1} {2}",max,min,sum);
			Console.ReadKey(true);
		}
	}
}