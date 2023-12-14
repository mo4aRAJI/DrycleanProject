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
    public partial class OrderView : Form
    {
        public OrderView()
        {
            InitializeComponent();
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                var q = from view in enty.Orders.AsNoTracking()
                        select view;
                var viewl = q.ToList();
                dataGridView1.DataSource = viewl;
                dataGridView1.Columns["Id"].HeaderText = "Идентификатор заказа";
                dataGridView1.Columns["EmployeeId"].HeaderText = "Идентификатор сотрудника";
                dataGridView1.Columns["Passport"].HeaderText = "Паспорт клиента";
                dataGridView1.Columns["AddressId"].HeaderText = "Идентификатор филиала";
                dataGridView1.Columns["Date"].HeaderText = "Дата принятия заказа";
                dataGridView1.Columns["Status"].HeaderText = "Статус заказа";
                dataGridView1.Columns["Cost"].HeaderText = "Стоимость услуг";
                dataGridView1.Columns["Address"].Visible = false;
                dataGridView1.Columns["Employee"].Visible = false;
                dataGridView1.Columns["Items"].Visible = false;
                dataGridView1.Columns["PassportNavigation"].Visible = false;
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
                DeleteOrders detailForm = new DeleteOrders(number);
                detailForm.Tag = this;
                detailForm.Show();
                Hide();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OrderAdd Oa = new OrderAdd();
            Oa.Tag = this;
            Oa.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Tf = (TablesForm)Tag;
            Tf.Show();
            Close();
        }

        private void OrderView_VisibleChanged(object sender, EventArgs e)
        {
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                var q = from view in enty.Orders.AsNoTracking()
                        select view;
                var viewl = q.ToList();
                dataGridView1.DataSource = viewl;
                dataGridView1.Columns["Id"].HeaderText = "Идентификатор заказа";
                dataGridView1.CellClick += dataGridView1_CellContentClick;
            }
        }
    }
}
