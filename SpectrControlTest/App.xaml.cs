﻿using System.Windows;

namespace SpectrControl
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            // Create the ViewModel and expose it using the View's DataContext
            Views.MainView view = new Views.MainView();
            view.DataContext = new ViewModels.MainViewModel();
            view.Show();
        }
    }
}
