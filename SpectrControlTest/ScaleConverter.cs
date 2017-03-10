using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using SpectrControl.Controls;

namespace SpectrControl
{
    internal class ScaleConverter : IMultiValueConverter
    {
        #region Implementation of IMultiValueConverter

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var list = ((IEnumerable<double>)values[0]).ToList();
            double max = list.Max();
            double min = list.Min() * 0.98;
            double height = (double)values[1];
            double value = (double)values[2];
            ScaleType st = (ScaleType)values[3];
            switch (st)
            {
                case ScaleType.N:
                    break;
                case ScaleType.Log:
                    max -= min;
                    value -= min;
                    value = 20 * Math.Log10(value);
                    max = 20 * Math.Log10(max);
                    break;
                case ScaleType.Ln:
                    value = Math.Log(value);
                    max = Math.Log(max);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return value * height * 0.95 / max;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
