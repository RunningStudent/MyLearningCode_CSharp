namespace 大管家模式的窗体传值
{
    partial class ChildFm
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
            this.txtAccept = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtAccept
            // 
            this.txtAccept.Location = new System.Drawing.Point(71, 66);
            this.txtAccept.Name = "txtAccept";
            this.txtAccept.Size = new System.Drawing.Size(100, 21);
            this.txtAccept.TabIndex = 0;
            // 
            // ChildFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.txtAccept);
            this.Name = "ChildFm";
            this.Text = "ChildFm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccept;
    }
}