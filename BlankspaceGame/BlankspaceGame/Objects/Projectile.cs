using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlankspaceGame
{
    class Projectile : GameObject
    {
        // Velocity, speed and damage fields
        private Vector2 velocity;
        private int speed;
        private int damage;

        public Projectile(Vector2 unitVelocity, int speed, Rectangle rect, Texture2D text) : base(rect, text)
        {
            this.velocity = unitVelocity;
            this.speed = speed;
        }
    }
}
