using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TreeView练习加载省市
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTree2(0,treeView1.Nodes);
        }
        #region 方法2
        /// <summary>
        /// 用DataTable保存数据,在加载到TreeView上
        /// </summary>
        /// <param name="p"></param>
        /// <param name="tN"></param>
        private void LoadTree2(int p, TreeNodeCollection tN)
        {
            string sql = "select AreaId,AreaName from TblArea where AreaPId=" + p;
            DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text);
            foreach (DataRow item in dt.Rows)
            {
                TreeNode newTreedNode = tN.Add(item[1].ToString());
                newTreedNode.Tag = item[0].ToString();//保存编号
                LoadTree2((int)item[0], newTreedNode.Nodes);
            }
        }
        #endregion
        #region 方法1
        /// <summary>
        /// 载入节点方法一:在DataReader内使用递归损耗极大
        /// </summary>
        private void LoadTree1()
        {
            string sqlAddRoot = "select * from TblArea";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sqlAddRoot, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //载入根节点们
                        if (reader.GetInt32(2) == 0)
                        {
                            TreeNode tn = treeView1.Nodes.Add(reader.GetString(1));
                            //载入子节点们
                            IncludeChild(tn, reader.GetInt32(0));
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 递归载入子节点1
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="p"></param>
        private void IncludeChild(TreeNode tn, double p)
        {
            string sql = "select * from TblArea where AreaPId=" + p;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TreeNode newNode = tn.Nodes.Add(reader.GetString(1));
                        IncludeChild(newNode, reader.GetInt32(0));
                    }
                }
                else
                {
                    return;
                }
            }
        }

        #endregion


        private void 删除ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DeleteTreeNodeAndDataInDB(treeView1.SelectedNode);
        }

        /// <summary>
        /// 递归删除节点
        /// </summary>
        /// <param name="treeNode"></param>
        private void DeleteTreeNodeAndDataInDB(TreeNode treeNode)
        {
            string sql = "delete TblArea where AreaId=";
            while (treeNode.Nodes.Count != 0)
            {
                DeleteTreeNodeAndDataInDB(treeNode.Nodes[0]);
            }
            treeNode.Remove();
            SqlHelper.ExecuteNonQuery(sql + treeNode.Tag.ToString(), CommandType.Text);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            contextMenuStrip1.Show(treeView1, e.X, e.Y);
        }






     




    }
}
