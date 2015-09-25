namespace TreeView练习
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tBFilePath = new System.Windows.Forms.TextBox();
            this.btnInputFileAndDir = new System.Windows.Forms.Button();
            this.tbTXT = new System.Windows.Forms.TextBox();
            this.btnInputTxt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(28, 57);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(148, 250);
            this.treeView1.TabIndex = 0;
            // 
            // tBFilePath
            // 
            this.tBFilePath.Location = new System.Drawing.Point(28, 18);
            this.tBFilePath.Name = "tBFilePath";
            this.tBFilePath.Size = new System.Drawing.Size(355, 21);
            this.tBFilePath.TabIndex = 1;
            // 
            // btnInputFileAndDir
            // 
            this.btnInputFileAndDir.Location = new System.Drawing.Point(389, 18);
            this.btnInputFileAndDir.Name = "btnInputFileAndDir";
            this.btnInputFileAndDir.Size = new System.Drawing.Size(112, 21);
            this.btnInputFileAndDir.TabIndex = 2;
            this.btnInputFileAndDir.Text = "载入文件及文件夹";
            this.btnInputFileAndDir.UseVisualStyleBackColor = true;
            this.btnInputFileAndDir.Click += new System.EventHandler(this.btnInputFileAndDir_Click);
            // 
            // tbTXT
            // 
            this.tbTXT.Location = new System.Drawing.Point(246, 57);
            this.tbTXT.Multiline = true;
            this.tbTXT.Name = "tbTXT";
            this.tbTXT.Size = new System.Drawing.Size(445, 250);
            this.tbTXT.TabIndex = 3;
            // 
            // btnInputTxt
            // 
            this.btnInputTxt.Location = new System.Drawing.Point(507, 18);
            this.btnInputTxt.Name = "btnInputTxt";
            this.btnInputTxt.Size = new System.Drawing.Size(108, 21);
            this.btnInputTxt.TabIndex = 4;
            this.btnInputTxt.Text = "载入仅txt";
            this.btnInputTxt.UseVisualStyleBackColor = true;
            this.btnInputTxt.Click += new System.EventHandler(this.btnInputTxt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 347);
            this.Controls.Add(this.btnInputTxt);
            this.Controls.Add(this.tbTXT);
            this.Controls.Add(this.btnInputFileAndDir);
            this.Controls.Add(this.tBFilePath);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox tBFilePath;
        private System.Windows.Forms.Button btnInputFileAndDir;
        private System.Windows.Forms.TextBox tbTXT;
        private System.Windows.Forms.Button btnInputTxt;
    }
}

