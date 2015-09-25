/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015-2-1
 * 时间: 13:36
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace GDI_练习
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
			this.drawlBT = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// drawlBT
			// 
			this.drawlBT.Location = new System.Drawing.Point(275, 55);
			this.drawlBT.Name = "drawlBT";
			this.drawlBT.Size = new System.Drawing.Size(94, 41);
			this.drawlBT.TabIndex = 0;
			this.drawlBT.Text = "绘制线条";
			this.drawlBT.UseVisualStyleBackColor = true;
			this.drawlBT.Click += new System.EventHandler(this.DrawlBTClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(502, 572);
			this.Controls.Add(this.drawlBT);
			this.Name = "MainForm";
			this.Text = "GDI+练习";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFormPaint);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button drawlBT;
	}
}
