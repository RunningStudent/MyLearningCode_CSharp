namespace 用控件进行对数据库的增删改查
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
            this.cbBClass = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbBGender = new System.Windows.Forms.ComboBox();
            this.txttSCardId = new System.Windows.Forms.TextBox();
            this.txttSAge = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txttSPhone = new System.Windows.Forms.TextBox();
            this.txttSName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txttSAddress = new System.Windows.Forms.TextBox();
            this.txttSId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbBEditClass = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.cbBEditGender = new System.Windows.Forms.ComboBox();
            this.txtEditCardId = new System.Windows.Forms.TextBox();
            this.txtEditAge = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEditPhone = new System.Windows.Forms.TextBox();
            this.txtEditName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEditAddress = new System.Windows.Forms.TextBox();
            this.txtEditSid = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbBClass);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.cbBGender);
            this.groupBox1.Controls.Add(this.txttSCardId);
            this.groupBox1.Controls.Add(this.txttSAge);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txttSPhone);
            this.groupBox1.Controls.Add(this.txttSName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txttSAddress);
            this.groupBox1.Controls.Add(this.txttSId);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加";
            // 
            // cbBClass
            // 
            this.cbBClass.FormattingEnabled = true;
            this.cbBClass.Location = new System.Drawing.Point(496, 78);
            this.cbBClass.Name = "cbBClass";
            this.cbBClass.Size = new System.Drawing.Size(128, 20);
            this.cbBClass.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(495, 107);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(111, 26);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(511, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(118, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // cbBGender
            // 
            this.cbBGender.FormattingEnabled = true;
            this.cbBGender.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbBGender.Location = new System.Drawing.Point(79, 75);
            this.cbBGender.Name = "cbBGender";
            this.cbBGender.Size = new System.Drawing.Size(110, 20);
            this.cbBGender.TabIndex = 2;
            // 
            // txttSCardId
            // 
            this.txttSCardId.Location = new System.Drawing.Point(495, 48);
            this.txttSCardId.Name = "txttSCardId";
            this.txttSCardId.Size = new System.Drawing.Size(134, 21);
            this.txttSCardId.TabIndex = 1;
            // 
            // txttSAge
            // 
            this.txttSAge.Location = new System.Drawing.Point(287, 74);
            this.txttSAge.Name = "txttSAge";
            this.txttSAge.Size = new System.Drawing.Size(138, 21);
            this.txttSAge.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(441, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "tSClass";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "tSAge";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "tSGender";
            // 
            // txttSPhone
            // 
            this.txttSPhone.Location = new System.Drawing.Point(287, 47);
            this.txttSPhone.Name = "txttSPhone";
            this.txttSPhone.Size = new System.Drawing.Size(138, 21);
            this.txttSPhone.TabIndex = 1;
            // 
            // txttSName
            // 
            this.txttSName.Location = new System.Drawing.Point(67, 47);
            this.txttSName.Name = "txttSName";
            this.txttSName.Size = new System.Drawing.Size(122, 21);
            this.txttSName.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(441, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "tSCardId ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "tSPhone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "tSName";
            // 
            // txttSAddress
            // 
            this.txttSAddress.Location = new System.Drawing.Point(287, 20);
            this.txttSAddress.Name = "txttSAddress";
            this.txttSAddress.Size = new System.Drawing.Size(138, 21);
            this.txttSAddress.TabIndex = 1;
            // 
            // txttSId
            // 
            this.txttSId.Location = new System.Drawing.Point(67, 20);
            this.txttSId.Name = "txttSId";
            this.txttSId.ReadOnly = true;
            this.txttSId.Size = new System.Drawing.Size(122, 21);
            this.txttSId.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(441, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "tSBirthday";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "tSAddress";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "tSId";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 157);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(625, 186);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbBEditClass);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.cbBEditGender);
            this.groupBox2.Controls.Add(this.txtEditCardId);
            this.groupBox2.Controls.Add(this.txtEditAge);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtEditPhone);
            this.groupBox2.Controls.Add(this.txtEditName);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtEditAddress);
            this.groupBox2.Controls.Add(this.txtEditSid);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Location = new System.Drawing.Point(27, 361);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 139);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "修改";
            // 
            // cbBEditClass
            // 
            this.cbBEditClass.FormattingEnabled = true;
            this.cbBEditClass.Location = new System.Drawing.Point(496, 78);
            this.cbBEditClass.Name = "cbBEditClass";
            this.cbBEditClass.Size = new System.Drawing.Size(128, 20);
            this.cbBEditClass.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(511, 20);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(118, 21);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // cbBEditGender
            // 
            this.cbBEditGender.FormattingEnabled = true;
            this.cbBEditGender.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbBEditGender.Location = new System.Drawing.Point(79, 75);
            this.cbBEditGender.Name = "cbBEditGender";
            this.cbBEditGender.Size = new System.Drawing.Size(110, 20);
            this.cbBEditGender.TabIndex = 2;
            // 
            // txtEditCardId
            // 
            this.txtEditCardId.Location = new System.Drawing.Point(495, 48);
            this.txtEditCardId.Name = "txtEditCardId";
            this.txtEditCardId.Size = new System.Drawing.Size(134, 21);
            this.txtEditCardId.TabIndex = 1;
            // 
            // txtEditAge
            // 
            this.txtEditAge.Location = new System.Drawing.Point(287, 74);
            this.txtEditAge.Name = "txtEditAge";
            this.txtEditAge.Size = new System.Drawing.Size(138, 21);
            this.txtEditAge.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(441, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "tSClass";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(222, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "tSAge";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "tSGender";
            // 
            // txtEditPhone
            // 
            this.txtEditPhone.Location = new System.Drawing.Point(287, 47);
            this.txtEditPhone.Name = "txtEditPhone";
            this.txtEditPhone.Size = new System.Drawing.Size(138, 21);
            this.txtEditPhone.TabIndex = 1;
            // 
            // txtEditName
            // 
            this.txtEditName.Location = new System.Drawing.Point(67, 47);
            this.txtEditName.Name = "txtEditName";
            this.txtEditName.Size = new System.Drawing.Size(122, 21);
            this.txtEditName.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(441, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "tSCardId ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(222, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "tSPhone";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "tSName";
            // 
            // txtEditAddress
            // 
            this.txtEditAddress.Location = new System.Drawing.Point(287, 20);
            this.txtEditAddress.Name = "txtEditAddress";
            this.txtEditAddress.Size = new System.Drawing.Size(138, 21);
            this.txtEditAddress.TabIndex = 1;
            // 
            // txtEditSid
            // 
            this.txtEditSid.Location = new System.Drawing.Point(67, 20);
            this.txtEditSid.Name = "txtEditSid";
            this.txtEditSid.ReadOnly = true;
            this.txtEditSid.Size = new System.Drawing.Size(122, 21);
            this.txtEditSid.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(441, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "tSBirthday";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(222, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "tSAddress";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "tSId";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(402, 506);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 27);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 543);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txttSAge;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttSPhone;
        private System.Windows.Forms.TextBox txttSName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttSAddress;
        private System.Windows.Forms.TextBox txttSId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBGender;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txttSCardId;
        private System.Windows.Forms.ComboBox cbBClass;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbBEditClass;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox cbBEditGender;
        private System.Windows.Forms.TextBox txtEditCardId;
        private System.Windows.Forms.TextBox txtEditAge;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEditPhone;
        private System.Windows.Forms.TextBox txtEditName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtEditAddress;
        private System.Windows.Forms.TextBox txtEditSid;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnDelete;
    }
}

