using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;

namespace Tetris
{
    public partial class Scores : Form
    {
        public Scores(Hashtable table)
        {
            InitializeComponent();

            ICollection keys = table.Keys;

            int k = 0;
            foreach(string s in keys)
            {
                Label labelDate = new Label();
                labelDate.Text = s;
                tabelLayoutScore.Controls.Add(labelDate, 0, k);

                Label labelVal = new Label();
                labelVal.Text = Convert.ToString(table[s]);
                tabelLayoutScore.Controls.Add(labelVal, 1, k);

                k++;
            }
        }

        private void tabelLayoutScore_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
