using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BlankspaceTool
{
    enum Tools
    {
        Space,
        Enemy,
        Shotgun,
        Tank,
        Boss
    }

    public partial class WavesEditor : Form
    {
        private List<Wave> waves;

        private int waveIndex;
        private int maxWaves;
        private Tools equipedTool;

        public WavesEditor(string path)
        {
            InitializeComponent();

            waves = new List<Wave>();

            Load(path);
        }
        public WavesEditor(int wavesCount)
        {
            InitializeComponent();

            waves = new List<Wave>();
            waveIndex = 0;

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

                maxWaves = wavesCount;
                totalWavesLabel.Text = "Total Waves: " + maxWaves;

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

            // Change the names
            waveGroupBox.Text = "Wave " + (waveIndex + 1);
            CurrentWaveLabel.Text = "Current Wave: " + (waveIndex + 1);

            // Set the delay time per wave
            delayUpDown.Value = (decimal)waves[waveIndex].Delay;
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

            if (equipedTool == Tools.Space)
            {
                waves[waveIndex].Objects[x, y].BackColor = Color.LightGray;
                waves[waveIndex].SetTile(x, y, TileType.Space);
            }
            if(equipedTool == Tools.Enemy)
            {
                waves[waveIndex].Objects[x, y].BackColor = Color.Blue;
                waves[waveIndex].SetTile(x, y, TileType.Enemy);
            }
            if (equipedTool == Tools.Shotgun)
            {
                waves[waveIndex].Objects[x, y].BackColor = Color.Red;
                waves[waveIndex].SetTile(x, y, TileType.Shotgun);
            }
            if (equipedTool == Tools.Tank)
            {
                waves[waveIndex].Objects[x, y].BackColor = Color.Green;
                waves[waveIndex].SetTile(x, y, TileType.Tank);
            }
            if (equipedTool == Tools.Boss)
            {
                waves[waveIndex].Objects[x, y].BackColor = Color.Cyan;
                waves[waveIndex].SetTile(x, y, TileType.Boss);
            }
        }

        private void ClickTool(object sender, EventArgs e)
        {
            Color toolColor = ((Button)sender).BackColor;

            if (toolColor == Color.Blue)
            {
                equipedTool = Tools.Enemy;
            }
            if (toolColor == Color.Red)
            {
                equipedTool = Tools.Shotgun;
            }
            if (toolColor == Color.Green)
            {
                equipedTool = Tools.Tank;
            }
            if (toolColor == Color.Cyan)
            {
                equipedTool = Tools.Boss;
            }
            if (toolColor == Color.LightGray)
            {
                equipedTool = Tools.Space;
            }

            equipedToolPictureBox.BackColor = toolColor;
        }

        private void UpdatedWaveDelay(object sender, EventArgs e)
        {
            // Get the time from the delay box
            int time = (int)delayUpDown.Value;

            // Set the delay in the wave
            waves[waveIndex].SetDelay(time);
        }

        private void ClickSave(object sender, EventArgs e)
        {
            // Get the file path
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "Wave | *.wave";

            dialog.ShowDialog();

            Save(dialog.FileName);
        }

        private void ClickLoad(object sender, EventArgs e)
        {
            // Get the file path
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Wave | *.wave";

            dialog.ShowDialog();

            Load(dialog.FileName);
        }

        private void Save(string path)
        {
            if (path != "")
            {
                // Open a file stream for saving bianary
                Stream stream = File.OpenWrite(path);
                BinaryWriter bw = new BinaryWriter(stream);

                // Save the number of waves
                // Then save the width and height of each wave
                // Then save each wave
                // In each wave save the delay
                // Then the tile type

                bw.Write(maxWaves);
                bw.Write(5);
                bw.Write(5);

                foreach (Wave wave in waves)
                {
                    bw.Write(wave.Delay);
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            bw.Write((int)wave.TileTypes[x, y]);
                        }
                    }
                }

                bw.Close();

                MessageBox.Show("Saved Sucessfully!", "Results");
            } else
            {
                MessageBox.Show("I need a path!", "Save Error");
            }
        }

        private void Load(string path)
        {
            if(path != "")
            {
                Stream read = File.OpenRead(path);
                BinaryReader br = new BinaryReader(read);

                // first read the number of waves
                // Second read the width and height
                // third read the waves
                int wavesCount = br.ReadInt32();
                int width = br.ReadInt32();
                int height = br.ReadInt32();

                if(waves.Count > 0)
                {
                    waves.Clear();
                }

                InitializeWaves(wavesCount);

                for (int i = 0; i < wavesCount; i++)
                {
                    waves[i].SetDelay(br.ReadInt32());

                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            waves[i].SetTile(x, y, (TileType)br.ReadInt32());
                        }
                    }
                }

                waveIndex = 0;
                LoadWave();

                br.Close();

                MessageBox.Show("Loaded Sucessfully!", "Results");
            } else
            {
                MessageBox.Show("You forgot to give me a path!", "Load Error");
                InitializeWaves(1);
            }
        }
    }
}
