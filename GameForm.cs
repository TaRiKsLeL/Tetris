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
        public GameForm()
        {
            InitializeComponent();
            setLabels();
        }

        void setLabels()
        {
            for(int i=0; i < tableLayoutPanel1.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    Label label = new Label();
                    label.BackColor = Color.Aqua;
                    label.Dock = DockStyle.Fill;
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
