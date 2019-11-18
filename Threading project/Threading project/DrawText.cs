using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;
//By Ingeborg Asplund 2018
namespace Threading_project
{
    /// <summary>
    /// This class are used to handle the textwriting to the listbox in the ui. Its thread is 
    /// started at the start of the program and its activeness decided by an internal bool(isAktive)
    /// </summary>
    class DrawText
    {
        //Insance variables
        private System.Windows.Controls.ListBox writeCanvas;
        private List<string> storyComponents;// list containing all of the possible strings a story can contain
        private bool isRunning;//determines if the thread should be running easily truned of and on with this bool  
      
        /// <summary>
        /// property that allows other classes to set the internal bool isrunning used to determine weather or not to draw text onto the canvas
        /// </summary>
        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }
        /// <summary>
        /// property through which the writecanvas are set
        /// </summary>
        public System.Windows.Controls.ListBox Writer
        {
            set { writeCanvas = value; }
        }
        
        /// <summary>
        /// class constructor for the drawtext class initializing the values that needs to be set at class construction
        /// </summary>
        public DrawText()
        {
            storyComponents = new List<string>();
            FillList();          
        }
        /// <summary>
        /// method that writes out text in listbox
        /// </summary>
        private void UpdateUI( int selsction)
        {
            string component = storyComponents[selsction];
            writeCanvas.Dispatcher.Invoke(new Action(() => writeCanvas.Items.Add(component)));
        }
        /// <summary>
        /// Method that fills the list of strings displayed in the thread that writes the random story 
        /// </summary>
        private void FillList()
        {
            storyComponents = new List<string>();
            storyComponents.Add("Timmy Picked up the green gemstone from the dusty road.");
            storyComponents.Add("A dragon trotted by flapping its bright purple wings.");
            storyComponents.Add("The road continued on and on towards the horizon.");
            storyComponents.Add("The sun was setting and the sky turned bright red.");
            storyComponents.Add("Birds flew towards the bright yellow sun in the sky.");
            storyComponents.Add("He looked upwards and scratched his forehead with a tiny hand.");
            storyComponents.Add("His hands had sharp claws and yellow teeth protruded from his mouth.");
            storyComponents.Add("Alicia was a green butterfly with orange wings and big facetted eyes.");
            storyComponents.Add("She liked to swim in the oceans with fish and dolphins.");
            storyComponents.Add("She crashed her toy airplane in the river and could'nt retrievi it.");
            storyComponents.Add("The cake smelled delicious, they could not withstand the temptation.");
            storyComponents.Add("A small bug sat in a three talking to his children.");
            storyComponents.Add("She used to teach her children how to recognize a predator.");
            storyComponents.Add("The gemstone glittered in green and blue reflecting his eyes.");
            storyComponents.Add("There was a sword hidden in the forest burried under and ancient stonepillar.");
            storyComponents.Add("She was a muscular person weighting up to 150 lbs.");
            storyComponents.Add("She swiped her tail, spikes protruding from its topside.");
            storyComponents.Add("His voice was soft as he spoke looking towards the dazzling flame.");
            storyComponents.Add("The village burnt down last night and no one has an idea whoes fault it was.");
            storyComponents.Add("Ida tied a knot and raised the sails of her vessel.");
            storyComponents.Add("He wished he could fly but knew he would never learn.");
            storyComponents.Add("She was a professional vrestler from a fightclub in town.");
            storyComponents.Add("He was the prettiest prince in all of the kingdom, nicknamed little borother Sam.");
            storyComponents.Add("He liked cars and was a big fan of motorcompetitions until his favorite racer died from the sport..");
            storyComponents.Add("He lost everything when the castle burnt down.");
            storyComponents.Add("Dragons are scary creatures of menacing power don't toy with them.");
        }
        /// <summary>
        /// Method that display the text on the story part of the form
        /// </summary>
        public  void DisplayText()
        {
            writeCanvas.Dispatcher.Invoke(new Action(() => writeCanvas.Items.Clear()));         
            Random random = new Random();// instanciate a new item of the randomclass 
            while (isRunning)
            {
                int randomSelect = random.Next(storyComponents.Count);// generates a randomindex
                UpdateUI(randomSelect);
                Thread.Sleep(1000);
            }
                                       
        }
    }
}
