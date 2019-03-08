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
        private EnemyManager eManager;

        public int Delay { get { return delay; } }

        public Wave (int delay, int width, int height, EnemyManager enemyManager)
        {
            this.delay = delay;
            tiles = new TileType[width, height];
            this.eManager = enemyManager;
        }

        public void SetType(TileType type, int x, int y)
        {
            tiles[x, y] = type;
        }

        public void SpawnEnemys()
        {
            int width = tiles.GetLength(0), height = tiles.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    switch (tiles[x, y])
                    {
                        case TileType.Enemy:
                            eManager.AddEnemy
                                (
                                new Rectangle(x * 100, y * -100 - 100, 68, 60),
                                eManager.DefEnemy,
                                3,
                                1
                                );
                            break;
                    }
                }
            }
        }

    }
}
