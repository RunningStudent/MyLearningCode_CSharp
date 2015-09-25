/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 13:44
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 面向对象复习之简单工厂模式计算器
{
	abstract class  Calculate
	{
		public double number1 { get; set; }
		public double number2 { get; set; }
		public Calculate(double n1,double n2)
		{
			this.number1=n1;
			this.number2=n2;
		}
		public abstract double Count();
	}
	class Add:Calculate
	{
		public Add(double n1,double n2):base(n1,n2)
		{}
		public override double Count()
		{
			return number1+number2;
		}
	}
	class Sub:Calculate
	{
		public Sub(double n1,double n2):base(n1,n2)
		{}
		public override double Count()
		{
			return number1-number2;
		}
	}
	class Multiply:Calculate
	{
		public Multiply(double n1,double n2):base(n1,n2)
		{}
		public override double Count()
		{
			return number1*number2;
		}
	}
	class Divided:Calculate
	{
		public Divided(double n1,double n2):base(n1,n2)
		{}
		public override double Count()
		{
			return number1/number2;
		}
	}

	class Program
	{
		public static Calculate GetCalculate(string opt,double n1,double n2)
		{
			Calculate c=null;
			switch (opt) {
				case "+":
					c=new Add(n1,n2);
					break;
				case "-":
					c=new Sub(n1,n2);
					break;
				case "*":
					c=new Multiply(n1,n2);
					break;
				case "/":
					c=new Divided(n1,n2);
					break;
				default:
					Console.WriteLine("输入正确的运算符");
					opt=Console.ReadLine();
					c=GetCalculate(opt,n1,n2);
					break;
			}
			return c;
		}
		public static void Main(string[] args)
		{
			double n1,n2;
			string opt;
			Calculate c;
			while (true)
			{
				try 
				{
					
					Console.WriteLine("输入");
					n1=Convert.ToDouble(Console.ReadLine());
					n2=Convert.ToDouble(Console.ReadLine());
					opt=Console.ReadLine();
					c=GetCalculate(opt,n1,n2);
					Console.WriteLine(c.Count());
					
				}
				catch
				{
					Console.WriteLine("输入正确的数字");
				}
				
			}
			Console.ReadKey(true);
		}
	}
}