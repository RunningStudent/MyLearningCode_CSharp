namespace 线程_摇奖机
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRoll = new System.Windows.Forms.Button();
            this.lbRoll1 = new System.Windows.Forms.Label();
            this.lbRoll2 = new System.Windows.Forms.Label();
            this.lbRoll3 = new System.Windows.Forms.Label();
            this.lbRoll4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(154, 189);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(75, 23);
            this.btnRoll.TabIndex = 0;
            this.btnRoll.Text = "摇";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // lbRoll1
            // 
            this.lbRoll1.AutoSize = true;
            this.lbRoll1.Location = new System.Drawing.Point(37, 73);
            this.lbRoll1.Name = "lbRoll1";
            this.lbRoll1.Size = new System.Drawing.Size(59, 12);
            this.lbRoll1.TabIndex = 1;
            this.lbRoll1.Text = "摇啊~~~~~";
            // 
            // lbRoll2
            // 
            this.lbRoll2.AutoSize = true;
            this.lbRoll2.Location = new System.Drawing.Point(107, 73);
            this.lbRoll2.Name = "lbRoll2";
            this.lbRoll2.Size = new System.Drawing.Size(59, 12);
            this.lbRoll2.TabIndex = 1;
            this.lbRoll2.Text = "摇啊~~~~~";
            // 
            // lbRoll3
            // 
            this.lbRoll3.AutoSize = true;
            this.lbRoll3.Location = new System.Drawing.Point(196, 73);
            this.lbRoll3.Name = "lbRoll3";
            this.lbRoll3.Size = new System.Drawing.Size(59, 12);
            this.lbRoll3.TabIndex = 1;
            this.lbRoll3.Text = "摇啊~~~~~";
            // 
            // lbRoll4
            // 
            this.lbRoll4.AutoSize = true;
            this.lbRoll4.Location = new System.Drawing.Point(289, 73);
            this.lbRoll4.Name = "lbRoll4";
            this.lbRoll4.Size = new System.Drawing.Size(59, 12);
            this.lbRoll4.TabIndex = 1;
            this.lbRoll4.Text = "摇啊~~~~~";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 273);
            this.Controls.Add(this.lbRoll4);
            this.Controls.Add(this.lbRoll3);
            this.Controls.Add(this.lbRoll2);
            this.Controls.Add(this.lbRoll1);
            this.Controls.Add(this.btnRoll);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Label lbRoll1;
        private System.Windows.Forms.Label lbRoll2;
        private System.Windows.Forms.Label lbRoll3;
        private System.Windows.Forms.Label lbRoll4;
    }
}

