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
    public partial class EmployeeView : Form
    {
        public EmployeeView()
        {
            InitializeComponent();
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                var q = from view in enty.Employees.AsNoTracking()
                        select view;
                var viewl = q.ToList();
                dataGridView1.DataSource = viewl;
                dataGridView1.Columns["Id"].HeaderText = "Идентификатор";
                dataGridView1.Columns["Fullname"].HeaderText = "ФИО";
                dataGridView1.Columns["Experience"].HeaderText = "Опыт работы (лет)";
                dataGridView1.Columns["Orders"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeAdd Ea = new EmployeeAdd();
            Ea.Show();
            Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            Hide();
        }
    }
}
