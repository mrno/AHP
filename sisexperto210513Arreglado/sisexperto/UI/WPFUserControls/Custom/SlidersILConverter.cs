using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace sisexperto.UI.WPFUserControls.Custom
{
    public class SlidersILConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              System.Globalization.CultureInfo culture)
        {
            var slider = (Slider)value;

            return slider.Maximum - slider.Value;
        }

        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            var slider = (Slider)value;

            return slider.Maximum - slider.Value;
        }
    }
}