using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DrycleanProject.Forms
{
    public partial class OrderAdd : Form
    {
        public OrderAdd()
        {
            InitializeComponent();
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                List<string> addresses = enty.Addresses.AsNoTracking().Select(x => x.Address1).ToList();
                comboBox1.Items.Clear();
                foreach (var elem in addresses)
                {
                    comboBox1.Items.Add(elem);
                }
                List<long> clients = enty.Clients.AsNoTracking().Select(x => x.Passport).ToList();
                comboBox2.Items.Clear();
                foreach (var elem in clients)
                {
                    comboBox2.Items.Add(elem);
                }
                List<string> employees = enty.Employees.AsNoTracking().Select(x => x.Fullname).ToList();
                comboBox3.Items.Clear();
                foreach (var elem in employees)
                {
                    comboBox3.Items.Add(elem);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                short addressId = enty.Addresses.AsNoTracking()
                               .Where(x => x.Address1 == comboBox1.Text)
                               .Select(x => x.Id)
                               .FirstOrDefault();
                int employeeId = enty.Employees.AsNoTracking()
                               .Where(x => x.Fullname == comboBox3.Text)
                               .Select(x => x.Id)
                               .FirstOrDefault();
                long clientId = 0;
                string comboBoxText = comboBox3.Text;
                if (enty.Clients.AsNoTracking().Any(x => x.Passport == Convert.ToInt64(comboBox2.Text)))
                {
                    Order order = new Order()
                    {
                        Id = Convert.ToInt16(textBox1.Text),
                        EmployeeId = employeeId,
                        Passport = Convert.ToInt64(comboBox2.Text),
                        AddressId = addressId,
                        Status = "Принят в обработку",
                        Cost = Convert.ToInt16(textBox2.Text)
                    };
                    enty.Orders.Add(order);
                    enty.SaveChanges();
                }
                else
                {
                    ClientAdd Ca = new ClientAdd();
                    Ca.Show();
                    MessageBox.Show("Добавьте клиента перед добавлением заказа", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Не устанавливаем shouldContinue в true, чтобы остановить выполнение кода до явного продолжения.
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

