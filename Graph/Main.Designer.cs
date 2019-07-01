namespace WindowsFormsApp1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxMatrix = new System.Windows.Forms.PictureBox();
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Results = new System.Windows.Forms.RichTextBox();
            this.Random = new System.Windows.Forms.Button();
            this.Grid = new System.Windows.Forms.CheckBox();
            this.Clear = new System.Windows.Forms.Button();
            this.Dijkstra = new System.Windows.Forms.Button();
            this.VertexID = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VertexID)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1002, 573);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.pictureBoxGraph);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(994, 547);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Graph";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureBoxMatrix);
            this.panel2.Location = new System.Drawing.Point(463, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 541);
            this.panel2.TabIndex = 3;
            // 
            // pictureBoxMatrix
            // 
            this.pictureBoxMatrix.BackColor = System.Drawing.Color.White;
            this.pictureBoxMatrix.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMatrix.Name = "pictureBoxMatrix";
            this.pictureBoxMatrix.Size = new System.Drawing.Size(525, 541);
            this.pictureBoxMatrix.TabIndex = 3;
            this.pictureBoxMatrix.TabStop = false;
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.BackColor = System.Drawing.Color.White;
            this.pictureBoxGraph.Location = new System.Drawing.Point(7, 4);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(450, 540);
            this.pictureBoxGraph.TabIndex = 0;
            this.pictureBoxGraph.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(994, 547);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Results";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.Results);
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 534);
            this.panel1.TabIndex = 1;
            // 
            // Results
            // 
            this.Results.Location = new System.Drawing.Point(4, 4);
            this.Results.Name = "Results";
            this.Results.ReadOnly = true;
            this.Results.Size = new System.Drawing.Size(974, 527);
            this.Results.TabIndex = 0;
            this.Results.Text = "";
            // 
            // Random
            // 
            this.Random.Location = new System.Drawing.Point(314, 4);
            this.Random.Name = "Random";
            this.Random.Size = new System.Drawing.Size(77, 24);
            this.Random.TabIndex = 1;
            this.Random.Text = "Random";
            this.Random.UseVisualStyleBackColor = true;
            this.Random.Click += new System.EventHandler(this.Random_Click);
            // 
            // Grid
            // 
            this.Grid.AutoSize = true;
            this.Grid.Checked = true;
            this.Grid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Grid.Location = new System.Drawing.Point(397, 9);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(45, 17);
            this.Grid.TabIndex = 2;
            this.Grid.Text = "Grid";
            this.Grid.UseVisualStyleBackColor = true;
            this.Grid.CheckedChanged += new System.EventHandler(this.Grid_CheckedChanged);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(235, 4);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(77, 24);
            this.Clear.TabIndex = 3;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Dijkstra
            // 
            this.Dijkstra.Location = new System.Drawing.Point(154, 4);
            this.Dijkstra.Name = "Dijkstra";
            this.Dijkstra.Size = new System.Drawing.Size(77, 24);
            this.Dijkstra.TabIndex = 4;
            this.Dijkstra.Text = "Dijkstra";
            this.Dijkstra.UseVisualStyleBackColor = true;
            this.Dijkstra.Click += new System.EventHandler(this.Dijkstra_Click);
            // 
            // VertexID
            // 
            this.VertexID.Location = new System.Drawing.Point(540, 4);
            this.VertexID.Name = "VertexID";
            this.VertexID.Size = new System.Drawing.Size(92, 20);
            this.VertexID.TabIndex = 6;
            this.VertexID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Starting vertex";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1026, 597);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VertexID);
            this.Controls.Add(this.Dijkstra);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.Random);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Graph";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VertexID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBoxGraph;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button Random;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxMatrix;
        private System.Windows.Forms.CheckBox Grid;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Dijkstra;
        private System.Windows.Forms.RichTextBox Results;
        private System.Windows.Forms.NumericUpDown VertexID;
        private System.Windows.Forms.Label label1;
    }
}

