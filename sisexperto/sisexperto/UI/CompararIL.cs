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
        private readonly FachadaProyectosExpertos miFachada;
        private readonly CriterioMatriz matrizCriterio;
        private TrackBar track;
        private int i = 0;
        public CompararIL(CriterioMatriz matriz, FachadaProyectosExpertos facha, Proyecto proy)
        {
            InitializeComponent();
            miFachada = facha;
            _proyecto = proy;
            _experto = facha.Experto;
            _expertoEnProyecto = miFachada.SolicitarExpertoProyectoActual(_proyecto, _experto);
             matrizCriterio = matriz;
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
                        var l = (Label) miLabel;

                        l.Text = miFachada.SolicitarEtiquetasDelExperto(_expertoEnProyecto)[i].Nombre;

                        foreach (CriterioFila fila in matrizCriterio.FilasCriterio)
                        {
                            foreach (CriterioCelda celda in fila.CeldasCriterios)
                            {
                                if ((celda.Fila == Convert.ToInt32(posicion[0])) &&
                                    (celda.Columna == Convert.ToInt32(posicion[1])))
                                {
                                    //1
                                    celda.ValorILNumerico = (track.Value);

                                    //2
                                    //GuardarConsistencia();    puede ser esa opción también.
                                    matrizCriterio.Consistencia = false;

                                    //miFachada.GuardarValoracion();
                                }
                            }
                        }

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

                foreach (CriterioFila fila in matrizCriterio.FilasCriterio)
                {
                    foreach (CriterioCelda celda in fila.CeldasCriterios)
                    {
                        //listaCeldas.Add(celda);

                        var izquierdaTB = new Label();
                        izquierdaTB.SetBounds(5, y, 75, 50);
                        izquierdaTB.Text = fila.Criterio.Nombre;
                        Controls.Add(izquierdaTB);

                        var track = new TrackBar();
                        track.SetBounds(75, y, 400, 45);
                        track.Name = celda.Fila.ToString() + 'x' + celda.Columna.ToString();
                        track.SetRange(1, _expertoEnProyecto.ConjuntoEtiquetas.Cantidad);
                        track.Value =  Mediar(celda.ValorILNumerico);
                        track.Scroll += mostrar;
                        Controls.Add(track);


                        var derechaTB = new Label();
                        derechaTB.SetBounds(500, y, 80, 30);
                        derechaTB.Text = celda.Criterio.Nombre;
                        Controls.Add(derechaTB);

                        var miLabel = new Label();
                        miLabel.SetBounds(150, y + 45, 250, 30);
                        //    double doble = dato.obtenerValorCompCriterio(comp.id_proyecto, comp.id_Experto, comp.pos_fila,
                        //                                                  comp.pos_columna);
                        miLabel.Text = celda.ValorILLinguistico;
                        miLabel.Name = celda.Fila.ToString() + 'x' + celda.Columna.ToString();
                        Controls.Add(miLabel);

                        y += 90;
                    }
                }
            }
        }
    } 


