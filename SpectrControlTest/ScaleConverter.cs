using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SpectrControl
{
    internal class ScaleConverter : IMultiValueConverter
    {
        #region Implementation of IMultiValueConverter

        private static int _counter;
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //Debug.WriteLine("Counter: {0}",++_counter);
            double max = ((IEnumerable<double>)values[0]).Max();
            double height = (double)values[1];
            double val = (double)values[2];
            //Debug.Assert(value < 500, "value<500");
            return val * height * 0.9 / max;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
