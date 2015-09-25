namespace 播放器
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Media = new AxWMPLib.AxWindowsMediaPlayer();
            this.platBt = new System.Windows.Forms.Button();
            this.pauseBt = new System.Windows.Forms.Button();
            this.stopBt = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.playBt = new System.Windows.Forms.Button();
            this.stopB = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.musiclB = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.volumeUp = new System.Windows.Forms.Button();
            this.volumeDown = new System.Windows.Forms.Button();
            this.musicInforLB = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lrcLb = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Media)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Media
            // 
            this.Media.Enabled = true;
            this.Media.Location = new System.Drawing.Point(12, 12);
            this.Media.Name = "Media";
            this.Media.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Media.OcxState")));
            this.Media.Size = new System.Drawing.Size(320, 117);
            this.Media.TabIndex = 0;
            // 
            // platBt
            // 
            this.platBt.Location = new System.Drawing.Point(6, 21);
            this.platBt.Name = "platBt";
            this.platBt.Size = new System.Drawing.Size(75, 23);
            this.platBt.TabIndex = 1;
            this.platBt.Text = "播放";
            this.platBt.UseVisualStyleBackColor = true;
            this.platBt.Click += new System.EventHandler(this.button1_Click);
            // 
            // pauseBt
            // 
            this.pauseBt.Location = new System.Drawing.Point(6, 61);
            this.pauseBt.Name = "pauseBt";
            this.pauseBt.Size = new System.Drawing.Size(75, 23);
            this.pauseBt.TabIndex = 2;
            this.pauseBt.Text = "暂停";
            this.pauseBt.UseVisualStyleBackColor = true;
            this.pauseBt.Click += new System.EventHandler(this.pauseBt_Click);
            // 
            // stopBt
            // 
            this.stopBt.Location = new System.Drawing.Point(6, 90);
            this.stopBt.Name = "stopBt";
            this.stopBt.Size = new System.Drawing.Size(75, 23);
            this.stopBt.TabIndex = 3;
            this.stopBt.Text = "停止";
            this.stopBt.UseVisualStyleBackColor = true;
            this.stopBt.Click += new System.EventHandler(this.stopBt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stopBt);
            this.groupBox1.Controls.Add(this.pauseBt);
            this.groupBox1.Controls.Add(this.platBt);
            this.groupBox1.Location = new System.Drawing.Point(422, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(91, 128);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // playBt
            // 
            this.playBt.Location = new System.Drawing.Point(25, 151);
            this.playBt.Name = "playBt";
            this.playBt.Size = new System.Drawing.Size(51, 31);
            this.playBt.TabIndex = 5;
            this.playBt.Text = "播放";
            this.playBt.UseVisualStyleBackColor = true;
            this.playBt.Click += new System.EventHandler(this.playBt_Click_1);
            // 
            // stopB
            // 
            this.stopB.Location = new System.Drawing.Point(91, 151);
            this.stopB.Name = "stopB";
            this.stopB.Size = new System.Drawing.Size(59, 31);
            this.stopB.TabIndex = 6;
            this.stopB.Text = "停止";
            this.stopB.UseVisualStyleBackColor = true;
            this.stopB.Click += new System.EventHandler(this.stopB_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(156, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 31);
            this.button3.TabIndex = 7;
            this.button3.Text = "打开";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // musiclB
            // 
            this.musiclB.ContextMenuStrip = this.contextMenuStrip1;
            this.musiclB.FormattingEnabled = true;
            this.musiclB.ItemHeight = 12;
            this.musiclB.Location = new System.Drawing.Point(25, 204);
            this.musiclB.Name = "musiclB";
            this.musiclB.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.musiclB.Size = new System.Drawing.Size(193, 148);
            this.musiclB.TabIndex = 8;
            this.musiclB.DoubleClick += new System.EventHandler(this.musiclB_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(227, 204);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(63, 35);
            this.button4.TabIndex = 9;
            this.button4.Text = "上一曲";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(227, 245);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(62, 36);
            this.button5.TabIndex = 10;
            this.button5.Text = "下一曲";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.Image = global::播放器.Properties.Resources.静音;
            this.label1.Location = new System.Drawing.Point(285, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 44);
            this.label1.TabIndex = 12;
            this.label1.Tag = "静音";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // volumeUp
            // 
            this.volumeUp.Location = new System.Drawing.Point(227, 154);
            this.volumeUp.Name = "volumeUp";
            this.volumeUp.Size = new System.Drawing.Size(25, 27);
            this.volumeUp.TabIndex = 13;
            this.volumeUp.Text = "+";
            this.volumeUp.UseVisualStyleBackColor = true;
            this.volumeUp.Click += new System.EventHandler(this.volumeUp_Click);
            // 
            // volumeDown
            // 
            this.volumeDown.Location = new System.Drawing.Point(263, 154);
            this.volumeDown.Name = "volumeDown";
            this.volumeDown.Size = new System.Drawing.Size(26, 27);
            this.volumeDown.TabIndex = 14;
            this.volumeDown.Text = "-";
            this.volumeDown.UseVisualStyleBackColor = true;
            this.volumeDown.Click += new System.EventHandler(this.volumeDown_Click);
            // 
            // musicInforLB
            // 
            this.musicInforLB.Location = new System.Drawing.Point(227, 284);
            this.musicInforLB.Name = "musicInforLB";
            this.musicInforLB.Size = new System.Drawing.Size(105, 77);
            this.musicInforLB.TabIndex = 15;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lrcLb
            // 
            this.lrcLb.Location = new System.Drawing.Point(361, 204);
            this.lrcLb.Name = "lrcLb";
            this.lrcLb.Size = new System.Drawing.Size(142, 48);
            this.lrcLb.TabIndex = 16;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 370);
            this.Controls.Add(this.lrcLb);
            this.Controls.Add(this.musicInforLB);
            this.Controls.Add(this.volumeDown);
            this.Controls.Add(this.volumeUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.musiclB);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.stopB);
            this.Controls.Add(this.playBt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Media);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Media)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer Media;
        private System.Windows.Forms.Button platBt;
        private System.Windows.Forms.Button pauseBt;
        private System.Windows.Forms.Button stopBt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button playBt;
        private System.Windows.Forms.Button stopB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox musiclB;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button volumeUp;
        private System.Windows.Forms.Button volumeDown;
        private System.Windows.Forms.Label musicInforLB;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lrcLb;
        private System.Windows.Forms.Timer timer2;
    }
}

