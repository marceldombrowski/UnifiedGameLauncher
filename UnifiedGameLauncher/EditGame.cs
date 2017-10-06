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
    public partial class EditGame : Form
    {
        private GameEntry myEntry;
        private int myId;

        public delegate void CallbackEventHandler(int id, GameEntry updatedEntry);
        public event CallbackEventHandler Callback;

        public EditGame(int id, GameEntry entry)
        {
            InitializeComponent();
            myEntry = entry;
            myId = id;
        }

        private void clearListButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void EditGame_Load(object sender, EventArgs e)
        {
            gameName.Text = myEntry.GameName;
            gameExecutable.Text = myEntry.GameArgs;
            gameImage.Text = myEntry.GameImage;
            gameImagePreview.Image = GetImage(myEntry);
        }

        private void browseExecutable_Click(object sender, EventArgs e)
        {
            ShowOpenDialog("Executables|*.exe", gameExecutable, gameImagePreview, gameName, gameImage);
        }

        private void ShowOpenDialog(string filter, TextBox textBox, PictureBox imageBox = null, TextBox secondaryTextBox = null, TextBox tertiaryTextBox = null)
        {
            openFileDialog1.Filter = filter;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = openFileDialog1.FileName;
                if (imageBox != null)
                {
                    if (tertiaryTextBox != null)
                    {
                        imageBox.Image = Icon.ExtractAssociatedIcon(openFileDialog1.FileName).ToBitmap();
                    }
                    else
                    {
                        imageBox.Image = Image.FromFile(openFileDialog1.FileName);
                    }
                }

                if (secondaryTextBox != null)
                {
                    if (secondaryTextBox.Text.Length == 0)
                    {
                        string[] mySplitString = openFileDialog1.FileName.Split('\\');
                        string myString = mySplitString[mySplitString.Length - 1];
                        string myName = myString.Substring(0, myString.Length - 4);
                        if (RenamingHashtable.GetNiceName(myName).Equals("UNDEFINED"))
                        {
                            secondaryTextBox.Text = myName;
                        }
                        else
                        {
                            secondaryTextBox.Text = RenamingHashtable.GetNiceName(myName);
                        }
                    }
                }

                if (tertiaryTextBox != null)
                {
                    tertiaryTextBox.Text = openFileDialog1.FileName;
                }
            }
        }

        private void browseImage_Click(object sender, EventArgs e)
        {
            ShowOpenDialog("Images|*.png;*.jpg;*.jpeg;*.bmp", gameImage, gameImagePreview);
        }

        private void addGameButton_Click(object sender, EventArgs e)
        {
            myEntry.GameName = gameName.Text;
            myEntry.GameArgs = gameExecutable.Text;
            myEntry.GameImage = gameImage.Text;

            if (Callback != null)
            {
                Callback(myId, myEntry);
            }

            this.Close();
        }
    }
}
