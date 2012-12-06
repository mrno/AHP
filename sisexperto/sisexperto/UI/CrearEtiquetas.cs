using System;
using System.Collections.Generic;
using System.Windows.Forms;
using sisexperto.Entidades;

namespace sisExperto.UI
{
    public partial class CrearEtiquetas : Form
    {
        #region Delegates

        public delegate void EdicionProyecto();

        #endregion

        private readonly FachadaProyectosExpertos _fachada;
        private readonly int _token;
        private ConjuntoEtiquetas _conjuntoEtiquetas = new ConjuntoEtiquetas();
        private List<Etiqueta> _etiquetas = new List<Etiqueta>();

        public CrearEtiquetas(int Token)
        {
            InitializeComponent();
            _token = Token;
            //_proyectoSeleccionado = Proyecto;
            _fachada = new FachadaProyectosExpertos();
        }

        public event EdicionProyecto ProyectoModificado;

        private void buttonAgregarEtiqueta_Click(object sender, EventArgs e)
        {
            if (textBoxNombreEtiqueta.Text != "" && textBoxDescripcionEtiqueta.Text != "")
            {
                var etiqueta = new Etiqueta
                                   {
                                       Nombre = textBoxNombreEtiqueta.Text,
                                       Descripcion = textBoxDescripcionEtiqueta.Text,
                                       Indice = _etiquetas.Count,
                                       a = 0,
                                       b = 0,
                                       c = 0,
                                   };
                _etiquetas.Add(etiqueta);
                textBoxDescripcionEtiqueta.Text = "";
                textBoxNombreEtiqueta.Text = "";
                buttonQuitarEtiqueta.Enabled = true;
                dataGridViewEtiquetas.DataSource = null;
                dataGridViewEtiquetas.DataSource = _etiquetas;
            }
            else MessageBox.Show("El Nombre y la Descripción de la etiqueta no pueden estar vacíos.");
        }

        private void buttonQuitarEtiqueta_Click(object sender, EventArgs e)
        {
            _etiquetas.Remove((Etiqueta) dataGridViewEtiquetas.CurrentRow.DataBoundItem);
            dataGridViewEtiquetas.DataSource = null;
            dataGridViewEtiquetas.DataSource = _etiquetas;

            if (_etiquetas.Count == 0)
                buttonQuitarEtiqueta.Enabled = false;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            //button 5

            if ((_etiquetas.Count >= 3 && _etiquetas.Count <= 13) && ((_etiquetas.Count & 1) != 0))
            {
                PrepararGuardado();
                _conjuntoEtiquetas.Descripcion = textBoxDescripcionConjunto.Text;
                _conjuntoEtiquetas.Nombre = textBoxNombreConjunto.Text;
                _conjuntoEtiquetas.Token = _token;
                _conjuntoEtiquetas.Etiquetas = _etiquetas;
                _conjuntoEtiquetas.Cantidad = _etiquetas.Count;
                _fachada.GuardarConjuntoEtiquetas(_conjuntoEtiquetas);
              
                MessageBox.Show("Se creo el conjunto de etiquetas satisfactoriamente.");
                Limpiar();
                Close();
            }
            else
            {
                string error = "Se tienen que crear un conjunto con una cantidad de 3, 5, 7, 9, 11 o 13 etiquetas";
                if (_etiquetas.Count == 0) error = "No se crearon Alternativas ni Criterios.";
                MessageBox.Show(error);
            }
        }

        private void Limpiar()
        {
            textBoxDescripcionConjunto.Text = "";

            textBoxNombreConjunto.Text = "";

            dataGridViewEtiquetas.DataSource = null;

            buttonQuitarEtiqueta.Enabled = false;

            _etiquetas = new List<Etiqueta>();

            _conjuntoEtiquetas = new ConjuntoEtiquetas();
        }

        private void buttonLimpiarAsignaciones_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (CambiosGuardados())
            {
                MessageBox.Show("Existen cambios no guardados.");
            }
            else Close();
        }

        private bool CambiosGuardados()
        {
            return false;
        }

        //Se setean los valores del triangulo del conjunto de etiquetas antes de guardar
        private void PrepararGuardado()
        {
            foreach (Etiqueta etiqueta in _etiquetas)
            {
                etiqueta.b = (double) etiqueta.Indice/_etiquetas.Count;
            }
        }


        private void AutoCreado(Int32 cuantos)
        {
            _etiquetas = new List<Etiqueta>();
            int padd = ((cuantos - 1)/2);
            for (int i = 0; i < cuantos; i++)
            {
                int rdo = i <= padd ? i - padd : i - padd;

                var etiqueta = new Etiqueta
                                   {
                                       Nombre = CrearNombre(rdo),
                                       Descripcion = CrearNombre(rdo),
                                       Indice = _etiquetas.Count,
                                   };
                _etiquetas.Add(etiqueta);
            }

            buttonQuitarEtiqueta.Enabled = true;
            dataGridViewEtiquetas.DataSource = null;
            dataGridViewEtiquetas.DataSource = _etiquetas;
        }


        private String CrearNombre(Int32 valor)
        {
            if (valor == (float) -6) //     TRECE
                return "Extremadamente mas bajo"; //
            if (valor == (float) -5) //      ONCE
                return "Bastante mas bajo"; //
            if (valor == (float) -4) //      NUEVE
                return "Mas bajo"; //      
            if (valor == (float) -3) //     SIETE
                return "Moderadamente mas bajo"; //  
            if (valor == (float) -2) //    CINCO
                return "Minimamente mas bajo"; //
            if (valor == (float) -1) //          
                return "Bajo"; //
            if (valor == (float) 0) //
                return "Medio"; //  TRES
            if (valor == (float) 1) //
                return "Alto"; //
            if (valor == (float) 2) //
                return "Minimamente mas alto"; //    CINCO
            if (valor == (float) 3) //  
                return "Moderadamente mas alto"; //     SIETE
            if (valor == (float) 4) //
                return "Mas alto"; //       NUEVE
            if (valor == (float) 5) //
                return "Bastante mas Alto"; //    ONCE
            if (valor == (float) 6) //
                return "Extremadamente Alto"; //     TRECE
            else
            {
                return "";
            }
        }

        private void buttonTres_Click(object sender, EventArgs e)
        {
            AutoCreado(Convert.ToInt32(buttonTres.Text));
            //comboBoxCantidad.SelectedItem = 3;
        }

        private void buttonCinco_Click(object sender, EventArgs e)
        {
            AutoCreado(Convert.ToInt32(buttonCinco.Text));
            //comboBoxCantidad.SelectedItem = 5;
        }

        private void buttonSiete_Click(object sender, EventArgs e)
        {
            AutoCreado(Convert.ToInt32(buttonSiete.Text));
            //comboBoxCantidad.SelectedItem = 7;
        }

        private void buttonNueve_Click(object sender, EventArgs e)
        {
            AutoCreado(Convert.ToInt32(buttonNueve.Text));
            //comboBoxCantidad.SelectedItem = 9;
        }

        private void buttonOnce_Click(object sender, EventArgs e)
        {
            AutoCreado(Convert.ToInt32(buttonOnce.Text));
            //comboBoxCantidad.SelectedItem = 11;
        }

        private void buttonTrece_Click(object sender, EventArgs e)
        {
            AutoCreado(Convert.ToInt32(buttonTrece.Text));
            //comboBoxCantidad.SelectedItem = 13;
        }
    }
}