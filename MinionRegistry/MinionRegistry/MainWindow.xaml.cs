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
using Microsoft.Win32;
using ApplicationLogics;
using System.IO;

namespace MinionRegistry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MinionList minions;
        public MainWindow()
        {
            InitializeComponent();
            minions = new MinionList();
            SetupUI();
        }
        /// <summary>
        /// Function that initializes the ui and ensures its main functions are working
        /// </summary>
        private void SetupUI()
        {
            btn_Save.IsEnabled = false;
            btn_Search.IsEnabled = false;
            btnFireMinion.IsEnabled = false;
            btnInspect.IsEnabled = false;
            txtMinionName.Text = string.Empty;
            txtStrength.Text = string.Empty;
            lstMinions.Items.Clear();
            btn_Search.IsEnabled = false;
            rbtnSearchName.IsChecked = true;
            cmbMinionType.ItemsSource = Enum.GetValues(typeof(MinionType)).Cast<MinionType>();
            cmbMinionType.SelectedItem = MinionType.Flareimp;
        }
        private void RecriutMinion_Click(object sender, RoutedEventArgs e)
        {
            string name = ReadName();//calls the read name function
            int strength = ReadStrenght();
            if (!string.IsNullOrEmpty(name) && strength > 0)
            {
                Minion added = new Minion(name, strength, ReadType());
                minions.AddItem(added);
                MinionWindow minWind = new MinionWindow(added);
                minWind.Show();
                lstMinions.ItemsSource = minions.MyMinions(minions.Mylist);
                btnFireMinion.IsEnabled = true;
                btn_Save.IsEnabled = true;
                btn_Search.IsEnabled = true;
                btnInspect.IsEnabled = false;
                txtMinionName.Text = string.Empty;
                txtStrength.Text = string.Empty;

            }
            else
            {
                MessageBox.Show("Input faulty, the minion must have a strenght value and a name which are unique", "Faulty input", MessageBoxButton.OK);
            }

        }
        /// <summary>
        /// Function for fireing a specific minion and removing its 
        /// </summary>
        private void FireMinion_Click(object sender, RoutedEventArgs e)
        {
            if (lstMinions.SelectedIndex != -1)
            {
                Minion fired = minions.Mylist[lstMinions.SelectedIndex];
                CloseMinionWind(fired);
                minions.DeleteItem(lstMinions.SelectedIndex);
                lstMinions.ItemsSource = minions.MyMinions(minions.Mylist);
                if (minions.Count == 0)
                {
                    btnFireMinion.IsEnabled = false;
                    btn_Search.IsEnabled = false;
                    btnInspect.IsEnabled = false;

                }
            }
        }

        /// <summary>
        /// Function that finds the window belonging to a certain minion through comparing a sent in minion with the minion of the 
        /// minionwindow
        /// </summary>
        /// <param name="miniMon"></param>
        private void CloseMinionWind(Minion miniMon)
        {
            foreach (Window w in Application.Current.Windows)
            {
                if (miniMon.Name == w.Name)
                {
                    w.Close();//closes all windows named after the minion sent in
                }
            }
        }
        /// <summary>
        /// Function that reads the name of a new minion
        /// </summary>
        /// <returns></returns>
        private string ReadName()
        {
            string name = txtMinionName.Text.Trim();
            Minion SearchResult = minions.SearchByName(name);
            if (!string.IsNullOrEmpty(name) && SearchResult == null)
                return name;
            else
                return string.Empty;
        }
        /// <summary>
        /// Function that reads the strenght of a new minion
        /// </summary>
        /// <returns></returns>
        private int ReadStrenght()
        {
            int strPoint = 0;
            bool canParse = int.TryParse(txtStrength.Text.Trim(), out strPoint);
            if (canParse)
                strPoint = int.Parse(txtStrength.Text.Trim());
            return strPoint;
        }
        /// <summary>
        /// Function that reads the type of a new minion.
        /// </summary>
        private MinionType ReadType()
        {
            MinionType min = (MinionType)cmbMinionType.SelectedValue;
            return min;
        }
        /// <summary>
        /// Function that handles the searchbutton enabling the user to search for minions based on different
        /// criterias and displays different items dependent on the conditions selected. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string search = SearchCondition();

            if (rbtnSearchName.IsChecked == true)
            {
                //List<Minion> name = new List<Minion>();
                //name.Add(minions.SearchByName(search));
                lstMinions.ItemsSource = minions.MyMinions(minions.SearchNameByStartLetter(search));
            }
            else if (rbtn_SearchStrenght.IsChecked == true)
            {
                int SearchForStrenght = ParseSearch();
                lstMinions.ItemsSource = minions.MyMinions(minions.SearchByStrength(SearchForStrenght));
            }
            else if (rbtn_SearchType.IsChecked == true)
            {
                MinionType miniType = SearchType(search);
                lstMinions.ItemsSource = minions.MyMinions(minions.SearchByType(miniType));
            }
            else if (rbtn_SearchTrait.IsChecked == true)
            {
                if (!string.IsNullOrEmpty(txt_SearchField.Text.Trim()))
                    lstMinions.ItemsSource = minions.MyMinions(minions.SearchByTrait(txt_SearchField.Text.Trim()));

            }
            txt_SearchField.Text = string.Empty;

        }
        /// <summary>
        /// Function associated with the savebutton it creates an xml of the minionlist 
        /// and puts where the user instructs. Not yet implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "File";
            sfd.DefaultExt = ".xml";
            sfd.Filter = "Text documents (.xml)|*.xml";
            Nullable<bool> result = sfd.ShowDialog();
            if (result == true)
            {
                string save = sfd.FileName;
                SaveFunction(save);
            }

        }
        /// <summary>
        /// Function associated with the loadbutton allows the user to select an xmlfile to load.Not yet implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.FileName = "File";
            opf.DefaultExt = ".xml";
            opf.Filter = "Text documents (.xml)|*.xml";
            Nullable<bool> result = opf.ShowDialog();
            if (result == true)
            {
                string file = opf.FileName;
                LoadFile(file);
            }
        }
        /// <summary>
        /// Function for exiting the application
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void Quit_Click(object source, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Function that reopens a minionwindow after it was closed.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void Inspect_Click(object source, RoutedEventArgs e)
        {
            Minion select = minions.Mylist[lstMinions.SelectedIndex];
            MinionWindow win = new MinionWindow(select);
            win.Show();
        }
        /// <summary>
        /// Enables the inspect button whenever an item in the list of minions are selected
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void SelectMinion(object sender, SelectionChangedEventArgs e)
        {
            if (lstMinions.SelectedIndex != -1)
                btnInspect.IsEnabled = true;
        }
        /// <summary>
        /// Function that reads the searchfield and returns a string of text representing what stands in the searchbox.
        /// </summary>
        /// <returns></returns>
        private string SearchCondition()
        {
            bool searchok;
            if (!string.IsNullOrEmpty(txt_SearchField.Text.Trim()))
                searchok = true;
            else
                searchok = false;
            if (searchok)
                return txt_SearchField.Text.Trim();
            else
            {
                MessageBox.Show("You must enter a searchcondition in the searchbar, it can be either a name, a trait,a strenght value or a type", "Error", MessageBoxButton.OK);
                return null;
            }
        }
        /// <summary>
        /// Method that returns an int representing a specifik strenght value searched for by the user
        /// </summary>
        /// <returns></returns>
        private int ParseSearch()
        {
            int strong = 0;
            bool parsable = int.TryParse(txt_SearchField.Text.Trim(), out strong);
            if (parsable)
                strong = int.Parse(txt_SearchField.Text.Trim());
            else
                MessageBox.Show("Value must be numeric", "Error", MessageBoxButton.OK);
            return strong;
        }
        /// <summary>
        /// Method that returns the miniontype the user want to sort the minions after
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private MinionType SearchType(string s)
        {
            MinionType t = MinionType.Flareimp;
            switch (s)
            {
                case "Flareimp":
                    t = MinionType.Flareimp;
                    break;
                case "Icegiant":
                    t = MinionType.Icegiant;
                    break;
                case "WindSpectre":
                    t = MinionType.WindSpectre;
                    break;
                case "Unrestfull_Spirit":
                    t = MinionType.Unrestfull_Spirit;
                    break;
                case "Shadowfoe":
                    t = MinionType.Shadowfoe;
                    break;
                case "Flamehound":
                    t = MinionType.Flamehound;
                    break;
                case "ForgottenOne":
                    t = MinionType.ForgottenOne;
                    break;
                case "Souleater":
                    t = MinionType.Souleater;
                    break;
                case "SwampHunter":
                    t = MinionType.SwampHunter;
                    break;
                case "Boggling":
                    t = MinionType.Boggling;
                    break;
                case "HellWasp":
                    t = MinionType.HellWasp;
                    break;
            }
            return t;
        }
        /// <summary>
        /// Function used to save down the current minionlist as a save file(triggered by save button)
        /// </summary>
        private void SaveFunction(string filePath)
        {
            string errMsg = null;
            if (!File.Exists(filePath))
            {
                try
                {
                    minions.SaveBinary(filePath);
                }
                catch (Exception e)
                {
                    errMsg = string.Format("Save failed:{0}", e.ToString());
                    MessageBox.Show(errMsg, "Error", MessageBoxButton.OK);
                }
                finally { }
            }
        }
        /// <summary>
        /// Function used to load a saved file into the application
        /// </summary>
        private void LoadFile(string filepath)
        {
            string errMsg = null;
            if (File.Exists(filepath))
            {
                try
                {
                    minions.LoadBinary(filepath);
                    lstMinions.ItemsSource = minions.MyMinions(minions.Mylist);
                    btnFireMinion.IsEnabled = true;
                    btn_Save.IsEnabled = true;
                    btn_Search.IsEnabled = true;
                }
                catch (Exception e)
                {
                    errMsg = string.Format("Failed to load XML:{0}", e.ToString());
                    MessageBox.Show(errMsg, "Error", MessageBoxButton.OK);
                }
                finally { }
            }
        }

       
    }
}