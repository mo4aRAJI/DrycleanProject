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
                dataGridView1.CellClick += dataGridView1_CellContentClick;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Получите данные из выделенной строки
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string number = selectedRow.Cells[0].Value.ToString();


                // Создайте новую форму и передайте данные
                DeleteClient detailForm = new DeleteClient(number);
                detailForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientAdd Ca = new ClientAdd();
            Ca.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Tf = (TablesForm)Tag;
            Tf.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
