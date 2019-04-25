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
 * Purpose: Contains enemies details and fields
 * Recent Changes: Created header
 */
namespace BlankspaceGame
{
    public enum EnemyType
    {
        Basic,
        Shotgun,
        Tank,
        MovingBasic,
        MovingShotgun,
        Boss
    }
    public class Enemy : Actor
    {
        // Fields
        // Info for determining direction
        private Vector2 unitVelocity;
        private int speed;
        private int cooldown;
        private EnemyType type;
        private Queue<int> attackQueue;

        public EnemyType Type
        {
            get { return type; }
        }

        // Despawns if the enemies get too far from the player
        public bool CheckDespawn()
        {
            if (Y > 900)
            {
                return true;
            }
            return false;
        }

        public bool Invincible
        {
            get
            {
                if(Y < -position.Height)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        /*
         * Constructor
         */ 
        public Enemy(Rectangle rect, Texture2D text, int hp, Vector2 unitVelIn, int spdIn, int baseCd, EnemyType type) : base(rect, text, hp)
        {
            unitVelocity = unitVelIn;
            speed = spdIn;
            unitVelocity.Normalize();
            this.type = type;
            cooldown = baseCd;
            attackQueue = new Queue<int>();
        }

        /*
         * Move method for moving in target direction
         */
        public void Move()
        {
            // If enemy is boss, do not move and pass self to the enemymanager
            if (type == EnemyType.Boss && Y >= 150)
            {
                EnemyManager.BossEnemy = this;
                return;
            }
            Vector2 dir = unitVelocity * speed;
            X += (int)dir.X;
            Y += (int)dir.Y;
        }

        /*
         * Checks if bullets have hit enemy
         */
        public int CheckBulletCollision()
        {
            if (Invincible == true)
                return -1;
            
            for (int i = 0; i < ProjectileManager.Projectiles.Count; i++) //Loops through bullets to find the one hitting
            {
                if (ProjectileManager.Projectiles[i].Colliding(this))
                {
                    return i;
                }
            }
            return -1;
        }

        /*
         * Returns an int that determines the attack, will add code here for alternate enemy attacks
         */
        public int CheckForAttack(Random rand)
        {
            // Decrements cooldown if it is nonzero
            if (cooldown > 0)
            {
                cooldown -= 1;
                return 0;
            }
            // If queue is not empty, use that attack
            if (attackQueue.Count > 0)
            {
                cooldown = 5;
                return attackQueue.Dequeue();
            }
            // Checks the type of enemy and then adds its attack to the queue         
            switch (this.type)
            {
                case EnemyType.Basic:
                    attackQueue.Enqueue(1);
                    attackQueue.Enqueue(1);
                    attackQueue.Enqueue(1);
                    cooldown = rand.Next(50, 150);
                    return 0;
                case EnemyType.Shotgun:
                    attackQueue.Enqueue(2);
                    attackQueue.Enqueue(2);
                    cooldown = rand.Next(50, 150);
                    return 0;
                case EnemyType.Tank:
                    attackQueue.Enqueue(3);
                    cooldown = rand.Next(100, 200);
                    return 0;
                case EnemyType.Boss: // Boss enemy has random object to decide which attack to use
                    int value = rand.Next(0, 3);
                    if (value == 0)
                    {
                        attackQueue.Enqueue(4);
                        attackQueue.Enqueue(4);
                        attackQueue.Enqueue(4);
                        attackQueue.Enqueue(4);
                        attackQueue.Enqueue(4);
                        attackQueue.Enqueue(4);
                    } else if (value == 2)
                    {
                        attackQueue.Enqueue(5);
                        attackQueue.Enqueue(5);
                        attackQueue.Enqueue(5);
                    } else if (value == 3)
                    {
                        attackQueue.Enqueue(3);
                        attackQueue.Enqueue(3);
                    }
                    cooldown = 20;
                    return 0;
                default:
                    return 0;
            }
        }
    }
}
