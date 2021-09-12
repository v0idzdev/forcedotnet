using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Force.Classes
{
    public class Shape2D
    {
        public Vector2D Position = null;
        public Vector2D Scale = null;
        public string Tag = "";

        /// <summary>
        /// Constructs a new 2D shape object
        /// </summary>
        /// <param name="Position">The shape's position, which is a vector</param>
        /// <param name="Scale">The shape's scale, which is a vector</param>
        /// <param name="Tag">The shape's tag, which is a string</param>

        public Shape2D(Vector2D Position, Vector2D Scale, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            Log.Info($"[SHAPE 2D] {Tag} — Has been registered!");
            Engine.RegisterShape(this); 
        }

        /// <summary>
        /// Removes the shape from the list, which stops the engine drawing it
        /// </summary>

        public void DestroySelf()
        {
            Log.Info($"[SHAPE 2D] {Tag} — Has been destroyed!");
            Engine.UnregisterShape(this);
        }
    }
}
