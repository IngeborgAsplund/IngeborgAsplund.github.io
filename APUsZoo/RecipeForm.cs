using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// This is a file containing the code operating behind the scenes of the Recipeform it handles the button click functionality
/// for adding removing and changing recipes
/// </summary>
namespace APUsZoo
{
    public partial class RecipeForm : Form
    {
        private Recipe recipe;//variable that acess a recipe
        private string ingredient;// string assigned by add method
        /// <summary>
        /// This is the first method called when initialized it create a new form of type recipeform and adds a recipe if initial recipe is not equal to null
        /// </summary>
        public RecipeForm()
        {
            InitializeComponent();
            if (recipe == null)
                recipe = new Recipe();
            InitGUI();
        }
        /// <summary>
        /// Method that clears the GUI and set the form up for use
        /// </summary>
        private void InitGUI()
        {
            txtIngredients.Text = string.Empty;
            txtRecipeName.Text = string.Empty;
            lstIngredients.Items.Clear();
            btnChangeIngredient.Enabled = false;
            btnDeleteIngredient.Enabled = false;
            
        }
        /// <summary>
        /// public property for the recipe variable created by this class
        /// </summary>
        public Recipe Recipe
        {
            get { return recipe; }
            set { Recipe = value; }
        }
        /// <summary>
        /// Buttonclick for adding a recipe ingredient to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            ingredient = txtIngredients.Text;
            bool validToAdd = ValidateString(ingredient);
            if (validToAdd)
            {
                Recipe.Ingredients.Add(ingredient);
                UpdateGUI();                               
                            
            }
            else
                MessageBox.Show("Please make sure that you have typed in a name for the ingredient");
        }
        /// <summary>
        /// Buttonclick for changing an ingredient on the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeIngredient_Click(object sender, EventArgs e)
        {
            ingredient = txtIngredients.Text;
            int changeInd = lstIngredients.SelectedIndex;
            bool validChange = ValidateString(ingredient);
            if (validChange && changeInd != -1)
            {
                Recipe.Ingredients.Change(ingredient, lstIngredients.SelectedIndex);                             
                UpdateGUI();                
            }
            else
                MessageBox.Show("Input was invalid please make sure that you typed a name of your ingredient and that the item you want to change exist in the current context");
                
        }
        /// <summary>
        /// Buttonclick for deleting an ingredient in this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteIngredient_Click(object sender, EventArgs e)
        {
            int indexToRemove = lstIngredients.SelectedIndex;
            if(indexToRemove!=-1)
            {
                Recipe.Ingredients.Delete(lstIngredients.SelectedIndex);                            
                UpdateGUI();                                   
            }
        }
        /// <summary>
        /// When finish is clicked the name of the recipe is registered in the recipeclass
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            string name = txtRecipeName.Text;
            bool nameOk = ValidateString(name);
            if (nameOk)
                Recipe.Name = name;
            else
                MessageBox.Show("Name was invalid, please enter a name for the recipe");
        }
        /// <summary>
        /// small validationmethod used by several of the functions in this forms it checks that the information in a string is not equal to null or empty
        /// </summary>
        /// <param name="checkThis"></param>
        /// <returns></returns>
        private bool ValidateString(string checkThis)
        {
            if (!string.IsNullOrEmpty(checkThis))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Function that updates the listbox items after adding an ingredient.
        /// </summary>
        private void UpdateGUI()
        {
            txtIngredients.Text = string.Empty;
            btnChangeIngredient.Enabled = false;
            btnDeleteIngredient.Enabled = false;
            lstIngredients.Items.Clear();
            lstIngredients.Items.AddRange(Recipe.Ingredients.PresentArray());
        }
        /// <summary>
        /// Function that updates the textbox for ingredient with the content of the corresponding string in the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstIngredients.SelectedIndex != -1)
            {
                txtIngredients.Text = lstIngredients.SelectedItem.ToString();
                btnChangeIngredient.Enabled = true;
                btnDeleteIngredient.Enabled = true; 
            }
           
        }
    }
}
