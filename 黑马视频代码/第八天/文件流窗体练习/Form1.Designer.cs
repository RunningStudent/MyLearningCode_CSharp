namespace 文件流窗体练习
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBAge = new System.Windows.Forms.TextBox();
            this.tBMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cBSex = new System.Windows.Forms.ComboBox();
            this.lBData = new System.Windows.Forms.ListBox();
            this.btnDataAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBSex);
            this.groupBox1.Controls.Add(this.tBMail);
            this.groupBox1.Controls.Add(this.tBAge);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tBName);
            this.groupBox1.Location = new System.Drawing.Point(36, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 288);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "个人信息";
            // 
            // tBName
            // 
            this.tBName.Location = new System.Drawing.Point(27, 45);
            this.tBName.Name = "tBName";
            this.tBName.Size = new System.Drawing.Size(100, 21);
            this.tBName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "年龄";
            // 
            // tBAge
            // 
            this.tBAge.Location = new System.Drawing.Point(27, 106);
            this.tBAge.Name = "tBAge";
            this.tBAge.Size = new System.Drawing.Size(98, 21);
            this.tBAge.TabIndex = 3;
            // 
            // tBMail
            // 
            this.tBMail.Location = new System.Drawing.Point(27, 230);
            this.tBMail.Name = "tBMail";
            this.tBMail.Size = new System.Drawing.Size(98, 21);
            this.tBMail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "性别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "邮箱";
            // 
            // cBSex
            // 
            this.cBSex.FormattingEnabled = true;
            this.cBSex.Items.AddRange(new object[] {
            "保密",
            "男",
            "女"});
            this.cBSex.Location = new System.Drawing.Point(27, 176);
            this.cBSex.Name = "cBSex";
            this.cBSex.Size = new System.Drawing.Size(98, 20);
            this.cBSex.TabIndex = 4;
            // 
            // lBData
            // 
            this.lBData.FormattingEnabled = true;
            this.lBData.ItemHeight = 12;
            this.lBData.Location = new System.Drawing.Point(250, 56);
            this.lBData.Name = "lBData";
            this.lBData.Size = new System.Drawing.Size(192, 268);
            this.lBData.TabIndex = 1;
            this.lBData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lBData_MouseDoubleClick);
            // 
            // btnDataAdd
            // 
            this.btnDataAdd.Location = new System.Drawing.Point(36, 341);
            this.btnDataAdd.Name = "btnDataAdd";
            this.btnDataAdd.Size = new System.Drawing.Size(70, 27);
            this.btnDataAdd.TabIndex = 2;
            this.btnDataAdd.Text = "添加数据";
            this.btnDataAdd.UseVisualStyleBackColor = true;
            this.btnDataAdd.Click += new System.EventHandler(this.btnDataAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(129, 343);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 24);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "数据保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 397);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDataAdd);
            this.Controls.Add(this.lBData);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tBMail;
        private System.Windows.Forms.TextBox tBAge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBName;
        private System.Windows.Forms.ComboBox cBSex;
        private System.Windows.Forms.ListBox lBData;
        private System.Windows.Forms.Button btnDataAdd;
        private System.Windows.Forms.Button btnSave;
    }
}

