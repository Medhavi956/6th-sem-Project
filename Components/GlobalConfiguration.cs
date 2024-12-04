using System.Drawing;

namespace Graphical_Programming_Language_App_Medhavi.Components
{
    /// <summary>
    /// Provides global configuration settings for the graphical programming language application.
    /// </summary>
    public static class GlobalConfiguration
    {
        /// <summary>
        /// Gets or sets the color used for drawing.
        /// </summary>
        public static Color penColor { get; set; } = Color.Black;

        /// <summary>
        /// Gets or sets the X-coordinate for the drawing position.
        /// </summary>
        public static int xPoint { get; set; } = 10;

        /// <summary>
        /// Gets or sets the Y-coordinate for the drawing position.
        /// </summary>
        public static int yPoint { get; set; } = 10;

        /// <summary>
        /// Gets or sets the fill status for drawing shapes.
        /// </summary>
        public static bool isFillOn { get; set; } = false;
    }
}
