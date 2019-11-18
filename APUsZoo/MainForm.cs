using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;


/// <summary>
/// Main form script that handles input from the user when the correct iput are given an animal is added to the list of animals in 
/// the Animal Manager, otherwise provide the user with the information that the input was faulty and that they should try again.
/// Note that to get the feeding details for an animal to show up in the GUI you have to select that specific animal in the lisbox for animals
/// The reason no preview of the feeding details are shown is that the application is built with several possible diets per animal which the user 
/// select through a list box. Showing a preview of all of them would require very much repeated code, taking a switch that looks both at which animal specie and which diet
/// currently is active. Then comes the fact that the feeding schedule will be editable by the user in the future which lead to that that information would be impossible to preview in future installments
/// and thherefore details about feeding is handled as a type of information the user get post creation when selecting the animal he/she want to see the feeding details of.
/// </summary>
namespace APUsZoo
{
    public partial class MainForm : Form
    {        
        private AnimalManager aniMangage;// animal manager
        private RecipeManager recipes;// recipemanager that keeps information about recipes for animal food in apu Zoo
        private EmployeeManager employeeList;// staff manager that keep track on all different employees at apu zoo.
        private Category animalCategory;
        private FoodSchedule mainSchedule;
        private bool showStaff;// bool used to determine which type of list is going to be displayed in the informations tab, defaulted to recipes,aka false
        private bool savedFile;//bool that determines if progress have been saved or not, it is initiated as false on startup and is used to determine which message is thrown
        // when the user selects new or exit.
        public MainForm()
        {
            InitializeComponent();// initialize the mainform component
            aniMangage = new AnimalManager(); // create a new instance of the animal manager
            recipes = new RecipeManager();
            employeeList = new EmployeeManager();
            SetUpGUI();
            showStaff = false;
            savedFile = true;
            UpdateinformationDisplay();
        }
        // setup function that prepares interface for use set tooltips and similar
        private void SetUpGUI()
        {
            // set up a set of default values for the comboboxes
            cmbCategory.Items.Clear();//clear combobox
            cmbCategory.Items.AddRange(Enum.GetNames(typeof(Category)));//binds combbox to enum
            cmbCategory.SelectedIndex = (int)Category.Reptile;//set selected index to start at reptiles
            cmbDiet.Items.Clear();
            cmbDiet.Items.AddRange(Enum.GetNames(typeof(Diet)));
            cmbDiet.SelectedIndex = (int)Diet.AllEater;
            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(Enum.GetNames(typeof(Gender)));
            cmbGender.SelectedIndex = (int)Gender.Female;
            rbtnSortByID.Checked = true;// set sort by id as checked when applicarion starts 
            btnDeleteAnimal.Enabled = false; //When no animals are added this will be false

            // set up all of the tooltips so that the user know ho use the different part of the ui
            MainFormttp.SetToolTip(txtName, "type name here");
            MainFormttp.SetToolTip(txtAge, "type age here");
            MainFormttp.SetToolTip(cmbDiet, "choose what type of food the animal eats");
            MainFormttp.SetToolTip(cmbGender, "Which gender is the animal");
            MainFormttp.SetToolTip(cmbCategory, "choose which type of animal to add");
            MainFormttp.SetToolTip(btnAdd, "press this to add an animal");
            MainFormttp.SetToolTip(btnBrowse, "Select an image from your computer(Optional)");
            MainFormttp.SetToolTip(lblDietType, "Eater type will correspond with the chosen diet for the animal");
            MainFormttp.SetToolTip(lstFeedingSchedule, "Information about how the animal is fed will appear when the animal in question is selected");
        }
        //add function that call external method for checking and reading the input
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool checkInput = ReadInput();
            if (checkInput)
            {
                AddAnimal();// calls the add animal method this reads in the values needed for each of the animals dependent on user input
                // in the addmethod values are directly parsed to their respective values as the readinput bool already done its job verifying
                // that the variables are okto use(is numerical for ints and doubles and not null for strings)
                UpdateGUI();
                btnDeleteAnimal.Enabled = false;// right after an animal is added and nothing is selected there should be no way to delete an empty object
                savedFile = false; // there are now new changes made that needs saving before we can proceed
            }
            //the default input wrong message replaced with individual messages for the different controls

        }
        // browse button
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // open the filter for jpg, jpeg and bmp files to be loaded into the picturebox
            opfAnimal.Filter = "(*.jpg; *.jpeg;*.bmp;*.png;)| *.jpg;*.jpeg;*.bmp;*.png";
            // opens a filedialogue that lets the user choose an image at desktop to load into the picture box
            if (opfAnimal.ShowDialog() == DialogResult.OK)
            {
                // if ok load  the selected image in the picture box for animals
                ptbAnimalpic.Image = new Bitmap(opfAnimal.FileName);
            }
        }
        /// <summary>
        /// Button function that allows deletion of an item in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteAnimal_Click(object sender, EventArgs e)
        {
            int index = lstAnimalList.SelectedIndex;// get an index corresponding to the one selected in the list
            aniMangage.Delete(index);//deletes the selected item based on index
            UpdateGUI();
            EraseFoodScheduleGUI();
            btnDeleteAnimal.Enabled = false;// turns of the availability of the deletebutton
            savedFile = false;
        }
        /// <summary>
        /// Button function for adding a recipe to the form, it instanciates a new object of type recipeform and check if the dialogue result was Ok.
        /// if so an object of type recipe fetched throught the recipeform is added to the listbox. The listbox is also altered and filled with the appropriate objects
        /// which is true for the rest of the GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            if (showStaff)
            {
                showStaff = false;
                UpdateinformationDisplay();
            }
            RecipeForm recfrm = new RecipeForm();
            if(recfrm.ShowDialog() == DialogResult.OK)
            {
                lstinformation.Items.Add(recfrm.Recipe.ToString());
                recipes.Add(recfrm.Recipe);
                savedFile = false;// there are now new changes made
            }
        }
        /// <summary>
        /// Button event for adding a recipe to the apu Zoo application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (!showStaff)
            {
                showStaff = true;
                UpdateinformationDisplay(); 
            }            
            EmplyeeManagementForm staffmanage = new EmplyeeManagementForm();
            if(staffmanage.ShowDialog()==DialogResult.OK)
            {
                lstinformation.Items.Add(staffmanage.Employee.ToString());
                employeeList.Add(staffmanage.Employee);
                savedFile = false;// new changes made so they needs to be saved
            }
        }
        //lst selected index changed function for the the output box
        private void lstAnimalList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAnimalList.SelectedIndex != -1)
            {
                // update the UI information after the selected animal
                UpdateAfterSelected();
                UpdateFoodschedule();
                btnDeleteAnimal.Enabled = true;
            }
            
        }
       /// <summary>
       /// Exit function from the menue toolstrip, calling the function exit dialogue
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void MnuExit_Click(object sender, EventArgs e)
        {
            ExitDialogue();
        }

        /// <summary>
        /// Spawns dialogue box asking the user if they want to start a new instance of the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuNew_Click(object sender, EventArgs e)
        {
            NewDialogue();
        }
        /// <summary>
        /// Menue item for saving a file to already existig directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSave_Click(object sender, EventArgs e)
        {
            SaveDialogue();
        }
        /// <summary>
        /// Menue click event for save as. spawns a save file dialogue and then calls the save As method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdSave_Saveas.ShowDialog() == DialogResult.OK)
            {
                string filename = sfdSave_Saveas.FileName;// set a string as the file name resulting of the dialogue
                SaveAs(filename);
                savedFile = true;
            }
        }
        /// <summary>
        /// Function for opening an binary file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            OpenDialogue();
        }
        /// <summary>
        /// Function for loading an xml file into application by buttonclick in menue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuImportXML_Click(object sender, EventArgs e)
        {
            if (!savedFile)
            {
                if (MessageBox.Show("Do you want to save before proceeding?", "Notice", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    SaveDialogue();
                }
            }
            if (opfLoading.ShowDialog() == DialogResult.OK)
            {
                string path = opfLoading.FileName;
                OpenSavedXML(path);
            }
            
        }
        /// <summary>
        /// Menue option that export data in the application to xml file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExportXML_Click(object sender, EventArgs e)
        {
            if(sfdSave_Saveas.ShowDialog()==DialogResult.OK)
            {
                string path = sfdSave_Saveas.FileName;// get the name of the file
                ExportAsXML(path);// export as xml
                savedFile = true;// set saved file to true
            }
        }
        // function that updates the GUI after which categry is active
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // this function updates how the GUI looks based on whih category of animal is selected
            // bind cmbcategory to the comboboxes selected index

            animalCategory = (Category)cmbCategory.SelectedIndex;
            switch (animalCategory)
            {
                case Category.Reptile:
                    // calls method that update the UI for birdtype animals
                    UpdateForReptile();
                    break;
                case Category.Bird:
                    // calls method that update the UI for birdtype animals
                    UpdateForBird();
                    break;
            }


        }
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstAnimalObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstAnimalObject.SelectedIndex!=-1)
            UpdateSpecificInformation();            
        }
        /// <summary>
        /// Event fired when the current radiobutton checked is changed and updates the information in GUI according to choosen sorting method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnSortByID_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonController();
            lstAnimalList.Items.Clear();
            lstAnimalList.Items.AddRange(aniMangage.PresentArray());
        }
        /// <summary>
        /// check/readinput functions called by add function
        ///  this is the general input checkermethod that calls a number of submethds it i used to read in and 
        // verify the different types of data based on a) general animal information such as name, age and diet
        // ,b) groupspecific data such as color for birds and required environmental temperature for rebiles and c)
        // data specific to the different species, such as swimspeed, known phrases etc
        /// </summary>
        /// <returns></returns>
        private bool ReadInput()
        {                                   
            bool readGeneral = ReadAndCheckGeneral();
            bool readSpecie = ReadAndCheckAnimalspecific();
            return readGeneral && readSpecie;
        }
        /// <summary>
        /// reads and check general information
        /// </summary>
        /// <returns></returns>
        private bool ReadAndCheckGeneral()
        {
            // This method call some submethods that check name, age,diet and gender individually
            bool name = NameCheck();
            bool age = Ageparse();
            return name && age;
        }
        /// <summary>
        /// check the name of the animal
        /// </summary>
        /// <returns></returns>
        private bool NameCheck()
        {
            //check that a name has been entered
            bool ok = false;
            string name = txtName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                ok = true;
            }
            else
            {
                MessageBox.Show("You have to type in a name","Error");
            }
            return ok;
        }
        /// <summary>
        /// check the age for the animal
        /// </summary>
        /// <returns></returns>
        private bool Ageparse()
        {
            // this method try to parse age as a double, if that cant be done  this bool= false;
            string agestr = txtAge.Text.Trim();
            double age = 0;// default age is 0
            bool ok = double.TryParse(agestr, out age);// parses agestr to age if this is possible the the bool is true
            if (!ok)
                MessageBox.Show("Age have to be a numerical or decimal value","Error");
            return ok;
        }
        /// <summary>
        /// Metod that check the information specific to reptiles, bird and respective categories species
        /// </summary>
        /// <returns></returns>
        private bool ReadAndCheckAnimalspecific()
        {
            // this method contains a switch that check different numbers based on which type of animal is selected in the
            // category combobox.
            bool ok = false;// introduces general bool
            animalCategory = (Category)cmbCategory.SelectedIndex;
            switch (animalCategory)
            {
                case Category.Reptile:
                    ok = CheckReptile();//check values for reptile species
                    break;
                case Category.Bird:
                    ok = CheckBird();// check values for bird species
                    break;

            }


            return ok;

        }
        /// <summary>
        /// check values for reptile species
        /// </summary>
        /// <returns></returns>
        private bool CheckReptile()
        {
            //<>Summary
            //this method checks the specific conditions for the reptile objects it use a case statement which mean that it can easily be expanded with more categories if needed
            //<Summary>
            string strReqtemp = txtAttribute1.Text.Trim();// saves the first attribute as required environemntal temp
            string strCrawl = txtAttribute2.Text.Trim();// saves the second attribute as crawlspeed
            string strSpeciespecific = txtAttribute3.Text.Trim();// saves the last attribute as any speciewise characteristic
            double required;// the required environmental temperature
            double crawl; // the crawlspeed       
            // bool that check the base values for all reptiles
            bool reptile = double.TryParse(strReqtemp, out required) && double.TryParse(strCrawl, out crawl);
            if (!reptile)  // error message spawned by faulty input      
                MessageBox.Show("Requred environmental temperature and crawlspeed need to be assigned and be of numerical or decimal value type","Error");
            
            bool checkSpecific = false;// secound bool that check the data to be saved in the specific animal specie
            // the following switch case statement check the last specific attribute dependent on which specie is selected
            // right now both cases tryparse a double but if later on reptiles with int, and string values are added these can be checked individually  
            if (lstAnimalObject.SelectedIndex != -1) { 
            ReptileSpecies reptiles = (ReptileSpecies)lstAnimalObject.SelectedIndex;// define and bind enum to listbox
            switch (reptiles)
            {
                case ReptileSpecies.Chameleon:
                    double colorChange;// lokal double for ColorChangeSpeed
                    checkSpecific = double.TryParse(strSpeciespecific, out colorChange);
                    if (!checkSpecific)
                        MessageBox.Show("Colorchange speed need to be of numerical or decimal value");
                    break;
                case ReptileSpecies.SeaTurtle:
                    double swimSpeed;// lokal double for Swimspeed
                    checkSpecific = double.TryParse(strSpeciespecific, out swimSpeed);
                    if (!checkSpecific)
                        MessageBox.Show("Swimspeed need to be of numerical or decimal type value","Error");
                    break;
            }
            }
            return reptile && checkSpecific;
        }
        /// <summary>
        /// check values for birdspecies
        /// </summary>
        /// <returns></returns>
        private bool CheckBird()
        {
            string strColor = txtAttribute1.Text.Trim();
            string strFlightspeed = txtAttribute2.Text.Trim();
            string strBirdAttribute = txtAttribute3.Text.Trim();
            double flight;
            bool bird = false;
            if (!string.IsNullOrEmpty(strColor) && double.TryParse(strFlightspeed, out flight))
            {
                // this bool are checked somewhat differenctly to the one in reptile as there are two different type of values needing to be checked
                // one is a string(color), and one is a double(flightspeed)
                bird = true;
            }
            else
                MessageBox.Show("You need to write in what color your bird has and flightspeed need to be of numerical or decimal value type");

            bool checkSpecific = false;
            //switch statement that check the checkSpecific bool towards a speciespecific criteria
            if (lstAnimalObject.SelectedIndex != -1) { 
            BirdSpecies birds = (BirdSpecies)lstAnimalObject.SelectedIndex;// define and bind enum to the selected option in the combobox
            switch (birds)
            {
                // tyrparse the variables that are specific for different species
                case BirdSpecies.Parrot:
                    int knownphrase;
                    checkSpecific = int.TryParse(strBirdAttribute, out knownphrase);//parses the known phrases variable
                    if (!checkSpecific)
                        MessageBox.Show("Knownphrases need to be a numerical value");
                    break;
                case BirdSpecies.Pigeon:
                    int letterCarry;
                    checkSpecific = int.TryParse(strBirdAttribute, out letterCarry);
                    if (!checkSpecific)
                        MessageBox.Show("Letters carried need to be a numerical value");
                    break;
            }
            }
            return bird && checkSpecific;
        }
        // Method for adding an animal calling a latebound method in bird and reptile classes respectively
        private void AddAnimal()
        {
           
            // values that are read through the interface
            string namestring = txtName.Text.Trim();
            double ageValue = double.Parse(txtAge.Text.Trim());
            Diet mydiet = (Diet)cmbDiet.SelectedIndex;
            Gender mygender = (Gender)cmbGender.SelectedIndex;
            Category mycat = (Category)cmbCategory.SelectedIndex;
            switch (mycat)
            {
                case Category.Reptile:
                    // read in and save values specific to reptiles
                    double envtemp = double.Parse(txtAttribute1.Text.Trim());
                    double crawl = double.Parse(txtAttribute2.Text.Trim());
                    // parses the Reptilepecie enum as items in the listbox of choosable animals 
                    if (lstAnimalObject.SelectedIndex != -1)
                    { 
                    ReptileSpecies reptiles = (ReptileSpecies)Enum.Parse(typeof(ReptileSpecies), lstAnimalObject.Text);                    
                    switch (reptiles)
                    {
                        case ReptileSpecies.Chameleon:                          
                           
                            double colorchanger = double.Parse(txtAttribute3.Text.Trim());//read in specific value needed for the chameleon
                            Chameleon myChameleon = new Chameleon();// creates a new object of type chameleon
                            myChameleon.SetChameleonValues(namestring, ageValue, mydiet, mygender, mycat, envtemp, crawl, colorchanger);// set required datavalues
                            aniMangage.GiveID(myChameleon);// add mychameleon object to list in animal manager                             
                            break;
                        case ReptileSpecies.SeaTurtle:
                           
                            double swimmer = double.Parse(txtAttribute3.Text.Trim());
                            SeaTurtle myturtle = new SeaTurtle();
                            myturtle.SeaTurtleValues(namestring, ageValue, mydiet, mygender, mycat, envtemp, crawl, swimmer);
                            aniMangage.GiveID(myturtle);// add myturtle to the list in animal manager                          
                            break;
                    }
                    }
                    break;                    
                case Category.Bird:
                    string strcoloration = txtAttribute1.Text.Trim();
                    double flyer = double.Parse(txtAttribute2.Text.Trim());// an already controlled value is parsed as double
                    if (lstAnimalObject.SelectedIndex != -1) { 
                    BirdSpecies birds = (BirdSpecies)Enum.Parse(typeof(BirdSpecies), lstAnimalObject.Text);

                    switch (birds)
                    {
                        // procedure below basicly repeats the process for reptiles but uses birds instead                      
                        case BirdSpecies.Pigeon:
                            int letter = int.Parse(txtAttribute3.Text.Trim());                                                                   
                            Pigeon pig = new Pigeon();
                            pig.PigeonValues(namestring, ageValue, mydiet, mygender, mycat, strcoloration, flyer, letter);
                            aniMangage.GiveID(pig);// add pigeon pig to the animal managers list of animals                        
                            break;
                        case BirdSpecies.Parrot:                          
                            int knowphrase = int.Parse(txtAttribute3.Text.Trim());
                            Parrot newparrot = new Parrot();
                            newparrot.ParrotValues(namestring, ageValue, mydiet, mygender, mycat, strcoloration, flyer, knowphrase);
                            aniMangage.GiveID(newparrot); // add newparrot to animanage                           
                            break;
                    }
                    }
                    break;
            }
                       
        }
        
        //update GUI function that compiles a list of strings representing the objects in AnimalManager registry
        private void UpdateGUI()
        {
            // update the listbox for animal list
            RadioButtonController();          
            lstAnimalList.Items.Clear();
            lstAnimalList.Items.AddRange(aniMangage.PresentArray());
            // for birds the above seem to point at null, an I have no Idea why, since the way I read the variables and create the objects
            // for reptiles and birds are identical
            //erase textboxes so that they are empty 
            txtName.Text = String.Empty;
            txtAge.Text = String.Empty;
            txtAttribute1.Text = String.Empty;
            txtAttribute2.Text = String.Empty;
            txtAttribute3.Text = String.Empty;
            // set the cmbcategory to point to their original pointers
            cmbDiet.SelectedIndex = (int)Diet.AllEater;
            cmbGender.SelectedIndex = (int)Gender.Female;
            cmbCategory.SelectedIndex = (int)Category.Reptile;

        }
        // GUI function that updates the interface after selected objects in the registry
        private void UpdateAfterSelected()
        {
            int selected = lstAnimalList.SelectedIndex;// get an int for the selected listbox item
            Animal animal = aniMangage.FindAt(selected);// use the selected int to find the animal selected in the listbox
            // update the GUI after the general settings of the animal
            txtName.Text = animal.Name;
            txtAge.Text = animal.Age.ToString();
            cmbDiet.SelectedIndex = (int)animal.AnimDiet;
            cmbGender.SelectedIndex = (int)animal.AnimGender;
            cmbCategory.SelectedIndex = (int)animal.AnimCat;
            switch (animal.AnimCat)
            {
                // switch statement that updates the information that are specific to the different species and their types
                case Category.Reptile:
                    // write out the info for reptiles in general
                    txtAttribute1.Text= ((Reptile)animal).RecuiredTemp.ToString();
                    txtAttribute2.Text = ((Reptile)animal).CrawlSpeed.ToString();
                    if((animal)is Chameleon)
                    {
                        // write out info for chameleon
                        lstAnimalObject.SelectedIndex = (int)ReptileSpecies.Chameleon;
                        txtAttribute3.Text = ((Chameleon)animal).ColorChangeSpeed.ToString();
                    }
                    else if((animal)is SeaTurtle)
                    {
                        // write out info for seaturtle
                        lstAnimalObject.SelectedIndex = (int)ReptileSpecies.SeaTurtle;
                        txtAttribute3.Text = ((SeaTurtle)animal).SwimSpeed.ToString();
                    }
                    break;
                case Category.Bird:
                    txtAttribute1.Text = ((Bird)animal).Color;
                    txtAttribute2.Text = ((Bird)animal).FlightSpeed.ToString();
                    if((animal)is Pigeon)
                    {
                        //write out info for pigeon
                        lstAnimalObject.SelectedIndex = (int)BirdSpecies.Pigeon;
                        txtAttribute3.Text = ((Pigeon)animal).LettersCarried.ToString();
                    }
                    else if((animal)is Parrot)
                    {
                        //write out info for parrot
                        lstAnimalObject.SelectedIndex = (int)BirdSpecies.Parrot;
                        txtAttribute3.Text = ((Parrot)animal).KnownPhrases.ToString();
                    }
                    break;
            }
            
        }

        //The below methods handle the opening of dialogue windows 
        /// <summary>
        /// Method that call dialogue for exiting the application
        /// </summary>
        private void ExitDialogue()
        {
            // method that calls a message box that ask the user if he/she want to exit the application
            string message = String.Empty;//initialized as empty
            // determine what message is used when the user push the exit button
            if (!savedFile)
                message = "Are you sure you want to exit this application without saving first?";
            else
                message = "Are you sure you want to exit";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult dlgmessage;
            dlgmessage = MessageBox.Show(message,"Exit",buttons);
            // if yes then exit application
            if(dlgmessage == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        /// <summary>
        /// Function that calls the reset application function when new is pressed after having asked the user if he/she want to start a new instance of the program
        /// </summary>
        private void NewDialogue()
        {
            string dlg = string.Empty;
            if (!savedFile)
                dlg = "Are you sure you want to proceed without saving first? All data that was not saved before a new instance i initiated will be lost.";
            else
                dlg = "Do you want to start a new instance of animal motel?";
            DialogResult dlgMessage;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            dlgMessage = MessageBox.Show(dlg, "New", buttons);
            if (dlgMessage == DialogResult.Yes)
                ResetApplication();
        }
        private void OpenDialogue()
        {
            string filePath = string.Empty;
            if (!savedFile)
            {
                // message box that gives the user the option to save their file to desktop
                if (MessageBox.Show("Do you want to save your current file before proceeding", "Open", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (sfdSave_Saveas.ShowDialog() == DialogResult.OK)// if the dialogue result is ok
                    {
                        filePath = sfdSave_Saveas.FileName;// create and define a path for the save data
                        Save(filePath);// call save method.
                    }
                }

            }
            // send an open new file dialogue
            if (opfLoading.ShowDialog() == DialogResult.OK)
            {
                filePath = opfLoading.FileName;// do create a new string instead of requiring an from the outside
                OpenSavedData(filePath);
            }
        }
        private void SaveDialogue()
        {
            if(sfdSave_Saveas.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfdSave_Saveas.FileName;
                if (File.Exists(fileName))
                    Save(fileName);
                else
                    SaveAs(fileName);
            }
        }

        // the below functions handle the data response behind the menue options in the application
        /// <summary>
        /// Method that resets the application to its initial state, this will be called by the new button after asking the user if
        /// they like to proceed without saving if that is not done before.
        /// </summary>
        private void ResetApplication ()
        {           
            aniMangage.DeleteAll();
            recipes.DeleteAll();
            employeeList.DeleteAll();
            UpdateGUI();
            SetUpGUI();
            showStaff = false;
            savedFile = true;
            UpdateinformationDisplay();
        }
        /// <summary>
        /// This function saves data in existing directory
        /// </summary>
        private void Save(string path)// takes the path of the file we want to save to
        {
            string errormsg = null;
            try
            {
                if (File.Exists(path))
                {
                    aniMangage.BinarySerialize(path);
                }
                else
                    MessageBox.Show("could'nt find the filepath are you sure it exists");
            }
            catch(Exception e)
            {
                errormsg = String.Format("Save failed: {0}", e.ToString());
                MessageBox.Show(errormsg, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                MessageBox.Show("Saved file");
            }
        }
        /// <summary>
        /// This function save a file down to a new directory
        /// </summary>
        private void SaveAs(string filePath)// the function get this information from a save file dialogue where the user specifies the domain
        {
            //1 first we want to check if the directory already does exist
            string errormsg = null;// define a string for eventual errormessages
            
            try
            {
                //2.Then we need to ask the user if they want to write over the old directory or create a new one with a prefix 
                if (File.Exists(filePath))
                {
                    // spawn messagebox
                    DialogResult dialog = MessageBox.Show("The file already exist do you want to overwrite it?", "Important", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                        Save(filePath);// call the save function 
                }
                else
                {//3.Then we need to create a new directory and call the method to serialize our list of objects down to it.
                    //File.Create(filePath);
                    aniMangage.BinarySerialize(filePath);// serialize down a binary file to the location of directory
                }

                }
            catch(Exception e)
            {
                //4. Then we need to catch an capture any errors
                errormsg = String.Format("Save failed: {0}",e.ToString());
                MessageBox.Show(errormsg, "Error", MessageBoxButtons.OK);// spawn messagebox detailing the error and wherein it laid
            }
            finally{}

        }
        /// <summary>
        /// Export an xmlfile containging the list of animals in animalmotel
        /// </summary>
        private void ExportAsXML(string filePath)
        {
            string errormsg = null;
            if (!File.Exists(filePath+".xml"))// check if there is an already existing xml file with the name
            {
                try
                {
                    //File.Create(filePath);
                    recipes.XMlSerialization(filePath);
                }
                catch (Exception e)
                {
                    errormsg = String.Format("XMLExport failed: {0}", e.ToString());// define errormessage
                    MessageBox.Show(errormsg, "Error", MessageBoxButtons.OK);
                }
                finally{}
            }
        }
        /// <summary>
        /// Open a binary file in the project
        /// </summary>
        private void OpenSavedData(string filePath)
        {
            string errormsg = null;
                if (File.Exists(filePath))// if the file do exist
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(filePath))// and the path naming is not equal to null
                        {
                            aniMangage.BinaryDeSerialize(filePath);// do binary deserialization of list
                            UpdateGUI();// update the graphical user interface
                            btnDeleteAnimal.Enabled = false;// shut of the delete animal button if it is turned on
                        }
                    }
                    catch (Exception e)
                    {
                        errormsg = String.Format("Failed to open file: {0}", e.ToString());// define an errormessage
                        MessageBox.Show(errormsg, "Error", MessageBoxButtons.OK);// spawn messagebox
                    }
                    finally{}
                }
               
        }
        /// <summary>
        /// Open a XML file earlier saved to desk
        /// </summary>
        private void OpenSavedXML(string filepath)
        {
            string errormsg;
            if (File.Exists(filepath))
            {
                try
                {
                    recipes.XMLDeserialization(filepath);
                    showStaff = false;
                    UpdateinformationDisplay();
                }
                catch(Exception e)
                {
                    errormsg = String.Format("XML loading failed: {0}", e.ToString());
                    MessageBox.Show(errormsg,"Error",MessageBoxButtons.OK);
                }
                finally{}
            }
        }
        /// <summary>
        /// Update the UI animalocject list for when reptiles are selected
        /// </summary>
        private void UpdateForReptile()
        {
            // set up the ui to represent reptiles
            gpbSpecifications.Text = "Reptile specifications";
            lblAttribute1.Text = "Req-environmental temperature C";
            lblAttribute2.Text = "Crawlspeed m/h";
                lstAnimalObject.Items.Clear();
                lstAnimalObject.Items.AddRange(Enum.GetNames(typeof(ReptileSpecies)));
                // bind the reptilespecie enum to the lstanimalobject.selectedindex if all animals selection are not active
                lstAnimalObject.SelectedIndex = (int)ReptileSpecies.Chameleon;
            
        }
        /// <summary>
        /// Update the UI for when birds are selected
        /// </summary>
        private void UpdateForBird()
        {
            // set up ui to represent birds
            gpbSpecifications.Text = "Bird specifications";
            lblAttribute1.Text = "Coloration";
            lblAttribute2.Text = "Flight Speed km/h";                                  
            // update listbox information for birds specifically
            lstAnimalObject.Items.Clear();
            lstAnimalObject.Items.AddRange(Enum.GetNames(typeof(BirdSpecies)));
            // set the selectedindex of listbox at parrot for default if select among all animals are not active
            lstAnimalObject.SelectedIndex = (int)BirdSpecies.Parrot;

        }        
        /// <summary>
        ///  dependent on which category is active the interface for interacting with the program looks different
             // this is what this method is desgined for, if the user has birds selected the interface should ask for the infromation
             // related to birds, if the user is selecting reptiles on hte other hand the interface shal ask for the information
             // relevant to reptiles.
        /// </summary>
        private void UpdateSpecificInformation()
        {
           
            Category cat = (Category)cmbCategory.SelectedIndex;
            switch (cat)
            {
                case Category.Reptile:
                    ReptileSpecies reps = (ReptileSpecies)lstAnimalObject.SelectedIndex;
                    switch (reps)
                    {
                        case ReptileSpecies.Chameleon:
                            lblAttribute3.Text = "Colorchangespeed secounds";
                            break;
                        case ReptileSpecies.SeaTurtle:
                            lblAttribute3.Text = "Swimspeed km/h";
                            break;
                    }
                    break;
                case Category.Bird:
                    BirdSpecies birds = (BirdSpecies)lstAnimalObject.SelectedIndex;
                    switch (birds)
                    {
                        case BirdSpecies.Parrot:
                            lblAttribute3.Text = "Known Phrases";
                            break;
                        case BirdSpecies.Pigeon:
                            lblAttribute3.Text = "Letters carried";
                            break;
                    }
                    break;
            }
        }
        /// <summary>
        /// When the user clicks on an animal the interface is updated with feeding information about how many times the animal should be fed and 
        /// what kind of diet it has.
        /// </summary>
        private void UpdateFoodschedule()
        {
            Animal animal = aniMangage.FindAt(lstAnimalList.SelectedIndex);// create a reference to the animal selected in the list
            mainSchedule = animal.GetFoodschedule();// define mainschedule after the selected index
            lblDietType.Text = animal.AnimDiet.ToString();//set text in dietbox to reflect the animals choosen diet
            lstFeedingSchedule.Items.Clear();// clears the feeding schedule
            lstFeedingSchedule.Items.Add(mainSchedule.DescribeNoFeedingRequired());// get the general information for the animal feeding scheduling
            ///lstFeedingSchedule.Items.AddRange(mainSchedule.PresentFoodSchedule());//present the foodschedule for the animal  
            UpdateFeedingDetails(animal);
        }
        /// <summary>
        /// set the sortbynams bool property in animal manager to either true or false dependent on the sorting method choosen
        /// </summary>
        private void RadioButtonController()
        {
            if (rbtnSortByID.Checked)
            {
                SortByID comparer = new SortByID();
                aniMangage.Sort(comparer);
            }
            else if (rbtnSortByPetName.Checked)
            {
                CompareByName comparer = new CompareByName();
                aniMangage.Sort(comparer);
            }
        }
        /// <summary>
        /// method that fills a list of strings with the same hard coded strings as in the individual 
        //animals feeding schedules based on selections in interface/details saved in animal I know the solution looks ugly as hell but it was the only way for me to properly show the different
        // feeding schedules that I havde defined in the animal objects. I know that I completely bypasses the foodschedule class here but it is only because the foodschedule 
        // class for some odd reason refuses to return a list of strings when called. since the information I've got when asking is that the schedule should be hardcoded, then here it is
        // hardcoded to the point of being written directly into the interface when an animal is selected, with strings defined a secound time in the GUI class
        /// </summary>
        private void UpdateFeedingDetails(Animal anim)
        {
            string[] newInstructions;
            string specie = anim.GetSpecies();// get the specie of the animal
            //Switch for wich specie is active for the animal
            switch (specie)
            {
                case "Chameleon":
                    if(anim.AnimDiet == Diet.MeatEater)
                    {
                        newInstructions = new string[4];
                        newInstructions[0] = "Morning: 1 plate with small fish";
                        newInstructions[1] = "Lunch: Mix of fish and small spiders";
                        newInstructions[2] = "Afernoon: Insect snacks";
                        newInstructions[3] = "Evening: One bowl of spidermeat";
                        lstFeedingSchedule.Items.AddRange(newInstructions);
                    }
                    else if(anim.AnimDiet == Diet.AllEater)
                    {
                        newInstructions = new string[4];
                        newInstructions[0] = "Morning: 1 plate of fruit and insects";
                        newInstructions[1] = "Lunch fruit and fisch pieces";
                        newInstructions[2] = "Afternoon: 2 pieces of mango";
                        newInstructions[3] = "Evening, 1/2 bird egg and a bowl of insects";
                        lstFeedingSchedule.Items.AddRange(newInstructions);
                    }
                    else if(anim.AnimDiet == Diet.PlantEater)
                    {
                        newInstructions = new string[5];
                        newInstructions[0] = "Morning: Plant leaves and fruit pieces";
                        newInstructions[1] = "Lunch: A bowl of friut pieces and plant leaves";
                        newInstructions[2] = "Afternoon: 4 pieces of mango and some water";
                        newInstructions[3] = "Evening: a bowl of mango and apple pieces";
                        newInstructions[4] = "Often: refill water herbivorous chameleons consume much water every day";
                        lstFeedingSchedule.Items.AddRange(newInstructions);
                    }
                    break;
                case "Sea Turtle":
                    if(anim.AnimDiet == Diet.MeatEater)
                    {
                        newInstructions = new string[4];
                        newInstructions[0] = "Morning: two big salmons and a bowl of northern herring";
                        newInstructions[1] = "Lunch: Landturtle meat and a bowl of cubed raw salmon";
                        newInstructions[2] = "Afernoon: Small tropical fish";
                        newInstructions[3] = "Evening: One bowl of raw sealmeat";
                        lstFeedingSchedule.Items.AddRange(newInstructions);
                    }
                    else if(anim.AnimDiet== Diet.AllEater)
                    {
                        newInstructions = new string[4];
                        newInstructions[0] = "Morning: A bowl of seaweed, five seaweedcrakers and two small bird eggs";
                        newInstructions[1] = "Lunch: Seaweed sallad with salmon and herring pieces";
                        newInstructions[2] = "Afternoon: Seaweed crackers and sesame seed bread";
                        newInstructions[3] = "Evening: Seaweed, half a salmon and five herrings";
                        lstFeedingSchedule.Items.AddRange(newInstructions);
                    }
                    else if(anim.AnimDiet == Diet.PlantEater)
                    {
                        newInstructions = new string[3];
                        newInstructions[0] = "Morning: Bowl of mixed seaweed";
                        newInstructions[1] = "Lunch: Seaweed salad, with pieces of mango and dragon fruit";
                        newInstructions[2] = "Evening: Seaweed crackers and fruit salad";
                        lstFeedingSchedule.Items.AddRange(newInstructions);
                    }
                    break;
                case "Pigeon":
                    if (anim.AnimDiet == Diet.MeatEater)
                    {
                        newInstructions = new string[4];
                        newInstructions[0] = "Dawn: The Pigeon will hunt for small insects such as fleas and maggots";
                        newInstructions[1] = "Morning: One small bowl of spiderlegs and bumblebees";
                        newInstructions[2] = "Lunch: One big spider";
                        newInstructions[3] = "Evening: The Pigeon will hunt smaller insects such as fireflies by itself";
                        lstFeedingSchedule.Items.AddRange(newInstructions);
                    }
                    else if (anim.AnimDiet == Diet.AllEater)
                    {
                        newInstructions = new string[3];
                        newInstructions[0] = "Morning: One small bowl of insects and seeds";
                        newInstructions[1] = "Lunch: Breadcrums, worms and fireflies";
                        newInstructions[2] = "Evening: Sesame seed crackers and a bowl of small insects";                       
                        lstFeedingSchedule.Items.AddRange(newInstructions);
                    }
                    else if(anim.AnimDiet==Diet.PlantEater)
                    {
                        newInstructions = new string[4];
                        newInstructions[0] = "Morning: Sesame seeds and breadcrumbs";
                        newInstructions[1] = "Lunch: Fruit and berries";
                        newInstructions[2] = "Afternoon: Nuts and various seeds";
                        newInstructions[3] = "Evening: bowl of corn and small nuts";
                        lstFeedingSchedule.Items.AddRange(newInstructions);
                    }
                    break;
                case "Parrot":
                    if (anim.AnimDiet == Diet.MeatEater)
                    {
                        newInstructions = new string[4];
                        newInstructions[0] = "Morning: Bowl of jumbo insect legs";
                        newInstructions[1] = "Lunch: spiderlegs and giant mosquitos";
                        newInstructions[2] = "Afternoon: Maggots and fishpieces hidden in enclosure for the bird to search";
                        newInstructions[3] = "Evening, bowl of tropical insects";
                        lstFeedingSchedule.Items.AddRange(newInstructions);
                    }
                    else if (anim.AnimDiet == Diet.AllEater)
                    {
                        newInstructions = new string[4];
                        newInstructions[0] = "Morning: One bowl of fruit and peanuts";
                        newInstructions[1] = "Lunch: Fruitsallad, peanutbisquits and spiderlegs";
                        newInstructions[2] = "Evening Bowl of fish and tropical fruit";
                        newInstructions[3] = "Observe that this bird should never be fed chocholate";
                        lstFeedingSchedule.Items.AddRange(newInstructions);
                    }
                    else if(anim.AnimDiet == Diet.PlantEater)
                    {
                        newInstructions = new string[5];
                        newInstructions[0] = "Morning: Half a mango and a bowl of peanuts";
                        newInstructions[1] = "Lunch: Tropical fruits and nuts";
                        newInstructions[2] = "Afternoon: Hide nuts and fruit in enclosure for bird to search";
                        newInstructions[3] = "Occasionally: Some extra nutcrackers";
                        newInstructions[4] = "Evening: Dranonfruit and apples";
                        lstFeedingSchedule.Items.AddRange(newInstructions);
                    }
                    break;
            }
        }
        /// <summary>
        /// Removes GUI items relating to foodschedule when an item is deleted
        /// </summary>
        private void EraseFoodScheduleGUI()
        {
            lblDietType.Text = String.Empty;
            lstFeedingSchedule.Items.Clear();
        }
        /// <summary>
        /// Method for updating the information display for recipes and staff dependent on a boolean
        /// </summary>
        private void UpdateinformationDisplay()
        {
            if (!showStaff)
            {
                grpFood_StaffInfo.Text = "Recipe information";

                lstinformation.Items.Clear();
                lstinformation.Items.AddRange(recipes.PresentArray());
            }
            else if (showStaff)
            {
                grpFood_StaffInfo.Text = "StaffInformation";

                lstinformation.Items.Clear();
                lstinformation.Items.AddRange(employeeList.PresentArray());
            }
        }
        /// <summary>
        /// Function that handles the different keyboard shortcuts for exiting, saving, opening new files exporting to exml and more
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.X)
                ExitDialogue();
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.N)
                NewDialogue();
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                SaveDialogue();
                savedFile = true;
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O)
                OpenDialogue();// call the method for open data saved down to disk from the application
               
        }

        
    }
}
