using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//By Ingeborg Asplund 2018
namespace Threading_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        private Thread story;
        private Thread image;
        DrawText myWriter;
        Triangle mytriangle;
        /// <summary>
        /// Initialization of the mainwindow of the application
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            myWriter = new DrawText();
            myWriter.Writer = lstStory;// give acess to the listbox text is displayed on  
            mytriangle = new Triangle();
            this.DataContext = mytriangle;
           
        }
        
        /// <summary>
        /// Method that initializes the start of the Storytelling thread which display random sentences choosen from 
        /// a wide variety of options and thus creates a silly story.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartStory_Click(object sender, RoutedEventArgs e)
        {
            story = new Thread(myWriter.DisplayText);//create a thread for displaying text                      
            myWriter.IsRunning = true;
            story.Start();
        }
        /// <summary>
        /// Method that stops telling the story and make the story thread join the rest of the application again
        /// ending the story with a "and so they lived happily ever after"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopTelling_Click(object sender, RoutedEventArgs e)
        {            
            myWriter.IsRunning = false;
        }
        /// <summary>
        /// Method that starts the thread that stops the draw thread and makes it rejoin the mainthread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawGraphics_Click(object sender, RoutedEventArgs e)
        {
            image = new Thread(mytriangle.RotateShape);                  
            mytriangle.IsRunning = true;
            image.Start();
        }
        /// <summary>
        /// function that stops drawing the triangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopDrawing_Click(object sender, RoutedEventArgs e)
        {        
                mytriangle.IsRunning = false;
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            if (myWriter.IsRunning || mytriangle.IsRunning)
            {
                myWriter.IsRunning = false;
                mytriangle.IsRunning = false;
                Application.Current.Shutdown();
            }
            else
                Application.Current.Shutdown();
        }
    }
}
