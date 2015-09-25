/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 20:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace 练习二
{
	class Program
	{
		public static void Main(string[] args)
		{
			//练习1：将int数组中的奇数放到一个新的int数组中返回。
			int[] nums={1,2,3,4,5,6,7,8,9};
			nums=GetJi(nums);
			foreach (int e in nums) {
				Console.Write("{0} ",e);
			}
			Console.ReadKey(true);
		}
		public static int[] GetJi(int []a)
		{
			List<int> Ji=new List<int>();
			foreach (int e in a) {
				if (e%2!=0) {
					Ji.Add(e);
				}
			}
			return Ji.ToArray();
		}
	}
}