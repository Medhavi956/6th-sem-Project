using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphical_Programming_Language_App_Medhavi.Basic_Commands;
using System;
using System.Drawing;

namespace Graphical_Programming_Language_App_Medhavi.Basic_Commands.Tests
{
    /// <summary>
    /// Test class for the DrawLine class.
    /// </summary>
    [TestClass()]
    public class DrawLineTests
    {
        Form1 form = new Form1(); // Assuming Form1 is your form where you get the Graphics object from a panel

        /// <summary>
        /// Test method for drawing a line with both invalid parameters.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void Draw_Line_Test_with_both_invalid_parameter()
        {
            Graphics g = form.getPanel(); // Get the Graphics object from the form's panel

            string side1 = "invalid";
            string side2 = "invalid";

            new DrawLine(side1, side2, g); // Attempt to create a new DrawLine object with invalid parameters
        }

        /// <summary>
        /// Test method for drawing a line with one invalid parameter.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void Draw_Line_Test_with_one_invalid_parameter()
        {
            Graphics g = form.getPanel(); // Get the Graphics object from the form's panel

            string side1 = "100";
            string side2 = "invalid";

            new DrawLine(side1, side2, g); // Attempt to create a new DrawLine object with one invalid parameter
        }
    }
}
