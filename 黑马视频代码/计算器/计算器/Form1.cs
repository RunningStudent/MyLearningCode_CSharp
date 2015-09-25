using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 计算器
{
    public partial class Form1 : Form
    {
        private bool ls = false;//连续运算模式
        private string _show = "";
        private string _operate;//运算符
        public Form1()
        {
            InitializeComponent();
        }
        #region 数字按钮,小数点
        private void button1_Click(object sender, EventArgs e)
        {
            _show+= "1";
            textBox1.Text = _show;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _show += "2";
            textBox1.Text = _show;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _show += "3";
            textBox1.Text = _show;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _show += "4";
            textBox1.Text = _show;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _show += "5";
            textBox1.Text = _show;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _show += "6";
            textBox1.Text = _show;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _show += "7";
            textBox1.Text = _show;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _show += "8";
            textBox1.Text = _show;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _show += "9";
            textBox1.Text = _show;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (_show == "")
                return;
            _show += "0";
            textBox1.Text = _show;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (_show == "")
                return;
            _show += ".";
            textBox1.Text = _show;
        }
        #endregion


        private Calculator c;

        private void Form1_Load(object sender, EventArgs e)
        {
            c = new Calculator();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Calcute();
            _operate = "+";
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            Calcute();
            _operate = "-";
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            Calcute();
            _operate = "*";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            Calcute();
            _operate = "/";
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (_show == "")
                return;
            c._number2 = double.Parse(_show);
            _show = c.calculate(_operate).ToString();
            ls = false;
            textBox1.Text = _show;
        }

        private void Calcute()
        {
            if (_show == "")
                return;
            if (ls == false)
            {
                c._number1 = double.Parse(_show);
                ls = true;
                _show = "";
            }
            else
            {
                c._number2 = double.Parse(_show); ;
                _show = c.calculate(_operate).ToString();
                c._number1 = double.Parse(_show);
                textBox1.Text = _show;
                _show = "";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ls = false;
            _show = "";
            textBox1.Text = "";
        }
    }
}
