using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
/*Name: Blank Space
 * Class: IGME106
 * Author: WIP
 * Purpose: Will handle pickups
 * Recent Changes: Created header
 */
namespace BlankspaceGame
{
    //Defines pickup type
    public enum Type
    {
        Health,
        Bomb,
        Points,
        Mine
    }
    class Pickup : GameObject
    {   
        
        Type pType;
        public Type PType
        {
            get
            {
                return pType;
            }
        }

        //Constructor
        public Pickup(Type type, Rectangle rect, Texture2D text) : base(rect, text)
        {
            this.position = rect;
            pType = type;
        }

        /*
         * Moves the pickups down the screen
         */
        public void Move()
        {
            this.Y++;
        }

    }
}
