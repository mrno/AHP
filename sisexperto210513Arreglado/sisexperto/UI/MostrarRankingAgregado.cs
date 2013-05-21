using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisexperto.Entidades;
using sisExperto.Fachadas;
using sisexperto.Entidades.IL;
using sisexperto.UI;
using probaAHP;
using sisexperto.UI.Clases;

namespace sisExperto
{
    public partial class MostrarRankingAgregado : Form
    {
        private readonly FachadaEjecucionProyecto _fachada;
        private FachadaProyectosExpertos _fachadaExpertos = new FachadaProyectosExpertos();
        private int _modelo;
        private readonly Proyecto _proyecto;
        private IEnumerable<Experto> _expertosAgregados;
        private readonly double[,] rankingFinal;
        private int _tipoAgregacion;

        public MostrarRankingAgregado(Proyecto Proyecto, FachadaEjecucionProyecto Fachada, int tipoAgregacion, int modelo)
        {
            InitializeComponent();
            //tipoAgregacion=1 -> NO Ponderado
            //tipoAgregacion=2 -> Ponderado
            _tipoAgregacion = tipoAgregacion;
            _fachada = Fachada;
            _proyecto = Proyecto;
            _modelo = modelo;


            if (modelo==0)//AHP
            {
                _expertosAgregados = from c in _proyecto.ObtenerExpertosProyectoConsistenteAHP()
                                     select c.Experto;
                rankingFinal = _fachada.CalcularRankingAHP(_proyecto, tipoAgregacion);
            }
            else //IL
            {
                _expertosAgregados = from c in _proyecto.ObtenerExpertosProyectoConsistenteIL()
                                     select c.Experto;
                // tipoAgregacion 1 = No ponderado
                // tipoAgregacion 2 = Ponderado
                rankingFinal = _fachada.CalcularRankingIL(_proyecto, tipoAgregacion);
            }

            dataGridExpertos.DataSource = _expertosAgregados.ToList();

            labelTitulo.Text = _proyecto.Nombre;
            if (modelo==0)
            {
                this.Text = "Agregacion AHP";
                if (tipoAgregacion == 1)
                {
                    labelSubtitulo.Text = "Agregacion No Ponderada, media geometrica";
                    
                }
                else
                {
                    labelSubtitulo.Text = "Agregacion Ponderada";
                }
                button1.Visible = false;
            }
            else
            {
                   this.Text = "Agregacion IL";
                if (tipoAgregacion == 1)
                {
                    labelSubtitulo.Text = "Agregacion No Ponderada, media geometrica";
                    
                }
                else
                {
                    labelSubtitulo.Text = "Agregacion Ponderada";
                }
            }
        }

        private void CalcularAgregacion_Load(object sender, EventArgs e)
        {
            ICollection<Alternativa> listaAlt = _proyecto.Alternativas;

            int cont = 0;

            var listaResultado = new List<ResultadoViewModel>();
            foreach (Alternativa alternativa in listaAlt)
            {
                var resultado = new ResultadoViewModel();
                resultado.Alternativa = alternativa.Nombre;
                resultado.ValorPorcentaje = rankingFinal[cont, 0];
                cont++;
                listaResultado.Add(resultado);
            }
            resultadoViewModelBindingSource.DataSource = listaResultado.OrderByDescending(x => x.Porcentaje).ToList();
            //dataGridResultados.DataSource = listaResultado.OrderByDescending(x => x.Porcentaje).ToList();
        }
        
        //private void buttonMostrar_Click(object sender, EventArgs e)
        //{
        //    var exp = (Experto)dataGridExpertos.CurrentRow.DataBoundItem;
        //    var expEnProyecto = _fachadaExpertos.SolicitarExpertoProyectoActual(_proyecto, exp);
        //    MostrarRankingPersonal ventanaRankingPersonal;
        //    if (_modelo==0)//AHP
        //       {
        //            ventanaRankingPersonal = new MostrarRankingPersonal(_proyecto, _fachada, expEnProyecto, 1);
        //       }
        //       else
        //       {
        //            ventanaRankingPersonal = new MostrarRankingPersonal(_proyecto, _fachada, expEnProyecto, 2);       
        //       }
            
        //    ventanaRankingPersonal.Show();
        //}

        public double[,] CalcularRankingPersonal(Proyecto _proyecto, FachadaEjecucionProyecto _fachada, ExpertoEnProyecto _expertoEnProyecto, int _tipo)
        {
            //_tipo=1 -> AHP
            //_tipo=2 -> IL

            double[,] rankingFinal;

            if (_tipo==1)
            {
                rankingFinal = _fachada.CalcularRankingAHP(_expertoEnProyecto);
            }
            else
            {
                rankingFinal = _fachada.CalcularRankingIL(_expertoEnProyecto);
            }

            return rankingFinal;
        }


        private void mostrarRankingPersonal(object sender, DataGridViewCellEventArgs e)
        {            
            ExpertoEnProyecto miExpertoProyecto = new ExpertoEnProyecto();
            var exp = (Experto)dataGridExpertos.CurrentRow.DataBoundItem;
            var expProy = _fachadaExpertos.ObtenerExpertosActivosEnProyecto(_proyecto);
            double[,] rankingPersonal;

            groupBox3.Text = "Ranking Personal: " + exp.Apellido.ToUpper() + ", " + exp.Nombre;

            foreach (var item in expProy)
            {
                if (item.Experto.ExpertoId == exp.ExpertoId)
                    miExpertoProyecto = item;
            }

            if (_modelo==0)//AHP
            {
                rankingPersonal = CalcularRankingPersonal(_proyecto, _fachada, miExpertoProyecto, 1);
            }
            else
            {
                rankingPersonal = CalcularRankingPersonal(_proyecto, _fachada, miExpertoProyecto, 2);
            }
            //double[,] rankingPersonal = CalcularRankingPersonal(_proyecto, _fachada, miExpertoProyecto, 2);

            ICollection<Alternativa> listaAlt = _proyecto.Alternativas;

            int cont = 0;

            var listaResultado = new List<ResultadoViewModel>();
            foreach (Alternativa alternativa in listaAlt)
            {
                var resultado = new ResultadoViewModel();
                resultado.Alternativa = alternativa.Nombre;
                resultado.ValorPorcentaje = rankingPersonal[cont, 0];
                cont++;
                listaResultado.Add(resultado);
            }
            resultadoViewModelBindingSourceIndividual.DataSource = listaResultado.OrderByDescending(x => x.Porcentaje).ToList();
            //dataGridRankingPersonal.DataSource = listaResultado.OrderByDescending(x => x.Porcentaje).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var expertos = _fachadaExpertos.ObtenerExpertosActivosEnProyecto(_proyecto);
            ExpertoEnProyecto unExpProy = new ExpertoEnProyecto();
            ExpertoEnProyecto miExpertoProyecto = new ExpertoEnProyecto();
            var exp = (Experto)dataGridExpertos.CurrentRow.DataBoundItem;

            foreach (var item in expertos)
            {
                if (item.Experto.ExpertoId == exp.ExpertoId)
                    unExpProy = item;
            }

            if (this._tipoAgregacion == 2)
            {
                var frmMostrarTuplas = new MostrarResultadoTuplas(_fachada, unExpProy, _proyecto, true);
                frmMostrarTuplas.ShowDialog();
            }
            else
            {
                var frmMostrarTuplas = new MostrarResultadoTuplas(_fachada, unExpProy, _proyecto, false);
                frmMostrarTuplas.ShowDialog();
            }
        }
    }
}