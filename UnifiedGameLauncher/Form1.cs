using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnifiedGameLauncher
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HelperClass MyHelper;
        private AddGame MyAddGameForm;
        private Options MyOptionsForm;

        public Form1()
        {
            InitializeComponent();
        }

        public void SetListStyle(int style)
        {
            gameList.View = (View)style;
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\MarcelDombrowski", "Style", style);
        }

        public void ChangeTheme(bool lightTheme)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\MarcelDombrowski", "UseLightTheme", lightTheme == true ? "1" : "0");
            if (lightTheme)
            {
                gameList.BackColor = Color.White;
                gameList.ForeColor = Color.Black;
                menuStrip1.BackColor = Color.White;
                menuStrip1.ForeColor = Color.Black;
            } else
            {
                gameList.BackColor = Color.FromArgb(50, 50, 50);
                gameList.ForeColor = Color.White;
                menuStrip1.BackColor = Color.FromArgb(50, 50, 50);
                menuStrip1.ForeColor = Color.White;
            }
        }

        private void LoadSettings()
        {
            var registryKeyExists = Registry.CurrentUser.OpenSubKey("Software\\MarcelDombrowski", true);
            if (registryKeyExists == null)
                Registry.CurrentUser.CreateSubKey("Software\\MarcelDombrowski");
            {
            }
            int style = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\MarcelDombrowski", "Style", 4);
            gameList.View = (View)style;

            int locationX = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\MarcelDombrowski", "LocationX", Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width);
            int locationY = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\MarcelDombrowski", "LocationY", 0);
            int height = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\MarcelDombrowski", "Height", Screen.PrimaryScreen.WorkingArea.Height);

            this.Size = new Size(this.Size.Width, height);
            this.Location = new Point(locationX, locationY);

            ChangeTheme(((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\MarcelDombrowski", "UseLightTheme", "1")).Equals("1") ? true : false);
        }

        public void EmptyList()
        {
            MyHelper.Callback += RefreshMenu;
            MyHelper.EmptyList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyHelper = new HelperClass();
            RefreshMenu();

            LoadSettings();

            Form1_Resize(sender, e);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            gameList.Size = new Size(this.Width - 1, this.Height - menuStrip1.Height - 1);
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
            string steamPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", "");
            if (steamPath.Equals(""))
            {
                MessageBox.Show("Could not find Steam, please select the directory where you installed Steam.", "Could not find Steam", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                folderBrowserDialog1.SelectedPath = @"C:\Games\Steam";
                folderBrowserDialog1.Description = "Choose Steam Root Folder";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    MyHelper.Callback += RefreshMenu;
                    MyHelper.ImportFromSteam(folderBrowserDialog1.SelectedPath);
                }
            } else
            {
                MyHelper.Callback += RefreshMenu;
                MyHelper.ImportFromSteam(steamPath);
            }
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
                gameList.LargeImageList.ImageSize = new Size(48, 48);
            }
            gameList.LargeImageList.Images.Clear();
            if (gameList.StateImageList == null)
            {
                gameList.StateImageList = new ImageList();
                gameList.StateImageList.ImageSize = new Size(48, 48);
            }
            gameList.StateImageList.Images.Clear();


            int i = 0;
            foreach (GameEntry ge in MyList)
            {
                gameList.SmallImageList.Images.Add(GetImage(ge));
                gameList.LargeImageList.Images.Add(GetImage(ge));
                gameList.StateImageList.Images.Add(GetImage(ge));
                gameList.Items.Add(ge.GameName, i++);                
            }
        }

        private Image GetImage(GameEntry ge)
        {
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\icons"))
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\icons\\" + ge.GameName + ".bmp"))
                {
                    return Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\icons\\" + ge.GameName + ".bmp");
                }
            }

            if (ge.GameImage.Substring(ge.GameImage.Length - 4, 4).Equals(".exe"))
            {
                return Icon.ExtractAssociatedIcon(ge.GameImage).ToBitmap();
            }
            else
            {
                return Bitmap.FromFile(ge.GameImage);
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
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\MarcelDombrowski", "LocationX", this.Location.X);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\MarcelDombrowski", "LocationY", this.Location.Y);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\MarcelDombrowski", "Height", this.Size.Height);

            MyHelper.SaveAsJson();
            RenamingHashtable.SaveHashtable();
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
            } else if (e.Button == MouseButtons.Middle)
            {
                
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

        private void originToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyHelper.ImportFromOrigin();
        }

        private void battlenetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyHelper.ImportFromBattleNet();
        }

        private void gOGGalaxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyHelper.ImportFromGogGalaxy();
        }

        private void uPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyHelper.ImportFromUPlay();
        }

        private void gameList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                RunSelectedItem();
            }
        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyOptionsForm = new Options(this);
            MyOptionsForm.Show();
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
