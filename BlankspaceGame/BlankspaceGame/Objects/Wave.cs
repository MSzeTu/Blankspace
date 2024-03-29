﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
/*Name: Blank Space
 * Class: IGME106
 * Author: WIP
 * Purpose: Base class for individual waves
 * Recent Changes: Created header
 */
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

        /*
         * Spawns the enemies in the wave
         */ 
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
                            EnemyManager.AddEnemy
                                (
                                new Rectangle(x * 120 + 30, y * -100 - 100, 60, 60),
                                EnemyType.Basic
                                );
                            break;
                        case TileType.Shotgun:
                            EnemyManager.AddEnemy
                                (
                                new Rectangle(x * 120 + 30, y * -100 - 100, 60, 60),
                                EnemyType.Shotgun   
                                );
                            break;
                        case TileType.Tank:
                            EnemyManager.AddEnemy
                                (
                                new Rectangle(x * 120 + 30, y * -100 - 100, 60, 60),
                                EnemyType.Tank             
                                );
                            break;
                        case TileType.Boss:
                            EnemyManager.AddEnemy
                                (
                                new Rectangle(200, y * -100 - 100, 200, 100),
                                EnemyType.Boss
                                );
                            break;
                    }
                }
            }
        }

    }
}
