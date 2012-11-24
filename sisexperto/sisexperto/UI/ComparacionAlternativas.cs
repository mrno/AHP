using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisexperto.Entidades;
using sisExperto.Entidades;

namespace sisExperto
{
    public partial class ComparacionAlternativas : Form
    {
        //private DALDatos dato = new DALDatos();
        //private int id_proyecto;
        //private int id_Experto;
        //private int id_Criterio;

        //private Queue<Criterio> colaCriterio;

        private AlternativaMatriz matrizAlternativa;
        private FachadaProyectosExpertos miFachada;

        private int y = 140;

        private double[,] mejorada;
        private int pos = 0;


        public ComparacionAlternativas(AlternativaMatriz matriz, FachadaProyectosExpertos facha)
        {
            InitializeComponent();
            matrizAlternativa = matriz;
            miFachada = facha;

            //id_proyecto = id_proy;
            //id_Experto = id_exp;
            //id_Criterio = Criterio;
            //colaCriterio = dato.colaCriterios(id_proyecto);
        }

        public float valorarNumero(int valor)
        {
            if (valor == 1)//corresponde a 1/9
                //return (float)1 / (float)9;
                return (float)9;
            if (valor == 2)//corresponde a 1/8
                //return (float)1 / (float)8;
                return (float)8;
            if (valor == 3)//corresponde a 1/7
                //return (float)1 / (float)7;
                return (float)7;
            if (valor == 4)//corresponde a 1/6
                //return (float)1 / (float)6;
                return (float)6;
            if (valor == 5)//corresponde a 1/5
                //return (float)1 / (float)5;
                return (float)5;
            if (valor == 6)//corresponde a 1/4
                //return (float)1 / (float)4;
                return (float)4;
            if (valor == 7)//corresponde a 1/3
                //return (float)1 / (float)3;
                return (float)3;
            if (valor == 8)//corresponde a 1/2
                //return (float)1 / (float)2;
                return (float)2;
            if (valor == 9)//corresponde a 1
                return 1;
            if (valor == 10)//corresponde a 2
                //return 2;
                return (float)1 / (float)2;
            if (valor == 11)//corresponde a 3
                //return 3;
                return (float)1 / (float)3;
            if (valor == 12)//corresponde a 4
                //return 4;
                return (float)1 / (float)4;
            if (valor == 13)//corresponde a 5
                //return 5;
                return (float)1 / (float)5;
            if (valor == 14)//corresponde a 6
                //return 6;
                return (float)1 / (float)6;
            if (valor == 15)//corresponde a 7
                //return 7;
                return (float)1 / (float)7;
            if (valor == 16)//corresponde a 8
                //return 8;
                return (float)1 / (float)8;
            if (valor == 17)//corresponde a 9
                //return 9;
                return (float)1 / (float)9;

            return 0;
        }

        public string valorarPalabra(int valor)
        {
            if (valor == 1)//corresponde a 9
                return "[9] es extremadamente más importante que ";
            if (valor == 2)//corresponde a 8
                return "[8] ";
            if (valor == 3)//corresponde a 7
                return "[7] es muy fuertemente más importante que ";
            if (valor == 4)//corresponde a 6
                return "[6] ";
            if (valor == 5)//corresponde a 5
                return "[5] es fuertemente más importante que ";
            if (valor == 6)//corresponde a 4
                return "[4] ";
            if (valor == 7)//corresponde a 3
                return "[3] es moderadamente más importante que ";
            if (valor == 8)//corresponde a 2
                return "[2] ";
            if (valor == 9)//corresponde a 1
                return "[1] es igual de importante que ";
            if (valor == 10)//corresponde a 1/2
                return "[1/2] ";
            if (valor == 11)//corresponde a 1/3
                return "[1/3]es moderadamente menos importante que ";
            if (valor == 12)//corresponde a 1/4
                return "[1/4] ";
            if (valor == 13)//corresponde a 1/5
                return "[1/5] es fuertemente menos importante que ";
            if (valor == 14)//corresponde a 1/6
                return "[1/6] ";
            if (valor == 15)//corresponde a 1/7
                return "[1/7] es muy fuertemente menos importante que ";
            if (valor == 16)//corresponde a 1/8
                return "[1/8] ";
            if (valor == 17)//corresponde a 1/9
                return "[1/9] es extremadamente menos importante que ";

            return "";
        }

