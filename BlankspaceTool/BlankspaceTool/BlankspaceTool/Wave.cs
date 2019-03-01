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

        public PictureBox[,] Objects { get { return objects; } }

        public TileType[,] tileType;

        public Wave (PictureBox[,] objects)
        {
            this.objects = objects;
            tileType = new TileType[5, 5];
        }

        public void SetTile(int x, int y, TileType type)
        {
            tileType[x, y] = type;
        }
    }
}
