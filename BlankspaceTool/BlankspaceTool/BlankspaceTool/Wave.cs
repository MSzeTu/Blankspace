using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BlankspaceTool
{
    enum TileType
    {
        Space,
        Enemy
    }

    class Wave
    {
        private PictureBox[,] objects;
        private TileType[,] tileType;
        private int delay;

        public PictureBox[,] Objects { get { return objects; } }
        public TileType[,] TileTypes { get { return tileType; } }

        public int Delay { get { return delay; } }
         

        public Wave (PictureBox[,] objects)
        {
            this.objects = objects;
            tileType = new TileType[5, 5];
            delay = 0;
        }

        public void SetTile(int x, int y, TileType type)
        {
            tileType[x, y] = type;

            if (type == TileType.Space)
            {
                objects[x, y].BackColor = Color.LightGray;
            }
            if(type == TileType.Enemy)
            {
                objects[x, y].BackColor = Color.Red;
            }
        }

        public void SetDelay(int delay)
        {
            this.delay = delay;
        }
    }
}
