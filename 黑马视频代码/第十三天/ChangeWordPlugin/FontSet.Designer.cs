namespace ChangeWordPlugin
{
    partial class FontSet
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
            this.cBFont = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btSure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cBFont
            // 
            this.cBFont.FormattingEnabled = true;
            this.cBFont.Items.AddRange(new object[] {
            "宋体",
            "隶书",
            "黑体"});
            this.cBFont.Location = new System.Drawing.Point(141, 43);
            this.cBFont.Name = "cBFont";
            this.cBFont.Size = new System.Drawing.Size(92, 20);
            this.cBFont.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "字体";
            // 
            // cBSize
            // 
            this.cBSize.FormattingEnabled = true;
            this.cBSize.Items.AddRange(new object[] {
            "10",
            "20",
            "30"});
            this.cBSize.Location = new System.Drawing.Point(141, 98);
            this.cBSize.Name = "cBSize";
            this.cBSize.Size = new System.Drawing.Size(92, 20);
            this.cBSize.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "大小";
            // 
            // btSure
            // 
            this.btSure.Location = new System.Drawing.Point(154, 140);
            this.btSure.Name = "btSure";
            this.btSure.Size = new System.Drawing.Size(79, 26);
            this.btSure.TabIndex = 2;
            this.btSure.Text = "确定";
            this.btSure.UseVisualStyleBackColor = true;
            this.btSure.Click += new System.EventHandler(this.btSure_Click);
            // 
            // FontSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 194);
            this.Controls.Add(this.btSure);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cBSize);
            this.Controls.Add(this.cBFont);
            this.Name = "FontSet";
            this.Text = "FontSet";
            this.Load += new System.EventHandler(this.FontSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSure;
    }
}