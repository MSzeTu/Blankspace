﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankspaceGame
{
    /// <summary>
    /// Hello I did the PE late my name is Will
    /// This is IKE MCNUTT reporting for duty
    /// Matthew Sze-Tu is here and ready to go!
    /// This is Patrick Monaghan reporting for duty!
    /// Made project MAC compatable
    /// </summary>

    //Enum for determining current GameState
    public enum GameState
    {
        Menu,
        Game,
        GameOver
    }
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Keyboard objects to handle key presses
        KeyboardState kbState;
        KeyboardState pKbState;
        GameState gState;
        PlayerManager playerManager;
        Texture2D player;
        Texture2D projectile;
        ProjectileManager projectileManager;
        EnemyManager enemyManager;
        Player playerObject;
        private SpriteFont arial12;// spritefont
        private SpriteFont arial24;// spritefont //appears to be the same size, need real diffrent size

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gState = GameState.Menu;
            projectileManager = new ProjectileManager();
            enemyManager = new EnemyManager();
            projectileManager = new ProjectileManager();           
            playerObject = new Player(new Rectangle(300, 850, 50, 50), player);
            playerManager = new PlayerManager(playerObject);
            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            player = Content.Load<Texture2D>("Player/Ship");
            playerObject.SetTexture(player);
            projectile = Content.Load<Texture2D>("Projectiles/Projectile");
            // Loads enemy content into manager
            enemyManager.LoadDefaultEnemy(Content.Load<Texture2D>("Enemy/Enemy"));
            enemyManager.DebugEnemyTest();
            //loads spritefont
            arial12 = Content.Load<SpriteFont>("Fonts/arial12");// load sprite font
            arial24 = Content.Load<SpriteFont>("Fonts/arial24");// load sprite font
        }

        void textOnScreen()
        {
            switch (gState)
            {
                case GameState.Menu:
                    {
                        spriteBatch.DrawString(arial24, "BLANKSPACE", new Vector2(248, 175), Color.White);// <Problem> arial24 is same size as arial12
                        spriteBatch.DrawString(arial12, "Menu", new Vector2(282, 315), Color.White);// menu screen 
                        spriteBatch.DrawString(arial12, "Use W,A,S,D to move", new Vector2(225, 350), Color.White);// game play instructions
                        spriteBatch.DrawString(arial12, "Use SpaceBar to shoot", new Vector2(221, 375), Color.White);
                        spriteBatch.DrawString(arial12, "Survive enemy attacks", new Vector2(224, 400), Color.White);
                        spriteBatch.DrawString(arial12, "Press enter to Play", new Vector2(234, 500), Color.White);// continue to game instructions
                        break;
                    }
                case GameState.Game:
                    {
                        spriteBatch.DrawString(arial12, "Ammo Type: ", new Vector2(25, 875), Color.White);// add Ammo Type var
                        spriteBatch.DrawString(arial12, "Level: ", new Vector2(280, 875), Color.White);// add Current Level var
                        spriteBatch.DrawString(arial12, "Health: ", new Vector2(525, 875), Color.White);// add Health var
                        break;
                    }
                case GameState.GameOver:
                    {
                        spriteBatch.DrawString(arial24, "GAME OVER!", new Vector2(248, 175), Color.White);// Game over screen
                        spriteBatch.DrawString(arial12, "You've been WhIPed", new Vector2(282, 315), Color.White);// funny? 
                        // last game stats
                        spriteBatch.DrawString(arial12, "You died on Level: ", new Vector2(225, 350), Color.White);// add current level var
                        spriteBatch.DrawString(arial12, "Your Final Score was: ", new Vector2(221, 375), Color.White);// add total score var
                        spriteBatch.DrawString(arial12, "The HighScore is: ", new Vector2(224, 400), Color.White);// add High Score var
                        spriteBatch.DrawString(arial12, "Press enter to retun to Main menu", new Vector2(234, 500), Color.White);// continue to menu instructions
                        break;
                    }
            }
            spriteBatch.End();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //Switch Statement to control screen based on current gamestate
            switch (gState)
            {
                //Switches off Menu when Start(Enter) is pressed 
                case GameState.Menu:
                    {
                        kbState = Keyboard.GetState();
                        if (SingleKeyPress(Keys.Enter) == true)
                        {
                            gState = GameState.Game;
                        }
                        pKbState = Keyboard.GetState();
                        break;
                    }
                //Sets up enemies, players, and fires projectiles when space is pressed. 
                case GameState.Game:
                    {
                        kbState = Keyboard.GetState();
                        projectileManager.UpdateProjectiles();
                        enemyManager.UpdateEnemies(projectileManager);
                        playerManager.MovePlayer();
                        if (playerManager.CheckFireWeapon(kbState))
                        {
                            projectileManager.AddProjectile(new Vector2(0, -1), 10, new Rectangle(playerObject.X + 19, playerObject.Y, 10, 10), projectile);
                        }
                        pKbState = Keyboard.GetState();
                        break;
                    }
                //Moves back to menu if button is pressed, or restarts if chosen.
                case GameState.GameOver:
                    {
                        kbState = Keyboard.GetState();
                        if (SingleKeyPress(Keys.Enter) == true)
                        {
                            gState = GameState.Menu;
                        }
                        if (SingleKeyPress(Keys.R) == true)
                        {
                            gState = GameState.Game;
                        }
                        pKbState = Keyboard.GetState();
                        break;
                    }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            //Draws based on the current Gamestate
            switch (gState)
            {
                case GameState.Menu:
                    {
                        GraphicsDevice.Clear(Color.Navy);
                        textOnScreen(); // helper method to clean up Draw method
                        break;
                    }
                case GameState.Game:
                    {
                        playerObject.Draw(spriteBatch);
                        projectileManager.DrawProjectiles(spriteBatch);
                        enemyManager.DrawEnemies(spriteBatch);
                        GraphicsDevice.Clear(Color.DarkBlue);
                        textOnScreen(); // helper method to clean up Draw method
                        break;
                    }
                case GameState.GameOver:
                    {
                        GraphicsDevice.Clear(Color.DarkSlateBlue);
                        textOnScreen(); // helper method to clean up Draw method
                        break;
                    }
            }

            base.Draw(gameTime);
        }

        //Checks if a key is being pressed one time
        protected Boolean SingleKeyPress(Keys key)
        {
            if (pKbState.IsKeyDown(key) == false && kbState.IsKeyDown(key) == true)
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
