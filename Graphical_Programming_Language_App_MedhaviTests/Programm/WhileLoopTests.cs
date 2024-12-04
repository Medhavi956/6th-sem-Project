using Graphical_Programming_Language_App_Medhavi.Programm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Graphical_Programming_Language_App_Medhavi.Tests
{
    [TestClass]
    public class WhileLoopTests
    {
      //  [TestMethod]
        public void Execute_WhenValidCondition_ShouldExecuteWhileLoop()
        {
            // Arrange
            VariableManager variableManager = new VariableManager();
            variableManager.AssignVariable("i = 0");
            Graphics graphics = null; // Replace with a mock or real Graphics object if needed
            List<string> executedCommands = new List<string>();
            Action<string> executeMethod = (s) => executedCommands.Add(s);
            WhileLoop whileLoop = new WhileLoop(new string[] { "command1", "command2", "command3", "endloop" }, "i < 5", 0, variableManager, graphics, executeMethod);

            // Act
            whileLoop.Execute();

            // Assert
            CollectionAssert.AreEqual(new string[] { "command1", "command2", "command3" }, executedCommands);
            Assert.AreEqual(5, variableManager.GetVariableValue("i"));
        }

     //   [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Execute_WhenInvalidCondition_ShouldThrowException()
        {
            // Arrange
            VariableManager variableManager = new VariableManager();
            Graphics graphics = null; // Replace with a mock or real Graphics object if needed
            Action<string> executeMethod = (s) => { /* Mock execution method */ };
            WhileLoop whileLoop = new WhileLoop(new string[] { "command1", "command2", "command3", "endloop" }, "invalidCondition", 0, variableManager, graphics, executeMethod);

            // Act
            whileLoop.Execute();

            // Assert
            // ArgumentException is expected, so no additional assertions needed.
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Execute_WhenErrorInLoopExecution_ShouldThrowException()
        {
            // Arrange
            VariableManager variableManager = new VariableManager();
            variableManager.AssignVariable("i = 0");
            Graphics graphics = null; // Replace with a mock or real Graphics object if needed
            Action<string> executeMethod = (s) => throw new ArgumentException("Error in loop execution");
            WhileLoop whileLoop = new WhileLoop(new string[] { "command1", "command2", "command3", "endloop" }, "i < 5", 0, variableManager, graphics, executeMethod);

            // Act
            whileLoop.Execute();

            // Assert
            // ArgumentException is expected, so no additional assertions needed.
        }

        // Add more test methods as needed.
    }
}
