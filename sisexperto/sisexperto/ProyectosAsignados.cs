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
    public partial class ProyectosAsignados : Form
    {
        private DALDatos dato = new DALDatos();
        private int id_experto;
        public ProyectosAsignados(int id_exp)
        {
            InitializeComponent();
            id_experto = id_exp;
        }

        private void ProyectosAsignados_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dato.proyectosExperto(id_experto);
        }
    }
}
