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
 * Purpose: Handles player controls and interactions
 * Recent Changes: Created header
 */
namespace BlankspaceGame
{
    class PlayerManager
    {
        //Keyboard objects to handle key presses
        KeyboardState kbState;
        KeyboardState pKbState;
        Player player;
        // Variables
        private int iFrame;
        private int currentCD;
        //Constructor
        public PlayerManager(Player initPlayer)
        {
            player = initPlayer;
            currentCD = 0;
            iFrame = 0;
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
            else if (iFrame > 0)
            {
                iFrame -= 1;
                player.Color = Color.Green;
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
            // Removes health for colliding with projectiles
            int collidedIndex = CheckBulletCollision(pm.Projectiles);
            if (collidedIndex != -1 && pm.Projectiles[collidedIndex].PlayerShot == false && iFrame == 0)
            {
                pm.Projectiles.RemoveAt(collidedIndex);
                player.Damage(1);
                player.DamageTick = 1;
                iFrame = 20;
                player.HitSound.Play();
            }
            // Removes health for colliding with enemies
            int collidedIndexE = CheckEnemyCollision(em.Enemies);
            if (collidedIndexE != -1 && iFrame == 0)
            {
                em.Enemies.RemoveAt(collidedIndexE);
                player.Damage(1);
                player.DamageTick = 1;
                iFrame = 5;
                player.HitSound.Play();
            }
            pKbState = Keyboard.GetState();
        }

        // Weapon firing code
        public bool CheckFireWeapon(KeyboardState kbState, Weapon wep)
        {
            if (kbState.IsKeyDown(Keys.Space) && currentCD == 0)
            {
                currentCD = wep.GetCooldown();
                return true;
            }
            if (currentCD > 0)
            {
                currentCD -= 1;
            }
            return false;
        }

        //Checks if player is trying to switch weapon 
        public bool CheckSwitchWeapon()
        {
            kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.D1) || kbState.IsKeyDown(Keys.D2) || kbState.IsKeyDown(Keys.D3))
            {
                return true;
            }
            pKbState = Keyboard.GetState();
            return false;
        }
        //Changes weapon type by pressing 1 2 or 3
        public Weapon SwitchWeapon()
        {
            Weapon returnWep = new Weapon(Firetype.Dual, Firerate.Fast, Firecolor.Red);
            kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.D1))
            {
                returnWep = new Weapon(Firetype.Dual, Firerate.Fast, Firecolor.Red);               
            }
            if (kbState.IsKeyDown(Keys.D2))
            {
                returnWep = new Weapon(Firetype.Shotgun, Firerate.Fast, Firecolor.Red);
            }
            if (kbState.IsKeyDown(Keys.D3))
            {
                returnWep = new Weapon(Firetype.Beam, Firerate.Fast, Firecolor.Red);
            }
            pKbState = Keyboard.GetState();
            return returnWep;
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

        //Lowers players health by 1 when colliding with enemy
        public int CheckEnemyCollision(List<Enemy> enemies)
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
            {               
                    if (enemies[i].Colliding(player))
                    {
                        return i;
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
