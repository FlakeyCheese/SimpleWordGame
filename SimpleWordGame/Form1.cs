using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWordGame
{
    public partial class Form1 : Form
    {
        List<string> wordList = new List<string>();
        Random rnd = new Random();
        int highScore=0;
        int currentScore=0;
         Label[] letters = new Label[8] ;
        Label[] answer = new Label[8];
        int count = 20;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            StreamReader file = new StreamReader("../../resources/ukenglish.txt") ;
            {
                
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    if (ln.Length > 2 && ln.Length < 9)
                    { wordList.Add(ln); }
                    
                }
                file.Close();
               
            }
            button2.Enabled = true;
            answer[0] = label1;
            answer[1] = label2;
            answer[2] = label3;
            answer[3] = label4;
            answer[4] = label5;
            answer[5] = label6;
            answer[6] = label7;
            answer[7] = label8;
            letters[0] = label9;
            letters[1] = label10;
            letters[2] = label11;
            letters[3] = label12;
            letters[4] = label13;
            letters[5] = label14;
            letters[6] = label15;
            letters[7] = label16;
        }
        
           
        private void button2_Click(object sender, EventArgs e)
        {
            label17.BackColor = Color.White;
            label17.Text = count.ToString();
            label18.Text = highScore.ToString();
            button2.Enabled = false;
            button1.Enabled = true;
            currentScore = 0;
            label21.Text = currentScore.ToString();
            gameTimer.Enabled = true;
            populateLetters();
        }
        public void populateLetters()
        {
            int vowelCount = rnd.Next(2, 4);
            for (int i = 0; i < vowelCount; i++)
            { letters[i].Text = generateVowel().ToString(); }
            for (int i = vowelCount; i < 8; i++)
            {
                letters[i].Text = generateUpper().ToString();
            }
        }
        public char generateUpper()
        {
            //Random Uppercase letter:
                        
            int ascii_index = rnd.Next(65, 91); //ASCII character codes 65-90
            char myRandomUpperCase = Convert.ToChar(ascii_index); //produces any char A-Z
            return myRandomUpperCase;
        }
        public char generateVowel()
        {
            //Random Vowel:
            char[] vowels = { 'A', 'E', 'I', 'O', 'U' };
                        int i = rnd.Next(0, 4);
            return vowels[i];
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            int time = Int32.Parse(label17.Text);
            time--;
            label17.Text = time.ToString();
            if (time ==0)
            { gameTimer.Enabled = false;
                label17.BackColor = Color.Red;
                button1.Enabled = false;
                button2.Enabled = true;
                if (currentScore > highScore) { highScore = currentScore; }
                for (int i = 0; i < 8; i++)
                { answer[i].Text = ""; }
            }
        }

        private void Common_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                 { e.Effect = DragDropEffects.Copy; }
        }

        private void Common_DragDrop(object sender, DragEventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Text = (string)e.Data.GetData(DataFormats.Text);
            button1.Focus();
        }

        private void Common_MouseDown(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            if (e.Button==MouseButtons.Left)
            { DoDragDrop(lbl.Text, DragDropEffects.Copy);
               // lbl.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get word from labels 1 to 8
            string word = "";
            Boolean over = false;
            for (int i = 0;i<8;i++)
            {
                if (answer[i].Text!="" && !over )

                {
                    word = word + answer[i].Text;
                }
                else if (answer[i].Text=="" &&!over && word.Length>0)
                { over = true; }
            }

            //check word is valid
            Boolean valid = false;
            if (wordList.Contains(word.ToLower()))
            { valid = true; }
            //if valid word convert to points
            if (valid)
            {
                int roundPoints = word.Length;
                currentScore = (Int32.Parse(label21.Text)) + roundPoints;
                // check points and reduce counter if >30
                if (currentScore > 30) { count--; }
                label21.Text = currentScore.ToString();
                //check if this word is the longest and update label accordingly
                if (roundPoints > Int32.Parse(label23.Text))
                    { label23.Text = roundPoints.ToString(); }
                //clear all letter labels
                for (int i = 0; i < 8; i++)
                { answer[i].Text = ""; }
                // reset timer
                label17.Text = count.ToString();
                //generate new letters
                populateLetters();
            }
            else
            { 
                
                for (int i = 0; i < 8; i++)
                {
                    answer[i].Text = "";
                                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
    }
}
