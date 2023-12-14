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
    public partial class ItemView : Form
    {
        public ItemView()
        {
            InitializeComponent();
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                var q = from view in enty.Items.AsNoTracking()
                        select view;
                var viewl = q.ToList();
                dataGridView1.DataSource = viewl;
                dataGridView1.Columns["OrderId"].HeaderText = "Идентификатор заказа";
                dataGridView1.Columns["ItemId"].HeaderText = "Идентификатор предмета";
                dataGridView1.Columns["Clothtype"].HeaderText = "Тип вещи";
                dataGridView1.Columns["Fabrictype"].HeaderText = "Тип ткани";
                dataGridView1.Columns["Color"].HeaderText = "Цвет";
                dataGridView1.Columns["Order"].Visible = false;
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
                string numb = selectedRow.Cells.Count > 1 && selectedRow.Cells[1].Value != null
                    ? selectedRow.Cells[1].Value.ToString()
                    : string.Empty;


                // Создайте новую форму и передайте данные
                DeleteItems detailForm = new DeleteItems(number, numb);
                detailForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ItemAdd Ia = new ItemAdd();
            Ia.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Tf = (TablesForm)Tag;
            Tf.Show();
            Hide();
        }
    }
}
