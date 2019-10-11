namespace PathFinder
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlGridPanel = new System.Windows.Forms.Panel();
            this.btnSetLocation1 = new System.Windows.Forms.Button();
            this.btnSetLocation2 = new System.Windows.Forms.Button();
            this.lstRouteFound = new System.Windows.Forms.ListBox();
            this.cbxDiagonalMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(475, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Path Finder - An Implementation of the A* Algorithm for a 2D grid space.\r\n(c) 24t" +
    "h November 2018, Kane Lean (Poole High School). Code provided under GNUv3 Licens" +
    "ing. ";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(160, 535);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(655, 33);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Find Path Between Loc1 (Start) and Loc2 (End)";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnFindPath_Generate);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(821, 528);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(152, 40);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Reload Grid";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlGridPanel
            // 
            this.pnlGridPanel.Location = new System.Drawing.Point(15, 50);
            this.pnlGridPanel.Name = "pnlGridPanel";
            this.pnlGridPanel.Size = new System.Drawing.Size(800, 480);
            this.pnlGridPanel.TabIndex = 6;
            // 
            // btnSetLocation1
            // 
            this.btnSetLocation1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSetLocation1.Location = new System.Drawing.Point(821, 445);
            this.btnSetLocation1.Name = "btnSetLocation1";
            this.btnSetLocation1.Size = new System.Drawing.Size(152, 34);
            this.btnSetLocation1.TabIndex = 10;
            this.btnSetLocation1.Text = "Set Selected Space as Location 1";
            this.btnSetLocation1.UseVisualStyleBackColor = false;
            this.btnSetLocation1.Click += new System.EventHandler(this.btnSetLocation1_Click);
            // 
            // btnSetLocation2
            // 
            this.btnSetLocation2.BackColor = System.Drawing.Color.Red;
            this.btnSetLocation2.Location = new System.Drawing.Point(821, 485);
            this.btnSetLocation2.Name = "btnSetLocation2";
            this.btnSetLocation2.Size = new System.Drawing.Size(152, 37);
            this.btnSetLocation2.TabIndex = 11;
            this.btnSetLocation2.Text = "Set Selected Space as Location 2";
            this.btnSetLocation2.UseVisualStyleBackColor = false;
            this.btnSetLocation2.Click += new System.EventHandler(this.btnSetLocation2_Click);
            // 
            // lstRouteFound
            // 
            this.lstRouteFound.BackColor = System.Drawing.Color.Gainsboro;
            this.lstRouteFound.FormattingEnabled = true;
            this.lstRouteFound.Location = new System.Drawing.Point(821, 50);
            this.lstRouteFound.Name = "lstRouteFound";
            this.lstRouteFound.Size = new System.Drawing.Size(152, 381);
            this.lstRouteFound.TabIndex = 12;
            // 
            // cbxDiagonalMode
            // 
            this.cbxDiagonalMode.AutoSize = true;
            this.cbxDiagonalMode.Location = new System.Drawing.Point(15, 544);
            this.cbxDiagonalMode.Name = "cbxDiagonalMode";
            this.cbxDiagonalMode.Size = new System.Drawing.Size(126, 17);
            this.cbxDiagonalMode.TabIndex = 13;
            this.cbxDiagonalMode.Text = "Use diagonal pathing";
            this.cbxDiagonalMode.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 575);
            this.Controls.Add(this.cbxDiagonalMode);
            this.Controls.Add(this.lstRouteFound);
            this.Controls.Add(this.btnSetLocation2);
            this.Controls.Add(this.btnSetLocation1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pnlGridPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A* Pathfinding Sample - Poole High School (Mr K. Lean)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlGridPanel;
        private System.Windows.Forms.Button btnSetLocation1;
        private System.Windows.Forms.Button btnSetLocation2;
        private System.Windows.Forms.ListBox lstRouteFound;
        private System.Windows.Forms.CheckBox cbxDiagonalMode;
    }
}

