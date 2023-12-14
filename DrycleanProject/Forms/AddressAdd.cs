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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DrycleanProject
{
    public partial class AddressAdd : Form
    {
        public AddressAdd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Aw = (AddressView)Tag;
            Aw.Tag = this;
            Aw.Show();
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
                    Address address = new Address()
                    {
                        Id = Convert.ToInt16(textBox1.Text),
                        Name = textBox2.Text,
                        Address1 = textBox3.Text
                    };
                    enty.Addresses.Add(address);
                    enty.SaveChanges();
                    MessageBox.Show("Запись добавлена!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

