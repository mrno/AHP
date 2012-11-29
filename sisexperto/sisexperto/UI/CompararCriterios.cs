using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisexperto.Entidades;
using sisexperto.Fachadas;

namespace sisExperto
{
    public partial class CompararCriterios : Form
    {
        private readonly Proyecto _proyecto;
        private readonly CriterioMatriz matrizCriterio;
        private readonly FachadaProyectosExpertos miFachada;
        private double[,] mejorada;
        private TrackBar track;


        public CompararCriterios(CriterioMatriz matriz, FachadaProyectosExpertos facha, Proyecto proy)
        {
            InitializeComponent();
            matrizCriterio = matriz;
            miFachada = facha;
            _proyecto = proy;
       }

        public float valorarNumero(int valor)
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
                return 1/(float) 2;
            if (valor == 11) //corresponde a 3
                //return 3;
                return 1/(float) 3;
            if (valor == 12) //corresponde a 4
                //return 4;
                return 1/(float) 4;
            if (valor == 13) //corresponde a 5
                //return 5;
                return 1/(float) 5;
            if (valor == 14) //corresponde a 6
                //return 6;
                return 1/(float) 6;
            if (valor == 15) //corresponde a 7
                //return 7;
                return 1/(float) 7;
            if (valor == 16) //corresponde a 8
                //return 8;
                return 1/(float) 8;
            if (valor == 17) //corresponde a 9
                //return 9;
                return 1/(float) 9;

            return 0;
        }

        public string valorarPalabra(int valor)
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

        public int valorarDoble(double valor)
        {
            if (valor >= 1)
                return 10 - (int) valor;
            else
                return 8 + (int) Math.Ceiling(1.0/valor);
        }

        public string obtenerDescripcion(double valor)
        {
            return valorarPalabra(valorarDoble(valor));
        }


        private void mostrar(object sender, EventArgs e)
        {
            label9.Text = "";

            track = (TrackBar) sender;

            foreach (Control miLabel in FindForm().Controls)
            {
                if (miLabel is Label)
                {
                    if (miLabel.Name == track.Name)
                    {
                        string[] posicion = track.Name.Split('x');
                        var l = (Label) miLabel;
                        l.Text = valorarPalabra(track.Value);

                        foreach (CriterioFila fila in matrizCriterio.FilasCriterio)
                        {
                            foreach (CriterioCelda celda in fila.CeldasCriterios)
                            {
                                if ((celda.Fila == Convert.ToInt32(posicion[0])) &&
                                    (celda.Columna == Convert.ToInt32(posicion[1])))
                                {
                                    //1
                                    celda.ValorAHP = valorarNumero(track.Value);

                                    //2
                                    //GuardarConsistencia();    puede ser esa opción también.
                                    matrizCriterio.Consistencia = false;

                                    miFachada.GuardarValoracion();
                                }
                            }
                        }

                        }
                }
            }
        }

        private void CompararCriterios_Load(object sender, EventArgs e)
        {
            int y = 140;

          foreach (CriterioFila fila in matrizCriterio.FilasCriterio)
            {
                foreach (CriterioCelda celda in fila.CeldasCriterios)
                {
                    //listaCeldas.Add(celda);

                    var izquierdaTB = new Label();
                    izquierdaTB.SetBounds(5, y, 75, 50);
                    izquierdaTB.Text = fila.Criterio.Nombre;
                    Controls.Add(izquierdaTB);

                    var track = new TrackBar();
                    track.SetBounds(75, y, 400, 45);
                    track.Name = celda.Fila.ToString() + 'x' + celda.Columna.ToString();
                    track.SetRange(1, 17);
                    track.Value = valorarDoble(celda.ValorAHP);
                    track.Scroll += mostrar;
                    Controls.Add(track);


                    var derechaTB = new Label();
                    derechaTB.SetBounds(500, y, 80, 30);
                    derechaTB.Text = celda.Criterio.Nombre;
                    Controls.Add(derechaTB);

                    var miLabel = new Label();
                    miLabel.SetBounds(150, y + 45, 250, 30);
                    //    double doble = dato.obtenerValorCompCriterio(comp.id_proyecto, comp.id_Experto, comp.pos_fila,
                    //                                                  comp.pos_columna);
                    miLabel.Text = valorarPalabra(track.Value);
                    miLabel.Name = celda.Fila.ToString() + 'x' + celda.Columna.ToString();
                    Controls.Add(miLabel);

                    y += 90;
                }
            }



            //// 
            //// button1
            //// 
            button1.Location = new Point(20, y);
            button1.Name = "button1";
            button1.Size = new Size(150, 40);
            button1.TabIndex = 6;
            button1.Text = "Calcular consistencia";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            //// 
            //// label9
            //// 
            label9.AutoSize = true;
            label9.Location = new Point(20, y + 45);
            label9.Name = "label9";
            label9.BackColor = Color.Red;
            label9.Size = new Size(40, 30);
            label9.TabIndex = 7;
            label9.Text = "";
        }

        private void GuardarConsistencia()
        {
            matrizCriterio.Consistencia = FachadaCalculos.Instance.CalcularConsistencia(matrizCriterio.MatrizCriterioAHP);
            miFachada.GuardarValoracion();
            if (matrizCriterio.Consistencia)
                MessageBox.Show("Matriz consistente");
            else
            {
                string NombreAlternativaA;
                string NombreAlternativaB;
                mejorada = FachadaCalculos.Instance.buscarMejoresConsistencia(matrizCriterio.MatrizCriterioAHP);
                double[] posicionRecomendada = MaxValueIJ(mejorada);


                var fila = (Int32) posicionRecomendada[0];
                var columna = (Int32) posicionRecomendada[1];

                List<Criterio> listaCriterios = _proyecto.Criterios.ToList();

                NombreAlternativaA = listaCriterios[fila].Nombre;
                NombreAlternativaB = listaCriterios[columna].Nombre;


                var M = (Int32) posicionRecomendada[2];

                double mejorValor = mejorada[M, 2];

                if (mejorada[0, 0] < mejorada[0, 1])
                {
                    label9.Text = NombreAlternativaA + " " +
                                  "deberia ser " +
                                  obtenerDescripcion(mejorValor) + " " +
                                  NombreAlternativaB;
                }
                else
                {
                    label9.Text = NombreAlternativaB + " " +
                                  "deberia ser " +
                                  obtenerDescripcion(1/mejorValor) + " " +
                                  NombreAlternativaA;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GuardarConsistencia();


          
        }

        private static double[] MaxValueIJ(double[,] intArray)
        {
            var rdo = new double[4];
            rdo[0] = (Int32) intArray[0, 0];
            rdo[1] = (Int32) intArray[0, 1];
            rdo[2] = 0;
            rdo[3] = 0;
            return rdo;
        }
    }
}