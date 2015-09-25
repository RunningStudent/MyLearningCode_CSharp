using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 话术脚本.Model;
using 话术脚本.BLL;

namespace 话术脚本.UI
{
    public partial class fmEdit : Form
    {
        public fmEdit()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 构造函数,保存主窗体的数据,已经更新数据的方法
        /// </summary>
        /// <param name="s"></param>
        /// <param name="m"></param>
        public fmEdit(Scripts s,Action<Scripts> m)
            : this()
        {
            this.model = s;
            this._method = m;
        }
        Action<Scripts> _method;
        Scripts model;


        /// <summary>
        /// 窗体加载把信息加载到编辑窗口中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmEdit_Load(object sender, EventArgs e)
        {
            txtEdit.Text = model.Msg;
            txtTitle.Text = model.Title;
        }


        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            model.Title= txtTitle.Text.Trim();
            model.Msg= txtEdit.Text.Trim();
            T_ScriptBLL bll = new T_ScriptBLL();
            if (bll.Update(model)>0)
            {
                MessageBox.Show("更新成功");
            }
            
            _method(model);
            this.Close();
        }

    }
}
