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
    public partial class FirstStart : Form
    {
        private Form1 MainForm;

        public FirstStart(Form1 form1)
        {
            InitializeComponent();
            MainForm = form1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (steam.Checked)
            {
                MainForm.ImportFromSteam();
            }

            if (origin.Checked)
            {
                MainForm.ImportFromOrigin();
            }

            if (battlenet.Checked)
            {
                MainForm.ImportFromBattleNet();
            }

            if (goggalaxy.Checked)
            {
                MainForm.ImportFromGogGalaxy();
            }

            if (uplay.Checked)
            {
                MainForm.ImportFromuPlay();
            }

            this.Close();
        }
    }
}
