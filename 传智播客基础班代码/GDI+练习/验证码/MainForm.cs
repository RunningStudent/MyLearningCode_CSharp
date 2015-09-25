/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 14:34
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace 验证码
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
		void PictureBox1Click(object sender, System.EventArgs e)
		{
			//随机数,这里用于生成随机数字和随机字体,颜色等
			Random r=new Random();
			//因为使每个数字的字体颜色不同,所以单个字符串代表一个数字而不是全部变成一串字符串
			string []str=new string[5];
			//个验证码赋值
			for (int i = 0; i < 5; i++) {
				str[i]=r.Next(0,10).ToString();
			}
			//绘图准备
			//记住Graphics是绘制者,绘制需要画布,之前都是用窗体当做画布,这次用一个图片当做画布
			//所以先创建一个图片
			Bitmap b=new Bitmap(150,50);
			Graphics g=Graphics.FromImage(b);
			//制作随机颜色,字体的验证码,并嵌入b
			string []fonts={"宋体","黑体","楷体","微软雅黑","隶书"};
			//color是枚举
			Color [] colors={Color.Red,Color.Yellow,Color.Green,Color.Blue,Color.Brown};
			for (int i = 0; i < 5; i++)
			{
				//需要坐标来放置验证码,为了显示上下摆动效果,纵坐标为随机,饿横坐标为固定增加
				Point p=new Point(i*30,r.Next(0,30));//测试
				//开始逐字绘制
				g.DrawString(str[i],new Font(fonts[r.Next(0,5)],15,FontStyle.Bold),new SolidBrush(colors[r.Next(0,5)]),p);
				//突然发现视频中是用一个string来保存验证码(用[]时记得tostring()),
				//我是一个数字一个字符串,这样似乎会浪费内存,
				//为了字体的随机数,不用Brush,而用它的派生类SolidBrush,这个类能用color初始化
			}
			Pen pen=new Pen(Color.Black,0.0001f);
			for (int  i = 0;  i < 10;  i++)
			{
				g.DrawLine(pen,new Point(0,r.Next(0,50)),new Point(150,r.Next(0,50)));
			}
			for (int i = 0; i < 100; i++) {
				b.SetPixel(r.Next(0,150),r.Next(0,50),Color.Black);
			}
			pictureBox1.Image=b;
		}
	}
}
