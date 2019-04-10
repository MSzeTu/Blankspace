namespace BlankspaceTool
{
    partial class WavesEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.waveGroupBox = new System.Windows.Forms.GroupBox();
            this.NextWaveButton = new System.Windows.Forms.Button();
            this.PreviousWaveButton = new System.Windows.Forms.Button();
            this.toolGroupBox = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.PlaceEnemyButton = new System.Windows.Forms.Button();
            this.emptySpaceButton = new System.Windows.Forms.Button();
            this.totalWavesLabel = new System.Windows.Forms.Label();
            this.EquipedToolBox = new System.Windows.Forms.GroupBox();
            this.equipedToolPictureBox = new System.Windows.Forms.PictureBox();
            this.CurrentWaveLabel = new System.Windows.Forms.Label();
            this.delayLabel = new System.Windows.Forms.Label();
            this.delayUpDown = new System.Windows.Forms.NumericUpDown();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.toolGroupBox.SuspendLayout();
            this.EquipedToolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipedToolPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // waveGroupBox
            // 
            this.waveGroupBox.Location = new System.Drawing.Point(240, 15);
            this.waveGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.waveGroupBox.Name = "waveGroupBox";
            this.waveGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.waveGroupBox.Size = new System.Drawing.Size(675, 639);
            this.waveGroupBox.TabIndex = 0;
            this.waveGroupBox.TabStop = false;
            this.waveGroupBox.Text = "Wave 1";
            // 
            // NextWaveButton
            // 
            this.NextWaveButton.Location = new System.Drawing.Point(123, 620);
            this.NextWaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.NextWaveButton.Name = "NextWaveButton";
            this.NextWaveButton.Size = new System.Drawing.Size(109, 28);
            this.NextWaveButton.TabIndex = 1;
            this.NextWaveButton.Text = "Next";
            this.NextWaveButton.UseVisualStyleBackColor = true;
            this.NextWaveButton.Click += new System.EventHandler(this.NextWaveButton_Click);
            // 
            // PreviousWaveButton
            // 
            this.PreviousWaveButton.Location = new System.Drawing.Point(16, 620);
            this.PreviousWaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.PreviousWaveButton.Name = "PreviousWaveButton";
            this.PreviousWaveButton.Size = new System.Drawing.Size(100, 28);
            this.PreviousWaveButton.TabIndex = 2;
            this.PreviousWaveButton.Text = "Previous";
            this.PreviousWaveButton.UseVisualStyleBackColor = true;
            this.PreviousWaveButton.Click += new System.EventHandler(this.PreviousWaveButton_Click);
            // 
            // toolGroupBox
            // 
            this.toolGroupBox.Controls.Add(this.button3);
            this.toolGroupBox.Controls.Add(this.button2);
            this.toolGroupBox.Controls.Add(this.button1);
            this.toolGroupBox.Controls.Add(this.PlaceEnemyButton);
            this.toolGroupBox.Controls.Add(this.emptySpaceButton);
            this.toolGroupBox.Location = new System.Drawing.Point(16, 15);
            this.toolGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.toolGroupBox.Name = "toolGroupBox";
            this.toolGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.toolGroupBox.Size = new System.Drawing.Size(216, 186);
            this.toolGroupBox.TabIndex = 3;
            this.toolGroupBox.TabStop = false;
            this.toolGroupBox.Text = "Tools";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Green;
            this.button2.Location = new System.Drawing.Point(144, 23);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 74);
            this.button2.TabIndex = 3;
            this.button2.Text = "Place Tank";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.ClickTool);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(76, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 74);
            this.button1.TabIndex = 2;
            this.button1.Text = "Place Shot Gun";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ClickTool);
            // 
            // PlaceEnemyButton
            // 
            this.PlaceEnemyButton.BackColor = System.Drawing.Color.Blue;
            this.PlaceEnemyButton.Location = new System.Drawing.Point(8, 23);
            this.PlaceEnemyButton.Margin = new System.Windows.Forms.Padding(4);
            this.PlaceEnemyButton.Name = "PlaceEnemyButton";
            this.PlaceEnemyButton.Size = new System.Drawing.Size(60, 74);
            this.PlaceEnemyButton.TabIndex = 0;
            this.PlaceEnemyButton.Text = "Place Enemy";
            this.PlaceEnemyButton.UseVisualStyleBackColor = false;
            this.PlaceEnemyButton.Click += new System.EventHandler(this.ClickTool);
            // 
            // emptySpaceButton
            // 
            this.emptySpaceButton.BackColor = System.Drawing.Color.LightGray;
            this.emptySpaceButton.Location = new System.Drawing.Point(144, 105);
            this.emptySpaceButton.Margin = new System.Windows.Forms.Padding(4);
            this.emptySpaceButton.Name = "emptySpaceButton";
            this.emptySpaceButton.Size = new System.Drawing.Size(60, 74);
            this.emptySpaceButton.TabIndex = 1;
            this.emptySpaceButton.Text = "Empty Space";
            this.emptySpaceButton.UseVisualStyleBackColor = false;
            this.emptySpaceButton.Click += new System.EventHandler(this.ClickTool);
            // 
            // totalWavesLabel
            // 
            this.totalWavesLabel.AutoSize = true;
            this.totalWavesLabel.Location = new System.Drawing.Point(12, 585);
            this.totalWavesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalWavesLabel.Name = "totalWavesLabel";
            this.totalWavesLabel.Size = new System.Drawing.Size(95, 17);
            this.totalWavesLabel.TabIndex = 2;
            this.totalWavesLabel.Text = "Total Waves: ";
            // 
            // EquipedToolBox
            // 
            this.EquipedToolBox.Controls.Add(this.equipedToolPictureBox);
            this.EquipedToolBox.Location = new System.Drawing.Point(16, 208);
            this.EquipedToolBox.Margin = new System.Windows.Forms.Padding(4);
            this.EquipedToolBox.Name = "EquipedToolBox";
            this.EquipedToolBox.Padding = new System.Windows.Forms.Padding(4);
            this.EquipedToolBox.Size = new System.Drawing.Size(216, 186);
            this.EquipedToolBox.TabIndex = 4;
            this.EquipedToolBox.TabStop = false;
            this.EquipedToolBox.Text = "Equiped Tool";
            // 
            // equipedToolPictureBox
            // 
            this.equipedToolPictureBox.BackColor = System.Drawing.Color.LightGray;
            this.equipedToolPictureBox.Location = new System.Drawing.Point(8, 23);
            this.equipedToolPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.equipedToolPictureBox.Name = "equipedToolPictureBox";
            this.equipedToolPictureBox.Size = new System.Drawing.Size(200, 155);
            this.equipedToolPictureBox.TabIndex = 0;
            this.equipedToolPictureBox.TabStop = false;
            // 
            // CurrentWaveLabel
            // 
            this.CurrentWaveLabel.AutoSize = true;
            this.CurrentWaveLabel.Location = new System.Drawing.Point(12, 601);
            this.CurrentWaveLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentWaveLabel.Name = "CurrentWaveLabel";
            this.CurrentWaveLabel.Size = new System.Drawing.Size(111, 17);
            this.CurrentWaveLabel.TabIndex = 5;
            this.CurrentWaveLabel.Text = "Current Wave: 1";
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(24, 402);
            this.delayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(52, 17);
            this.delayLabel.TabIndex = 6;
            this.delayLabel.Text = "Delay: ";
            // 
            // delayUpDown
            // 
            this.delayUpDown.DecimalPlaces = 2;
            this.delayUpDown.Location = new System.Drawing.Point(72, 402);
            this.delayUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.delayUpDown.Name = "delayUpDown";
            this.delayUpDown.Size = new System.Drawing.Size(160, 22);
            this.delayUpDown.TabIndex = 7;
            this.delayUpDown.ValueChanged += new System.EventHandler(this.UpdatedWaveDelay);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(28, 449);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(196, 28);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.ClickSave);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(28, 485);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(4);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(196, 28);
            this.LoadButton.TabIndex = 9;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.ClickLoad);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Cyan;
            this.button3.Location = new System.Drawing.Point(8, 104);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 74);
            this.button3.TabIndex = 4;
            this.button3.Text = "Place Boss";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.ClickTool);
            // 
            // WavesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 663);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.delayUpDown);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.CurrentWaveLabel);
            this.Controls.Add(this.EquipedToolBox);
            this.Controls.Add(this.totalWavesLabel);
            this.Controls.Add(this.toolGroupBox);
            this.Controls.Add(this.PreviousWaveButton);
            this.Controls.Add(this.NextWaveButton);
            this.Controls.Add(this.waveGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WavesEditor";
            this.Text = "WavesEditor";
            this.toolGroupBox.ResumeLayout(false);
            this.EquipedToolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.equipedToolPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox waveGroupBox;
        private System.Windows.Forms.Button NextWaveButton;
        private System.Windows.Forms.Button PreviousWaveButton;
        private System.Windows.Forms.GroupBox toolGroupBox;
        private System.Windows.Forms.Button emptySpaceButton;
        private System.Windows.Forms.Button PlaceEnemyButton;
        private System.Windows.Forms.Label totalWavesLabel;
        private System.Windows.Forms.GroupBox EquipedToolBox;
        private System.Windows.Forms.PictureBox equipedToolPictureBox;
        private System.Windows.Forms.Label CurrentWaveLabel;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.NumericUpDown delayUpDown;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}