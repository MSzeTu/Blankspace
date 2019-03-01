using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
namespace BlankspaceGame
{
    class PlayerManager
    {
        //Keyboard objects to handle key presses
        KeyboardState kbState;
        KeyboardState pKbState;
        Player player;
        // Variables
        private int cooldown;
        private int currentCD;
        //Constructor
        public PlayerManager(Player initPlayer)
        {
            player = initPlayer;
            cooldown = 5;
            currentCD = 0;
        }

        //Moves the player using wasd, prevents moving off screen
        public void UpdatePlayer(ProjectileManager pm, EnemyManager em)
        {
            kbState = Keyboard.GetState();
            if (player.DamageTick > 0)
            {
                player.DamageTick -= 1;
                player.Color = Color.Red;
            }
            else
            {
                player.Color = Color.White;
            }
            if (kbState.IsKeyDown(Keys.W) && player.Y>=0)
            {
                player.Y -= 6; 
            }
            if (kbState.IsKeyDown(Keys.S) && player.Y<=850)
            {
                player.Y += 6;
            }
            if (kbState.IsKeyDown(Keys.A) && player.X>=0)
            {
                player.X -= 6;
            }
            if (kbState.IsKeyDown(Keys.D) && player.X<=550)
            {
                player.X += 6;
            }
            int collidedIndex = CheckBulletCollision(pm.Projectiles);
            if (collidedIndex != -1 && pm.Projectiles[collidedIndex].PlayerShot == false)
            {
                player.Damage(1);
                player.DamageTick = 1;
                pm.Projectiles.RemoveAt(collidedIndex);
                player.HitSound.Play();
            }
            pKbState = Keyboard.GetState();
        }

        // Weapon firing code
        public bool CheckFireWeapon(KeyboardState kbState)
        {
            if (kbState.IsKeyDown(Keys.Space) && currentCD == 0)
            {
                currentCD = cooldown;
                return true;
            }
            if (currentCD > 0)
            {
                currentCD -= 1;
            }
            return false;
        }

        //Lowers players health by 1 when shot
        public int CheckBulletCollision(List<Projectile> projectiles)
        {
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                if (projectiles[i].PlayerShot == false)
                {
                    if (projectiles[i].Colliding(player))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        //Loads Player Sound Effects
        public void LoadSound(SoundEffect shoot, SoundEffect hit)
        {
            player.HitSound = hit;
            player.ShootSound = shoot;
        }
    }
}
