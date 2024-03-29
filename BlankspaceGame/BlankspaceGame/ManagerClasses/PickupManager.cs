﻿using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace BlankspaceGame
{
    static class PickupManager
    {
        //Pickup textures 
        static Texture2D heart;
        static Texture2D bombs;
        static Texture2D pointT;
        static Texture2D boom;
        static Texture2D mine;
        static SoundEffect powerSound;
        //Lists of pickups
        static private List<Pickup> pickups;
        static public List<Pickup> Pickups
        {
            get
            {
                return pickups;
            }
        }

        /*
         * Intializes the manager
         */ 
        static public void Intialize()
        {
            pickups = new List<Pickup>();
        }

        /*
         * Removes Pickup at target position
         */
        public static void RemovePickAt(int index)
        {
            pickups.RemoveAt(index);
        }

        /*
         * Adds pickups to list of pickups
         */
        public static void AddPickup(Type pickupTy, Rectangle position, Texture2D text)
        {
            Pickups.Add(new Pickup(pickupTy, new Rectangle(position.X, position.Y, 20, 20), text));
        }

        /*
         * Updates pickups
         */
        public static void UpdatePickup()
        {
            //Test if list is empty
            if (!(pickups.Count < 0))
            {
                //Loop through pickups
                for (int i = 0; i < pickups.Count; i++)
                {
                    //Call movement and check for collisions/off-screen
                    pickups[i].Move();
                    if (pickups[i].Y > 850)
                    {
                        pickups.RemoveAt(i);
                    }
                }
            }
        }

        /*
         * Triggers pickup effect based on pickup type
         */
        public static int TriggerEffect(Pickup p)
        {
            if (p.PType != Type.Mine)
            {
                powerSound.Play();
            } 
            //Checks pickup type for effects
            switch (p.PType)
            {
                case Type.Health:
                    {
                        return 1;
                    }
                case Type.Bomb:
                    {
                        for (int k = -1; k <= 1; k++)
                        {
                            for (int i = -1; i <= 1; i++)
                            {
                                if (i != 0 || k != 0)
                                {
                                    for (int n = 0; n < 10; n++)
                                    {
                                        ProjectileManager.AddProjectile(new Vector2(k, i), 10, 1, new Rectangle(p.X - 25+(n*10), p.Y - 25+(n*10), 10, 10), boom, true, false);
                                    }
                                }
                            }
                        }
                        PlayerManager.ScreenShakeMethod(25);
                        break;
                    }
                case Type.Points:
                    {
                        PlayerManager.Score += 100;
                        break;
                    }
                case Type.Mine:
                    {
                        return 2;
                    }
            }
            return 0;
        }

        /*
         * Decides if Pickup should spawn 
         */
        public static void Drop(Enemy source, Random roll)
        {
            int chance = roll.Next(1, 101);
            int typeChance;
            if (source.Type == EnemyType.Boss) //Places coins if Boss dies
            {
                for (int j = 0; j < 5; j++)
                {
                    AddPickup(Type.Points, new Rectangle(source.X+roll.Next(0,50) + (source.Position.Width / 2), source.Y + roll.Next(0, 50), 20,20), pointT);
                    AddPickup(Type.Points, new Rectangle(source.X+(source.Position.Width / 2)-roll.Next(0, 50), source.Y - roll.Next(0, 50), 20, 20), pointT);
                }
            }
            //Randomly chooses pickup type
            else if (chance <= 20)
            {
                typeChance = roll.Next(1, 21);
                if (typeChance <= 4)
                {
                    AddPickup(Type.Health, source.Position, heart);
                }
                else if (typeChance > 4 && typeChance < 8)
                {
                    AddPickup(Type.Bomb, source.Position, bombs);
                }
                else if (typeChance > 8 && typeChance < 18)
                {
                    AddPickup(Type.Points, source.Position, pointT);
                }
                else if (typeChance >= 18)
                {
                    AddPickup(Type.Mine, source.Position, mine);
                }
            }
        }

        /*
         * Loads pickups textures
         */
        public static void LoadTextures(Game1 game)
        {
            heart = game.Content.Load<Texture2D>("Pickups/heart");
            bombs = game.Content.Load<Texture2D>("Pickups/Laser");
            pointT = game.Content.Load<Texture2D>("Pickups/Coin");
            mine = game.Content.Load<Texture2D>("Pickups/Reverse");
            boom = game.Content.Load<Texture2D>("Projectiles/Explosion");
            powerSound = game.Content.Load<SoundEffect>("Sounds/Pickup_Sound");
        }

        /*
         * Draws pickups
         */
        public static void DrawPickups(SpriteBatch sb)
        {
            if (!(pickups.Count < 0))
            {
                foreach (Pickup p in pickups)
                {
                    p.Draw(sb);
                }
            }
        }
    }
}

