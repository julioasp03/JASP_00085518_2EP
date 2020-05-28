using System;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class CreateBuisness : UserControl
    {
        private UserControl current = null;
        public CreateBuisness()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            current = new Administrador();
            tableLayoutPanel1.Controls.Add(current,0,0);
            tableLayoutPanel1.SetColumnSpan(current, 3);
            tableLayoutPanel1.SetRowSpan(current, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("")||textBox2.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }
            else
            {
                ConnectioBD.ExecuteNonQuery($"INSERT INTO BUSINESS(name,description) VALUES('{textBox1.Text}','{textBox2.Text}')");
                MessageBox.Show("Negocio agregado");
            }
        }
    }
}