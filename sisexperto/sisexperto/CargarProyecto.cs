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

        private void CargarProyecto_Load(object sender, EventArgs e)
        {
            gridAlternativas.DataSource = dato.todasAlternativas();
            gridExpertos.DataSource = dato.expertosPorProyecto(id_proyecto);
            gridCriterios.DataSource = dato.criteriosPorProyecto(id_proyecto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevaAlternativa frmAlternativa = new NuevaAlternativa(id_proyecto);
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
                gridExpertos.DataSource = dato.expertosPorProyecto(id_proyecto);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NuevoCriterio frmCriterio = new NuevoCriterio(id_proyecto);
            frmCriterio.ShowDialog();
            {
                gridCriterios.DataSource = dato.criteriosPorProyecto(id_proyecto);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dato = new DALDatos();
            List<experto> listaExp = dato.expertosPorProyecto(id_proyecto);
            List<criterio> listaCri = dato.criteriosPorProyecto(id_proyecto);
            //Queue<criterio> colaCri = dato.colaCriterios(id_proyecto);
            Queue<criterio> colaCri;
            foreach (experto exp in listaExp)
            {
                colaCri = dato.colaCriterios(id_proyecto);
                foreach (criterio c in listaCri)
                {
                    colaCri.Dequeue();
                    foreach (criterio c2 in colaCri)
                    {
                        //FALTA EL ID DEL EXPERTO
                        dato.guardarComparacionCriterios(id_proyecto, exp.id_experto, c.id_criterio, c2.id_criterio, 0);
                    }
                }
            }
        }

        
    }


}
