/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 11:08
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace 窗体复习之简易计算器
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
		
		void MainFormLoad(object sender, EventArgs e)
		{
			countLB.SelectedIndex=0;
		}
		
		void CountBTClick(object sender, EventArgs e)
		{
			try
			{
				double a=Convert.ToInt16(num1TB.Text.Trim());
				double b=Convert.ToInt16(num2TB.Text.Trim());
				
				string czf=countLB.SelectedItem.ToString();
				switch (czf) {
					case "+":
						ansLb.Text=(a+b).ToString();
						break;
					case "-":
						ansLb.Text=(a-b).ToString();
						break;
					case "*":
						ansLb.Text=(a*b).ToString();
						break;
					case "/":
						ansLb.Text=(a/b).ToString();
						break;
					default:
						MessageBox.Show("请选择操作符");
						break;
				}
			}
			catch
			{
				MessageBox.Show("输入正确的数字");
			}
		}
	}
}
