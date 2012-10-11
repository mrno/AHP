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
        private gisiabaseEntities2 gisiaContexto = new gisiabaseEntities2();
        private List<experto> lista = new List<experto>();
        private List<experto> listaTodosExpertos = new List<experto>();
        private int id_experto;

        public NuevoProyecto(int id_exp)
        {
            InitializeComponent();
            id_experto = id_exp;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ((txt1.Text != "") && (txt2.Text != ""))
            {
                if (lista.Count != 0)
                {
                    dato = new DALDatos();
                    proyecto proy = dato.altaProyecto(id_experto, txt1.Text, txt2.Text);
                    foreach (experto exp in lista)
                    {
                        if (exp.id_experto == 0)
                        {
                            dato.asignarProyecto(proy.id_proyecto, dato.altaExperto(exp.nombre, exp.apellido, exp.nom_usuario, exp.clave).id_experto);
                        }
                        else
                        {
                            dato.asignarProyecto(proy.id_proyecto, exp.id_experto);
                        }
                    }
                    MessageBox.Show("El proyecto se ha creado satisfactoriamente.");
                    this.Close();
                }
                else
                    MessageBox.Show("Debe asignar por lo menos un experto al proyecto.");
            }
            else
                MessageBox.Show("Debe completar los campos Nombre y Objetivo.");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            dataGridView2.Visible = false;
        }

        private void btnExistente_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            dataGridView2.Visible = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
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
                listaTodosExpertos.Remove((experto)dataGridView2.CurrentRow.DataBoundItem);
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = listaTodosExpertos;
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

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (lista.Count != 0)
            {
                listaTodosExpertos.Add((experto)dataGridView1.CurrentRow.DataBoundItem);
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = listaTodosExpertos;
                lista.Remove((experto)dataGridView1.CurrentRow.DataBoundItem);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;
            }
        }

        private void NuevoProyecto_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            dataGridView2.Visible = true;
            listaTodosExpertos = dato.todosExpertos();
            dataGridView2.DataSource = listaTodosExpertos;
        }
    }
}
