using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sisexperto
{
    public partial class NuevoExperto : Form
    {
        private DALDatos dato;
        private int id_proy;
        public NuevoExperto(int id)
        {
            InitializeComponent();
            id_proy = id;
			//mundo
			//esto es nuevo desde la laptop

			//nuevo desde la pc del gisia
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt4.Text == txt5.Text)
            {
                dato = new DALDatos();
                dato.altaExperto(txt1.Text, txt2.Text, txt3.Text, txt4.Text);
                dato.asignarProyecto(id_proy, dato.ultimoExperto());
                this.Close();
            }
            else
            {
                MessageBox.Show("Las claves no coinciden. Por favor, vuelva a ingresarlas");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
