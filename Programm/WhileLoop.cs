using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Graphical_Programming_Language_App_Medhavi.Components;

namespace Graphical_Programming_Language_App_Medhavi.Programm
{
    /// <summary>
    /// Represents an implementation of a while loop in a graphical programming language.
    /// </summary>
    public class WhileLoop : Icommands
    {
        private string condition;
        private string[] commands;
        private int currentIndex, returnIndex;
        private VariableManager variable;
        private Graphics g;
        private Action<string> executeMethod;


        /// <summary>
        /// Initializes a new instance of the <see cref="WhileLoop"/> class.
        /// </summary>
        /// <param name="commands">The array of commands associated with the while loop.</param>
        /// <param name="condition">The condition to be evaluated for the while loop.</param>
        /// <param name="startIndex">The starting index of the while loop within the program.</param>
        /// <param name="variable">The variable manager for managing variables.</param>
        /// <param name="g">The Graphics object for drawing operations.</param>
        /// <param name="executeMethod">The method for executing commands.</param>

        public WhileLoop(string[] commands, string condition, int startIndex, VariableManager variable, Graphics g, Action<string> executeMethod)
        {
            this.commands = commands;
            this.condition = condition;
            this.currentIndex = startIndex;
            this.variable = variable;
            this.g = g;
            this.executeMethod = executeMethod;
        }


        /// <summary>
        /// Executes the while loop based on the specified condition and commands.
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

                        string operatorSymbol = conditionParts[1].Trim().ToString();
                        int a;

                        if (int.TryParse(conditionParts[2].Trim(), out a))
                        {
                            string[] whileCommands = ExtractWhileCommands(commands, currentIndex, "endloop");
                            ProgramHandler program = new ProgramHandler(g);

                            while (CompareValues(value, operatorSymbol, a))
                            {
                                executeMethod(string.Join("\n", whileCommands));
                                value = variable.GetVariableValue(variableName);
                            }
                            returnIndex = currentIndex + whileCommands.Length;
                        }

                    }
                    else
                    {
                        throw new ArgumentException($"Value of {variableName} was not Assigned");
                    }
                    

                   
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error in while loop", ex.Message);
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
        /// Gets the index of the next command after the while loop.
        /// </summary>
        /// <returns>The index of the next command.</returns>

        public int getIndex()
        {
            return returnIndex;
        }

        /// <summary>
        /// Extracts the commands within the while loop block.
        /// </summary>
        /// <param name="command">The array of commands in the program.</param>
        /// <param name="startIndex">The starting index of the while loop in the program.</param>
        /// <param name="endLoopKeyword">The keyword indicating the end of the while loop.</param>
        /// <returns>An array of commands within the while loop block.</returns>

        string[] ExtractWhileCommands(string[] command, int startIndex, string endLoopKeyword)
        {
            bool containsEndLoop = command.Any(c => c.Contains(endLoopKeyword));

            if (!containsEndLoop)
            {
                throw new ArgumentException("The while loop doesnt contain the endloop keyword");
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
                    if (trimmedCommand.ToLower().StartsWith("while "))
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
