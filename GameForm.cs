using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace Tetris
{
    public partial class GameForm : Form
    {
        public int[,] masiv = new int[22, 12];
        public int[,] nextFigureMasiv = new int[6, 6];

        int score=0;

        public static Hashtable scores2 = Form1.scores;

        public Image grayImage = Image.FromFile("gray21.png");
        public Image orangeImage = Image.FromFile("orange211.png");
        public Image redImage = Image.FromFile("red21.png");

        System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer();

        Figure f;


        public GameForm(int shapeColor, int speed)
        {
            InitializeComponent();
            this.FormClosing += GameForm_FormClosing;




           soundPlayer.SoundLocation = "tetris02.wav";
           

            setLabels(tableLayoutPanel1);
            setLabels(tableLayoutPanel2);


            f = new Figure();
            f = f.makeNewFigure(this);

            setFrame(masiv);
            
            setLabelsFromArray(masiv,tableLayoutPanel1);

            if (speed == 1)
            {
                timer1.Interval = 400;
            }
            else if(speed==2)
            {

                timer1.Interval = 140;
            }
            else
            {
                timer1.Interval = 50;
            }

            timer1.Enabled = true;
            soundPlayer.PlayLooping();

            printArray(masiv);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!checkLose(masiv))
            {
                if (!f.ElemBelowIs(1) && !f.ElemBelowIs(2))
                {
                    f.moveBelow();
                }
                else //якщо наступне є двійкою або одиничкою
                {
                    f.disableFigure();
                    f = f.makeNewFigure(this);
                }

                if (getWinRowIndex(masiv) != 0)  //якщо фігура зупинилась і є заповнений рядок
                {
                    int ind = getWinRowIndex(masiv);

                    if (ind == masiv.Length / (masiv.GetUpperBound(0)))
                    {
                        for (int i = 0; i < masiv.Length / (masiv.GetUpperBound(0) + 1); i++)
                        {
                            masiv[ind, i] = 0;
                        }
                        setFrame(masiv);
                    }

                    moveRows(masiv, ind);

                   score += 100;
                   scoreLbl.Text = "SCORE:" + score;
                    if (score % 500 == 0)
                    {
                        timer1.Interval -= 20;
                    }
                }
                setLabelsFromArray(masiv,tableLayoutPanel1);
                printArray(masiv);
            }
            else
            {
                timer1.Enabled = false;
                closeGame();
                

            }
            //Invalidate();
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

        void moveRows(int [,] arr,int winIndex)
        {
            int rows = masiv.GetUpperBound(0) + 1;
            int cols = masiv.Length / rows;

            int rowInd = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (arr[i, j] == 2)
                    {
                        rowInd=i;
                        break;
                    }
                }
                if (rowInd != 0)
                {
                    break;
                }
            }

            while (winIndex!=(rowInd-1))
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[winIndex, j] = arr[winIndex - 1, j];
                }
                winIndex--;
            }

    }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (f.allowMoveSideways(true))
                {
                    f.moveSideways(true);
                }
                
                    
            }

            if (e.KeyCode == Keys.Right)
            {
                if (f.allowMoveSideways(false))
                {
                    f.moveSideways(false);
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                if (!f.ElemBelowIs(1) && !f.ElemBelowIs(2))
                {
                    f.rotate(f.figure);
                }
                
            }

            if (e.KeyCode == Keys.Down)
            {
                f.moveToBottom();
            }
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                    // The Exit method of the Application class was called.  
                    break;
                case CloseReason.FormOwnerClosing:
                    // The owner form is closing.  
                    break;
                case CloseReason.MdiFormClosing:
                    // The parent form is closing.  
                    break;
                case CloseReason.None:
                    // Unknown closing reason.  
                    break;
                case CloseReason.TaskManagerClosing:
                    // The application is being closed from the TaskManager.  
                    break;
                case CloseReason.UserClosing:
                    timer1.Enabled = false;
                    soundPlayer.Stop();
                    //this.Close();
                    // The user is closing the form through the UI.  
                    break;
                case CloseReason.WindowsShutDown:
                    // Windows is closing the application because it is shutting down.  
                    break;
            }
        }

        public void closeGame()
        {
            MessageBox.Show("LOSE", "!!!");
            scores2.Add(DateTime.Now.ToString("HH:mm:ss"), score);
            soundPlayer.Stop();
            this.Close();
        }
        public void setLabelsFromArray(int[,] array, TableLayoutPanel tableLayoutPanel)
        {
            int rows = array.GetUpperBound(0) + 1;
            int cols = array.Length / rows;

            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    if (array[i + 1, j + 1] == 0)
                    {
                        //tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.Gray;
                        tableLayoutPanel.GetControlFromPosition(j, i).BackgroundImage = grayImage;
                    }

                    if (array[i + 1, j + 1] == 1)
                    {
                        tableLayoutPanel.GetControlFromPosition(j, i).BackColor = Color.DarkCyan;
                    }
                    if (array[i + 1, j + 1] == 3)
                    {
                      //  tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.OrangeRed;
                        tableLayoutPanel.GetControlFromPosition(j, i).BackgroundImage = orangeImage;
                    }

                    if (array[i + 1, j + 1] == 2)
                    {
                        // tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.Red;
                        tableLayoutPanel.GetControlFromPosition(j, i).BackgroundImage = redImage;
                    }
                }
            }
            
        }

        void setLabels(TableLayoutPanel tableLayoutPanel)
        {
            for(int i=0; i < tableLayoutPanel.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel.ColumnCount; j++)
                {
                    Label label = new Label();
                    label.ImageAlign = ContentAlignment.MiddleLeft;
                    label.Dock = DockStyle.Fill;
                    label.BackColor = Color.Gray;
                    label.Margin = new Padding(0);
                    tableLayoutPanel.Controls.Add(label,j,i);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
