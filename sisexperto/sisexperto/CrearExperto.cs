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
    public partial class CrearExperto : Form
    {
        private FachadaProyectosExpertos _fachada;

        public delegate void Expertos(experto experto);
        public event Expertos ExpertoAgregado;

        public CrearExperto(FachadaProyectosExpertos Fachada)
        {
            InitializeComponent();
            _fachada = Fachada;
        }

        private void buttonCrearContinuar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Guardar();
                Limpiar();
                labelValidacion.Text = "Usuario creado con éxito.";
            }
        }

        private void buttonCrearSalir_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Guardar();
                Close();
            }
        }

        private void Guardar()
        {
            experto exp = new experto();
            exp.nombre = textBoxNombre.Text;
            exp.apellido = textBoxApellido.Text;
            exp.nom_usuario = textBoxUsuario.Text;
            exp.clave = textBoxClave.Text;

            //se crea el experto y se dispara el evento para que actualice los grids correspondientes
            ExpertoAgregado(_fachada.AltaExperto(exp));
        }

        private void Limpiar()
        {
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxUsuario.Text = "";
            textBoxClave.Text = "";
            textBoxClaveRepetida.Text = "";
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validar()
        {
            string error1 = "";
            string error2 = "";
            if (_fachada.ExisteExperto(textBoxUsuario.Text))
                error1 = "Nombre de usuario no disponible. ";
            if ((textBoxClave.Text != textBoxClaveRepetida.Text) || textBoxClave.Text == "")
            {
                error2 = "Las contraseñas ingresadas no coinciden.";
            }
            labelValidacion.Text = error1 + error2;

            return (!_fachada.ExisteExperto(textBoxUsuario.Text) &&
                ((textBoxClave.Text == textBoxClaveRepetida.Text) && textBoxClave.Text != ""));
        }
        
    }
}
