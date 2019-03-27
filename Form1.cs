using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        int[,] masiv = new int[22,12];

        public Form1()
        {
            InitializeComponent();
            setFrame(masiv);
            printArray(masiv);
        }

        void printArray(int[,] arr)
        {
            int rows = masiv.GetUpperBound(0) + 1;
            int cols = masiv.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }

        }
        void setFrame(int[,] masiv)
        {
            int rows= masiv.GetUpperBound(0) + 1;
            int cols = masiv.Length / rows;

            for (int i = 0; i < rows; i++) 
            {
                for (int j = 0; j < cols; j++) 
                {
                    if (i == 0)
                    {
                        masiv[i, j] = 1;
                    }
                    if(j==0 || j == cols - 1)
                    {
                        masiv[i, j] = 1;
                    }
                    if (i == rows - 1)
                    {
                        masiv[i, j] = 1;
                    }
                }
            }
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

            new GameForm().ShowDialog();

        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
