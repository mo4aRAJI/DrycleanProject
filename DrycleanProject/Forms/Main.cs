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

        private void button4_Click(object sender, EventArgs e)
        {
            TablesForm Tf = new TablesForm();
            Tf.Tag = this;
            Tf.Show();
            Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ViewForm Vf = new ViewForm();
            Vf.Tag = this;
            Vf.Show();
            Hide();
        }
    }
}
