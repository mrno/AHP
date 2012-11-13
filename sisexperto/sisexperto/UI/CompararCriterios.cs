using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Consistencia;
using ConsistenciaNative;

namespace sisExperto
{
    public partial class CompararCriterios : Form
    {
       // private DALDatos dato;
        private int id_proyecto;
        private int id_Experto;
        private TrackBar track;
        private double[,] mejorada;
        private int pos = 0;

        public CompararCriterios(int id_p, int id_e)
        {
            InitializeComponent();
            id_proyecto = id_p;
            id_Experto = id_e;
        }

        private bool existe(string nombre)
        {
            bool resultado = new bool();
            resultado = false;
            foreach (Label miLabel in this.FindForm().Controls)
            {
                if (nombre == miLabel.Name)
                {
                    miLabel.Text = nombre;
                    miLabel.Refresh();
                    resultado = true;
                }
            }
            return resultado;
        }

        private void mostrar(object sender, EventArgs e)
        {
         //   label9.Text = "";
         //   button3.Visible = false;
         //track = (TrackBar)sender;
            
         //   foreach (Control miLabel in this.FindForm().Controls)
         //   {
         //       if (miLabel is Label)
         //       {
         //           if (miLabel.Name.ToString() == track.Name.ToString())
         //           {
         //               string[] posicion = track.Name.ToString().Split('x');
         //               Label l = (Label)miLabel;
         //               l.Text = dato.valorarPalabra(track.Value);
         //               dato = new DALDatos();
         //               dato.modificarComparacionCriterios(id_proyecto, id_Experto, Convert.ToInt32(posicion[0].ToString()), Convert.ToInt32(posicion[1].ToString()), dato.valorarNumero(track.Value));
         //               dato.actualizarConsistenciaProyecto(id_proyecto, id_Experto, false);
         //               dato.actualizarMatrizCriterio(id_proyecto, id_Experto, false);
         //           }
         //       }
         //   }
            
        }

