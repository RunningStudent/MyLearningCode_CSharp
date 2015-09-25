using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 使用sqlhelper对newtable进行增删改查
{
    public partial class Form1 : Form
    {
        //ClassInfo有classid,classname,classdesc
        BindingList<ClassInfo> list;
        //从数据库得到的数据都放到这个list,最后与dateGridView绑定
        //BingdingList特点,当list修改了DateGridVIew也会自动修改

        public Form1()
        {
            InitializeComponent();
        }

        //窗体载入时把数据读取到dateGridView
        private void Form1_Load(object sender, EventArgs e)
        {
            list = new BindingList<ClassInfo>();
            string sql = "select * from newTable";
            using (SqlDataReader reader = SqlHelper.ExecuteDateReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClassInfo info = new ClassInfo();
                        //把读取到的数据保存到一个ClassInfo类对象
                        info.classId = reader.GetInt32(0);
                        info.className = reader.GetString(1);
                        info.classDesc = reader.GetString(2);
                        list.Add(info);//把这个info加入到list中
                    }
                }
            }
            dataGridView1.DataSource = list;//数据绑定
        }

        //添加数据按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //先把数据保存到一个ClassInfo类
            ClassInfo info = new ClassInfo();
            info.className = tBClassName.Text.Trim();
            info.classDesc = tBClassDesc.Text.Trim();
            
            string sql = "insert into newTable output inserted.tClassId values(@name,@desc)";//能得到主键值
            //创建参数数组,为了给sql语句中的参数赋值
            //这里仅设定SqlParameter对象是属于什么参数的,这个参数的类型
            SqlParameter[] parameter = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.VarChar,50),
                new SqlParameter("@desc",SqlDbType.VarChar,50)
            };
            //这里是赋值
            parameter[0].Value = info.className;
            parameter[1].Value = info.classDesc;
            //把主键值赋值给info,这样所有成员都赋值了
            info.classId = (Int32)SqlHelper.ExecuteScalar(sql, parameter);
            //加入到list中
            list.Add(info);
            MessageBox.Show("添加成功");
        }

        //当dataGridView某行变为焦点事件
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int selectindex = e.RowIndex;
            label5.Text = "ClassId:"+list[selectindex].classId.ToString();
            tBEditClassName.Text = list[selectindex].className;
            tBEditClassDesc.Text = list[selectindex].classDesc;
        }

        //编辑按钮
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string sql = "update newtable set tClassName=@name,tClassDesc=@desc where tClassId=@Id";

            //创建对象数组
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.VarChar,50),
                new SqlParameter("@desc",SqlDbType.VarChar,50),
                new SqlParameter("@Id",SqlDbType.Int)
            };
            //赋值
            parameters[0].Value = tBEditClassName.Text;
            parameters[1].Value = tBEditClassDesc.Text;
            parameters[2].Value = int.Parse(label5.Text.Split(':')[1]);
            SqlHelper.ExcuteNonQuery(sql, parameters);//语句执行

            //修改选择行的数据
            list[dataGridView1.SelectedRows[0].Index].className = tBEditClassName.Text;
            list[dataGridView1.SelectedRows[0].Index].classDesc = tBEditClassDesc.Text;
            MessageBox.Show("修改成功");
        }

        //删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from newtable where tClassId=@Id";
            SqlParameter parameter = new SqlParameter("@Id", SqlDbType.Int);
            parameter.Value = int.Parse(label5.Text.Split(':')[1]);
            SqlHelper.ExcuteNonQuery(sql, parameter);
            //删除删除选择行
            list.RemoveAt(dataGridView1.SelectedRows[0].Index);
            MessageBox.Show("删除成功");
        }
    }
}
