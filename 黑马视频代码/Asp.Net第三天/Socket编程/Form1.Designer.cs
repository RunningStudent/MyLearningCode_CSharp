namespace SocketProgram
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
            this.btnWaitConnect = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.txtLetter = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnShutDown = new System.Windows.Forms.Button();
            this.btnShowClient = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnShake = new System.Windows.Forms.Button();
            this.cBoxIsIIS = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnWaitConnect
            // 
            this.btnWaitConnect.Location = new System.Drawing.Point(315, 12);
            this.btnWaitConnect.Name = "btnWaitConnect";
            this.btnWaitConnect.Size = new System.Drawing.Size(75, 23);
            this.btnWaitConnect.TabIndex = 0;
            this.btnWaitConnect.Text = "启动监听";
            this.btnWaitConnect.UseVisualStyleBackColor = true;
            this.btnWaitConnect.Click += new System.EventHandler(this.btnWaitConnect_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(35, 37);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 21);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(182, 37);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "45000";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(35, 81);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(355, 232);
            this.txtMsg.TabIndex = 3;
            // 
            // txtLetter
            // 
            this.txtLetter.Location = new System.Drawing.Point(35, 328);
            this.txtLetter.Name = "txtLetter";
            this.txtLetter.Size = new System.Drawing.Size(247, 21);
            this.txtLetter.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(315, 328);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnShutDown
            // 
            this.btnShutDown.Location = new System.Drawing.Point(421, 37);
            this.btnShutDown.Name = "btnShutDown";
            this.btnShutDown.Size = new System.Drawing.Size(97, 23);
            this.btnShutDown.TabIndex = 6;
            this.btnShutDown.Text = "断开所有连接";
            this.btnShutDown.UseVisualStyleBackColor = true;
            this.btnShutDown.Click += new System.EventHandler(this.btnShutDown_Click);
            // 
            // btnShowClient
            // 
            this.btnShowClient.Location = new System.Drawing.Point(422, 96);
            this.btnShowClient.Name = "btnShowClient";
            this.btnShowClient.Size = new System.Drawing.Size(96, 25);
            this.btnShowClient.TabIndex = 7;
            this.btnShowClient.Text = "弹出客户端";
            this.btnShowClient.UseVisualStyleBackColor = true;
            this.btnShowClient.Click += new System.EventHandler(this.btnShowClient_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(421, 149);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(97, 25);
            this.btnSendFile.TabIndex = 8;
            this.btnSendFile.Text = "文件发送";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnShake
            // 
            this.btnShake.Location = new System.Drawing.Point(422, 192);
            this.btnShake.Name = "btnShake";
            this.btnShake.Size = new System.Drawing.Size(95, 25);
            this.btnShake.TabIndex = 9;
            this.btnShake.Text = "颤抖吧";
            this.btnShake.UseVisualStyleBackColor = true;
            this.btnShake.Click += new System.EventHandler(this.btnShake_Click);
            // 
            // cBoxIsIIS
            // 
            this.cBoxIsIIS.AutoSize = true;
            this.cBoxIsIIS.Location = new System.Drawing.Point(315, 59);
            this.cBoxIsIIS.Name = "cBoxIsIIS";
            this.cBoxIsIIS.Size = new System.Drawing.Size(66, 16);
            this.cBoxIsIIS.TabIndex = 10;
            this.cBoxIsIIS.Text = "IIS模式";
            this.cBoxIsIIS.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 367);
            this.Controls.Add(this.cBoxIsIIS);
            this.Controls.Add(this.btnShake);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnShowClient);
            this.Controls.Add(this.btnShutDown);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtLetter);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnWaitConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWaitConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.TextBox txtLetter;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnShutDown;
        private System.Windows.Forms.Button btnShowClient;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnShake;
        private System.Windows.Forms.CheckBox cBoxIsIIS;
    }
}

