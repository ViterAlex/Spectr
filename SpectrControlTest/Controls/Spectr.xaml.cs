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

        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(
            "Caption", typeof(string), typeof(Spectr), new PropertyMetadata(default(string)));

        public string Caption
        {
            get
            {
                return (string) GetValue(CaptionProperty);
            }
            set
            {
                SetValue(CaptionProperty, value);
            }
        }

        public Spectr()
        {
            InitializeComponent();
        }
    }
}
