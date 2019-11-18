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
using ApplicationLogics;
//By Ingeborg Asplund 2018
namespace MinionRegistry
{
    /// <summary>
    /// Interaction logic for MinionWindow.xaml
    /// </summary>
    public partial class MinionWindow : Window
    {
        //Instance variables
        private Minion minion;
        //Constructor
        public MinionWindow(Minion min)
        {
            InitializeComponent();
            minion = min;
            Name = min.Name;
            SetUpUI();
        }
        /// <summary>
        /// Function that sets up the basic functionality of the ui
        /// </summary>
        private void SetUpUI()
        {
            lbl_Name.Content = minion.Name;
            _btnDelete.IsEnabled = false;
            lstTraits.Items.Clear();
            lstTraits.ItemsSource = minion.Mylist;
        }
        /// <summary>
        /// Function to add a trait to the minions list of traits.
        /// </summary>
        private void AddTrait_Click(object sender, RoutedEventArgs e)
        {
            bool inputOk = ReadTrait();
            if (inputOk)
            {
                minion.AddItem(txt_Trait.Text.Trim());
                lstTraits.ItemsSource = minion.Mylist;
                txt_Trait.Text = string.Empty;
                _btnDelete.IsEnabled = true;
            }
            else
                MessageBox.Show("Must enter text", "Error", MessageBoxButton.OK);
        }
        /// <summary>
        /// Function that removes a trait based on its index in the list, updating the ui accortingly
        /// </summary>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (lstTraits.SelectedIndex !=-1)
            {
                minion.DeleteItem(lstTraits.SelectedIndex);
                lstTraits.ItemsSource = minion.Mylist;
                if (minion.Count ==0)
                    _btnDelete.IsEnabled = false;
            }
            else
                MessageBox.Show("item out of index");
                
        }
        /// <summary>
        /// Function that allows user to close the miniowindow
        /// </summary>
        private void CloseWindow_Click(object source, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Function that reads the trait the user want to add and return either a false or true value depending
        /// on if the entered element existed or not.
        /// </summary>
        /// <returns></returns>
        private bool ReadTrait()
        {
            if (!string.IsNullOrEmpty(txt_Trait.Text.Trim()))
                return true;
            else
                return false;
        }
        

    }
}
