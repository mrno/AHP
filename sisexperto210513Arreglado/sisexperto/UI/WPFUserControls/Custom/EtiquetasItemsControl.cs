using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;
using Point = System.Drawing.Point;
using Size = System.Windows.Size;

namespace sisexperto.UI.WPFUserControls.Custom
{
    public class EtiquetasItemsControl : ItemsControl
    {
        protected override void OnRender(DrawingContext dc)
        {
            if (Items != null && Items.Count > 1)
            {
                var size = new Size((int)ActualWidth, (int)ActualHeight);

                var textos = (from object item in Items
                              select
                                  new FormattedText(item.ToString(), CultureInfo.GetCultureInfo("en-us"),
                                                    FlowDirection.LeftToRight, new Typeface("Verdana"), 12, Brushes.Black)).
                    ToList();

                var altoTexto = textos.First().Height;
                var espacioEntreTextos = (size.Height - altoTexto * Items.Count) / (Items.Count - 1);

                for (int i = 0; i < Items.Count; i++)
                {
                    dc.DrawText(textos.ElementAt(i),
                                new System.Windows.Point(0, (espacioEntreTextos + altoTexto) * i));
                }
            }
        }
    }
}
