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
    // Base object for anything which appears on the screen (Anything with a texture and a position)
    class GameObject
    {
        // Fields
        private Rectangle position;
        private Texture2D texture;

        // Accessors
        public Rectangle Position // Main rectangle object
        {
            get { return position; }
        }
        // Easy access for X and Y
        public int X
        {
            get { return position.X; }
            set { position.X = value; }
        }
        public int Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        // Draw method, virtual so that children can override it if needed (ie player)
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, Color.White);
        }

        // Collide method, so all objects can detect collisions with others
        public bool Colliding(GameObject obj)
        {
            if (this.position.Intersects(obj.position))
            {
                return true;
            }
            return false;
        }
    }
}
