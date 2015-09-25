using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace SocketProgram
{
    public partial class ClientFm : Form
    {
        public ClientFm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public Socket MySocket { get; set; }


        #region 事件
        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWaitConnect_Click(object sender, EventArgs e)
        {
            //1,创建socket,用于连接,信息接收与发送的socket
            Socket connectSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            MySocket = connectSocket;
            //2,连接服务器
            try
            {
                connectSocket.Connect(IPAddress.Parse(txtIP.Text), int.Parse(txtPort.Text));
            }
            catch
            {
                AppendTextToMsg("连接失败");
                return;
            }
            
            //3,开始接收消息
            ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveMsg), MySocket);

        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (MySocket.Connected)
            {
                //发送字节必须大于0
                byte[] bytLetter = Encoding.Default.GetBytes(txtLetter.Text);
                //一般不用设置,当涉及外网和局域网通信的使用会用到  
                int msgLength = MySocket.Send(bytLetter, 0, bytLetter.Length, SocketFlags.None);
            }
        }
        #endregion


        /// <summary>
        /// 接受服务器消息
        /// </summary>
        /// <param name="sokect">通信socket</param>
        public void ReceiveMsg(object sokect)
        {
            Socket receiveSocket = sokect as Socket;
            byte[] msgByte = new byte[1024 * 1024];

            while (true)
            {
                int length = -1;
                //为服务器异常退出而try
                try
                {
                    length = receiveSocket.Receive(msgByte, msgByte.Length, SocketFlags.None);
                }
                catch
                {
                    AppendTextToMsg(string.Format("服务器{0}异常退出了", receiveSocket.RemoteEndPoint.ToString()));
                    receiveSocket.Shutdown(SocketShutdown.Both);
                    receiveSocket.Close();
                    return;
                }
                //服务器正常退出
                if (length == 0)
                {
                    AppendTextToMsg(string.Format("服务器{0}退出了", receiveSocket.RemoteEndPoint.ToString()));
                    receiveSocket.Shutdown(SocketShutdown.Both);
                    receiveSocket.Close();
                    return;
                }
                //接受服务器消息
                switch (msgByte[0])
                {
                    case 1:
                        ReceiveStringMsg(msgByte, length, receiveSocket.RemoteEndPoint.ToString());
                        break;
                    case 2:
                        ReceiveFileData(msgByte, length);
                        break;
                    case 3:
                        ReceiveShake();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 震动窗口
        /// </summary>
        private void ReceiveShake()
        {
            Point oldLocation = this.Location;
            Random r = new Random();
            for (int i = 0; i < 50; i++)
            {
                this.Location = new Point(
                    r.Next(oldLocation.X - 10, oldLocation.X + 10),
                    r.Next(oldLocation.Y - 10, oldLocation.Y + 10)
                );
                Thread.Sleep(100);
            }
            this.Location = oldLocation;
        }

        /// <summary>
        /// 保存接受的文件
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        private void ReceiveFileData(byte[] data, int length)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.DefaultExt = "txt";
                sfd.Filter = "文本文件(*.txt)|*.txt|所有文件|*.*";
                if (sfd.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                byte[] saveData = new byte[length - 1];
                Buffer.BlockCopy(data, 1, saveData, 0, saveData.Length);
                File.WriteAllBytes(sfd.FileName, saveData);
                AppendTextToMsg("保存成功");
            }
        }

        /// <summary>
        /// 接受字符串消息,并显示在文本框
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="length">该数据实际的字节长度</param>
        /// <param name="receiveSocketIPAdress">发送该数据的服务器Ip地址</param>
        private void ReceiveStringMsg(byte[] data, int length, string receiveSocketIPAdress)
        {
            //如果传入字符串的长度大于1MB,那么会怎样?
            string str = Encoding.Default.GetString(data, 1, length - 1);
            AppendTextToMsg(string.Format("接收服务器{0}的消息:{1}", receiveSocketIPAdress, str));
        }

        /// <summary>
        /// 给消息文本框添加信息,追加至第一行
        /// 该方法要使用主窗体的textBox,所以要做跨线程处理
        /// </summary>
        /// <param name="str"></param>
        public void AppendTextToMsg(string str)
        {
            if (txtMsg.InvokeRequired)
            {
                txtMsg.Invoke(new Action<string>((s) =>
                {
                    txtMsg.Text = string.Format("{0}\r\n{1}", s, txtMsg.Text);

                }), str);
            }
            else
            {
                txtMsg.Text = string.Format("\r\n{0}", str);
            }
        }



    }
}
