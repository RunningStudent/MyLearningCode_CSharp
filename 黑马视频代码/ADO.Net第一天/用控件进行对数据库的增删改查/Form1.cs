using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace 用控件进行对数据库的增删改查
{
    public partial class Form1 : Form
    {
        //连接字符串
        string constr = "Data Source=Y-4988160916C94;Initial Catalog=ItCastCn;Integrated Security=True";

        //数据源,BindingList有自动更新DataGridView的功能
        BindingList<Student> stulist;
        public Form1()
        {
            InitializeComponent();
        }


        
        //窗体加载时的数据加载
        private void Form1_Load(object sender, EventArgs e)
        {
            DataInclude();
            ClassIdInclude();
        }


        //把班级信息加载到下拉框中
        private void ClassIdInclude()
        {
            //集合保存数据
            List<TbClass> classList = new List<TbClass>();
            using (SqlConnection sc = new SqlConnection(constr))
            {
                string sqlsentence = "select tclassName,tclassId from TblClass";
                using (SqlCommand command = new SqlCommand(sqlsentence, sc))
                {
                    sc.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            //用一个类来保存班级信息   
                            while (reader.Read())
                            {
                                TbClass tbclass = new TbClass();
                                tbclass.TClassName = reader.GetString(0);
                                tbclass.TClassId = reader.GetInt32(1);
                                classList.Add(tbclass);
                            }
                        }
                    }
                }
            }
            //给 添加控件组的下拉框 载入信息
            //设置下拉列表显示出集合元素_tClassName成员,这里必须填属性而不是字段
            cbBClass.DisplayMember = "TClassName";
            //设置下来列表选中时的值是集合元素_tClassId成员,这里必须填属性而不是字段
            cbBClass.ValueMember = "TClassId";
            //绑定数据源
            cbBClass.DataSource = classList;

            //给 修改控件组的下拉框 载入信息
            cbBEditClass.DisplayMember = "TClassName";
            cbBEditClass.ValueMember = "TClassId";
            cbBEditClass.DataSource = classList;
        }


        //数据加载方法
        private void DataInclude()
        {
            stulist = new BindingList<Student>();
            using (SqlConnection sc = new SqlConnection(constr))
            {
                string sqlSentence = @"select * from TblStudent";
                using (SqlCommand scmand = new SqlCommand(sqlSentence, sc))
                {
                    sc.Open();
                    using (SqlDataReader reader = scmand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Student stu = new Student();
                                stu.tSId = reader.GetInt32(0);
                                stu.tSName = reader.IsDBNull(1) ?null:reader.GetString(1);
                                stu.tSGender = reader.IsDBNull(2) ? null : reader.GetString(2);
                                stu.tSAddress = reader.IsDBNull(3) ? null : reader.GetString(3);
                                stu.tSPhone = reader.IsDBNull(4) ? null : reader.GetString(4);
                                stu.tSAge = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5);
                                stu.tSbirthday = reader.IsDBNull(6) ? null : (DateTime?)reader.GetDateTime(6);
                                stu.tSCardId = reader.IsDBNull(7) ? null : reader.GetString(7);
                                stu.tSClassId = reader.GetInt32(8);
                                stulist.Add(stu);
                            }
                        }
                    }
                }
            }
            //用BindingList进行数据绑定
            dataGridView1.DataSource = stulist;
        }

        //数据添加按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //可空列 tSName, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId

            //可填写列tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId
            //获取输入,把数据保存到一个student类中
            Student s = new Student();
            s.tSName = txttSName.Text == "" ? "NULL" : "'" + txttSName.Text + "'";
            s.tSGender = "'" + cbBGender.Text + "'";
            s.tSAddress = txttSAddress.Text == "" ? "NULL" : "'" + txttSAddress.Text + "'";
            s.tSPhone = txttSPhone.Text == "" ? "NULL" : "'" + txttSPhone.Text + "'";
            s.tSAge = txttSAge.Text == "" ? null : (int?)int.Parse(txttSAge.Text);
            s.tSbirthday =  dateTimePicker1.Value  ;
            s.tSCardId = txttSCardId.Text == "" ? "NULL" : "'" + txttSCardId.Text + "'";
            s.tSClassId=int.Parse(cbBClass.SelectedValue.ToString());


            using (SqlConnection sc = new SqlConnection(constr))
            { 
                //这个语句能返回新增的行的主键值
                string sqlsentence = string.Format("insert into TblStudent output inserted.tSId values({0},{1},{2},{3},{4},'{5}',{6},{7})", s.tSName, s.tSGender, s.tSAddress, s.tSPhone, s.tSAge == null ? "null" : s.tSAge.ToString(), s.tSbirthday.Value.ToString(), s.tSCardId, s.tSClassId);

                using (SqlCommand command = new SqlCommand(sqlsentence, sc))
                {
                    sc.Open();
                    //获得新增行的主键值
                    s.tSId = Convert.ToInt16(command.ExecuteScalar());
                }
            }

            //s成员全部填满,把它加入到stulist
            stulist.Add(s);
            MessageBox.Show("添加成功");
        }


        //选择数据行自动更新编辑控件组的数据
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            //tSId, tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId
            
            //修改控件显示值
            txtEditSid.Text = row.Cells[0].Value.ToString();
            txtEditName.Text = row.Cells[1].Value==null?string.Empty:row.Cells[1].Value.ToString();
            cbBEditGender.SelectedItem = row.Cells[2].Value.ToString();
            txtEditAddress.Text=row.Cells[3].Value == null ? string.Empty : row.Cells[3].Value.ToString();
            txtEditPhone.Text = row.Cells[4].Value == null ? string.Empty : row.Cells[4].Value.ToString();
            txtEditAge.Text = row.Cells[5].Value == null ? string.Empty : row.Cells[5].Value.ToString();

            if(row.Cells[6].Value!=null)
            {
                //好像是日历
                dateTimePicker2.Value = DateTime.Parse(row.Cells[6].Value.ToString());
            }

            txtEditCardId.Text = row.Cells[7].Value == null ? string.Empty : row.Cells[7].Value.ToString();

            //设置下拉框选中项
            cbBEditClass.SelectedValue = int.Parse(row.Cells[8].Value.ToString());
        }

        //数据删除未完成
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

       


        

       
    }

    //创建类用于保存数据
    class Student
    {
        // tSId tSName tSGender tSAddress tSPhone tSAge tSBirthday tSCardId tSClass
        public int tSId { get; set; }
        public string tSName { get; set; }
        public string tSGender { get; set; }
        public string tSAddress { get; set; }
        public string tSPhone { get; set; }
        public int? tSAge { get; set; }
        public DateTime? tSbirthday { get; set; }
        public string tSCardId { get; set; }
        public int tSClassId { get; set; }
    }

    class TbClass
    {
        //tClassName, tClassDesc
        private string _tClassName;
        public string TClassName
        {
            get { return _tClassName; }
            set { _tClassName = value; }
        }

        private int _tClassId;
        public int TClassId
        {
            get { return _tClassId; }
            set { _tClassId = value; }
        }

    }
}
