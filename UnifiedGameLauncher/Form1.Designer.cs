namespace UnifiedGameLauncher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameList = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.steamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.originToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.battlenetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gOGGalaxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manuallyAddGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameList
            // 
            this.gameList.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameList.FullRowSelect = true;
            this.gameList.Location = new System.Drawing.Point(0, 24);
            this.gameList.MultiSelect = false;
            this.gameList.Name = "gameList";
            this.gameList.Size = new System.Drawing.Size(121, 97);
            this.gameList.TabIndex = 0;
            this.gameList.TileSize = new System.Drawing.Size(300, 50);
            this.gameList.UseCompatibleStateImageBehavior = false;
            this.gameList.View = System.Windows.Forms.View.Tile;
            this.gameList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gameList_KeyPress);
            this.gameList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameList_MouseClick);
            this.gameList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gameList_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.minimizeToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(345, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.manuallyAddGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 20);
            this.toolStripMenuItem1.Text = "&Launcher";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.steamToolStripMenuItem,
            this.originToolStripMenuItem,
            this.battlenetToolStripMenuItem,
            this.gOGGalaxyToolStripMenuItem,
            this.uPlayToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(224, 22);
            this.toolStripMenuItem2.Text = "Import From";
            // 
            // steamToolStripMenuItem
            // 
            this.steamToolStripMenuItem.Name = "steamToolStripMenuItem";
            this.steamToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.steamToolStripMenuItem.Text = "Steam";
            this.steamToolStripMenuItem.Click += new System.EventHandler(this.steamToolStripMenuItem_Click);
            // 
            // originToolStripMenuItem
            // 
            this.originToolStripMenuItem.Name = "originToolStripMenuItem";
            this.originToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.originToolStripMenuItem.Text = "Origin";
            this.originToolStripMenuItem.Click += new System.EventHandler(this.originToolStripMenuItem_Click);
            // 
            // battlenetToolStripMenuItem
            // 
            this.battlenetToolStripMenuItem.Name = "battlenetToolStripMenuItem";
            this.battlenetToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.battlenetToolStripMenuItem.Text = "Battle.net";
            this.battlenetToolStripMenuItem.Click += new System.EventHandler(this.battlenetToolStripMenuItem_Click);
            // 
            // gOGGalaxyToolStripMenuItem
            // 
            this.gOGGalaxyToolStripMenuItem.Name = "gOGGalaxyToolStripMenuItem";
            this.gOGGalaxyToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.gOGGalaxyToolStripMenuItem.Text = "GOG Galaxy";
            this.gOGGalaxyToolStripMenuItem.Click += new System.EventHandler(this.gOGGalaxyToolStripMenuItem_Click);
            // 
            // uPlayToolStripMenuItem
            // 
            this.uPlayToolStripMenuItem.Name = "uPlayToolStripMenuItem";
            this.uPlayToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.uPlayToolStripMenuItem.Text = "UPlay";
            this.uPlayToolStripMenuItem.Click += new System.EventHandler(this.uPlayToolStripMenuItem_Click);
            // 
            // manuallyAddGameToolStripMenuItem
            // 
            this.manuallyAddGameToolStripMenuItem.Name = "manuallyAddGameToolStripMenuItem";
            this.manuallyAddGameToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.manuallyAddGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.manuallyAddGameToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.manuallyAddGameToolStripMenuItem.Text = "Manually &Add Game";
            this.manuallyAddGameToolStripMenuItem.Click += new System.EventHandler(this.manuallyAddGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            this.toolStripSeparator1.Click += new System.EventHandler(this.toolStripSeparator1_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 70);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 761);
            this.Controls.Add(this.gameList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(345, 1500);
            this.MinimumSize = new System.Drawing.Size(345, 39);
            this.Name = "Form1";
            this.Text = "KoMa Unified Game Launcher YES - v0.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView gameList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem steamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem originToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem battlenetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gOGGalaxyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manuallyAddGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
    }
}

