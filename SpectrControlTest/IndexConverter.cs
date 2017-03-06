using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace SpectrControl
{
    /// <summary>
    /// Класс для отображения номеров строк в DataGrid
    /// </summary>
    public class IndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (ListBoxItem)value;
            var listBox = ItemsControl.ItemsControlFromItemContainer(item) as ListBox;
            if (listBox == null || item == null)
            {
                return null;
            }
            int index = listBox.ItemContainerGenerator.IndexFromContainer(item) + 1;
            return index.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
