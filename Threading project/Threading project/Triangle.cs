using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Globalization;
//By Ingeborg Asplund 2018
namespace Threading_project
{
    /// <summary>
    /// This class handles the triangle and draws the polygon at the right side of the interface
    /// </summary>
    class Triangle:INotifyPropertyChanged
    {
        private int angle;// used to set the images angle 
        private bool isRunning;

        public event PropertyChangedEventHandler PropertyChanged;//event for alerting WPF about a change in the property for rotation of the image

        /// <summary>
        /// Property for that shows if this thread is running or not
        /// </summary>
        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }
        ///// <summary>
        ///// Prperty for the angle of the triangle
        ///// </summary>
        public int Angle
        {
            get { return angle; }
            set { angle = value;
                OnPropertyChanged("Angle");
            }
        }
        /// <summary>
        /// Constructor that sets up everything we need to have ready when this class is used
        /// </summary>
        public Triangle()
        {
            Angle = 0;            
        }
        
        /// <summary>
        /// Function thad draws and rotate a shape in image rotation part of the form.
        /// </summary>
        public void RotateShape()
        {
            //drawCanvas.Dispatcher.Invoke(new Action(() => drawCanvas.Children.Add(rotationShape)));                       
            while(isRunning)
            {
                //calculate the angle which the object should be rotating
                if (Angle < 360)
                    Angle = Angle + 10;
                else
                    Angle = 0;
                Thread.Sleep(1000);//wait 1 secound
            }
        }
        /// <summary>
        /// Method to make the wpf interface aware of the change in the rotation property
        /// </summary>
        /// <param name="propName"></param>
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        
    }
}
