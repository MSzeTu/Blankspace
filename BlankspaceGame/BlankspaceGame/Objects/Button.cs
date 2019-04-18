using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BlankspaceGame.Objects
{
    class Button : GameObject
    {
        // Constructor
        public Button(Rectangle rect, Texture2D text) : base(rect, text)
        { }

        // Clicked property, returns true if the button has the mouse over it and is clicked
        public bool Clicked
        {
            get
            {
                MouseState mState = Mouse.GetState();
                if (
                    // Checks if location is valid
                    mState.X > Position.X && mState.X < Position.X + Position.Width && mState.Y > Position.Y && mState.Y < Position.Y + Position.Height
                    // Checks if the mouse is down
                    && mState.LeftButton == ButtonState.Pressed
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
