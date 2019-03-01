using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
/*Name: Blank Space
 * Class: IGME106
 * Author: WIP
 * Purpose: Contains enemies details and fields
 * Recent Changes: Created header
 */
namespace BlankspaceGame
{
    public class Enemy : Actor
    {
        // Fields
        // Info for determining direction
        private Vector2 unitVelocity;
        private int speed;

        //Sprites and sound
        SoundEffect hitSound;
        SoundEffect shootSound;
        Texture2D defEnemy;
        Texture2D projectiles;
        public SoundEffect HitSound
        {
            get
            {
                return hitSound;
            }
        }
        public SoundEffect ShootSound
        {
            get
            {
                return shootSound;
            }
        }
        public Texture2D DefEnemy
        {
            get
            {
                return DefEnemy;
            }
        }
        public Texture2D Projectiles
        {
            get
            {
                return Projectiles;
            }
        }

        // Despawns if the enemies get too far from the player
        public bool CheckDespawn()
        {
            if (Y > 900)
            {
                return true;
            }
            return false;
        }

        public Enemy(Rectangle rect, Texture2D text, int hp, Vector2 unitVelIn, int spdIn) : base(rect, text, hp)
        {
            unitVelocity = unitVelIn;
            speed = spdIn;
            unitVelocity.Normalize();
        }

        // Loads enemy sprites and sounds
        public void LoadDefaultEnemy(Texture2D tex, Texture2D projectile, SoundEffect hit, SoundEffect shoot)
        {
            defEnemy = tex;
            projectiles = projectile;
            hitSound = hit;
            shootSound = shoot;
        }

        // Move method for moving in target direction
        public void Move()
        {
            Vector2 dir = unitVelocity * speed;

            X += (int)dir.X;
            Y += (int)dir.Y;
        }

        //Checks if bullets have hit enemy
        public int CheckBulletCollision(List<Projectile> projectiles)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i].Colliding(this))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
