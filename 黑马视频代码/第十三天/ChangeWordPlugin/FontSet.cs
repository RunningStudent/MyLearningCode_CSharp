using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChangeWordPlugin
{
    public partial class FontSet : Form
    {
        private TextBox txtB;

        public FontSet()
        {
            InitializeComponent();
        }

        public FontSet(TextBox txtB)
        {
            InitializeComponent();
            this.txtB = txtB;
        }
        
        private void btSure_Click(object sender, EventArgs e)
        {
            this.txtB.Font = new Font(cBFont.Text, float.Parse(cBSize.Text));
            this.Close();
        }

        private void FontSet_Load(object sender, EventArgs e)
        {
            cBFont.SelectedIndex = 0;
            cBSize.SelectedIndex = 0;
        }
    }
}
