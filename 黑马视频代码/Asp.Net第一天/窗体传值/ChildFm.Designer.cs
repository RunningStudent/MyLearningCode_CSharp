namespace 窗体传值
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
            this.btnChildren = new System.Windows.Forms.Button();
            this.txtChildren = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnChildren
            // 
            this.btnChildren.Location = new System.Drawing.Point(63, 118);
            this.btnChildren.Name = "btnChildren";
            this.btnChildren.Size = new System.Drawing.Size(75, 23);
            this.btnChildren.TabIndex = 0;
            this.btnChildren.Text = "传递消息";
            this.btnChildren.UseVisualStyleBackColor = true;
            
            // 
            // txtChildren
            // 
            this.txtChildren.Location = new System.Drawing.Point(63, 73);
            this.txtChildren.Name = "txtChildren";
            this.txtChildren.Size = new System.Drawing.Size(151, 21);
            this.txtChildren.TabIndex = 1;
            // 
            // ChildFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.txtChildren);
            this.Controls.Add(this.btnChildren);
            this.Name = "ChildFm";
            this.Text = "ChildFm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChildren;
        private System.Windows.Forms.TextBox txtChildren;
    }
}