using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Graphical_Programming_Language_App_Medhavi.Components;

namespace Graphical_Programming_Language_App_Medhavi.Programm
{
    /// <summary>
    /// Represents an implementation of the conditional if statement in a graphical programming language.
    /// </summary>
    public class IfStatement : Icommands
    {
        private string condition;
        private string[] commands;
        private int currentIndex, returnIndex;
        private VariableManager variable;
        private Graphics g;
        private Action<string> executeMethod;

        /// <summary>
        /// Initializes a new instance of the <see cref="IfStatement"/> class.
        /// </summary>
        /// <param name="commands">The array of commands associated with the if statement.</param>
        /// <param name="condition">The condition to be evaluated for the if statement.</param>
        /// <param name="startIndex">The starting index of the if statement within the program.</param>
        /// <param name="variable">The variable manager for managing variables.</param>
        /// <param name="g">The Graphics object for drawing operations.</param>
        /// <param name="executeMethod">The method for executing commands.</param>

        public IfStatement(string[] commands, string condition, int startIndex, VariableManager variable, Graphics g, Action<string> executeMethod)
        {
            this.commands = commands;
            this.condition = condition;
            this.currentIndex = startIndex;
            this.variable = variable;
            this.g = g;
            this.executeMethod = executeMethod;
        }

        /// <summary>
        /// Executes the if statement based on the specified condition and commands.
        /// </summary>

        public void Execute()
        {
            string[] conditionParts = condition.Split(' ');

            if (conditionParts.Length == 3)
            {
                try
                {
                    string variableName = conditionParts[0].Trim();
                    if (variable.GetVariableValue(variableName) != 0)
                    {
                        int value = variable.GetVariableValue(variableName);
                        string operatorSymbol = conditionParts[1].Trim();
                        int a;

                        if (int.TryParse(conditionParts[2].Trim(), out a))
                        {
                            string[] ifCommands = ExtractWhileCommands(commands, currentIndex, "endif");
                            ProgramHandler program = new ProgramHandler(g);

                            if (CompareValues(value, operatorSymbol, a))
                            {
                                executeMethod(string.Join("\n", ifCommands));

                            }
                            returnIndex = currentIndex + ifCommands.Length;
                        }

                    }
                    else
                    {
                        throw new ArgumentException($"Value of {variableName} was not Assigned");
                    }
                    
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error in IF Statement: ", ex.Message);
                }
            }
        }

        /// <summary>
        /// Compares two integer values based on the specified comparison operator.
        /// </summary>
        /// <param name="value">The first integer value.</param>
        /// <param name="operatorSymbol">The comparison operator symbol.</param>
        /// <param name="a">The second integer value.</param>
        /// <returns>True if the comparison is true; otherwise, false.</returns>

        private bool CompareValues(int value, string operatorSymbol, int a)
        {
            switch (operatorSymbol)
            {
                case "<":
                    return value < a;
                case "<=":
                    return value <= a;
                case "==":
                    return value == a;
                case ">=":
                    return value >= a;
                case ">":
                    return value > a;
                default:
                    throw new ArgumentException("Invalid operator");
            }
        }
        /// <summary>
        /// Gets the index of the next command after the if statement.
        /// </summary>
        /// <returns>The index of the next command.</returns>

        public int getIndex()
        {
            return returnIndex;
        }

        /// <summary>
        /// Extracts the commands within the if statement block.
        /// </summary>
        /// <param name="command">The array of commands in the program.</param>
        /// <param name="startIndex">The starting index of the if statement in the program.</param>
        /// <param name="endLoopKeyword">The keyword indicating the end of the if statement.</param>
        /// <returns>An array of commands within the if statement block.</returns>

        string[] ExtractWhileCommands(string[] command, int startIndex, string endLoopKeyword)
        {
            bool containsEndLoop = command.Any(c => c.Contains(endLoopKeyword));

            if (!containsEndLoop)
            {
                throw new ArgumentException("The if Statement doesnt contain the endif keyword");
            }

            List<string> whileCommands = new List<string>();
            int nestedCount = 0;

            for (int i = startIndex; i < command.Length; i++)
            {
                string trimmedCommand = command[i].Trim();

                if (trimmedCommand.ToLower() == endLoopKeyword.ToLower() && nestedCount == 0)
                {
                    break;
                }
                else
                {
                    whileCommands.Add(trimmedCommand);
                    if (trimmedCommand.ToLower().StartsWith("if "))
                    {
                        nestedCount++;
                    }
                    else if (trimmedCommand.ToLower().StartsWith(endLoopKeyword.ToLower()))
                    {
                        nestedCount--;
                    }
                }
            }

            return whileCommands.ToArray();
        }
    }
}
