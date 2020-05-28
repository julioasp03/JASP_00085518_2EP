using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class CreateOrder : UserControl
    {
        private UserControl current = null;
        public CreateOrder()
        {
            InitializeComponent();
            //llenamos comboBox//
            var producto = ConnectioBD.ExecuteQuery($"SELECT name FROM PRODUCT");
            var list3 = new List<string>();
            foreach (DataRow dr in producto.Rows)
            {
                list3.Add(dr[0].ToString());
            }

            comboBox1.DataSource = list3;
            //llenamos comboBox//
            var address = ConnectioBD.ExecuteQuery($"SELECT address FROM ADDRESS");
            var list4 = new List<string>();
            foreach (DataRow dr in address.Rows)
            {
                list4.Add(dr[0].ToString());
            }

            comboBox2.DataSource = list4;
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
                //verifico que este el producto//
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
                    //verifico que este la direccion//
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
                        //consigo el id del producto seleccionado//
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
                        //creo una varaible tiempo//
                        DateTime time= DateTime.Now;

                        ConnectioBD.ExecuteNonQuery($"INSERT INTO APPORDER(createDate,idProduct,idAddress) VALUES('{time}','{idproduct}','{idaddress}')");
                        MessageBox.Show("Pedido hecho");
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