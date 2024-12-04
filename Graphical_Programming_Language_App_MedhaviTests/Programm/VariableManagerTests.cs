using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphical_Programming_Language_App_Medhavi.Programm;
using System;

namespace Graphical_Programming_Language_App_Medhavi.Tests
{
    [TestClass]
    public class VariableManagerTests
    {
        [TestMethod]
        public void AssignVariable_WhenValidIntegerValue_ShouldAssignToVariable()
        {
            // Arrange
            VariableManager variableManager = new VariableManager();

            // Act
            variableManager.AssignVariable("x = 5");

            // Assert
            Assert.AreEqual(5, variableManager.GetVariableValue("x"));
        }

        [TestMethod]
        public void AssignVariable_WhenValidExpression_ShouldEvaluateAndAssignToVariable()
        {
            // Arrange
            VariableManager variableManager = new VariableManager();
            variableManager.AssignVariable("a = 3");
            variableManager.AssignVariable("b = 7");

            // Act
            variableManager.AssignVariable("result = a + b");

            // Assert
            Assert.AreEqual(10, variableManager.GetVariableValue("result"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AssignVariable_WhenInvalidExpression_ShouldThrowException()
        {
            // Arrange
            VariableManager variableManager = new VariableManager();

            // Act
            variableManager.AssignVariable("invalid = x + y");

            // Assert
            // ArgumentException is expected, so no additional assertions needed.
        }

        [TestMethod]
        public void GetVariableValue_WhenVariableExists_ShouldReturnVariableValue()
        {
            // Arrange
            VariableManager variableManager = new VariableManager();
            variableManager.AssignVariable("y = 42");

            // Act
            int result = variableManager.GetVariableValue("y");

            // Assert
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void GetVariableValue_WhenVariableDoesNotExist_ShouldReturnZero()
        {
            // Arrange
            VariableManager variableManager = new VariableManager();

            // Act
            int result = variableManager.GetVariableValue("nonexistent");

            // Assert
            Assert.AreEqual(0, result);
        }

        // Add more test methods as needed.
    }
}
