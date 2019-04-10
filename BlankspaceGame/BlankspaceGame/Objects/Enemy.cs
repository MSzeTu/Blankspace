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

        public Enemy(Rectangle rect, Texture2D text, int hp, Vector2 unitVelIn, int spdIn, EnemyType type) : base(rect, text, hp)
        {
            unitVelocity = unitVelIn;
            speed = spdIn;
            unitVelocity.Normalize();
            this.type = type;
            cooldown = 0;
            attackQueue = new Queue<int>();
        }

        // Move method for moving in target direction
        public void Move()
        {
            if (type == EnemyType.Boss && Y >= 150)
            {
                EnemyManager.BossEnemy = this;
                return;
            }

            Vector2 dir = unitVelocity * speed;

            X += (int)dir.X;
            Y += (int)dir.Y;
        }

        //Checks if bullets have hit enemy
        public int CheckBulletCollision()
        {
            if (Invincible == true)
                return -1;
            

            for (int i = 0; i < ProjectileManager.Projectiles.Count; i++)
            {
                if (ProjectileManager.Projectiles[i].Colliding(this))
                {
                    return i;
                }
            }
            return -1;
        }

        // Returns an int that determines the attack, will add code here for alternate enemy attacks
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
            int value = rand.Next(0, 101);
            // Checks the type of enemy and then rolls to see if it will attack or not
            // Different enemies have different chances to attack and some have multiple attacks
            switch (this.type)
            {
                case EnemyType.Basic:
                    if (value > 90)
                    {
                        attackQueue.Enqueue(1);
                        attackQueue.Enqueue(1);
                        attackQueue.Enqueue(1);
                    }
                    cooldown = 10;
                    return 0;
                case EnemyType.Shotgun:
                    if (value > 90)
                    {
                        attackQueue.Enqueue(2);
                        attackQueue.Enqueue(2);
                    }
                    cooldown = 20;
                    return 0;
                case EnemyType.Tank:
                    if (value > 90)
                    {
                        attackQueue.Enqueue(3);
                    }
                    cooldown = 30;
                    return 0;
                case EnemyType.Boss:
                    if (value > 80)
                    {
                        attackQueue.Enqueue(1);
                        attackQueue.Enqueue(1);
                        attackQueue.Enqueue(1);
                        attackQueue.Enqueue(1);
                        attackQueue.Enqueue(1);
                        attackQueue.Enqueue(1);
                    } else if (value > 60)
                    {
                        attackQueue.Enqueue(2);
                        attackQueue.Enqueue(2);
                        attackQueue.Enqueue(2);
                    } else if (value > 50)
                    {
                        attackQueue.Enqueue(3);
                        attackQueue.Enqueue(3);
                    }
                    cooldown = 10;
                    return 0;
                default:
                    return 0;
            }
        }
    }
}
