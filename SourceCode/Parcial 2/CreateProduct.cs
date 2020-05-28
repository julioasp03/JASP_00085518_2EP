using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class CreateProduct : UserControl
    {
        private UserControl current = null;
        public CreateProduct()
        {
            InitializeComponent();
            //llenamos comboBox//
            var nombre = ConnectioBD.ExecuteQuery($"SELECT name FROM BUSINESS");
            var list = new List<string>();
            foreach (DataRow dr in nombre.Rows)
            {
                list.Add(dr[0].ToString());
            }

            comboBox1.DataSource = list;
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
            if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("No se puede dejar campos vacios");
            }
            else
            {
                try
                {
                    //consigo el id de la empresa//
                    var idbusiness = "";
                    var business = ConnectioBD.ExecuteQuery($"SELECT idbusiness FROM BUSINESS WHERE name='{comboBox1.Text}' ");
                    foreach (DataRow num in business.Rows)
                    { 
                        idbusiness = num[0].ToString();
                    }
                    ConnectioBD.ExecuteNonQuery($"INSERT INTO PRODUCT(idbusiness,name) VALUES('{idbusiness}','{textBox2.Text}')");
                    MessageBox.Show("Producto agregado");
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