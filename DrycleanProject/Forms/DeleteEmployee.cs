using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Devices;
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
    public partial class DeleteEmployee : Form
    {
        public DeleteEmployee()
        {
            InitializeComponent();
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                var q = from audit in enty.Employees.AsNoTracking()
                select audit;
                var audtil = q.ToList();
                dataGridView1.DataSource = audtil;
                dataGridView1.Columns["Id"].HeaderText = "Идентификатор";
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
                DRFrom detailForm = new DRFrom(number);
                detailForm.Show();
            }
        }
    }
}
