using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphical_Programming_Language_App_Medhavi.Programm
{
    /// <summary>
    /// Manages variables and their values in a graphical programming language.
    /// </summary>
    public class VariableManager
    {
        private Dictionary<string, int> variables;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableManager"/> class.
        /// </summary>
        public VariableManager()
        {
            variables = new Dictionary<string, int>();
        }

        /// <summary>
        /// Assigns a value to the specified variable.
        /// </summary>
        // <param name"command">The command containing the variable assignment.</param>

        public void AssignVariable(string command)
        {
            string trimmedCommand = command.Trim();

            int indexOfEquals = trimmedCommand.IndexOf('=');
            if (indexOfEquals != -1)
            {
                string[] strings = trimmedCommand.Split('=');
                string variableName = strings[0].ToLower().Trim();

                if (strings.Length >= 2)
                {
                    string valueString = strings[1].Trim();
                    int value;
                    if (int.TryParse(valueString, out value))
                    {
                        variables[variableName] = value;
                    }
                    else
                    {
                        EvaluateExpression(variableName, valueString);
                    }
                }
            }
        }

        /// <summary>
        /// Evaluates and assigns the result of an expression to the specified variable.
        /// </summary>
        /// <param name="variableName">The name of the variable to assign the result.</param>
        /// <param name="values">The expression or values to be evaluated.</param>

        private void EvaluateExpression(string variableName, string values)
        {
            string valueString = values.ToLower();

            if (valueString.Contains('+'))
            {
                string[] operands = valueString.Split('+');

                if (operands.Length == 2 && variables.ContainsKey(operands[0].Trim()) && variables.ContainsKey(operands[1].Trim()))
                {
                    int result = variables[operands[0].Trim()] + variables[operands[1].Trim()];
                    variables[variableName] = result;
                }
                else if (operands.Length == 2 && variables.ContainsKey(operands[0].Trim()) && int.TryParse(operands[1].Trim(), out int value))
                {
                    int result = variables[operands[0].Trim()] + value;
                    variables[variableName] = result;
                }
                else if (operands.Length == 2 && int.TryParse(operands[1].Trim(), out int value1) && int.TryParse(operands[1].Trim(), out int value2))
                {
                    int result = value1 + value2;
                    variables[variableName] = result;
                }
                else
                {
                    throw new ArgumentException("Invalid expression or variable");
                }
            }
            else if (valueString.Contains('-'))
            {
                string[] operands = valueString.Split('-');

                if (operands.Length == 2 && variables.ContainsKey(operands[0].Trim()) && variables.ContainsKey(operands[1].Trim()))
                {
                    int result = variables[operands[0].Trim()] - variables[operands[1].Trim()];
                    variables[variableName] = result;
                }
                else if (operands.Length == 2 && variables.ContainsKey(operands[0].Trim()) && int.TryParse(operands[1].Trim(), out int value))
                {
                    int result = variables[operands[0].Trim()] - value;
                    variables[variableName] = result;
                }
                else if (operands.Length == 2 && int.TryParse(operands[1].Trim(), out int value1) && int.TryParse(operands[1].Trim(), out int value2))
                {
                    int result = value1 - value2;
                    variables[variableName] = result;
                }
                else
                {
                    throw new ArgumentException("Invalid expression or variable");
                }

            }
            else if (valueString.Contains('*'))
            {
                string[] operands = valueString.Split('*');

                if (operands.Length == 2 && variables.ContainsKey(operands[0].Trim()) && variables.ContainsKey(operands[1].Trim()))
                {
                    int result = variables[operands[0].Trim()] * variables[operands[1].Trim()];
                    variables[variableName] = result;
                }
                else if (operands.Length == 2 && variables.ContainsKey(operands[0].Trim()) && int.TryParse(operands[1].Trim(), out int value))
                {
                    int result = variables[operands[0].Trim()] * value;
                    variables[variableName] = result;
                }
                else if (operands.Length == 2 && int.TryParse(operands[1].Trim(), out int value1) && int.TryParse(operands[1].Trim(), out int value2))
                {
                    int result = value1 * value2;
                    variables[variableName] = result;
                }
                else
                {
                    throw new ArgumentException("Invalid expression or variable");
                }

            }

        }

        /// <summary>
        /// Gets the value of the specified variable.
        /// </summary>
        /// <param name="variableName">The name of the variable.</param>
        /// <returns>The value of the variable or 0 if the variable does not exist.</returns>

        public int GetVariableValue(string variableName)
        {
            if (variables.ContainsKey(variableName))
            {
                return variables[variableName];
            }
            else
            {
                return 0;
            }
        }
    }
}
