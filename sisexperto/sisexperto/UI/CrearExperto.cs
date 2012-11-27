using System;
using System.Windows.Forms;
using sisExperto.Entidades;

namespace sisExperto
{
    public partial class CrearExperto : Form
    {
        #region Delegates

        public delegate void Expertos(Experto Experto);

        #endregion

        private readonly FachadaProyectosExpertos _fachada;

        public CrearExperto(FachadaProyectosExpertos Fachada)
        {
            InitializeComponent();
            _fachada = Fachada;
        }

        public event Expertos ExpertoAgregado;

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
            var exp = new Experto();
            exp.Nombre = textBoxNombre.Text;
            exp.Apellido = textBoxApellido.Text;
            exp.Usuario = textBoxUsuario.Text;
            exp.Clave = textBoxClave.Text;

            //se crea el Experto y se dispara el evento para que actualice los grids correspondientes

            //ExpertoAgregado(_fachada.AltaExperto(exp));
            _fachada.AltaExperto(exp);
            try
            {
                ExpertoAgregado(_fachada.ObtenerExpertoValido(exp.Usuario, exp.Clave));
            }
            catch (Exception)
            {
            }
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
            Close();
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