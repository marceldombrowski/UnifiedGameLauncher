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
    public partial class AddGame : Form
    {
        public AddGame(HelperClass MyHelper)
        {
            InitializeComponent();
            MyHelperClass = MyHelper;
        }

        private HelperClass MyHelperClass;

        public delegate void CallbackEventHandler();
        public event CallbackEventHandler Callback;

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
                        } else
                        {
                            secondaryTextBox.Text = RenamingHashtable.GetNiceName(myName);
                        }
                    }
                }

                if (tertiaryTextBox != null)
                {
                    tertiaryTextBox.Text = openFileDialog1.FileName;
                    Console.WriteLine("set text");
                }
            }
            CheckIfAllEntriesAreValid();
        }

        private void browseImage_Click(object sender, EventArgs e)
        {
            ShowOpenDialog("Images|*.png;*.jpg;*.jpeg;*.bmp", gameImage, gameImagePreview);
        }

        private void clearListButton_Click(object sender, EventArgs e)
        {
            ClearEntries();
        }

        private void ClearEntries()
        {
            gameName.Text = "";
            gameExecutable.Text = "";
            gameImage.Text = "";
            gameImagePreview.Image = null;
            addGameButton.Enabled = false;
        }

        private void CheckIfAllEntriesAreValid()
        {
            if (gameName.Text.Length > 0 && gameExecutable.Text.Length > 0 && gameImage.Text.Length > 0)
            {
                addGameButton.Enabled = true;
            } else
            {
                addGameButton.Enabled = false;
            }
        }

        private void gameName_TextChanged(object sender, EventArgs e)
        {
            CheckIfAllEntriesAreValid();
        }

        private void AddGame_Load(object sender, EventArgs e)
        {

        }

        private void addGameButton_Click(object sender, EventArgs e)
        {
            MyHelperClass.AddEntry(new GameEntry(MyHelperClass.GetNextId(), gameName.Text, gameExecutable.Text, gameImage.Text));
            {
                string[] mySplitString = gameExecutable.Text.Split('\\');
                string myString = mySplitString[mySplitString.Length - 1];
                string myName = myString.Substring(0, myString.Length - 4);
                RenamingHashtable.AddEntry(myName, gameName.Text);
            }
            
            ClearEntries();
            if (Callback != null)
            {
                Callback();
            }
        }

        private void AddGame_Shown(object sender, EventArgs e)
        {
            ShowOpenDialog("Executables|*.exe", gameExecutable, gameImagePreview, gameName, gameImage);
        }
    }
}
