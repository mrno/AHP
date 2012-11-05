using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisexperto.Fachadas;
using probaAHP;

namespace sisexperto.UI
{
    public partial class PonderacionExpertos : Form
    {   //Agregue para que ande el metodo provisorio
        private DALDatos dato = new DALDatos();
        private CalculoAHP calculo;



        private FachadaEjecucionProyecto _fachadaEjecucion;
        private List<experto_proyecto> _expertosConPonderacion;
        private proyecto _proyecto;
        public PonderacionExpertos(FachadaEjecucionProyecto Fachada, proyecto Proyecto)
        {
            InitializeComponent();
            _fachadaEjecucion = Fachada;
            _proyecto = Proyecto;
        }

        private void PonderacionExpertos_Load(object sender, EventArgs e)
        {
            _expertosConPonderacion = _fachadaEjecucion.ObtenerExpertosProyecto(_proyecto);
            dataGridPonderacionExpertos.DataSource = _expertosConPonderacion.ToList();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambiosPonderacion();
        }

        
        //TODO Este metodo llama de la forma vieja.
        //Hay que hacerlo de nuevo en la fachada
        private void EjecutarAgregacionPonderada() {


            var listaExpertoProyecto = dato.expeProyConsistentePONDERADO(_proyecto.id_proyecto);
            PreparacionListaCriterioAlternativa preparacionLista = new PreparacionListaCriterioAlternativa();

            if (listaExpertoProyecto.Count != 0)
            {

                List<KRankPonderado> listaKRankPonderado = new List<KRankPonderado>();
                foreach (experto_proyecto exp in listaExpertoProyecto)
                {
                    List<double[,]> listaPreparada = preparacionLista.Preparar(_proyecto.id_proyecto, exp.id_experto);
                    KRankPonderado kRankPonderado = new KRankPonderado();
                    calculo = new CalculoAHP();
                    kRankPonderado.KRanking = calculo.calcularRanking(listaPreparada);
                    kRankPonderado.Peso = Convert.ToInt32(exp.ponderacion);
                    listaKRankPonderado.Add(kRankPonderado);
                }
                AgregacionPonderada agregacionPonderada = new AgregacionPonderada();

                var rdo = agregacionPonderada.agregar(listaKRankPonderado);


                CalcularAhpAgregado frmAhpAgregado = new CalcularAhpAgregado(rdo, _proyecto.id_proyecto);
                frmAhpAgregado.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ningún experto ha valorado de manera consistente.");
            }


        
        }

        private void GuardarCambiosPonderacion()
        {
            _fachadaEjecucion.GuardarCambios(_expertosConPonderacion);
        }

        private bool PonderacionNula()
        {
            return 0 < (from ex in _expertosConPonderacion
                        where ex.ponderacion == 0
                        select ex).Count();
        }

        private void dataGridPonderacionExpertos_Leave(object sender, EventArgs e)
        {
            //if (PonderacionNula() || _fachadaEjecucion.PosibleEjecutarAHP())
            //{
            //    buttonContinuar.Enabled = false;
            //} else buttonContinuar.Enabled = true;
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            EjecutarAgregacionPonderada();
        }
    }
}
