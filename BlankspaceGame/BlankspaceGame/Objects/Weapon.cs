using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
/*Name: Blank Space
 * Class: IGME106
 * Author: WIP
 * Purpose: Handles weapon types for procederely generated weapons
 * Recent Changes: Created header
 */
namespace BlankspaceGame
{
    // Defines firetype of the weapon
    enum Firetype
    {
        Dual,
        Beam,
        Shotgun
    }
    // Defines the firerate, faster rates have less damage and slow rates have high damage
    enum Firerate
    {
        Fast,
        Normal,
        Slow
    }
    // Defines the color of the weapon, MAY also inflict status effects if i have time to implement
    enum Firecolor
    {
        Red,
        Blue,
        Green
    }

    class Weapon
    {
        // Variables to hold the components of the weapon
        private Firetype type;
        private Firerate rate;
        private Firecolor color;

        // Textures for the firetypes
        private Texture2D dual;
        private Texture2D shotgun;
        private Texture2D beam;

        // Constructor
        public Weapon(Firetype t, Firerate r, Firecolor c)
        {
            type = t;
            rate = r;
            color = c;
        }

        // Fire method, called when space is pressed and will create bullets according to the components
        public void Fire(ProjectileManager projectileManager, int x, int y)
        {
            switch (this.type)
            {
                case Firetype.Dual:
                    projectileManager.AddProjectile(new Vector2(0, -1), 10, new Rectangle(x + 14, y, 10, 20), dual, true);
                    projectileManager.AddProjectile(new Vector2(0, -1), 10, new Rectangle(x + 24, y, 10, 20), dual, true);
                    break;
                case Firetype.Shotgun:

                    break;
                case Firetype.Beam:

                    break;
            }
        }

        // Returns the cooldown in ticks of the weapon
        public int GetCooldown()
        {
            int cd = 0;

            // Base cooldown of each weapon
            switch (this.type)
            {
                case Firetype.Dual:
                    cd = 10;
                    break;
                case Firetype.Shotgun:
                    cd = 30;
                    break;
                case Firetype.Beam:
                    cd = 60;
                    break;
            }

            // Cooldown modifiers for the firespeed
            switch (this.rate)
            {
                case Firerate.Fast:
                    cd = cd / 2;
                    break;
                case Firerate.Normal:
                    //cd = cd;
                    break;
                case Firerate.Slow:
                    cd = cd * 2;
                    break;
            }

            return cd;
        }

        // Loads the textures into the object
        public void LoadTextures(Game1 game)
        {
            dual = game.Content.Load<Texture2D>("Projectiles/redlaser");
        }
    }
}
