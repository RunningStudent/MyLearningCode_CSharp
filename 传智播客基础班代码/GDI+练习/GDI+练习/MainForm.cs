/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 13:36
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GDI_练习
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
		
		void DrawlBTClick(object sender, EventArgs e)
		{
			Graphics g=this.CreateGraphics();
			Pen p=new Pen(Brushes.Red);
			Point star=new Point(100,200);
			Point end=new Point(300,500);
			g.DrawLine(p,star,end);
		}
		
		void MainFormPaint(object sender, PaintEventArgs e)
		{
			Graphics g=this.CreateGraphics();
			Pen p=new Pen(Brushes.Red);
			Point star=new Point(100,200);
			Point end=new Point(300,500);
			g.DrawLine(p,star,end);
		}
	}
}
