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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DrycleanProject.Forms
{
    public partial class DeleteOrders : Form
    {
        private string number;
        public DeleteOrders(string cc)
        {
            InitializeComponent();
            this.number = cc;
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                List<string> nameEmployee = enty.Employees.AsNoTracking().Select(x => x.Fullname).ToList();
                List<string> nameClient = enty.Clients.AsNoTracking().Select(x => x.Fullname).ToList();
                List<string> address = enty.Addresses.AsNoTracking().Select(x => x.Address1).ToList();
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                int count = Math.Min(Math.Min(nameEmployee.Count, nameClient.Count), address.Count);
                for (int i = 0; i < count; i++)
                {
                    comboBox1.Items.Add(nameEmployee[i]);
                    comboBox2.Items.Add(nameClient[i]);
                    comboBox3.Items.Add(address[i]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                long orderId = Convert.ToInt16(number);
                var orders = enty.Orders.Where(o => o.Id == orderId).ToList();
                // Удалить связанные записи из таблицы items
                var orderIds = orders.Select(o => o.Id);
                var itemsToDelete = enty.Items.Where(i => orderIds.Contains(i.OrderId)).ToList();
                enty.Items.RemoveRange(itemsToDelete);
                // Удалить заказы
                enty.Orders.RemoveRange(orders);
                // Сохранить изменения в базе данных
                enty.SaveChanges();
                MessageBox.Show("Запись удалена!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderView Ov = new OrderView();
            Ov.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                int employeeId = enty.Employees.AsNoTracking()
                    .Where(x => x.Fullname == comboBox1.Text)
                    .Select(x => x.Id)
                    .FirstOrDefault();
                long clientId = enty.Clients.AsNoTracking()
                    .Where(x => x.Fullname == comboBox2.Text)
                    .Select(x => x.Passport)
                    .FirstOrDefault();
                short addressId = enty.Addresses.AsNoTracking()
                    .Where(x => x.Address1 == comboBox3.Text)
                    .Select(x => x.Id)
                    .FirstOrDefault();
                short orderId = Convert.ToInt16(number);
                // Создаем объект Order с обновленными значениями
                Order updatedOrder = new Order()
                {
                    Id = orderId,
                    EmployeeId = employeeId,
                    Passport = clientId,
                    AddressId = addressId,
                    Date = DateTime.Now.ToUniversalTime(),
                    Status = comboBox4.Text,
                    Cost = Convert.ToInt16(textBox1.Text)
                };
                // Помечаем запись как измененную и сохраняем изменения
                enty.Orders.Update(updatedOrder);
                enty.SaveChanges();
                MessageBox.Show("Запись изменена!", "Изменение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                // Разрешаем ввод цифр и управляющих символов (например, Backspace)
            }
            else
            {
                // Запрещаем ввод других символов
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',' || Char.IsControl(e.KeyChar))
            {
                // Разрешаем ввод букв и управляющих символов (например, Backspace)
            }
            else
            {
                // Запрещаем ввод других символов
                e.Handled = true;
            }
        }
    }

}

