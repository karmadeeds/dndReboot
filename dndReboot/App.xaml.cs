using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using dndReboot.ViewModel;
using dndReboot.View;

namespace dndReboot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow mw = new MainWindow();
            var viewModel = new MainWindowViewModel();
            //MockUIWindow ui = new MockUIWindow();
            //ui.Show();
            mw.DataContext = viewModel;
            mw.Show();
            //Roll rw = new Roll();
            //rw.Show();
            
        }
    }
}
