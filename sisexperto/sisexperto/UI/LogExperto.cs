using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisExperto.Entidades;

namespace sisExperto
{
    public partial class LogExperto : Form
    {


        public delegate void InicioSesion(Experto exp);
        public event InicioSesion InicioCorrecto;

        private FachadaProyectosExpertos _fachada;
        private string user;
        private string pass;


        public LogExperto(FachadaProyectosExpertos Fachada)
        {
            InitializeComponent();
            _fachada = Fachada;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            user = textBoxUsuario.Text;
            pass = textBoxContrasena.Text;
            entrar();
            
        }
        private void entrar()
        {
           


            var Experto = _fachada.ObtenerExpertoValido(user, pass);
            if (Experto == null)
            {
                labelSesionInv.Visible = true;
            }
            else
            {
                InicioCorrecto(Experto);
                this.Close();
            }

        }
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxContrasena_Enter(object sender, EventArgs e)
        {
            labelSesionInv.Visible = false;
        }

        private void textBoxUsuario_Enter(object sender, EventArgs e)
        {
            labelSesionInv.Visible = false;
        }

     

    
    }
}
