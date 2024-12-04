using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graphical_Programming_Language_App_Medhavi.Components.Tests
{
    /// <summary>
    /// Test class for the DrawRectangle class.
    /// </summary>
    [TestClass()]
    public class DrawRectangleTests
    {
        Form1 form = new Form1();

        /// <summary>
        /// Test method to validate handling both invalid width and height parameters.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void Draw_Rectangle_Test_with_both_invalid_parameter()
        {
            Graphics g = form.getPanel();

            string invalidWidth = "invalid";
            string invalidHeight = "invalid";

            new DrawRectangle(invalidWidth, invalidHeight, g);
        }

        /// <summary>
        /// Test method to validate handling one valid and one invalid parameter.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void Draw_Rectangle_Test_with_one_valid_parameter()
        {
            Graphics g = form.getPanel();

            string invalidWidth = "invalid";
            string invalidHeight = "100";

            new DrawRectangle(invalidWidth, invalidHeight, g);
        }

        /// <summary>
        /// Test method for handling both valid width and height parameters.
        /// </summary>
        //[TestMethod()]
        public void Rectangle_test_with_Both_Valid_Parameter()
        {
            // Add your test logic for handling valid width and height parameters
        }
    }
}
