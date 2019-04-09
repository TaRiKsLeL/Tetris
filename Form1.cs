using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace Tetris
{
    public partial class Form1 : Form
    {

        public static Hashtable scores = new Hashtable();

        public Form1()
        {
            InitializeComponent();
            shapeCB.SelectedIndex = 1;
        }

        

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        [STAThread]
        private void startBtn_Click(object sender, EventArgs e)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            int gameSpeed;

            if (lowBtn.Checked)
            {
                gameSpeed = 1;
            }
            else if(mediumBtn.Checked)
            {
                gameSpeed = 2;
            }
            else
            {
                gameSpeed = 3;
            }


            new GameForm(shapeCB.SelectedIndex,gameSpeed).ShowDialog();

        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            new Scores(scores).ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
