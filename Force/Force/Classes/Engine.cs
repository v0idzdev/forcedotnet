﻿using System;
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

        private Vector2D ScreenSize = new Vector2D(512, 512);
        private string WindowTitle = "New Game"; 
        private Canvas Window = null;
        private Thread GameLoopThread = null;

        public Color BackgroundColour = Color.White; // Background colour
        public Vector2D CameraPosition = Vector2D.Zero(); // The game camera
        public float CameraAngle = 0F; // The angle to rotate the camera by

        private static List<Shape2D> AllShapes = new List<Shape2D>(); // All game shapes
        private static List<Sprite2D> AllSprites = new List<Sprite2D>(); // All game sprites

        #endregion

        #region Constructor

        /// <summary>
        /// Generates a new instance of the game 
        /// </summary>
        /// <param name="ScreenSize">Screen size</param>
        /// <param name="WindowTitle">Window title</param>

        public Engine(Vector2D ScreenSize, string WindowTitle)          
        {
            Log.Info("Game is starting...");

            this.ScreenSize = ScreenSize; // Sets game instance's window size
            this.WindowTitle = WindowTitle; // Sets game instance's window title

            /* Sets up the game window */

            Window = new Canvas(); 
            Window.Size = new Size((int)this.ScreenSize.X, (int)this.ScreenSize.Y);
            Window.Text = this.WindowTitle;
            Window.Paint += Renderer;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUp;

            /* Starts a new thread for the game loop, so the screen updates */

            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(Window); // Runs our custom game window            
        }

        #endregion

        #region User Inputs

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            GetKeyUp(e); // Calls the abstract GetkeyUp method
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GetKeyDown(e); // Calls the abstract GetKeyDown method
        }

        #endregion

        #region Registering

        /// <summary>
        /// Adds the shape to the engine's list of shapes
        /// </summary>
        /// <param name="shape">The shape to add</param>

        public static void RegisterShape(Shape2D shape)
        {
            AllShapes.Add(shape);
        }

        /// <summary>
        /// Adds the sprite to the engine's list of sprites
        /// </summary>
        /// <param name="shape">The shape to add</param>

        public static void RegisterSprite(Sprite2D sprite)
        {
            AllSprites.Add(sprite);
        }

        /// <summary>
        /// Removes the shape to the engine's list of shapes
        /// </summary>
        /// <param name="shape">The shape to remove</param>

        public static void UnregisterShape(Shape2D shape)
        {
            AllShapes.Remove(shape);
        }

        /// <summary>
        /// Removes the sprite to the engine's list of sprites
        /// </summary>
        /// <param name="shape">The shape to add</param>       

        public static void UnregisterSprite(Sprite2D sprite)
        {
            AllSprites.Remove(sprite);
        }

        #endregion

        #region Game Loop

        void GameLoop()
        {
            OnLoad(); // Called before the game renderer starts

            /* While the game loop thread is running, it continues to loop */

            while (GameLoopThread.IsAlive)
            {
                try 
                {
                    /* While game loop thread is running, the screen refreshes */

                    OnDraw(); // Basically just draws the frame before it's displayed
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });

                    Update(); // After the frame is drawn, call the Update() Method 
                    Thread.Sleep(1); // Add delay so that it doesn't refresh on top of another refresh call
                }              
                
                catch /* Says 'Game is loading...' while waiting for app to run */
                {
                    Log.Error("Window has not been found... Wating...");
                }
            }
        }

        #endregion

        #region Renderer

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.Clear(BackgroundColour); // Background colour or skybox

            graphics.TranslateTransform(CameraPosition.X, CameraPosition.Y); // Sets the position of the camera

            graphics.RotateTransform(CameraAngle); // Rotates the camera, by using the camera angle variable

            foreach (Shape2D shape in AllShapes) // Draws each shape on the screen with the correct position and scale
            {
                graphics.FillRectangle(new SolidBrush(Color.Red), shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);
            }    
            
            foreach (Sprite2D sprite in AllSprites)  // Draws each sprite on the screen with the correct position and scale
            {
                graphics.DrawImage(sprite.Sprite, sprite.Position.X, sprite.Position.Y, sprite.Scale.X, sprite.Scale.Y);
            }
        }

        #endregion

        #region Abstract Methods
        
        public abstract void OnLoad(); // We use this to create new game objects or load sprites etc.
        public abstract void Update(); // We use this for our movement, physics and such
        public abstract void OnDraw(); // We use this to draw graphics into our game
        public abstract void GetKeyDown(KeyEventArgs e); // We use this to track key pressed
        public abstract void GetKeyUp(KeyEventArgs e); // We use this to track key releases

        #endregion
    }
}
