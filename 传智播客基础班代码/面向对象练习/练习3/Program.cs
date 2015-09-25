/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 17:01
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 练习3
{
	abstract class Animal
	{
		public abstract void Eat();
		public abstract void Bark();
	}
	class Dog:Animal
	{
		public override void Bark()
		{
			Console.WriteLine("狗在叫");
		}
		public override void Eat()
		{
			Console.WriteLine("狗在吃东西");
		}
	}
	class Cat:Animal
	{
		public override void Eat()
		{
			Console.WriteLine("猫吃东西");
		}
		public override void Bark()
		{
			Console.WriteLine("猫在叫");
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			//作业:动物Animal   都有吃Eat和叫Bark的方法，狗Dog和猫Cat叫的方法不一样.
			//父类中没有默认的实现所哟考虑用抽象方法。

			Animal a=new Cat();
			a.Bark();
			a.Eat();
			a=new Dog();
			a.Bark();
			a.Eat();
			Console.ReadKey(true);
		}
	}
}