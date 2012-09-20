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
    public partial class NuevoProyecto : Form
    {
        private DALDatos dato = new DALDatos();
        private gisiabaseEntities gisiaContexto = new gisiabaseEntities();
        private List<experto> lista = new List<experto>();

        public NuevoProyecto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dato = new DALDatos();
            dato.altaProyecto(txt1.Text, txt2.Text);
            foreach (experto exp in lista)
            {
                if(exp.id_experto == 0)
                    dato.altaExperto(exp.nombre, exp.apellido, exp.nom_usuario, exp.clave);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            dataGridView2.Visible = false;

            //DataGridViewRowCollection filas = dataGridView1.Rows;

            //foreach (DataGridViewRow row in filas)
            //{
            //    experto exp = new experto();
            //    exp = (experto)row.DataBoundItem;
            //    MessageBox.Show(exp.nombre.ToString());
            //}
        

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            dataGridView2.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

           // DataGridViewRow row = new DataGridViewRow();
            if (groupBox2.Visible == true)
            {
                experto exp = new experto();
                exp.nombre = txt3.Text;
                exp.apellido = txt4.Text;
                exp.nom_usuario = txt5.Text;
                exp.clave = txt6.Text;
                lista.Add(exp);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;
                txt3.Text = "";
                txt4.Text = "";
                txt5.Text = "";
                txt6.Text = "";
                txt7.Text = "";
            }
            else
            {
                experto exp = new experto();
                exp = (experto)dataGridView2.CurrentRow.DataBoundItem;
                lista.Add(exp);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;
 
            }
            

            //gisiaContexto.AddToexperto(exp);
            //dataGridView1.DataSource = gisiaContexto.experto;





            //dataGridView1.Rows.Add(exp);
            //gisiaContexto.AddToexperto(exp);
            //dataGridView1.DataSource = gisiaContexto.experto;



            //experto exp = new experto();
            //exp.nombre = txt3.Text;
            //exp.apellido = txt4.Text;
            //exp.nom_usuario = txt5.Text;
            //exp.clave = txt6.Text;
            //lista.Add(exp);
            //dataGridView1.DataSource = lista;
            //dataGridView1.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lista.Count != 0)
            {
                lista.Remove((experto)dataGridView1.CurrentRow.DataBoundItem);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;
            }
        }

        private void NuevoProyecto_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            dataGridView2.Visible = true;
            dataGridView2.DataSource = dato.todosExpertos();
        }
    }
}
