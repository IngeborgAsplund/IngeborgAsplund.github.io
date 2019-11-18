using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund 2018
namespace APUsZoo
{
    /// <summary>
    /// This class specifies a recipe for animal food. It has a name and a collection of ingredients(in the form of strings)
    /// </summary>
    public class Recipe
    {
        private string name;
        private ListManager<string> ingredients;
        /// <summary>
        /// property for the name variable of recipe
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Property for list returning the strings contained in ingredients
        /// </summary>
        public ListManager<string> Ingredients
        {
            get { return ingredients; }
        }
        
        /// <summary>
        /// default constructor initialized on creation of component
        /// </summary>
        public Recipe ()
        {
            ingredients = new ListManager<string>();
        }

        /// <summary>
        /// To string method that returns the name of the recipe as well as its ingredients, to be called by other classes in the scripts hierarchy
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string recipeinfo = Name + ":";
            int index = 0;
            if (index != -1)
            {
                for (index = 0; index < Ingredients.Count; index++)
                {
                    recipeinfo += Ingredients.FindAt(index).ToString()+", ";
                }
            }
          
            return recipeinfo;
        }
        
        

    }
}
