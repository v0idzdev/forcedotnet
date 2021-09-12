using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Force.Classes
{
    /// <summary>
    /// Implements 2D vectors
    /// </summary>

    public class Vector2D
    {
        public float X { get; set; } // The vector's x position
        public float Y { get; set; } // The vector's y position

        /// <summary>
        /// Creates a new Vector2D, with values [0, 0]
        /// </summary>

        public Vector2D() 
        {
            this.X = Zero().X; // Calls zero method to set x to 0
            this.Y = Zero().Y; // Calls zero method to set y to 0
        }

        /// <summary>
        /// Creates a new Vector2D, of any given values
        /// </summary>
        /// <param name="x">The vector's x position</param>
        /// <param name="y">The vector's y position</param>

        public Vector2D(float x, float y) 
        {
            this.X = x; // Sets new vector's x pos to value passed in
            this.Y = y; // Sets new vector's y pos to value passed in
        }

        /// <summary>
        /// Generates a new zero vector [0, 0]
        /// </summary>
        /// <remarks>
        /// Returns X and Y as [0, 0]
        /// </remarks>

        public static Vector2D Zero() // Generates a new zero vector 
        {
            return new Vector2D(0, 0); // Generates [0, 0] vector
        }
    }
}
