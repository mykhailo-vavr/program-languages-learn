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
            this.Dimention = new System.Windows.Forms.TextBox();
            this.initialNode = new System.Windows.Forms.TextBox();
            this.terminalNode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.res1 = new System.Windows.Forms.Label();
            this.res2 = new System.Windows.Forms.Label();
            this.shortestPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Dimention
            // 
            this.Dimention.Location = new System.Drawing.Point(173, 28);
            this.Dimention.Margin = new System.Windows.Forms.Padding(2);
            this.Dimention.Name = "Dimention";
            this.Dimention.Size = new System.Drawing.Size(76, 20);
            this.Dimention.TabIndex = 0;
            this.Dimention.TextChanged += new System.EventHandler(this.Dimention_TextChanged);
            // 
            // initialNode
            // 
            this.initialNode.Location = new System.Drawing.Point(173, 52);
            this.initialNode.Margin = new System.Windows.Forms.Padding(2);
            this.initialNode.Name = "initialNode";
            this.initialNode.Size = new System.Drawing.Size(76, 20);
            this.initialNode.TabIndex = 1;
            // 
            // terminalNode
            // 
            this.terminalNode.Location = new System.Drawing.Point(173, 76);
            this.terminalNode.Margin = new System.Windows.Forms.Padding(2);
            this.terminalNode.Name = "terminalNode";
            this.terminalNode.Size = new System.Drawing.Size(76, 20);
            this.terminalNode.TabIndex = 2;
            this.terminalNode.TextChanged += new System.EventHandler(this.terminalNode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Baloo 2 SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Розмір";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Baloo 2 SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(15, 107);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(234, 37);
            this.button2.TabIndex = 7;
            this.button2.Text = "START";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Baloo 2 SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.label41.Location = new System.Drawing.Point(11, 221);
            this.label41.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(39, 22);
            this.label41.TabIndex = 8;
            this.label41.Text = "text1";
            this.label41.Visible = false;
            this.label41.Click += new System.EventHandler(this.label41_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Baloo 2 SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.label42.Location = new System.Drawing.Point(11, 288);
            this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(41, 22);
            this.label42.TabIndex = 9;
            this.label42.Text = "text2";
            this.label42.Visible = false;
            this.label42.Click += new System.EventHandler(this.label42_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Baloo 2 SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Початкова вершина";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Baloo 2 SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Кінцева вершина";
            // 
            // res1
            // 
            this.res1.AutoSize = true;
            this.res1.Font = new System.Drawing.Font("Baloo 2 SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.res1.Location = new System.Drawing.Point(344, 32);
            this.res1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.res1.Name = "res1";
            this.res1.Size = new System.Drawing.Size(41, 21);
            this.res1.TabIndex = 12;
            this.res1.Text = "text3";
            this.res1.Visible = false;
            // 
            // res2
            // 
            this.res2.AutoSize = true;
            this.res2.Font = new System.Drawing.Font("Baloo 2 SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.res2.Location = new System.Drawing.Point(625, 32);
            this.res2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.res2.Name = "res2";
            this.res2.Size = new System.Drawing.Size(41, 21);
            this.res2.TabIndex = 13;
            this.res2.Text = "text4";
            this.res2.Visible = false;
            this.res2.Click += new System.EventHandler(this.res2_Click);
            // 
            // shortestPath
            // 
            this.shortestPath.AutoSize = true;
            this.shortestPath.Font = new System.Drawing.Font("Baloo 2 SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.shortestPath.Location = new System.Drawing.Point(11, 167);
            this.shortestPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.shortestPath.Name = "shortestPath";
            this.shortestPath.Size = new System.Drawing.Size(92, 22);
            this.shortestPath.TabIndex = 14;
            this.shortestPath.Text = "ShortestPath";
            this.shortestPath.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(918, 405);
            this.Controls.Add(this.shortestPath);
            this.Controls.Add(this.res2);
            this.Controls.Add(this.res1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.terminalNode);
            this.Controls.Add(this.initialNode);
            this.Controls.Add(this.Dimention);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Dimention;
        private System.Windows.Forms.TextBox initialNode;
        private System.Windows.Forms.TextBox terminalNode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label res1;
        private System.Windows.Forms.Label res2;
        private System.Windows.Forms.Label shortestPath;
    }
}

