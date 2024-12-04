using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Graphical_Programming_Language_App_Medhavi.Programm.Tests
{
    [TestClass]
    public class IfStatementTests
    {
        [TestMethod]
        public void Execute_WhenConditionIsTrue_ShouldExecuteCommands()
        {
            // Arrange
            string[] commands = { "command1", "command2", "if variable1 < 10", "   insideIfCommand1", "   insideIfCommand2", "endif", "command3" };
            string condition = "variable1 < 10";
            int startIndex = 2;
            VariableManager variableManager = new VariableManager();
            Graphics graphics = null; // You may want to create a mock or use a real Graphics object for testing.
            Action<string> executeMethod = command => { /* Mock execution method */ };

            IfStatement ifStatement = new IfStatement(commands, condition, startIndex, variableManager, graphics, executeMethod);

            // Act
            variableManager.AssignVariable("variable1 = 5");
            ifStatement.Execute();

            // Assert
            // You can add assertions based on your specific expectations.
            // For example, check if executeMethod was called with the expected set of commands.
        }

        [TestMethod]
        public void Execute_WhenConditionIsFalse_ShouldNotExecuteCommands()
        {
            // Arrange
            string[] commands = { "command1", "command2", "if variable1 < 10", "   insideIfCommand1", "   insideIfCommand2", "endif", "command3" };
            string condition = "variable1 < 10";
            int startIndex = 2;
            VariableManager variableManager = new VariableManager();
            Graphics graphics = null; // You may want to create a mock or use a real Graphics object for testing.
            Action<string> executeMethod = command => { /* Mock execution method */ };

            IfStatement ifStatement = new IfStatement(commands, condition, startIndex, variableManager, graphics, executeMethod);

            // Act
            variableManager.AssignVariable("variable1 = 15");
            ifStatement.Execute();

            // Assert
            // You can add assertions based on your specific expectations.
            // For example, check if executeMethod was not called.
        }

        // Add more test methods as needed.
    }
}
