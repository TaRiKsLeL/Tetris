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
    public partial class GameForm : Form
    {
        int[,] masiv = new int[22, 12];
        int x=6;
        int prevX;
        int k = 0;
        public GameForm()
        {
            InitializeComponent();

            setLabels();

            setFrame(masiv);
            printArray(masiv);
            setLabelsFromArray(masiv);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!checkLose(masiv))
            {
                if (masiv[k + 1, x] != 1 && masiv[k + 1, x] != 2)
                {
                    if (prevX != 0)
                    {
                        masiv[k, prevX] = 0;
                    }
                    masiv[k, x] = 0;
                    masiv[k + 1, x] = 3;
                    k++;
                }
                else //якщо наступне є двійкою або одиничкою
                {
                    masiv[k, x] = 2;
                    k = 0;
                    x = 6;
                }

                if (k == 0 && getWinRowIndex(masiv) != 0)  //якщо фігура зупинилась і є заповнений рядок
                {
                    int ind = getWinRowIndex(masiv);

                    for (int i = 0; i < masiv.Length / (masiv.GetUpperBound(0) + 1); i++)
                    {
                        masiv[ind, i] = 0;
                    }
                    setFrame(masiv);
                    ///////////////////////////.....//        ЗАКІНЧИТИ ЗАБИРАННЯ РЯДКА ПО ІНДЕКСУ І ЗСУВАННЯ
                }
                setLabelsFromArray(masiv);
                printArray(masiv);
            }
            else
            {
                timer1.Enabled = false;
                closeGame();
                MessageBox.Show("LOSE", "!!!");
            }
            Invalidate();
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
            int rows = masiv.GetUpperBound(0) + 1;
            int cols = masiv.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j == 0 || j == cols - 1)
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

        bool checkLose(int [,] array)
        {
            bool flag = false;
            for(int i=0;i<array.Length / (array.GetUpperBound(0) + 1); i++)
            {
                if (array[1, i] == 2)
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }

        int getWinRowIndex(int [,] array) //Ще повинно ігнорити перше і станнє
        {
            int rows = masiv.GetUpperBound(0) + 1;
            int cols = masiv.Length / rows;

            int q = 0;
            int index=0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] == 2)
                    {
                        q++;
                    }
                }
                if (q == 10)
                {
                    index = i;
                    break;
                }
                else
                {
                    q = 0;
                }
            }

            return index;
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (x > 0 || x < 10)
                {
                    prevX = x;
                    x -= 1;
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                if (x > 0 || x < 10)
                {
                    prevX = x;
                    x += 1;
                }
            }
        }

        public void closeGame()
        {
            this.Close();
        }
        void setLabelsFromArray(int[,] array)
        {
            int rows = masiv.GetUpperBound(0) + 1;
            int cols = masiv.Length / rows;

            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    if (array[i + 1, j + 1] == 0)
                    {
                        tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.Gray;
                    }

                    if (array[i + 1, j + 1] == 1)
                    {
                        tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.DarkCyan;
                    }
                    if (array[i + 1, j + 1] == 3 || array[i + 1, j + 1] == 2)
                    {
                        tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.OrangeRed;
                    }
                }
            }
            
        }

        void setLabels()
        {
            for(int i=0; i < tableLayoutPanel1.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    Label label = new Label();
                    label.Dock = DockStyle.Fill;
                    label.BackColor = Color.Gray;
                    label.Margin = new Padding(2);
                    tableLayoutPanel1.Controls.Add(label,j,i);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        
    }
}
