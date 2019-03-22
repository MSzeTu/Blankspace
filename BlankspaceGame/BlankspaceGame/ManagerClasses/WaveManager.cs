using System;
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
        Tank
    }

    static class WaveManager
    {
        // Wave data
        private static int waveCount;
        private static int width, height;

        // List for the waves
        public static List<Wave> waves;

        // Timing
        private static float currentTime;
        private static int currentWave;

        public static void Initialize(string path)
        {
            waves = new List<Wave>();

            currentWave = 0;
            currentTime = 0;
            LoadWaves(path);
        }

        // Updates the wave and delay
        public static void WaveUpdate()
        {
            currentTime += (1f / 60f);

            if (currentTime >= waves[currentWave].Delay)
            {
                waves[currentWave].SpawnEnemys();
                currentTime = 0;

                if (currentWave < waveCount - 1)
                {
                    currentWave++;
                }
                else
                {
                    currentWave = 0;
                }
            }
        }


        /// <summary>
        /// Loads in the wave from a given path
        /// </summary>
        /// <param name="path">The directory to the wave in question</param>
        public static void LoadWaves(string path)
        {
            // Open the bianary reader
            Stream reader = File.OpenRead(path);
            BinaryReader br = new BinaryReader(reader);

            // Read the wave count and the width and height of each wave
            waveCount = br.ReadInt32();
            width = br.ReadInt32();
            height = br.ReadInt32();

            // Loop through the waves
            for (int i = 0; i < waveCount; i++)
            {
                // Read the delay and add a base wave
                int delay = br.ReadInt32();
                waves.Add(new Wave(delay, width, height));

                // Load in each tile
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        TileType type = (TileType)br.ReadInt32();
                        waves[i].SetType(type, x, y);
                    }
                }
            }

            br.Close();
        }

        public static void ReloadWaves()
        {
            currentTime = 0;
            currentWave = 0;
        }
    }
}
