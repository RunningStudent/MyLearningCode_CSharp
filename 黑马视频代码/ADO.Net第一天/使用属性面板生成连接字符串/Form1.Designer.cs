namespace 使用属性面板生成连接字符串
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.btnCreateSB = new System.Windows.Forms.Button();
            this.btnShowSB = new System.Windows.Forms.Button();
            this.txtSB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(12, 12);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(261, 401);
            this.propertyGrid1.TabIndex = 0;
            // 
            // btnCreateSB
            // 
            this.btnCreateSB.Location = new System.Drawing.Point(12, 419);
            this.btnCreateSB.Name = "btnCreateSB";
            this.btnCreateSB.Size = new System.Drawing.Size(100, 28);
            this.btnCreateSB.TabIndex = 1;
            this.btnCreateSB.Text = "创建连接字符串";
            this.btnCreateSB.UseVisualStyleBackColor = true;
            this.btnCreateSB.Click += new System.EventHandler(this.btnCreateSB_Click);
            // 
            // btnShowSB
            // 
            this.btnShowSB.Location = new System.Drawing.Point(173, 419);
            this.btnShowSB.Name = "btnShowSB";
            this.btnShowSB.Size = new System.Drawing.Size(100, 27);
            this.btnShowSB.TabIndex = 2;
            this.btnShowSB.Text = "显示连接字符串";
            this.btnShowSB.UseVisualStyleBackColor = true;
            this.btnShowSB.Click += new System.EventHandler(this.btnShowSB_Click);
            // 
            // txtSB
            // 
            this.txtSB.Location = new System.Drawing.Point(16, 468);
            this.txtSB.Name = "txtSB";
            this.txtSB.Size = new System.Drawing.Size(256, 21);
            this.txtSB.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 508);
            this.Controls.Add(this.txtSB);
            this.Controls.Add(this.btnShowSB);
            this.Controls.Add(this.btnCreateSB);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnCreateSB;
        private System.Windows.Forms.Button btnShowSB;
        private System.Windows.Forms.TextBox txtSB;
    }
}

