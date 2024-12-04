using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graphical_Programming_Language_App_Medhavi.Shapes.Tests
{
    /// <summary>
    /// Test class for the DrawTriangle class.
    /// </summary>
    [TestClass()]
    public class DrawTriangleTests
    {
        Form1 form = new Form1(); // Assuming Form1 is your form where you get the Graphics object from a panel

        /// <summary>
        /// Test method to validate handling invalid parameters when creating a DrawTriangle object.
        /// </summary>
        /// <remarks>
        /// This test attempts to create a DrawTriangle object with an invalid side length,
        /// expecting an ArgumentException to be thrown as the side length provided is invalid for a triangle.
        /// </remarks>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void Invalid_Parameter_DrawTriangleTest()
        {
            // Arrange
            Graphics g = form.getPanel(); // Get the Graphics object from the form's panel
            string invalidRadius = "i"; // This should be an invalid value for a triangle side

            // Act
            new DrawCircle(invalidRadius, g); // Attempt to create a new DrawCircle object with an invalid radius
        }
    }
}
