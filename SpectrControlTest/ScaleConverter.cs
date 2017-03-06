using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using SpectrControl.Controls;

namespace SpectrControl
{
    internal class ScaleConverter : IMultiValueConverter
    {
        #region Implementation of IMultiValueConverter

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double max = ((IEnumerable<double>)values[0]).Max();
            double height = (double)values[1];
            double value = (double)values[2];
            ScaleType st = (ScaleType)values[3];
            switch (st)
            {
                case ScaleType.N:
                    break;
                case ScaleType.Log:
                    value = Math.Log10(value);
                    max = Math.Log10(max);
                    break;
                case ScaleType.Ln:
                    value = Math.Log(value);
                    max = Math.Log(max);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return value * height * 0.9 / max;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
