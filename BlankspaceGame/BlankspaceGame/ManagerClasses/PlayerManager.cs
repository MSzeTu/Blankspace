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
    static class PlayerManager
    {
        //Keyboard objects to handle key presses
        static KeyboardState kbState;
        static KeyboardState pKbState;
        static Player player;
        static Texture2D solidTexture;
        // Variables
        static private int iFrame;
        static private int currentCD;
        static private int score;
        static private int highScore;
        static private string weaponType;
        static Boolean rControls;

        // Mouse control variables
        static private bool mouseControl = false;
        static private float mouseMoveSpeed = 10;

        static public bool MouseControl
        {
            get
            {
                return mouseControl;
            }
            set
            {
                mouseControl = value;
            }
        }

        static public Boolean RControls
        {
            get
            {
                return rControls;
            }
            set
            {
                rControls = value;
            }
        }
        static private float screenShake;

        static public int HighScore
        {
            get { return highScore;}
        }
        static public string WeaponType
        {
            get { return weaponType; }
            set { weaponType = value; }
        }
        static public int Score
        {
            get { return score; }
            set { score = value; }
        }
        static public int X
        {
            get { return player.X; }
        }
        static public int Y
        {
            get { return player.Y; }
        }
        static public int IFrame
        {
            get { return iFrame; }
            set { iFrame = value; }
        }

        static public float ScreenShake
        {
            get
            {
                return screenShake;
            }
            set
            {
                screenShake = value;
            }
        }

        //Constructor
        static public void Initialize(Player initPlayer)
        {
            player = initPlayer;
            currentCD = 0;
            iFrame = 0;
            score = 0;
            highScore = 0;
            rControls = false;
        }

        //Moves the player using wasd, prevents moving off screen
        static public void UpdatePlayer()
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
            if (rControls)
            {
                // Mouse control
                if (mouseControl)
                {
                    // Set the player position to the mouse position
                    MouseState ms = Mouse.GetState();
                    int mX = ms.Position.Y;
                    int mY = ms.Position.X;
                    int shipX = player.X;
                    int shipY = player.Y;
                    int width = player.Position.Width;
                    int height = player.Position.Height;

                    Vector2 playerPos = Vector2.Lerp(new Vector2(shipX, shipY), new Vector2(mX - width / 2, mY - height / 2), mouseMoveSpeed * (1f / 60f));

                    player.X = (int)playerPos.X;
                    player.Y = (int)playerPos.Y;

                    if (player.X < 0)
                        player.X = 0;
                    if (player.X > 550)
                        player.X = 550;
                    if (player.Y < 0)
                        player.Y = 0;
                    if (player.Y > 850)
                        player.Y = 850;
                } else
                {
                    if (kbState.IsKeyDown(Keys.W) && player.Y <= 860)
                    {
                        player.Y += 6;
                    }
                    if (kbState.IsKeyDown(Keys.S) && player.Y >= 0)
                    {
                        player.Y -= 6;
                    }
                    if (kbState.IsKeyDown(Keys.A) && player.X <= 560)
                    {
                        player.X += 6;
                    }
                    if (kbState.IsKeyDown(Keys.D) && player.X >= 0)
                    {
                        player.X -= 6;
                    }
                }
            }
            else
            {
                // Mouse control
                if (mouseControl)
                {
                    // Set the player position to the mouse position
                    MouseState ms = Mouse.GetState();
                    int mX = ms.Position.X;
                    int mY = ms.Position.Y;
                    int shipX = player.X;
                    int shipY = player.Y;
                    int width = player.Position.Width;
                    int height = player.Position.Height;

                    Vector2 playerPos = Vector2.Lerp(new Vector2(shipX, shipY), new Vector2(mX - width / 2, mY - height / 2), mouseMoveSpeed * (1f / 60f));

                    player.X = (int)playerPos.X;
                    player.Y = (int)playerPos.Y;

                    if (player.X < 0)
                        player.X = 0;
                    if (player.X > 550)
                        player.X = 550;
                    if (player.Y < 0)
                        player.Y = 0;
                    if (player.Y > 850)
                        player.Y = 850;
                } else
                {
                    if (kbState.IsKeyDown(Keys.W) && player.Y >= 0)
                    {
                        player.Y -= 6;
                    }
                    if (kbState.IsKeyDown(Keys.S) && player.Y <= 850)
                    {
                        player.Y += 6;
                    }
                    if (kbState.IsKeyDown(Keys.A) && player.X >= 0)
                    {
                        player.X -= 6;
                    }
                    if (kbState.IsKeyDown(Keys.D) && player.X <= 550)
                    {
                        player.X += 6;
                    }

                }
            }

            // Removes health for colliding with projectiles
            int collidedIndex = CheckBulletCollision();
            if (collidedIndex != -1 && ProjectileManager.Projectiles[collidedIndex].PlayerShot == false && iFrame == 0)
            {
                player.Damage(ProjectileManager.Projectiles[collidedIndex].Damage);
                player.DamageTick = 1;
                iFrame = 20;
                player.HitSound.Play();
                ProjectileManager.Projectiles.RemoveAt(collidedIndex);
            }
            // Removes health for colliding with enemies
            int collidedIndexE = CheckEnemyCollision();
            if (collidedIndexE != -1 && iFrame == 0)
            {
                EnemyManager.Enemies.RemoveAt(collidedIndexE);
                player.Damage(1);
                player.DamageTick = 1;
                iFrame = 5;
                player.HitSound.Play();
            }
            //Triggers effect when colliding with Pickups
            int collidedIndexPi = CheckPickupCollision();
            if (collidedIndexPi != -1)
            {
                if (PickupManager.TriggerEffect(PickupManager.Pickups[collidedIndexPi]) == 1)
                {                    
                    player.Health++;
                }
                else if (PickupManager.TriggerEffect(PickupManager.Pickups[collidedIndexPi]) == 2)
                {
                    if (rControls == false)
                    {
                        rControls = true;
                    }
                    else if (rControls)
                    {
                        rControls = false;
                    }
                    
                }
                PickupManager.RemovePickAt(collidedIndexPi);
            }
            pKbState = Keyboard.GetState();
        }

        // Draw method for player and effects
        public static void DrawPlayer(SpriteBatch sb)
        {
            if (player.Health > 0)
            {
                player.Draw(sb);
            }
            // Draws red overlay when damaged
            if (iFrame > 0)
            {
                sb.Draw(solidTexture, new Rectangle(0, 0, 600, 900), new Color(50, 0, 0, iFrame * 4));
            }
        }

        // Weapon firing code
        static public bool CheckFireWeapon(KeyboardState kbState, Weapon wep)
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
        static public bool CheckSwitchWeapon()
        {
            kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.D1) || kbState.IsKeyDown(Keys.D2) || kbState.IsKeyDown(Keys.D3) || kbState.IsKeyDown(Keys.E))
            {
                return true;
            }
            pKbState = Keyboard.GetState();
            return false;
        }
        //Changes weapon type by pressing 1 2 or 3
        static public Weapon SwitchWeapon()
        {
            Weapon returnWep = new Weapon(Firetype.Dual, Firerate.Fast, Firecolor.Red);
            kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.D1))
            {
                returnWep = new Weapon(Firetype.Dual, Firerate.Fast, Firecolor.Red);
                weaponType = "Machine Gun";
            }
            if (kbState.IsKeyDown(Keys.D2))
            {
                returnWep = new Weapon(Firetype.Shotgun, Firerate.Fast, Firecolor.Red);
                weaponType = "Shotgun";
            }
            if (kbState.IsKeyDown(Keys.D3))
            {   
                returnWep = new Weapon(Firetype.Beam, Firerate.Fast, Firecolor.Red);
                weaponType = "Beam";
            }
            //God Mode
            if (kbState.IsKeyDown(Keys.E))
            {
                returnWep = new Weapon(Firetype.Erin, Firerate.Fast, Firecolor.Red);
                weaponType = "Erin";
                player.Health = 900;
            }
            pKbState = Keyboard.GetState();
            return returnWep;
        }

        static public void ScreenShakeMethod(int amt)
        {
            screenShake += amt;
        }

        //Lowers players health by 1 when shot
        static public int CheckBulletCollision()
        {
            for (int i = ProjectileManager.Projectiles.Count - 1; i >= 0; i--)
            {
                if (ProjectileManager.Projectiles[i].PlayerShot == false)
                {
                    if (ProjectileManager.Projectiles[i].Colliding(player))
                    {
                        ScreenShakeMethod(10);
                        return i;
                    }
                }
            }
            return -1;
        }

        //Lowers players health by 1 when colliding with enemy
        static public int CheckEnemyCollision()
        {
            for (int i = EnemyManager.Enemies.Count - 1; i >= 0; i--)
            {
                if (EnemyManager.Enemies[i].Colliding(player))
                {
                    ScreenShakeMethod(50);
                    return i;
                }
            }
            return -1;
        }

        //Checks for pickup collision
        public static int CheckPickupCollision()
        {
            for (int i = PickupManager.Pickups.Count - 1; i >= 0; i--)
            {
                if (PickupManager.Pickups[i].Colliding(player))
                {
                    return i;
                }    
            }
            return -1;
        }

        //Loads Player Sound Effects
        static public void LoadSound(SoundEffect shoot, SoundEffect hit)
        {
            player.HitSound = hit;
            player.ShootSound = shoot;
        }

        // Loads playermanager content
        static public void LoadContent(Game game)
        {
            solidTexture = game.Content.Load<Texture2D>("Effects/solidTexture");
            player.HitSound = game.Content.Load<SoundEffect>("Sounds/Explosion");
            player.ShootSound = game.Content.Load<SoundEffect>("Sounds/Laser_Sound");
        }

        //Saves high score 
        static public void SetHighScore()
        {
            if (score > highScore)
            {
                highScore = score;
            }
        }
    }
}
