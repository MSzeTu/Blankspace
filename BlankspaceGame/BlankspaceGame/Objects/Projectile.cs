﻿using System;
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
        /// <param name="direction">The direction the projectile is moving in.</param>
        /// <param name="speed">The speed the projectile is moving at.</param>
        /// <param name="rect">GameObject rectangle.</param>
        /// <param name="text">The projectiles texture.</param>
        public Projectile(Vector2 dir, int speed, Rectangle rect, Texture2D text, bool playPro) : base(rect, text)
        {
            this.direction = dir;
            this.direction.Normalize();
            this.speed = speed;
            playerShot = playPro;
        }

        /// <summary>
        /// Moves the projectile.
        /// </summary>
        public void Move()
        {
            // Multiply the normalized velocity with
            // the speed to ensure the object is moving at the desired rate.
            Vector2 velocity = direction * speed;

            // Move the object in the direction.
            X += (int)velocity.X;
            Y += (int)velocity.Y;

        }
    }
}
