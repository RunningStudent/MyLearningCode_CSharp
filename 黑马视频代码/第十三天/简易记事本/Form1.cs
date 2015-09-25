using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using EditPluginInterface;

namespace 简易记事本
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载插件程序集
            string[] plugins = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "addons"));
            foreach (string item in plugins)
            {
                //遍历插件,载入插件
                Assembly assembly = Assembly.LoadFile(item);
                //拿到插件程序集中实现EditPluginInterface的类
                Type[] types = assembly.GetTypes();
                //遍历每个类,先判断是否能被EditPlusInterface引用且不为抽象类
                Type pluginType = typeof(EditInterface);
                foreach (Type item1 in types)
                {
                    if (pluginType.IsAssignableFrom(item1) && !item1.IsAbstract)
                    {
                        //找到符合条件的类,把它用接口引用
                        EditInterface edit = (EditInterface)Activator.CreateInstance(item1);
                        //给菜单添加菜单项
                        ToolStripItem menuItem = tsmiEdit.DropDownItems.Add(edit.name);
                        //插件功能插件写,但是窗体应启动它,该给菜单项添加事件
                        menuItem.Click += new EventHandler(menuItem_Click);
                        menuItem.Tag=edit;
                    }
                }
            }
        }

        void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem)sender;
            EditInterface edit = (EditInterface)menuItem.Tag;
            edit.Run(this.tBEdit);
        }
    }
}
