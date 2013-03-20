using sisexperto.Entidades;
using sisexperto.Entidades.AHP;
using sisexperto.Fachadas;
using sisexperto.UI.Clases;
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
        private bool _viendoMatrizCriterio = true;

        private bool _generada = false;
        private List<string> _headers;
        private TextBox _selectedTextBox;

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

        #region Inicializar AHP

        private void CargarMatricesYPestanias()
        {
            panelMatriz.Controls.Clear();
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
            gridAlternativa.RowEnter += (gridAlternativa_RowEnter);

            buttonVerMatrizCriterio_Click(null, null);

            trackBarComparacion.Enabled = false;
            trackBarComparacion.BackColor = SystemColors.Control;
            trackBarComparacion.Scroll += (ScrollTrackBar);
            trackBarComparacion.Enter += delegate(object sender1, EventArgs e1) { trackBarComparacion.Leave += (GuardarValor); };            
        
        }

        private void buttonVerMatrizCriterio_Click(object sender, EventArgs e)
        {
            try
            {
                panelMatriz.Controls.Clear();
                _viendoMatrizCriterio = true;
                _generada = false;
                DibujarMatriz(_matrizCriterio);
            }
            catch (Exception) { }
        }

        private void gridAlternativa_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {   
                _matrizAlternativa = gridAlternativa.SelectedRows[0].DataBoundItem as AlternativaMatriz;
                if (_viendoMatrizCriterio)
                {
                    trackBarComparacion.Enabled = false;
                    trackBarComparacion.BackColor = SystemColors.Control;
                    panelMatriz.Controls.Clear();
                    _generada = false;
                    _viendoMatrizCriterio = false;
                }
                DibujarMatriz(_matrizAlternativa);
            }
            catch (Exception) { }
        }

        #endregion

        #region Comparacion Generica AHP

        protected void DibujarMatriz(IAHPMatrizComparable matrizObjeto)
        {
            labelComparacion.Text = "- seleccione una celda de la matriz";
            labelComparacionTrack.Text = "- seleccione una celda de la matriz";

            var matriz = matrizObjeto.Matriz;

            var margenSuperior = 10;
            var margenIzquierdo = 150;
            var alto = 400;
            var ancho = 400;

            _headers = ObtenerHeaders(matrizObjeto);            

            DiagonalPrincipal(matriz.GetLength(0), margenSuperior, margenIzquierdo, alto, ancho);
            //panelMatriz.Controls.Clear();

            for (int columna = 1; columna < matriz.GetLength(0); columna++)
            {
                for (int fila = 0; fila < columna; fila++)
                {
                    TextBox textBox; 

                    if (!_generada)
                    {
                        textBox = GenerarCelda(matriz.GetLength(0), fila, columna, matriz[fila, columna], margenSuperior, margenIzquierdo, alto, ancho);
                        GenerarInversa(matriz.GetLength(0), fila, columna, matriz[fila, columna], margenSuperior, margenIzquierdo, alto, ancho);                        
                                                
                        DibujarHeaders(_headers, margenSuperior, margenIzquierdo, alto);
                    }
                    else
                    {
                        textBox = panelMatriz.Controls.Find(fila + "x" + columna, true).First() as TextBox;

                        /* desubscribe los eventos que no permiten que se reactualice la matriz */
                        textBox.TextChanged -= (ActualizarTrackBarYLabels);
                        textBox.TextChanged -= (Validated); //keyup

                        textBox.Text = Utilidades.ParseValue(matriz[fila, columna]);
                        panelMatriz.Controls.Find("I" + fila + "x" + columna, true).First().Text = Utilidades.ParseValue(1.0 / matriz[fila, columna]);
                    }
                    /* subscribe los eventos que no permiten que se reactualice la matriz */
                    textBox.TextChanged += (Validated); //keyup originalmente
                    textBox.TextChanged += (ActualizarTrackBarYLabels);
                }
            }
            _generada = true;
        }

        protected List<string> ObtenerHeaders(IAHPMatrizComparable matrizObjeto)
        {
            var titulos = new List<string>();
            if (matrizObjeto is CriterioMatriz)
            {
                var matriz = matrizObjeto as CriterioMatriz;
                foreach (var item in matriz.ExpertoEnProyecto.Proyecto.Criterios)
                {
                    titulos.Add(item.Nombre);
                }
            }
            else if (matrizObjeto is AlternativaMatriz)
            {
                var matriz = matrizObjeto as AlternativaMatriz;
                foreach (var item in matriz.ExpertoEnProyecto.Proyecto.Alternativas)
                {
                    titulos.Add(item.Nombre);
                }
            }
            return titulos;
        }

        protected void DibujarHeaders(List<string> headers, int margenSuperior, int margenIzquierdo, int alto)
        {
            var separacionVertical = alto / headers.Count;
            
            for (int i = 0; i < headers.Count; i++)
            {               
                var header = new Label();
                header.Name = "header-" + i;
                header.Width = margenIzquierdo - 20;
                header.Top = margenSuperior + separacionVertical * i + separacionVertical / 2 - header.Height / 2;
                header.Left = 10;
                header.Text = headers[i];
                panelMatriz.Controls.Add(header);               
            }
        }
        
        protected void DiagonalPrincipal(int dimension, int margenSuperior, int margenIzquierdo, int altoContendor, int anchoContenedor)
        {
            for (int i = 0; i < dimension; i++)
            {
                var panel = new Panel();
                panel.Height = altoContendor / dimension;
                panel.Width = anchoContenedor / dimension;
                panel.Top = i * altoContendor / dimension + margenSuperior;
                panel.Left = i * anchoContenedor / dimension + margenIzquierdo;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panelMatriz.Controls.Add(panel);

                var label = new Label();
                label.Text = (1.0).ToString();
                label.TextAlign = ContentAlignment.TopLeft;
                label.Width = panel.Width;
                label.Top = (panel.Height - label.Height) / 2;
                label.Text = Utilidades.ParseValue(1);
                label.TextAlign = ContentAlignment.MiddleCenter;

                panelMatriz.Controls.Add(label);

                panel.Controls.Add(label);
            }            
        }

        protected TextBox GenerarCelda(int dimension, int fila, int columna, double valor, int margenSuperior, int margenIzquierdo, int altoContendor, int anchoContenedor)
        {
            var panel = new Panel();
            panel.Height = altoContendor / dimension;
            panel.Width = anchoContenedor / dimension;
            panel.Top = fila * altoContendor / dimension + margenSuperior;
            panel.Left = columna * anchoContenedor / dimension + margenIzquierdo;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.TabIndex = dimension * fila + columna;
            panelMatriz.Controls.Add(panel);

            var textBox = new TextBox();
            textBox.Name = fila + "x" + columna;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Width = panel.Width;
            textBox.Top = (panel.Height - textBox.Height) / 2 - 3;
            textBox.Text = Utilidades.ParseValue(valor);
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.Leave += (Validated);
            //textBox.Leave += (LeaveTextBox);

            panel.Controls.Add(textBox);

            panel.MouseHover += delegate(object sender, EventArgs e) { Cursor = Cursors.IBeam; };
            panel.MouseLeave += delegate(object sender, EventArgs e) { Cursor = Cursors.AppStarting; };

            textBox.Click += delegate(object sender, EventArgs e)
            {
                trackBarComparacion.Enabled = true;
                trackBarComparacion.BackColor = Color.White;
                textBox.Focus();
                textBox.SelectAll();
            };
            panel.Click += delegate(object sender, EventArgs e)
            {
                trackBarComparacion.Enabled = true;
                trackBarComparacion.BackColor = Color.White;
                textBox.Focus(); 
                textBox.SelectAll();
            };

            textBox.Enter += delegate(object sender, EventArgs e) { _selectedTextBox.Leave += (GuardarValor); };
            textBox.Enter += (PrepararLabelsYTrackbar);
            panel.Enter += (PrepararLabelsYTrackbar);

            textBox.Enter += (ActualizarTrackBarYLabels);
            ////textBox.TextChanged += (ActualizarTrackBarYLabels);

            return textBox;
        }

        protected void GenerarInversa(int dimension,int fila, int columna, double valor, int margenSuperior, int margenIzquierdo, int altoContendor, int anchoContenedor)
        {
            var panel = new Panel();
            panel.Height = altoContendor / dimension;
            panel.Width = anchoContenedor / dimension;
            panel.Top = columna * anchoContenedor / dimension + margenSuperior;
            panel.Left = fila * altoContendor / dimension + margenIzquierdo;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panelMatriz.Controls.Add(panel);

            var label = new Label();
            label.Name = "I" + fila + "x" + columna;
            label.Width = panel.Width;
            label.Top = (panel.Height - label.Height) / 2;
            label.Text = Utilidades.ParseValue(1.0 / valor);
            label.TextAlign = ContentAlignment.MiddleCenter;

            label.Enabled = false;

            panel.Controls.Add(label);
        }

        

        private void LeaveTextBox(object sender, EventArgs e)
        {
            var textbox = (sender as TextBox);
            var inverso = panelMatriz.Controls.Find("I" + textbox.Name, true).First();
            var texto = textbox.Text;
            var valor = Utilidades.ParseValue(texto);

            textbox.Text = Utilidades.ParseValue(valor);
            inverso.Text = Utilidades.ParseValue(1 / valor);                      
        }

        private void PrepararLabelsYTrackbar(object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                _selectedTextBox = ((sender as Panel).Controls[0] as TextBox);
            }
            else
            {
                _selectedTextBox = (sender as TextBox);
            }

            /* Suscripción para guardar */
                        
            int columna = int.Parse(_selectedTextBox.Name.Split('x').ElementAt(1));

            /* Actualizar label superior */
            labelComparacion.Text = string.Format("Comparado con: {0}", _headers[columna]);
        }
        
        private void ActualizarTrackBarYLabels(object sender, EventArgs e)
        {
            int fila = int.Parse(_selectedTextBox.Name.Split('x').ElementAt(0));
            int columna = int.Parse(_selectedTextBox.Name.Split('x').ElementAt(1));

            /* Cargar TrackBar */
            var valor = Utilidades.ParseValue(_selectedTextBox.Text);
            trackBarComparacion.Value = Utilidades.IndiceDelValorEnEscalaFundamental(valor);

            /* Actualizar el label inferior */
            if (_selectedTextBox.Text == "0") labelComparacionTrack.Text = "Valoración: Los elementos aún no fueron comparados";
            else
                labelComparacionTrack.Text = string.Format("Valoración: {0} es {1} que {2}.",
                    _headers[fila], Utilidades.IndiceEscalaFundamentalEnTexto(trackBarComparacion.Value), _headers[columna]); 
        }

        protected void Validated(object sender, EventArgs e)
        {
            var textBox = (sender as TextBox);
            var reg = new Regex("^[1-9]$|^1/$|^1/[1-9]$");
            if (!reg.IsMatch(textBox.Text))
            {
                textBox.Text = "1";
                textBox.SelectAll();
            }

            var inverso = panelMatriz.Controls.Find("I" + textBox.Name, true).First();
            var texto = textBox.Text;
            var valor = Utilidades.ParseValue(texto);

            inverso.Text = Utilidades.ParseValue(1 / valor); 
        }
                

        private void ScrollTrackBar(object sender, EventArgs e)
        {
            _selectedTextBox.Text = Utilidades.ParseValue(Utilidades.ValorDelIndiceEnEscalaFundamental(trackBarComparacion.Value));
        }

        private void GuardarValor(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                _selectedTextBox.Leave -= (GuardarValor);
            }
            else if (sender is TrackBar) 
            {
                trackBarComparacion.Leave -= (GuardarValor);
            }

            int fila = int.Parse(_selectedTextBox.Name.Split('x').ElementAt(0));
            int columna = int.Parse(_selectedTextBox.Name.Split('x').ElementAt(1));

            if (_viendoMatrizCriterio)
            {
                var matriz = _matrizCriterio.Matriz;
                matriz[fila, columna] = Utilidades.ParseValue(_selectedTextBox.Text);

                _matrizCriterio.Matriz = matriz;
            }
            else 
            {
                var matriz = _matrizAlternativa.Matriz;
                matriz[fila, columna] = Utilidades.ParseValue(_selectedTextBox.Text);
                _matrizAlternativa.Matriz = matriz;
            }
            _fachada.GuardarCambios();
        }

        #endregion


        #region Consistencia AHP

        private void buttonConsistencia_Click(object sender, EventArgs e)
        {
            if (_viendoMatrizCriterio)
            {
                GuardarConsistencia(_matrizCriterio);
            }
            else GuardarConsistencia(_matrizAlternativa);
        }

        protected void GuardarConsistencia(IAHPMatrizComparable matriz)
        {
            matriz.Consistencia = FachadaCalculos.Instance.CalcularConsistencia(matriz.Matriz);
            _fachada.GuardarValoracion();
            if (matriz.Consistencia)
                MessageBox.Show("Matriz consistente");
            else
            {
                var sugerencias = GenerarSugerencias(matriz);
                if (sugerencias.Count() > 0)
                {
                    
                }
                else { MessageBox.Show("No hay sugerencias"); }
            }
        }
        
        private List<SugerenciaViewModel> GenerarSugerencias(IAHPMatrizComparable matriz)
        {
            var listaSugerencias = new List<SugerenciaViewModel>();

            var sugerencias = FachadaCalculos.Instance.BuscarSugerencias(matriz.Matriz);
            for (int i = 0; i < sugerencias.Count(); i+= 3)
            {
                var fila = (int)(sugerencias.ElementAt(i).ElementAt(0));
                var columna = (int)(sugerencias.ElementAt(i).ElementAt(1));
                var valor = sugerencias.ElementAt(i).ElementAt(2);

                listaSugerencias.Add(new SugerenciaViewModel
                {
                    Fila = fila,
                    FilaTitulo = _headers.ElementAt(fila),
                    Columna = columna,
                    ColumnaTitulo = _headers.ElementAt(columna),
                    Valor = valor
                });
            }
            return listaSugerencias;
        }
        

        #endregion
    }
}
