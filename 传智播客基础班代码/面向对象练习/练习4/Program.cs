/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 17:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 练习4
{
	abstract class Shape
	{
		public abstract double CountFace();
		public abstract double CountGirth();
	}
	
	class Circle:Shape
	{
		public double rids { get; set; }
		public Circle(double r)
		{
			this.rids=r;
		}
		public override double CountFace()
		{
			return Math.PI*rids*rids;
		}
		public override double CountGirth()
		{
			return Math.PI*rids*2;
		}
	}	
	class Square:Shape
	{
		public double sideLong { get; set; }
		public double sideShort { get; set; }
		public Square(double sl,double ss)
		{
			this.sideLong=sl;
			this.sideShort=ss;
		}
		public override double CountFace()
		{
			return 1.0*sideLong*sideShort;
		}
		public override double CountGirth()
		{
			return (sideLong+sideShort)*2.0;
		}
	}
	class Rectangle:Shape
	{
		public double side { get; set; }
		public Rectangle(double s)
		{
			this.side=s;
		}
		public override double CountFace()
		{
			return side*side;
		}
		public override double CountGirth()
		{
			return side*4;
		}
	}
	
	class Program
	{
		public static void Main(string[] args)
		{
			//作业：计算形状Shape(圆Circle，矩形Square ，正方形Rectangle)的面积、周长
			
			Shape s=new Circle(2);
			Console.WriteLine("圆形面积为{0},周长为{1}",s.CountFace(),s.CountGirth());
			s=new Square(2,4);
			Console.WriteLine("矩形面积为{0},周长为{1}",s.CountFace(),s.CountGirth());
			s=new Rectangle(3);
			Console.WriteLine("正方形面积为{0},周长为{1}",s.CountFace(),s.CountGirth());
			Console.ReadKey(true);
		}
	}
}