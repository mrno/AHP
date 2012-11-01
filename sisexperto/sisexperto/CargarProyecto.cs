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
    public partial class CargarProyecto : Form
    {
        private DALDatos dato = new DALDatos();
        private int id_proyecto;
        private List<alternativa> listaAlternativas = new List<alternativa>();
        private List<criterio> listaCriteiro = new List<criterio>();
        private List<experto_proyecto> listaExpertoProyecto;
        private DataGridViewCell cell;
        private DataGridViewRow row;

        public CargarProyecto(int id)
        {
            InitializeComponent();
            id_proyecto = id;
        }
        private void CargarProyecto_Load(object sender, EventArgs e)
        {

           RefrescarListaExpertoProyecto();
            dataGridExpertoProyecto.AutoGenerateColumns = true;

            textBox1.Enabled = false;
        }

        private void RefrescarListaExpertoProyecto()
        {
            listaExpertoProyecto = dato.expertosPorProyecto2(id_proyecto);

            dataGridExpertoProyecto.DataSource = listaExpertoProyecto;




        }
        private void button5_Click(object sender, EventArgs e)
        {
            if ((listaAlternativas.Count > 2) && (listaCriteiro.Count > 2))
            {
                dato = new DALDatos();

                foreach (criterio cri in listaCriteiro)
                {
                    dato.altaCriterio(id_proyecto, cri.nombre, cri.descripcion);
                }

                foreach (alternativa alt in listaAlternativas)
                {
                    dato.altaAlternativa(id_proyecto, alt.nombre, alt.descripcion);
                }

                List<experto> listaExp = dato.expertosPorProyecto(id_proyecto);
                List<criterio> listaCri = dato.criteriosPorProyecto(id_proyecto);
                List<alternativa> listaAlt = dato.alternativasPorProyecto(id_proyecto);

                foreach(experto exp in listaExp)
                {
                    dato.altaMatrizCriterio(id_proyecto, exp.id_experto);

                    foreach (criterio cri in listaCri)
                    {
                        dato.altaMatrizAlternativa(id_proyecto, exp.id_experto, cri.id_criterio);
                    }
                }

                Queue<criterio> colaCri;
                Queue<alternativa> colaAlt;

                foreach (experto exp in listaExp)
                {
                    int fila = 0;
                    int columna;

                    colaCri = dato.colaCriterios(id_proyecto);
                    foreach (criterio c in listaCri)
                    {
                        columna = fila;
                        colaCri.Dequeue();
                        foreach (criterio c2 in colaCri)
                        {
                            columna++;
                            dato.guardarComparacionCriterios(id_proyecto, exp.id_experto, c.id_criterio, c2.id_criterio, fila, columna, 0);
                        }
                        fila++;
                    }
                }

                foreach (experto exp in listaExp)
                {
                    foreach (criterio cri in listaCri)
                    {
                        int fila = 0;
                        int columna;
                        colaAlt = dato.colaAlternativas(id_proyecto);

                        foreach (alternativa a in listaAlt)
                        {
                            columna = fila;
                            colaAlt.Dequeue();
                            foreach (alternativa a2 in colaAlt)
                            {
                                columna++;
                                dato.guardarComparacionAlternativas(id_proyecto, exp.id_experto, cri.id_criterio, a.id_alternativa, a2.id_alternativa, fila, columna, 0);
                            }
                            fila++;
                        }
                    }
                }

                MessageBox.Show("Las alternativas y criterios se han creado correctamente. Las asignaciones se realizaron satisfactoriamente.");
                this.Close();
            }
            else
                MessageBox.Show("La cantidad mínima para cada conjunto de alternativas o criterios es de 3.");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((txt1.Text != "") && (txt2.Text != ""))
            {
                alternativa alt = new alternativa();
                alt.nombre = txt1.Text;
                alt.descripcion = txt2.Text;
                listaAlternativas.Add(alt);
                gridAlternativas.DataSource = null;
                gridAlternativas.DataSource = listaAlternativas;
                txt1.Text = "";
                txt2.Text = "";
            }
            else
                MessageBox.Show("Debe completar los campos Nombre y Descripcion.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((txt3.Text != "") && (txt4.Text != ""))
            {
                criterio cri = new criterio();
                cri.nombre = txt3.Text;
                cri.descripcion = txt4.Text;
                listaCriteiro.Add(cri);
                gridCriterios.DataSource = null;
                gridCriterios.DataSource = listaCriteiro;
                txt3.Text = "";
                txt4.Text = "";
            }
            else
                MessageBox.Show("Debe completar los campos Nombre y Descripcion.");
        }

        private void dataGridExpertoProyecto_Click(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Enabled = true;
            row = this.dataGridExpertoProyecto.SelectedRows[0];
           // row = this.dataGridExpertoProyecto.Rows[cell.RowIndex];
            
            string value = row.Cells[3].Value.ToString();
            textBox1.Text = value;
            
        }


        private void cargarEnListLaPonderacion()
        {
           // listaExpertoProyecto[cell.RowIndex].ponderacion=Convert.ToInt32(textBox1.Text);
            
            Int32 ponderacion = Convert.ToInt32(textBox1.Text);
            Int32 id_experto = listaExpertoProyecto[row.Index].id_experto;
            dato.modificarPonderacionExpertoProyectoAHP(id_proyecto,id_experto,ponderacion);
            RefrescarListaExpertoProyecto();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarEnListLaPonderacion();
        }

     

   
    }


}
