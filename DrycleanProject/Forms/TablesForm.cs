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
            OrderAdd Oa = new OrderAdd();
            Oa.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientAdd Ca = new ClientAdd();
            Ca.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmployeeView Ev = new EmployeeView();
            Ev.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClientView Cv = new ClientView();
            Cv.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddressView Aw = new AddressView();
            Aw.Show();
            Hide();
        }
    }
}
