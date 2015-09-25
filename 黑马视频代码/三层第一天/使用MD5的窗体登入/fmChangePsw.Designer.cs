namespace 使用MD5的窗体登入
{
    partial class fmChangePsw
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnChange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOldPsw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPsw = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComfirmPsw = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(131, 206);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 0;
            this.btnChange.Text = "确认修改";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "旧密码";
            // 
            // txtOldPsw
            // 
            this.txtOldPsw.Location = new System.Drawing.Point(106, 59);
            this.txtOldPsw.Name = "txtOldPsw";
            this.txtOldPsw.Size = new System.Drawing.Size(100, 21);
            this.txtOldPsw.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "新密码";
            // 
            // txtNewPsw
            // 
            this.txtNewPsw.Location = new System.Drawing.Point(106, 102);
            this.txtNewPsw.Name = "txtNewPsw";
            this.txtNewPsw.Size = new System.Drawing.Size(100, 21);
            this.txtNewPsw.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "确认密码";
            // 
            // txtComfirmPsw
            // 
            this.txtComfirmPsw.Location = new System.Drawing.Point(106, 143);
            this.txtComfirmPsw.Name = "txtComfirmPsw";
            this.txtComfirmPsw.Size = new System.Drawing.Size(100, 21);
            this.txtComfirmPsw.TabIndex = 2;
            // 
            // fmChangePsw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 278);
            this.Controls.Add(this.txtComfirmPsw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNewPsw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOldPsw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChange);
            this.Name = "fmChangePsw";
            this.Text = "fmChangePsw";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOldPsw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPsw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComfirmPsw;
    }
}