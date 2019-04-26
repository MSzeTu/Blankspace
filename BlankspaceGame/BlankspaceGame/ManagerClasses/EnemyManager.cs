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
    static class EnemyManager
    {
        // CONST
        const int BULLET_SPEED = 7;

        // List of enemies
        static private List<Enemy> enemies;
        static public List<Enemy> Enemies
        {
            get
            {
                return enemies;
            }
        }
        static public int EnemyCount
        {
            get
            {
                return enemies.Count;
            }
        }

        // Sprites and sounds
        static Texture2D enemyBasic;
        static Texture2D enemyShotgun;
        static Texture2D enemyTank;
        static Texture2D enemyBoss;
        static Texture2D projectiles;
        static Texture2D box;
        static SoundEffect hitEnemy;
        static SoundEffect enemyShoots;

        // Reference for boss enemy
        static private Enemy bossEnemy;

        public static Enemy BossEnemy
        {
            get { return bossEnemy; }
            set { bossEnemy = value; }
        }

        // Initializes default values
        public static void Initialize()
        {
            enemies = new List<Enemy>();
        }

        // Loads enemy sprites to the manager
        static public void LoadEnemyContent(Game g)
        {
            enemyBasic = g.Content.Load<Texture2D>("Enemy/EnemyBasic");
            enemyShotgun = g.Content.Load<Texture2D>("Enemy/EnemyShotgun");
            enemyTank = g.Content.Load<Texture2D>("Enemy/EnemyTank");
            enemyBoss = g.Content.Load<Texture2D>("Enemy/Boss");
            box = g.Content.Load<Texture2D>("Effects/solidTexture");
            projectiles = g.Content.Load<Texture2D>("Projectiles/Projectile");
            hitEnemy = g.Content.Load<SoundEffect>("Sounds/Explosion");
            enemyShoots = g.Content.Load<SoundEffect>("Sounds/EnemyShot");
        }

        // For adding an enemy to the list
        /// <summary>
        /// Adds an enemy to the list
        /// </summary>
        /// <param name="rect">Rectangle which defines size and location, should be handled when reading in</param>
        /// <param name="text">Texture of the enemy, use the saved textures in the EnemyManager</param>
        /// <param name="hp">Health value, should be a value between 10 and 100</param>
        /// <param name="speed">Speed of the enemy, should be a value between XXXXXXXX</param>
        static public void AddEnemy(Rectangle rect, EnemyType type)
        {
            Texture2D text = enemyBasic;
            int hp = 1;
            int speed = 1;
            Random rand = new Random();
            // Determines stats based on enemy type
            switch (type)
            {
                case EnemyType.Basic:
                    text = enemyBasic;
                    hp = 3;
                    speed = 2;
                    break;
                case EnemyType.Shotgun:
                    text = enemyShotgun;
                    hp = 5;
                    speed = 2;
                    break;
                case EnemyType.Tank:
                    text = enemyTank;
                    hp = 15;
                    speed = 2;
                    break;
                case EnemyType.Boss:
                    text = enemyBoss;
                    hp = 400;
                    speed = 2;
                    break;
            }

            enemies.Add(new Enemy(rect, text, hp, new Vector2(0, 1), speed, rand.Next(5, 30), type));
        }

        // Called in update to move all enemies at the same time
        static public void UpdateEnemies()
        {
            Random rand = new Random();
            // Moves the enemies
            foreach (Enemy i in enemies)
            {
                // Boss points for left and right attacks
                Point left = new Point(i.X + i.Position.Width / 2 - 25, i.Y + i.Position.Height);
                Point right = new Point(i.X + i.Position.Width / 2 + 25, i.Y + i.Position.Height);

                // Normal enemy firing point
                Point center = new Point(i.X + i.Position.Width / 2, i.Y + i.Position.Height);

                // Target for the shots (Center of the player)
                Point playerTarget = new Point(PlayerManager.X + PlayerManager.Position.Width / 2, PlayerManager.Y + PlayerManager.Position.Height / 2);

                i.Move();
                // If damage tick is not 0, decrement and set colors (This means the enemy is recovering from being hit)
                if (i.DamageTick > 0)
                {
                    i.DamageTick -= 1;
                    i.Color = Color.Red;
                    hitEnemy.Play();
                }
                else
                {
                    i.Color = Color.White;
                }
                // Does check for enemies to fire shots at player
                switch (i.CheckForAttack(rand))
                {
                    case 1:
                        // Fires one projectile at the player
                        enemyShoots.Play(volume: 0.3f, pitch: 0.0f, pan: 0.0f);
                        ProjectileManager.AddProjectile(new Vector2(playerTarget.X - center.X, playerTarget.Y - center.Y), 10, 1, new Rectangle(center, new Point(10, 10)), projectiles, false, false);
                        break;
                    case 2:
                        // Fires a cone of 3 projectiles at the player
                        enemyShoots.Play(volume: 0.3f, pitch: 0.0f, pan: 0.0f);
                        ProjectileManager.AddProjectile(new Vector2(playerTarget.X - center.X + 50, playerTarget.Y - center.Y), 10, 1, new Rectangle(center, new Point(10, 10)), projectiles, false, false);
                        ProjectileManager.AddProjectile(new Vector2(playerTarget.X - center.X, playerTarget.Y - center.Y), 10, 1, new Rectangle(center, new Point(10, 10)), projectiles, false, false);
                        ProjectileManager.AddProjectile(new Vector2(playerTarget.X - center.X - 50, playerTarget.Y - center.Y), 10, 1, new Rectangle(center, new Point(10, 10)), projectiles, false, false);
                        break;
                    case 3:
                        // Fires a circle of projectiles around the enemy
                        enemyShoots.Play(volume: 0.3f, pitch: 0.0f, pan: 0.0f);
                        for (int k = -1; k <= 1; k++)
                        {
                            for (int p = -1; p <= 1; p++)
                            {
                                if (p != 0 || k != 0)
                                {
                                    ProjectileManager.AddProjectile(new Vector2(k, p), 10, 1, new Rectangle(i.X + i.Position.Width / 2, i.Y + i.Position.Height, 10, 10), projectiles, false, false);
                                }
                            }
                        }
                        break;
                    case 4:
                        // BOSS version of case 1, firing one bullet
                        enemyShoots.Play(volume: 0.3f, pitch: 0.0f, pan: 0.0f);
                        ProjectileManager.AddProjectile(new Vector2(playerTarget.X - left.X, playerTarget.Y - left.Y), 10, 1, new Rectangle(left, new Point(10, 10)), projectiles, false, false);
                        ProjectileManager.AddProjectile(new Vector2(playerTarget.X - right.X, playerTarget.Y - right.Y), 10, 1, new Rectangle(right, new Point(10, 10)), projectiles, false, false);
                        break;
                    case 5:
                        // BOSS version of case 2, shotgun attack
                        enemyShoots.Play(volume: 0.3f, pitch: 0.0f, pan: 0.0f);
                        // This section fires the left side
                        ProjectileManager.AddProjectile(new Vector2(playerTarget.X - left.X + 50, playerTarget.Y - left.Y), 10, 1, new Rectangle(left, new Point(10, 10)), projectiles, false, false);
                        ProjectileManager.AddProjectile(new Vector2(playerTarget.X - left.X, playerTarget.Y - left.Y), 10, 1, new Rectangle(left, new Point(10, 10)), projectiles, false, false);
                        ProjectileManager.AddProjectile(new Vector2(playerTarget.X - left.X - 50, playerTarget.Y - left.Y), 10, 1, new Rectangle(left, new Point(10, 10)), projectiles, false, false);
                        // This section fires the right side
                        ProjectileManager.AddProjectile(new Vector2(playerTarget.X - right.X + 50, playerTarget.Y - right.Y), 10, 1, new Rectangle(right, new Point(10, 10)), projectiles, false, false);
                        ProjectileManager.AddProjectile(new Vector2(playerTarget.X - right.X, playerTarget.Y - right.Y), 10, 1, new Rectangle(right, new Point(10, 10)), projectiles, false, false);
                        ProjectileManager.AddProjectile(new Vector2(playerTarget.X - right.X - 50, playerTarget.Y - right.Y), 10, 1, new Rectangle(right, new Point(10, 10)), projectiles, false, false);
                        break;
                    default:
                        // Do nothing
                        break;
                }
            }
            // Main loop for checking all enemies
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                // Hurting enemies if they are hit by a bullet
                // Index which tracks which bullet is colliding
                int collidedIndex = enemies[i].CheckBulletCollision();
                if (collidedIndex != -1 && ProjectileManager.Projectiles[collidedIndex].PlayerShot == true)
                {
                    enemies[i].Damage(ProjectileManager.Projectiles[collidedIndex].Damage);
                    enemies[i].DamageTick = 1;
                    if (enemies[i].Health <= 0)
                    {
                        PlayerManager.Score += 100;
                        PickupManager.Drop(enemies[i], rand);
                    }
                    // Removes bullet which hit enemy
                    if (ProjectileManager.Projectiles[collidedIndex].Beam == false)
                    {
                        ProjectileManager.RemoveProjAt(collidedIndex);
                    }
                }
                // Checks for health and deletes ones with no health, also creates explosion when an enemy dies and might drop pickup
                if (enemies[i].Health <= 0 || enemies[i].CheckDespawn())
                {
                    // Creates explosion if enemy is a tank type
                    if (enemies[i].Type == EnemyType.Tank)
                    {
                        for (int k = -1; k <= 1; k++)
                        {
                            for (int p = -1; p <= 1; p++)
                            {
                                if (p != 0 || k != 0)
                                {
                                    ProjectileManager.AddProjectile(new Vector2(k, p), 10, 1, new Rectangle(enemies[i].X + 19, enemies[i].Y, 10, 10), projectiles, false, false);
                                }
                            }
                        }
                    }
                    enemies.RemoveAt(i);
                }
            }
        }

        // Called in draw to draw all enemies at the same time
        static public void DrawEnemies(SpriteBatch sb)
        {
            foreach (Enemy i in enemies)
            {
                i.Draw(sb);
            }
            DrawHealthBar(sb);
        }

        // Health Bar logic (Might break if more than one boss exists, idk yet lol)
        static private void DrawHealthBar(SpriteBatch sb)
        {
            // Draws the health bar if the boss is not null
            if (bossEnemy != null)
            {
                sb.Draw(box, new Rectangle(20, 50, 25, 2 * bossEnemy.Health), Color.Red);
            }
        }

    }
}
