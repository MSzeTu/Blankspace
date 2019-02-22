using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BlankspaceGame
{
    class Player : Actor
    {
        // Constructor
        public Player(Rectangle pos, Texture2D text):base(pos, text, 10) // Passes 10 to hp
        {

        }
    }
}
