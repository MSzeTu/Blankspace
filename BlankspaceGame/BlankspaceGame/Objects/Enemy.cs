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
    public class Enemy : Actor
    {
        // Fields
        // Info for determining direction
        private Vector2 unitVelocity;
        private int speed;

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

        // Move method for moving in target direction
        public void Move()
        {
            Vector2 dir = unitVelocity * speed;

            X += (int)dir.X;
            Y += (int)dir.Y;
        }

        public int CheckBulletCollision(List<Projectile> projectiles)
        {
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                if (projectiles[i].Colliding(this))
                {
                    Health -= 1;
                    return i;
                }
            }
            return -1;
        }
    }
}
