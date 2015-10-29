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
using dndReboot.Commands;
using dndReboot.Model;
using dndReboot.ViewModel;
using System.ComponentModel;
namespace dndReboot.View
{
    /// <summary>
    /// Interaction logic for Roll.xaml
    /// </summary>
    public partial class Roll : Window
    {

        static bool HasRolled = false;
        //Character MyCharacter = MainWindowViewModel.MyCharacter;
        
        public Roll()
        {
            InitializeComponent();
        }

        public int RollForIt(Random rr)
        {
            int[] rolls = { rr.Next(1,7), rr.Next(1,7), rr.Next(1,7), rr.Next(1,7)};
            int min = rolls.Min();
            int sum = rolls.Sum();
            int statRoll = sum - min;
            return statRoll;
        }
        public static void EnumVisual(Visual myVisual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
                //MessageBox.Show(childVisual.GetType().ToString());
                if (childVisual.GetType() == typeof(Button))
                {
                    (childVisual as Button).IsEnabled = true;
                }
                else if (childVisual.GetType() == typeof(ListBoxItem))
                {
                    (childVisual as ListBoxItem).IsEnabled = true;
                }
                EnumVisual(childVisual);
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (HasRolled == false)
            {
                HasRolled = true;
                RollButton.Content = "Re-roll Stats";
            }
            if (Rolls.HasItems == true) Rolls.Items.Clear();
            //int[] rolls = new int[4];
            //Random r = new Random();
            //rolls[0] = r.Next(1, 7);
            //rolls[1] = r.Next(1, 7);
            //rolls[2] = r.Next(1, 7);
            //rolls[3] = r.Next(1, 7);
            //int min = rolls.Min();
            //int total = rolls.Sum();

            //foreach (var roll in rolls)
            //{
            //    Rolls.Items.Add(roll);
            //}
            //Rolls.Items.Add(min);
            //Rolls.Items.Add(total);
            Random rr = new Random();
            for (int ii = 0; ii < 6; ii++)
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = RollForIt(rr);
                Rolls.Items.Add(lbi);
            }
        }

        void AssignCommandExecute()
        {
            //bool isinvasion = true;
            //foreach (Model.Race rr in this.AllRaces)
            //{
            //    if (rr.Name.Trim().ToLower() == "human")
            //    {
            //        isinvasion = false;
            //    }
            //}

            //if (isinvasion)
            //{
            //    BackgroundBrush = new SolidColorBrush(Colors.Green);
            //}
            //else
            //{
            //    BackgroundBrush = new SolidColorBrush(Colors.White);
            //}
            //dndReboot.View.Roll window = new dndReboot.View.Roll();
            //window.Show();

        }

        bool AssignCommandCanExecute
        {
            get
            {
                if (this.Rolls.HasItems == false)
                {
                    return false;
                }
                return true;
            }
        }


        private void assignStatButton(object sender, RoutedEventArgs e)
        {
            Character cc= CharacterCreationViewModel.SharedCharacter;
            //cc = (CharacterView.DataContextProperty as Character);
            var b = sender as Button;
            var bc = (sender as Button).Content.ToString();

            if (Rolls.SelectedItem != null)
            {
                ListBoxItem lbItem = Rolls.SelectedItem as ListBoxItem;
                int ii = int.Parse(lbItem.Content.ToString());
                switch (bc)
                {
                    case "Strength":
                        cc.Str.Value = ii;
                        break;
                    case "Dexterity":
                        cc.Dex.Value = ii;
                        break;
                    case "Constitution":
                        cc.Con.Value = ii;
                        break;
                    case "Intelligence":
                        cc.Int.Value = ii;
                        break;
                    case "Wisdom":
                        cc.Wis.Value = ii;
                        break;
                    case "Charisma":
                        cc.Chr.Value = ii;
                        break;
                }
                b.IsEnabled = false;
                lbItem.IsEnabled = false;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EnumVisual(this);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
