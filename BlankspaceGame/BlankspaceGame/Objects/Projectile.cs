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
 * Purpose: Contains Projectile details and fields
 * Recent Changes: Created header
 */
namespace BlankspaceGame
{
    public class Projectile : GameObject
    {
        // Velocity, speed and damage fields
        private Vector2 direction;
        private Vector2 accPosition;
        private int speed;
        private int damage;
        private bool playerShot;
        private bool beam;
        private int lifetime;

        public bool PlayerShot
        {
            get
            {
                return playerShot;
            }
        }

        public bool Beam
        {
            get { return beam; }
        }

        public int Lifetime
        {
            get { return lifetime; }
        }

        // Vector position overrides
        public float X
        {
            get { return accPosition.X; }
            set { accPosition.X = value; }
        }
        public float Y
        {
            get { return accPosition.Y; }
            set { accPosition.Y = value; }
        }

        /// <summary>
        /// Creates the projectile, this requires a direction, speed, and the gameobject components.
        /// </summary>
        /// <param name="direction">The direction the projectile is moving in.</param>
        /// <param name="speed">The speed the projectile is moving at.</param>
        /// <param name="rect">GameObject rectangle.</param>
        /// <param name="text">The projectiles texture.</param>
        public Projectile(Vector2 dir, int speed, Rectangle rect, Texture2D text, bool playPro, bool beamBool) : base(rect, text)
        {
            this.direction = dir;
            this.direction.Normalize();
            this.speed = speed;
            accPosition.X = rect.X;
            accPosition.Y = rect.Y;
            playerShot = playPro;
            beam = beamBool;
            lifetime = 0;
        }

        /// <summary>
        /// Moves the projectile.
        /// </summary>
        public void Move(int x, int y)
        {
            if (beam == false)
            {
                // Multiply the normalized velocity with
                // the speed to ensure the object is moving at the desired rate.
                Vector2 velocity = direction * speed;

                // Move the object in the direction.
                accPosition.X += velocity.X;
                accPosition.Y += velocity.Y;
            }
            if (beam == true)
            {
                accPosition.X = x - 25;
                accPosition.Y = y - 1500;
            }
            lifetime += 1;
        }

        public void UpdateVars()
        {
            position.X = (int)X;
            position.Y = (int)Y;
        }
    }
}
