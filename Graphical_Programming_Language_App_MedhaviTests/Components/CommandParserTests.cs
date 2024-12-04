using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphical_Programming_Language_App_Medhavi.Components;
using System.Drawing;
using System;

namespace Graphical_Programming_Language_App_Medhavi.Components.Tests
{
    /// <summary>
    /// Test class for the CommandParser class.
    /// </summary>
    [TestClass()]
    public class CommandParserTests
    {
        Form1 form = new Form1(); // Assuming Form1 is your form where you get the Graphics object from a panel

        /// <summary>
        /// Test method for handling an invalid command.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void CommandParser_Invalid__Calls()
        {
            Graphics g = form.getPanel(); // Get the Graphics object from the form's panel
            string command = "Invalid_command";

            new CommandParser(command, g); // Attempt to create a new CommandParser object with an invalid command
        }

        /// <summary>
        /// Test method for handling a valid "moveto" command with invalid parameters.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void CommandParser_ValidMoveToCommand_Withinvalid_pram()
        {
            Graphics g = form.getPanel(); // Get the Graphics object from the form's panel
            string command = "moveto invalid,invalid";

            new CommandParser(command, g); // Attempt to create a new CommandParser object with a "moveto" command and invalid parameters
        }

        /// <summary>
        /// Test method for handling a valid "moveto" command with valid parameters.
        /// </summary>
        [TestMethod()]
        public void CommandParser_ValidMoveToCommand_WithValid_pram()
        {
            Graphics g = form.getPanel(); // Get the Graphics object from the form's panel
            string command = "moveto 100,100";

            // Act
            int expectedX = 100;
            int expectedY = 100;

            new CommandParser(command, g); // Create a new CommandParser object with a valid "moveto" command and valid parameters

            // Assert
            int actualX = GlobalConfiguration.xPoint;
            int actualY = GlobalConfiguration.yPoint;

            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);
        }
    }
}
