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
    public partial class DeleteItem : Form
    {
        private string number;
        public DeleteItem(string cc)
        {
            InitializeComponent();
            this.number = cc;
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                List<string> names = enty.Addresses.AsNoTracking().Select(x => x.Name).ToList();
                List<string> address = enty.Addresses.AsNoTracking().Select(x => x.Address1).ToList();
                comboBox2.Items.Clear();
                comboBox1.Items.Clear();
                var combinedList = names.Zip(address, (name, addr) => new { Name = name, Address = addr });
                foreach (var elem in combinedList)
                {
                    comboBox1.Items.Add(elem.Name);
                    comboBox2.Items.Add(elem.Address);
                }
            }
        }

        private bool AreTextBoxesFilled()
        {
            // Проверка, что все TextBox не пусты
            return !string.IsNullOrWhiteSpace(comboBox1.Text) &&
                   !string.IsNullOrWhiteSpace(comboBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                long addressId = Convert.ToInt16(number);
                // Найти заказы для данного клиента
                var orders = enty.Orders.Where(o => o.AddressId == addressId).ToList();
                // Удалить связанные записи из таблицы items
                var orderIds = orders.Select(o => o.Id);
                var itemsToDelete = enty.Items.Where(i => orderIds.Contains(i.OrderId)).ToList();
                enty.Items.RemoveRange(itemsToDelete);
                // Удалить заказы
                enty.Orders.RemoveRange(orders);
                // Удалить клиента
                var addressToDelete = enty.Addresses.FirstOrDefault(c => c.Id == addressId);
                if (addressToDelete != null)
                {
                    enty.Addresses.Remove(addressToDelete);
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
                short addressId = Convert.ToInt16(number);
                // Создаем объект Address с обновленными значениями
                Address updatedAddress = new Address()
                {
                    Id = addressId,
                    Name = comboBox1.Text,
                    Address1 = comboBox2.Text
                };
                // Помечаем запись как измененную и сохраняем изменения
                enty.Addresses.Update(updatedAddress);
                enty.SaveChanges();
                MessageBox.Show("Запись изменена!", "Изменение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
