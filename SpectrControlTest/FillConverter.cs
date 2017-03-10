using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace SpectrControl
{
    public class FillConverter : IMultiValueConverter
    {
        #region Implementation of IMultiValueConverter

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var defaultFill = values[0] as Brush;
            var minFill = values[1] as Brush;
            var maxFill = values[2] as Brush;
            var valuesSet = values[3] as IEnumerable<double>;
            var value = (double)values[4];
            IEnumerable<double> enumerable = valuesSet as IList<double> ?? valuesSet.ToList();
            if (enumerable.Min().Equals(value))
            {
                return minFill;
            }
            if (enumerable.Max().Equals(value))
            {
                return maxFill;
            }
            return defaultFill;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}