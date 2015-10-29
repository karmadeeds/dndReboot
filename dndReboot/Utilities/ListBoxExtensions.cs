using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using dndReboot.Model;

namespace dndReboot.Utilities
{
    public static class ListBoxExtensions
    {
        // Using a DependencyProperty as the backing store for SearchValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemListProperty =
            DependencyProperty.RegisterAttached("SelectedItemList", typeof(IList), typeof(ListBoxExtensions),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnSelectedItemListChanged)));

        public static IList GetSelectedItemList(DependencyObject obj)
        {
            return (IList)obj.GetValue(SelectedItemListProperty);
        }

        public static void SetSelectedItemList(DependencyObject obj, IList value)
        {
            obj.SetValue(SelectedItemListProperty, value);
        }

        private static void OnSelectedItemListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listbox = d as ListBox;
            if (listbox != null)
            {
                listbox.SelectedItems.Clear();
                var selectedItems = e.NewValue as IList;
                if (selectedItems != null)
                {
                    foreach (var item in selectedItems)
                    {
                        listbox.SelectedItems.Add(item);
                    }
                }
            }
        }

        //Testing with IEnumerable<ValueDescription>
        //public static readonly DependencyProperty SelectedValueDescriptionProperty =
        //    DependencyProperty.RegisterAttached("SelectedVDList", typeof(ValueDescription), typeof(ListBoxExtensions),
        //    new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnSelectedVDListChanged)));

        //public static ObservableCollection<ValueDescription> GetSelectedVDList(DependencyObject obj)
        //{
        //    return (ObservableCollection<ValueDescription>) obj.GetValue(SelectedValueDescriptionProperty);
        //}

        //public static void SetSelectedVDList(DependencyObject obj, ObservableCollection<ValueDescription> value)
        //{
        //    obj.SetValue(SelectedValueDescriptionProperty, value);
        //}

        //private static void OnSelectedVDListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var listbox = d as ListBox;
        //    if (listbox != null)
        //    {
        //        listbox.SelectedItems.Clear();
        //        var selectedItems = e.NewValue as ObservableCollection<ValueDescription>;
        //        if (selectedItems != null)
        //        {
        //            foreach (var item in selectedItems)
        //            {
        //                listbox.SelectedItems.Add(item);
        //            }
        //        }
        //    }
        //}



        //public static readonly DependencyProperty SelectedWeaponProficiencyProperty =
        //    DependencyProperty.RegisterAttached("SelectedWPList", typeof(WeaponProficiency), typeof(ListBoxExtensions),
        //    new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnSelectedWPListChanged)));
        //public static IEnumerable<WeaponProficiency> GetSelectedWPList(DependencyObject obj)
        //{
        //    return (IEnumerable<WeaponProficiency>)obj.GetValue(SelectedWeaponProficiencyProperty);
        //}

        //public static void SetSelectedWPList(DependencyObject obj, IEnumerable<WeaponProficiency> value)
        //{
        //    obj.SetValue(SelectedWeaponProficiencyProperty, value);
        //}

        //private static void OnSelectedWPListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var listbox = d as ListBox;
        //    if (listbox != null)
        //    {
        //        listbox.SelectedItems.Clear();
        //        var selectedItems = e.NewValue as IEnumerable<WeaponProficiency>;
        //        if (selectedItems != null)
        //        {
        //            foreach (var item in selectedItems)
        //            {
        //                listbox.SelectedItems.Add(item);
        //            }
        //        }
        //    }
        //}


    }
}
