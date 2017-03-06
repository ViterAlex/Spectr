using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SpectrControl.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public static readonly DependencyProperty FfValuesProperty = DependencyProperty.Register(
    "FfValues", typeof(ObservableCollection<double>), typeof(MainViewModel), new PropertyMetadata(default(ObservableCollection<double>)));

        public ObservableCollection<double> FfValues
        {
            get
            {
                return (ObservableCollection<double>)GetValue(FfValuesProperty);
            }
            set
            {
                SetValue(FfValuesProperty, value);
            }
        }

        public static readonly DependencyProperty ValuesSetProperty = DependencyProperty.Register(
            "ValuesSet", typeof(ObservableCollection<ObservableCollection<double>>), typeof(MainViewModel), new PropertyMetadata(default(ObservableCollection<ObservableCollection<double>>)));

        public ObservableCollection<ObservableCollection<double>> ValuesSet
        {
            get
            {
                return (ObservableCollection<ObservableCollection<double>>)GetValue(ValuesSetProperty);
            }
            set
            {
                SetValue(ValuesSetProperty, value);
            }
        }


        public DispatcherTimer SpectrTimer { get; }

        #region Constructor

        public MainViewModel()
        {
            ValuesSet = new ObservableCollection<ObservableCollection<double>>();
            for (int i = 0; i < 5; i++)
            {
                ValuesSet.Add(new ObservableCollection<double>());
            }
            var rnd = new Random();
            foreach (var values in ValuesSet)
            {
                for (int i = 0; i < 128; i++)
                {
                    values.Add(rnd.NextDouble(100, 400));
                }
            }

            SpectrTimer = new DispatcherTimer();
            SpectrTimer.Interval = TimeSpan.FromMilliseconds(200);
            SpectrTimer.Tick += (sender, args) =>
            {
                var i = rnd.Next(ValuesSet.Count);
                ValuesSet[i][rnd.Next(ValuesSet[i].Count)] = rnd.NextDouble(100, 1000);
                OnPropertyChanged(nameof(ValuesSet));
            };
        }

        #endregion
    }
}
