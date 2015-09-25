/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 16:42
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 练习二
{
	abstract class Vehicle
	{
		public string brand { get; set; }
		public string color { get; set; }
		public abstract void Run();
		public Vehicle(string b,string color)
		{
			this.color=color;
			this.brand=b;
		}
	}
	class Truck:Vehicle
	{
		public double weight { get; set; }
		public override void Run()
		{
			Console.WriteLine("卡车在跑");
		}
		public void  PullGoods()
		{
			Console.WriteLine("卡车在拉货");
		}
		public Truck(string b,string c):base(b,c)
		{}
	}
	class Car:Vehicle
	{
		public override void Run()
		{
			Console.WriteLine("小车在跑");
		}
		public int passenger { get; set; }
		public void CarryPassenger()
		{
			Console.WriteLine("小车载了{0}个人",passenger);
		}
		public Car(string b,string c,int p):base(b,c)
		{
			this.passenger=p;
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			
			//作业：定义汽车类Vehicle属性（brand(品牌),color（颜色））方法run，
			//子类卡车(Truck) 属性weight载重  方法拉货，轿车 (Car) 
			//属性passenger载客数量  方法载客
			Car c=new Car("神州","红色",100);
			c.Run();
			c.CarryPassenger();
			Console.WriteLine("{0} {1} {2}",c.brand,c.color,c.passenger);
			Console.ReadKey(true);
		}
	}
}