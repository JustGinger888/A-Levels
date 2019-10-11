namespace URL
{
    partial class MainGame
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
            this.pbx_MainItem = new System.Windows.Forms.PictureBox();
            this._GridMainMap = new System.Windows.Forms.Panel();
            this._lblRetry = new System.Windows.Forms.Label();
            this._GridMiniMap = new System.Windows.Forms.Panel();
            this._tmrMovementCheck = new System.Windows.Forms.Timer(this.components);
            this._tmrInputCheck = new System.Windows.Forms.Timer(this.components);
            this._BombCount = new System.Windows.Forms.Label();
            this._KeyCount = new System.Windows.Forms.Label();
            this._ChestCount = new System.Windows.Forms.Label();
            this._CoinCount = new System.Windows.Forms.Label();
            this._tmrEnemyMovement = new System.Windows.Forms.Timer(this.components);
            this._tmrBulletCheck = new System.Windows.Forms.Timer(this.components);
            this._pnlEnemyHealthGrid = new System.Windows.Forms.Panel();
            this._pnlCharacterHealthGrid = new System.Windows.Forms.Panel();
            this._tmrAStar = new System.Windows.Forms.Timer(this.components);
            this._tmrEnemyRespawn = new System.Windows.Forms.Timer(this.components);
            this._lblExit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_MainItem)).BeginInit();
            this._GridMainMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbx_MainItem
            // 
            this.pbx_MainItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbx_MainItem.Location = new System.Drawing.Point(35, 12);
            this.pbx_MainItem.Name = "pbx_MainItem";
            this.pbx_MainItem.Size = new System.Drawing.Size(58, 58);
            this.pbx_MainItem.TabIndex = 0;
            this.pbx_MainItem.TabStop = false;
            // 
            // _GridMainMap
            // 
            this._GridMainMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this._GridMainMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._GridMainMap.Controls.Add(this._lblRetry);
            this._GridMainMap.Location = new System.Drawing.Point(256, 136);
            this._GridMainMap.Name = "_GridMainMap";
            this._GridMainMap.Size = new System.Drawing.Size(530, 323);
            this._GridMainMap.TabIndex = 15;
            // 
            // _lblRetry
            // 
            this._lblRetry.AutoSize = true;
            this._lblRetry.BackColor = System.Drawing.Color.Transparent;
            this._lblRetry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblRetry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblRetry.ForeColor = System.Drawing.Color.Lime;
            this._lblRetry.Location = new System.Drawing.Point(231, 263);
            this._lblRetry.Name = "_lblRetry";
            this._lblRetry.Size = new System.Drawing.Size(66, 22);
            this._lblRetry.TabIndex = 23;
            this._lblRetry.Text = "RETRY";
            this._lblRetry.Visible = false;
            this._lblRetry.Click += new System.EventHandler(this._lblRetry_Click);
            // 
            // _GridMiniMap
            // 
            this._GridMiniMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this._GridMiniMap.Location = new System.Drawing.Point(864, 347);
            this._GridMiniMap.Name = "_GridMiniMap";
            this._GridMiniMap.Size = new System.Drawing.Size(113, 113);
            this._GridMiniMap.TabIndex = 16;
            // 
            // _tmrMovementCheck
            // 
            this._tmrMovementCheck.Interval = 200;
            this._tmrMovementCheck.Tick += new System.EventHandler(this._tmrMovementCheck_Tick);
            // 
            // _tmrInputCheck
            // 
            this._tmrInputCheck.Interval = 1000;
            this._tmrInputCheck.Tick += new System.EventHandler(this._tmrInputCheck_Tick);
            // 
            // _BombCount
            // 
            this._BombCount.AutoSize = true;
            this._BombCount.BackColor = System.Drawing.Color.Transparent;
            this._BombCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._BombCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BombCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this._BombCount.Location = new System.Drawing.Point(68, 125);
            this._BombCount.Name = "_BombCount";
            this._BombCount.Size = new System.Drawing.Size(51, 22);
            this._BombCount.TabIndex = 17;
            this._BombCount.Text = "TEST";
            // 
            // _KeyCount
            // 
            this._KeyCount.AutoSize = true;
            this._KeyCount.BackColor = System.Drawing.Color.Transparent;
            this._KeyCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._KeyCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._KeyCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this._KeyCount.Location = new System.Drawing.Point(68, 170);
            this._KeyCount.Name = "_KeyCount";
            this._KeyCount.Size = new System.Drawing.Size(51, 22);
            this._KeyCount.TabIndex = 18;
            this._KeyCount.Text = "TEST";
            // 
            // _ChestCount
            // 
            this._ChestCount.AutoSize = true;
            this._ChestCount.BackColor = System.Drawing.Color.Transparent;
            this._ChestCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ChestCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ChestCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this._ChestCount.Location = new System.Drawing.Point(68, 209);
            this._ChestCount.Name = "_ChestCount";
            this._ChestCount.Size = new System.Drawing.Size(51, 22);
            this._ChestCount.TabIndex = 19;
            this._ChestCount.Text = "TEST";
            // 
            // _CoinCount
            // 
            this._CoinCount.AutoSize = true;
            this._CoinCount.BackColor = System.Drawing.Color.Transparent;
            this._CoinCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._CoinCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CoinCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this._CoinCount.Location = new System.Drawing.Point(68, 249);
            this._CoinCount.Name = "_CoinCount";
            this._CoinCount.Size = new System.Drawing.Size(51, 22);
            this._CoinCount.TabIndex = 20;
            this._CoinCount.Text = "TEST";
            // 
            // _tmrEnemyMovement
            // 
            this._tmrEnemyMovement.Interval = 200;
            this._tmrEnemyMovement.Tick += new System.EventHandler(this._tmrEnemyMovement_Tick);
            // 
            // _tmrBulletCheck
            // 
            this._tmrBulletCheck.Tick += new System.EventHandler(this._tmrBulletCheck_Tick);
            // 
            // _pnlEnemyHealthGrid
            // 
            this._pnlEnemyHealthGrid.BackColor = System.Drawing.Color.Transparent;
            this._pnlEnemyHealthGrid.Location = new System.Drawing.Point(758, 12);
            this._pnlEnemyHealthGrid.Name = "_pnlEnemyHealthGrid";
            this._pnlEnemyHealthGrid.Size = new System.Drawing.Size(258, 26);
            this._pnlEnemyHealthGrid.TabIndex = 21;
            // 
            // _pnlCharacterHealthGrid
            // 
            this._pnlCharacterHealthGrid.BackColor = System.Drawing.Color.Transparent;
            this._pnlCharacterHealthGrid.Location = new System.Drawing.Point(99, 12);
            this._pnlCharacterHealthGrid.Name = "_pnlCharacterHealthGrid";
            this._pnlCharacterHealthGrid.Size = new System.Drawing.Size(520, 26);
            this._pnlCharacterHealthGrid.TabIndex = 22;
            // 
            // _tmrAStar
            // 
            this._tmrAStar.Enabled = true;
            this._tmrAStar.Tick += new System.EventHandler(this._tmrAStar_Tick);
            // 
            // _tmrEnemyRespawn
            // 
            this._tmrEnemyRespawn.Interval = 1000;
            this._tmrEnemyRespawn.Tick += new System.EventHandler(this._tmrEnemyRespawn_Tick);
            // 
            // _lblExit
            // 
            this._lblExit.AutoSize = true;
            this._lblExit.BackColor = System.Drawing.Color.Transparent;
            this._lblExit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblExit.ForeColor = System.Drawing.Color.Lime;
            this._lblExit.Location = new System.Drawing.Point(445, 84);
            this._lblExit.Name = "_lblExit";
            this._lblExit.Size = new System.Drawing.Size(153, 22);
            this._lblExit.TabIndex = 24;
            this._lblExit.Text = "Press Space To Exit";
            this._lblExit.Visible = false;
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::URL.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1053, 622);
            this.Controls.Add(this._lblExit);
            this.Controls.Add(this._pnlCharacterHealthGrid);
            this.Controls.Add(this._pnlEnemyHealthGrid);
            this.Controls.Add(this._CoinCount);
            this.Controls.Add(this._ChestCount);
            this.Controls.Add(this._KeyCount);
            this.Controls.Add(this._BombCount);
            this.Controls.Add(this._GridMiniMap);
            this.Controls.Add(this._GridMainMap);
            this.Controls.Add(this.pbx_MainItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainGame";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_MainItem)).EndInit();
            this._GridMainMap.ResumeLayout(false);
            this._GridMainMap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_MainItem;
        private System.Windows.Forms.Panel _GridMainMap;
        private System.Windows.Forms.Panel _GridMiniMap;
        private System.Windows.Forms.Timer _tmrInputCheck;
        private System.Windows.Forms.Label _BombCount;
        private System.Windows.Forms.Label _KeyCount;
        private System.Windows.Forms.Label _ChestCount;
        private System.Windows.Forms.Label _CoinCount;
        public System.Windows.Forms.Timer _tmrMovementCheck;
        private System.Windows.Forms.Timer _tmrEnemyMovement;
        private System.Windows.Forms.Timer _tmrBulletCheck;
        private System.Windows.Forms.Panel _pnlEnemyHealthGrid;
        private System.Windows.Forms.Panel _pnlCharacterHealthGrid;
        private System.Windows.Forms.Timer _tmrAStar;
        private System.Windows.Forms.Label _lblRetry;
        private System.Windows.Forms.Timer _tmrEnemyRespawn;
        private System.Windows.Forms.Label _lblExit;
    }
}

