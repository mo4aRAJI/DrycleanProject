using Microsoft.EntityFrameworkCore;
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
    public partial class ViewForm : Form
    {

        public ViewForm()
        {
            InitializeComponent();
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                var q = from item in enty.Items.AsNoTracking()
                        join order in enty.Orders.AsNoTracking() on item.OrderId equals order.Id
                        join client in enty.Clients.AsNoTracking() on order.Passport equals client.Passport
                        join employee in enty.Employees.AsNoTracking() on order.EmployeeId equals employee.Id
                        join address1 in enty.Addresses.AsNoTracking() on order.AddressId equals address1.Id
                        orderby order.Id
                        select new ResultForm()
                        {
                            orderId = order.Id,
                            ItemId = item.ItemId,
                            TypeC = item.Clothtype,
                            TypeF = item.Fabrictype,
                            Color = item.Color,
                            Passport = client.Fullname,
                            Employee = employee.Fullname,
                            Address = address1.Address1,
                            Date = order.Date,
                            Status = order.Status,
                            Cost = order.Cost
                        };

                var viewl = q.ToList();
                dataGridView1.DataSource = viewl;

                // Проверяем наличие столбцов и значения null перед установкой заголовков
                if (dataGridView1.Columns["orderId"] != null) dataGridView1.Columns["orderId"].HeaderText = "Идентификатор заказа";
                if (dataGridView1.Columns["ItemId"] != null) dataGridView1.Columns["ItemId"].HeaderText = "Идентификатор предмета";
                if (dataGridView1.Columns["TypeC"] != null) dataGridView1.Columns["TypeC"].HeaderText = "Тип вещи";
                if (dataGridView1.Columns["TypeF"] != null) dataGridView1.Columns["TypeF"].HeaderText = "Тип ткани";
                if (dataGridView1.Columns["Color"] != null) dataGridView1.Columns["Color"].HeaderText = "Цвет";
                if (dataGridView1.Columns["Passport"] != null) dataGridView1.Columns["Passport"].HeaderText = "ФИО клиента";
                if (dataGridView1.Columns["Employee"] != null) dataGridView1.Columns["Employee"].HeaderText = "ФИО сотрудника";
                if (dataGridView1.Columns["Address"] != null) dataGridView1.Columns["Address"].HeaderText = "Адрес филиала";
                if (dataGridView1.Columns["Date"] != null) dataGridView1.Columns["Date"].HeaderText = "Дата принятия заказа";
                if (dataGridView1.Columns["Status"] != null) dataGridView1.Columns["Status"].HeaderText = "Статус заказа";
                if (dataGridView1.Columns["Cost"] != null) dataGridView1.Columns["Cost"].HeaderText = "Стоимость услуг";

                List<string> address = enty.Addresses.AsNoTracking().Select(x => x.Address1).ToList();
                comboBox1.Items.Clear();
                foreach (var elem in address)
                {
                    comboBox1.Items.Add(elem);
                }
                List<string> employees = enty.Employees.AsNoTracking().Select(x => x.Fullname).ToList();
                comboBox2.Items.Clear();
                foreach (var elem in employees)
                {
                    comboBox2.Items.Add(elem);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != null && comboBox2.Text == "")
            {
                using (DrycleanersContext enty = new DrycleanersContext())
                {
                    short addressId = enty.Addresses.AsNoTracking()
                        .Where(x => x.Address1 == comboBox1.Text)
                        .Select(x => x.Id)
                        .FirstOrDefault();
                    var q = from item in enty.Items.AsNoTracking()
                            join order in enty.Orders.AsNoTracking() on item.OrderId equals order.Id
                            join client in enty.Clients.AsNoTracking() on order.Passport equals client.Passport
                            join employee in enty.Employees.AsNoTracking() on order.EmployeeId equals employee.Id
                            join address in enty.Addresses.AsNoTracking() on order.AddressId equals address.Id
                            where address.Id == addressId
                            orderby order.Id
                            select new ResultForm()
                            {
                                orderId = order.Id,
                                ItemId = item.ItemId,
                                TypeC = item.Clothtype,
                                TypeF = item.Fabrictype,
                                Color = item.Color,
                                Passport = client.Fullname,
                                Employee = employee.Fullname,
                                Address = address.Address1,
                                Date = order.Date,
                                Status = order.Status,
                                Cost = order.Cost
                            };

                    var viewl = q.ToList();
                    dataGridView1.DataSource = viewl;
                }
            }
            if (comboBox2.Text != null && comboBox1.Text == "")
            {
                using (DrycleanersContext enty = new DrycleanersContext())
                {
                    int employeeId = enty.Employees.AsNoTracking()
                        .Where(x => x.Fullname == comboBox2.Text)
                        .Select(x => x.Id)
                        .FirstOrDefault();
                    var q = from item in enty.Items.AsNoTracking()
                            join order in enty.Orders.AsNoTracking() on item.OrderId equals order.Id
                            join client in enty.Clients.AsNoTracking() on order.Passport equals client.Passport
                            join employee in enty.Employees.AsNoTracking() on order.EmployeeId equals employee.Id
                            join address in enty.Addresses.AsNoTracking() on order.AddressId equals address.Id
                            where employee.Id == employeeId
                            orderby order.Id
                            select new ResultForm()
                            {
                                orderId = order.Id,
                                ItemId = item.ItemId,
                                TypeC = item.Clothtype,
                                TypeF = item.Fabrictype,
                                Color = item.Color,
                                Passport = client.Fullname,
                                Employee = employee.Fullname,
                                Address = address.Address1,
                                Date = order.Date,
                                Status = order.Status,
                                Cost = order.Cost
                            };

                    var viewl = q.ToList();
                    dataGridView1.DataSource = viewl;
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            var main = (Main)Tag;
            main.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewAdd Va = new ViewAdd();
            Va.Tag = this;
            Va.Show();
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {

        }
    }
}
