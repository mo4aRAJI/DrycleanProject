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
    public partial class DeleteItems : Form
    {
        private string number;
        private string numb;
        public DeleteItems(string cc, string dd)
        {
            InitializeComponent();
            this.number = cc;
            this.numb = dd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                long orderId = Convert.ToInt16(number);
                // Найти все связанные записи в таблице Items
                var itemsToDelete = enty.Items.Where(i => i.OrderId == orderId).ToList();
                // Удалить связанные записи из таблицы Items
                enty.Items.RemoveRange(itemsToDelete);
                // Найти заказы для удаления
                var ordersToDelete = enty.Orders.Where(o => o.Id == orderId).ToList();
                // Удалить заказы
                enty.Orders.RemoveRange(ordersToDelete);
                // Сохранить изменения в базе данных
                enty.SaveChanges();
                MessageBox.Show("Запись удалена!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                short orderId = Convert.ToInt16(number);
                short itemId = Convert.ToInt16(numb);
                // Создаем объект Order с обновленными значениями
                Item updatedItem = new Item()
                {
                    OrderId = orderId,
                    ItemId = itemId,
                    Clothtype = comboBox1.Text,
                    Fabrictype = comboBox2.Text,
                    Color = comboBox3.Text
                };
                // Помечаем запись как измененную и сохраняем изменения
                enty.Items.Update(updatedItem);
                enty.SaveChanges();
                MessageBox.Show("Запись изменена!", "Изменение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            ItemView Iv = new ItemView();
            Iv.Show();
            Close();
        }
    }
}
