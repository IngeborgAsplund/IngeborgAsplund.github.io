using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Igeborg Asplund 2018
namespace ApplicationLogics
{
    /// <summary>
    /// This is an enum depicting the different types of minions one could reqruit it is meant to serve a similar 
    /// purpose as the competence titles/ jobs in the competence registry/appointment schedule in the example given
    /// in the assignment description, meaning that certain traits can be linked to the various miniontype
    /// </summary>
    /// 
    [Serializable]
   public enum  MinionType
    {
        Flareimp,
        Icegiant,
        WindSpectre,
        Unrestfull_Spirit,
        Shadowfoe,
        Flamehound,
        ForgottenOne,
        Souleater,
        SwampHunter,
        Boggling,
        HellWasp,
    }
}
