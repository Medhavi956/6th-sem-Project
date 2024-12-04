using System;
using System.Drawing;
using Graphical_Programming_Language_App_Medhavi.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graphical_Programming_Language_App_Medhavi.Basic_Commands.Tests
{
    /// <summary>
    /// Test class for the ColorHandler class.
    /// </summary>
    [TestClass()]
    public class ColorHandlerTests
    {
        /// <summary>
        /// Test method for handling an invalid color input.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void Color_Invalid_test()
        {
            //Arrange

            //Act
            string invalidColor = "Invalid";
            new ColorHandler(invalidColor);
        }

        /// <summary>
        /// Test method for handling a valid color input.
        /// </summary>
        [TestMethod()]
        public void Valid_Color_Test()
        {
            //Arrange
            string validColor = "red";
            Color expectedColor = Color.Red;

            //Act
            new ColorHandler(validColor);
            Color actualColor = GlobalConfiguration.penColor;

            //Assert
            Assert.AreEqual(expectedColor, actualColor);
        }
    }
}
