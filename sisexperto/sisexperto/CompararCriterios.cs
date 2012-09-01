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
    public partial class CompararCriterios : Form
    {
        private DALDatos dato;
        int id_proyecto;
        int id_experto;
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
            int y = 70;

            List<comparacion_criterio> listaComparacion = dato.comparacionCriterioPorExperto(id_proyecto, id_experto);

            List<criterio> lista = dato.criteriosPorProyecto(id_proyecto);

            foreach (comparacion_criterio comp in listaComparacion)
            {
                Label izquierdaTB = new Label();
                izquierdaTB.SetBounds(10, y, 60, 30);
                izquierdaTB.Text = dato.criterioNombre(comp.id_criterio1);
                Controls.Add(izquierdaTB);

                TrackBar track = new TrackBar();
                track.SetBounds(70, y, 450, 40);
                track.Name = comp.pos_fila.ToString() + 'x' + comp.pos_columna.ToString();
                track.SetRange(1, 17);
                track.Scroll += new System.EventHandler(this.mostrar);
                Controls.Add(track);

                Label derechaTB = new Label();
                derechaTB.SetBounds(520, y, 100, 30);
                derechaTB.Text = dato.criterioNombre(comp.id_criterio2);
                Controls.Add(derechaTB);

                Label izquierda = new Label();
                izquierda.SetBounds(620, y, 100, 30);
                izquierda.Text = dato.criterioNombre(comp.id_criterio1);
                Controls.Add(izquierda);


                Label miLabel = new Label();
                miLabel.SetBounds(720, y, 200, 50);
                miLabel.Name = comp.pos_fila.ToString() + 'x' + comp.pos_columna.ToString();
                //miLabel.Text = miLabel.Name;
                Controls.Add(miLabel);


                Label derecha = new Label();
                derecha.SetBounds(920, y, 100, 30);
                derecha.Text = dato.criterioNombre(comp.id_criterio2);
                Controls.Add(derecha);

                y += 70;
            }

            //Queue<criterio> lista2 = dato.colaCriterios(id_experto);//OJO ACÁ, ESTA DEMÁS EL ID_EXPERTO
            //foreach (criterio c in lista)
            //{
            //    lista2.Dequeue();

            //    foreach (criterio c2 in lista2)
            //    {
            //        Label izquierdaTB = new Label();
            //        izquierdaTB.SetBounds(10, y, 60, 30);
            //        izquierdaTB.Text = c.nombre.ToString();
            //        Controls.Add(izquierdaTB);

            //        TrackBar track = new TrackBar();
            //        track.SetBounds(70, y, 450, 40);
            //        track.Name = c.id_criterio.ToString() + c2.id_criterio.ToString();
            //        track.SetRange(1, 17);
            //        track.Scroll += new System.EventHandler(this.mostrar);
            //        Controls.Add(track);

            //        Label derechaTB = new Label();
            //        derechaTB.SetBounds(520, y, 100, 30);
            //        derechaTB.Text = c.nombre.ToString();
            //        Controls.Add(derechaTB);



            //        Label izquierda = new Label();
            //        izquierda.SetBounds(620, y, 100, 30);
            //        izquierda.Text = c.nombre.ToString();
            //        Controls.Add(izquierda);


            //        Label miLabel = new Label();
            //        miLabel.SetBounds(720, y, 200, 50);
            //        miLabel.Name = c.id_criterio.ToString() + c2.id_criterio.ToString();
            //        //miLabel.Text = miLabel.Name;
            //        Controls.Add(miLabel);


            //        Label derecha = new Label();
            //        derecha.SetBounds(920, y, 100, 30);
            //        derecha.Text = c2.nombre.ToString();
            //        Controls.Add(derecha);


            //        y += 70;
            //    }
            //}

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
