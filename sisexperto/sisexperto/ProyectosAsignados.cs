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
            label1.Text = "Nombre de experto: " + dato.buscarExperto(id_experto).nombre.ToString();
            dataGridView1.DataSource = dato.proyectosExperto(id_experto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            proyecto proy = (proyecto)dataGridView1.CurrentRow.DataBoundItem;
            CompararCriterios frmComparar = new CompararCriterios(proy.id_proyecto,id_experto);
            frmComparar.ShowDialog();
        }
    }
}
