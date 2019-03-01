using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlankspaceGame
{
    public class ProjectileManager
    {
        // List of projectiles
        private List<Projectile> projectiles;
        public List<Projectile> Projectiles
        {
            get
            {
                return projectiles;
            }
        }

        public ProjectileManager()
        {
            // Initialize the list of projectiles
            projectiles = new List<Projectile>();
        }

        // Removes projectile at target position
        public void RemoveProjAt(int index)
        {
            projectiles.RemoveAt(index);
        }

        /// <summary>
        /// Adds projectiles to the list of projectiles
        /// </summary>
        /// <param name="projectile">The projectile to add</param>
        public void AddProjectile(Vector2 unitVelocity, int speed, Rectangle rect, Texture2D text, Boolean playerShot)
        {
            projectiles.Add(new Projectile(unitVelocity, speed, rect, text, playerShot));
        }

        // Method to update projectils
        public void UpdateProjectiles()
        {
            // Test if the list is empty
            if(!(projectiles.Count < 0))
            {
                // Loop through the projectiles
                foreach (Projectile projectile in projectiles)
                {
                    // Call their move method and maybe test collisions or somthin
                    projectile.Move();
                }
            }
        }

        // Draw for the projectiles
        public void DrawProjectiles(SpriteBatch sb)
        {
            // Test if the list is empty
            if (!(projectiles.Count < 0))
            {
                // Loop through the projectiles
                foreach (Projectile projectile in projectiles)
                {
                    // Call their move method and maybe test collisions or somthin
                    projectile.Draw(sb);
                }
            }
        }

        // Clears the projectile list
        public void Clear()
        {
            projectiles.Clear();
        }
    }
}
