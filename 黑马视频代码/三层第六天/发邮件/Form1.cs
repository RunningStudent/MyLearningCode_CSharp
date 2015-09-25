using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace 发邮件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 发一封普通的Mail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //创建邮件对象
            MailMessage mail = new MailMessage();
            mail.Subject = "这是主题";
            //设置编码格式
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = "这是正文";
            //设置编码格式
            mail.BodyEncoding = Encoding.UTF8;
            
            //发件人,只能有一个
            mail.From = new MailAddress("test@stupid.com");

            //收件人,可以多个,是个集合
            mail.To.Add(new MailAddress("test2@stupid.com", "左边是邮箱地址,右边是显示的名字",Encoding.UTF8));
            //mail.cc,抄送

            //创建发送邮件对象,服务器地址,Smtp端口号!!
            SmtpClient client = new SmtpClient("localhost", 25);
            //输入发件人的账号密码
            client.Credentials = new NetworkCredential("test1@stupid.com", "123456");
            client.Send(mail);
            MessageBox.Show("ok");
        }

        /// <summary>
        /// 发一封带html的邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //创建邮件对象
            MailMessage mail = new MailMessage();
            mail.Subject = "这是主题";
            //设置编码格式
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = "这是正文";
            //设置编码格式
            mail.BodyEncoding = Encoding.UTF8;

            //=========================html部分==================

            AlternateView htmlBody =
            AlternateView.CreateAlternateViewFromString("<font size='7' color='red' >htmlBodyContent</font>", null, "text/html");
            mail.AlternateViews.Add(htmlBody);//这种方式可以同时显示两种格式一种为html，另外一种为文本模式。与下面这种的区别。            //一般情况下邮件中只能看到html的邮件

            //另一种设置html正文的方法
            //mail.IsBodyHtml=true

            //==================================================

            //发件人,只能有一个
            mail.From = new MailAddress("test@stupid.com");

            //收件人,可以多个,是个集合
            mail.To.Add(new MailAddress("test2@stupid.com", "左边是邮箱地址,右边是显示的名字", Encoding.UTF8));
            //mail.cc,抄送

            //创建发送邮件对象,服务器地址,Smtp端口号!!
            SmtpClient client = new SmtpClient("localhost", 25);
            //输入发件人的账号密码
            client.Credentials = new NetworkCredential("test1@stupid.com", "123456");
            client.Send(mail);
            MessageBox.Show("ok");
        }

        /// <summary>
        /// 带图片的邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //创建邮件对象
            MailMessage mail = new MailMessage();
            mail.Subject = "这是主题";
            //设置编码格式
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = "这是正文";
            //设置编码格式
            mail.BodyEncoding = Encoding.UTF8;

            //=========================html部分==================

            //给img的src=设置cid,即ContentId
            AlternateView htmlBody =AlternateView.CreateAlternateViewFromString("<font size='7' color='red' >htmlBodyContent</font><img src='cid:picture'/>", null, "text/html");
            mail.AlternateViews.Add(htmlBody);

            //载入资源
            LinkedResource lr = new LinkedResource(@"C:\Documents and Settings\Administrator\桌面\HTML图片.png", "image/gif");
            lr.ContentId = "picture";

            htmlBody.LinkedResources.Add(lr);

            //==================================================

            //发件人,只能有一个
            mail.From = new MailAddress("test@stupid.com");

            //收件人,可以多个,是个集合
            mail.To.Add(new MailAddress("test2@stupid.com", "左边是邮箱地址,右边是显示的名字", Encoding.UTF8));
            //mail.cc,抄送

            //创建发送邮件对象,服务器地址,Smtp端口号!!
            SmtpClient client = new SmtpClient("localhost", 25);
            //输入发件人的账号密码
            client.Credentials = new NetworkCredential("test1@stupid.com", "123456");
            client.Send(mail);
            MessageBox.Show("ok");
        }


        /// <summary>
        /// 发送带附件的邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //创建邮件对象
            MailMessage mail = new MailMessage();
            mail.Subject = "这是主题";
            //设置编码格式
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = "这是正文";
            //设置编码格式
            mail.BodyEncoding = Encoding.UTF8;
            //发件人,只能有一个
            mail.From = new MailAddress("test@stupid.com");

            //收件人,可以多个,是个集合
            mail.To.Add(new MailAddress("test2@stupid.com", "左边是邮箱地址,右边是显示的名字", Encoding.UTF8));
            
            //=============发送附件==========================
            //创建附件对象
            Attachment a1 = new Attachment(@"C:\Documents and Settings\Administrator\桌面\new  2.txt");
            Attachment a2 = new Attachment(@"C:\Documents and Settings\Administrator\桌面\Javascript.swf");
            Attachment a3 = new Attachment(@"C:\Documents and Settings\Administrator\桌面\JQuery.swf");
            
            //加入到邮件中
            mail.Attachments.Add(a1);
            mail.Attachments.Add(a2);
            mail.Attachments.Add(a3);
            //===============================================

            //创建发送邮件对象,服务器地址,Smtp端口号!!
            SmtpClient client = new SmtpClient("localhost", 25);
            //输入发件人的账号密码
            client.Credentials = new NetworkCredential("test1@stupid.com", "123456");
            client.Send(mail);
            MessageBox.Show("ok");

        }
    }
}
