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
                                item.ValorILNumerico = etiqueta.Indice;
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

                    // track.Value =  Mediar(celda.ValorILNumerico);
                    track.Scroll += mostrar;
                    Controls.Add(track);


                    //var derechaTB = new Label();
                    //derechaTB.SetBounds(500, y, 80, 30);
                    //derechaTB.Text = celda.Criterio.Nombre;
                    //Controls.Add(derechaTB);

                    var miLabel = new Label();
                    miLabel.SetBounds(150, y + 45, 250, 30);
                    //    double doble = dato.obtenerValorCompCriterio(comp.id_proyecto, comp.id_Experto, comp.pos_fila,
                    //                                                  comp.pos_columna);
                    //miLabel.Text = celda.ValorILLinguistico;
                    miLabel.Name = fila.Nombre;
                    Controls.Add(miLabel);

                    y += 90;
                    
                }
            }
        }
    } 


