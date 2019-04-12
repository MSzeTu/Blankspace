using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
/*Name: Blank Space
 * Class: IGME106
 * Author: WIP
 * Purpose: DA DEVICE DAT CONTROLLS THE BOLLATS WHEN THEY ARE AT DE CONTROLLERS... TOTALLY BOLLATS
 * Recent Changes: CORRECTED DA BOLLETS THINGY MAGIGIES
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

        /// <summary>
        /// REMOVES A BOLLAT FROM DA LIST
        /// </summary>
        /// <param name="index">DA INDEX OF DA BOLLETS TO BE REMOVAED</param>
        public static void RemoveProjAt(int index)
        {
            projectiles.RemoveAt(index);
        }

        /// <summary>
        /// ADDS BOLLETS TO THE LAST OF BOLLATS
        /// </summary>
        /// <param name="unitVelocity">The direction of the BULLET</param>
        /// <param name="speed">THE SPED OF THE BULLET</param>
        /// <param name="dmg">THE DARMAGE OF THE BOLLET</param>
        /// <param name="rect">THE BOLLETS RECTANGLE</param>
        /// <param name="text">SOMTHIGN TO DO WITH TEXT... I GUESS MAYBE THE TEXTURE</param>
        /// <param name="playerShot">DID A PLAYER WANT T KILL THEMSELVES? NO GOOD</param>
        /// <param name="beam">LAZOR</param>
        public static void AddProjectile(Vector2 unitVelocity, int speed, int dmg, Rectangle rect, Texture2D text, bool playerShot, bool beam)
        {
            projectiles.Add(new Projectile(unitVelocity, speed, dmg, rect, text, playerShot, beam));
        }

        /// <summary>
        /// DA METHODS TO UPDATE DA BOLLETS
        /// </summary>
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

        /// <summary>
        /// DRAW THE BOLLETS
        /// </summary>
        /// <param name="sb">THE DEVICE TO DRAWR THE BOLLETS</param>
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

        /// <summary>
        /// BYE BYE BOLLATS
        /// </summary>
        public static void Clear()
        {
            projectiles.Clear();
        }
    }
}
