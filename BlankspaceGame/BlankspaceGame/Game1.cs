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
 * Recent Changes: Added Instruction State
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
        Instructions,
        Game,
        Pause,
        GameOver,
        Win
    }
    public class Game1 : Game
    {
        Boolean isPlaying;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Song song;
        Song pauseSong;
        //Keyboard objects to handle key presses
        KeyboardState kbState;
        KeyboardState pKbState;
        GameState gState;
        Texture2D player;
        Texture2D projectile;
        Texture2D mainMenu;
        Texture2D win;
        Texture2D pause;
        Texture2D lose;
        Texture2D instructions;
        Player playerObject;
        private SpriteFont arial12;// spritefont
        private SpriteFont arial24;// spritefont
        private SpriteFont arial18;// spritefont
        Texture2D BackDrop;
        Rectangle backLoc;
        Weapon wep;
        // Buttons
        Button buttonStart;
        Button buttonInstructions;
        Button buttonResume;
        Button buttonBack;
        Button buttonSwap;

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
            playerObject = new Player(new Rectangle(275, 800, 48, 40), player);
            isPlaying = false;
            InitializeButtons(this);
            // Initializes the manager classes
            EnemyManager.Initialize();
            PlayerManager.Initialize(playerObject);
            ProjectileManager.Initialize();
            WaveManager.Initialize();
            PickupManager.Intialize();
            ParalaxManager.Initialize();

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
            PlayerManager.LoadContent(this);
            //Background music
            song = Content.Load<Song>("Sounds/BackGround_Music");
            pauseSong = Content.Load<Song>("Sounds/Pause_Music");
            // Loads enemy content into manager
            //Loads Pickup content into manager
            PickupManager.LoadTextures(this);
            EnemyManager.LoadEnemyContent(this);
            //enemyManager.DebugEnemyTest();
            //loads spritefont
            arial12 = Content.Load<SpriteFont>("Fonts/arial12");// load sprite font
            arial18 = Content.Load<SpriteFont>("Fonts/arial18");// load sprite font
            arial24 = Content.Load<SpriteFont>("Fonts/arial24");// load sprite font
            //load Images
            BackDrop = Content.Load<Texture2D>("Images/pixilSpace");
            mainMenu = Content.Load<Texture2D>("Menus/MainMenu");
            pause = Content.Load<Texture2D>("Menus/PauseMenu");
            win = Content.Load<Texture2D>("Menus/Win");
            lose = Content.Load<Texture2D>("Menus/Lose");
            instructions = Content.Load<Texture2D>("Menus/Instructions");

            ParalaxManager.SetTexture(BackDrop);
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
                        buttonStart.Position = new Rectangle(150, 400, 300, 100);
                        buttonInstructions.Position = new Rectangle(150, 550, 300, 100);
                        kbState = Keyboard.GetState();
                        if (buttonStart.Clicked)
                        {
                            GameReset();// player stats reset for new game
                            gState = GameState.Game;
                        }
                        if (buttonInstructions.Clicked)
                        {
                            gState = GameState.Instructions;
                        }
                        pKbState = Keyboard.GetState();
                        break;
                    }
                case GameState.Instructions:
                    {
                        buttonSwap.Position = new Rectangle(350, 720, 200, 67);
                        buttonBack.Position = new Rectangle(350, 800, 200, 67);
                        
                        if (buttonBack.Clicked)
                        {
                            gState = GameState.Menu;
                        }
                        if (buttonSwap.Clicked)
                        {
                            PlayerManager.MouseControl = !PlayerManager.MouseControl;
                        }
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
                        if (kbState.IsKeyDown(Keys.M) && isPlaying == true)
                        {
                            MediaPlayer.Stop();
                            MediaPlayer.Play(pauseSong);
                            MediaPlayer.IsRepeating = true;

                        }
                        PickupManager.UpdatePickup();
                        ProjectileManager.UpdateProjectiles();
                        EnemyManager.UpdateEnemies();
                        PlayerManager.UpdatePlayer();
                        if (PlayerManager.CheckFireWeapon(kbState, wep))
                        {
                            wep.Fire();
                            playerObject.ShootSound.Play(volume: 0.2f, pitch: 0.0f, pan: 0.0f);
                        }
                        if (playerObject.Health <= 0)
                        {
                            PlayerManager.SetHighScore();
                            gState = GameState.GameOver;
                        }
                        if (kbState.IsKeyDown(Keys.P))
                        {
                            MediaPlayer.Stop();
                            isPlaying = false;
                            gState = GameState.Pause;
                        }
                        if (PlayerManager.CheckSwitchWeapon())
                        {
                            wep = PlayerManager.SwitchWeapon();
                            wep.LoadTextures(this);
                        }
                        pKbState = Keyboard.GetState();
                        break;
                    }
                //Freezes game until P is pressed again
                case GameState.Pause:
                    {
                        buttonResume.Position = new Rectangle(150, 600, 300, 100);
                        if (isPlaying == false)
                        {
                            MediaPlayer.Play(pauseSong);
                            MediaPlayer.IsRepeating = true;
                            isPlaying = true;

                        }
                        if (buttonResume.Clicked)
                        {
                            isPlaying = false;
                            gState = GameState.Game;
                        }
                        break;
                    }
                //Moves back to menu if button is pressed, or restarts if chosen.
                case GameState.GameOver:
                    {
                        WaveManager.ReloadWaves();
                        buttonBack.Position = new Rectangle(150, 700, 300, 100);
                        
                        if (buttonBack.Clicked)
                        {
                            gState = GameState.Menu;
                        }
                        //if (SingleKeyPress(Keys.R) == true)
                        //{
                        //    GameReset();
                        //    gState = GameState.Game;
                        //}
                        break;
                    }
                //Does the same thing as the Game Over state
                case GameState.Win:
                    {
                        WaveManager.ReloadWaves();
                        buttonBack.Position = new Rectangle(150, 700, 300, 100);

                        kbState = Keyboard.GetState();
                        if (buttonBack.Clicked)
                        {
                            gState = GameState.Menu;
                        }
                        //if (SingleKeyPress(Keys.R) == true)
                        //{
                        //    GameReset();
                        //    gState = GameState.Game;
                        //}
                        pKbState = Keyboard.GetState();
                        break;
                    }
            }

            // Reduce screenshake
            if (PlayerManager.ScreenShake > 0)
            {
                PlayerManager.ScreenShake -= (PlayerManager.ScreenShake / 10f);
            }
            else
            {
                PlayerManager.ScreenShake = 0;
            }

            // Winstate
            if (WaveManager.GameWon == true)
            {
                PlayerManager.SetHighScore();
                gState = GameState.Win;
                WaveManager.GameWon = false;
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

            Random rng = new Random();

            int shake = (int)PlayerManager.ScreenShake + ((wep != null) ? (wep.FireType == Firetype.Erin) ? 2 : 0 : 0);
            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                null,
                null,
                null,
                null,
                null,
                Matrix.CreateTranslation(rng.Next(-shake, shake), rng.Next(-shake, shake), 0)
                );


            //Draws based on the current Gamestate
            switch (gState)
            {
                case GameState.Menu:
                    {
                        IsMouseVisible = true;
                        GraphicsDevice.Clear(Color.Black);
                        spriteBatch.Draw(mainMenu, new Rectangle(0, 0, 600, 900), Color.White);
                        // Buttons
                        buttonStart.Draw(spriteBatch);
                        buttonInstructions.Draw(spriteBatch);
                        break;
                    }
                case GameState.Instructions:
                    {
                        IsMouseVisible = true;
                        spriteBatch.Draw(instructions, new Rectangle(0, 0, 600, 900), Color.White);
                        buttonBack.Draw(spriteBatch);
                        buttonSwap.Draw(spriteBatch);
                        // Draws the current control method
                        if (PlayerManager.MouseControl == true)
                        {
                            spriteBatch.DrawString(arial12, "Using mouse controls", new Vector2(400, 680), Color.White);
                        } else
                        {
                            spriteBatch.DrawString(arial12, "Using keyboard controls", new Vector2(400, 680), Color.White);
                        }
                        break;
                    }
                case GameState.Game:
                    {
                        IsMouseVisible = false;
                        spriteBatch.Draw(BackDrop, backLoc, Color.White);
                        ParalaxManager.Update(spriteBatch);
                        ProjectileManager.DrawProjectiles(spriteBatch);
                        EnemyManager.DrawEnemies(spriteBatch);
                        PlayerManager.DrawPlayer(spriteBatch);
                        PickupManager.DrawPickups(spriteBatch);
                        GraphicsDevice.Clear(Color.Black);
                        spriteBatch.DrawString(arial12, "Health: " + playerObject.Health, new Vector2(10, 855), Color.White); // add Health var
                        spriteBatch.DrawString(arial12, "BlankSpaces: " + PlayerManager.BlankSpace, new Vector2(10, 875), Color.White); // add Health var
                        spriteBatch.DrawString(arial12, $"Level: {WaveManager.CurrentLevel + 1}", new Vector2(515, 855), Color.White); // add Current Level var
                        spriteBatch.DrawString(arial12, "Score: " + PlayerManager.Score, new Vector2(515, 875), Color.White); // add Current Score var
                        // Draws the wave incoming alert
                        if (true)
                        break;
                    }
                case GameState.Pause:
                    {
                        IsMouseVisible = true;
                        GraphicsDevice.Clear(Color.Black);
                        spriteBatch.Draw(pause, new Rectangle(0, 0, 600, 900), Color.White);
                        buttonResume.Draw(spriteBatch);
                        spriteBatch.DrawString(arial18, "Current Score: " + PlayerManager.Score, new Vector2(200, 400), Color.Teal); // add total score var
                        spriteBatch.DrawString(arial18, $"Current Level: {WaveManager.CurrentLevel + 1}", new Vector2(200, 475), Color.Teal); // add Current Level var
                        break;
                    }
                case GameState.GameOver:
                    {
                        IsMouseVisible = true;
                        GraphicsDevice.Clear(Color.Black);
                        spriteBatch.Draw(lose, new Rectangle(0, 0, 600, 900), Color.White);
                        // last game stats
                        spriteBatch.DrawString(arial18, "Your Final Score: " + PlayerManager.Score, new Vector2(200, 400), Color.DarkRed); // add total score var
                        spriteBatch.DrawString(arial18, "The HighScore is: " + PlayerManager.HighScore, new Vector2(200, 475), Color.DarkRed); // add High Score var
                        buttonBack.Draw(spriteBatch);
                        break;
                    }
                case GameState.Win:
                    {
                        IsMouseVisible = true;
                        // Win UI
                        IsMouseVisible = true;
                        GraphicsDevice.Clear(Color.Black);
                        spriteBatch.Draw(win, new Rectangle(0, 0, 600, 900), Color.White);
                        spriteBatch.DrawString(arial12, "Your Final Score: " + PlayerManager.Score, new Vector2(220, 400), Color.Teal); // add total score var
                        spriteBatch.DrawString(arial12, "The HighScore is: " + PlayerManager.HighScore, new Vector2(220, 475), Color.Teal); // add High Score var
                        buttonBack.Draw(spriteBatch);
                        break;
                    }

            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        protected void GameReset()
        {
            PlayerManager.BlankSpace = 2;
            playerObject.Health = 5; // player health reset for new game
            ProjectileManager.Clear();
            playerObject.X = 275;
            playerObject.Y = 800;
            PlayerManager.Score = 0;
            PlayerManager.IFrame = 0;
            EnemyManager.Enemies.Clear();
            EnemyManager.BossEnemy = null;
            PickupManager.Pickups.Clear();
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

        // Creates the buttons, edit the positions here!
        protected void InitializeButtons(Game1 g)
        {
            buttonStart = new Button(new Rectangle(0, 0, 300, 100), g.Content.Load<Texture2D>("Buttons/startButton"));
            buttonBack = new Button(new Rectangle(0, 0, 300, 100), g.Content.Load<Texture2D>("Buttons/backButton"));
            buttonResume = new Button(new Rectangle(0, 0, 300, 100), g.Content.Load<Texture2D>("Buttons/resumeButton"));
            buttonInstructions = new Button(new Rectangle(0, 0, 300, 100), g.Content.Load<Texture2D>("Buttons/instructionsButton"));
            buttonSwap = new Button(new Rectangle(0, 0, 300, 100), g.Content.Load<Texture2D>("Buttons/buttonSwap"));
        }
    }
}
