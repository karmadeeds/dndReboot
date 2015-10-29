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
using dndReboot.Utilities;
using dndReboot.ViewModel;

namespace dndReboot.View
{
    /// <summary>
    /// Interaction logic for CharacterSheetView.xaml
    /// </summary>
    public partial class CharacterSheetView : UserControl
    {
        public CharacterSheetView()
        {
            InitializeComponent();
            DataContext = new CharacterViewModel();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            var ctrl = (UserControl) sender;
            if (e.Key == Key.Enter)
            {
                ctrl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<SkillProficiency> temp = new List<SkillProficiency>();
            foreach (SkillProficiency f in SkillProficiency.Dexterity.GetUniqueFlags())
            {
                temp.Add(f);
            }
            foreach (var ss in temp)
            {
                MessageBox.Show(ss.ToString());
            }
        }
    }
}
