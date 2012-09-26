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
        private DALDatos dato;
        private int id_proyecto;
        private int id_experto;
        public ComparacionAlternativas(int id_proy, int id_exp)
        {
            InitializeComponent();
            id_proyecto = id_proy;
            id_experto = id_exp;
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

        private void ComparacionAlternativas_Load(object sender, EventArgs e)
        {
            dato = new DALDatos();
            int y = 70;

            List<comparacion_alternativa> listaComparacion = dato.comparacionAlternativaPorExperto(id_proyecto, id_experto);
            //List<criterio> listaCriterio = dato.criteriosPorProyecto(id_proyecto);
            //List<alternativa> listaAlternativa = dato.alternativasPorProyecto(id_proyecto);

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
                //miLabel.Text = miLabel.Name;
                Controls.Add(miLabel);


                Label derecha = new Label();
                derecha.SetBounds(1180, y, 100, 30);
                derecha.Text = dato.alternativaNombre(comp.id_alternativa2);
                Controls.Add(derecha);

                y += 70;
            }
        }
    }
}
