using Microsoft.Win32;
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
    public partial class Options : Form
    {
        private Form1 MyMainForm;

        public Options(Form1 mainForm)
        {
            InitializeComponent();
            MyMainForm = mainForm;
        }

        private void Options_Load(object sender, EventArgs e)
        {
            bool useLightTheme = ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\MarcelDombrowski", "UseLightTheme", "1")).Equals("1") ? true : false;
            if (useLightTheme)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            } else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }

            pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\data\\tile.png");
            pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\data\\largeIcon.png");
            pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\data\\list.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MyMainForm.SetListStyle(4);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MyMainForm.SetListStyle(0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MyMainForm.SetListStyle(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MyMainForm.ChangeTheme(true);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            MyMainForm.ChangeTheme(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to remove all games from the list?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MyMainForm.EmptyList();
            }
        }
    }
}
