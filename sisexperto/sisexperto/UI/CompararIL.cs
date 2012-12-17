using System;
using System.Collections.Generic;
using System.Windows.Forms;
using sisExperto;
using sisExperto.Entidades;
using sisexperto.Entidades;


namespace sisexperto.UI
{
    public partial class CompararIL : Form
    {
        private readonly Proyecto _proyecto;
        private readonly Experto _experto;
        private readonly ExpertoEnProyecto _expertoEnProyecto;
        private readonly FachadaProyectosExpertos _miFachada;
        private readonly AlternativaIL _alternativaIl;
        private TrackBar track;
        private int i = 0;

        public CompararIL(FachadaProyectosExpertos facha, Proyecto proy, AlternativaIL alternativaIl)
        {
            InitializeComponent();
            _miFachada = facha;
            _proyecto = proy;
            _experto = facha.Experto;
            _expertoEnProyecto = _miFachada.SolicitarExpertoProyectoActual(_proyecto, _experto);
            _alternativaIl = alternativaIl;
        }

        protected int valorarDoble(double valor)
        {
            foreach (var item in _expertoEnProyecto.ValoracionIl.ConjuntoEtiquetas.Etiquetas)
            {
                if (valor == item.b)
                    return item.Indice;
                return 1;
            }
            return 1;
        }

        private void mostrar(object sender, EventArgs e)
          {
            track = (TrackBar) sender;
              i = 0;
            foreach (Control miLabel in FindForm().Controls)
            {
                if (miLabel is Label)
                {
                    if (miLabel.Name == track.Name)
                    {
                        string[] posicion = track.Name.Split('x');
                        Label l = (Label) miLabel;

                        List<Etiqueta> listaEtiquetas = _expertoEnProyecto.ValoracionIl.ConjuntoEtiquetas.Etiquetas;

                        var etiqueta = listaEtiquetas[(track.Value - 1)];
                        l.Text = etiqueta.Nombre;

                        foreach (var item in _alternativaIl.ValorCriterios)
                        {
                            if (item.Nombre == track.Name)
                            {
                                item.ValorILNumerico = etiqueta.Indice - 1;
                                item.ValorILLinguistico = etiqueta.Nombre;
                            }
                        }
                        _miFachada.GuardarValoracion();
                    }
                }
                i++;
            }
        }

        private int Mediar(int valorCelda)
        {
            
            return valorCelda == 0 ? 1 : 1;
        }

        public void CompararIL_load(object sender, EventArgs e)
        {
                int y = 140;
                nombreAlternativa.Text = _alternativaIl.Nombre;
                
                foreach (var fila in _alternativaIl.ValorCriterios)
                {
                    var izquierdaTB = new Label();
                    izquierdaTB.SetBounds(5, y, 75, 50);
                    izquierdaTB.Text = fila.Nombre;
                    Controls.Add(izquierdaTB);

                    var track = new TrackBar();
                    track.SetBounds(75, y, 400, 45);
                    track.Name = fila.Nombre;
                    track.SetRange(1, _expertoEnProyecto.ValoracionIl.ConjuntoEtiquetas.Cantidad);

                    //track.Value = valorarDoble(fila.ValorILNumerico);
                    if (fila.ValorILNumerico == 0)
                        track.Value = (int)Math.Ceiling((double)track.Maximum / 2);
                    else
                        track.Value = (Int32)fila.ValorILNumerico + 1;

                    track.Scroll += mostrar;
                    Controls.Add(track);

                    var miLabel = new Label();
                    miLabel.SetBounds(150, y + 45, 250, 30);
                    miLabel.Text = fila.ValorILLinguistico;
                    miLabel.Name = fila.Nombre;
                    Controls.Add(miLabel);

                    y += 90;
                    
                }
            }
        }
    } 


