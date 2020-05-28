using System;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class Order : UserControl
    {
        private UserControl current = null;
        public Order()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            current = new Usuario();
            tableLayoutPanel1.Controls.Add(current,0,0);
            tableLayoutPanel1.SetColumnSpan(current, 3);
            tableLayoutPanel1.SetRowSpan(current, 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            current = new CreateOrder();
            tableLayoutPanel1.Controls.Add(current,0,0);
            tableLayoutPanel1.SetColumnSpan(current, 3);
            tableLayoutPanel1.SetRowSpan(current, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            current = new DeleteOrder();
            tableLayoutPanel1.Controls.Add(current,0,0);
            tableLayoutPanel1.SetColumnSpan(current, 3);
            tableLayoutPanel1.SetRowSpan(current, 10);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            current = new ViewOrders();
            tableLayoutPanel1.Controls.Add(current,0,0);
            tableLayoutPanel1.SetColumnSpan(current, 3);
            tableLayoutPanel1.SetRowSpan(current, 10);
        }
    }
}