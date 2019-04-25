using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Name: Blank Space
 * Class: IGME106
 * Author: WIP
 * Purpose: Level class for levels themselves
 * Recent Changes: Created header
 */
namespace BlankspaceGame
{
    class Level
    {

        // Wave data
        private int waveCount;
        private int width, height;

        // List for the waves
        private List<Wave> waves;

        public List<Wave> Waves { get { return waves; } }

        public int WaveCount { get { return waveCount; } set { waveCount = value; } }
        public int Width { get { return width; } set { width = value; } }
        public int Height { get { return height; } set { height = value; } }

        public Level(List<Wave> waves)
        {
            this.waves = waves;
        }

        public bool Complete(int currentWave)
        {
            return (currentWave >= waveCount - 1) ? true : false;
        }
    }
}
