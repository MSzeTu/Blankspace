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
    class Enemy : Actor
    {
        // Fields
        // Info for determining direction
        private int direction;
        private int speed;

        // Methods for spawning and despawning
        public void Spawn()
        {

        }

        public void Despawn()
        {

        }

        public Enemy(Rectangle rect, Texture2D text, int hp) : base(rect, text, hp)
        {

        }
    }
}
