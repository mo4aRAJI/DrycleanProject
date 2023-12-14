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
    public partial class DeleteClient : Form
    {
        private string number;
        public DeleteClient(string cc)
        {
            InitializeComponent();
            this.number = cc;
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                List<string> names = enty.Clients.AsNoTracking().Select(x => x.Fullname).ToList();
                List<string> phone = enty.Clients.AsNoTracking().Select(x => x.Phonenumber).ToList();
                comboBox2.Items.Clear();
                comboBox1.Items.Clear();
                var combinedList = names.Zip(phone, (name, phone) => new { Name = name, Phone = phone });
                foreach (var elem in combinedList)
                {
                    comboBox1.Items.Add(elem.Name);
                    comboBox2.Items.Add(elem.Phone);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                long clientPassport = Convert.ToInt64(number);
                // Найти заказы для данного клиента
                var orders = enty.Orders.Where(o => o.Passport == clientPassport).ToList();
                // Удалить связанные записи из таблицы items
                var orderIds = orders.Select(o => o.Id);
                var itemsToDelete = enty.Items.Where(i => orderIds.Contains(i.OrderId)).ToList();
                enty.Items.RemoveRange(itemsToDelete);
                // Удалить заказы
                enty.Orders.RemoveRange(orders);
                // Удалить клиента
                var clientToDelete = enty.Clients.FirstOrDefault(c => c.Passport == clientPassport);
                if (clientToDelete != null)
                {
                    enty.Clients.Remove(clientToDelete);
                }
                // Сохранить изменения в базе данных
                enty.SaveChanges();
                MessageBox.Show("Запись удалена!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                long clientPassport = Convert.ToInt64(number);
                // Создаем объект Client с обновленными значениями
                Client updatedClient = new Client()
                {
                    Passport = clientPassport,
                    Fullname = comboBox1.Text,
                    Phonenumber = comboBox2.Text,
                    Discount = Convert.ToInt16(textBox1.Text)
                };
                // Помечаем запись как измененную и сохраняем изменения
                enty.Clients.Update(updatedClient);
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
