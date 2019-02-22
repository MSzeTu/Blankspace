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

        // Constructor
        public EnemyManager()
        {
            enemies = new List<Enemy>();
        }

        // For adding an enemy to the list
        public void AddEnemy(Rectangle rect, Texture2D text, int hp, int speed)
        {
            enemies.Add(new Enemy(rect, text, hp, new Vector2(-1, 0), speed));
        }

        // Called in update to move all enemies at the same time
        public void UpdateEnemies()
        {
            foreach (Enemy i in enemies)
            {
                i.Move();
            }
        }
    }
}
