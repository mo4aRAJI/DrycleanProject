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
    public partial class ItemAdd : Form
    {
        public ItemAdd()
        {
            InitializeComponent();
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                List<int> id = enty.Orders.AsNoTracking().Select(x => x.Id).Distinct().ToList();
                comboBox1.Items.Clear();
                foreach (var elem in id)
                {
                    comboBox1.Items.Add(elem);
                }
            }
        }
        private bool AreTextBoxesFilled()
        {
            // Проверка, что все TextBox не пусты
            return !string.IsNullOrWhiteSpace(textBox1.Text) &&
                   !string.IsNullOrWhiteSpace(comboBox1.Text) &&
                   !string.IsNullOrWhiteSpace(comboBox2.Text) &&
                   !string.IsNullOrWhiteSpace(comboBox3.Text) &&
                   !string.IsNullOrWhiteSpace(comboBox4.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                int orderId = Convert.ToInt32(comboBox1.Text); // Значение выбранное в comboBox1

                int itemId = Enumerable.Range(1, int.MaxValue)
                    .Except(enty.Items.AsNoTracking().Where(x => x.OrderId == orderId).Select(x => x.ItemId))
                    .FirstOrDefault();

                // Находим скидку клиента

                var orderInfo = enty.Orders
                    .Where(o => o.Id == orderId)
                    .Select(o => new
                    {
                        Passport = o.Passport,
                        Discount = enty.Clients
                            .Where(c => c.Passport == o.Passport)
                            .Select(c => c.Discount ?? -99)
                            .FirstOrDefault()
                    })
                    .FirstOrDefault();
                double discountedCost; int discount;
                int itemsCost = 500;
                if (orderInfo.Discount != -99)
                {
                    discount = Convert.ToInt32(orderInfo.Discount);
                    discountedCost = itemId * itemsCost * (1 - discount * 0.01); // Рассчитываем с учетом скидки
                }
                else
                {
                    discountedCost = itemsCost * itemId;
                }

                // Записываем значение в textBox1
                textBox1.Text = itemId.ToString();

                // Рассчитываем и записываем значение в столбец cost таблицы orders
                Order orderToUpdate = enty.Orders.FirstOrDefault(o => o.Id == orderId);
                if (orderToUpdate != null)
                {
                    orderToUpdate.Cost = Convert.ToInt32(discountedCost);
                    enty.SaveChanges();
                }
            }
            if (AreTextBoxesFilled())
            {
                using (DrycleanersContext enty = new DrycleanersContext())
                {
                    Item item = new Item()
                    {
                        OrderId = Convert.ToInt32(comboBox1.Text),
                        ItemId = Convert.ToInt16(textBox1.Text),
                        Clothtype = comboBox2.Text,
                        Fabrictype = comboBox3.Text,
                        Color = comboBox4.Text
                    };
                    enty.Items.Add(item);
                    enty.SaveChanges();
                    MessageBox.Show("Запись добавлена!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля! Исключением является поле Скидка.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
