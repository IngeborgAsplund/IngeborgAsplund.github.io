using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund 2017-2018
namespace Troop_Calculator
{
    public class Troop
    {
        private string troopName;// the name of the troop
        private int numberOfMinions; //how many units the troop consist of
        private MinionType miniontype; // which type of minions consist the troop of(there are sic types)

        // Property methods for this class instance variables.
        public string TroopName
        {
            get { return troopName; }
            set { troopName = value; }
        }
        public int NumberOfMinions
        {
            get { return numberOfMinions; }
            set { numberOfMinions = value; }
        }
        public MinionType DefineType
        {
            get { return miniontype; }
            set { miniontype = value; }
        }
        public Troop() 
        {
            // basic constructor, this is initially called when other classes call an object of this class
        }
        public Troop(string name, MinionType minion, int number)
        {
            //constructor of three parameters-called when the program adds an object of this type
            TroopName = name;
            DefineType = minion;
            NumberOfMinions = number;
        }
        public int DetermineStrength()
        {
            // contains a switch case loop that defines the strenght each minion has dependent on the enum choosen by the user
            // The reason for doing it this way and not let the user type in a value for strenght is that I believe that it becomes
            // more challenging to build and army if you have a set of predefined values you have to choose from rather than being able to 
            // give your troopmembers any strenght.
            // Since this application is slightly gamified my thought was that I wanted to include some form of basic game mechanic, that builds challenge and
            // hopefully make the app fun to use.
            int stregth = 0;// determined by enum and initiated as zero
            MinionType lokalType = DefineType;// make sure that it is actually the active enum that is used through use of property instead if instance variable
            switch (lokalType)
            {
                case MinionType.Dynamitetroll:
                    stregth = 14;
                    break;
                case MinionType.Deathsister:
                    stregth = 18;
                    break;
                case MinionType.Lavaspider:
                    stregth = 5;
                    break;
                case MinionType.BurningHusk:
                    stregth = 20;
                    break;
                case MinionType.Firebird:
                    stregth = 15;
                    break;
                case MinionType.Helldragon:
                    stregth = 25;
                    break;
            }
            return stregth;// returns the strength variable that is used in the function below to calculate the total strength of the troop
        }
        // Calculate streght of the whole troop
        public int CalculateTotalStrenght()
        {
            int strenght = DetermineStrength();// calls the above method to determine how strong each member of the troop will be
            int totalStrenght = 0;// total strenght initiated to 0 = strength*quantity.
            if (NumberOfMinions >-1)// check so that number of minions is not negative
                totalStrenght = strenght * NumberOfMinions;// strenght is multiplied with the number of minions to get the total strenght of the troop
            return totalStrenght;
        }
        public override string ToString()
        {
            // writes out the information in the class Troop in a formated string
            string noSoldiers = numberOfMinions.ToString();//translates the number of minions assigned to the troop to string
            string strenght = CalculateTotalStrenght().ToString();//gets the totalstrenght of the troop and translates to string
            string troopTitle = String.Format("{0,15}{1,40}{2,40}{3,25}",TroopName,DefineType.ToString(),noSoldiers,strenght);//needs testing
            return troopTitle;
        }
    }
}
