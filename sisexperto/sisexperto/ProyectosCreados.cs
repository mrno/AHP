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
    public partial class ProyectosCreados : Form
    {
        private DALDatos dato = new DALDatos();
        private int id_experto;
        public ProyectosCreados(int id_exp)
        {
            InitializeComponent();
            id_experto = id_exp;
        }

        private void ProyectosCreados_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dato.proyectosPorCreador(id_experto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            proyecto proy = (proyecto)dataGridView1.CurrentRow.DataBoundItem;
            int id = proy.id_proyecto;
            CargarProyecto frmCargarProyecto = new CargarProyecto(id);
            frmCargarProyecto.ShowDialog();
        }
    }
}
