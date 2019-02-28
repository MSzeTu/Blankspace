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
            this.SuspendLayout();
            // 
            // waveGroupBox
            // 
            this.waveGroupBox.Location = new System.Drawing.Point(180, 12);
            this.waveGroupBox.Name = "waveGroupBox";
            this.waveGroupBox.Size = new System.Drawing.Size(506, 519);
            this.waveGroupBox.TabIndex = 0;
            this.waveGroupBox.TabStop = false;
            this.waveGroupBox.Text = "Wave 1";
            // 
            // NextWaveButton
            // 
            this.NextWaveButton.Location = new System.Drawing.Point(99, 504);
            this.NextWaveButton.Name = "NextWaveButton";
            this.NextWaveButton.Size = new System.Drawing.Size(75, 23);
            this.NextWaveButton.TabIndex = 1;
            this.NextWaveButton.Text = "Next";
            this.NextWaveButton.UseVisualStyleBackColor = true;
            this.NextWaveButton.Click += new System.EventHandler(this.NextWaveButton_Click);
            // 
            // PreviousWaveButton
            // 
            this.PreviousWaveButton.Location = new System.Drawing.Point(12, 504);
            this.PreviousWaveButton.Name = "PreviousWaveButton";
            this.PreviousWaveButton.Size = new System.Drawing.Size(75, 23);
            this.PreviousWaveButton.TabIndex = 2;
            this.PreviousWaveButton.Text = "Previous";
            this.PreviousWaveButton.UseVisualStyleBackColor = true;
            this.PreviousWaveButton.Click += new System.EventHandler(this.PreviousWaveButton_Click);
            // 
            // WavesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 539);
            this.Controls.Add(this.PreviousWaveButton);
            this.Controls.Add(this.NextWaveButton);
            this.Controls.Add(this.waveGroupBox);
            this.Name = "WavesEditor";
            this.Text = "WavesEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox waveGroupBox;
        private System.Windows.Forms.Button NextWaveButton;
        private System.Windows.Forms.Button PreviousWaveButton;
    }
}