using System;
using System.Drawing;
using Graphical_Programming_Language_App_Medhavi.Components;

namespace Graphical_Programming_Language_App_Medhavi.Shapes
{
    /// <summary>
    /// Represents a command to draw a triangle on a Graphics surface.
    /// </summary>
    public class DrawTriangle : Icommands
    {
        private string _sideX;
        private Graphics g;

        /// <summary>
        /// Initializes a new instance of the DrawTriangle class.
        /// </summary>
        /// <param name="sideX">The length of the sides of the triangle.</param>
        /// <param name="graphics">The Graphics object used for drawing.</param>
        public DrawTriangle(string sideX, Graphics graphics)
        {
            _sideX = sideX;
            this.g = graphics;
            Execute();
        }

        /// <summary>
        /// Executes the command to draw a triangle.
        /// </summary>
        public void Execute()
        {
            try
            {
                if (!int.TryParse(_sideX, out int sideX))
                {
                    throw new ArgumentException("Invalid length Value. Please provide valid integer values for length of triangle parameters.");
                }

                int centerX = (int)(g.VisibleClipBounds.Width / 2);
                int centerY = (int)g.VisibleClipBounds.Height / 2;
                int halfLengthX = sideX / 2;
                int height = (int)(Math.Sqrt(3) / 2 * sideX);

                Point[] points = new Point[]
                {
                    new Point(centerX, centerY - height / 2),
                    new Point(centerX - halfLengthX, centerY + height / 2),
                    new Point(centerX + halfLengthX, centerY + height / 2)
                };

                Pen pen = new Pen(GlobalConfiguration.penColor);
                SolidBrush brush = new SolidBrush(GlobalConfiguration.penColor);

                if (GlobalConfiguration.isFillOn)
                {
                    g.FillPolygon(brush, points);
                }
                else
                {
                    g.DrawPolygon(pen, points);
                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Invalid length Value. Please provide valid integer values for length of triangle parameters.", ex);
            }
        }
    }
}
