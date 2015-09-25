using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 用代码生成器生成的代码对数据库操作.BLL;
using System.Collections;

namespace 用代码生成器生成的代码对数据库操作.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private MyClassBLL bll = new MyClassBLL();

        private void Form1_Load(object sender, EventArgs e)
        {
            
            IEnumerable list = bll.GetAll();
            dataGridView1.DataSource = list;
        }

        //点击删除选中行
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count!=0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                bll.DeleteByClassId(id);
                MessageBox.Show("ok");

            }
        }
    }
}
