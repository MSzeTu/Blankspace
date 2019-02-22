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
    class EnemyManager
    {
        // List of enemies
        private List<Enemy> enemies;

        // Sprites
        Texture2D defEnemy;

        // Constructor
        public EnemyManager()
        {
            enemies = new List<Enemy>();
        }

        // Loads enemy sprites to the manager
        public void LoadDefaultEnemy(Texture2D tex)
        {
            defEnemy = tex;
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
        public void UpdateEnemies()
        {
            foreach (Enemy i in enemies)
            {
                i.Move();
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
            AddEnemy(new Rectangle(50, 200, 48, 40), defEnemy, 10, 5);
            AddEnemy(new Rectangle(100, 200, 48, 40), defEnemy, 10, 5);
            AddEnemy(new Rectangle(50, 300, 48, 40), defEnemy, 10, 5);
            AddEnemy(new Rectangle(100, 300, 48, 40), defEnemy, 10, 5);
        }
    }
}
