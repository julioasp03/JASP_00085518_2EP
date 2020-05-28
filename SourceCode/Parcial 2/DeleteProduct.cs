using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class DeleteProduct : UserControl
    {
        private UserControl current;
        public DeleteProduct()
        {
            InitializeComponent();
            //llenamos comboBox1//
            var nombre = ConnectioBD.ExecuteQuery($"SELECT name FROM BUSINESS");
            var list = new List<string>();
            foreach (DataRow dr in nombre.Rows)
            {
                list.Add(dr[0].ToString());
            }

            comboBox1.DataSource = list;
            //llenamos comboBox2//
            var producto = ConnectioBD.ExecuteQuery($"SELECT name FROM PRODUCT");
            var listP = new List<string>();
            foreach (DataRow dr in producto.Rows)
            {
                listP.Add(dr[0].ToString());
            }

            comboBox2.DataSource = listP;
            
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
            if (comboBox1.Text.Equals("")||comboBox2.Text.Equals(""))
            {
                MessageBox.Show("No se puede dejar campos vacios");
            }
            else
            {
                try
                {
                    ConnectioBD.ExecuteNonQuery($"DELETE FROM PRODUCT WHERE name='{comboBox2.Text}'");
                    MessageBox.Show("Producto eliminado");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Ha ocurrido un error");
                    throw;
                }
            }
        }
    }
}