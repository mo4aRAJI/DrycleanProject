using Microsoft.EntityFrameworkCore;
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
    public partial class AddressView : Form
    {
        public AddressView()
        {
            InitializeComponent();
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                var q = from view in enty.Addresses.AsNoTracking()
                        select view;
                var viewl = q.ToList();
                dataGridView1.DataSource = viewl;
                dataGridView1.Columns["Id"].HeaderText = "Идентификатор филиала";
                dataGridView1.Columns["name"].HeaderText = "Название";
                dataGridView1.Columns["address1"].HeaderText = "Адрес";
                dataGridView1.Columns["Orders"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddressAdd Ca = new AddressAdd();
            Ca.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
