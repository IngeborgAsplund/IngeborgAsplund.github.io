using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
//By Ingeborg Asplund
namespace DrawingAndDiagramUtility
{
    
    /// <summary>
    /// This class contains classes that draws text to place on the canvas, it make use of input parameters sent from the gui
    /// to decide what text to draw format and place.
    /// </summary>
    public class WriteText
    {
        Graphics g;
        /// <summary>
        /// Constructor that defines the graphics object to draw text with
        /// </summary>
        public WriteText(Graphics g)
        {
            this.g = g;
        }
        /// <summary>
        /// Draws an input string as the title of the diagram on a sent in canvasobject. The method handles formating, pens/brushes
        /// font and sizing of the text as well as the initial placements
        /// </summary>
        /// <param name="title"></param>
        /// <param name="can"></param>
        public void DrawTitle(string title)
        {          
            Brush titleBrush = Brushes.Red;
            Font titlefont= new Font("Times New Roman",14f);
            g.DrawString(title, titlefont, titleBrush, new Point(60, 40));
        }
        /// <summary>
        /// Method that creates a list of numbers to display and format based on scale and the numbers of divisions.
        /// </summary>
        /// <param name="divisionsx"></param>
        /// <param name="scaleX"></param>
        public void DrawOutScaleX(int divisionsx, int scaleX,List<Point> xlocations)
        {            
            int origin = 0;
            Font coordfont = new Font("Arial", 8);
            Brush coordbrush = Brushes.Black;
            //loop that quicly calculates a specific coordinates value and places them in the diagram image based
            // on point locations sent in by the caller class
            for(int i = 0; i < divisionsx; i ++)
            {
                origin = origin + scaleX;
                g.DrawString(origin.ToString(), coordfont, coordbrush, xlocations[i]);// places my scale metrics in the exact right spots.
            }
          

        }
        /// <summary>
        /// Method that creates a list of numbers to display and format based on scale and the numbers of divisions.
        /// </summary>
        public void DrawoutScaleY(int divisionY,int ScaleY, List<Point> Ylocations)
        {
            int origin = 0;
            Font coordfont = new Font("Arial", 8);
            Brush coordbrush = Brushes.Black;
            //loop that calculates and draws out values for the Y axis based on scale, divison and location values sent into the method
            for(int i = 0; i < divisionY; i++)
            {
                origin = origin + ScaleY;
                g.DrawString(origin.ToString(), coordfont, coordbrush, Ylocations[i]);
            }
        }
    }
}
