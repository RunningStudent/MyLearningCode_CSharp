using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 话术脚本.BLL;
using 话术脚本.Model;

namespace 话术脚本.UI
{
    public partial class fmAddNode : Form
    {
        public fmAddNode()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 构造函数获取传入的委托方法,以及数据的parentId
        /// </summary>
        /// <param name="method"></param>
        /// <param name="pid"></param>
        public fmAddNode(Action method,int pid)
            : this()
        {
            this._method = method;
            this._pid = pid;

        }
        private T_ScriptBLL bll = new T_ScriptBLL();
        private int _pid;
        private Action _method;

        private void button1_Click(object sender, EventArgs e)
        {
            Scripts s=new Scripts();
            s.Msg=textBox2.Text;
            s.ParentId=_pid;
            s.Title=textBox1.Text;
            bll.Insert(s);
            //更新TreeView
            _method();
            this.Close();
        }
    }
}
