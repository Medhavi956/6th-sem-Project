using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Graphical_Programming_Language_App_Medhavi.Programm
{

    /// <summary>
    /// Manages methods and their associated commands in a graphical programming language.
    /// </summary>
    public class MethodManager
    {
        private int returnIndex;
        private Dictionary<string, string> methods;
        private string[] parameterNameArray;
        private Dictionary<string, int> parameterValues;
        List<string> parameterNames = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodManager"/> class.
        /// </summary>
        public MethodManager()
        {
            methods = new Dictionary<string, string>();
            parameterValues = new Dictionary<string, int>();
        }

        /// <summary>
        /// Assigns a method with the specified condition, commands, and current index.
        /// </summary>
        /// <param name="condition">The condition specifying the method name and parameters.</param>
        /// <param name="commands">The array of commands associated with the method.</param>
        /// <param name="currentIndex">The current index in the program.</param>

        public void AssignMethod(string condition, string[] commands, int currentIndex)
        {
            string[] conditionParts = condition.Split(' ');
            try
            {
                string MethodName = conditionParts[0].Trim();

                string parameter = conditionParts[1].Trim();
                string removeBraces = parameter.Substring(1, parameter.Length - 2);
                string[] methodName = removeBraces.Split(',');
                for (int i = 0; i < methodName.Length; i++)
                {
                    parameterNames.Add(methodName[i]);

                }
                parameterNameArray = parameterNames.ToArray();



                string[] methodLists = ExtractListCommands(commands, currentIndex,"endmethod");

                string commandsList = string.Join("\n", methodLists);
                methods[MethodName] = commandsList;
                if (methods.ContainsKey(MethodName))
                {
                }
                returnIndex = currentIndex + methodLists.Length;
            }
            catch (Exception ex)
            {
                throw new ArgumentException( ex.Message);
            }

        }

        /// <summary>
        /// Gets the index of the next command after the method.
        /// </summary>
        /// <returns>The index of the next command.</returns>

        public int getIndex()
        {
            return returnIndex;
        }

        /// <summary>
        /// Extracts the commands within the method block.
        /// </summary>
        /// <param name="command">The array of commands in the program.</param>
        /// <param name="startIndex">The starting index of the method in the program.</param>
        /// <param name="endLoopKeyword">The keyword indicating the end of the method.</param>
        /// <returns>An array of commands within the method block.</returns>

        private string[] ExtractListCommands(string[] command, int startIndex, string endLoopKeyword)
        {
            bool containsEndLoop = command.Any(c => c.Contains(endLoopKeyword));

            if (!containsEndLoop)
            {
                throw new ArgumentException("The method doesnt contain the endMethod keyword");
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
                    if (trimmedCommand.ToLower().StartsWith("method "))
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

        /// <summary>
        /// Checks if the specified method exists.
        /// </summary>
        /// <param name="method">The method to check.</param>
        /// <returns>True if the method exists; otherwise, false.</returns>

        public bool checkMethod(string method)
        {
            string[] conditionParts = method.Split(' ');
            string methodName = conditionParts[0].Trim();

            if (methods.ContainsKey(methodName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the method value based on the specified method line.
        /// </summary>
        /// <param name="methodLine">The method line containing the method name and parameters.</param>
        /// <returns>The string representation of the method's commands with replaced parameter values.</returns>

        public string getMethodValue(string methodLine)
        {
            string[] conditionParts = methodLine.Split(' ');
            try
            {
                string methodName = conditionParts[0].Trim();
                string parameterPart = conditionParts[1].Trim();
                string parameters = parameterPart.Substring(1, parameterPart.Length - 2);
                string[] values = parameters.Trim().Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    string parameterName = parameterNameArray[i];
                    int value = int.Parse(values[i].Trim());

                    parameterValues[parameterName] = value;
                }
                if (methods.ContainsKey(methodName))
                {
                    string methodLines = methods[methodName];

                    string[] parameterNames = methodLines.Split(' ');

                    foreach (string parameterName in parameterNames)
                    {
                        if (parameterValues.ContainsKey(parameterName))
                        {
                            methodLines = methodLines.Replace($" {parameterName}", $" {parameterValues[parameterName].ToString()}");
                        }
                    }
                    return methodLines;
                }
                else
                {
                    return "null";
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Method '{methodLine}' does not exist.", ex.Message);
            }
        }

    }
}
