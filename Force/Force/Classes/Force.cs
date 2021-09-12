using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Force.Classes
{
    #region Canvas Class

    /// <summary>
    /// Creates a new WinForms canvas, and enables double buffering
    /// </summary>

    class Canvas : Form
    {
        public Canvas()
        {
            /* Without this WinForms does this weird flickering */

            this.DoubleBuffered = true; 
        }
    }

    #endregion

    #region Force Framework Class

    /// <summary>
    /// The base class that all Force .NET classes inherit from
    /// </summary>

    public abstract class Force
    {
        #region Variables

        /* The game instance's, size, title etc. */

        private Vector2D screenSize = new Vector2D(512, 512);
        private string windowTitle = "New Game"; 
        private Canvas Window = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Generates a new instance of the game 
        /// </summary>
        /// <param name="screenSize">Screen size</param>
        /// <param name="windowTitle">Window title</param>

        public Force(Vector2D screenSize, string windowTitle) 
        {
            this.screenSize = screenSize; // Sets game instance's window size
            this.windowTitle = windowTitle; // Sets game instance's window title

            /* Sets up the game window */

            Window = new Canvas(); 
            Window.Size = new Size((int)this.screenSize.X, (int)screenSize.Y);
            Window.Text = this.windowTitle;

            Application.Run(Window); // Runs our custom game window 
        }

        #endregion
    }

    #endregion

    #region Callback Class


    #endregion
}
