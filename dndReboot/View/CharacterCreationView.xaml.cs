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
using dndReboot.ViewModel;
using dndReboot.Model;
using System.Reflection;
using dndReboot.DataAccess;
using System.Data.SQLite;
using System.ComponentModel;
using System.Collections.ObjectModel;
using dndReboot.Utilities;

namespace dndReboot.View
{
    /// <summary>
    /// Interaction logic for CharacterCreationView.xaml
    /// </summary>
    public partial class CharacterCreationView : UserControl
    {
        public static CharacterCreationViewModel ccvm = new CharacterCreationViewModel();
        public CharacterCreationView()
        {
            InitializeComponent();
            DataContext = ccvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
