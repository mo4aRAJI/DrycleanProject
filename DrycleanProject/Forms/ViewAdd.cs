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
    public partial class ViewAdd : Form
    {
        public ViewAdd()
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
                int orderId = Enumerable.Range(1, int.MaxValue)
                    .Except(enty.Orders.AsNoTracking().Select(x => x.Id))
                    .FirstOrDefault();

                textBox1.Text = orderId.ToString();
            }
        }

        private bool AreTextBoxesFilled()
        {
            // Проверка, что все TextBox не пусты
            return !string.IsNullOrWhiteSpace(textBox1.Text) &&
                   !string.IsNullOrWhiteSpace(comboBox1.Text) &&
                   !string.IsNullOrWhiteSpace(comboBox2.Text) &&
                   !string.IsNullOrWhiteSpace(comboBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AreTextBoxesFilled())
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
                            Status = "Принят в обработку"
                        };
                        enty.Orders.Add(order);
                        enty.SaveChanges();
                        MessageBox.Show("Запись добавлена!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ItemAdd Ia = new ItemAdd();
                        Ia.Tag = this;
                        Ia.Show();
                        Close();
                    }
                    else
                    {
                        ClientAdd Ca = new ClientAdd();
                        Ca.Tag = this;
                        Ca.Show();
                        MessageBox.Show("Добавьте клиента перед добавлением заказа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Не устанавливаем shouldContinue в true, чтобы остановить выполнение кода до явного продолжения.
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Vf = (ViewForm)Tag;
            Vf.Show();
            Close();
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
