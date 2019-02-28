using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlankspaceGame
{
    public class Projectile : GameObject
    {
        // Velocity, speed and damage fields
        private Vector2 velocity;
        private int speed;
        private int damage;
        private bool playerShot;
        public bool PlayerShot
        {
            get
            {
                return playerShot;
            }
        }

        /// <summary>
        /// Creates the projectile, this requires a direction, speed, and the gameobject components.
        /// </summary>
        /// <param name="unitVelocity">The direction the projectile is moving in.</param>
        /// <param name="speed">The speed the projectile is moving at.</param>
        /// <param name="rect">GameObject rectangle.</param>
        /// <param name="text">The projectiles texture.</param>
        public Projectile(Vector2 unitVelocity, int speed, Rectangle rect, Texture2D text, bool playPro) : base(rect, text)
        {
            this.velocity = unitVelocity;
            this.speed = speed;
            playerShot = playPro;
        }

        /// <summary>
        /// Moves the projectile.
        /// </summary>
        public void Move()
        {
            // Normalize the velocity to ensure it moves at the desired speed.
            velocity.Normalize();
             
            // Multiply the normalized velocity with
            // the speed to ensure the object is moving at the desired rate.
            Vector2 dir = velocity * speed;

            // Move the object in the direction.
            X += (int)dir.X;
            Y += (int)dir.Y;

        }
    }
}
