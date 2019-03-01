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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ClickCreate(object sender, EventArgs e)
        {
            WavesEditor we = new WavesEditor((int)wavesCountUpDown.Value);

            we.ShowDialog();
        }

        public void ClickLoad(object sender, EventArgs e)
        {
            // Get the file path
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Wave | *.wave";

            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                WavesEditor we = new WavesEditor(dialog.FileName);
                we.ShowDialog();
            } else
            {
                MessageBox.Show("You forgot to give me a path!", "Load Error");
            }
        }
    }
}
