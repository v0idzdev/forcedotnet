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

    /// <summary>
    /// The base class that all Force .NET classes inherit from
    /// </summary>

    public abstract class Engine
    {
        #region Variables

        /* The game instance's, size, title etc. */

        private Vector2D screenSize = new Vector2D(512, 512);
        private string windowTitle = "New Game"; 
        private Canvas window = null;
        private Thread gameLoopThread = null;

        public Color BackgroundColour = Color.White;

        #endregion

        #region Constructors

        /// <summary>
        /// Generates a new instance of the game 
        /// </summary>
        /// <param name="screenSize">Screen size</param>
        /// <param name="windowTitle">Window title</param>

        public Engine(Vector2D screenSize, string windowTitle)
            
        {
            this.screenSize = screenSize; // Sets game instance's window size
            this.windowTitle = windowTitle; // Sets game instance's window title

            /* Sets up the game window */

            window = new Canvas(); 
            window.Size = new Size((int)this.screenSize.X, (int)screenSize.Y);
            window.Text = this.windowTitle;
            window.Paint += Renderer;

            /* Starts a new thread for the game loop, so the screen updates */

            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();

            Application.Run(window); // Runs our custom game window 
            
        }

        void GameLoop()
        {
            OnLoad(); // Called before the game renderer starts

            /* While the game loop thread is running, it continues to loop */

            while (gameLoopThread.IsAlive)
            {
                try 
                {
                    /* While game loop thread is running, the screen refreshes */

                    OnDraw(); // Basically just draws the frame before it's displayed
                    window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });

                    Update(); // After the frame is drawn, call the Update() Method 
                    Thread.Sleep(1); // Add delay so that it doesn't refresh on top of another refresh call
                }              
                
                catch /* Says 'Game is loading...' while waiting for app to run */
                {
                    Console.WriteLine("Game is Loading...");
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.Clear(BackgroundColour); // Background colour or skybox
        }

        public abstract void OnLoad(); // We use this to create new game objects or load sprites etc.
        public abstract void Update(); // We use this for our movement, physics and such
        public abstract void OnDraw(); // We use this to draw graphics into our game

        #endregion
    }
}
