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
using SocketProgram.IISClass;

namespace SocketProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //设置可跨线程
        }

        /// <summary>
        /// 保存通信socket
        /// </summary>
        private List<Socket> lists = new List<Socket>();

        #region 事件
        /// <summary>
        /// 启动监听按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWaitConnect_Click(object sender, EventArgs e)
        {

            //1,创建监听socket
            Socket seriveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //2,设置监听端口
                IPAddress ip = IPAddress.Parse(txtIP.Text);
                IPEndPoint port = new IPEndPoint(ip, int.Parse(txtPort.Text));
                seriveSocket.Bind(port);

                //3,监听,设置最大连接队列
                seriveSocket.Listen(10);
                txtMsg.Text += "监听开始\r\n";
                //4,接受连接并创建沟通socket,写在线程中,根据选择框判断是否为服务器形态运行
                if (cBoxIsIIS.Checked==true)
                {
                    //众多按钮不可用
                    btnSend.Enabled = false;
                    btnSendFile.Enabled = false;
                    btnShake.Enabled = false;
                    btnShutDown.Enabled = false;
                    btnShowClient.Enabled = false ;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(WaitForRequest), seriveSocket);        

                }
                else
                {

                    ThreadPool.QueueUserWorkItem(new WaitCallback(WaitForConnect), seriveSocket);        
                }
                cBoxIsIIS.Enabled = false;
                
            }
            catch (System.Exception ex)
            {}
            
            //监听socket并没有与客户端连接所以如果关闭的时候不需要shutdown,直接close

        }

        /// <summary>
        /// 给每个终端发送字符串消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            //发送字节必须大于0
            byte[] bytLetter = Encoding.Default.GetBytes(txtLetter.Text);
            ConverData(bytLetter,1);
        }

       


        /// <summary>
        /// 断开所有连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShutDown_Click(object sender, EventArgs e)
        {
            foreach (var item in lists)
            {
                if (item.Connected)
                {
                    //断开所有通信连接,且断开的是接收和发送
                    item.Shutdown(SocketShutdown.Both);
                    //断开其实是发送空字节数据,除了断开其他地方不能发送空字节消息
                    item.Close();
                }
                
            }
            lists.Clear();
        }


        /// <summary>
        /// 弹出客户端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowClient_Click(object sender, EventArgs e)
        {
            Form fm = new ClientFm();
            fm.Show();
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd=new OpenFileDialog())
            {
                if (ofd.ShowDialog(this)!= System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                byte[] fileData = File.ReadAllBytes(ofd.FileName);
                ConverData(fileData, 2);
            }

        }

        /// <summary>
        /// 发送抖屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShake_Click(object sender, EventArgs e)
        {
            byte[] shake = new byte[1];
            shake[0] = 3;
            ConverData(shake, 3);
        }
        #endregion




        /// <summary>
        /// 传输数据
        /// </summary>
        /// <param name="date">要传输的数据</param>
        /// <param name="dataType">该数据的类型,1为字符串,2为文件,3为抖屏</param>
        private void ConverData(byte[] date, int dataType)
        {
            byte[] resultData = new byte[date.Length + 1];
            //构建最终结构字节数据
            switch (dataType)
            {
                case 1:
                    resultData[0] = 1;
                    Buffer.BlockCopy(date, 0, resultData, 1, date.Length);
                    break;
                case 2:
                    resultData[0] = 2;
                    Buffer.BlockCopy(date, 0, resultData, 1, date.Length);
                    break;
                case 3:
                    resultData[0] = 3;
                    Buffer.BlockCopy(date, 0, resultData, 1, date.Length);
                    break;
                default:
                    break;
            }
            //对每个链接发送数据
            foreach (var item in lists)
            {
                if (item.Connected)
                {
                    //一般不用设置,当涉及外网和局域网通信的使用会用到  
                    int convertedDataLength = item.Send(resultData, 0, resultData.Length, SocketFlags.None);
                }
            }
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

        /// <summary>
        /// 接受连接,聊天程序形态
        /// </summary>
        /// <param name="sokect">监听socket</param>
        public void WaitForConnect(object sokect)
        {
            Socket seriveSocket = (Socket)sokect;
            //持续性的接受连接
            while (true)
            {
                //连接成功创建通信socket,阻塞方法
                Socket newSocket = seriveSocket.Accept();
                string str = "connect!!";

                newSocket.Send(Encoding.Default.GetBytes(str));
                ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveMsg), newSocket);

                //新连接保存到集合中
                lists.Add(newSocket);
                AppendTextToMsg(String.Format("{0}:连接成功", newSocket.RemoteEndPoint.ToString()));
            }
        }

        /// <summary>
        /// 接受客户端消息
        /// </summary>
        /// <param name="sokect">通信socket</param>
        public void ReceiveMsg(object sokect)
        {
            Socket receiveSocket = sokect as Socket;
            byte[] msgByte = new byte[1024 * 1024];

            while (true)
            {
                int lenght = -1;
                try
                {
                   lenght = receiveSocket.Receive(msgByte, msgByte.Length, SocketFlags.None);
                }
                catch
                {
                    //为了断开所有连接按钮设置的try_catch
                    //如果在断开连接按钮中释放了receiveSocket,下面就报异常,所以要try
                    try
                    {
                        AppendTextToMsg(string.Format("客户端{0}异常退出了", receiveSocket.RemoteEndPoint.ToString()));
                        receiveSocket.Shutdown(SocketShutdown.Both);
                        receiveSocket.Close();
                        lists.Remove(receiveSocket);
                    }
                    catch (System.Exception ex)
                    {}
                    return;
                }

                //接受数据为0长度,说明对方断开连接,此时我方也断开连接
                if (lenght == 0)
                {
                    //如果传入字符串的长度大于1MB,那么会怎样?
                    AppendTextToMsg(string.Format("客户端{0}退出了", receiveSocket.RemoteEndPoint.ToString()));
                    receiveSocket.Shutdown(SocketShutdown.Both);
                    receiveSocket.Close();
                    lists.Remove(receiveSocket);
                    return;
                }
                string str = Encoding.Default.GetString(msgByte, 0, lenght);
                AppendTextToMsg(string.Format("接收客户端{0}的消息:{1}", receiveSocket.RemoteEndPoint.ToString(), str));


            }
        }



        /// <summary>
        /// 等待浏览器请求,连接一次就断开
        /// </summary>
        /// <param name="sokect">监听socket</param>
        public void WaitForRequest(object sokect)
        {
            Socket listenSocket = sokect as Socket;
            byte[] receiveData=new byte[2*1024*1024];
            while (true)
            {
                //这里一直监听请求,但是浏览器可能会发送0字节请求,以表示断开连接
                //但下面代码已经自动断开连接,所以0字节数据会当做普通请求处理,所以加个判断
                Socket connectSocket=listenSocket.Accept();
                int length=connectSocket.Receive(receiveData, receiveData.Length, SocketFlags.None);
                if (length<=0)
                {
                    continue;
                }

                //获取请求报文
                string respondStr = Encoding.UTF8.GetString(receiveData, 0, length);
                HttpContext context = new HttpContext(respondStr);

                //把报文和连接信息显示在文本框
                AppendTextToMsg(String.Format("{0}:连接成功", connectSocket.RemoteEndPoint.ToString()));
                AppendTextToMsg(string.Format("接收客户端{0}的消息:{1}", connectSocket.RemoteEndPoint.ToString(), respondStr));
                
                //处理报文
                ProcessDemo1 process = new ProcessDemo1();
                process.ProcessRequest(context);

                //返回响应报文
                connectSocket.Send(context.Response.GetResponseHead());
                connectSocket.Send(context.Response.ResponseBody);

                //关闭sockect
                connectSocket.Shutdown(SocketShutdown.Both);
                connectSocket.Close();
             
                
            }
        }
        

      
    }
}
