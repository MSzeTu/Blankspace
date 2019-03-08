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
        Enemy
    }

    class WaveManager
    {
        // Wave data
        private int waveCount;
        private int width, height;
        private EnemyManager eManager;

        // List for the waves
        public List<Wave> waves;

        // Timing
        private float currentTime;
        private int currentWave;

        public WaveManager(string path, EnemyManager eManager)
        {
            waves = new List<Wave>(); 
            this.eManager = eManager;

            LoadWaves(path);
        }

        // Updates the wave and delay
        public void WaveUpdate()
        {
            currentTime += (1f / 60f);

            if (currentWave < waveCount)
            {
                if (currentTime >= waves[currentWave].Delay)
                {
                    waves[currentWave].SpawnEnemys();
                    currentTime = 0;
                    currentWave++;
                }
            }
        }

        /// <summary>
        /// Loads in the wave from a given path
        /// </summary>
        /// <param name="path">The directory to the wave in question</param>
        public void LoadWaves(string path)
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
                waves.Add(new Wave(delay,width, height, eManager));

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
    }
}
