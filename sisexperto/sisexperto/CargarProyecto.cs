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
    public partial class CargarProyecto : Form
    {
        private DALDatos dato = new DALDatos();
        private int id_proyecto;

        public CargarProyecto(int id)
        {
            InitializeComponent();
            id_proyecto = id;
        }

        //public void frmAlternativa_FormClosed()
        //{
        //    gridAlternativas.DataSource = dato.todasAlternativas();
        //}

        private void CargarProyecto_Load(object sender, EventArgs e)
        {
            gridAlternativas.DataSource = dato.todasAlternativas();
            gridExpertos.DataSource = dato.todosExpertos();
            gridCriterios.DataSource = dato.todosCriterios();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevaAlternativa frmAlternativa = new NuevaAlternativa(id_proyecto);
            //frmAlternativa.FormClosed += new FormClosedEventHandler(frmAlternativa_FormClosed);
            //frmAlternativa.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAlternativa_FormClosed);
            frmAlternativa.ShowDialog();
            {
                gridAlternativas.DataSource = dato.todasAlternativas();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NuevoExperto frmExperto = new NuevoExperto(id_proyecto);
            frmExperto.ShowDialog();
            {
                gridExpertos.DataSource = dato.todosExpertos();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NuevoCriterio frmCriterio = new NuevoCriterio(id_proyecto);
            frmCriterio.ShowDialog();
            {
                gridCriterios.DataSource = dato.todosCriterios();
            }
        }

        
    }


}
