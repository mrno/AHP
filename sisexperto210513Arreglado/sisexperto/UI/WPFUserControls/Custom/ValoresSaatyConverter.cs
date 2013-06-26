using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace sisexperto.UI.WPFUserControls.Custom
{
    public class ValoresSaatyConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valor = (double) value;
            var salida = "-";
            //importancia mayor o igual de los elementos
            if (valor >= 1 && valor <= 9)
            {
                salida = valor.ToString(CultureInfo.InvariantCulture);
            }
            //importancia menor
            if (valor < 1 && valor > 0)
            {
                salida = "1/" + Math.Ceiling(1.0 / valor).ToString(CultureInfo.InvariantCulture);
            }
            //importancia no asignada
            return salida;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var texto = value.ToString();
            var salida = 1.0;
            if (texto.Contains("/"))
            {
                int valor;
                if (int.TryParse(texto.Split('/').ElementAt(1), out valor) && valor >= 1 && valor <= 9)
                    salida = 1.0/valor;
            }
            else
            {
                int valor;
                if (int.TryParse(texto, out valor) && valor >= 1 && valor <= 9)
                    salida = valor;
            }
            return salida;
        }

        #endregion
    }
}
