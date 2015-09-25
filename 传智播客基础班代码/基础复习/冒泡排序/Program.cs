/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 9:41
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 冒泡排序
{
	class Program
	{
		public static void Main(string[] args)
		{
			int []a={ 1, 3, 5, 7, 90, 2, 4, 6, 8, 10 };
			int t;
			for (int i = 0; i < a.Length; i++) {
				for (int j = 0; j < a.Length-i-1; j++) {
					if (a[j+1]<a[j]) {
						t=a[j+1];
						a[j+1]=a[j];
						a[j]=t;
					}
				}
			}
			foreach (int element in a) {
				Console.Write("{0} ",element);
			}
			Console.ReadKey(true);
		}
	}
}