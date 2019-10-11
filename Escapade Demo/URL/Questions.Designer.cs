namespace URL
{
    partial class Questions
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
            this._tbxAnswer = new System.Windows.Forms.TextBox();
            this._pbxPictureQuestion = new System.Windows.Forms.PictureBox();
            this._btnEnterText = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._pbxPictureQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // _tbxAnswer
            // 
            this._tbxAnswer.Location = new System.Drawing.Point(12, 380);
            this._tbxAnswer.Name = "_tbxAnswer";
            this._tbxAnswer.Size = new System.Drawing.Size(562, 20);
            this._tbxAnswer.TabIndex = 0;
            // 
            // _pbxPictureQuestion
            // 
            this._pbxPictureQuestion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._pbxPictureQuestion.Location = new System.Drawing.Point(12, 12);
            this._pbxPictureQuestion.Name = "_pbxPictureQuestion";
            this._pbxPictureQuestion.Size = new System.Drawing.Size(562, 362);
            this._pbxPictureQuestion.TabIndex = 1;
            this._pbxPictureQuestion.TabStop = false;
            // 
            // _btnEnterText
            // 
            this._btnEnterText.Location = new System.Drawing.Point(12, 406);
            this._btnEnterText.Name = "_btnEnterText";
            this._btnEnterText.Size = new System.Drawing.Size(75, 23);
            this._btnEnterText.TabIndex = 2;
            this._btnEnterText.Text = "Enter";
            this._btnEnterText.UseVisualStyleBackColor = true;
            this._btnEnterText.Click += new System.EventHandler(this._btnEnterText_Click);
            // 
            // Questions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 441);
            this.Controls.Add(this._btnEnterText);
            this.Controls.Add(this._pbxPictureQuestion);
            this.Controls.Add(this._tbxAnswer);
            this.Name = "Questions";
            this.Text = "Questions";
            this.Load += new System.EventHandler(this.Questions_Load);
            ((System.ComponentModel.ISupportInitialize)(this._pbxPictureQuestion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbxAnswer;
        private System.Windows.Forms.PictureBox _pbxPictureQuestion;
        private System.Windows.Forms.Button _btnEnterText;
    }
}