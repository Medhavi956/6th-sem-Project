using System;
using System.Drawing;

namespace Graphical_Programming_Language_App_Medhavi.Components
{
    /// <summary>
    /// Represents a command to draw a rectangle on a Graphics surface.
    /// </summary>
    public class DrawRectangle : Icommands
    {
        private int posX = GlobalConfiguration.xPoint;
        private int posY = GlobalConfiguration.yPoint;
        private string width;
        private string height;
        private Graphics g;

        /// <summary>
        /// Initializes a new instance of the DrawRectangle class.
        /// </summary>
        /// <param name="width">The width of the rectangle to be drawn.</param>
        /// <param name="height">The height of the rectangle to be drawn.</param>
        /// <param name="g">The Graphics object used for drawing.</param>
        public DrawRectangle(string width, string height, Graphics g)
        {
            this.width = width;
            this.height = height;
            this.g = g;

            Execute();
        }

        /// <summary>
        /// Executes the command to draw a rectangle.
        /// </summary>
        public void Execute()
        {
            try
            {
                if (!int.TryParse(width, out int _width) || !int.TryParse(height, out int _height))
                {
                    throw new ArgumentException("Invalid parameter. Please provide valid integer values for rectangle parameters.");
                }

                Pen pen = new Pen(GlobalConfiguration.penColor);
                SolidBrush brush = new SolidBrush(GlobalConfiguration.penColor);

                if (GlobalConfiguration.isFillOn)
                {
                    g.FillRectangle(brush, posX, posY, _width, _height);
                }
                else
                {
                    g.DrawRectangle(pen, posX, posY, _width, _height);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid Parameter. Please provide valid integer values for rectangle parameters.", ex);
            }
        }
    }
}
