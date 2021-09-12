using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Force.Classes;

namespace Force
{
    class Game : Classes.Force
    {
        /* After being instantiated by main, the game instatiates the base of our engine */

        public Game() : base(new Vector2D(615, 515), "New Force.NET Game") { }
    }
}
