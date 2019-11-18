using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//By Ingeborg Asplund 2017-2018
namespace Troop_Calculator
{    
    public partial class Mainform : Form
    {
        private Army armyobject;// instanciate the army object as a private variable
        public Mainform()
        {
            InitializeComponent();// initializes main form
            armyobject = new Army();// create a new object of type army
            InitializeGUI();
            // the two below  are for testing
            armyobject.TestValues();
            UpdateGUI();
            //inactivates delete,edit and caclucate buttons
            InactivateButtons();
        }
        public void InitializeGUI()
        {
            // initializes the GUI making sure that all the textboxes and labels are clear at start of application
            txtTroopName.Text = String.Empty;
            txtNumOfMinion.Text = String.Empty;
            cmbType.SelectedIndex = 0;
            lstArmyTroops.Items.Clear();
            lblTotalStregth.Text = "0";
            // set up tooltip, these tell the user about how to use the application
            ttpApplicationhint.SetToolTip(txtTroopName, "Enter a name for your troop in this field, ex. Left Flank");
            ttpApplicationhint.SetToolTip(txtNumOfMinion, "Enter how many minions you want in your troop");
            ttpApplicationhint.SetToolTip(cmbType, "Choose a type of minion. Each minion will have a strenght level that are defined by its type");
            ttpApplicationhint.SetToolTip(btnCalculate, "Press this button to get the full strenght of your army as a whole");
        }
        public void InactivateButtons()
        {
            // This inactivates the buttons for delete and edit and are called whenever there are no listobjects selected any more
            if (btnEditTroop.Enabled && btnDelete.Enabled)//check if the buttons are enabled already
            { 
            btnEditTroop.Enabled = false;
            btnDelete.Enabled = false;
            }
            // if listbox is empty the calculate button wont be enabled
            if (lstArmyTroops.Items.Count == 0)
                btnCalculate.Enabled = false; //btnCalculate is only turned of when listbox is empty          
        }
        public void ActivateButtons()
        {
            // since this is only called by listbox.selectedindex changed it will only affect edit and delete
            // the calculate button are instead activated by the addmethod after a check that it is not already active
            if(!btnEditTroop.Enabled&&!btnDelete.Enabled)
            {
                btnEditTroop.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
        public bool Readinput()
        {
            // saves down the input variables, name and quantity are then sent to a method for controlling the input
            string name = txtTroopName.Text;
            string quantity = txtNumOfMinion.Text.Trim();
            MinionType type = (MinionType)cmbType.SelectedIndex;
            // bool that controls the input for the added troop
            bool add = ControlInput();
            if (add)
            {
                int numOfMinions = int.Parse(quantity);//parses the quantityvariable to an int
                //by this time it should already have been checked that it is not a negative or a nonnumeric value
                armyobject.AddTroop(name, type, numOfMinions);// calls the addmethod in army
            }
            else
            {
                MessageBox.Show("Sorry new minions but you have to ensure you have a name and that you know how many you are before joining, otherwise you cause a lot of confusion-Michelle");
            }
            return add;
        }
        public bool ReadChanged(ref Troop troop)
        {
            string name = txtTroopName.Text;
            string quantity = txtNumOfMinion.Text.Trim();
            MinionType type = (MinionType)cmbType.SelectedIndex;
            // bool that controls the input for the changed troop
            bool changed = ControlInput();
            if (changed)
            {
                troop.TroopName = name;
                troop.DefineType = type;
                troop.NumberOfMinions = int.Parse(quantity);// parse the quantity
                // quantity has already been checked by checkinput and the methods that method calls
            }
            else
                MessageBox.Show("No, you can't change to that, you have to have a name and a number before any changes can be made-Michelle");
            return changed;
        }
        private bool ControlInput()
        {
            // This method checks the input with the help of two different bools
            bool stringInput = Checkstrings();
            bool parsed = Checknumbers();
            return stringInput && parsed;// return all three bools
        }
        private bool Checkstrings()
        {
            // check so that the strings entered by the user is not null or empty
            bool ok = false;
            if (!string.IsNullOrEmpty(txtTroopName.Text) && !string.IsNullOrEmpty(txtNumOfMinion.Text))
                ok = true;
            return ok;
        }
        private bool Checknumbers()
        {
            // This method checks the input for the number of minions making shure it is of numeric value
            string inputNumber = txtNumOfMinion.Text.Trim();// takes in the string from the user interface and trims away unnecessary spaces
            int numOfMinions = 0;// this are zero if the tryparse went false;
            bool isNumeric = int.TryParse(inputNumber,out numOfMinions);// check if the input for the number minionquantity is numeric
            bool NotNegative = numOfMinions >= 0;// turns true whenever result is bigger than or equal to zero
            return isNumeric&&NotNegative;
        }
        //The below method is called whenever the user press exit in the menuestrip or use Alt+f5 shortcut
        public void ExitDialogue()
        {
            //Set up content of message box
            string message = "Are you sure that you want to exit";
            string title = "Exit";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //Define a dialogue result
            DialogResult result;
            // spawn messagebox
            result = MessageBox.Show(message, title, buttons);
            //check for the result of dialogue
            if(result == DialogResult.Yes)
            {
                Application.Exit();//quit application if yes
            }
        }
        // the below method is called whenever the user press the new button in menuestrip or use shortcut Control+N
        public void NewDialogue()
        {
            // basically same as above
            string message = "Are you sure you want to start over with a new army, doing so will result in loss of progress";
            string title = "New";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, title, buttons);
            if(result == DialogResult.Yes)
            {
                armyobject.ClearList();
                //Updates the GUI
                UpdateGUI();
                lblTotalStregth.Text = "0";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Readinput();
            //Updates the GUI
            UpdateGUI();
            //Makes sure to activate the calculate button after a troop is added
            if (!btnCalculate.Enabled)
            btnCalculate.Enabled = true;
            // Inactivates delete and edit buttons
            InactivateButtons();
        }

        private void btnEditTroop_Click(object sender, EventArgs e)
        {
            // defines a troop with the help of gettroopat method
            Troop selected = armyobject.GetTroopAt(lstArmyTroops.SelectedIndex);
            //read edited input
            ReadChanged(ref selected);
            // call the edit method
            armyobject.EditTroop(selected, lstArmyTroops.SelectedIndex);
            //Updates the GUI
            UpdateGUI();
            //Inactivates edit and delete
            InactivateButtons();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // call delete method
            armyobject.DeleteTroop(lstArmyTroops.SelectedIndex);
            //Updates the GUI
            UpdateGUI();
            //Inactivates Edit and Delete
            InactivateButtons();
        }

        private void lstArmyTroops_SelectedIndexChanged(object sender, EventArgs e)
        {
            //activates the edit and deletebuttons
            ActivateButtons();
            //Update the lefthand side of the GUI
            UpdateAfterTroop();
          
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //calculates the total armystrength
            armyobject.CalculateArmyStrenght();
            // writes out resulst in label
            lblTotalStregth.Text = armyobject.TotalArmystrenght.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // calls the dialogue for exit
            ExitDialogue();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //calls the dialogue for new instance
            NewDialogue();
        }

        private void btnInformation_Click(object sender, EventArgs e)
        {
            //spawns the informationbox about Michelle
            DialogResult result;
            MichelleBio1 biography = new MichelleBio1();
            result = biography.ShowDialog();
        }

        private void Mainform_KeyDown(object sender, KeyEventArgs e)
        {
            //controls which shortcut is used and spawn dialogue based on that
            if (e.Control && e.KeyCode == Keys.N)
            {
                NewDialogue();
            }
            if(e.Alt&&e.KeyCode == Keys.F5)
            {
                ExitDialogue();
            }
        }
        public void UpdateAfterTroop()
        {
            Troop guideTroop = armyobject.GetTroopAt(lstArmyTroops.SelectedIndex);//get the selected troop
            //sets up the left hand side of the interface according to what troop is currently selected
            txtTroopName.Text = guideTroop.TroopName;
            cmbType.SelectedIndex = (int)guideTroop.DefineType;
            txtNumOfMinion.Text = guideTroop.NumberOfMinions.ToString();
        }
        public void UpdateGUI()
        {
            //updates the listbox in the user interface
            string[] listOfTroops = armyobject.TroopToList();
            lstArmyTroops.Items.Clear();
            lstArmyTroops.Items.AddRange(listOfTroops);
        }
    }
    
}
