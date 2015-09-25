using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 登入界面封装成控件
{
    public partial class UCLoginControl : UserControl
    {
        public UCLoginControl()
        {
            InitializeComponent();
        }
        public event Action<object, UCEventArgs> login;
        private void button1_Click(object sender, EventArgs e)
        {
            //获取用户输入
            //把信息保存在一个UCEventArgs对象中
            UCEventArgs uce = new UCEventArgs();
            uce.UserName = textBox1.Text;
            uce.UserPassword = textBox2.Text;
            uce.IsPass = false;

            //并触发事件方法
            if (login != null)
            {
                login(this, uce);
                //把控件对象和控件信息传入事件储存的方法中
                //而方法是由使用这个控件的地方写的
                //所以要注意这里的this与uce不是给login,而是给那个方法


                //登入成功还是失败造成的现象可以在内部和外部写
                //if (uce.IsPass == true)
                //{
                //    this.BackColor = Color.Red;
                //}
                //else
                //{
                //    this.BackColor = Color.Blue;
                //}
            }
        }
    }
    public  class UCEventArgs : EventArgs//储存控件信息
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _userPassword;

        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

        private bool _isPass;//储存是否严重成功,毕竟事件方法触发是在内部.验证在外部

        public bool IsPass
        {
            get { return _isPass; }
            set { _isPass = value; }
        }
    }

}
