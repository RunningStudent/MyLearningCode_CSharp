/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 13:57
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GDI_简易图形绘制
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, System.EventArgs e)
		{
			//矩形绘制
			Graphics g=this.CreateGraphics();
			Pen p=new Pen(Brushes.Red);
			Rectangle r=new Rectangle(new Point(50,50),new Size(100,100));
			g.DrawRectangle(p,r);
		}
		void Button2Click(object sender, System.EventArgs e)
		{
			//扇形绘制
			Graphics g=this.CreateGraphics();
			Pen p=new Pen(Brushes.Green);
			Rectangle r=new Rectangle(new Point(50,50),new Size(100,100));
			g.DrawPie(p,r,60,60);
		}
		void Button3Click(object sender, System.EventArgs e)
		{
			//文本绘制
			Graphics g=this.CreateGraphics();
			g.DrawString("我是天才",new Font(new FontFamily("宋体"),20,FontStyle.Underline),Brushes.Yellow,new Point(20,20));
		}
	}
}
