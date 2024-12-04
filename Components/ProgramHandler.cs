using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using Graphical_Programming_Language_App_Medhavi.Programm;

namespace Graphical_Programming_Language_App_Medhavi.Components
{
    /// <summary>
    /// Handles the execution of a program containing various commands.
    /// </summary>
    public class ProgramHandler
    {
        private Dictionary<string, int> variables = new Dictionary<string, int>();
        private Graphics outputGraphics;
        VariableManager variable = new VariableManager();
        MethodManager methodManager = new MethodManager();

        /// <summary>
        /// Initializes a new instance of the ProgramHandler class.
        /// </summary>
        /// <param name="g">The Graphics object for drawing.</param>

        public ProgramHandler(Graphics g)
        {
            this.outputGraphics = g;
        }

        /// <summary>
        /// Executes the provided program containing commands.
        /// </summary>
        /// <param name="line">The program string containing commands.</param>
        public void Execute(string line)
        {
            string[] commands = line.Split('\n');

            int currentIndex = 0;
            bool errorShown = false;

            while (currentIndex < commands.Length)
            {               
                    string command = commands[currentIndex];
                    string trimmedCommand = command.Trim();


                try
                {
                    int indexOfEquals = trimmedCommand.IndexOf('=');
                    if (indexOfEquals != -1)
                    {
                        if (trimmedCommand.ToLower().StartsWith("if "))
                        {
                            string condition = trimmedCommand.Substring(3).Trim();
                            IfStatement iff = new IfStatement(commands, condition, currentIndex + 1, variable, outputGraphics, Execute);
                            iff.Execute();
                            currentIndex = iff.getIndex();
                        }
                        else
                        {
                            variable.AssignVariable(trimmedCommand);
                        }
                    }

                    else if (trimmedCommand.ToLower().StartsWith("print "))
                    {
                        string varToPrint = trimmedCommand.Substring(6).Trim(); // Remove "print " from the command
                        int value = variable.GetVariableValue(varToPrint);
                        MessageBox.Show($"Print: {value}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (trimmedCommand.ToLower().StartsWith("while "))
                    {
                        string condition = trimmedCommand.Substring(6).Trim();
                        WhileLoop whileloop = new WhileLoop(commands, condition, currentIndex + 1, variable, outputGraphics, Execute);
                        whileloop.Execute();
                        currentIndex = whileloop.getIndex();
                    }

                    else if (trimmedCommand.ToLower().StartsWith("method "))
                    {
                        string condition = trimmedCommand.Substring(7).Trim();
                        methodManager.AssignMethod(condition, commands, currentIndex + 1);
                        currentIndex = methodManager.getIndex();
                    }

                    else if (trimmedCommand.ToLower().StartsWith("if "))
                    {
                        string condition = trimmedCommand.Substring(3).Trim();
                        IfStatement iff = new IfStatement(commands, condition, currentIndex + 1, variable, outputGraphics, Execute);
                        iff.Execute();
                        currentIndex = iff.getIndex();
                    }
                    
                    else if (methodManager.checkMethod(trimmedCommand))
                    {
                        string lines = methodManager.getMethodValue(trimmedCommand).ToString();
                        Execute(lines);
                    }

                    else
                    {
                        string[] commandParts = trimmedCommand.ToLower().Split(' ');

                        if ((commandParts[0] == "circle" || commandParts[0] == "triangle" ) && variable.GetVariableValue(commandParts[1]) != 0 && commandParts.Length <= 2)
                        {
                            string combinedCommand = commandParts[0] + " " + variable.GetVariableValue(commandParts[1]).ToString();
                            new CommandParser(combinedCommand, outputGraphics);
                        }
                        else if (commandParts[0] == "rectangle"  && commandParts.Length <= 2)
                        {
                            string[] value = commandParts[1].Trim().Split(',');
                            if(variable.GetVariableValue(value[0]) != 0 && variable.GetVariableValue(value[1]) != 0)
                            {
                                string combinedCommand = commandParts[0] + " " + variable.GetVariableValue(value[0]).ToString() + "," + variable.GetVariableValue(value[1]).ToString();
                                new CommandParser(combinedCommand, outputGraphics);

                            }
                            else
                            {
                                new CommandParser(trimmedCommand, outputGraphics);
                            }

                        }
                        else
                        {
                            new CommandParser(trimmedCommand, outputGraphics);
                        }
                    }
                    currentIndex++;

                }
                catch(ArgumentException ex)
                {
                    throw new ArgumentException($"Error in Line: {currentIndex + 1}\r\n{ex.Message}");

                }


            }
        }
        /// <summary>
        /// Displays output text on the Graphics object.
        /// </summary>
        /// <param name="outputText">The text to display.</param>
        private void DisplayOutput(string errorMessage,int lineIndex)
        {
            outputGraphics.DrawString($"Error in line {lineIndex} with Error Message: {errorMessage}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
        }
    }
}
