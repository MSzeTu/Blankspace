using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlankspaceGame
{
    class Wave
    {
        private TileType[,] tiles;
        private int delay;

        public int Delay { get { return delay; } }

        public Wave(int delay, int width, int height)
        {
            this.delay = delay;
            tiles = new TileType[width, height];
        }

        public void SetType(TileType type, int x, int y)
        {
            tiles[x, y] = type;
        }

        public void SpawnEnemys()
        {
            Random rand = new Random();
            EnemyType randomEnemyType = EnemyType.Basic;
            int width = tiles.GetLength(0), height = tiles.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    switch (tiles[x, y])
                    {
                        case TileType.Enemy:
                            switch (rand.Next(0, 4))
                            {
                                case 0:
                                    randomEnemyType = EnemyType.Basic;
                                    break;
                                case 1:
                                    randomEnemyType = EnemyType.Shotgun;
                                    break;
                                case 2:
                                    randomEnemyType = EnemyType.Tank;
                                    break;
                            }
                            EnemyManager.AddEnemy
                                (
                                new Rectangle(x * 100 + 25, y * -100 - 100, 60, 60),
                                randomEnemyType
                                );
                            break;
                    }
                }
            }
        }

    }
}
