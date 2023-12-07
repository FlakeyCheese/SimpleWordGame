using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWordGame
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            string help1 = "You have 20 seconds to make a word. You gain 1 point for each letter in the word. If the word is not in the dictionary you get no points\r\n";
            string help2 = "Your word must have at least 3 letters to count. You can spell your word anywhere in the green boxes but the first word only will be assessed\r\n";
            string help3 = " Drag letters from the yellow boxes to the gren to spell a word. You can use letters more than once.\r\n";
            string help4 = "your turn is over if you have not clicked the GO button on a valid word before the time runs out.\r\n";
            label2.Text = help1 + help2 + help3 + help4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
