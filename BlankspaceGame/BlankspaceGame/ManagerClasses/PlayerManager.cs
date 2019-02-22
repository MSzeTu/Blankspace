using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace BlankspaceGame
{
    class PlayerManager
    {
        Texture2D player;
        Rectangle playerRec;

        //Initializes player position and texture
        public void AddPlayer(Texture2D playerTex, Rectangle playerPos)
        {
            player = playerTex;
            playerRec = playerPos;
        }

        //Draws the player at their initial position
        public void Draw(SpriteBatch sb)
        {           
            sb.Draw(player, playerRec, Color.White);
        }
    }
}
