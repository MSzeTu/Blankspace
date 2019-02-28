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
    class Wave
    {
        private PictureBox[,] objects;

        public PictureBox[,] Objects { get { return objects; } }

        public Wave (PictureBox[,] objects)
        {
            this.objects = objects;
        }
    }
}
