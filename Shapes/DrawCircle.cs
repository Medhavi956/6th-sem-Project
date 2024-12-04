using System;
using System.Drawing;
using Graphical_Programming_Language_App_Medhavi.Components;

namespace Graphical_Programming_Language_App_Medhavi.Shapes
{
    /// <summary>
    /// Represents a command to draw a circle on a Graphics surface.
    /// </summary>
    public class DrawCircle : Icommands
    {
        private string radius;
        private Graphics graphics;
        private int posX = GlobalConfiguration.xPoint;
        private int posY = GlobalConfiguration.yPoint;

        /// <summary>
        /// Initializes a new instance of the DrawCircle class.
        /// </summary>
        /// <param name="radius">The radius of the circle to be drawn.</param>
        /// <param name="graphics">The Graphics object used for drawing.</param>
        public DrawCircle(string radius, Graphics graphics)
        {
            this.radius = radius;
            this.graphics = graphics;

            Execute();
        }

        /// <summary>
        /// Executes the command to draw a circle.
        /// </summary>
        public void Execute()
        {
            try
            {
                if (!int.TryParse(radius, out int _radius))
                {
                    throw new ArgumentException("Invalid Radius Value. Please provide valid integer values for radius parameters.");
                }

                Pen pen = new Pen(GlobalConfiguration.penColor);
                SolidBrush brush = new SolidBrush(GlobalConfiguration.penColor);

                if (GlobalConfiguration.isFillOn)
                {
                    graphics.FillEllipse(brush, posX, posY, _radius, _radius);
                }
                else
                {
                    graphics.DrawEllipse(pen, posX, posY, _radius, _radius);
                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Invalid Parameter. Please provide valid integer values for circle parameters.", ex);
            }
        }
    }
}
