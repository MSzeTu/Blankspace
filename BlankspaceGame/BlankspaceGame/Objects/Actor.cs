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
    class Actor : GameObject
    {
        // Fields
        private int health;

        // Accessor for HP
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public void Damage(int damageVal)
        {
            health -= damageVal;
        }

        // Constructor
        public Actor (Rectangle rect, Texture2D text) : base(rect, text)
        {

        }
    }
}
