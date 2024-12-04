using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graphical_Programming_Language_App_Medhavi.Programm.Tests
{
    [TestClass]
    public class MethodManagerTests
    {
        [TestMethod]
        public void AssignMethod_WhenValidMethod_ShouldAddToMethodsDictionary()
        {
            // Arrange
            MethodManager methodManager = new MethodManager();
            string[] commands = { "command1", "command2", "endmethod" };
            int currentIndex = 0;

            // Act
            methodManager.AssignMethod("methodName {param1, param2}", commands, currentIndex);

            // Assert
            Assert.IsTrue(methodManager.checkMethod("methodName"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AssignMethod_WhenInvalidMethod_ShouldThrowException()
        {
            // Arrange
            MethodManager methodManager = new MethodManager();
            string[] commands = { "command1", "command2", "endmethod" };
            int currentIndex = 0;

            // Act
            methodManager.AssignMethod("invalidMethod", commands, currentIndex);

            // Assert
            // ArgumentException is expected, so no additional assertions needed.
        }

        [TestMethod]
        public void getMethodValue_WhenValidMethodLine_ShouldReturnMethodCommands()
        {
            // Arrange
            MethodManager methodManager = new MethodManager();
            string[] commands = { "command1", "command2", "endmethod" };
            int currentIndex = 0;
            methodManager.AssignMethod("methodName {param1,param2}", commands, currentIndex);

            // Act
            string methodValue = methodManager.getMethodValue("methodName {5,10}");

            // Assert
            Assert.AreEqual("command1\ncommand2", methodValue.Trim());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void getMethodValue_WhenInvalidMethodLine_ShouldThrowException()
        {
            // Arrange
            MethodManager methodManager = new MethodManager();
            string[] commands = { "command1", "command2", "endmethod" };
            int currentIndex = 0;
            methodManager.AssignMethod("methodName {param1, param2}", commands, currentIndex);

            // Act
            string methodValue = methodManager.getMethodValue("invalidMethodName (5,10)");

            // Assert
            // ArgumentException is expected, so no additional assertions needed.
        }

        // Add more test methods as needed.
    }
}
