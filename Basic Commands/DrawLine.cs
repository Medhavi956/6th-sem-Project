using System;
using System.Drawing;
using Graphical_Programming_Language_App_Medhavi.Components;

namespace Graphical_Programming_Language_App_Medhavi.Basic_Commands
{
    /// <summary>
    /// Represents a class containing the DrawLine method.
    /// </summary>
    public class DrawLine : Icommands
    {
        private int posX = GlobalConfiguration.xPoint;
        private int posY = GlobalConfiguration.yPoint;
        private Graphics g;
        private string endX;
        private string endY;

        /// <summary>
        /// Initializes a new instance of the DrawLine class.
        /// </summary>
        /// <param name="endX">The X-coordinate for the end point.</param>
        /// <param name="endY">The Y-coordinate for the end point.</param>
        /// <param name="g">The Graphics object used for drawing.</param>
        public DrawLine(string endX, string endY, Graphics g)
        {
            this.g = g;
            this.endX = endX;
            this.endY = endY;
            Execute();
        }

        /// <summary>
        /// Executes the DrawLine command based on provided coordinates and Graphics object.
        /// </summary>
        public void Execute()
        {
            if (!int.TryParse(endX, out int _xPoint) || !int.TryParse(endY, out int _yPoint))
            {
                throw new ArgumentException("Invalid Value. Please provide valid integer values for end coordinates.");
            }

            Pen pen = new Pen(GlobalConfiguration.penColor);
            g.DrawLine(pen, posX, posY, _xPoint, _yPoint);
        }
    }
}
