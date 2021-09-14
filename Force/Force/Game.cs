using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Force.Classes;

namespace Force
{
    class Game : Engine
    {
        #region Shapes & Game Objects

        /* Put your game objects and shapes here.
         * Then load them in the OnLoad method. */

        Sprite2D player; // The player

        float speed = 2F; // Movement speed

        bool left; // If moving left
        bool right; // If moving right
        bool down; // If moving down
        bool up; // If moving up


        string[,] Map = /* The 'grid' to build our level */
        {
            // A 'g' means a ground tile will be here

            { "g", "g", "g", "g", "g", "g", "g" },
            { "g", ".", ".", ".", ".", ".", "g" },
            { "g", ".", ".", ".", "g", ".", "g" },
            { "g", ".", "g", "g", "g", ".", "g" },
            { "g", ".", "g", ".", "g", ".", "g" },
            { "g", ".", "g", ".", ".", ".", "g" },
            { "g", "g", "g", "g", "g", "g", "g" }, 
        }; 

        #endregion

        #region Initialise Engine

        /* Starts up the game engine */

        public Game() : base(new Vector2D(615, 515), "New Force.NET Game") { /* ... */ }

        #endregion

        #region Game Logic

        /* OnLoad is called before the graphics renderer starts. 
         * Use this for loading sprites, game objects, UI etc. */

        public override void OnLoad()
        {
            /* Objects loaded first will appear
             * in front of objects loaded after */         

            // Setting background colour

            BackgroundColour = Color.Black;

            // Rendering player sprite on the screen with dimensions 16 * 16, at position 80, 250

            player = new Sprite2D(new Vector2D(80, 250), new Vector2D(16, 16), "Square", "Player");

            // Drawing the ground tiles on the screen

            for (int i = 0; i < Map.GetLength(0); i++) // For each horizontal block
            {
                for (int j = 0; j < Map.GetLength(1); j++) // For each vertical block
                {
                    if (Map[j, i] == "g") // All grid items called 'g' will have a square drawn on them
                    { 
                        new Sprite2D(new Vector2D(i * 64, j * 64), new Vector2D(64, 64), "Square", "Ground");   
                    }
                }
            }
        }

        /* OnDraw is called before every frame update.
         * Use this for graphics, changing colours etc. */

        public override void OnDraw()
        {
            
        }

        /* Update is called after every frame update. 
         * Use this for movement, physics, and such */

        public override void Update()
        {
            if (up) // If moving upwards          
                player.Position.Y -= speed;
            

            if (down) // If moving downwards       
                player.Position.Y += speed;
            

            if (left) // If moving to left        
                player.Position.X -= speed;
            

            if (right) // If moving to right        
                player.Position.X += speed;         
        }

        /* GetKeyDown is used for detecting whether a 
         * given key has been or is being pressed down. */

        public override void GetKeyDown(KeyEventArgs e)
        {
            // Gets key presses from the keyboard

            if (e.KeyCode == Keys.W) { up = true; }
            if (e.KeyCode == Keys.S) { down = true; }
            if (e.KeyCode == Keys.A) { left = true; }
            if (e.KeyCode == Keys.D) { right = true; }
        }

        /* GetKeyUp is used for detecting whether a 
         * given key has stopped being pressed down. */

        public override void GetKeyUp(KeyEventArgs e)
        {
            // Gets key releases from the keyboard

            if (e.KeyCode == Keys.W) { up = false; }
            if (e.KeyCode == Keys.S) { down = false; }
            if (e.KeyCode == Keys.A) { left = false; }
            if (e.KeyCode == Keys.D) { right = false; }
        }

        #endregion
    }
}
