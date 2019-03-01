using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace BlankspaceGame
{
    class Player : Actor
    {
        //Sets up players sound effects
        SoundEffect hitSound;
        SoundEffect shootSound;
        public SoundEffect HitSound
        {
            get
            {
                return hitSound;
            }
            set
            {
                hitSound = value;
            }
        }
        public SoundEffect ShootSound
        {
            get
            {
                return shootSound;
            }
            set
            {
                shootSound = value;
            }
        }
        // Constructor
        public Player(Rectangle pos, Texture2D text):base(pos, text, 10) // Passes 10 to hp
        {

        }              
    }
}
