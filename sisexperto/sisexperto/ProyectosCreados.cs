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

       
        
        private List<double[,]> listaCompleta = new List<double[,]>();
        private List<NAlternativas> listaNAlt;
        private AgregacionNoPonderada calculadorNoPonderadas = new AgregacionNoPonderada();
        private List<experto> listaExperto;
        private List<AgrAlternativas> listaAlternativasPonderar = new List<AgrAlternativas>();
        private AgrCriterio matrizCriterioPonderar;

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

        private void button2_Click(object sender, EventArgs e)
        {
            proyecto proy = (proyecto)dataGridView1.CurrentRow.DataBoundItem;
            listaExperto = dato.expertosPorProyecto(proy.id_proyecto);

            foreach (experto exp in listaExperto)
            {
                AgrAlternativas altAgregar = new AgrAlternativas(proy.id_proyecto, exp.id_experto);
                listaAlternativasPonderar.Add(altAgregar);
            }

            matrizCriterioPonderar = new AgrCriterio(proy.id_proyecto);

            //Acá procedo a agregarle la primer matriz, la de criterios:

            listaCompleta.Add(calculadorNoPonderadas.AgregarCriterios(matrizCriterioPonderar));

            //Acá creo una lista con las alternativas ponderadas en la primer línea y luego la recorro y para cada elemento le asigno
            //su valor de atributo a la listaCompleta:

            listaNAlt = calculadorNoPonderadas.AgregarAlternativas(listaAlternativasPonderar);

            foreach (NAlternativas alt in listaNAlt)
            {
                listaCompleta.Add(alt.nAlternativas);
            }

            //Luego de todo este despelote, listaCompleta está terminada para pasarse a la clase CalculoAHP.

            CalcularAhpAgregado frmAhpAgregado = new CalcularAhpAgregado(listaCompleta, proy.id_proyecto);
            frmAhpAgregado.ShowDialog();
            
        }
    }
}
