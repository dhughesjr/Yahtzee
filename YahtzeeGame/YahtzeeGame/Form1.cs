using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YahtzeeGame
{
    public partial class Form1 : Form
    {
        #region Declaration

        Image[] diceImages;
        int[] dice;
        //control the rolls count per turn
        int begrollcount = 3;
        //controlls whether the die is held
        int holdcount1 = new int();
        int holdcount2 = new int();
        int holdcount3 = new int();
        int holdcount4 = new int();
        int holdcount5 = new int();
        //some counter for the bonus yahtzee
        int yzbonuscount = 0;
        int yzbonus = 0;
        //counter that is turn on when a scoring option is chosen and accpeted
        int threekcnt = 0;
        Stack<int> frank = new Stack<int>();

        #endregion

        #region Initialization

        public Form1()
        {
            InitializeComponent();
            //button13.Hide();
            //calling the function rolls to paly randomize a stack of 195 rolls of dice
            RollDice();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            diceImages = new Image[7];
            diceImages[0] = Properties.Resources.dice_blank;
            diceImages[1] = Properties.Resources.dice_1;
            diceImages[2] = Properties.Resources.dice_2;
            diceImages[3] = Properties.Resources.dice_3;
            diceImages[4] = Properties.Resources.dice_4;
            diceImages[5] = Properties.Resources.dice_5;
            diceImages[6] = Properties.Resources.dice_6;

            dice = new int[5] { 0, 0, 0, 0, 0 };

            //hide the unhold buttons
            btnNoHold1.Hide();
            btnNoHold2.Hide();
            btnNoHold3.Hide();
            btnNoHold4.Hide();
            btnNoHold5.Hide();
        }

        #endregion

        #region Private Methods

        private void btn_rollDice_Click(object sender, EventArgs e)
        { 
            RollDice();

            //simulating the roll of the die
            if (holdcount1 < 1)
            {
                int francis1 = frank.Pop();
                //figure out how to change to dice images instead...
                //TextBox1.Text = francis1.ToString();
            }
            if (holdcount2 < 1)
            {
                int francis2 = frank.Pop();
                //figure out how to change to dice images instead...
                //TextBox1.Text = francis1.ToString();
            }
            if (holdcount3 < 1)
            {
                int francis3 = frank.Pop();
                //figure out how to change to dice images instead...
                //TextBox1.Text = francis1.ToString();
            }
            if (holdcount4 < 1)
            {
                int francis4 = frank.Pop();
                //figure out how to change to dice images instead...
                //TextBox1.Text = francis1.ToString();
            }
            if (holdcount5 < 1)
            {
                int francis5 = frank.Pop();
                //figure out how to change to dice images instead...
                //TextBox1.Text = francis1.ToString();
            }

            //GetResults();

            //ResetDice();
        }


        private void RollDice()
        {
            //the stack is a global variable and is populated within this function
            Stack<Int32> mcsc = new Stack<int>();
            //the random sorts out the one through 6
            Random mark = new Random();
            //the array of 195
            int[] rolls = new int[195];
            //running through the array to make 195 attempts
            for (int i = 0; i < 195; i++)
            {
                rolls[i] = mark.Next(1,7);
            }
                
            //filling the stack
            foreach(int element in rolls)
            {
                mcsc.Push(element);
            }

            //frank = mcsc;

            lbl_dice1.Image = diceImages[dice[0]];
            lbl_dice2.Image = diceImages[dice[1]];
            lbl_dice3.Image = diceImages[dice[2]];
            lbl_dice4.Image = diceImages[dice[3]];
            lbl_dice5.Image = diceImages[dice[4]];
        }

        //private void GetResults()
        //{
           
        //}

        //private void ResetDice()
        //{
            
        //}

        #endregion

        private void btnHold1_Click(object sender, EventArgs e)
        {
            holdcount1 += 1;
            btnNoHold1.Show();
            btnHold1.Hide();
        }

        private void btnHold2_Click(object sender, EventArgs e)
        {
            holdcount2 += 1;
            btnNoHold2.Show();
            btnHold2.Hide();
        }

        private void btnHold3_Click(object sender, EventArgs e)
        {
            holdcount3 += 1;
            btnNoHold3.Show();
            btnHold3.Hide();
        }

        private void btnHold4_Click(object sender, EventArgs e)
        {
            holdcount4 += 1;
            btnNoHold4.Show();
            btnHold4.Hide();
        }

        private void btnHold5_Click(object sender, EventArgs e)
        {
            holdcount5 += 1;
            btnNoHold5.Show();
            btnHold5.Hide();
        }

        private void btnNoHold1_Click(object sender, EventArgs e)
        {
            holdcount1 -= 1;
            btnNoHold1.Hide();
            btnHold1.Show();
        }

        private void btnNoHold2_Click(object sender, EventArgs e)
        {
            holdcount2 -= 1;
            btnNoHold1.Hide();
            btnHold2.Show();
        }

        private void btnNoHold3_Click(object sender, EventArgs e)
        {
            holdcount3 -= 1;
            btnNoHold1.Hide();
            btnHold3.Show();
        }

        private void btnNoHold4_Click(object sender, EventArgs e)
        {
            holdcount4 -= 1;
            btnNoHold1.Hide();
            btnHold4.Show();
        }

        private void btnNoHold5_Click(object sender, EventArgs e)
        {
            holdcount5 -= 1;
            btnNoHold1.Hide();
            btnHold5.Show();
        }
        //generate a score
        private void btnScoreGen_Click(object sender, EventArgs e)
        {
            //create a 1d array to capture the results in and 5 single integers to filll these values
            int[] resultset = new int[5];
            int rs1 = new int();
            int rs2 = new int();
            int rs3 = new int();
            int rs4 = new int();
            int rs5 = new int();

            //the integers are made from converting the textbox/ lable text to an int
            //this may need changed to use the images...

            rs1 = Convert.ToInt32(textBox1.Text);
            rs2 = Convert.ToInt32(textBox2.Text);
            rs3 = Convert.ToInt32(textBox3.Text);
            rs4 = Convert.ToInt32(textBox4.Text);
            rs5 = Convert.ToInt32(textBox5.Text);

            resultset[0] = rs1;
            resultset[1] = rs2;
            resultset[2] = rs3;
            resultset[3] = rs4;
            resultset[4] = rs5;

            //this array is sent with the code below.
            //there is logic that checks for a previous yahtzee.
            if (threekcnt == 1)
            {
                bonuscheck(rs1, rs2, rs3, rs4, rs5);
                ResultClass alfa = new ResultClass();
                int rolledschore = new int();
                rolledscore = alfa.threeofakind(resultset);
                label24.Text = rolledscore.ToString();
            }
        }
    }
}
