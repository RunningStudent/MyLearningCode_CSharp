/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 20:21
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using System.Collections.Generic;
namespace 集合练习
{
	class Program
	{
		public static void Main(string[] args)
		{
			//案例：把分拣奇偶数的程序用泛型实现。int[] nums={1,2,3,4,5,6,7,8,9};奇数在左边 偶数在右边
			int[] nums={1,2,3,4,5,6,7,8,9};
			List<int> Ji=new List<int>();
			List<int> Ou=new List<int>();
			for(int i=0;i<nums.Length;i++)
			{
				if (nums[i]%2==0) {
					Ji.Add(nums[i]);
				}
				else
				{
					Ou.Add(nums[i]);
				}
			}
			Ji.AddRange(Ou);
			foreach (var element in Ji) {
				Console.Write("{0} ",element);
			}
			
			Console.ReadKey(true);
		}
	}
}