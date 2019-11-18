using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund 2018
namespace EvilOverlordsDiagramGenerator
{
    /// <summary>
    /// This class contains methods to parse strings into the right values in this case integers
    /// </summary>
    class ParseInput
    {
        /// <summary>
        /// Method to parse the string values as ints when that is needed, can take in any string that
        /// need to be converted to int and return the des
        /// </summary>
        /// <param name="xdivisionNo"></param>
        /// <returns></returns>
        public int ParseStringToInt(string value)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(value))
            {
                bool parsable = IntOK(value);
                if (parsable)
                    result = int.Parse(value);
            }
            else
                MessageBox.Show("Must have a numeric value and are not allowed to be empty", "Error");
            return result;
        }
        /// <summary>
        /// Method that parses string inputs as double values, any strig one want to convert to a double might be sent in
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double ParseStringToDouble(string value)
        {
            double result = 0;
            if (!string.IsNullOrEmpty(value))
            {
                bool parsable = DoubleOk(value);
                if (parsable)
                    result = double.Parse(value);
            } 
            else
                MessageBox.Show("Must have a numeric value and are not allowed to be empty", "Error");
            return result;
        }
        /// <summary>
        /// See to that the settings values are not set to negative values.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SettingsNotNegative(int divX, int divY, int scalX,int scalY )
        {
            if (divX>=0&&divY>=0&&scalX>=0&&scalY>=0)
                return true;
            else return false;
        }
        /// <summary>
        ///  Bool that returns true or false depending on if the string sent in is possible to parse to an int
        /// </summary>
        /// <param name="parseMe"></param>
        /// <returns></returns>
        private bool IntOK(string parseMe)
        {
            int result;
            bool ok = int.TryParse(parseMe, out result);
            return ok;
        }
        /// <summary>
        /// Checks if it is possible to parse the string sent in to a double
        /// </summary>
        /// <param name="parseMe"></param>
        /// <returns></returns>
        private bool DoubleOk(string parseMe)
        {
            int result;
            bool ok = int.TryParse(parseMe, out result);
            return ok;
        }
        
    }
}
