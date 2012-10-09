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

        private double[,] mejorada;
        private int pos = 0;
        private int crit;
        
        public ComparacionAlternativas(int id_proy, int id_exp)
        {
            InitializeComponent();
            id_proyecto = id_proy;
            id_experto = id_exp;
            colaCriterio = dato.colaCriterios(id_proyecto);
        }

        private void mostrar(object sender, EventArgs e)
        {
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
            int y = 70;

            List<comparacion_alternativa> listaComparacion = dato.compAlternativaPorExpertoCriterio(id_proyecto, id_experto, id_cri);

            foreach (comparacion_alternativa comp in listaComparacion)
            {
                Label izquierdaTB = new Label();
                izquierdaTB.SetBounds(16, y, 60, 50);
                izquierdaTB.Text = dato.alternativaNombre(comp.id_alternativa1);
                Controls.Add(izquierdaTB);

                TrackBar track = new TrackBar();
                track.SetBounds(75, y, 659, 45);
                track.Name = comp.id_criterio.ToString() + 'x' + comp.pos_fila.ToString() + 'x' + comp.pos_columna.ToString();
                track.SetRange(1, 17);
                track.Value = 9;
                track.Scroll += new System.EventHandler(this.mostrar);
                Controls.Add(track);

                Label derechaTB = new Label();
                derechaTB.SetBounds(740, y, 100, 30);
                derechaTB.Text = dato.alternativaNombre(comp.id_alternativa2);
                Controls.Add(derechaTB);

                Label izquierda = new Label();
                izquierda.SetBounds(870, y, 100, 30);
                izquierda.Text = dato.alternativaNombre(comp.id_alternativa1);
                Controls.Add(izquierda);


                Label miLabel = new Label();
                miLabel.SetBounds(980, y, 200, 50);
                miLabel.Name = comp.id_criterio.ToString() + 'x' + comp.pos_fila.ToString() + 'x' + comp.pos_columna.ToString();
                Controls.Add(miLabel);


                Label derecha = new Label();
                derecha.SetBounds(1180, y, 100, 30);
                derecha.Text = dato.alternativaNombre(comp.id_alternativa2);
                Controls.Add(derecha);

                y += 70;
            }
 
        }

        private void ComparacionAlternativas_Load(object sender, EventArgs e)
        {
            crit = colaCriterio.Dequeue().id_criterio;
            cargarTracks(crit);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colaCriterio != null)
            {
                foreach (Control track in this.Controls)
                {
                    if (track is TrackBar)
                        this.Controls.Remove(track);
                }

                crit = colaCriterio.Dequeue().id_criterio;
                cargarTracks(crit);

            }
            else
                MessageBox.Show("Valoración finalizada. Matrices consistentes.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CalcularAhp frmCalcularAhp = new CalcularAhp(id_proyecto, id_experto);
            frmCalcularAhp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Queue<criterio> colaCri = dato.colaCriterios(id_proyecto);
            List<comparacion_alternativa> listaAlt;
           
                listaAlt = dato.compAlternativaPorExpertoCriterio(id_proyecto, id_experto, crit);

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
                MessageBox.Show("matriz consistente");
            else
            {
                mejorada = consistencia.buscarMejoresConsistencia(matrizAlt);
                if( mejorada[0, 0] <  mejorada[0, 1])
                    label9.Text = "En la posición " + mejorada[0, 0].ToString() + "," + mejorada[0, 1].ToString() + " colocar " + dato.obtenerDescripcion(mejorada[pos, 2]);
                else
                    label9.Text = "En la posición " + mejorada[0, 1].ToString() + "," + mejorada[0, 0].ToString() + " colocar " + dato.obtenerDescripcion((double)1/mejorada[pos, 2]);
            }

                
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pos++;
            label9.Text = "En la posición " + mejorada[pos, 0].ToString() + "," + mejorada[pos, 1].ToString() + " colocar " + dato.obtenerDescripcion((double)mejorada[pos, 2]);
        }
    }
}
