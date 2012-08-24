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
    public partial class NuevoProyecto : Form
    {
        private DALDatos dato;
        
        public NuevoProyecto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dato = new DALDatos();
            dato.altaProyecto(txt1.Text, txt2.Text);
            CargarProyecto frmCargarProy = new CargarProyecto(dato.ultimoProyecto());
            frmCargarProy.ShowDialog();
        }

     
        private void NuevoProyecto_Load(object sender, EventArgs e)
        {

        }
    }
}
