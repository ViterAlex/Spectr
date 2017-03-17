using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace SpectrControl
{
    public class MaxMinConverter : IMultiValueConverter
    {
        #region Implementation of IMultiValueConverter

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var param = parameter.ToString();
            var list = ((IEnumerable<double>)values[0]).ToList();
            var item = (double)values[1];
            switch (param)
            {
                case "max":
                    return IsMax(list, item);
                case "min":
                    return IsMin(list, item);
            }
            return false;
        }

        private static bool IsMin(IEnumerable<double> list, double item)
        {
            var result = list.Min().Equals(item);
            return result;
        }

        private static bool IsMax(IEnumerable<double> list, double item)
        {
            var result = list.Max().Equals(item);
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}