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

namespace sisexperto
{
    public partial class CompararCriterios : Form
    {
        private DALDatos dato;
        private int id_proyecto;
        private int id_experto;

        private double[,] mejorada;
        private int pos = 0;

        public CompararCriterios(int id_p, int id_e)
        {
            InitializeComponent();
            id_proyecto = id_p;
            id_experto = id_e;
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
            button3.Visible = false;
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
                        dato.modificarComparacionCriterios(id_proyecto, id_experto, Convert.ToInt32(posicion[0].ToString()), Convert.ToInt32(posicion[1].ToString()), dato.valorarNumero(track.Value));
                    }
                }
            }
            
        }

        private void CompararCriterios_Load(object sender, EventArgs e)
        {
            dato = new DALDatos();
            int y = 140;

            List<comparacion_criterio> listaComparacion = dato.comparacionCriterioPorExperto(id_proyecto, id_experto);

            List<criterio> lista = dato.criteriosPorProyecto(id_proyecto);

            foreach (comparacion_criterio comp in listaComparacion)
            {
                Label izquierdaTB = new Label();
                izquierdaTB.SetBounds(16, y, 60, 50);
                izquierdaTB.Text = dato.criterioNombre(comp.id_criterio1);
                Controls.Add(izquierdaTB);

                TrackBar track = new TrackBar();
                track.SetBounds(75, y, 659, 45);
                track.Name = comp.pos_fila.ToString() + 'x' + comp.pos_columna.ToString();
                track.SetRange(1, 17);
                track.Value = 9;
                track.Scroll += new System.EventHandler(this.mostrar);
                Controls.Add(track);

                Label derechaTB = new Label();
                derechaTB.SetBounds(740, y, 100, 30);
                derechaTB.Text = dato.criterioNombre(comp.id_criterio2);
                Controls.Add(derechaTB);

                Label izquierda = new Label();
                izquierda.SetBounds(870, y, 100, 30);
                izquierda.Text = dato.criterioNombre(comp.id_criterio1);
                Controls.Add(izquierda);


                Label miLabel = new Label();
                miLabel.SetBounds(980, y, 200, 50);
                miLabel.Name = comp.pos_fila.ToString() + 'x' + comp.pos_columna.ToString();
                Controls.Add(miLabel);

                
                Label derecha = new Label();
                derecha.SetBounds(1180, y, 100, 30);
                derecha.Text = dato.criterioNombre(comp.id_criterio2);
                Controls.Add(derecha);

                y += 70;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<comparacion_criterio> listaComparacion = dato.comparacionCriterioPorExperto(id_proyecto, id_experto);
            int cantFilas = 1;

            foreach (comparacion_criterio comp in listaComparacion)
            {
                if (comp.pos_fila == 0)
                    cantFilas++;
            }

            double[,] matriz = new double[cantFilas,cantFilas];

            foreach(comparacion_criterio comp in listaComparacion)
            {
                matriz[comp.pos_fila, comp.pos_columna] = (double)comp.valor;
            }

            int limite = cantFilas;
            for (int i = 0; i < limite; i++)
            {
                for (int j = 0; j < limite; j++)
                {
                    if (i == j)
                        matriz[i, j] = 1;
                    else if (i > j)
                        matriz[i, j] = (double)1 / (matriz[j, i]);
                }
                
            }

            ConsistenciaMatriz consistencia = new ConsistenciaMatriz();

            if (consistencia.calcularConsistencia(matriz))
            {
                button3.Visible = true;
                MessageBox.Show("Matriz consistente.");
            }
            else
            {
                mejorada = consistencia.buscarMejoresConsistencia(matriz);
                if (mejorada[0, 0] < mejorada[0, 1])
                    label9.Text = "En la posición " + mejorada[0, 0].ToString() + "," + mejorada[0, 1].ToString() + " colocar " + dato.obtenerDescripcion(mejorada[pos, 2]);
                else
                    label9.Text = "En la posición " + mejorada[0, 1].ToString() + "," + mejorada[0, 0].ToString() + " colocar " + dato.obtenerDescripcion((double)1 / mejorada[pos, 2]);
            }

                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pos++;
            label9.Text = "En la posición " + mejorada[pos, 0].ToString() + "," + mejorada[pos, 1].ToString() + " colocar " + dato.obtenerDescripcion((double)mejorada[pos, 2]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ComparacionAlternativas frmCompAlternativas = new ComparacionAlternativas(id_proyecto, id_experto);
            frmCompAlternativas.ShowDialog();
            this.Close();
            
            //this.Close();
            //Singleton.Instance.crearComparacionAlternativas(id_proyecto, id_experto);
            
            //pasarle una lista

        }
    }
}
