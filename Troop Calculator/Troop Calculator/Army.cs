using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund 2017-2018
namespace Troop_Calculator
{
    class Army
    {
        private List<Troop> armytroops;// declares a list of the type troop

        // properties for list and totalArmyStrenght the later is not instance variable since it is only used for output
        public int numberOfTroops
        {
            get { return armytroops.Count; }// return all elements in list
        }
        public int TotalArmystrenght
        {
            
            get { return CalculateArmyStrenght(); }// return results of method CalculateArmystrength
            set { int armystrength = value; }//this is only used by the resetmethod ClearList that send the value of 0 to the total armystrength when activated
        }
        // basic constructor for when this class are called by other classes(MainForm)
        public Army()
        {
            armytroops = new List<Troop>();// initiates the list of troops
        }
        public bool AddTroop(string name, MinionType minion,int numberOfMninions)
        {
            bool ok = false;
            //check that number of minions are bigger or equal to zero, that the input for number of minion are numerical is checked by main form
            if (!string.IsNullOrEmpty(name) && numberOfMninions >= 0)
                ok = true;
            if (ok)
            {
                Troop troopToadd = new Troop(name, minion, numberOfMninions);// create an object using constructor with three parameters
                armytroops.Add(troopToadd);
            }
            return ok;
        }
        public bool EditTroop(Troop troopToedit, int troopindex)// troopindtex = selected index in listbox
        {
            // Changes a troop at specific index in list
            bool ok = false;
            if (troopToedit != null && troopindex >= 0 && troopindex < numberOfTroops)
                ok = true;
            if (ok)
            {
                Troop oldTroop = GetTroopAt(troopindex);// calls a method that get the old troop that should be removed
                armytroops.Remove(oldTroop);
                armytroops.Insert(troopindex, troopToedit);//insert the edited troop
            }
            return ok;
        }
        public bool DeleteTroop(int index)// index = selected index in listbox
        {
            //delete a troop at given index in dynamic list
            bool ok = false;
            if (index >= 0 && index < numberOfTroops)// check if within index
                ok = true;
            if (ok)
            {
                Troop troopToRemove = GetTroopAt(index);
                armytroops.Remove(troopToRemove);
            }
            return ok;
        }
        public Troop GetTroopAt(int index)
        {
            // Get a specific troop by using its index this are used by the edit and delete methods amongn others
            Troop foundtroop = armytroops[index];// foundtroop equals to the troop at the specified index in the armytroops dynamic List
            return foundtroop;// returns the found troop
        }
        public int CalculateArmyStrenght()
        {
            int totalstrength = 0;// the total strength is incremented with one
            int index = 0;
            foreach (Troop troop in armytroops)
            {
                totalstrength = totalstrength + troop.CalculateTotalStrenght();// adds all of the troops in the calculator togheter
                index++;// increment index with one
            }
            return totalstrength;//return the value resulting of the operation above
        }
        public void ClearList()
        {
            armytroops.Clear();// this reset the list of troops making it containing
            TotalArmystrenght = 0;// reset the army strengh to zero avoiding a situation where the user is choosing new from the menue or through shortcut and
            // then press calculate army strenght in the user interface getting the preiously calculated value as result
        }
        public string[] TroopToList()
        {
            string[] trooplist = new string[numberOfTroops];
            int index = 0;
            foreach(Troop troop in armytroops)
            {
                    trooplist[index++] = troop.ToString();// adds strings created by of troop.tostring 
            }
            return trooplist;// return an array of strings
        }
        // below I have added a testmethod for adding troops
        public void TestValues()
        {
            AddTroop("Front Flank", MinionType.Helldragon, 3);// test adds a troop that is as name sugests aimed at frontal battle
            AddTroop("Left flanc", MinionType.Lavaspider, 60);// adds another one, this makes it poosible to also test the calculate total armystrenght function in a fast way
        }
    }
}
