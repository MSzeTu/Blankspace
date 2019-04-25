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

        // Property that returns true if the button is hovered
        public bool Hovered
        {
            get
            {
                MouseState mState = Mouse.GetState();
                if (mState.X > Position.X && mState.X < Position.X + Position.Width && mState.Y > Position.Y && mState.Y < Position.Y + Position.Height)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /*
         * Overrides draw to draw differently if the button is hovered
         */
        public override void Draw(SpriteBatch sb)
        {
            if (Hovered)
            {
                sb.Draw(texture, position, Color.Red);
            } else
            {
                sb.Draw(texture, position, Color.White);
            }
        }
    }
}
