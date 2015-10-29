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
using System.Windows.Shapes;
using dndReboot.ViewModel;

namespace dndReboot.View
{
    /// <summary>
    /// Interaction logic for AddProficienciesView.xaml
    /// </summary>
    public partial class AddProficienciesView : Window
    {
        public static ViewModelBase vm;
        
        public AddProficienciesView(ViewModelBase viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            //vm = (WeaponProficiencyViewModel)viewModel;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

                //MessageBox.Show(s);
            
        }
    }
}
