using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Aplund 2018
namespace APUsZoo
{
    /// <summary>
    /// Interface that details the methods that an abstract class Animal must have within its, containing no fields and leave the implementation 
    /// of methods to the Animal class this interfaces main task is to define what must exist for all animals
    /// </summary>
     interface IAnimal
    {
        // Needed Properties

        /// <summary>
        /// all animals must have a gender defined
        /// </summary>
        Gender AnimGender { get; set; }
        /// <summary>
        /// all animals must have a defined diet.
        /// </summary>
        Diet AnimDiet { get; set; }
        /// <summary>
        /// All animals must have a category
        /// </summary>
        Category AnimCat { get; set; }
        /// <summary>
        /// All animals must have an ID
        /// </summary>
        int ID { get; set; }
        /// <summary>
        /// All animals must have an age
        /// </summary>
        double Age { get; set; }
        /// <summary>
        /// All animals must have a name
        /// </summary>
        string Name { get; set; }

        // Needed methods.
        /// <summary>
        /// string FormatAnimalDetails are needed to implement by the animal class.
        /// </summary>
        /// <returns></returns>
        string ToString();
        /// <summary>
        /// Animal is required to implement the getFoodschedule method. 
        /// Foodschedules will vary dependent on which type of diet the user choosen and which specie of animal it is
        /// </summary>
        FoodSchedule GetFoodschedule();
        /// <summary>
        /// Animal is required to implement the GetSpecies method, that returns which kind of specie the animal in question belong to
        /// </summary>
        string GetSpecies();

    }
}
