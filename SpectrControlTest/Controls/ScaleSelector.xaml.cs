using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpectrControl.Controls
{
    /// <summary>
    /// Interaction logic for ScaleSelector.xaml
    /// </summary>
    public partial class ScaleSelector : UserControl
    {
        public static readonly DependencyProperty ScaleTypeProperty = DependencyProperty.Register(
            "ScaleType", typeof(ScaleType), typeof(ScaleSelector), new PropertyMetadata(default(ScaleType)));

        public ScaleType ScaleType
        {
            get
            {
                return (ScaleType) GetValue(ScaleTypeProperty);
            }
            set
            {
                SetValue(ScaleTypeProperty, value);
            }
        }
        public ScaleSelector()
        {
            InitializeComponent();
        }
    }
}
