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
    public partial class WavesEditor : Form
    {
        private List<Wave> waves;

        private int waveIndex;
        private int maxWaves;

        public WavesEditor(int wavesCount)
        {
            InitializeComponent();

            waves = new List<Wave>();
            waveIndex = 0;
            maxWaves = wavesCount;

            InitializeWaves(wavesCount);
        }

        private void InitializeWaves(int wavesCount)
        {
            for (int i = 0; i < wavesCount; i++)
            {
                // Create the wave objects array
                PictureBox[,] objects = new PictureBox[5, 5];
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        objects[x, y] = new PictureBox();
                        objects[x, y].Location = new System.Drawing.Point(6 + (x * 100), 19 + (y * 100));
                        objects[x, y].Name = $"{x},{y}";
                        objects[x, y].Size = new System.Drawing.Size(95, 95);
                        objects[x, y].TabIndex = 0;
                        objects[x, y].TabStop = false;
                        objects[x, y].BackColor = Color.LightGray;
                        objects[x, y].Click += ClickTile;

                        waveGroupBox.Controls.Add(objects[x, y]);
                    }
                }

                // Add the wave to the list of waves
                waves.Add(new Wave(objects));
            }
        }

        private void LoadWave()
        {
            // Clear the thingy
            waveGroupBox.Controls.Clear();

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    waveGroupBox.Controls.Add(waves[waveIndex].Objects[x, y]);
                }
            }

            // Change the name
            waveGroupBox.Text = "Wave " + (waveIndex + 1);
        }

        private void NextWaveButton_Click(object sender, EventArgs e)
        {
            if(waveIndex < maxWaves - 1)
            {
                waveIndex++;
                LoadWave();
            }
        }

        private void PreviousWaveButton_Click(object sender, EventArgs e)
        {
            if(waveIndex > 0)
            {
                waveIndex--;
                LoadWave();
            }
        }

        private void ClickTile(object sender, EventArgs e)
        {
            PictureBox clickedBox = ((PictureBox)sender);

            // Calculate which box was clicked
            string point = clickedBox.Name;
            int x = int.Parse(point.Split(',')[0]);
            int y = int.Parse(point.Split(',')[1]);

            waves[waveIndex].Objects[x, y].BackColor = Color.Wheat;
        }
    }
}
