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
            AddressView Aw = new AddressView();
            Aw.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
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
            }

        }
    }
}

