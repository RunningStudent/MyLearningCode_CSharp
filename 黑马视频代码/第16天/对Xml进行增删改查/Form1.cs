using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 对Xml进行增删改查//只完成了增加功能
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private XDocument document;
        private List<Person> informationList=new List<Person>();
        private void Form1_Load(object sender, EventArgs e)
        {
            document = XDocument.Load("UserData.xml");
            InformationInclude();
        }

        private void InformationInclude()
        {
            
            XElement rootNode = document.Root;
            foreach (var item in rootNode.Elements())
            {
                Person p = new Person();
                p._id = item.Attribute("id").Value.ToString();
                p._name = item.Element("name").Value.ToString();
                p._password = item.Element("password").Value;
                informationList.Add(p);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XElement rootNode = document.Root;//获得根节点
            string id = tBid.Text;
            string userName = tBuserName.Text;
            string password = tBpasswod.Text;
            //获得用户信息
            #region 弱鸡做法
            //foreach (XElement item in rootNode.Elements())
            //{
            //    //遍历文档,验证id是否已存在
            //    if (item.Attribute("id").Value.ToString() == id)
            //    {
            //        MessageBox.Show("id名已存在");
            //        return;
            //    }
            //}
            #endregion
            //集合都能用到Linq
            if ((from i in rootNode.Elements()
                 where i.Attribute("id").Value.ToString() == id
                 select i).Count() != 0)//判断与用户输入的相同的id 的节点数量为是否为0
            {
                MessageBox.Show("id名已存在");
                return;
            }
            XElement user = new XElement("user");
            user.SetAttributeValue("id", id);//创建rootNode的子节点,并赋予属性
            XElement name = new XElement("name", userName);//创建user子节点,并赋予内容
            XElement pswd = new XElement("password", password);//创建user子节点,并赋予内容
            user.Add(name, pswd);//把user的两个子节点加入
            rootNode.Add(user);//user节点加入根节点
            document.Save("UserData.xml");//保存文档
            MessageBox.Show("保存成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in informationList)
            {
                textBox1.Text += (item._id+"   "+item._name+"   "+item._password);
                textBox1.Text += "\n";
            }
        }

    }
    class Person
    {
        public string _name;
        public string _id;
        public string _password;
    }
}
