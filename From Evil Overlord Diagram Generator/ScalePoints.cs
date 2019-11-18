using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund
namespace DrawingAndDiagramUtility
{
    /// <summary>
    /// This script is here to handle the scaling of points  it contains properties for drawing surface the offset values
    /// as well as 
    /// </summary>
    public class ScalePoints
    {
        //instance variables
        private int xOffsett;
        private int drawingSurfaceX;
        private int drawingSurfaceY;              
        //Class properties
        /// <summary>
        /// property for the offsett of the for the drawing surface(it is the same in both direction)
        /// </summary>
        public int Offsett
        {
            get { return xOffsett; }
            set { xOffsett = value; }
        }
       
        /// <summary>
        /// Property for the drawing surfaces length(in pixels) 
        /// </summary>
        public int DrawingSurfaceX
        {
            get { return drawingSurfaceX; }
            set { drawingSurfaceX = value; }
        }
        /// <summary>
        /// property for the Drawing surfaces legnth in ydirection
        /// </summary>
        public int DrawingSurfaceY
        {
            get { return drawingSurfaceY; }
            set { drawingSurfaceY = value; }
        }
       
        /// <summary>
        /// calculate the postion of the point in xdirection
        /// </summary>
        /// <returns></returns>
        public int PointCoordinateX(int MaxX, int locX)
        {
            //reference solution
            // pOut.X = (int)(p.X * (fDta.W - fDta.AxisMax.X) / (float)(fDta.Xint * fDta.Xvals));
            float exactCoord = (locX * drawingSurfaceX / MaxX)+60;
            int coordinate = (int)exactCoord-Offsett; 
            return coordinate;
        }
        /// <summary>
        /// Calculate the Yposition of the point.
        /// </summary>
        /// <returns></returns>
        public int PointCooridnateY(int maxY, int locY)
        {
            int exactCoord = DrawingSurfaceY - (locY * (DrawingSurfaceY)/maxY)-Offsett;
            int coordinate = exactCoord+5;
            return coordinate;
        }
        /// <summary>
        /// translates the pixels from where the mouse is pointing on the canvas this function is specifically for 
        /// mouse point placements. FloatX being the position read in from where the mouse clicked.
        /// </summary>
        /// <returns></returns>
        //public int PixelXToInt(int mouseLocX, int maxX)
        //{           
        //    int coord = (mouseLocX-Offsett)*maxX/DrawingSurfaceX;
        //    return coord;
        //}
        /// <summary>
        /// Translate the Y location for the mouse position to a location relative to diagram
        /// </summary>
        /// <param name="mouseLocY"></param>
        /// <returns></returns>
        //public int PixelYToInt(int mouseLocY, int maxY)
        //{
        //    int leftover = drawingSurfaceY -(mouseLocY+ Offsett);// gets the coordinate when coming down from the upper left corener
        //    int coord = (DrawingSurfaceY-leftover)-(leftover*maxY/drawingSurfaceY);
        //    return coord;
        //}

        
    }
}
