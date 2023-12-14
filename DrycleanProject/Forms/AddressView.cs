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
                DeleteItem detailForm = new DeleteItem(number);
                detailForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddressAdd Ca = new AddressAdd();
            Ca.Tag = this;
            Ca.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Tf = (TablesForm)Tag;
            Tf.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
