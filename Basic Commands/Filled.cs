using System;
using Graphical_Programming_Language_App_Medhavi.Components;

namespace Graphical_Programming_Language_App_Medhavi.Basic_Commands
{
    /// <summary>
    /// Represents a class that handles setting the fill status.
    /// </summary>
    public class Filled
    {
        private string status;

        /// <summary>
        /// Initializes a new instance of the Filled class with the specified fill status.
        /// </summary>
        /// <param name="status">The fill status to set ('on' or 'off').</param>
        public Filled(string status)
        {
            this.status = status;
            Execute();
        }

        /// <summary>
        /// Executes the Filled command to set the fill status.
        /// </summary>
        public void Execute()
        {
            if (status == "on")
            {
                GlobalConfiguration.isFillOn = true;
            }
            else if (status == "off")
            {
                GlobalConfiguration.isFillOn = false;
            }
            else
            {
                throw new ArgumentException("Invalid Value. Please write either 'on' or 'off'.");
            }
        }
    }
}
