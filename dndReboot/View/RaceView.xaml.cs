using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using dndReboot.DataAccess;
using dndReboot.ViewModel;
using dndReboot.Model;
using dndReboot.Utilities;


namespace dndReboot.View
{
    /// <summary>
    /// Interaction logic for RaceView.xaml
    /// </summary>
    public partial class RaceView : UserControl
    {
        public RaceView()
        {
            InitializeComponent();
            DataContext = new RaceViewModelTest();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
