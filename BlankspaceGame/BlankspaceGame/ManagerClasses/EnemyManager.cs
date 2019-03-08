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
 * Purpose: Handles enemy movement and interactions
 * Recent Changes: Created header
 */
namespace BlankspaceGame
{
    class EnemyManager
    {
        // List of enemies
        private List<Enemy> enemies;
        public List<Enemy> Enemies
        {
            get
            {
                return enemies;
            }
        }

        // Sprites and sounds
        Texture2D defEnemy;
        Texture2D projectiles;
        SoundEffect hitEnemy;
        SoundEffect enemyShoots;
        // Constructor
        public EnemyManager()
        {
            enemies = new List<Enemy>();
        }

        // Loads enemy sprites to the manager
        public void LoadDefaultEnemy(Texture2D tex, Texture2D projectile, SoundEffect hit, SoundEffect shoot)
        {
            defEnemy = tex;
            projectiles = projectile;
            hitEnemy = hit;
            enemyShoots = shoot;
        }

        // For adding an enemy to the list
        /// <summary>
        /// Adds an enemy to the list
        /// </summary>
        /// <param name="rect">Rectangle which defines size and location, should be handled when reading in</param>
        /// <param name="text">Texture of the enemy, use the saved textures in the EnemyManager</param>
        /// <param name="hp">Health value, should be a value between 10 and 100</param>
        /// <param name="speed">Speed of the enemy, should be a value between XXXXXXXX</param>
        public void AddEnemy(Rectangle rect, Texture2D text, int hp, int speed)
        {
            enemies.Add(new Enemy(rect, text, hp, new Vector2(0, 1), speed));
        }

        // Called in update to move all enemies at the same time
        public void UpdateEnemies(ProjectileManager pm)
        {
            // Moves the enemies
            foreach (Enemy i in enemies)
            {
                i.Move();
                // If damage tick is not 0, decrement and set colors
                if (i.DamageTick > 0)
                {
                    pm.AddProjectile(new Vector2(0, 1), 10, new Rectangle(i.X + 19, i.Y, 10, 10), projectiles, false, false);
                    i.DamageTick -= 1;
                    i.Color = Color.Red;
                    hitEnemy.Play();
                } else
                {
                    i.Color = Color.White;
                }
            }
            // Main loop for checking all enemies
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                // Hurting enemies if they are hit by a bullet
                // Index which tracks which bullet is colliding
                int collidedIndex = enemies[i].CheckBulletCollision(pm.Projectiles);
                if (collidedIndex != -1 && pm.Projectiles[collidedIndex].PlayerShot == true)
                {
                    enemies[i].Damage(1);
                    enemies[i].DamageTick = 1;
                    // Removes bullet which hit enemy
                    if (pm.Projectiles[collidedIndex].Beam == false)
                    {
                        pm.RemoveProjAt(collidedIndex);
                    }
                }
                // Checks for health and deletes ones with no health
                if (enemies[i].Health <= 0 || enemies[i].CheckDespawn())
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int p = -1; p <= 1; p++)
                        {
                            if (p != 0 || k != 0)
                            {
                                pm.AddProjectile(new Vector2(k, p), 10, new Rectangle(enemies[i].X + 19, enemies[i].Y, 10, 10), projectiles, false, false);
                            }
                        }
                    }
                    enemies.RemoveAt(i);
                }
            }
        }

        // Called in draw to draw all enemies at the same time
        public void DrawEnemies(SpriteBatch sb)
        {
            foreach (Enemy i in enemies)
            {
                i.Draw(sb);
            }
        }

        // DEBUG test enemy spawns
        public void DebugEnemyTest()
        {
            AddEnemy(new Rectangle(300, 200, 48, 40), defEnemy, 10, 2);
            AddEnemy(new Rectangle(100, 200, 48, 40), defEnemy, 10, 2);
            AddEnemy(new Rectangle(50, 300, 48, 40), defEnemy, 10, 2);
            AddEnemy(new Rectangle(100, 300, 48, 40), defEnemy, 10, 2);
        }

        // DEBUG auto enemy spawn
        public void DebugEnemyRespawn()
        {
            if (enemies.Count < 4)
            {
                Random rand = new Random();
                AddEnemy(new Rectangle(rand.Next(0, 560), 100, 48, 40), defEnemy, 10, 2);
            }
        }
    }
}
