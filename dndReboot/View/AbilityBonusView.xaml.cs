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

namespace dndReboot.View
{
    /// <summary>
    /// Interaction logic for AbilityBonusView.xaml
    /// </summary>
    public partial class AbilityBonusView : UserControl
    {
        public AbilityBonusView()
        {
            //AbilityBonusViewModel abvm = new AbilityBonusViewModel();
            //DataContext = abvm;
            InitializeComponent();
        }

        public AbilityBonusView(AbilityBonusViewModel abvm)
        {
            DataContext = abvm;
            InitializeComponent();            
        }
    }
}
