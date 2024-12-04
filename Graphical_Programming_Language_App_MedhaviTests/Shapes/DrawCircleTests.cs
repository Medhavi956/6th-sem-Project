using System;
using System.Drawing;
using Graphical_Programming_Language_App_Medhavi.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Graphical_Programming_Language_App_Medhavi.Shapes.Tests
{
    /// <summary>
    /// Test class for the DrawCircle class.
    /// </summary>
    [TestClass()]
    public class DrawCircleTests
    {
        Form1 form = new Form1();
        /// <summary>
        /// Test method to validate handling an invalid circle parameter.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void Invalid_Circle_parameter_test()
        {
            // Arrange
            Graphics g = form.getPanel();
            string invalidRadius = "i";

            // Act
            new DrawCircle(invalidRadius, g);
        }

        /// <summary>
        /// Test method to verify if a circle is drawn with valid radius and parameters.
        /// </summary>
      //  [TestMethod()]
        public void DrawCircle_ValidRadius_CircleDrawn()
        {
            // Arrange
            Graphics g = form.getPanel();

            // Set valid configuration values
            GlobalConfiguration.penColor = Color.Black;
            GlobalConfiguration.isFillOn = true;
            GlobalConfiguration.xPoint = 100;
            GlobalConfiguration.yPoint = 100;

            // Set a valid radius
            string validRadius = "50";

            // Act
            DrawCircle drawCircle = new DrawCircle(validRadius, g);
            // Assert: 
            Mock.Get(g).Verify(x => x.FillEllipse(It.IsAny<Brush>(), 100, 100, 50, 50), Times.Once);
        }
    }
}
