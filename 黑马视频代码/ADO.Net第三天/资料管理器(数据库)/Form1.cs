using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace 资料管理器_数据库_
{
    public partial class Form1 : Form
    {

        //一共两个数据库,一个类别Category,一共具体数据ContentInfo
        //缺少连带数据删除,即类别删除所关联的数据也删除
        //缺少添加顶级Category类别方法,只能添加子类别
        //缺少具体数据删除
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载时,把数据加载到TreeView,事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategory(treeView1.Nodes, GetCategoryByParentId(-1));
        }

        /// <summary>
        /// 选中TreeView节点自动加载版块信息到ListBox里,从数据库中拿取,事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadDataIntoListBox(e.Node);
        }

        
        /// <summary>
        /// 双击ListBox元素自动显示文章内容事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Contentinfo info = (Contentinfo)listBox1.SelectedItem;
            textBox1.Text = info.dContent;
        }

        /// <summary>
        /// 鼠标点击节点(无论左右键)时,该节点被选中,事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
        }

        /// <summary>
        /// 右键菜单点击导入文件到数据库事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "选中导入文件的路径";
            of.Filter = "文本文件 |*.txt|所有文件|*.*";
            of.Multiselect = false;
            of.ShowDialog();
            if (of.FileName != "")
            {
                string sql = "insert into contentinfo(dTid,dName,dContent) values(@tid,@name,@content)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@tid",(int)treeView1.SelectedNode.Tag),
                new SqlParameter("@name",Path.GetFileNameWithoutExtension(of.FileName)),
                new SqlParameter("@content",File.ReadAllText(of.FileName))
                };
                SqlHelper.ExecuteNonQuery(sql, parameters);
                LoadDataIntoListBox(treeView1.SelectedNode);
            }
        }

        /// <summary>
        /// treeView子节  菜单点击添加子类别事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 增加子类ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
            f2.ShowDialog();
            Category category = new Category();
            TreeNode node = treeView1.SelectedNode.Nodes.Add(f2.name);
            node.ContextMenuStrip = contextMenuStrip1;//给新节点绑定右键菜单
            //给TreeView增加新类别完成
            //但记得把tid放到新的节点的tag中,而tid是Category表中的主键,要在表中增加这条数据才能获得

            string sql = "insert into Category(tName,tParentId) output inserted.tId values(@name,@parentId)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@name",f2.name),
                new SqlParameter("@parentId",(int)treeView1.SelectedNode.Tag)
            };
            int tid = (int)SqlHelper.ExecuteScalar(sql, parameters);
            node.Tag = tid;
        }



        /// <summary>
        /// 递归载入Category(版块)方法
        /// </summary>
        /// <param name="treeNodeCollection">被加入数据的TreeView的Nodes集合</param>
        /// <param name="list">要加入的数据的集合</param>
        private void LoadCategory(TreeNodeCollection treeNodeCollection, List<Category> list)
        {
            //可以先试着写出非递归情况
            foreach (var item in list)
            {
                TreeNode node = treeNodeCollection.Add(item.tName);
                //为了方便后面选中TreeView节点加载文章标题,这里吧tId保存到tag
                node.Tag = item.tId;
                if (node.Level != 0)//给子节点添加右键菜单
                {
                    node.ContextMenuStrip = contextMenuStrip1;
                }
                else
                {
                    node.ContextMenuStrip = contextMenuStrip2;
                }
                LoadCategory(node.Nodes, GetCategoryByParentId(item.tId));
            }
        }


        /// <summary>
        /// 根据ParentId返回对应的版块的集合方法,集合元素是保存版块信息的Category对象 方法
        /// </summary>
        /// <param name="pid">parentid</param>
        /// <returns></returns>
        private List<Category> GetCategoryByParentId(int pid)
        {
            List<Category> list = new List<Category>();
            string sql = "select tId,tName from category where tParentId=@pid";
            using (SqlDataReader reader = SqlHelper.ExecuteSqlDataReader(sql, new SqlParameter("@pid", pid)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Category c = new Category();
                        c.tId = reader.GetInt32(0);
                        c.tName = reader.GetString(1);
                        list.Add(c);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 往ListBox载入文章方法
        /// </summary>
        /// <param name="node"></param>
        private void LoadDataIntoListBox(TreeNode node)
        {
            List<Contentinfo> infoList = new List<Contentinfo>();
            string sql = "select did,dName,dContent from contentinfo where dTid=@tid";
            using (SqlDataReader reader = SqlHelper.ExecuteSqlDataReader(sql, new SqlParameter("@tid", (int)node.Tag)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Contentinfo info = new Contentinfo();
                        info.dName = reader.GetString(1);//获得文章名
                        info.dContent = reader.GetString(2);//获得文章内容
                        infoList.Add(info);
                    }
                }
            }
            //使用数据绑定方式把数据保存到LisBox,为了正确显示文章标题,重写ToString()
            listBox1.DataSource = infoList;
        }


        /// <summary>
        /// 菜单删除子类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //先删除数据库中这个类别下的文章
            string sql= "delete from ContentInfo where dTid=@dtid";
            int tid=(int)treeView1.SelectedNode.Tag;
            SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@dtid", tid));
            //再删除数据库中这个类别
            sql = "delete from Category where tId=@tid";
            SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@tid", tid));
            //在删除TreeView中这个节点
            treeView1.SelectedNode.Remove();
        }


        


    }
}
