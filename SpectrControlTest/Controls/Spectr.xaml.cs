using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace SpectrControl.Controls
{
    /// <summary>
    /// Interaction logic for Spectr.xaml
    /// </summary>
    public partial class Spectr

    {
        public static readonly DependencyProperty ValuesProperty = DependencyProperty.Register(
            "Values", typeof(IEnumerable<double>), typeof(Spectr), new FrameworkPropertyMetadata(default(IEnumerable<double>), FrameworkPropertyMetadataOptions.AffectsMeasure));

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
                return (string)GetValue(CaptionProperty);
            }
            set
            {
                SetValue(CaptionProperty, value);
            }
        }

        public static readonly DependencyProperty MinBrushProperty = DependencyProperty.Register(
            "MinBrush", typeof(Brush), typeof(Spectr), new PropertyMetadata(Brushes.Blue));

        public Brush MinBrush
        {
            get
            {
                return (Brush)GetValue(MinBrushProperty);
            }
            set
            {
                SetValue(MinBrushProperty, value);
            }
        }

        public static readonly DependencyProperty MaxBrushProperty = DependencyProperty.Register(
            "MaxBrush", typeof(Brush), typeof(Spectr), new PropertyMetadata(Brushes.DarkGreen));

        public Brush MaxBrush
        {
            get
            {
                return (Brush)GetValue(MaxBrushProperty);
            }
            set
            {
                SetValue(MaxBrushProperty, value);
            }
        }

        public Spectr()
        {
            InitializeComponent();
            Background = Brushes.DarkOliveGreen;
            Foreground = Brushes.Yellow;
        }
    }
}
