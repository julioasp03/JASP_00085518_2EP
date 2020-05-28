using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class DeleteOrder : UserControl
    {
        private UserControl current = null;
        public DeleteOrder()
        {
            InitializeComponent();
            //llenamos comboBox//
            var producto = ConnectioBD.ExecuteQuery($"SELECT name FROM PRODUCT");
            var list = new List<string>();
            foreach (DataRow dr in producto.Rows)
            {
                list.Add(dr[0].ToString());
            }

            comboBox1.DataSource = list;
            //llenamos comboBox//
            var address = ConnectioBD.ExecuteQuery($"SELECT address FROM ADDRESS");
            var list2 = new List<string>();
            foreach (DataRow dr in address.Rows)
            {
                list2.Add(dr[0].ToString());
            }

            comboBox2.DataSource = list2;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            current = new Order();
            tableLayoutPanel1.Controls.Add(current,0,0);
            tableLayoutPanel1.SetColumnSpan(current, 3);
            tableLayoutPanel1.SetRowSpan(current, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
             int num = 0, num2=0;
            if (comboBox1.Text.Equals("")||comboBox2.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar espacios vacios");
            }
            else
            {
                //vereifico que este el producto en la base//
                var start = ConnectioBD.ExecuteQuery($"SELECT name FROM PRODUCT");
                var list = new List<string>();

                foreach (DataRow dr in start.Rows)
                {
                    list.Add(dr[0].ToString());
                }

                foreach (var x in list)
                {
                    if (x.Equals(comboBox1.Text))
                    {
                        num = 1;
                    }
                }

                if (num==1)
                {
                    //verifico que este la direccion en la base//
                    var address = ConnectioBD.ExecuteQuery($"SELECT address FROM ADDRESS");
                    var list2 = new List<string>();

                    foreach (DataRow dr in address.Rows)
                    {
                        list2.Add(dr[0].ToString());
                    }

                    foreach (var x2 in list2)
                    {
                        if (x2.Equals(comboBox2.Text))
                        {
                            num2 = 1;
                        }
                    }

                    if (num2==1)
                    {
                        //selecciono el id del producto//
                        var idproduct = "";
                        var id1 = ConnectioBD.ExecuteQuery($"SELECT idproduct FROM PRODUCT WHERE name='{comboBox1.Text}' ");
                        foreach (DataRow x in id1.Rows)
                        { 
                            idproduct = x[0].ToString();
                        }
                        //selecciono el id de la direccion//
                        var idaddress = "";
                        var id2 = ConnectioBD.ExecuteQuery($"SELECT idaddress FROM ADDRESS WHERE address='{comboBox2.Text}' ");
                        foreach (DataRow x in id2.Rows)
                        {
                            idaddress = x[0].ToString();
                        }

                        try
                        {
                            ConnectioBD.ExecuteNonQuery(
                                $"DELETE FROM APPORDER WHERE idProduct='{idproduct}'AND idAddress='{idaddress}'");
                            MessageBox.Show("Pedido eliminado");
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("No se encuentra el pedido");
                            throw;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Direccion no encontrada");
                    }
                }
                else
                {
                    MessageBox.Show("Producto no encontrado");
                }
            }
        }
    }
}