using DrycleanProject.Forms;
using Microsoft.EntityFrameworkCore;

namespace DrycleanProject
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderAdd Oa = new OrderAdd();
            Oa.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientAdd Ca = new ClientAdd();
            Ca.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteEmployee De = new DeleteEmployee();
            De.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TablesForm Tf = new TablesForm();
            Tf.Show();
            Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
