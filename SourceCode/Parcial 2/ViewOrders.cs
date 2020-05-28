using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class ViewOrders : UserControl
    {
        private UserControl current = null;
        public ViewOrders()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            current = new Order();
            tableLayoutPanel1.Controls.Add(current,0,0);
            tableLayoutPanel1.SetColumnSpan(current, 3);
            tableLayoutPanel1.SetRowSpan(current, 3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = 0;
            var usuario = ConnectioBD.ExecuteQuery($"SELECT username FROM APPUSER");
            var list = (from DataRow dr in usuario.Rows select dr[0].ToString()).ToList();
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("No se puede dejar campos vacios");
            }
            else
            {
                try
                {
                    foreach (var x in list)
                    {
                        if (textBox1.Text.Equals(x))
                        {
                            num = 1;
                        }
                    }

                    if (num ==1)
                    {
                        //selleciono el id del user que esta viendo sus direcciones//
                        var iduser = "";
                        var id = ConnectioBD.ExecuteQuery($"SELECT iduser FROM APPUSER WHERE username='{textBox1.Text}' ");
                        foreach (DataRow x in id.Rows)
                        { 
                            iduser = x[0].ToString();
                        }
                        //miro sus direcciones//
                        var dt = ConnectioBD.ExecuteQuery($"SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address "+
                        $"FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au "+
                        $"WHERE ao.idProduct = pr.idProduct "+
                        $"AND ao.idAddress = ad.idAddress "+
                        $"AND au.idUser = '{iduser}'");
                        dataGridView1.DataSource = dt; 
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("No se esncontro el usuario");
                    throw;
                }
            }
        }
    }
}