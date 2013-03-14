using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisExperto;
using sisexperto.Fachadas;
using sisexperto.Entidades.AHP;

namespace sisexperto.UI
{
    public partial class Comparacion : Form
    {
        protected Proyecto _proyecto;
        protected IAHPMatrizComparable _matriz;
        protected IEnumerable<IAHPComparable> _listaElementosAComparar;
        protected FachadaProyectosExpertos _fachada;
        protected IEnumerable<double[]> _sugerencias = new List<double[]>();
        protected double[,] mejorada;

        public Comparacion(IAHPMatrizComparable Matriz, FachadaProyectosExpertos Fachada, Proyecto Proyecto)
        {
            InitializeComponent();
            _matriz = Matriz;
            _fachada = Fachada;
            _proyecto = Proyecto;
            buttonListo.Enabled = Matriz.Completa;
        }
        
        protected float valorarNumero(int valor)
        {
            if (valor == 1) //corresponde a 1/9
                //return (float)1 / (float)9;
                return 9;
            if (valor == 2) //corresponde a 1/8
                //return (float)1 / (float)8;
                return 8;
            if (valor == 3) //corresponde a 1/7
                //return (float)1 / (float)7;
                return 7;
            if (valor == 4) //corresponde a 1/6
                //return (float)1 / (float)6;
                return 6;
            if (valor == 5) //corresponde a 1/5
                //return (float)1 / (float)5;
                return 5;
            if (valor == 6) //corresponde a 1/4
                //return (float)1 / (float)4;
                return 4;
            if (valor == 7) //corresponde a 1/3
                //return (float)1 / (float)3;
                return 3;
            if (valor == 8) //corresponde a 1/2
                //return (float)1 / (float)2;
                return 2;
            if (valor == 9) //corresponde a 1
                return 1;
            if (valor == 10) //corresponde a 2
                //return 2;
                return 1 / (float)2;
            if (valor == 11) //corresponde a 3
                //return 3;
                return 1 / (float)3;
            if (valor == 12) //corresponde a 4
                //return 4;
                return 1 / (float)4;
            if (valor == 13) //corresponde a 5
                //return 5;
                return 1 / (float)5;
            if (valor == 14) //corresponde a 6
                //return 6;
                return 1 / (float)6;
            if (valor == 15) //corresponde a 7
                //return 7;
                return 1 / (float)7;
            if (valor == 16) //corresponde a 8
                //return 8;
                return 1 / (float)8;
            if (valor == 17) //corresponde a 9
                //return 9;
                return 1 / (float)9;

            return 0;
        }

        protected string valorarPalabra(int valor)
        {
            if (valor == 1) //corresponde a 9
                return "[9] es extremadamente más importante que ";
            if (valor == 2) //corresponde a 8
                return "[8] ";
            if (valor == 3) //corresponde a 7
                return "[7] es muy fuertemente más importante que ";
            if (valor == 4) //corresponde a 6
                return "[6] ";
            if (valor == 5) //corresponde a 5
                return "[5] es fuertemente más importante que ";
            if (valor == 6) //corresponde a 4
                return "[4] ";
            if (valor == 7) //corresponde a 3
                return "[3] es moderadamente más importante que ";
            if (valor == 8) //corresponde a 2
                return "[2] ";
            if (valor == 9) //corresponde a 1
                return "[1] es igual de importante que ";
            if (valor == 10) //corresponde a 1/2
                return "[1/2] ";
            if (valor == 11) //corresponde a 1/3
                return "[1/3]es moderadamente menos importante que ";
            if (valor == 12) //corresponde a 1/4
                return "[1/4] ";
            if (valor == 13) //corresponde a 1/5
                return "[1/5] es fuertemente menos importante que ";
            if (valor == 14) //corresponde a 1/6
                return "[1/6] ";
            if (valor == 15) //corresponde a 1/7
                return "[1/7] es muy fuertemente menos importante que ";
            if (valor == 16) //corresponde a 1/8
                return "[1/8] ";
            if (valor == 17) //corresponde a 1/9
                return "[1/9] es extremadamente menos importante que ";

            return "";
        }

        protected int valorarDoble(double valor)
        {
            if (valor == 0)
                return 9;

            if (valor >= 1)
                return 10 - (int)valor;
            else
                return 8 + (int)Math.Ceiling(1.0 / valor);
        }

        protected string obtenerDescripcion(double valor)
        {
            return valorarPalabra(valorarDoble(valor));
        }

        protected void buttonConsistencia_Click(object sender, EventArgs e)
        {
            buttonListo.Enabled = false;
            GuardarConsistencia();
        }

