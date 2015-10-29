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
using dndReboot.Model;
using dndReboot.ViewModel;

namespace dndReboot.View
{
    /// <summary>
    /// Interaction logic for AddRaceView.xaml
    /// </summary>
    public partial class AddRaceView : UserControl
    {
        public AddRaceView()
        {
            InitializeComponent();
            RaceCreationViewModel rcvm = new RaceCreationViewModel();
            DataContext = rcvm;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
