using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class DeleteAddress : UserControl
    {
        private UserControl current = null;
        public DeleteAddress()
        {
            InitializeComponent();
            //llenamos comboBox1//
            var direccion = ConnectioBD.ExecuteQuery($"SELECT address FROM ADDRESS");
            var list = new List<string>();
            foreach (DataRow dr in direccion.Rows)
            {
                list.Add(dr[0].ToString());
            }

            comboBox1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            current = new Usuario();
            tableLayoutPanel1.Controls.Add(current,0,0);
            tableLayoutPanel1.SetColumnSpan(current, 3);
            tableLayoutPanel1.SetRowSpan(current, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar espacios vacios");
            }
            else
            {
                //verifico que el usuario este en la base//
                var start = ConnectioBD.ExecuteQuery($"SELECT username FROM APPUSER");
                var list = new List<string>();

                foreach (DataRow dr in start.Rows)
                {
                    list.Add(dr[0].ToString());
                }

                foreach (var x in list)
                {
                    if (x.Equals(textBox1.Text))
                    {
                        num = 1;
                    }
                }

                if (num==1)
                {
                    //selecciono el id del usuario//
                    var isuser = "";
                    var tipo = ConnectioBD.ExecuteQuery(
                        $"SELECT iduser FROM APPUSER WHERE username='{textBox1.Text}' ");

                    foreach (DataRow x in tipo.Rows)
                    {
                        isuser = x[0].ToString();
                    }

                    try
                    {
                        ConnectioBD.ExecuteNonQuery(
                            $"DELETE FROM ADDRESS WHERE address='{comboBox1.Text}' AND iduser='{isuser}' ");
                        MessageBox.Show("Direccion eliminada");
                    } 
                    catch (Exception exception)
                    {
                        MessageBox.Show("Ha ocurrido un error");
                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Error campos no concuerdan");
                }
            }
        }
    }
}