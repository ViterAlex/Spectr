using System.Collections.Generic;
using System.Windows;

namespace SpectrControl.Controls
{
    /// <summary>
    /// Interaction logic for Spectr.xaml
    /// </summary>
    public partial class Spectr

    {
        public static readonly DependencyProperty ValuesProperty = DependencyProperty.Register(
            "Values", typeof(IEnumerable<double>), typeof(Spectr), new PropertyMetadata(default(IEnumerable<double>)));

        public IEnumerable<double> Values
        {
            get
            {
                return (IEnumerable<double>)GetValue(ValuesProperty);
            }
            set
            {
                SetValue(ValuesProperty, value);
            }
        }
        
        public Spectr()
        {
            InitializeComponent();
        }
    }
}
