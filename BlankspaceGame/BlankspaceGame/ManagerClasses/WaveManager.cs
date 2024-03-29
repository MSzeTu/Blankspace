﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BlankspaceGame
{

    public enum TileType
    {
        Space,
        Enemy,
        Shotgun,
        Tank,
        Boss
    }

    static class WaveManager
    {

        // Paths of the levels
        private static string[] levelsToLoad;

        // Timing
        private static float currentTime;
        private static int currentWave;

        // Level stuff
        private static int currentLevel;
        private static List<Level> levels;
        private static bool toNextLevel;
        private static bool gameWon;

        // Level Property
        public static int CurrentLevel {
            get {
                return currentLevel;
            }
        }

        // Level count property
        public static int LevelCount
        {
            get
            {
                return levelsToLoad.Length;
            }
        }

        public static bool GameWon
        {
            get
            {
                return gameWon;
            }
            set
            {
                gameWon = value;
            }
        }

        public static bool IsChangingLevel
        {
            get
            {
                if (EnemyManager.EnemyCount <= 0 && currentTime <= 0 && currentLevel < LevelCount)
                    return true;
                else
                    return false;
            }
        }

        public static void Initialize()
        {

            levels = new List<Level>();

            currentWave = 0;
            currentTime = 0;
            currentLevel = 0;
            levelsToLoad = GetLevelsInFolder();

            for (int i = 0; i < levelsToLoad.Length; i++)
            {
                LoadWaves(levelsToLoad[i]);
            }
            gameWon = false;
        }

        /*
         * Updates the wave and delay
         */
        public static void WaveUpdate()
        {
            if (!toNextLevel)
                currentTime += (1f / 60f);

            if (currentLevel < LevelCount)
            {
                if (currentTime >= levels[currentLevel].Waves[currentWave].Delay && !toNextLevel)
                {
                    levels[currentLevel].Waves[currentWave].SpawnEnemys();
                    currentTime = 0;

                    if (currentWave < levels[currentLevel].WaveCount - 1)
                    {
                        currentWave++;
                    }
                    else
                    {
                        if (toNextLevel == false)
                        {
                            currentTime = -10;
                            toNextLevel = true;
                        }
                    }
                }

                if (levels[currentLevel].Complete(currentWave) && toNextLevel == true && EnemyManager.EnemyCount <= 0)
                {
                    currentWave = 0;
                    currentLevel++;
                    toNextLevel = false;
                }
                gameWon = false;
            } else
            {
                // All levels are complete
                // Check if all enemies are defeated
                if (EnemyManager.EnemyCount <= 0 && currentTime >= 0)
                {
                    // Now all waves have been complete YAY
                    gameWon = true;
                } else
                {
                    gameWon = false;
                }
            }
        }


        /// <summary>
        /// Loads in the wave from a given path
        /// </summary>
        /// <param name="path">The directory to the wave in question</param>
        public static void LoadWaves(string path)
        {
            // List of waves
            List<Wave> waves = new List<Wave>();
            Level level = new Level(waves);

            // Open the bianary reader
            Stream reader = File.OpenRead(path);
            BinaryReader br = new BinaryReader(reader);

            // Read the wave count and the width and height of each wave
            level.WaveCount = br.ReadInt32();
            level.Width = br.ReadInt32();
            level.Height = br.ReadInt32();

            // Loop through the waves
            for (int i = 0; i < level.WaveCount; i++)
            {
                // Read the delay and add a base wave
                int delay = br.ReadInt32();
                waves.Add(new Wave(delay, level.Width, level.Height));

                // Load in each tile
                for (int x = 0; x < level.Width; x++)
                {
                    for (int y = 0; y < level.Height; y++)
                    {
                        TileType type = (TileType)br.ReadInt32();
                        waves[i].SetType(type, x, y);
                    }
                }
            }

            levels.Add(level);
            br.Close();
        }

        /*
         * Reloads waves after game
         */ 
        public static void ReloadWaves()
        {
            currentTime = 0;
            currentWave = 0;
            currentLevel = 0;
            toNextLevel = false;
        }

        static string[] GetLevelsInFolder()
        {

            // Check if the levels folder exists
            if (Directory.Exists(".\\Content\\Levels\\"))
            {
                // Get the directory
                DirectoryInfo levelsFolder = new DirectoryInfo(".\\Content\\Levels\\");

                // Get the level files
                FileInfo[] files = levelsFolder.GetFiles();

                // Get the length of the level name string
                int levelCount = files.Length;
                string[] lvlsToLoad = new string[levelCount];

                for (int i = 0; i < files.Length; i++)
                {
                    lvlsToLoad[i] = $".\\Content\\Levels\\{files[i].Name}";
                }

                return lvlsToLoad;
            } else
            {
                throw new Exception("The level folder does not exist!");
            }
        }
    }
}
