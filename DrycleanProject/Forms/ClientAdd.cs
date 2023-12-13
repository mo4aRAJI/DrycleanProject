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
            ClientView Cv = new ClientView();
            Cv.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DrycleanersContext enty = new DrycleanersContext())
            {
                Client client = new Client()
                {
                    Passport = Convert.ToInt64(textBox1.Text),
                    Fullname = textBox2.Text,
                    Phonenumber = textBox3.Text,
                    Discount = Convert.ToInt16(textBox1.Text)
                };
                enty.Clients.Add(client);
                enty.SaveChanges();
            }

        }
    }
}
