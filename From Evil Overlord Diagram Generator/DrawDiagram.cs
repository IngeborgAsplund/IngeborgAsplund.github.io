using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
// By Ingeborg Asplund 2018
namespace DrawingAndDiagramUtility
{
    /// <summary>
    /// Class containing the methods required to create diagrams, daw lines and place points depending on the current
    /// sorting of the diagram and input data of the application. This are done through required input parameters for instance
    /// the method that draws divisions want to know how many divisions is to be made along a certain axis as well as how long said diagram axis 
    /// is.
    /// </summary>
    public class DrawDiagram
    {
        private List<Point> diagramPoints;//list of points 
        private List<string> displaycoords; // list of strings representing the originally assigned locations without multiplication by scalefactor      
        private WriteText myTextFormater;//an instance of the WriteText
        private ScalePoints scaler;//reference to the object that scales the points in the diagram to be placed accuratly
        //scaling variables
        private int maxX;//defines maximum value for Xaxis
        private int maxY;//defines maximum value for Yaxis
        private int measureX;
        private int measureY;
        //graphics object
        private Graphics g;
        private bool xDirection;
        /// <summary>
        /// property for the bool controlling which direction the user want to sort information in
        /// </summary>
        public bool DirectionX
        {
            get { return xDirection; }
            set { xDirection = value; }
        }      
        /// <summary>
        /// property that allow overlaying programs in structure acess to the scalepoints object
        /// </summary>
        public ScalePoints Scala
        {
            get { return scaler; }
        }
        /// <summary>
        /// Maxvalue for horisontal coordinates
        /// </summary>
        public int MaxX
        {
            get { return maxX; }
            set { maxX = value; }
        }
        /// <summary>
        /// Maximumvalue for vertical coordinates
        /// </summary>
        public int MaxY
        {
            get { return maxY; }
            set { maxY = value; }
        }
        /// <summary>
        /// Property for the list of points describing the coordinates in the diagram, for use of 
        /// overlaying classes. Namely the form class diagramgenerator and the function that registers the 
        /// mouse position when the user clicks in the diagram frame.
        /// </summary>
        public List<Point> Diagram
        {
            get { return diagramPoints; }
        }
        /// <summary>
        /// Property for similar use as the one above, meant to use by diagramgenerator class to add
        /// the coordinates to display whenever clicking is done in the diagramframe.
        /// </summary>
        public List<string> Display
        {
            get { return displaycoords; }
        }
        /// <summary>
        /// Class constructor initializing the variables needed for the class.
        /// </summary>
        public DrawDiagram(Graphics sentin)
        {
            g = sentin;
            diagramPoints = new List<Point>();
            displaycoords = new List<string>();
            myTextFormater = new WriteText(g);
            scaler = new ScalePoints();
            xDirection = true;
        }
        /// <summary>
        /// Public method that is called by the user interface in order to create the new diagram, the line placing methods as well as all of the 
        /// textdrawing methods from the WriteText class
        /// </summary>
        /// <param name="divisionX"></param>
        /// <param name="divisionY"></param>
        /// <param name="scaleX"></param>
        /// <param name="scaleY"></param>
        /// <param name="drawMe"></param>
        /// <param name="title"></param>
        public void CreateNewDidagram(string title, int divisionX, int divisionY, int scaleX, int scaleY, Panel drawMe)
        {
            myTextFormater.DrawTitle(title);// draws the title on the panel
            DrawOutFrame(drawMe);
            PlaceScaleMarkersX(divisionX, scaleX, drawMe);
            PlaceScaleMarkersY(divisionY, scaleY, drawMe);
            xDirection = true;
        }
        /// <summary>
        /// Draws out the lines that makes up the frame around the diagram
        /// </summary>
        /// <param name="pan"></param>
        private void DrawOutFrame(Panel pan)
        {
            Pen framePen = Pens.Red;
            g.DrawLine(framePen, new Point(30, 5), new Point(30, pan.Height - 30));
            g.DrawLine(framePen, new Point(30, pan.Height - 30), new Point(pan.Width-30, pan.Height - 30));
            scaler.Offsett = 30;// gives offsett value to the scale points object
        }
        /// <summary>
        /// Evenly divide the bottom of the frame of the diagram with small black lines based on the numbers of divisons
        /// </summary>
        /// <param name="scaleX"></param>
        /// <param name="divsionsX"></param>
        /// <param name="pan"></param>
        private void PlaceScaleMarkersX( int divsionsX, int scaleX, Panel pan)
        {
            List<Point> texthere = new List<Point>();
            int Y1 =pan.Height-30 ;// Top of line
            int y2 = pan.Height-25;//bottom of line           
            measureX = pan.Width - 60;//entire lenght of bottom frame
            scaler.DrawingSurfaceX = measureX+30;//now gives the whole measure including the offsett for the xaxis to provide a more accurate calculation
            int OrigX = 30;// start draw out divisions from here
            int xInterval = measureX/ divsionsX;//the distace between each digit
            Pen stroke = Pens.Black;
            //loop that calculates the xlocation and places the lines at the right positions on the 
            for(int i = 0; i < divsionsX; i++)
            {
                OrigX = OrigX + xInterval;
                Point start = new Point(OrigX,Y1);
                Point end = new Point(OrigX,y2);
                g.DrawLine(stroke, start, end);
                texthere.Add(end);
            }
            myTextFormater.DrawOutScaleX(divsionsX,scaleX,texthere);
        }
        /// <summary>
        /// Evenly divides the side of the frame surrounding the diagram based on the numbers of divisions given for y axis.
        /// </summary>
        /// <param name="divisionsY"></param>
        /// <param name="pan"></param>
        private void PlaceScaleMarkersY(int divisionsY,int scaleY, Panel pan)
        {
            List<Point> texthere = new List<Point>();
            int x1 = 30;
            int x2 = 25;
            measureY = pan.Height-35;
            scaler.DrawingSurfaceY = measureY+30;// same as with x measurement
            int yOrigin = pan.Height - 30;
            int Yinterval = measureY / divisionsY;
            //assigning and drawing loop
            for (int i = 0; i < divisionsY; i++)
            {
                yOrigin = yOrigin - Yinterval;
                Point start = new Point(x1, yOrigin);
                Point end = new Point(x2, yOrigin);
                Pen stroke = Pens.Black;
                g.DrawLine(stroke, start, end);
                texthere.Add(new Point(x2-20,yOrigin));
            }
            myTextFormater.DrawoutScaleY(divisionsY,scaleY,texthere);
        }
        /// <summary>
        /// Adds a new point to the list of points contained in the diagram and refreshes the diagramdrawing
        /// </summary>
        /// <param name="locX"></param>
        /// <param name="locY"></param>
        public void AddNewPoints(int locX, int locY, ListBox lstpoint, Panel pan, int divX,int divY, int scaleX,int scaleY, string name)
        {                       
            string strcoord = locX.ToString()+", "+locY.ToString();
            displaycoords.Add(strcoord);          
            int posX = scaler.PointCoordinateX(MaxX, locX);
            int posY = scaler.PointCooridnateY(MaxY, locY);
            Point diagram = new Point(posX,posY);
            diagramPoints.Add(diagram);           
            if (xDirection)
            {
                SortInXDir(lstpoint, pan, divX, divY, scaleX, scaleY, name);
            }
            else
            {
                SortInYDir(lstpoint, pan, divX, divY, scaleX, scaleY, name);
            }

        }
               
