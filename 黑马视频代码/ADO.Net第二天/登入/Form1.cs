using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace 登入
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
	
	//登入按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            //为了数据库打开时间短,把消息另外写在一个字符串
            string msg = null;
            bool loginsucceed = false;//代表是否登陆成功
            string constr = "Data Source=Y-4988160916C94;Initial Catalog=ItCastCn;Integrated Security=True";
            using (SqlConnection sc = new SqlConnection(constr))
            {
                #region 不带参数的登入
                //string sqlstr = string.Format("select autoid,loginPwd from Tblogin where loginId='{0}'", txtUserName.Text);
                //using (SqlCommand command = new SqlCommand(sqlstr, sc))
                //{
                //    sc.Open();
                //    using (SqlDataReader reader = command.ExecuteReader())
                //    {
                //        if (reader.HasRows)
                //        {
                //            while (reader.Read())
                //            {
                //                if (reader.GetString(1) != txtPassword.Text)
                //                {
                //                    msg = "密码错误";
                //                    loginsucceed = false;
                //                }
                //                else
                //                {
                //                    msg = "登入成功";
                //                    UserId = reader.GetInt32(0);
                //                    loginsucceed = true;//如果登入成功吧它设置为true
                //                }
                //            }
                //        }
                //        else
                //        {
                //            msg = "账户不存在";
                //        }
                //    }
                //}
                #end region
                
                //用户名为查找条件
                string sqlstr = "select autoid,loginPwd,ErrorCount,LastLoginTime from Tblogin where loginId=@user";
                using (SqlCommand command = new SqlCommand(sqlstr, sc))
                {
                    sc.Open();
		      //给带参数的sql语句的变量赋值的方法之一
                    //SqlParameter user = new SqlParameter("@user", txtUserName.Text);
                    //command.Parameters.Add(user);
                    command.Parameters.AddWithValue("@user", txtUserName.Text);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //如果查到,说明数据库中有这个用户
                        if (reader.HasRows)
                        {
                            reader.Read();
			    
			    //从数据库中获得数据的数据先保存到变量中等会用
                            UserId = reader.GetInt32(0);
                            int errorcount = reader.GetInt32(2);
                            DateTime lastdateTime = reader.GetDateTime(3);
                            TimeSpan span = DateTime.Now - lastdateTime;//时间间隔,分为单位
				
			    
                            if (errorcount >= 3 && span.Minutes < 15)//先判断是否登入失败了3次,是否间隔15分钟
                            {
                                MessageBox.Show("登入失败3次,请等待15分钟后登入");
                                return;
                            }

                            if (reader.GetString(1) == txtPassword.Text)
                            {
                                msg = "登入成功";
                                loginsucceed = true;
                            }
                            else
                            {
                                msg = "密码错误";
                                loginsucceed = false;
  				//因为密码错误,所以把数据库中的ErrorCount+1
                                reader.Close();//关闭reader后才能用command
                                //创建新的sql语句,如果用到参数变量,变量名不能跟上面的一样,可能上面的sql语句还保存在command中
				//这里用UserId,没用带参数的sql语句
                                sqlstr = "update Tblogin set ErrorCount=ErrorCount+1 where autoid=" + UserId.ToString();
                                command.CommandText = sqlstr;
                                command.ExecuteNonQuery();
                            }
			    //=======判断密码正误完成========

                            //因为所输入账号存在,所以把数据库中的登入时间更新,同时进行对ErrorTime的重置操作
                            reader.Close();
                            //当错误次数少于3次,且密码错误,仅更新日期
                            if (errorcount < 3&&!loginsucceed)
                            {
                                sqlstr = "update Tblogin set LastLoginTime=" + "\'" + DateTime.Now.ToString() + "\'" + "where autoid=" + UserId.ToString();
                            }
                            //当错误次数大于3,既然程序能到这里说明已经间隔了15分钟,把错误次数-3
                            //不能的单纯重置为0,例:如果15分钟后再错,那么最终的错误次数应该是4,在这里-3最后等于1
                            else if (errorcount >= 3)
                            {
                                sqlstr = "update Tblogin set LastLoginTime=" + "\'" + DateTime.Now.ToString() + "\'" + ",ErrorCount=ErrorCount-3" + " where autoid=" + UserId.ToString();
                            }
                            //当登入成功,把错误次数重置为0
                            else if (loginsucceed)
                            {
                                sqlstr = "update Tblogin set LastLoginTime=" + "\'" + DateTime.Now.ToString() + "\'" + ",ErrorCount=0" + " where autoid=" + UserId.ToString();
                            }
                            command.CommandText = sqlstr;
                            command.ExecuteNonQuery();

                        }
                        else
                        {
                            msg = "账号不存在";
                        }
                    }
                }



            }
            MessageBox.Show(msg);
            if (loginsucceed)
            {
                btnChangePsw.Enabled = true;
                //如果登入成功,把修改密码按钮设置可用
            }
        }

        //修改密码按钮
        private void btnChangePsw_Click(object sender, EventArgs e)
        {
            //传入账号密码
            Form changPsw = new 修改密码(txtUserName.Text, UserId);
            changPsw.Show();
        }

	//修改账号txtbox操作时触发的事件
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            btnChangePsw.Enabled = false;
            //修改密码的窗口会获取当前账号,为防止账号更改
            //设置当修改账号时把修改密码的按钮设置为不可用
        }
    }
}
