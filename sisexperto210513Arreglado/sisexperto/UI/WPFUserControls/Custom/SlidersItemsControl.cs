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
    public class SlidersItemsControl : ItemsControl
    {
        protected override void OnRender(DrawingContext dc)
        {
            if (Items != null && Items.Count > 1)
            {
                var alturaTextos = new FormattedText(Items.GetItemAt(0).ToString(), CultureInfo.GetCultureInfo("en-us"),
                                                    FlowDirection.LeftToRight, new Typeface("Verdana"), 14, Brushes.Black).Height;

                var margenesVerticales = ((ActualHeight - 37)/Items.Count - alturaTextos)/2;

                Margin = new Thickness(0, margenesVerticales, 0, margenesVerticales - 24);
            }
        }
    }
}
