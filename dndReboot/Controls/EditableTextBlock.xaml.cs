﻿using System;
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

namespace dndReboot.Controls
{
    /// <summary>
    /// Interaction logic for EditableTextBlock.xaml
    /// </summary>
    public partial class EditableTextBlock : UserControl
    {
        public EditableTextBlock()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(EditableTextBlock), new UIPropertyMetadata());

        private void textBoxName_LostFocus(object sender, RoutedEventArgs e)
        {
            var txtBlock = (TextBlock)((Grid)((TextBox)sender).Parent).Children[0];

            txtBlock.Visibility = Visibility.Visible;
            ((TextBox)sender).Visibility = Visibility.Collapsed;
        }

        private void textBlockName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var txtBox = (TextBox)((Grid)((TextBlock)sender).Parent).Children[1];
            txtBox.Visibility = Visibility.Visible;
            txtBox.Focus();
            ((TextBlock)sender).Visibility = Visibility.Collapsed;
        }

        private void textBoxName_MouseLeave(object sender, MouseEventArgs e)
        {
            var txtBlock = (TextBlock)((Grid)((TextBox)sender).Parent).Children[0];
            var edit = (TextBox) sender;

            //if (edit.IsFocused == false)
            //{
            //    txtBlock.Visibility = Visibility.Visible;
            //    ((TextBox) sender).Visibility = Visibility.Collapsed;
            //}
        }
    }
}
