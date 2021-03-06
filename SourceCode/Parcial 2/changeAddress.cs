﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class ChangeAddress : UserControl
    {
        private UserControl current = null;
        public ChangeAddress()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            tableLayoutPanel1.Controls.Clear();
            current = new Usuario();
            tableLayoutPanel1.Controls.Add(current,0,0);
            tableLayoutPanel1.SetColumnSpan(current, 3);
            tableLayoutPanel1.SetRowSpan(current, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (textBox1.Text.Equals("")||textBox2.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar espacios vacios");
            }
            else
            {
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
                    
                    ConnectioBD.ExecuteNonQuery($"UPDATE ADDRESS SET address='{textBox2.Text}' WHERE address='{textBox3.Text}'");
                    MessageBox.Show("Direccion guardada");
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
                }
            }
        }
    }
}