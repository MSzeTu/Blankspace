using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
/*Name: Blank Space
 * Class: IGME106
 * Author: WIP
 * Purpose: Contains player object and fields
 * Recent Changes: Created header
 */
namespace BlankspaceGame
{
    public class Player : Actor
    {
        //Sets up players sound effects
        SoundEffect hitSound;
        SoundEffect shootSound;
        SoundEffect blankSound;
        public SoundEffect BlankSound
        { get { return blankSound; }
            set { blankSound = value; }
        }
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
