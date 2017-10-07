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
                button1.BackColor = Color.White;
                button1.ForeColor = Color.Black;
            } else
            {
                gameList.BackColor = Color.FromArgb(50, 50, 50);
                gameList.ForeColor = Color.White;
                menuStrip1.BackColor = Color.FromArgb(50, 50, 50);
                menuStrip1.ForeColor = Color.White;
                button1.BackColor = Color.FromArgb(50, 50, 50);
                button1.ForeColor = Color.White;
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

            if (!File.Exists("gameList.json"))
            {
                FirstStart firstStart = new FirstStart(this);
                firstStart.Show();
            }
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

        public void ImportFromSteam()
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
            }
            else
            {
                MyHelper.Callback += RefreshMenu;
                MyHelper.ImportFromSteam(steamPath);
            }
        }

        public void ImportFromOrigin()
        {
            MyHelper.ImportFromOrigin();
        }

        public void ImportFromBattleNet()
        {
            MyHelper.ImportFromBattleNet();
        }

        public void ImportFromGogGalaxy()
        {
            MyHelper.ImportFromGogGalaxy();
        }

        public void ImportFromuPlay()
        {
            MyHelper.ImportFromUPlay();
        }

        private void steamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFromSteam();   
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

        private void EntryUpdated(int id, GameEntry updatedEntry)
        {
            MyHelper.UpdateEntry(id, updatedEntry);
            RefreshMenu();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditGame editGame = new EditGame(gameList.SelectedIndices[0], MyHelper.GetEntry(gameList.SelectedIndices[0]));
            editGame.Callback += EntryUpdated;
            editGame.Show();

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyHelper.RemoveEntry(gameList.SelectedIndices[0]);
            gameList.Items.RemoveAt(gameList.SelectedIndices[0]);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void originToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFromOrigin();
        }

        private void battlenetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFromBattleNet();
        }

        private void gOGGalaxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFromGogGalaxy();
        }

        private void uPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFromuPlay();
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
            
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void steamToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://store.steampowered.com/");
        }

        private void originToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.origin.com/");
        }

        private void battlenetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://us.battle.net/shop/en/");
        }

        private void gogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.gog.com/");
        }

        private void uPlayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://store.ubi.com/");
        }

        protected override void WndProc(ref Message m)
        {
            const UInt32 WM_NCHITTEST = 0x0084;
            const UInt32 WM_MOUSEMOVE = 0x0200;

            const UInt32 HTLEFT = 10;
            const UInt32 HTRIGHT = 11;
            const UInt32 HTBOTTOMRIGHT = 17;
            const UInt32 HTBOTTOM = 15;
            const UInt32 HTBOTTOMLEFT = 16;
            const UInt32 HTTOP = 12;
            const UInt32 HTTOPLEFT = 13;
            const UInt32 HTTOPRIGHT = 14;

            const int RESIZE_HANDLE_SIZE = 10;
            bool handled = false;
            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                Dictionary<UInt32, Rectangle> boxes = new Dictionary<UInt32, Rectangle>() {
            {HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
            {HTBOTTOM, new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
            {HTBOTTOMRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
            {HTRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE)},
            {HTTOPRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
            {HTTOP, new Rectangle(RESIZE_HANDLE_SIZE, 0, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
            {HTTOPLEFT, new Rectangle(0, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
            {HTLEFT, new Rectangle(0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE) }
        };

                foreach (KeyValuePair<UInt32, Rectangle> hitBox in boxes)
                {
                    if (hitBox.Value.Contains(clientPoint))
                    {
                        m.Result = (IntPtr)hitBox.Key;
                        handled = true;
                        break;
                    }
                }
            }

            if (!handled)
                base.WndProc(ref m);
        }

        private void showFirstStartWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FirstStart firstStart = new FirstStart(this);
            firstStart.Show();
        }
    }
}
