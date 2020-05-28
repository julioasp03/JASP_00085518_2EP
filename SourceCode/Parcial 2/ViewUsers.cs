using System;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class ViewUsers : UserControl
    {
        private UserControl current=null;
        public ViewUsers()
        {
            InitializeComponent();
            var dt = ConnectioBD.ExecuteQuery(
                $"SELECT * FROM APPUSER ");
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            current = new Administrador();
            tableLayoutPanel1.Controls.Add(current,0,0);
            tableLayoutPanel1.SetColumnSpan(current, 3);
            tableLayoutPanel1.SetRowSpan(current, 2);
        }
    }
}