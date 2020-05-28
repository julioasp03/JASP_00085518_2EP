using System;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class ViewallOrders : UserControl
    {
        private UserControl current = null;
        public ViewallOrders()
        {
            InitializeComponent();
            var dt = ConnectioBD.ExecuteQuery($"SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address "+
            $"FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au "+
            $"WHERE ao.idProduct = pr.idProduct "+
            $"AND ao.idAddress = ad.idAddress "+
            $"AND ad.idUser = au.idUser");
            dataGridView1.DataSource = dt; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            current = new Administrador();
            tableLayoutPanel1.Controls.Add(current,0,0);
            tableLayoutPanel1.SetColumnSpan(current, 2);
            tableLayoutPanel1.SetRowSpan(current, 2);
        }
    }
}