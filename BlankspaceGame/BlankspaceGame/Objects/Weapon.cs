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
        Shotgun,
        Erin
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

        public Firetype FireType
        {
            get
            {
                return type;
            }
        }

        /*
         * Constructor
         */
        public Weapon(Firetype t, Firerate r, Firecolor c)
        {
            type = t;
            rate = r;
            color = c;
        }

        /*
         * Fire method, called when space is pressed and will create bullets according to the components
         */
        public void Fire()
        {
            // Sets the x and y to player position
            int x = PlayerManager.X;
            int y = PlayerManager.Y+5;

            // Creates projectiles based on current firetype
            switch (this.type)
            {
                case Firetype.Dual:
                    ProjectileManager.AddProjectile(new Vector2(0, -1), 10, GetDamage(), new Rectangle(x + 5/*8 5 16*/, y, 10, 20), dual, true, false);
                    ProjectileManager.AddProjectile(new Vector2(0, -1), 10, GetDamage(), new Rectangle(x + 31/*28 31 21*/, y, 10, 20), dual, true, false);
                    break;
                case Firetype.Shotgun:
                    ProjectileManager.AddProjectile(new Vector2(0, -1), 10, GetDamage(), new Rectangle(x + 18, y, 10, 20), dual, true, false);
                    ProjectileManager.AddProjectile(new Vector2(0.1f, -1), 10, GetDamage(), new Rectangle(x + 18, y, 10, 20), dual, true, false);
                    ProjectileManager.AddProjectile(new Vector2(0.2f, -1), 10, GetDamage(), new Rectangle(x + 18, y, 10, 20), dual, true, false);
                    ProjectileManager.AddProjectile(new Vector2(-0.1f, -1), 10, GetDamage(), new Rectangle(x + 18, y, 10, 20), dual, true, false);
                    ProjectileManager.AddProjectile(new Vector2(-0.2f, -1), 10, GetDamage(), new Rectangle(x + 18, y, 10, 20), dual, true, false);
                    break;
                case Firetype.Beam:
                    ProjectileManager.AddProjectile(new Vector2(0, 1), 0, GetDamage(), new Rectangle(x - 25, y - 1500, 100, 1500), beam, true, true);
                    break;
                case Firetype.Erin:
                    ProjectileManager.AddProjectile(new Vector2(0, 1), 0, GetDamage(), new Rectangle(x - 75, y - 1500, 100, 1500), beam, true, true);
                    ProjectileManager.AddProjectile(new Vector2(0, 1), 0, GetDamage(), new Rectangle(x + 75, y - 1500, 100, 1500), beam, true, true);
                    PlayerManager.ScreenShake += (PlayerManager.ScreenShake < 40) ? 5 : 0;
                    break;
            }
        }

        /*
         *  Returns the Cooldown of the weapon
         */
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
                    cd = 40;
                    break;
                case Firetype.Beam:
                    cd = 120;
                    break;
                case Firetype.Erin:
                    cd = 0;
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

        /*
         * Returns the damage of the weapon
         */
        public int GetDamage()
        {
            int dmg = 0;
            // Base damage of each weapontype
            switch (this.type)
            {
                case Firetype.Dual:
                    dmg = 2;
                    break;
                case Firetype.Shotgun:
                    dmg = 4;
                    break;
                case Firetype.Beam:
                    dmg = 2;
                    break;
                case Firetype.Erin:
                    dmg = 20;
                    break;
            }

            // Cooldown modifiers for the damage
            switch (this.rate)
            {
                case Firerate.Fast:
                    dmg /= 2;
                    break;
                case Firerate.Normal:
                    //dmg = dmg;
                    break;
                case Firerate.Slow:
                    dmg *= 2;
                    break;
            }

            return dmg;
        }

        /*
         * Loads the textures into the object
         */
        public void LoadTextures(Game1 game)
        {
            dual = game.Content.Load<Texture2D>("Projectiles/redlaser");
            beam = game.Content.Load<Texture2D>("Projectiles/beam");
        }
    }
}
