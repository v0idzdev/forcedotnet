using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace Force.Classes
{
    public class Sprite2D
    {
        public Vector2D Position = null;
        public Vector2D Scale = null;
        public Bitmap Sprite = null;
        public string Directory = "";
        public string Tag = "";

        /// <summary>
        /// Constructs a new 2D sprite object
        /// </summary>
        /// <param name="Position">The sprite's position, which is a vector</param>
        /// <param name="Scale">The sprite's scale, which is a vector</param>
        /// <param name="Directory">The sprite's directory</param>

        public Sprite2D(Vector2D Position, Vector2D Scale, string Directory, string Tag)
        {
            this.Directory = Directory;
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            try // If the sprite / image CAN be loaded
            {
                Image temp = Image.FromFile($"Assets/{Directory}.png");
                Bitmap sprite = new Bitmap(temp);
                Sprite = sprite;
            }    
            
            catch // If the sprite / image CAN'T be loaded, display an error message in the log
            {
                Log.Error($"[SPRITE 2D] {Tag} wasn't loaded — Please enter a valid directory.");
            }

            Log.Info($"[SHAPE 2D] {Tag} — Has been registered!");
            Engine.RegisterSprite(this);
        }

        /// <summary>
        /// Removes the sprite from the list, which stops the engine drawing it
        /// </summary>

        public void DestroySelf()
        {
            Log.Info($"[SPRITE 2D] {Tag} — Has been destroyed!");
            Engine.UnregisterSprite(this);
        }
    }
}
