using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*Name: Blank Space
 * Class: IGME106
 * Author: WIP
 * Purpose: Parent class for objects
 * Recent Changes: Created header
 */
namespace BlankspaceGame
{
    public class Actor : GameObject
    {
        // Fields
        private int health;
        private Color color;
        private int damageTick;

        // Accessor for HP
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        // Accessor for color
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        // Accessor for damageTick
        public int DamageTick
        {
            get { return damageTick; }
            set { damageTick = value; }
        }

        public void Damage(int damageVal)
        {
            health -= damageVal;
        }

        // Constructor
        public Actor (Rectangle rect, Texture2D text, int hp) : base(rect, text)
        {
            this.health = hp;
            color = Color.White;
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, color);
        }
    }
}
