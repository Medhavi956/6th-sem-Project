using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphical_Programming_Language_App_Medhavi.Components;
using System.Drawing;
using System;

namespace Graphical_Programming_Language_App_Medhavi.Components.Tests
{
    /// <summary>
    /// Test class for the ProgramHandler class.
    /// </summary>
    [TestClass()]
    public class ProgramHandlerTests
    {
        Form1 form = new Form1(); // Assuming Form1 is your form where you get the Graphics object from a panel

        /// <summary>
        /// Test method for handling an invalid command.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void ProgramHandler_Invalid__Calls()
        {
            Graphics g = form.getPanel(); // Get the Graphics object from the form's panel
            string command = "Invalid command";

            ProgramHandler program = new ProgramHandler(g);
            program.Execute(command); // Attempt to execute an invalid command
        }

        /// <summary>
        /// Test method for handling a valid "moveto" command with invalid parameters.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void ProgramHandler_ValidMoveToCommand_Withinvalid_pram()
        {
            Graphics g = form.getPanel(); // Get the Graphics object from the form's panel
            string command = "moveto invalid,invalid";

            ProgramHandler program = new ProgramHandler(g);
            program.Execute(command); // Attempt to execute a "moveto" command with invalid parameters
        }

        /// <summary>
        /// Test method for handling a valid "moveto" command with valid parameters.
        /// </summary>
        [TestMethod()]
        public void ProgramHandler_ValidMoveToCommand_WithValid_pram()
        {
            Graphics g = form.getPanel(); // Get the Graphics object from the form's panel
            string command = "moveto 100,100";

            // Act
            int expectedX = 100;
            int expectedY = 100;

            ProgramHandler program = new ProgramHandler(g);
            program.Execute(command); // Execute a "moveto" command with valid parameters

            // Assert
            int actualX = GlobalConfiguration.xPoint;
            int actualY = GlobalConfiguration.yPoint;

            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);
        }
    }
}
