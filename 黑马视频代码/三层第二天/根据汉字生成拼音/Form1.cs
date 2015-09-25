using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.International.Converters.PinYinConverter;
using System.Data.SqlClient;

namespace 根据汉字生成拼音
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            textBox2.Text = GetPinYin(input);
        }

        /// <summary>
        /// 根据字符串获得拼音
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string GetPinYin(string input)
        {
            StringBuilder resultSb = new StringBuilder();
            foreach (var item in input)
            {
                //判断是否是汉字
                if (ChineseChar.IsValidChar(item))
                {
                    ChineseChar c = new ChineseChar(item);
                    //一般情况下回输出拼音加一个数字,下面把这个数字去掉
                    resultSb.Append(c.Pinyins[0].Substring(0,c.Pinyins[0].Length-1)+" ");
                }
            }
            return resultSb.ToString().ToLower();
        }

        /// <summary>
        /// 点击,给数据库添加拼音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select CC_AutoId,CC_CustomerName from T_Customers";
            string sqlInert = "update T_Customers set CC_CustomerPY=@py where CC_AutoId=@autoId ";
            using (SqlDataReader reader=SqlHelper.ExecuteReader(sql,CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int autoId = reader.GetInt32(0);
                        string py = GetPinYin(reader.GetString(1));
                        SqlParameter p = new SqlParameter("@py", py);
                        SqlParameter id = new SqlParameter("@autoId", autoId);
                        SqlHelper.ExecuteNonQuery(sqlInert, CommandType.Text, p, id);
                    }
                }
            }
            MessageBox.Show("ok");
        }

        
    }
}
