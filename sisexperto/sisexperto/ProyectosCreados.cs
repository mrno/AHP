using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using probaAHP;

namespace sisexperto
{
    public partial class ProyectosCreados : Form
    {
        private DALDatos dato = new DALDatos();
        private int id_experto;
        private int id;
        private CalculoAHP calculo;
        private double[,] ranking;
     
        private List<double[,]> listaCompleta = new List<double[,]>();
        private List<NAlternativas> listaNAlt;
        private AgregacionNoPonderada calculadorNoPonderadas = new AgregacionNoPonderada();
        private AgregacionPonderada calculadorPonderadas = new AgregacionPonderada();
        private List<experto> listaExperto;
        private List<experto_proyecto> listaExpertoProyecto;
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
            id = proy.id_proyecto;
            CargarProyecto frmCargarProyecto = new CargarProyecto(id);
            frmCargarProyecto.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            proyecto proy = (proyecto)dataGridView1.CurrentRow.DataBoundItem;
            listaExperto = dato.expeProyConsistente(proy.id_proyecto);

            if (listaExperto.Count != 0)
            {
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
                
                CalculoAHP calculo = new CalculoAHP();
                ranking = calculo.calcularRanking(listaCompleta);





                CalcularAhpAgregado frmAhpAgregado = new CalcularAhpAgregado(ranking, proy.id_proyecto);
                frmAhpAgregado.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ningún experto ha valorado de manera consistente.");
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {

            proyecto proy = (proyecto)dataGridView1.CurrentRow.DataBoundItem;
            listaExpertoProyecto = dato.expePorProyConsistente(proy.id_proyecto);
            PreparacionListaCriterioAlternativa preparacionLista = new PreparacionListaCriterioAlternativa();

            if (listaExpertoProyecto.Count != 0)
            {
               
                List<KRankPonderado> listaKRankPonderado = new List<KRankPonderado>();
                foreach (experto_proyecto exp in listaExpertoProyecto)
                {
                    List<double[,]> listaPreparada = preparacionLista.Preparar(proy.id_proyecto, exp.id_experto);
                    KRankPonderado kRankPonderado = new KRankPonderado();
                  calculo = new CalculoAHP();
            kRankPonderado.KRanking = calculo.calcularRanking(listaPreparada);
                    kRankPonderado.Peso = Convert.ToInt32(exp.ponderacion);
                    listaKRankPonderado.Add(kRankPonderado);
                }
                AgregacionPonderada agregacionPonderada = new AgregacionPonderada();

                var rdo = agregacionPonderada.agregar(listaKRankPonderado);


               CalcularAhpAgregado frmAhpAgregado = new CalcularAhpAgregado(rdo,proy.id_proyecto);
               frmAhpAgregado.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ningún experto ha valorado de manera consistente.");
            }


        }
    }
}
