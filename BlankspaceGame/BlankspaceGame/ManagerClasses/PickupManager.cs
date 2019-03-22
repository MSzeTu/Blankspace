using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlankspaceGame
{
    static class PickupManager
    {
        //Pickup textures 
        static Texture2D heart;
        static Texture2D bombs;
        static Texture2D pointT;
        static Texture2D fireBuff;
        static public Texture2D Heart
        {
            get
            {
                return heart;
            }
        }
        static public Texture2D Bombs
        {
            get
            {
                return bombs;
            }
        }
        static public Texture2D PointT
        {
            get
            {
                return pointT;
            }
        }
        static public Texture2D FireBuff
        {
            get
            {
                return fireBuff;
            }
        }

        //Lists of pickups
        static private List<Pickup> pickups;
        static public List<Pickup> Pickups
        {
            get
            {
                return pickups;
            }
        }

        static public void Intialize()
        {
            pickups = new List<Pickup>();
        }

        //Removes Pickup at target position
        public static void RemovePickAt(int index)
        {
            pickups.RemoveAt(index);
        }

        //Adds pickups to list of pickups
        public static void AddPickup(Type pickupTy, Rectangle position, Texture2D text)
        {
            Pickups.Add(new Pickup(pickupTy, new Rectangle(position.X, position.Y, 20,20), text));
        }

        //Updates pickups
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

        //Triggers pickup effect based on pickup type
        public static int TriggerEffect(Type pType)
        {
            switch (pType)
            {
                case Type.Health:
                    {
                        return 1;
                        break;
                    }
                case Type.Bomb:
                    {
                        break;
                    }
                case Type.Points:
                    {
                        break;
                    }
                case Type.Buff:
                    {
                        break;
                    }
            }
            return 0;
        }

        //Decides if Pickup should spawn 
        public static void Drop(Enemy source)
        {
            Random roll = new Random();
            int chance = roll.Next(1,101);
            int typeChance;
            if (chance <= 900)
            {
                typeChance = roll.Next(1, 21);
                if (typeChance <= 900)
                {
                    AddPickup(Type.Health, source.Position, heart);
                }
            }
        }

        //Loads pickups textures
        public static void LoadTextures(Game1 game)
        {
            heart = game.Content.Load<Texture2D>("Pickups/heart");
        }

        //Draws pickups
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

