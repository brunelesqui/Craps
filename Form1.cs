using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Craps
{
    public partial class Form1 : Form
    {
        private Craps gameCraps;
        private Craps.Status status;
        private decimal bet;
        private decimal total;

        public decimal Total
        {
            get
            {
                return total;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameCraps = new Craps();
            Reset();

            SetTitle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            status = gameCraps.ThrowDice();

            LoadDices();
            lblPoint.Text = gameCraps.Point.ToString();

            bet = Convert.ToDecimal(txtBet.Text);
            txtBet.Enabled = false;

            switch (status)
            {
                case Craps.Status.CONTINUE:
                    break;
                case Craps.Status.WIN:
                    MessageBox.Show( "¡GANASTE!" );
                    Calculate();
                    Reset();
                    break;
                case Craps.Status.LOSE:
                case Craps.Status.CRAPS:
                    MessageBox.Show( (status == Craps.Status.CRAPS ? "CRAPS!" : "LO SIENTO, HAS PERDIDO") );
                    Calculate();
                    Reset();
                    break;
            }

            SetTitle();
        }

        private void Calculate()
        {
            if (status == Craps.Status.WIN)
                total += bet;
            else
                total -= bet;

            txtTotalPoints.Text = total.ToString();
        }

        private void Reset()
        {
            gameCraps.Reset();
            status = Craps.Status.START;
            lblPoint.Text = string.Empty;
            pictureBox1.Image = Image.FromFile("dice_face_one.JPG");
            pictureBox2.Image = Image.FromFile("dice_face_two.JPG");
            bet = 0;
            txtBet.Enabled = true;
        }

        private void SetTitle()
        {
            switch(status)
            {
                case Craps.Status.CONTINUE:
                    this.Text = "Craps [JUGANDO]";
                    break;
                default:
                    this.Text = "Craps [LISTO]";
                    break;
            }
        }

        private void LoadDices()
        {
            String[] DICES_FILES = 
                { "none",
                  "dice_face_one",
                  "dice_face_two",
                  "dice_face_three",
                  "dice_face_four",
                  "dice_face_five",
                  "dice_face_six"
                };

            pictureBox1.Image = Image.FromFile(DICES_FILES[gameCraps.Dice1] + ".JPG");
            pictureBox2.Image = Image.FromFile(DICES_FILES[gameCraps.Dice2] + ".JPG");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
