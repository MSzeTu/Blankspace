using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Name: Blank Space
 * Class: IGME106
 * Author: WIP
 * Purpose: Main Method
 * Recent Changes: Created header
 */
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
        Boolean isPlaying = false;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Song song;
        //Keyboard objects to handle key presses
        KeyboardState kbState;
        KeyboardState pKbState;
        GameState gState;
        Texture2D player;
        Texture2D projectile;
        Player playerObject;
        private SpriteFont arial12;// spritefont
        private SpriteFont arial24;// spritefont
        SoundEffect proSound;
        SoundEffect explosionSound;
        private SpriteFont arial18;// spritefont
        Texture2D BackDrop;
        Rectangle backLoc;
        Weapon wep;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
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
            playerObject = new Player(new Rectangle(300, 850, 55, 55), player);

            // Initializes the manager classes
            EnemyManager.Initialize();
            PlayerManager.Initialize(playerObject);
            ProjectileManager.Initialize();
            WaveManager.Initialize();

            backLoc = new Rectangle(0, 0, 600, 1250);

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
            proSound = Content.Load<SoundEffect>("Sounds/Laser_Sound");
            explosionSound = Content.Load<SoundEffect>("Sounds/Explosion");
            PlayerManager.LoadSound(proSound, explosionSound);
            PlayerManager.LoadContent(this);
            //Background music
            song = Content.Load<Song>("Sounds/BackGround_Music");
            // Loads enemy content into manager
            EnemyManager.LoadEnemyContent(Content.Load<Texture2D>("Enemy/Enemy"), projectile, explosionSound, proSound);
            //enemyManager.DebugEnemyTest();
            //loads spritefont
            arial12 = Content.Load<SpriteFont>("Fonts/arial12");// load sprite font
            arial18 = Content.Load<SpriteFont>("Fonts/arial18");// load sprite font
            arial24 = Content.Load<SpriteFont>("Fonts/arial24");// load sprite font
            //load Images
            BackDrop = Content.Load<Texture2D>("Images/pixilSpace");
        }

        //Draws all the gamescreen text to keep the draw method cleaner
        void TextOnScreen()
        {
            switch (gState)
            {
                case GameState.Menu:
                    {
                        spriteBatch.DrawString(arial24, "BLANKSPACE", new Vector2(200, 175), Color.White); // <Problem> arial24 is same size as arial12
                        spriteBatch.DrawString(arial18, "Menu", new Vector2(270, 300), Color.White); // menu screen 
                        spriteBatch.DrawString(arial12, "Use W,A,S,D to move", new Vector2(225, 350), Color.White); // game play instructions
                        spriteBatch.DrawString(arial12, "Use SpaceBar to shoot", new Vector2(221, 375), Color.White);
                        spriteBatch.DrawString(arial12, "Use 1,2,3 to switch weapons.", new Vector2(210, 400), Color.White);
                        spriteBatch.DrawString(arial12, "Survive enemy attacks", new Vector2(224, 425), Color.White);
                        spriteBatch.DrawString(arial18, "Press enter to Play", new Vector2(203, 525), Color.White); // continue to game instructions
                        break;
                    }
                case GameState.Game:
                    {
                        spriteBatch.DrawString(arial12, "Health: " + playerObject.Health, new Vector2(10, 855), Color.White); // add Health var
                        spriteBatch.DrawString(arial12, "Ammo Type: ", new Vector2(10, 875), Color.White); // add Ammo Type var
                        spriteBatch.DrawString(arial12, $"Level: {WaveManager.CurrentLevel + 1}", new Vector2(515, 855), Color.White); // add Current Level var
                        spriteBatch.DrawString(arial12, "Score: " + PlayerManager.Score, new Vector2(515, 875), Color.White); // add Current Score var
                        break;
                    }
                case GameState.GameOver:
                    {
                        spriteBatch.DrawString(arial24, "GAME OVER!", new Vector2(200, 175), Color.White); // Game over screen
                        spriteBatch.DrawString(arial18, "You have been WhIPed!", new Vector2(170, 275), Color.White); // funny? 
                        // last game stats
                        spriteBatch.DrawString(arial12, "You died on Level: ", new Vector2(235, 350), Color.White); // add current level var\
                        spriteBatch.DrawString(arial12, "Your Final Score: "+PlayerManager.Score, new Vector2(235, 375), Color.White); // add total score var
                        spriteBatch.DrawString(arial12, "The HighScore is: "+PlayerManager.HighScore, new Vector2(235, 400), Color.White); // add High Score var
                        spriteBatch.DrawString(arial18, "Press enter to retun to Main menu", new Vector2(122, 500), Color.White); // continue to menu instructions
                        break;
                    }
            }
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
                            GameReset();// player stats reset for new game
                            gState = GameState.Game;
                        }
                        pKbState = Keyboard.GetState();
                        break;
                    }
                //Sets up enemies, players, and fires projectiles when space is pressed. 
                case GameState.Game:
                    {
                        WaveManager.WaveUpdate();

                        kbState = Keyboard.GetState();
                        if (isPlaying == false)
                        {
                            MediaPlayer.Play(song);
                            MediaPlayer.IsRepeating = true;
                            isPlaying = true;
                        }
                        ProjectileManager.UpdateProjectiles();
                        EnemyManager.UpdateEnemies();
                        //enemyManager.DebugEnemyRespawn();
                        PlayerManager.UpdatePlayer();
                        if (PlayerManager.CheckFireWeapon(kbState, wep))
                        {
                            wep.Fire();
                            playerObject.ShootSound.Play();
                        }
                        if (playerObject.Health <= 0)
                        {
                            PlayerManager.SetHighScore();
                            gState = GameState.GameOver;
                        }
                        if (PlayerManager.CheckSwitchWeapon())
                        {
                            wep = PlayerManager.SwitchWeapon();
                            wep.LoadTextures(this);
                        }
                        pKbState = Keyboard.GetState();
                        break;
                    }
                //Moves back to menu if button is pressed, or restarts if chosen.
                case GameState.GameOver:
                    {
                        WaveManager.ReloadWaves();

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
                        TextOnScreen(); // helper method to clean up Draw method
                        break;
                    }
                case GameState.Game:
                    {
                        spriteBatch.Draw(BackDrop, backLoc, Color.White);
                        ProjectileManager.DrawProjectiles(spriteBatch);
                        EnemyManager.DrawEnemies(spriteBatch);
                        PlayerManager.DrawPlayer(spriteBatch);
                        GraphicsDevice.Clear(Color.DarkSlateGray);
                        TextOnScreen(); // helper method to clean up Draw method
                        break;
                    }
                case GameState.GameOver:
                    {
                        GraphicsDevice.Clear(Color.DarkSlateBlue);
                        TextOnScreen(); // helper method to clean up Draw method
                        break;
                    }
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        protected void GameReset()
        {
            playerObject.Health = 3; // player health reset for new game
            ProjectileManager.Clear();
            playerObject.X = 300;
            playerObject.Y = 850;
            PlayerManager.Score = 0;
            PlayerManager.IFrame = 0;
            EnemyManager.Enemies.Clear();
            //enemyManager.DebugEnemyTest();
            // Creates weapon and loads content
            wep = new Weapon(Firetype.Shotgun, Firerate.Fast, Firecolor.Red);
            wep.LoadTextures(this);
        }


        //Checks if a key is being pressed one time
        protected bool SingleKeyPress(Keys key)
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
