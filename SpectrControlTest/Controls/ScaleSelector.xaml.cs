using System.Windows;

namespace SpectrControl.Controls
{
    /// <summary>
    /// Interaction logic for ScaleSelector.xaml
    /// </summary>
    public partial class ScaleSelector
    {
        public static readonly DependencyProperty ScaleTypeProperty = DependencyProperty.Register(
            "ScaleType", typeof(ScaleType), typeof(ScaleSelector), new FrameworkPropertyMetadata(ScaleType.N,FrameworkPropertyMetadataOptions.AffectsRender));

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
