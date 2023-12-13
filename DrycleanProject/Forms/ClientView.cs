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
    public partial class ClientView : Form
    {
        public ClientView()
        {
            InitializeComponent();
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                var q = from view in enty.Clients.AsNoTracking()
                        select view;
                var viewl = q.ToList();
                dataGridView1.DataSource = viewl;
                dataGridView1.Columns["Passport"].HeaderText = "Серия и номер паспорта";
                dataGridView1.Columns["Fullname"].HeaderText = "ФИО";
                dataGridView1.Columns["Phonenumber"].HeaderText = "Номер телефона";
                dataGridView1.Columns["Discount"].HeaderText = "Скидка (в процентах)";
                dataGridView1.Columns["Orders"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientAdd Ca = new ClientAdd();
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
    }
}
