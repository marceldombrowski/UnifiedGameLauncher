namespace UnifiedGameLauncher
{
    partial class EditGame
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
            this.browseImage = new System.Windows.Forms.Button();
            this.gameImagePreview = new System.Windows.Forms.PictureBox();
            this.gameImage = new System.Windows.Forms.TextBox();
            this.gameName = new System.Windows.Forms.TextBox();
            this.gameExecutable = new System.Windows.Forms.TextBox();
            this.clearListButton = new System.Windows.Forms.Button();
            this.addGameButton = new System.Windows.Forms.Button();
            this.browseExecutable = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gameImagePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // browseImage
            // 
            this.browseImage.Location = new System.Drawing.Point(189, 58);
            this.browseImage.Name = "browseImage";
            this.browseImage.Size = new System.Drawing.Size(75, 23);
            this.browseImage.TabIndex = 1004;
            this.browseImage.Text = "Browse...";
            this.browseImage.UseVisualStyleBackColor = true;
            // 
            // gameImagePreview
            // 
            this.gameImagePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gameImagePreview.Location = new System.Drawing.Point(270, 32);
            this.gameImagePreview.Name = "gameImagePreview";
            this.gameImagePreview.Size = new System.Drawing.Size(48, 48);
            this.gameImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameImagePreview.TabIndex = 1007;
            this.gameImagePreview.TabStop = false;
            // 
            // gameImage
            // 
            this.gameImage.Location = new System.Drawing.Point(83, 61);
            this.gameImage.Name = "gameImage";
            this.gameImage.Size = new System.Drawing.Size(100, 20);
            this.gameImage.TabIndex = 1003;
            // 
            // gameName
            // 
            this.gameName.Location = new System.Drawing.Point(83, 6);
            this.gameName.Name = "gameName";
            this.gameName.Size = new System.Drawing.Size(181, 20);
            this.gameName.TabIndex = 1000;
            // 
            // gameExecutable
            // 
            this.gameExecutable.Location = new System.Drawing.Point(83, 34);
            this.gameExecutable.Name = "gameExecutable";
            this.gameExecutable.Size = new System.Drawing.Size(100, 20);
            this.gameExecutable.TabIndex = 1001;
            // 
            // clearListButton
            // 
            this.clearListButton.Location = new System.Drawing.Point(108, 87);
            this.clearListButton.Name = "clearListButton";
            this.clearListButton.Size = new System.Drawing.Size(75, 23);
            this.clearListButton.TabIndex = 1006;
            this.clearListButton.Text = "Discard";
            this.clearListButton.UseVisualStyleBackColor = true;
            this.clearListButton.Click += new System.EventHandler(this.clearListButton_Click);
            // 
            // addGameButton
            // 
            this.addGameButton.Location = new System.Drawing.Point(15, 88);
            this.addGameButton.Name = "addGameButton";
            this.addGameButton.Size = new System.Drawing.Size(75, 23);
            this.addGameButton.TabIndex = 1005;
            this.addGameButton.Text = "Confirm";
            this.addGameButton.UseVisualStyleBackColor = true;
            this.addGameButton.Click += new System.EventHandler(this.addGameButton_Click);
            // 
            // browseExecutable
            // 
            this.browseExecutable.Location = new System.Drawing.Point(189, 32);
            this.browseExecutable.Name = "browseExecutable";
            this.browseExecutable.Size = new System.Drawing.Size(75, 23);
            this.browseExecutable.TabIndex = 1002;
            this.browseExecutable.Text = "Browse...";
            this.browseExecutable.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 1008;
            this.label3.Text = "Image:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1010;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1009;
            this.label1.Text = "Executable:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // EditGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 123);
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
            this.Name = "EditGame";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Entry";
            this.Load += new System.EventHandler(this.EditGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameImagePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browseImage;
        private System.Windows.Forms.PictureBox gameImagePreview;
        private System.Windows.Forms.TextBox gameImage;
        private System.Windows.Forms.TextBox gameName;
        private System.Windows.Forms.TextBox gameExecutable;
        private System.Windows.Forms.Button clearListButton;
        private System.Windows.Forms.Button addGameButton;
        private System.Windows.Forms.Button browseExecutable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}