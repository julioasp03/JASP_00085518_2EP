using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class CrearUsuario : UserControl
    {
        private UserControl current = null;
        public CrearUsuario()
        {
            InitializeComponent();
            comboBox1.DataSource= new List<string>(){"Administrador","Usuario normal"};
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
                MessageBox.Show("No se puede dejar campos vacios");
            }
            else
            {
                //creamos una lista para ver que no se repita el usuario//
                var start = ConnectioBD.ExecuteQuery($"SELECT username FROM APPUSER");
                var list = new List<string>();
                int x = 0;

                foreach (DataRow dr in start.Rows)
                {
                    list.Add(dr[0].ToString());
                }
                //recorremos lista y verificamos//
                foreach (var obj in list)
                {
                    if (obj.Equals(textBox2.Text))
                    {
                        MessageBox.Show("Nombre de usaurio ya existente por favor cambie usuario");
                        x = 1;
                    }
                }

                if (x == 0)
                {
                    try
                    {
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0:
                                ConnectioBD.ExecuteNonQuery($"INSERT INTO APPUSER(fullname,username,password,usertype) VALUES(" +
                                                             $"'{textBox1.Text}'," +
                                                             $"'{textBox2.Text}'," +
                                                             $"'{textBox2.Text}'," +
                                                             $"'{true}')");
                                MessageBox.Show("Se ha registrado ");
                                break;
                            case 1:
                                ConnectioBD.ExecuteNonQuery($"INSERT INTO APPUSER(fullname,username,password,usertype) VALUES(" +
                                                             $"'{textBox1.Text}'," +
                                                             $"'{textBox2.Text}'," +
                                                             $"'{textBox2.Text}'," +
                                                             $"'{false}')");
                                MessageBox.Show("Se ha registrado ");
                                break;
                        }
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
}