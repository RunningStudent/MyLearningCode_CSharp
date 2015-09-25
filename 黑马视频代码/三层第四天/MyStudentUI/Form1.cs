using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyStudentBLL;
using StudentModel;


namespace MyStudentUI
{
    public partial class Form1 : Form
    {
        MyStudentBll bll = new MyStudentBll();
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //把班级信息加载到cboCLass
            List<StudentClass> listClass = bll.GetClassMsg();

            //设置显示成员,选择成员,数据绑定
            cboClass.DisplayMember = "ClassName";
            cboClass.ValueMember = "ClassId";
            cboClass.DataSource = listClass;

            //创建一个克隆,如果使用相同的数据源两个comboBox显示的是一样的数据
            List<StudentClass> newListClass = listClass.ToList<StudentClass>();
            cboEditClassName.DisplayMember = "ClassName";
            cboEditClassName.ValueMember = "ClassId";
            cboEditClassName.DataSource = listClass;
            LoadDataToDataGridView();

        }


        List<Student> list;


        /// <summary>
        /// 加载数据到DataGridView
        /// </summary>
        private void LoadDataToDataGridView()
        {
            list= bll.GetTop20Data();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list;
        }


        /// <summary>
        /// 插入数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //数据获得
            Student s = new Student();
            s.Birthday = dateTimePicker2.Value;
            s.EnglishScore = Convert.ToInt32(txtEnglish.Text.Trim());
            s.Gender = cboGender.Text;
            s.MathScore = txtMath.Text.Length > 0 ? (int?)Convert.ToInt32(txtMath.Text.Trim()) : null;
            s.Age = Convert.ToInt32(txtAge.Text.Trim());
            //获取班级信息,保存在StudentClass类中
            StudentClass myClass = new StudentClass();
            myClass.ClassId = (int)cboClass.SelectedValue;
            myClass.ClassName = cboClass.Text;
            s.Myclass = myClass;
            s.Name = txtName.Text.Trim();

            //使用逻辑层
            if (bll.Insert(s) > 0)
            {
                MessageBox.Show("插入成功");
            }
            else
            {
                MessageBox.Show("插入失败");
            }

        }



        /// <summary>
        /// dataGridView初始化时候,特别地把ClasName列的真实数据显示出来,而不是类的命名空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 && e != null && e.Value is StudentClass)
            {
                StudentClass sclass = e.Value as StudentClass;
                if (sclass != null)
                {
                    e.Value = sclass.ClassName;
                }
            }
        }


        /// <summary>
        /// 更新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //获取修改好的数据
            Student s = new Student();
            s.Name = txtEditName.Text;
            s.Age = int.Parse(txtEditAge.Text);
            s.EnglishScore = int.Parse(txtEditEnglish.Text);
            s.MathScore = txtEditMath.Text.Length == 0 ? null : (int?)int.Parse(txtEditMath.Text);
            s.Birthday = dateTimePicker2.Value;
            StudentClass sclass = new StudentClass();
            sclass.ClassId = (int)cboEditClassName.SelectedValue;
            sclass.ClassName = cboEditClassName.Text;
            s.Myclass = sclass;
            s.Gender = cboEditGender.Text;
            //前面都是用文本框或者combobox获取数据,下面直接用DataGridView获取


            //获取选中行的索引
            int index = dataGridView1.SelectedRows[0].Index;
            //设置被添加数据的StudentID
            s.StudentId = list[index].StudentId;
            //更新DataGridView显示内容
            list[index] = s;

            bll.Update(s);
        }



        /// <summary>
        /// 选中DataGridView某行时候把填充Edit数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Student s = list[e.RowIndex];
            txtEditAge.Text = s.Age.ToString();
            txtEditName.Text = s.Name;
            txtEditMath.Text= s.MathScore.ToString();
            txtEditEnglish.Text = s.EnglishScore.ToString();
            cboEditClassName.Text = s.Myclass.ClassName;
            cboEditGender.Text = s.Gender;
            dateTimePicker2.Value  = (DateTime)s.Birthday;
        }


        /// <summary>
        /// 删除数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            //获取选中行的索引
            int index = dataGridView1.SelectedRows[0].Index;
            //获取被修改行数据的id
            int sindex = list[index].StudentId;
            bll.Delete(sindex);
            list.RemoveAt(index);
        }

        






    }
}
