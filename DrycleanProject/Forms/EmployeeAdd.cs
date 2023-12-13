using DrycleanProject.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrycleanProject
{
    public partial class EmployeeAdd : Form
    {
        public EmployeeAdd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeView Ev = new EmployeeView();
            Ev.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                Employee employee = new Employee()
                {
                    Id = Convert.ToInt16(textBox1.Text),
                    Fullname = textBox2.Text,
                    Experience = Convert.ToInt16(textBox1.Text)
                };
                enty.Employees.Add(employee);
                enty.SaveChanges();
            }

        }
    }
}
