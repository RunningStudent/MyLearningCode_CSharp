/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 14:42
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 面向对象之模拟储存设备复习
{
	abstract class Storage
	{
		public abstract void Read();
		public abstract void Write();
	}
	class Mp3:Storage
	{
		public override void Write()
		{
			Console.WriteLine("Mp3在写入");
		}
		public override void Read()
		{
			Console.WriteLine("Mp3在读取");
		}
		public void PlayMusic()
		{
			Console.WriteLine("Mp3在放音乐");
		}
	}
	
	class Upan:Storage
	{
		public override void Read()
		{
			Console.WriteLine("U盘在读取");
		}
		public override void Write()
		{
			Console.WriteLine("U盘在写入");
		}
	}
	
	class CPU
	{
		public Storage sto 
		{set;get; }
		public CPU(Storage s)
		{
			this.sto=s;
		}
		public void UseStorage()
		{
			this.sto.Read();
			this.sto.Write();
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			Mp3 m=new Mp3();
			CPU c=new CPU(m);
			c.UseStorage();
			Console.ReadKey();
		}
		
	}
}