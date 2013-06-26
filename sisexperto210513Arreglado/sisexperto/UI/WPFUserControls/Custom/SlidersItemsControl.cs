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
using sisexperto.UI.WPFUserControls.ViewModels;

namespace sisexperto.UI.WPFUserControls.Custom
{
    public class SlidersItemsControl : ItemsControl
    {
        protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            InvalidateVisual();
        }
        
        protected override void OnRender(DrawingContext dc)
        {
            if (Items != null && Items.Count > 0)
            {
                var alturaTextos = new FormattedText(Items.GetItemAt(0).ToString(), CultureInfo.GetCultureInfo("en-us"),
                                                    FlowDirection.LeftToRight, new Typeface("Verdana"), 14, Brushes.Black).Height;
                var nroEtiquetas = (Items.GetItemAt(0) as CriterioILViewModel).MaximaEtiqueta;
                var margenesVerticales = ((ActualHeight - 37 + 30)/nroEtiquetas - alturaTextos)/2;

                Margin = new Thickness(0, margenesVerticales, 0, margenesVerticales - 18);
            }
        }
    }
}
