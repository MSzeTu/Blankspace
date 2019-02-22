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
        //Keyboard objects to handle key presses
        KeyboardState kbState;
        KeyboardState pKbState;
        Player player;
        //Constructor
        public PlayerManager(Player initPlayer)
        {
            player = initPlayer;
        }

        //Moves the player using wasd
        public void MovePlayer()
        {
            kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.W))
            {
                player.X += 6; 
            }
            pKbState = Keyboard.GetState();
        }
    }
}
