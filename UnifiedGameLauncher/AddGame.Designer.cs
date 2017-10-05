namespace UnifiedGameLauncher
{
    partial class AddGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.browseExecutable = new System.Windows.Forms.Button();
            this.addGameButton = new System.Windows.Forms.Button();
            this.clearListButton = new System.Windows.Forms.Button();
            this.gameExecutable = new System.Windows.Forms.TextBox();
            this.gameName = new System.Windows.Forms.TextBox();
            this.gameImage = new System.Windows.Forms.TextBox();
            this.gameImagePreview = new System.Windows.Forms.PictureBox();
            this.browseImage = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gameImagePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 998;
            this.label1.Text = "Executable:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 999;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 997;
            this.label3.Text = "Image:";
            // 
            // browseExecutable
            // 
            this.browseExecutable.Location = new System.Drawing.Point(189, 32);
            this.browseExecutable.Name = "browseExecutable";
            this.browseExecutable.Size = new System.Drawing.Size(75, 23);
            this.browseExecutable.TabIndex = 3;
            this.browseExecutable.Text = "Browse...";
            this.browseExecutable.UseVisualStyleBackColor = true;
            this.browseExecutable.Click += new System.EventHandler(this.browseExecutable_Click);
            // 
            // addGameButton
            // 
            this.addGameButton.Enabled = false;
            this.addGameButton.Location = new System.Drawing.Point(15, 88);
            this.addGameButton.Name = "addGameButton";
            this.addGameButton.Size = new System.Drawing.Size(75, 23);
            this.addGameButton.TabIndex = 6;
            this.addGameButton.Text = "Add Game";
            this.addGameButton.UseVisualStyleBackColor = true;
            this.addGameButton.Click += new System.EventHandler(this.addGameButton_Click);
            // 
            // clearListButton
            // 
            this.clearListButton.Location = new System.Drawing.Point(108, 87);
            this.clearListButton.Name = "clearListButton";
            this.clearListButton.Size = new System.Drawing.Size(75, 23);
            this.clearListButton.TabIndex = 7;
            this.clearListButton.Text = "Clear";
            this.clearListButton.UseVisualStyleBackColor = true;
            this.clearListButton.Click += new System.EventHandler(this.clearListButton_Click);
            // 
            // gameExecutable
            // 
            this.gameExecutable.Location = new System.Drawing.Point(83, 34);
            this.gameExecutable.Name = "gameExecutable";
            this.gameExecutable.Size = new System.Drawing.Size(100, 20);
            this.gameExecutable.TabIndex = 2;
            // 
            // gameName
            // 
            this.gameName.Location = new System.Drawing.Point(83, 6);
            this.gameName.Name = "gameName";
            this.gameName.Size = new System.Drawing.Size(181, 20);
            this.gameName.TabIndex = 1;
            this.gameName.TextChanged += new System.EventHandler(this.gameName_TextChanged);
            // 
            // gameImage
            // 
            this.gameImage.Location = new System.Drawing.Point(83, 61);
            this.gameImage.Name = "gameImage";
            this.gameImage.Size = new System.Drawing.Size(100, 20);
            this.gameImage.TabIndex = 4;
            // 
            // gameImagePreview
            // 
            this.gameImagePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gameImagePreview.Location = new System.Drawing.Point(270, 13);
            this.gameImagePreview.Name = "gameImagePreview";
            this.gameImagePreview.Size = new System.Drawing.Size(82, 82);
            this.gameImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameImagePreview.TabIndex = 9;
            this.gameImagePreview.TabStop = false;
            // 
            // browseImage
            // 
            this.browseImage.Location = new System.Drawing.Point(189, 58);
            this.browseImage.Name = "browseImage";
            this.browseImage.Size = new System.Drawing.Size(75, 23);
            this.browseImage.TabIndex = 5;
            this.browseImage.Text = "Browse...";
            this.browseImage.UseVisualStyleBackColor = true;
            this.browseImage.Click += new System.EventHandler(this.browseImage_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 123);
            this.Controls.Add(this.browseImage);
            this.Controls.Add(this.gameImagePreview);
            this.Controls.Add(this.gameImage);
            this.Controls.Add(this.gameName);
            this.Controls.Add(this.gameExecutable);
            this.Controls.Add(this.clearListButton);
            this.Controls.Add(this.addGameButton);
            this.Controls.Add(this.browseExecutable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddGame";
            this.ShowIcon = false;
            this.Text = "Manually Add Game";
            this.Load += new System.EventHandler(this.AddGame_Load);
            this.Shown += new System.EventHandler(this.AddGame_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gameImagePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button browseExecutable;
        private System.Windows.Forms.Button addGameButton;
        private System.Windows.Forms.Button clearListButton;
        private System.Windows.Forms.TextBox gameExecutable;
        private System.Windows.Forms.TextBox gameName;
        private System.Windows.Forms.TextBox gameImage;
        private System.Windows.Forms.PictureBox gameImagePreview;
        private System.Windows.Forms.Button browseImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}