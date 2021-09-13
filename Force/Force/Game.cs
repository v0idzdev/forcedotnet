using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Force.Classes;

namespace Force
{
    class Game : Engine
    {
        #region Shapes & Game Objects

        /* Put your game objects and shapes here.
         * Then load them in the OnLoad method. */

        //Sprite2D player;

        string[,] Map = /* The 'grid' to build our level */
        {
            // A 'g' means a ground tile will be here

            { ".", ".", ".", ".", ".", ".", ".", "." },
            { ".", ".", ".", ".", ".", ".", ".", "." },
            { ".", ".", ".", ".", ".", ".", ".", "." },
            { ".", ".", ".", ".", ".", ".", ".", "." },
            { ".", ".", ".", ".", ".", ".", ".", "." },
            { "g", "g", ".", "g", "g", ".", "g", "g" },
            { "g", "g", "g", "g", "g", "g", "g", "g" },
            { "g", "g", "g", "g", "g", "g", "g", "g" },
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
            BackgroundColour = Color.Black;

            //player = new Shape2D(new Vector2D(10, 10), new Vector2D(10, 10), "Test");
            //player = new Sprite2D(new Vector2D(10, 10), new Vector2D(64, 64), "Square", "Player");

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

        float x = .1F;

        public override void Update()
        {
           
        }

        #endregion
    }
}
