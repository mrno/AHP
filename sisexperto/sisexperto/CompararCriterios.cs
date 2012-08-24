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



                    Label izquierdaTB = new Label();
                    izquierdaTB.SetBounds(30, y, 100, 40);
                    izquierdaTB.Text = c.nombre.ToString();
                    Controls.Add(izquierdaTB);

                    TrackBar track = new TrackBar();
                    track.SetBounds(130, y, 500, 40);
                    track.Name = c.id_criterio.ToString() + c2.id_criterio.ToString();
                    track.SetRange(1, 17);
                    track.Scroll += new System.EventHandler(this.mostrar);
                    Controls.Add(track);
                    
                    Label derechaTB = new Label();
                    derechaTB.SetBounds(630, y, 100, 40);
                    derechaTB.Text = c.nombre.ToString();
                    Controls.Add(derechaTB);



                    Label izquierda = new Label();
                    izquierda.SetBounds(730, y, 100, 40);
                    izquierda.Text = c.nombre.ToString();
                    Controls.Add(izquierda);


                    Label miLabel = new Label();
                    miLabel.SetBounds(830, y, 200, 40);
                    miLabel.Name = c.id_criterio.ToString() + c2.id_criterio.ToString();
                    //miLabel.Text = miLabel.Name;
                    Controls.Add(miLabel);

                    
                    Label derecha = new Label();
                    derecha.SetBounds(1030, y, 100, 40);
                    derecha.Text = c2.nombre.ToString();
                    Controls.Add(derecha);

                    
                    y += 70;
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
