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
    public partial class ClientAdd : Form
    {
        public ClientAdd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool AreTextBoxesFilled()
        {
            // Проверка, что все TextBox не пусты
            return !string.IsNullOrWhiteSpace(textBox1.Text) &&
                   !string.IsNullOrWhiteSpace(textBox2.Text) &&
                   !string.IsNullOrWhiteSpace(textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AreTextBoxesFilled())
            {
                using (DrycleanersContext enty = new DrycleanersContext())
                {
                    short finalValue;
                    if (!string.IsNullOrWhiteSpace(textBox4.Text))
                    {
                        finalValue = Convert.ToInt16(textBox4.Text);
                    }
                    else
                    {
                        finalValue = 0;
                    }
                    Client client = new Client()
                    {
                        Passport = Convert.ToInt64(textBox1.Text),
                        Fullname = textBox2.Text,
                        Phonenumber = textBox3.Text,
                        Discount = finalValue
                    };
                    enty.Clients.Add(client);
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
            if (Char.IsLetter(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
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
