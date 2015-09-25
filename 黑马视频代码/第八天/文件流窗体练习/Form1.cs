using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 文件流窗体练习
{

    #region Person结构定义
    /// <summary>
    /// Person结构定义
    /// </summary>
    public struct Person
    {
        public string name;
        public string sex;
        public int age;
        public string mail;
        public Person(string name, string sex, string mail, int age)
        {
            this.name = name;
            this.sex = sex;
            this.mail = mail;
            this.age = age;
        }
    }
    #endregion
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Person> date = new List<Person>();



        #region 数据载入,窗口初始化
        /// <summary>
        /// 数据载入,窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Form1_Load(object sender, EventArgs e)
        {
            cBSex.SelectedIndex = 0;
            if(!File.Exists("人员.txt"))
                return;
            using (StreamReader sr = new StreamReader("人员.txt",Encoding.Default))
            {
                string str = null;
                string[] strs = null;
                while (!sr.EndOfStream)
                {
                    str = sr.ReadLine();
                    strs = str.Split(',');
                    Person p = new Person(strs[0], strs[1], strs[3], int.Parse(strs[2]));
                    date.Add(p);
                    lBData.Items.Add(strs[0]);
                    //lBData.Items自动使用Tostring(),所以会显示命名空间,所以可以重写Person.Tostring()
                    //这里就能直接把Person对象保存在Items中,且正确的显示姓名
                }
            }
        }
        #endregion

        #region 双击获得具体数据
        /// <summary>
        /// 双击获得具体数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lBData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Person p = date[lBData.SelectedIndex];
            string str = "姓名:" + p.name + "  性别:" + p.sex + "   年龄:" + p.age + "   邮箱:" + p.mail;
            MessageBox.Show(str);
        }
        #endregion

        #region 数据添加事件
        /// <summary>
        /// 数据添加按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDataAdd_Click(object sender, EventArgs e)
        {
            if (tBMail.Text == "" || tBName.Text == "" || tBAge.Text == "")
            {
                MessageBox.Show("输入完整信息");
            }
            Person p = new Person(tBName.Text, cBSex.SelectedItem.ToString(), tBMail.Text, int.Parse(tBAge.Text));
            lBData.Items.Add(tBName.Text);
            date.Add(p);
        }
        #endregion 

        #region 数据保存事件
        /// <summary>
        /// 数据保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("人员.txt", false, Encoding.Default))
            {
                string str = null;
                foreach (var item in date)
                {
                    str = string.Format("{0},{1},{2},{3}", item.name, item.sex, item.age, item.mail);
                    sw.WriteLine(str);
                }
            }
            MessageBox.Show("保存成功");
        }
        #endregion
        

    }
}
