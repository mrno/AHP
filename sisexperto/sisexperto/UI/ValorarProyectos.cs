using sisexperto.Entidades;
using sisexperto.Entidades.AHP;
using sisExperto;
using sisExperto.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace sisexperto.UI
{
    public partial class ValorarProyectos : Form
    {
        private Experto _experto;
        private FachadaProyectosExpertos _fachada;
        private List<Proyecto> _listaProyectos = new List<Proyecto>();
        private ExpertoEnProyecto _expertoEnProyecto;

        private Proyecto _proyectoSeleccionado; 

        private CriterioMatriz _matrizCriterio;
        private AlternativaMatriz _matrizAlternativa;

        private bool _generada = false;

        public ValorarProyectos(Experto experto,  Proyecto ProyectoSeleccionado, FachadaProyectosExpertos Fachada)
        {
            InitializeComponent();
            _proyectoSeleccionado = ProyectoSeleccionado;
            _experto = experto;
            _fachada = Fachada;
            _expertoEnProyecto = _fachada.SolicitarExpertoProyectoActual(_proyectoSeleccionado, _experto);
            _listaProyectos = _fachada.SolicitarProyectosAsignados(_experto).ToList();
        }

        private void ValorarProyectos_Load(object sender, EventArgs e)
        {
            comboBoxProyectos.DataSource = _listaProyectos;
            comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            comboBoxProyectos.SelectedIndexChanged += (comboBoxProyectos_SelectedIndexChanged);

            CargarMatricesYPestanias();
        }

        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;
            _expertoEnProyecto = _fachada.SolicitarExpertoProyectoActual(_proyectoSeleccionado, _experto);
            CargarMatricesYPestanias();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_proyectoSeleccionado.Tipo == "AHP" && tabControl1.SelectedIndex == 1)
            {
                e.Cancel = true;
            }
            if (_proyectoSeleccionado.Tipo == "IL" && tabControl1.SelectedIndex == 0)
            {
                e.Cancel = true;
            }
        }

        private void CargarMatricesYPestanias()
        {
            groupBoxMatrizComparacion.Controls.Clear();
            _generada = false;
            switch (_proyectoSeleccionado.Tipo)
            {
                case "AHP":
                    cargarMatricesAHP();
                    tabPageAHP.Enabled = true;
                    tabPageIL.Enabled = false;
                    tabControl1.SelectedTab = tabPageAHP;
                    break;
                case "IL":
                    //cargarMatricesIL();
                    tabPageAHP.Enabled = false;
                    tabPageIL.Enabled = true;
                    tabControl1.SelectedTab = tabPageIL;
                    break;
                case "Ambos":
                    tabPageAHP.Enabled = true;
                    tabPageIL.Enabled = true;
                    cargarMatricesAHP();
                    //cargarMatricesIL();
                    break;
            }
        }

        private void cargarMatricesAHP()
        {
            _expertoEnProyecto = (from c in _experto.ProyectosAsignados
                                  where c.Proyecto.ProyectoId == _proyectoSeleccionado.ProyectoId
                                  select c).FirstOrDefault();
            _matrizCriterio = _expertoEnProyecto.ValoracionAHP.CriterioMatriz;
            checkBoxConsistencia.Checked = _matrizCriterio.Consistencia;

            List<AlternativaMatriz> listaAlternativas = _expertoEnProyecto.ValoracionAHP.AlternativasMatrices.ToList();
            alternativaMatrizBindingSource.DataSource = null;
            alternativaMatrizBindingSource.DataSource = listaAlternativas;
            gridAlternativa.Refresh();
            gridAlternativa.Rows[0].Selected = true;
            //for (int i = 0; i < listaAlternativas.Count; i++)
            //{
            //    gridAlternativa.Rows[i].Cells[0].Value = listaAlternativas[i].Criterio.Nombre;
            //}
            gridAlternativa.RowEnter += (gridAlternativa_RowEnter);
        }

        private void gridAlternativa_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var matriz = gridAlternativa.SelectedRows[0].DataBoundItem as AlternativaMatriz;
                DibujarMatriz(matriz);
            }
            catch (Exception) { }
        }


        protected void DibujarMatriz(IAHPMatrizComparable matrizObjeto)
        {
            //groupBoxMatrizComparacion.Controls.Clear();

            var matriz = matrizObjeto.Matriz;
            
            DiagonalPrincipal(matriz.GetLength(0), 100, 100, 400, 400);

            for (int columna = 1; columna < matriz.GetLength(0); columna++)
            {
                for (int fila = 0; fila < columna; fila++)
                {
                    if (!_generada)
                    {
                        GenerarCelda(matriz.GetLength(0), fila, columna, matriz[fila, columna], 100, 100, 400, 400);
                        GenerarInversa(matriz.GetLength(0), fila, columna, matriz[fila, columna], 100, 100, 400, 400);
                    }
                    else
                    {
                        groupBoxMatrizComparacion.Controls.Find(fila + "x" + columna, true).First().Text = ParseValue(matriz[fila, columna]);
                        groupBoxMatrizComparacion.Controls.Find("I" + fila + "x" + columna, true).First().Text = ParseValue(matriz[fila, columna]);
                    }
                }
            }
            _generada = true;
        }
        
        protected void DiagonalPrincipal(int dimension, int margenSuperior, int margenIzquierdo, int altoContendor, int anchoContenedor)
        {
            for (int i = 0; i < dimension; i++)
            {
                var panel = new Panel();
                panel.Height = altoContendor / dimension;
                panel.Width = anchoContenedor / dimension;
                panel.Top = i * altoContendor / dimension + margenSuperior; // -panel.Height / 2; ;
                panel.Left = i * anchoContenedor / dimension + margenIzquierdo;
                panel.BorderStyle = BorderStyle.FixedSingle;
                groupBoxMatrizComparacion.Controls.Add(panel);

                var label = new Label();
                label.Text = (1.0).ToString();
                label.TextAlign = ContentAlignment.TopLeft;
                label.Width = panel.Width;
                label.Top = (panel.Height - label.Height) / 2;
                label.Text = ParseValue(1);
                label.TextAlign = ContentAlignment.MiddleCenter;
                
                groupBoxMatrizComparacion.Controls.Add(label);

                panel.Controls.Add(label);
            }            
        }

        protected void GenerarCelda(int dimension, int fila, int columna, double valor, int margenSuperior, int margenIzquierdo, int altoContendor, int anchoContenedor)
        {
            var panel = new Panel();
            panel.Height = altoContendor / dimension;
            panel.Width = anchoContenedor / dimension;
            panel.Top = fila * altoContendor / dimension + margenSuperior; // -panel.Height;
            panel.Left = columna * anchoContenedor / dimension + margenIzquierdo;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.TabIndex = dimension * fila + columna;
            groupBoxMatrizComparacion.Controls.Add(panel);

            var textBox = new TextBox();
            textBox.Name = fila + "x" + columna;
            textBox.BorderStyle = BorderStyle.None;
            //textBox.Height = altoContendor / dimension;
            //textBox.Width = anchoContenedor / dimension;
            //textBox.Top = fila * altoContendor / dimension + margenSuperior;
            //textBox.Left = columna * anchoContenedor / dimension + margenIzquierdo;
            textBox.Width = panel.Width;
            textBox.Top = (panel.Height - textBox.Height) / 2 - 3;
            textBox.Text = ParseValue(valor);
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.KeyUp += (Validated);
            textBox.Leave += (Validated);
            textBox.Leave += (LeaveTextBox);

            panel.Controls.Add(textBox);

            panel.MouseHover += delegate(object sender, EventArgs e) { Cursor = Cursors.IBeam; };
            panel.MouseLeave += delegate(object sender, EventArgs e) { Cursor = Cursors.AppStarting; };

            textBox.Click += delegate(object sender, EventArgs e) { textBox.Focus(); textBox.SelectAll(); };
            panel.Click += delegate(object sender, EventArgs e) { textBox.Focus(); textBox.SelectAll(); };
        }

        protected void GenerarInversa(int dimension,int fila, int columna, double valor, int margenSuperior, int margenIzquierdo, int altoContendor, int anchoContenedor)
        {
            var panel = new Panel();
            panel.Height = altoContendor / dimension;
            panel.Width = anchoContenedor / dimension;
            panel.Top = columna * anchoContenedor / dimension + margenSuperior; // -panel.Height;
            panel.Left = fila * altoContendor / dimension + margenIzquierdo;
            panel.BorderStyle = BorderStyle.FixedSingle;
            groupBoxMatrizComparacion.Controls.Add(panel);

            var label = new Label();
            label.Name = "I" + fila + "x" + columna;
            //textBox.Height = altoContendor / dimension;
            //textBox.Width = anchoContenedor / dimension;
            //textBox.Top = columna * anchoContenedor / dimension + margenIzquierdo;
            //textBox.Left = fila * altoContendor / dimension + margenSuperior;
            label.Width = panel.Width;
            label.Top = (panel.Height - label.Height) / 2;
            label.Text = ParseValue(valor);
            label.TextAlign = ContentAlignment.MiddleCenter;

            label.Enabled = false;

            panel.Controls.Add(label);
        }

        private string ParseValue(double valor)
        {
            if (valor >= 1)
            {
                return ((int)valor).ToString();
            }
            else
            {
                if (valor <= 0)
                {
                    return "0";
                }
                return "1/" + (int)Math.Ceiling(1.0 / valor);
            }
        }

        protected int valorarDoble(double valor)
        {
            if (valor == 0)
                return 9;

            if (valor >= 1)
                return 10 - (int)valor;
            else
                return 8 + (int)Math.Ceiling(1.0 / valor);
        }

        private void LeaveTextBox(object sender, EventArgs e)
        {
            var textbox = (sender as TextBox);
            var inverso = groupBoxMatrizComparacion.Controls.Find("I" + textbox.Name, true).First();

            var texto = textbox.Text;
            if (texto.Contains("/"))
            {
                var ladoDerecho = texto.Split('/').ElementAt(1);
                if (ladoDerecho == "")
                {
                    textbox.Text = "1";
                    inverso.Text = "1";
                }
                else
                {
                    inverso.Text = ladoDerecho;
                }
            }
            else
            {
                if (texto == "0")
                    texto = "1";
                if (texto == "1")
                {
                    inverso.Text = texto;
                }
                else inverso.Text = "1/" + texto;    
            }                          
        }

        private void Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Validated(object sender, EventArgs e)
        {
            var textBox = (sender as TextBox);
            var reg = new Regex("^[1-9]$|^1/$|^1/[1-9]$");
            if (!reg.IsMatch(textBox.Text))
            {
                textBox.Text = "1";
                textBox.SelectAll();
            }
        }
    }
}
