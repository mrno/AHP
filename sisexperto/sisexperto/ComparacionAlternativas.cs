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
    public partial class ComparacionAlternativas : Form
    {
        private DALDatos dato = new DALDatos();
        private int id_proyecto;
        private int id_experto;
        private Queue<criterio> colaCriterio;

        private int y = 140;

        private double[,] mejorada;
        private int pos = 0;
        private criterio crit;
        
        public ComparacionAlternativas(int id_proy, int id_exp)
        {
            InitializeComponent();
            id_proyecto = id_proy;
            id_experto = id_exp;
            colaCriterio = dato.colaCriterios(id_proyecto);
        }

        private void mostrar(object sender, EventArgs e)
        {
            label9.Text = "";
            button3.Visible = false;
            button1.Visible = true;
            TrackBar track = (TrackBar)sender;

            foreach (Control miLabel in this.FindForm().Controls)
            {
                if (miLabel is Label)
                {
                    if (miLabel.Name.ToString() == track.Name.ToString())
                    {
                        string[] posicion = track.Name.ToString().Split('x');
                        Label l = (Label)miLabel;
                        l.Text = dato.valorarPalabra(track.Value);
                        dato = new DALDatos();
                        dato.modificarComparacionAlternativa(id_proyecto, id_experto, Convert.ToInt32(posicion[0].ToString()), Convert.ToInt32(posicion[1].ToString()), Convert.ToInt32(posicion[2].ToString()), dato.valorarNumero(track.Value));
                    }
                }
            }

        }

        private void cargarTracks(int id_cri)
        {
            dato = new DALDatos();
            y = 140;

            List<comparacion_alternativa> listaComparacion = dato.compAlternativaPorExpertoCriterio(id_proyecto, id_experto, id_cri);

            foreach (comparacion_alternativa comp in listaComparacion)
            {
    
                Label izquierdaTB = new Label();
                izquierdaTB.SetBounds(5, y, 75, 50);
                izquierdaTB.Text = dato.alternativaNombre(comp.id_alternativa1);
                Controls.Add(izquierdaTB);

                TrackBar track = new TrackBar();
                track.SetBounds(75, y, 400, 45);
                track.Name = comp.id_criterio.ToString() + 'x' + comp.pos_fila.ToString() + 'x' + comp.pos_columna.ToString();
                track.SetRange(1, 17);
                track.Value = dato.obtenerEnteroCompAlternativa(comp.id_proyecto, comp.id_experto, comp.id_criterio, comp.pos_fila, comp.pos_columna);
                track.Scroll += new System.EventHandler(this.mostrar);
                Controls.Add(track);
               
                Label miLabel = new Label();
                miLabel.SetBounds(150, y + 45, 250, 30);
                miLabel.Name = comp.id_criterio.ToString() + 'x' + comp.pos_fila.ToString() + 'x' + comp.pos_columna.ToString();
                miLabel.Text = "";
                Controls.Add(miLabel);

                Label derechaTB = new Label();
                derechaTB.SetBounds(500, y, 80, 30);
                derechaTB.Text = dato.alternativaNombre(comp.id_alternativa2);
                Controls.Add(derechaTB);

                button3.Enabled = false;

                y += 90;
            }
        }

        private void ComparacionAlternativas_Load(object sender, EventArgs e)
        {
 
            crit = colaCriterio.Dequeue();
            label20.Text = "Considerando el criterio: " + crit.nombre.ToString();
            cargarTracks(crit.id_criterio);

            //int y = 140;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, y);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Calcular consistencia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.Controls.Add(this.button1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, y + 45);
            this.label9.Name = "label9";
            this.label9.BackColor = Color.Red;
            this.label9.Size = new System.Drawing.Size(150, 40);
            this.label9.TabIndex = 7;
            this.label9.Text = "";
            this.Controls.Add(this.label9);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(110, y);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 40);
            this.button4.TabIndex = 2;
            this.button4.Text = "AHP";
            this.button4.Visible = false;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.Controls.Add(this.button4);

            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(210, y);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.Visible = true;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            //this.Controls.Add(this.button2);

            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(310, y);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 40);
            this.button3.TabIndex = 9;
            this.button3.Text = "Siguiente";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = true;
            this.button3.Enabled = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.Controls.Add(this.button3);
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colaCriterio.Count != 0)
            {
                foreach (Control track in this.Controls)
                {
                    if (track is TrackBar)
                    {
                        foreach (Control unLabel in this.Controls)
                            {
                                if (unLabel is Label && unLabel.Name == track.Name)
                                    this.Controls.Remove(unLabel);
                            }
                        this.Controls.Remove(track);
                    }
                }

                button1.Visible = true;
                crit = colaCriterio.Dequeue();
                label20.Text = "Considerando el criterio: " + crit.nombre.ToString();
                cargarTracks(crit.id_criterio);

            }
            else
            {
                MessageBox.Show("Valoración finalizada. Matrices consistentes.");
                button4.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CalcularAhp frmCalcularAhp = new CalcularAhp(id_proyecto, id_experto);
            frmCalcularAhp.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Text = "";
           // Queue<criterio> colaCri = dato.colaCriterios(id_proyecto);
            List<comparacion_alternativa> listaAlt;
           
                listaAlt = dato.compAlternativaPorExpertoCriterio(id_proyecto, id_experto,crit.id_criterio);

                int cantidadFilas = 1;

                foreach (comparacion_alternativa comp in listaAlt)
                {
                    if (comp.pos_fila == 0)
                        cantidadFilas++;
                }

                double[,] matrizAlt = new double[cantidadFilas, cantidadFilas];

                foreach (comparacion_alternativa comp in listaAlt)
                {
                    matrizAlt[comp.pos_fila, comp.pos_columna] = (double)comp.valor;
                }

                int tope = cantidadFilas;
                for (int i = 0; i < tope; i++)
                {
                    for (int j = 0; j < tope; j++)
                    {
                        if (i == j)
                            matrizAlt[i, j] = 1;
                        else if (i > j)
                            matrizAlt[i, j] = (double)1 / (matrizAlt[j, i]);
                    }
                }

            ConsistenciaMatriz consistencia = new ConsistenciaMatriz();

            if (consistencia.calcularConsistencia(matrizAlt))
            {
                button1.Visible = true;
                this.button3.Enabled = true;
                this.button3.Visible = true;
                MessageBox.Show("Matriz consistente.");
            }
            else
            {
                
                //mejorada = consistencia.buscarMejoresConsistencia(matrizAlt);
                //if (mejorada[0, 0] < mejorada[0, 1])
                //    label9.Text = "En la posición " + mejorada[0, 0].ToString() + "," + mejorada[0, 1].ToString() + " colocar " + dato.obtenerDescripcion(mejorada[pos, 2]);
                //else
                //    label9.Text = "En la posición " + mejorada[0, 1].ToString() + "," + mejorada[0, 0].ToString() + " colocar " + dato.obtenerDescripcion((double)1 / mejorada[pos, 2]);
                string NombreAlternativaA;
                string NombreAlternativaB;
                mejorada = consistencia.buscarMejoresConsistencia(matrizAlt);
                double[] posicionRecomendada = MaxValueIJ(mejorada);


                Int32 fila = (Int32)posicionRecomendada[0];
                Int32 columna = (Int32)posicionRecomendada[1];

                List<alternativa> listaAlternativas = dato.alternativasPorProyecto(id_proyecto);

                NombreAlternativaA = listaAlternativas[fila].nombre;
                NombreAlternativaB = listaAlternativas[columna].nombre;


                Int32 M = (Int32)posicionRecomendada[2];

                double mejorValor = mejorada[M, 2];

                if (mejorada[0, 0] < mejorada[0, 1])
                {
                    label9.Text = NombreAlternativaA + " " +
                                      "deberia ser " +
                                      dato.obtenerDescripcion(mejorValor) + " " +
                                      NombreAlternativaB;
                }
                else
                {
                    label9.Text = NombreAlternativaB + " " +
                                     "deberia ser " +
                                     dato.obtenerDescripcion((double)1 / mejorValor) + " " +
                                     NombreAlternativaA;
                }
            }
        }
        static double[] MaxValueIJ(double[,] intArray)
        {
            double maxVal = 0;

            int k = 0;
            int l = 0;
            int m = 0;
            int n = 0;

            for (int i = 0; i < intArray.GetLength(1) - 1; i++)
            {


                for (int j = 0; j < intArray.GetLength(1) - 1; j++)
                {
                    if (intArray[i, 2] > maxVal)
                    {

                        maxVal = intArray[i, 2];
                        k = (Int32)intArray[i, 0];
                        l = (Int32)intArray[i, 1];
                        m = i;
                        n = j;

                    }
                }
            }

            double[] rdo = new double[4];
            rdo[0] = k;
            rdo[1] = l;
            rdo[2] = m;
            rdo[3] = n;
            return rdo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pos++;
            label9.Text = "En la posición " + mejorada[pos, 0].ToString() + "," + mejorada[pos, 1].ToString() + " colocar " + dato.obtenerDescripcion((double)mejorada[pos, 2]);
        }

       

      
    }
}
