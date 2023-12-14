using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Devices;
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
    public partial class DeleteEmployee : Form
    {
        private string number;
        public DeleteEmployee(string cc)
        {
            InitializeComponent();
            this.number = cc;
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                List<string> names = enty.Employees.AsNoTracking().Select(x => x.Fullname).ToList();
                List<short> exp = enty.Employees.AsNoTracking().Select(x => x.Experience).ToList();
                comboBox2.Items.Clear();
                comboBox1.Items.Clear();
                var combinedList = names.Zip(names, (name, exp) => new { Name = name, Experience = exp });
                foreach (var elem in combinedList)
                {
                    comboBox1.Items.Add(elem.Name);
                    comboBox2.Items.Add(elem.Experience);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                long employeeId = Convert.ToInt16(number);
                // Найти заказы для данного клиента
                var orders = enty.Orders.Where(o => o.EmployeeId == employeeId).ToList();
                // Удалить связанные записи из таблицы items
                var orderIds = orders.Select(o => o.Id);
                var itemsToDelete = enty.Items.Where(i => orderIds.Contains(i.OrderId)).ToList();
                enty.Items.RemoveRange(itemsToDelete);
                // Удалить заказы
                enty.Orders.RemoveRange(orders);
                // Удалить сотрудника
                var employeeToDelete = enty.Employees.FirstOrDefault(c => c.Id == employeeId);
                if (employeeToDelete != null)
                {
                    enty.Employees.Remove(employeeToDelete);
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
                short employeeId = Convert.ToInt16(number);
                // Создаем объект Client с обновленными значениями
                Employee updatedEmployee = new Employee()
                {
                    Id = employeeId,
                    Fullname = comboBox1.Text,
                    Experience = Convert.ToInt16(comboBox2.Text)
                };
                // Помечаем запись как измененную и сохраняем изменения
                enty.Employees.Update(updatedEmployee);
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
