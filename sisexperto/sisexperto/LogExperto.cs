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
    public partial class LogExperto : Form
    {
        private DALDatos dato = new DALDatos();
        public LogExperto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (dato.logExperto(textBox1.Text, textBox2.Text))
            {
                experto exp= dato.validarExperto(textBox1.Text, textBox2.Text);
                ProyectosAsignados frmProyAsignados = new ProyectosAsignados(exp.id_experto);
                frmProyAsignados.ShowDialog();
            }
            

        }

    }
}
