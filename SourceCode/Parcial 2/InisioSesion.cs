using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class InisioSesion : UserControl
    {
        private UserControl current = null;

        public InisioSesion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            current = new MenuInicial();
            tableLayoutPanel1.Controls.Add(current, 0, 0);
            tableLayoutPanel1.SetColumnSpan(current, 3);
            tableLayoutPanel1.SetRowSpan(current, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = 0, num2 = 0;
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("No se puede dejar campos vacios");
            }
            else
            {
                //creo una lista con los username//
                var start = ConnectioBD.ExecuteQuery($"SELECT username FROM APPUSER");
                var list = new List<string>();

                foreach (DataRow dr in start.Rows)
                {
                    list.Add(dr[0].ToString());
                }

                //creo una lista con las contraseñas//
                var password = ConnectioBD.ExecuteQuery($"SELECT password FROM APPUSER");
                var listpassword = new List<string>();
                foreach (DataRow x in password.Rows)
                {
                    listpassword.Add(x[0].ToString());
                }

                //verifico que el username este en la lista//
                foreach (var text in list)
                {
                    if (textBox1.Text.Equals(text))
                    {
                        num = 1;
                    }
                }

                if (num == 1)
                {
                    //Verifico que la contraseña este en la lista//
                    foreach (var obj in listpassword)
                    {
                        if (textBox2.Text.Equals(obj))
                        {
                            num2 = 1;
                        }
                    }
                }
                
                if (num2 == 1)
                {
                    //hago el cambio de user control//
                    var isAdmin = "";
                    var tipo = ConnectioBD.ExecuteQuery(
                        $"SELECT usertype FROM APPUSER WHERE username='{textBox1.Text}' ");

                    foreach (DataRow x in tipo.Rows)
                    {
                        isAdmin = x[0].ToString();
                    }

                    if (Convert.ToBoolean(isAdmin))
                    {
                        tableLayoutPanel1.Controls.Clear();
                        current = new Administrador();
                        tableLayoutPanel1.Controls.Add(current);
                        tableLayoutPanel1.SetColumnSpan(current, 3);
                        tableLayoutPanel1.SetRowSpan(current, 10);

                    }
                    else
                    {
                        tableLayoutPanel1.Controls.Clear();
                        current = new Usuario();
                        tableLayoutPanel1.Controls.Add(current);
                        tableLayoutPanel1.SetColumnSpan(current, 3);
                        tableLayoutPanel1.SetRowSpan(current, 10);


                    }
                }
                else
                {
                    MessageBox.Show("Nombre o contraseña incorrecta");
                }
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            current = new ChangePassword();
            tableLayoutPanel1.Controls.Add(current);
            tableLayoutPanel1.SetColumnSpan(current, 3);
            tableLayoutPanel1.SetRowSpan(current, 10);
        }
    }
}


