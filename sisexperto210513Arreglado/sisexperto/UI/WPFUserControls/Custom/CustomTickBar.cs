using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;
using Point = System.Windows.Point;
using Size = System.Drawing.Size;

namespace sisexperto.UI.WPFUserControls.Custom
{
    public class CustomTickBar : TickBar
    {
        protected override void OnRender(DrawingContext dc)
        {
            var size = new Size((int)ActualWidth, (int)ActualHeight);
            int tickCount = (int)(Maximum - Minimum);
            
            // Draw each tick text
            var textos = new List<FormattedText>();

            for (int i = 0; i <= tickCount; i++)
            {
                var text = Convert.ToString(Convert.ToInt32(this.Minimum + this.TickFrequency * i), 10);

                var formattedText = new FormattedText(text, CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight, new Typeface("Verdana"), 10, Brushes.Black);

                textos.Add(formattedText);
            }
            
            // Calculate tick's setting
            double tickFrequencySize = ((size.Width - textos.Sum(x => x.Width)) /(tickCount)) + textos.First().Width ;

            var j = 0;
            foreach (var texto in textos)
            {
                dc.DrawText(texto, new Point(((int)((tickFrequencySize) * j + texto.Width/2)), 0));
                j++;
            }
        }
    }
}
