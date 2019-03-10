using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
/*Name: Blank Space
 * Class: IGME106
 * Author: WIP
 * Purpose: Handles projectile list and interactions
 * Recent Changes: Created header
 */
namespace BlankspaceGame
{
    static public class ProjectileManager
    {
        // List of projectiles
        static private List<Projectile> projectiles;
        static public List<Projectile> Projectiles
        {
            get
            {
                return projectiles;
            }
        }

        static public void Initialize()
        {
            // Initialize the list of projectiles
            projectiles = new List<Projectile>();
        }

        // Removes projectile at target position
        public static void RemoveProjAt(int index)
        {
            projectiles.RemoveAt(index);
        }

        /// <summary>
        /// Adds projectiles to the list of projectiles
        /// </summary>
        /// <param name="projectile">The projectile to add</param>
        public static void AddProjectile(Vector2 unitVelocity, int speed, int dmg, Rectangle rect, Texture2D text, bool playerShot, bool beam)
        {
            projectiles.Add(new Projectile(unitVelocity, speed, dmg, rect, text, playerShot, beam));
        }

        // Method to update projectils
        public static void UpdateProjectiles()
        {
            // Test if the list is empty
            if (!(projectiles.Count < 0))
            {
                // Loop through the projectiles
                foreach (Projectile projectile in projectiles)
                {
                    // Call their move method and maybe test collisions or somthin
                    projectile.Move();
                    projectile.UpdateVars();
                }

                for (int i = projectiles.Count - 1; i >= 0; i--)
                {
                    // Check if beam lifetime is too long and delete
                    if (projectiles[i].Lifetime > 5 && projectiles[i].Beam == true)
                    {
                        projectiles.RemoveAt(i);
                    }
                }
            }
        }

        // Draw for the projectiles
        public static void DrawProjectiles(SpriteBatch sb)
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
        public static void Clear()
        {
            projectiles.Clear();
        }
    }
}