        /// <summary>
        /// Redraw diagram after the points have been rearanged depending on their Y value  
        /// </summary>
        public void SortInYDir(ListBox lstPoint, Panel pan, int divX,int divY,int scaleX,int scaleY,string name)
        {
            // rearanges the elements in the list after their value using linq
            List<Point> ydir = diagramPoints.OrderBy(p=>p.Y).ToList();     
            g.Clear(Color.White);
            myTextFormater.DrawTitle(name);
            DrawOutFrame(pan);
            PlaceScaleMarkersX(divX, scaleX, pan);
            PlaceScaleMarkersY(divY, scaleY, pan);
            RefreshUserInterface( lstPoint, ydir);
        }
        /// <summary>
        /// Redraw the points and lines after they are rearanged based on xvalue.
        /// </summary>
        /// <param name="can"></param>
        public void SortInXDir( ListBox lst, Panel pan, int divX, int divY,int scaleX,int scaleY,string name)
        {
            List<Point> xdir = diagramPoints.OrderBy(p => p.X).ToList();
            g.Clear(Color.White);
            myTextFormater.DrawTitle(name);
            DrawOutFrame(pan);
            PlaceScaleMarkersX(divX, scaleX, pan);
            PlaceScaleMarkersY(divY, scaleY, pan);
            RefreshUserInterface( lst, diagramPoints);
        }
        /// <summary>
        /// update the graphical interface, drawing lines between the points withing the diagram and then updating the listbox where all current points exists
        /// </summary>
        public void RefreshUserInterface(ListBox lstpoint, List<Point> mypoints)
        {
            Pen linePen = new Pen(Brushes.Red);
            linePen.DashStyle = DashStyle.Solid;
            linePen.Width = 2;
            if (mypoints.Count > 1)
            {
                g.DrawLines(linePen, mypoints.ToArray());
            }
            lstpoint.Items.Clear();// clear listbox
            //loop that assigns the items to the listbox
            foreach(string coord in displaycoords)
            {
                lstpoint.Items.Add(coord);
            }
            
        }
        /// <summary>
        /// method to clear the diagram removing all of the information in the list and erases both the panel and the 
        /// listbox associated with it.
        /// </summary>
        public void ClearDiagram(ListBox lst)
        {
            diagramPoints.Clear();
            displaycoords.Clear();
            lst.Items.Clear();
            g.Clear(Color.White);
        }
    }
}