        private void mostrar(object sender, EventArgs e)
        {
            //label9.Text = "";
            //button3.Visible = false;
            //button1.Visible = true;
            TrackBar track = (TrackBar)sender;

            foreach (Control miLabel in this.FindForm().Controls)
            {
                if (miLabel is Label)
                {
                    if (miLabel.Name.ToString() == track.Name.ToString())
                    {
                        string[] posicion = track.Name.ToString().Split('x');
                        Label l = (Label)miLabel;
                        l.Text = valorarPalabra(track.Value);
                        
                        foreach (AlternativaFila fila in matrizAlternativa.FilasAlternativa)
                        {
                            foreach (AlternativaCelda celda in fila.CeldasAlternativas)
                            {
                                if ((celda.Fila == Convert.ToInt32(posicion[0])) && (celda.Columna == Convert.ToInt32(posicion[1])))
                                {
                                    //1
                                    celda.ValorAHP = valorarNumero(track.Value);

                                    //2
                                    matrizAlternativa.Consistencia = false;
                                    miFachada.GuardarValoracion();
                                }
                            }
                        }
                        
                        //1   dato.modificarComparacionAlternativa(id_proyecto, id_Experto, Convert.ToInt32(posicion[0].ToString()), Convert.ToInt32(posicion[1].ToString()), Convert.ToInt32(posicion[2].ToString()), dato.valorarNumero(track.Value));
                        //2   dato.actualizarConsistenciaProyecto(id_proyecto, id_Experto, false);
                        //3   dato.actualizarMatrizAlternativa(id_proyecto, id_Experto, id_Criterio, false);
                    }
                }
            }
        }

        private void cargarTracks(int id_cri)
        {
            //dato = new DALDatos();
            //y = 140;

            //List<comparacion_Alternativa> listaComparacion = dato.compAlternativaPorExpertoCriterio(id_proyecto, id_Experto, id_cri);

            //foreach (comparacion_Alternativa comp in listaComparacion)
            //{
    
            //    Label izquierdaTB = new Label();
            //    izquierdaTB.SetBounds(5, y, 75, 50);
            //    izquierdaTB.Text = dato.AlternativaNombre(comp.id_Alternativa1);
            //    Controls.Add(izquierdaTB);

            //    TrackBar track = new TrackBar();
            //    track.SetBounds(75, y, 400, 45);
            //    track.Name = comp.id_Criterio.ToString() + 'x' + comp.pos_fila.ToString() + 'x' + comp.pos_columna.ToString();
            //    track.SetRange(1, 17);
            //    track.Value = dato.obtenerEnteroCompAlternativa(comp.id_proyecto, comp.id_Experto, comp.id_Criterio, comp.pos_fila, comp.pos_columna);
            //    track.Scroll += new System.EventHandler(this.mostrar);
            //    Controls.Add(track);
               
            //    Label miLabel = new Label();
            //    miLabel.SetBounds(150, y + 45, 250, 30);
            //    miLabel.Name = comp.id_Criterio.ToString() + 'x' + comp.pos_fila.ToString() + 'x' + comp.pos_columna.ToString();
            //    double doble = dato.obtenerValorCompAlternativa(comp.id_proyecto, comp.id_Experto, comp.id_Criterio, comp.pos_fila, comp.pos_columna);
            //    miLabel.Text = dato.obtenerDescripcion(doble);
            //    Controls.Add(miLabel);

            //    Label derechaTB = new Label();
            //    derechaTB.SetBounds(500, y, 80, 30);
            //    derechaTB.Text = dato.AlternativaNombre(comp.id_Alternativa2);
            //    Controls.Add(derechaTB);

            //    button3.Enabled = false;

            //    y += 90;
            //}
        }

