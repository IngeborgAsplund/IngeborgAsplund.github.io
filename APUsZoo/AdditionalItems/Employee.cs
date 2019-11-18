using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// This is a script handling the information for employees at the APU zoo.
/// </summary>
namespace APUsZoo
{
    public class Employee
    {
        private string name;
        private ListManager<string> qualifications;
        /// <summary>
        /// Property 
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Property for the list of qualifications registered through listmanager
        /// </summary>
        public ListManager<string> Qualifications
        {
            get { return qualifications; }
        }
        
        /// <summary>
        /// public constructor for the employee class, that creates a neww instance of the listmanager type string
        /// </summary>
        public Employee()
        {
            qualifications = new ListManager<string>();
            
        }
       
        public override string ToString()
        {
            string employeeinfo = Name + ":";
            int index = 0;
            if (index != -1)
            {
                for (index = 0; index <Qualifications.Count; index++)
                {
                   
                    employeeinfo +=Qualifications.FindAt(index).ToString()+", ";
                }
            }                           
            return employeeinfo;
        }
        /// <summary>
        /// method for checking the information in strings sent into the program by the user
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public bool CheckString(string check)
        {
            if (!string.IsNullOrEmpty(check))
                return true;
            else return false;
        }
       
    }
}
