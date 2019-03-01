namespace BlankspaceTool
{
    partial class Form1
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
            this.LoadButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.wavesCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.CreateNewButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wavesCountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(12, 12);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(234, 84);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.ClickLoad);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.wavesCountUpDown);
            this.groupBox1.Controls.Add(this.CreateNewButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 180);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create New";
            // 
            // wavesCountUpDown
            // 
            this.wavesCountUpDown.Location = new System.Drawing.Point(103, 30);
            this.wavesCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.wavesCountUpDown.Name = "wavesCountUpDown";
            this.wavesCountUpDown.Size = new System.Drawing.Size(125, 20);
            this.wavesCountUpDown.TabIndex = 3;
            this.wavesCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CreateNewButton
            // 
            this.CreateNewButton.Location = new System.Drawing.Point(9, 67);
            this.CreateNewButton.Name = "CreateNewButton";
            this.CreateNewButton.Size = new System.Drawing.Size(219, 107);
            this.CreateNewButton.TabIndex = 2;
            this.CreateNewButton.Text = "Create New";
            this.CreateNewButton.UseVisualStyleBackColor = true;
            this.CreateNewButton.Click += new System.EventHandler(this.ClickCreate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Waves: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 294);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LoadButton);
            this.Name = "Form1";
            this.Text = "Waves Manager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wavesCountUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CreateNewButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown wavesCountUpDown;
    }
}

