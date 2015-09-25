/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-3
 * 时间: 16:25
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace 练习1
{
	class Father
	{
		public string  lastName { get; set; }
		public double property { get; set; }
		public string bloodType{get;set;}
		public Father(string laN,double pro,string blood)
		{
			this.lastName=laN;
			this.property=pro;
			this.bloodType=blood;
		}
	}
	class Son:Father
	{
		public Son(string name,double pro,string blood):base(name,pro,blood)
		{}
		public void PlayGame()
		{
			Console.WriteLine("Son is Playing Games");
		}
	}
	class Daughter:Father
	{
		public Daughter(string name,double pro,string blood):base(name,pro,blood)
		{}
		public void Dance()
		{
			Console.WriteLine("Daughter can dance");
		}
	}
	class Program
	{
		//作业：定义父亲类Father(姓lastName,财产property,血型bloodType),
		//儿子Son类(玩游戏PlayGame方法),女儿Daughter类(跳舞Dance方法)，
		//调用父类构造函数(:base())给子类字段赋值
		public static void Main(string[] args)
		{
			Son s=new Son("张三",100,"A");
			s.PlayGame();
			Console.WriteLine("{0} {1} {2}",s.lastName,s.property,s.bloodType);
			Console.ReadKey(true);
		}
	}
}