using System;
using System.Drawing;
using Graphical_Programming_Language_App_Medhavi.Components;

namespace Graphical_Programming_Language_App_Medhavi.Basic_Commands
{
    /// <summary>
    /// Represents a class that handles setting the drawing pen color.
    /// </summary>
    public class ColorHandler : Icommands
    {
        private string _color;

        /// <summary>
        /// Initializes a new instance of the ColorHandler class with the specified color.
        /// </summary>
        /// <param name="color">The color value to set.</param>
        public ColorHandler(string color)
        {
            _color = color;
            Execute();
        }

        /// <summary>
        /// Executes the ColorHandler command to set the pen color.
        /// </summary>
        public void Execute()
        {
            switch (_color)
            {
                case "black":
                    GlobalConfiguration.penColor = Color.Black;
                    break;
                case "red":
                    GlobalConfiguration.penColor = Color.Red;
                    break;
                case "blue":
                    GlobalConfiguration.penColor = Color.Blue;
                    break;
                case "green":
                    GlobalConfiguration.penColor = Color.Green;
                    break;
                case "yellow":
                    GlobalConfiguration.penColor = Color.Yellow;
                    break;
                case "orange":
                    GlobalConfiguration.penColor = Color.Orange;
                    break;
                case "lime":
                    GlobalConfiguration.penColor = Color.LightGreen;
                    break;
                case "coral":
                    GlobalConfiguration.penColor = Color.Coral;
                    break;
                case "white":
                    GlobalConfiguration.penColor = Color.White;
                    break;
                default:
                    throw new ArgumentException("Invalid color. Please enter the correct Color.");
            }
        }
    }
}
