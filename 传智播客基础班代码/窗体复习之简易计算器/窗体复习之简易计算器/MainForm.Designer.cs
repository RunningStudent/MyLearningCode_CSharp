/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 11:08
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace 窗体复习之简易计算器
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.num1TB = new System.Windows.Forms.TextBox();
			this.countLB = new System.Windows.Forms.ComboBox();
			this.num2TB = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ansLb = new System.Windows.Forms.Label();
			this.countBT = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// num1TB
			// 
			this.num1TB.Location = new System.Drawing.Point(47, 69);
			this.num1TB.Name = "num1TB";
			this.num1TB.Size = new System.Drawing.Size(62, 21);
			this.num1TB.TabIndex = 0;
			// 
			// countLB
			// 
			this.countLB.FormattingEnabled = true;
			this.countLB.Items.AddRange(new object[] {
									"请选择操作符",
									"+",
									"-",
									"*",
									"/"});
			this.countLB.Location = new System.Drawing.Point(115, 70);
			this.countLB.Name = "countLB";
			this.countLB.Size = new System.Drawing.Size(96, 20);
			this.countLB.TabIndex = 1;
			// 
			// num2TB
			// 
			this.num2TB.Location = new System.Drawing.Point(217, 70);
			this.num2TB.Name = "num2TB";
			this.num2TB.Size = new System.Drawing.Size(57, 21);
			this.num2TB.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(280, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 14);
			this.label1.TabIndex = 3;
			this.label1.Text = "=";
			// 
			// ansLb
			// 
			this.ansLb.Location = new System.Drawing.Point(315, 72);
			this.ansLb.Name = "ansLb";
			this.ansLb.Size = new System.Drawing.Size(48, 23);
			this.ansLb.TabIndex = 4;
			// 
			// countBT
			// 
			this.countBT.Location = new System.Drawing.Point(307, 114);
			this.countBT.Name = "countBT";
			this.countBT.Size = new System.Drawing.Size(56, 28);
			this.countBT.TabIndex = 5;
			this.countBT.Text = "计算";
			this.countBT.UseVisualStyleBackColor = true;
			this.countBT.Click += new System.EventHandler(this.CountBTClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(391, 319);
			this.Controls.Add(this.countBT);
			this.Controls.Add(this.ansLb);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.num2TB);
			this.Controls.Add(this.countLB);
			this.Controls.Add(this.num1TB);
			this.Name = "MainForm";
			this.Text = "窗体复习之简易计算器";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button countBT;
		private System.Windows.Forms.Label ansLb;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox num2TB;
		private System.Windows.Forms.ComboBox countLB;
		private System.Windows.Forms.TextBox num1TB;
	}
}
