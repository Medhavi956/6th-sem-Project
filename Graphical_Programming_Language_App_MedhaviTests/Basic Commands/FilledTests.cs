using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphical_Programming_Language_App_Medhavi.Basic_Commands;
using System;
using System.Drawing;
using Graphical_Programming_Language_App_Medhavi.Components;

namespace Graphical_Programming_Language_App_Medhavi.Basic_Commands.Tests
{
    /// <summary>
    /// Test class for the Filled class.
    /// </summary>
    [TestClass()]
    public class FilledTests
    {
        /// <summary>
        /// Test method for handling an invalid command input.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The expected exception was not thrown")]
        public void Filled_Invalid_command_test()
        {
            //Act
            string invalidCommand = "Invalid";
            new Filled(invalidCommand); // Attempt to create a new Filled object with an invalid command
        }

        /// <summary>
        /// Test method for handling a valid "off" command input.
        /// </summary>
        [TestMethod()]
        public void Filled_Valid_commandOff_test()
        {
            //Arrange
            string validCommand = "off";
            bool expectedValue = false;

            //Act
            new Filled(validCommand); // Create a new Filled object with "off" command
            bool actualValue = GlobalConfiguration.isFillOn;

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        /// <summary>
        /// Test method for handling a valid "on" command input.
        /// </summary>
        [TestMethod()]
        public void Filled_Valid_commandOn_test()
        {
            //Arrange
            string validCommand = "on";
            bool expectedValue = true;

            //Act
            new Filled(validCommand); // Create a new Filled object with "on" command
            bool actualValue = GlobalConfiguration.isFillOn;

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
