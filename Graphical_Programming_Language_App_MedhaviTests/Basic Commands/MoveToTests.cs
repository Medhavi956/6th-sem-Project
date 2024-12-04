using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphical_Programming_Language_App_Medhavi.Basic_Commands;
using System.Drawing;
using System;

namespace Graphical_Programming_Language_App_Medhavi.Basic_Commands.Tests
{
    /// <summary>
    /// Test class for the MoveTo class.
    /// </summary>
    [TestClass()]
    public class MoveToTests
    {
        Form1 form = new Form1(); // Assuming Form1 is your form where you get the Graphics object from a panel

        /// <summary>
        /// Test method for MoveTo with both invalid parameters.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void Moveto_Test_with_both_invalid_parameter()
        {
            Graphics g = form.getPanel(); // Get the Graphics object from the form's panel

            string side1 = "invalid";
            string side2 = "invalid";

            new MoveTo(side1, side2, g); // Attempt to create a new MoveTo object with invalid parameters
        }

        /// <summary>
        /// Test method for MoveTo with one valid and one invalid parameter.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void Moveto_Test_with_one_Valid_parameter()
        {
            Graphics g = form.getPanel(); // Get the Graphics object from the form's panel

            string side1 = "invalid";
            string side2 = "100";

            new MoveTo(side1, side2, g); // Attempt to create a new MoveTo object with one invalid parameter
        }
    }
}
