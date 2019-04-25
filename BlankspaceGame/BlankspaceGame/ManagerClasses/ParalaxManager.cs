using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
/*Name: Blank Space
 * Class: IGME106
 * Author: WIP
 * Purpose: Handles the paralax of the background
 * Recent Changes: Created header
 */
namespace BlankspaceGame
{
    static class ParalaxManager
    {
        private static Texture2D bGround;

        private static Rectangle p1;
        private static Rectangle p2;

        /*
         * Initializes background layers
         */
        public static void Initialize ()
        {
            p1 = new Rectangle(0, 0, 600, 1250);
            p2 = new Rectangle(0, -1250, 600, 1250);
        }

        /*
         * Sets layers
         */
        public static void SetTexture(Texture2D background)
        {
            bGround = background;
        }

        /*
         * Updates the background movement
         */ 
        public static void Update(SpriteBatch sb)
        {
            if (p1.Y >= 900)
                p1.Y = -1250 - 350;
            if (p2.Y >= 900)
                p2.Y = -1250 - 350;

            p1.Y++;
            p2.Y++;

            Draw(sb);
        }

        /*
         * Actually draws the background
         */ 
        private static void Draw(SpriteBatch sb)
        {
            // Draw the background
            sb.Draw(bGround, p1, Color.White);
            sb.Draw(bGround, p2, Color.White);
        }
    }
}
