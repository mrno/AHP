using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace sisexperto.UI.WPFUserControls.Custom
{
    public class EscalaSaatyConverter: IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valor = (double) value;
            if(valor >= (1.0/9) && valor <= 9)
                return EscalaSaaty.ToList().IndexOf((double)value);
            return 8;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int entero = int.Parse(value.ToString());
            double valor = EscalaSaaty.ElementAt(entero);
            return valor;
        }

        #endregion

        public static readonly double[] EscalaSaaty = new double[]
                                                          {
                                                              9, 8, 7, 6, 5, 4, 3, 2, 1, 
                                                              1.0/2, 1.0/3, 1.0/4, 1.0/5, 
                                                              1.0/6, 1.0/7, 1.0/8, 1.0/9
                                                          };
        
    }

    public class ImportanciaEscalaSaatyConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Importancia((double) value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static string Importancia(double valor)
        {
            if (valor == 0 || valor > 9) //corresponde a 0
                return "Elementos no comparados";
            if (valor == 9.0) //corresponde a 9
                return "es extremadamente más importante que";
            if (valor == 8.0) //corresponde a 8
                return "es entre muy fuertemente a extremandamente más importante que";
            if (valor == 7.0) //corresponde a 7
                return "es muy fuertemente más importante que";
            if (valor == 6.0) //corresponde a 6
                return "es estre fuerte y muy fuertemente más importante que";
            if (valor == 5.0) //corresponde a 5
                return "es fuertemente más importante";
            if (valor == 4.0) //corresponde a 4
                return "es entre moderada y fuertemente más importante que";
            if (valor == 3.0) //corresponde a 3
                return "es moderadamente más importante que";
            if (valor == 2.0) //corresponde a 2
                return "es mínimamente más importante que";
            if (valor == 1.0) //corresponde a 1
                return "es igual de importante que";
            if (valor == 1.0/2) //corresponde a 1/2
                return "es mínimamente menos importante que";
            if (valor == 1.0/3) //corresponde a 1/3
                return "es moderadamente menos importante que";
            if (valor == 1.0/4) //corresponde a 1/4
                return "es entre moderada y fuertemente menos importante que";
            if (valor == 1.0/5) //corresponde a 1/5
                return "es fuertemente menos importante que";
            if (valor == 1.0/6) //corresponde a 1/6
                return "es estre fuerte y muy fuertemente menos importante que";
            if (valor == 1.0/7) //corresponde a 1/7
                return "es muy fuertemente menos importante";
            if (valor == 1.0/8) //corresponde a 1/8
                return "es entre muy fuertemente a extremandamente menos importante que";
            if (valor == 1.0/9) //corresponde a 1/9
                return "es extremadamente menos importante que";

            return "";
        }

        #endregion
    }
}
