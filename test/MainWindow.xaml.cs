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

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Point LB1StartMousePos;
        Point LB2StartMousePos;

        private void LB1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LB1StartMousePos = e.GetPosition(null);
        }

        private void LB2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LB2StartMousePos = e.GetPosition(null);
        }

        private void LB1_Drop(object sender, DragEventArgs e)
        {
            // This casts 'e.Data.GetData()' as a ListBoxItem and if it isn't null
            // then the code will "execute" sort of. basically, listItem will always be 
            // a ListBoxItem (atleast i think it will)
            if (e.Data.GetData(DataFormats.FileDrop) is ListBoxItem listItem)
            {
                LB1.Items.Add(listItem);
            }
        }

        private void LB2_Drop(object sender, DragEventArgs e)
        {
            // This casts 'e.Data.GetData()' as a ListBoxItem and if it isn't null
            // then the code will "execute" sort of. basically, listItem will always be 
            // a ListBoxItem (atleast i think it will)
            if (e.Data.GetData(DataFormats.FileDrop) is ListBoxItem listItem)
            {
                LB2.Items.Add(listItem);
            }
        }

        private void LB1_MouseMove(object sender, MouseEventArgs e)
        {
            Point mPos = e.GetPosition(null);

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(mPos.X) > SystemParameters.MinimumHorizontalDragDistance &&
                Math.Abs(mPos.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                try
                {
                    // This gets the selected item
                    ListBoxItem selectedItem = (ListBoxItem)LB1.SelectedItem;
                    // You need to remove it before adding it to another listbox.
                    // if  you dont, it throws an error (due to referencing between 2 listboxes)
                    LB1.Items.Remove(selectedItem);

                    // The actual dragdrop thingy
                    // DragDropEffects.Copy... i dont think this matters but oh well.
                    DragDrop.DoDragDrop(this, new DataObject(DataFormats.FileDrop, selectedItem), DragDropEffects.Copy);

                    // This code will check if the listboxitem is inside a ListBox or not.
                    // This will stop the ListBoxItem you dragged from vanishing if you dont
                    // Drop it inside a listbox (drop it in the titlebar or something lol)

                    // ListBoxItems are objects obviously, and objects are passed and moved by reference.
                    // Any change to an object affects every reference. 'selectedItem' is a reference
                    // To LB2.SelectedItem, and they both will NEVER be different :)

                    if (selectedItem.Parent == null)
                    {
                        LB1.Items.Add(selectedItem);
                    }
                }
                catch { }
            }
        }

        private void LB2_MouseMove(object sender, MouseEventArgs e)
        {
            Point mPos = e.GetPosition(null);

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(mPos.X) > SystemParameters.MinimumHorizontalDragDistance &&
                Math.Abs(mPos.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                try
                {
                    // This gets the selected item
                    ListBoxItem selectedItem = (ListBoxItem)LB2.SelectedItem;
                    // You need to remove it before adding it to another listbox.
                    // if  you dont, it throws an error (due to referencing between 2 listboxes)
                    LB2.Items.Remove(selectedItem);

                    // The actual dragdrop thingy
                    // DragDropEffects.Copy... i dont think this matters but oh well.
                    DragDrop.DoDragDrop(this, new DataObject(DataFormats.FileDrop, selectedItem), DragDropEffects.Copy);

                    // This code will check if the listboxitem is inside a ListBox or not.
                    // This will stop the ListBoxItem you dragged from vanishing if you dont
                    // Drop it inside a listbox (drop it in the titlebar or something lol)

                    // ListBoxItems are objects obviously, and objects are passed and moved by reference.
                    // Any change to an object affects every reference. 'selectedItem' is a reference
                    // To LB2.SelectedItem, and they both will NEVER be different :)

                    if (selectedItem.Parent == null)
                    {
                        LB2.Items.Add(selectedItem);
                    }
                }
                catch { }
            }
        }
    }
}
