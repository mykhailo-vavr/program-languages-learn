namespace TU_Shortest_Path_In_Graph_Visualization
{
    partial class BFSAlgorithm
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
            this.components = new System.ComponentModel.Container();
            this.Visualization = new System.Windows.Forms.PictureBox();
            this.NextStepButton = new System.Windows.Forms.Button();
            this.GoBackButton = new System.Windows.Forms.Button();
            this.ShortestPathLabel = new System.Windows.Forms.Label();
            this.CurrentNodeLabel = new System.Windows.Forms.Label();
            this.graphCreatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize) (this.Visualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.graphCreatorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Visualization
            // 
            this.Visualization.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Visualization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Visualization.Location = new System.Drawing.Point(9, 10);
            this.Visualization.Margin = new System.Windows.Forms.Padding(2);
            this.Visualization.Name = "Visualization";
            this.Visualization.Size = new System.Drawing.Size(929, 384);
            this.Visualization.TabIndex = 16;
            this.Visualization.TabStop = false;
            this.Visualization.Paint += new System.Windows.Forms.PaintEventHandler(this.Visualization_Paint);
            // 
            // NextStepButton
            // 
            this.NextStepButton.Location = new System.Drawing.Point(356, 456);
            this.NextStepButton.Margin = new System.Windows.Forms.Padding(2);
            this.NextStepButton.Name = "NextStepButton";
            this.NextStepButton.Size = new System.Drawing.Size(99, 48);
            this.NextStepButton.TabIndex = 18;
            this.NextStepButton.Text = "Next Step";
            this.NextStepButton.UseVisualStyleBackColor = true;
            this.NextStepButton.Click += new System.EventHandler(this.NextStepButton_Click);
            // 
            // GoBackButton
            // 
            this.GoBackButton.Location = new System.Drawing.Point(459, 456);
            this.GoBackButton.Margin = new System.Windows.Forms.Padding(2);
            this.GoBackButton.Name = "GoBackButton";
            this.GoBackButton.Size = new System.Drawing.Size(99, 48);
            this.GoBackButton.TabIndex = 23;
            this.GoBackButton.Text = "Go Back";
            this.GoBackButton.UseVisualStyleBackColor = true;
            this.GoBackButton.Click += new System.EventHandler(this.GoBackButton_Click);
            // 
            // ShortestPathLabel
            // 
            this.ShortestPathLabel.AutoSize = true;
            this.ShortestPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ShortestPathLabel.Location = new System.Drawing.Point(10, 511);
            this.ShortestPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ShortestPathLabel.Name = "ShortestPathLabel";
            this.ShortestPathLabel.Size = new System.Drawing.Size(98, 17);
            this.ShortestPathLabel.TabIndex = 24;
            this.ShortestPathLabel.Text = "Shortest Path:";
            // 
            // CurrentNodeLabel
            // 
            this.CurrentNodeLabel.AutoSize = true;
            this.CurrentNodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CurrentNodeLabel.Location = new System.Drawing.Point(10, 479);
            this.CurrentNodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentNodeLabel.Name = "CurrentNodeLabel";
            this.CurrentNodeLabel.Size = new System.Drawing.Size(101, 17);
            this.CurrentNodeLabel.TabIndex = 25;
            this.CurrentNodeLabel.Text = "Current Node: ";
            // 
            // graphCreatorBindingSource
            // 
            this.graphCreatorBindingSource.RaiseListChangedEvents = false;
            // 
            // BFSAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(946, 540);
            this.Controls.Add(this.CurrentNodeLabel);
            this.Controls.Add(this.ShortestPathLabel);
            this.Controls.Add(this.GoBackButton);
            this.Controls.Add(this.NextStepButton);
            this.Controls.Add(this.Visualization);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BFSAlgorithm";
            ((System.ComponentModel.ISupportInitialize) (this.Visualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.graphCreatorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox Visualization;
        private System.Windows.Forms.BindingSource graphCreatorBindingSource;
        private System.Windows.Forms.Button NextStepButton;
        private System.Windows.Forms.Button GoBackButton;
        private System.Windows.Forms.Label ShortestPathLabel;
        private System.Windows.Forms.Label CurrentNodeLabel;
    }
}