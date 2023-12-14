using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrycleanProject.Forms
{
    public partial class TablesForm : Form
    {
        public TablesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderView Ov = new OrderView();
            Ov.Tag = this;
            Ov.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ItemView Iv = new ItemView();
            Iv.Tag = this;
            Iv.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmployeeView Ev = new EmployeeView();
            Ev.Tag = this;
            Ev.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClientView Cv = new ClientView();
            Cv.Tag = this;
            Cv.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddressView Aw = new AddressView();
            Aw.Tag = this;
            Aw.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var main = (Main)Tag;
            main.Show();
            Close();
        }
    }
}
