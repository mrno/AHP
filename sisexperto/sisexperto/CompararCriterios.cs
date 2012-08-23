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
        public CompararCriterios()
        {
            InitializeComponent();
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
                        Label l = (Label)miLabel;
                        l.Text = dato.valorarPalabra(track.Value);
                    }
                }
            }
            
        }

        private void CompararCriterios_Load(object sender, EventArgs e)
        {
            dato = new DALDatos();
            int y = 70;
            
            List<criterio> lista = dato.todosCriterios();
            //List<criterio> lista2 = dato.todosCriterios();
            
            Queue<criterio> lista2 = dato.colaCriterios();
            foreach (criterio c in lista)
            {
                //pos = pos +1;

                //lista2.Remove(c);
                lista2.Dequeue();
                
                foreach (criterio c2 in lista2)
                {
                    Label miLabel = new Label();
                    miLabel.SetBounds(900, y, 200, 40);
                    miLabel.Name = c.id_criterio.ToString() + c2.id_criterio.ToString();
                    //miLabel.Text = miLabel.Name;
                    Controls.Add(miLabel);

                    Label izquierda = new Label();
                    izquierda.SetBounds(700, y, 100, 40);
                    izquierda.Text = c.nombre.ToString();
                    Controls.Add(izquierda);

                    Label derecha = new Label();
                    derecha.SetBounds(1100, y, 100, 40);
                    derecha.Text = c2.nombre.ToString();
                    Controls.Add(derecha);

                    TrackBar track = new TrackBar();
                    track.SetBounds(300, y, 300, 40);
                    track.Name = c.id_criterio.ToString() + c2.id_criterio.ToString();
                    track.Scroll += new System.EventHandler(this.mostrar);
                    Controls.Add(track);

                    y += 70;
                }
            }

        }
    }
}