        private void ComparacionAlternativas_Load(object sender, EventArgs e)
        {
            int y = 140;

            foreach (AlternativaFila fila in matrizAlternativa.FilasAlternativa)
            {
                foreach (AlternativaCelda celda in fila.CeldasAlternativas)
                {

                    Label izquierdaTB = new Label();
                    izquierdaTB.SetBounds(5, y, 75, 50);
                    izquierdaTB.Text = fila.Alternativa.Nombre.ToString();
                    Controls.Add(izquierdaTB);

                    TrackBar track = new TrackBar();
                    track.SetBounds(75, y, 400, 45);
                    track.Name = celda.Fila.ToString() + 'x' + celda.Columna.ToString();
                    track.SetRange(1, 17);
                    
                    //track.Value = dato.obtenerEnteroCompCriterio(comp.id_proyecto,
                    //    comp.id_Experto, comp.pos_fila, comp.pos_columna);

                    track.Scroll += new System.EventHandler(this.mostrar);
                    Controls.Add(track);


                    Label derechaTB = new Label();
                    derechaTB.SetBounds(500, y, 80, 30);
                    derechaTB.Text = celda.Alternativa.Nombre.ToString();
                    Controls.Add(derechaTB);

                    Label miLabel = new Label();
                    miLabel.SetBounds(150, y + 45, 250, 30);
                    //    double doble = dato.obtenerValorCompCriterio(comp.id_proyecto, comp.id_Experto, comp.pos_fila,
                    //                                                  comp.pos_columna);
                    //    miLabel.Text = dato.obtenerDescripcion(doble);
                    miLabel.Name = celda.Fila.ToString() + 'x' + celda.Columna.ToString();
                    Controls.Add(miLabel);

                    y += 90;
                }
            }
            
        









 
           // //crit = colaCriterio.Dequeue();

           //// label20.Text = "Considerando el Criterio: " + dato.CriterioNombre(id_Criterio).ToString();
           // cargarTracks(id_Criterio);

           // //int y = 140;
           // // 
           // // button1
           // // 
           // this.button1.Location = new System.Drawing.Point(5, y);
           // this.button1.Name = "button1";
           // this.button1.Size = new System.Drawing.Size(150, 40);
           // this.button1.TabIndex = 6;
           // this.button1.Text = "Calcular consistencia";
           // this.button1.UseVisualStyleBackColor = true;
           // this.button1.Click += new System.EventHandler(this.button1_Click);
           // this.Controls.Add(this.button1);
           // // 
           // // label9
           // // 
           // this.label9.AutoSize = true;
           // this.label9.Location = new System.Drawing.Point(5, y + 45);
           // this.label9.Name = "label9";
           // this.label9.BackColor = Color.Red;
           // this.label9.Size = new System.Drawing.Size(150, 40);
           // this.label9.TabIndex = 7;
           // this.label9.Text = "";
           // this.Controls.Add(this.label9);
           // // 
           // // button4
           // // 
           // this.button4.Location = new System.Drawing.Point(110, y);
           // this.button4.Name = "button4";
           // this.button4.Size = new System.Drawing.Size(150, 40);
           // this.button4.TabIndex = 2;
           // this.button4.Text = "AHP";
           // this.button4.Visible = false;
           // this.button4.UseVisualStyleBackColor = true;
           // this.button4.Click += new System.EventHandler(this.button4_Click);
           // this.Controls.Add(this.button4);

           // // 
           // // button2
           // // 
           // this.button2.Location = new System.Drawing.Point(210, y);
           // this.button2.Name = "button2";
           // this.button2.Size = new System.Drawing.Size(100, 30);
           // this.button2.TabIndex = 8;
           // this.button2.Text = "button2";
           // this.button2.Visible = true;
           // this.button2.UseVisualStyleBackColor = true;
           // this.button2.Click += new System.EventHandler(this.button2_Click);
           // //this.Controls.Add(this.button2);

           // // 
           // // button3
           // // 
           // //this.button3.Location = new System.Drawing.Point(310, y);
           // //this.button3.Name = "button3";
           // //this.button3.Size = new System.Drawing.Size(150, 40);
           // //this.button3.TabIndex = 9;
           // //this.button3.Text = "Siguiente";
           // //this.button3.UseVisualStyleBackColor = true;
           // //this.button3.Visible = true;
           // //this.button3.Enabled = false;
           // //this.button3.Click += new System.EventHandler(this.button3_Click);
           // //this.Controls.Add(this.button3);
           // //button3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //CalcularAhpAgregadoPonderado frmCalcularAhpAgregadoPonderado = new CalcularAhpAgregadoPonderado(id_proyecto, id_Experto);
            //frmCalcularAhpAgregadoPonderado.ShowDialog();
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // label9.Text = "";
           //// Queue<Criterio> colaCri = dato.colaCriterios(id_proyecto);
           // List<comparacion_Alternativa> listaAlt;
           
           //     listaAlt = dato.compAlternativaPorExpertoCriterio(id_proyecto, id_Experto, id_Criterio);

           //     int cantidadFilas = 1;

           //     foreach (comparacion_Alternativa comp in listaAlt)
           //     {
           //         if (comp.pos_fila == 0)
           //             cantidadFilas++;
           //     }

           //     double[,] matrizAlt = new double[cantidadFilas, cantidadFilas];

           //     foreach (comparacion_Alternativa comp in listaAlt)
           //     {
           //         matrizAlt[comp.pos_fila, comp.pos_columna] = (double)comp.valor;
           //     }

           //     int tope = cantidadFilas;
           //     for (int i = 0; i < tope; i++)
           //     {
           //         for (int j = 0; j < tope; j++)
           //         {
           //             if (i == j)
           //                 matrizAlt[i, j] = 1;
           //             else if (i > j)
           //                 matrizAlt[i, j] = (double)1 / (matrizAlt[j, i]);
           //         }
           //     }

           // ConsistenciaMatriz consistencia = new ConsistenciaMatriz();

           // if (consistencia.calcularConsistencia(matrizAlt))
           // {
           //     dato.actualizarMatrizAlternativa(id_proyecto, id_Experto, id_Criterio, true);
           //     button1.Visible = true;
           //     //this.button3.Enabled = true;
           //     //this.button3.Visible = true;
           //     MessageBox.Show("Matriz consistente.");
           // }
           // else
           // {
           //     string NombreAlternativaA;
           //     string NombreAlternativaB;
           //     mejorada = consistencia.buscarMejoresConsistencia(matrizAlt);
           //     double[] posicionRecomendada = MaxValueIJ(mejorada);


           //     Int32 fila = (Int32)posicionRecomendada[0];
           //     Int32 columna = (Int32)posicionRecomendada[1];

           //     List<Alternativa> listaAlternativas = dato.AlternativasPorProyecto(id_proyecto);

           //     NombreAlternativaA = listaAlternativas[fila].nombre;
           //     NombreAlternativaB = listaAlternativas[columna].nombre;


           //     Int32 M = (Int32)posicionRecomendada[2];

           //     double mejorValor = mejorada[M, 2];

           //     if (mejorada[0, 0] < mejorada[0, 1])
           //     {
           //         label9.Text = NombreAlternativaA + " " +
           //                           "deberia ser " +
           //                           dato.obtenerDescripcion(mejorValor) + " " +
           //                           NombreAlternativaB;
           //     }
           //     else
           //     {
           //         label9.Text = NombreAlternativaB + " " +
           //                          "deberia ser " +
           //                          dato.obtenerDescripcion((double)1 / mejorValor) + " " +
           //                          NombreAlternativaA;
           //     }
           // }
        }
        static double[] MaxValueIJ(double[,] intArray)
        {
            //double maxVal = 0;

            //int k = 0;
            //int l = 0;
            //int m = 0;
            //int n = 0;

            //for (int i = 0; i < intArray.GetLength(1) - 1; i++)
            //{


            //    for (int j = 0; j < intArray.GetLength(1) - 1; j++)
            //    {
            //        if (intArray[i, 2] > maxVal)
            //        {

            //            maxVal = intArray[i, 2];
            //            k = (Int32)intArray[i, 0];
            //            l = (Int32)intArray[i, 1];
            //            m = i;
            //            n = j;

            //        }
            //    }
            //}

            //double[] rdo = new double[4];
            //rdo[0] = k;
            //rdo[1] = l;
            //rdo[2] = m;
            //rdo[3] = n;
            //return rdo;
            double[] rdo = new double[4];
            rdo[0] = (Int32)intArray[0, 0];
            rdo[1] = (Int32)intArray[0, 1];
            rdo[2] = 0;
            rdo[3] = 0;
            return rdo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //pos++;
            //label9.Text = "En la posición " + mejorada[pos, 0].ToString() + "," + mejorada[pos, 1].ToString() + " colocar " + dato.obtenerDescripcion((double)mejorada[pos, 2]);
        
        }

       

      
    }
}
