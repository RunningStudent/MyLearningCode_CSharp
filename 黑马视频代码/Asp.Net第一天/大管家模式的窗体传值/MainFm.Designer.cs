namespace 大管家模式的窗体传值
{
    partial class MainFm
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
            this.btnShowParentAndSonFm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowParentAndSonFm
            // 
            this.btnShowParentAndSonFm.Location = new System.Drawing.Point(97, 124);
            this.btnShowParentAndSonFm.Name = "btnShowParentAndSonFm";
            this.btnShowParentAndSonFm.Size = new System.Drawing.Size(297, 23);
            this.btnShowParentAndSonFm.TabIndex = 0;
            this.btnShowParentAndSonFm.Text = "出来吧父窗体与子窗体";
            this.btnShowParentAndSonFm.UseVisualStyleBackColor = true;
            this.btnShowParentAndSonFm.Click += new System.EventHandler(this.btnShowParentAndSonFm_Click);
            // 
            // MainFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 192);
            this.Controls.Add(this.btnShowParentAndSonFm);
            this.Name = "MainFm";
            this.Text = "MainFm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowParentAndSonFm;
    }
}