using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlankspaceGame.ManagerClasses
{
    public class ProjectileManager
    {
        // List of projectiles
        private List<Projectile> projectiles;

        public ProjectileManager()
        {
            // Initialize the list of projectiles
            projectiles = new List<Projectile>();
        }

        /// <summary>
        /// Adds projectiles to the list of projectiles
        /// </summary>
        /// <param name="projectile">The projectile to add</param>
        public void AddProjectile(Projectile projectile)
        {
            projectiles.Add(projectile);
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
    }
}