        private void CompararCriterios_Load(object sender, EventArgs e)
        {
            //dato = new DALDatos();
            //int y = 140;

            //List<comparacion_Criterio> listaComparacion = dato.comparacionCriterioPorExperto(id_proyecto, id_Experto);

            //List<Criterio> lista = dato.CriteriosPorProyecto(id_proyecto);

            //foreach (comparacion_Criterio comp in listaComparacion)
            //{
            //    Label izquierdaTB = new Label();
            //    izquierdaTB.SetBounds(5, y, 75, 50);
            //    izquierdaTB.Text = dato.CriterioNombre(comp.id_Criterio1);
            //    Controls.Add(izquierdaTB);

            //    TrackBar track = new TrackBar();
            //    track.SetBounds(75, y, 400, 45);
            //    track.Name = comp.pos_fila.ToString() + 'x' + comp.pos_columna.ToString();
            //    track.SetRange(1, 17);
            //    track.Value = dato.obtenerEnteroCompCriterio(comp.id_proyecto,
            //        comp.id_Experto, comp.pos_fila, comp.pos_columna);
            //    track.Scroll += new System.EventHandler(this.mostrar);
            //    Controls.Add(track);

            
                

            //    Label derechaTB = new Label();
            //    derechaTB.SetBounds(500, y, 80, 30);
            //    derechaTB.Text = dato.CriterioNombre(comp.id_Criterio2);
            //    Controls.Add(derechaTB);

            //    Label miLabel = new Label();
            //    miLabel.SetBounds(150, y + 45, 250, 30);
            //    double doble = dato.obtenerValorCompCriterio(comp.id_proyecto, comp.id_Experto, comp.pos_fila,
            //                                                  comp.pos_columna);
            //    miLabel.Text = dato.obtenerDescripcion(doble);
            //    miLabel.Name = comp.pos_fila.ToString() + 'x' + comp.pos_columna.ToString();


            //    Controls.Add(miLabel);


            //    y += 90;
            //}

            //// 
            //// button1
            //// 
            //this.button1.Location = new System.Drawing.Point(20, y);
            //this.button1.Name = "button1";
            //this.button1.Size = new System.Drawing.Size(150, 40);
            //this.button1.TabIndex = 6;
            //this.button1.Text = "Calcular consistencia";
            //this.button1.UseVisualStyleBackColor = true;
            //this.button1.Click += new System.EventHandler(this.button1_Click);
            //// 
            //// label9
            //// 
            //this.label9.AutoSize = true;
            //this.label9.Location = new System.Drawing.Point(20, y + 45);
            //this.label9.Name = "label9";
            //this.label9.BackColor = Color.Red;
            //this.label9.Size = new System.Drawing.Size(40, 30);
            //this.label9.TabIndex = 7;
            //this.label9.Text = "";
            
            //// 
            //// button2
            //// 
            //this.button2.Location = new System.Drawing.Point(200, y);
            //this.button2.Name = "button2";
            //this.button2.Size = new System.Drawing.Size(150, 40);
            //this.button2.TabIndex = 8;
            //this.button2.Text = "button2";
            //this.button3.Visible = false;
            //this.button2.UseVisualStyleBackColor = true;
            //this.button2.Click += new System.EventHandler(this.button2_Click);
          

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //label9.Text = "";
            //List<comparacion_Criterio> listaComparacion = dato.comparacionCriterioPorExperto(id_proyecto, id_Experto);
            //int cantFilas = 1;

            //foreach (comparacion_Criterio comp in listaComparacion)
            //{
            //    if (comp.pos_fila == 0)
            //        cantFilas++;
            //}

            //double[,] matriz = new double[cantFilas,cantFilas];

            //foreach(comparacion_Criterio comp in listaComparacion)
            //{
            //    matriz[comp.pos_fila, comp.pos_columna] = (double)comp.valor;
            //}

            //int limite = cantFilas;
            //for (int i = 0; i < limite; i++)
            //{
            //    for (int j = 0; j < limite; j++)
            //    {
            //        if (i == j)
            //            matriz[i, j] = 1;
            //        else if (i > j)
            //            matriz[i, j] = (double)1 / (matriz[j, i]);
            //    }
                
            //}

            //ConsistenciaMatriz consistencia = new ConsistenciaMatriz();

            //if (consistencia.calcularConsistencia(matriz))
            //{
            //    dato.actualizarMatrizCriterio(id_proyecto, id_Experto, true);
            //    MessageBox.Show("Matriz consistente.");
            //}
            //else
            //{
                
            //    string NombreCriterioA;
            //    string NombreCriterioB;
            //    mejorada = consistencia.buscarMejoresConsistencia(matriz);
            //    double[] posicionRecomendada = MaxValueIJ(mejorada);


                
            //    Int32 fila = (Int32)posicionRecomendada[0];
            //    Int32 columna = (Int32)posicionRecomendada[1];

            //    List<Criterio> listaCriterios = dato.CriteriosPorProyecto(id_proyecto);

            //    NombreCriterioA = listaCriterios[fila].nombre;
            //    NombreCriterioB = listaCriterios[columna].nombre;
                
              
                
            //    Int32 M = (Int32)posicionRecomendada[2];
               
            //    double mejorValor = mejorada[M, 2];

            //    if (mejorada[0, 0] < mejorada[0, 1])
            //    {
            //        label9.Text = NombreCriterioA + " " +
            //                          "deberia ser " +
            //                          dato.obtenerDescripcion(mejorValor) + " " +
            //                          NombreCriterioB;     
            //    }
            //    else
            //    {
            //        label9.Text = NombreCriterioB + " " +
            //                         "deberia ser " +
            //                         dato.obtenerDescripcion((double)1 / mejorValor) + " " +
            //                         NombreCriterioA;     
            //    }
                
               
              
               
            //}

                
        }

        static double[] MaxValueIJ(double[,] intArray)
        {
  
            double[] rdo = new double[4];
            rdo[0] = (Int32)intArray[0, 0];
            rdo[1] = (Int32)intArray[0, 1];
            rdo[2] = 0;
            rdo[3] = 0;
            return rdo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        //    pos++;
        //    label9.Text = "En la posición " + mejorada[pos, 0].ToString() + "," + mejorada[pos, 1].ToString() + " colocar " + dato.obtenerDescripcion((double)mejorada[pos, 2]);
        //
        }

    }
}
