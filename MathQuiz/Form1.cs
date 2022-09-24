using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //First statement calls the new StartTheQuiz() method.
            //Second statement sets the Enabled property of the
            //startButton control to false. So that the quiz taker can't
            //select the button during a quiz.
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\windows\media\Ring10.wav");
                player.Play();
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // If CheckTheAnswer() returns false, keep counting
                // down. Decrease the time left by one second and 
                // display the new time left by updating the 
                // Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\windows\media\Ring02.wav");
                player.Play();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }
        //The first line declares the method. It includes a parameter that's named sender.
        //In C#, the parameter is object sender. This parameter refers to the object whose
        //event is firing, which is known as the sender. In this case, the sender object is the
        //NumericUpDown control.
        private void answer_Enter(object sender, EventArgs e)
        {
            //The first line inside the method casts, or converts, the sender from a generic object to a
            //NumericUpDown control. That line also assigns the name answerBox to the NumericUpDown control.
            //All the NumericUpDown controls on the form will use this method, not just the addition
            //problem's control.

            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            //The next line verifies whether answerBox was successfully cast as a NumericUpDown control.
            //The first line inside the if statement determines the length of the answer that's currently in the NumericUpDown control.
            //The second line inside the if statement uses the answer length to select the current value in the control.

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
