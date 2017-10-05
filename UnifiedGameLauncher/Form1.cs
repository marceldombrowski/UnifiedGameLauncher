using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnifiedGameLauncher
{
    public partial class Form1 : Form
    {
        private HelperClass MyHelper;
        private AddGame MyAddGameForm;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyHelper = new HelperClass();
            RefreshMenu();

            Form1_Resize(sender, e);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            gameList.Size = new Size(this.Width, this.Height - menuStrip1.Height - 24);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void steamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyHelper.ImportFromSteam();
        }

        private void RefreshMenu()
        {
            List<GameEntry> MyList = MyHelper.GetList();

            gameList.Items.Clear();
            if (gameList.SmallImageList == null)
            {
                gameList.SmallImageList = new ImageList();
            }
            gameList.SmallImageList.Images.Clear();
            if (gameList.LargeImageList == null)
            {
                gameList.LargeImageList = new ImageList();
            }
            gameList.LargeImageList.Images.Clear();


            int i = 0;
            foreach (GameEntry ge in MyList)
            {
                gameList.SmallImageList.Images.Add(Bitmap.FromFile(ge.GameImage));
                gameList.LargeImageList.Images.Add(Bitmap.FromFile(ge.GameImage));
                gameList.Items.Add(ge.GameName, i++);                
            }
        }

        private void manuallyAddGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyAddGameForm = new AddGame(MyHelper);
            MyAddGameForm.Callback += RefreshMenu;
            MyAddGameForm.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyHelper.SaveAsJson();
        }

        private void RunSelectedItem()
        {
            System.Diagnostics.Process.Start(MyHelper.GetExecutable(gameList.SelectedIndices[0]));
        }

        private void gameList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RunSelectedItem();
        }

        private void gameList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (gameList.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunSelectedItem();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyHelper.RemoveEntry(gameList.SelectedIndices[0]);
            gameList.Items.RemoveAt(gameList.SelectedIndices[0]);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(c) 2017, Marcel Dombrowski", "About KoMa UGLy", MessageBoxButtons.OK);
        }
    }
}