        protected void GuardarConsistencia()
        {
            _matriz.Consistencia = FachadaCalculos.Instance.CalcularConsistencia(_matriz.Matriz);
            _fachada.GuardarValoracion();
            if (_matriz.Consistencia)
                MessageBox.Show("Matriz consistente");
            else
            {
                ActualizarSugerencias();
                if (_sugerencias.Count() > 0)
                {
                    buttonAplicar.Enabled = true;
                    buttonDescartar.Enabled = true;
                    MostrarSugerencia();
                }                
            }
        }

        protected void MostrarSugerencia()
        {            
            double[] sugerencia = _sugerencias.FirstOrDefault();

            var fila = (Int32)sugerencia[0];
            var columna = (Int32)sugerencia[1];
            
            var NombreAlternativaA = _listaElementosAComparar.ElementAt(fila).Nombre;
            var NombreAlternativaB = _listaElementosAComparar.ElementAt(columna).Nombre;
            
            double mejorValor = sugerencia[2];
                        
            labelSugerencia.Text = "Sugerencia: " + NombreAlternativaA + " " +
                            "deberia ser " +
                            obtenerDescripcion(mejorValor) + " " +
                            NombreAlternativaB;
           
        }

        private void ActualizarSugerencias()
        {
            _sugerencias = FachadaCalculos.Instance.BuscarSugerencias(_matriz.Matriz);
            
        }

        protected void GenerarTracks(IAHPComparable Fila, int PFila, IAHPComparable Celda, int PCelda, double Valor, int y)
        {
            //sume 20 en cada setbound
            var izquierdaTB = new Label();
            izquierdaTB.SetBounds(25, y, 75, 50);
            izquierdaTB.Text = Fila.Nombre;
            panelComparacion.Controls.Add(izquierdaTB);

            var track = new TrackBar();
            track.SetBounds(95, y, 400, 45);
            track.Name = PFila.ToString() + 'x' + PCelda.ToString();
            track.SetRange(1, 17);
            track.Value = valorarDoble(Valor);
            track.Scroll += MoverTrack;
            panelComparacion.Controls.Add(track);


            var derechaTB = new Label();
            derechaTB.SetBounds(520, y, 80, 30);
            derechaTB.Text = Celda.Nombre;
            panelComparacion.Controls.Add(derechaTB);

            var miLabel = new Label();
            miLabel.SetBounds(170, y + 45, 250, 30);
            miLabel.Text = valorarPalabra(track.Value);
            miLabel.Name = PFila.ToString() + 'x' + PCelda.ToString();
            panelComparacion.Controls.Add(miLabel);
        }

        public virtual void MoverTrack(object sender, EventArgs e) {}

        public virtual void OnLoad(object sender, EventArgs e) { }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            buttonListo.Enabled = false;
            var combinacionAplicar = _sugerencias.FirstOrDefault();

            ActualizarTrack((int)combinacionAplicar[0], (int)combinacionAplicar[1], combinacionAplicar[2]);
            ActualizarMatriz((int)combinacionAplicar[0], (int)combinacionAplicar[1], combinacionAplicar[2]);

            labelSugerencia.Text = "Sugerencia:";
            buttonAplicar.Enabled = false;
            buttonDescartar.Enabled = false;

            GuardarConsistencia();            
        }

        private void ActualizarMatriz(int fila, int columna, double valor)
        {
            //puede evitarse quizás, pero ya vamos a probarlo
            var dimension = _matriz.Matriz.GetLength(0);
            var matriz = new double[dimension, dimension];
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    matriz[i, j] = _matriz.Matriz[i, j];
                }
            }

            matriz[fila, columna] = valor;

            _matriz.Matriz = matriz;

            _fachada.GuardarValoracion();
        }

        private void ActualizarTrack(int fila, int celda, double valor) 
        {
            TrackBar track = new TrackBar();
            Label label = new Label();
            foreach (Control c in panelComparacion.Controls)
            {
                if ((c is TrackBar) && (c.Name == fila.ToString() + 'x' + celda.ToString()))
                {
                    track = c as TrackBar;
                }
                if ((c is Label) && (c.Name == fila.ToString() + 'x' + celda.ToString()))
                {
                    label = c as Label;
                }
            }
            track.Value = valorarDoble(valor);
            label.Text = valorarPalabra(valorarDoble(valor));
        }

        private void buttonDescartar_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = _sugerencias.ToList();
                lista.RemoveAt(0);

                _sugerencias = lista;
                MostrarSugerencia();
            }
            catch (Exception)
            {
                labelSugerencia.Text = "Sugerencia: Cambie otros valores, porque se ha quedado sin sugerencias";
               
                buttonAplicar.Enabled = false;
                buttonDescartar.Enabled = false;
            } 
        }
    }
}
