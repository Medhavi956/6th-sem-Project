using System;
using System.Drawing;
using Graphical_Programming_Language_App_Medhavi.Basic_Commands;
using Graphical_Programming_Language_App_Medhavi.Shapes;

namespace Graphical_Programming_Language_App_Medhavi.Components
{

    /// <summary>
    /// Parses commands and executes corresponding actions related to drawing shapes or changing settings.
    /// </summary>
    public class CommandParser
    {
        private string[] commands;
        private Graphics graphics;

        /// <summary>
        /// Initializes a new instance of the CommandParser class with provided commands and graphics object.
        /// </summary>
        /// <param name="commands">The command string to be parsed.</param>
        /// <param name="g">The Graphics object used for drawing shapes.</param>
        public CommandParser(string commands, Graphics g)
        {
            this.commands = commands.Trim().Split(' ');
            this.graphics = g;
            classCaller();
        }

        /// <summary>
        /// Calls the appropriate class based on the parsed command.
        /// </summary>
        private void classCaller()
        {
            if (commands[0].ToLower() == "moveto" && commands.Length <= 3)
            {
                string[] value = commands[1].Trim().Split(',');
                new MoveTo(value[0], value[1], graphics);
            }

            else if (commands[0].ToLower() == "drawto" && commands.Length <= 3)
            {
                string[] value = commands[1].Trim().Split(',');
                new DrawLine(value[0], value[1], graphics);
            }

            else if (commands[0].ToLower() == "fill" && commands.Length <= 2)
            {
                new Filled(commands[1]);
            }

            else if (commands[0].ToLower() == "color" && commands.Length <= 2)
            {
                new ColorHandler(commands[1]);
            }
            else if (commands[0].ToLower() == "rectangle" && commands.Length <= 3)
            {
                string[] value = commands[1].Trim().Split(',');
                new DrawRectangle(value[0], value[1], graphics);
            }
            else if (commands[0].ToLower() == "circle" && commands.Length <= 2)
            {
                new DrawCircle(commands[1], graphics);
            }

            else if (commands[0].ToLower() == "triangle" && commands.Length <= 2)
            {
                new DrawTriangle(commands[1], graphics);
            }            
            else
            {
                throw new ArgumentException("Invalid Command ! please Enter the correct command");
            }


        }


    }


}
