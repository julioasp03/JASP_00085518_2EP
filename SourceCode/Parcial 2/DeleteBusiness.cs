using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class DeleteBusiness : UserControl
    {
        private UserControl current = null;
        public DeleteBusiness()
        {
            InitializeComponent();
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
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("No se puede dejar campos vacios");
            }
            else
            {
                //creamos una lista para ver exista la empresa//
                var start = ConnectioBD.ExecuteQuery($"SELECT name FROM BUSINESS");
                var list = new List<string>();
                int x = 0;

                foreach (DataRow dr in start.Rows)
                {
                    list.Add(dr[0].ToString());
                }
                //recorremos lista y verificamos//
                foreach (var obj in list)
                {
                    if (obj.Equals(textBox1.Text))
                    {
                        x = 1;
                    }
                }

                if (x == 1)
                {
                    try
                    {
                       ConnectioBD.ExecuteNonQuery($"DELETE FROM BUSINESS WHERE name='{textBox1.Text}'");
                       MessageBox.Show("Empresa eliminada");
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