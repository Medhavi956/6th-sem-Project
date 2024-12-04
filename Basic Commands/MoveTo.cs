using System;
using System.Drawing;
using Graphical_Programming_Language_App_Medhavi.Components;

namespace Graphical_Programming_Language_App_Medhavi.Basic_Commands
{
    /// <summary>
    /// Represents a class that handles moving the drawing position to a specified point.
    /// </summary>
    public class MoveTo : Icommands
    {
        private Graphics g;
        private Font font;
        private Brush brush;
        private string indicatorSymbol = "*";
        private string x, y;

        /// <summary>
        /// Initializes a new instance of the MoveTo class with the specified coordinates and graphics object.
        /// </summary>
        /// <param name="x">The x-coordinate of the new drawing position.</param>
        /// <param name="y">The y-coordinate of the new drawing position.</param>
        /// <param name="g">The Graphics object to draw on.</param>
        public MoveTo(string x, string y, Graphics g)
        {
            this.g = g;
            this.x = x;
            this.y = y;

            font = new Font("Arial", 12);
            brush = new SolidBrush(Color.Black);

            Execute();
        }

        /// <summary>
        /// Moves the drawing position to the specified coordinates.
        /// </summary>
        public void Execute()
        {
            if (!int.TryParse(x, out int _xPoint) || !int.TryParse(y, out int _yPoint))
            {
                throw new ArgumentException("Invalid Value. Please provide valid integer values for moveTo parameters.");
            }

            GlobalConfiguration.xPoint = _xPoint;
            GlobalConfiguration.yPoint = _yPoint;

            Point newStartPoint = new Point(GlobalConfiguration.xPoint, GlobalConfiguration.yPoint);

        }
    }
}
