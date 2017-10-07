namespace UnifiedGameLauncher
{
    partial class FirstStart
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.steam = new System.Windows.Forms.CheckBox();
            this.origin = new System.Windows.Forms.CheckBox();
            this.battlenet = new System.Windows.Forms.CheckBox();
            this.goggalaxy = new System.Windows.Forms.CheckBox();
            this.uplay = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select the services you want to import your games from:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uplay);
            this.groupBox1.Controls.Add(this.goggalaxy);
            this.groupBox1.Controls.Add(this.battlenet);
            this.groupBox1.Controls.Add(this.origin);
            this.groupBox1.Controls.Add(this.steam);
            this.groupBox1.Location = new System.Drawing.Point(7, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 153);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Launchers";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(230, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // steam
            // 
            this.steam.AutoSize = true;
            this.steam.Checked = true;
            this.steam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.steam.Location = new System.Drawing.Point(7, 20);
            this.steam.Name = "steam";
            this.steam.Size = new System.Drawing.Size(56, 17);
            this.steam.TabIndex = 0;
            this.steam.Text = "Steam";
            this.steam.UseVisualStyleBackColor = true;
            // 
            // origin
            // 
            this.origin.AutoSize = true;
            this.origin.Enabled = false;
            this.origin.Location = new System.Drawing.Point(7, 43);
            this.origin.Name = "origin";
            this.origin.Size = new System.Drawing.Size(53, 17);
            this.origin.TabIndex = 1;
            this.origin.Text = "Origin";
            this.origin.UseVisualStyleBackColor = true;
            // 
            // battlenet
            // 
            this.battlenet.AutoSize = true;
            this.battlenet.Enabled = false;
            this.battlenet.Location = new System.Drawing.Point(7, 66);
            this.battlenet.Name = "battlenet";
            this.battlenet.Size = new System.Drawing.Size(71, 17);
            this.battlenet.TabIndex = 4;
            this.battlenet.Text = "Battle.net";
            this.battlenet.UseVisualStyleBackColor = true;
            // 
            // goggalaxy
            // 
            this.goggalaxy.AutoSize = true;
            this.goggalaxy.Enabled = false;
            this.goggalaxy.Location = new System.Drawing.Point(7, 89);
            this.goggalaxy.Name = "goggalaxy";
            this.goggalaxy.Size = new System.Drawing.Size(81, 17);
            this.goggalaxy.TabIndex = 5;
            this.goggalaxy.Text = "Gog Galaxy";
            this.goggalaxy.UseVisualStyleBackColor = true;
            // 
            // uplay
            // 
            this.uplay.AutoSize = true;
            this.uplay.Enabled = false;
            this.uplay.Location = new System.Drawing.Point(7, 112);
            this.uplay.Name = "uplay";
            this.uplay.Size = new System.Drawing.Size(52, 17);
            this.uplay.TabIndex = 6;
            this.uplay.Text = "uPlay";
            this.uplay.UseVisualStyleBackColor = true;
            // 
            // FirstStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 235);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstStart";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "First Start";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox uplay;
        private System.Windows.Forms.CheckBox goggalaxy;
        private System.Windows.Forms.CheckBox battlenet;
        private System.Windows.Forms.CheckBox origin;
        private System.Windows.Forms.CheckBox steam;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}