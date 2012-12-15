using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisexperto.Entidades;
using sisexperto.Fachadas;
using sisexperto.UI;

namespace sisExperto
{
    public partial class ComparacionAlternativas : Comparacion
    {
        public ComparacionAlternativas(AlternativaMatriz matriz, FachadaProyectosExpertos facha, Proyecto proy) : base(matriz, facha, proy)
        {
            _listaElementosAComparar = proy.Alternativas;
        }

        public override void MoverTrack(object sender, EventArgs e)
        {
            buttonListo.Enabled = true;
            buttonAplicar.Enabled = false;
            buttonDescartar.Enabled = false;
            labelSugerencia.Text = "Sugerencia:";

            var track = (TrackBar) sender;
            var _matrizAlternativa = (AlternativaMatriz)_matriz;
            foreach (Control miLabel in panelComparacion.Controls)
            {
                if (miLabel is Label)
                {
                    if (miLabel.Name == track.Name)
                    {
                        string[] posicion = track.Name.Split('x');
                        var l = (Label) miLabel;
                        l.Text = valorarPalabra(track.Value);

                        foreach (AlternativaFila fila in _matrizAlternativa.FilasAlternativa)
                        {
                            foreach (AlternativaCelda celda in fila.CeldasAlternativas)
                            {
                                if ((celda.Fila == Convert.ToInt32(posicion[0])) &&
                                    (celda.Columna == Convert.ToInt32(posicion[1])))
                                {
                                    //1
                                    celda.ValorAHP = valorarNumero(track.Value);

                                    //2
                                    _matrizAlternativa.Consistencia = false;
                                    
                                    _fachada.GuardarValoracion();
                                }
                            }
                        }

                        //1   dato.modificarComparacionAlternativa(id_proyecto, id_Experto, Convert.ToInt32(posicion[0].ToString()), Convert.ToInt32(posicion[1].ToString()), Convert.ToInt32(posicion[2].ToString()), dato.valorarNumero(track.Value));
                        //2   dato.actualizarConsistenciaProyecto(id_proyecto, id_Experto, false);
                        //3   dato.actualizarMatrizAlternativa(id_proyecto, id_Experto, id_Criterio, false);
                    }
                }
            }
        }


        public override void OnLoad(object sender, EventArgs e)
        {
            label19.Text = "Comparación de Alternativas";

            int y = 140;
            var _matrizAlternativa = (AlternativaMatriz)_matriz;

            foreach (AlternativaFila fila in _matrizAlternativa.FilasAlternativa)
            {
                foreach (AlternativaCelda celda in fila.CeldasAlternativas)
                {
                    GenerarTracks(fila.Alternativa, celda.Fila, celda.Alternativa, celda.Columna, celda.ValorAHP, y);
                    y += 90;
                }
            }
                      
        }

    }
}