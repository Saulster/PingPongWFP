using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Media;


namespace PingPongWFP
{
    public partial class PingPong : UserControl
    {
        // Ping Pong Ball Parameters.
        private const int BallWidth = 20;
        private const int BallHeight = 20;
        private const int PaddleWidth = 20;
        private const int PaddleHeight = 100;

        private readonly Random RandomNumber = new Random(255);

        private Brush BallColor = Brushes.DodgerBlue;
        private int BallVx, BallVy; // Velocity.
        private int BallX, BallY;   // Position.

        private int Paddle1Y, Paddle2Y; // Positions of the two paddles

        private int leftSideLossCount = 0;
        private int rightSideLossCount = 0;
        private bool gameEnded = false;
        private void tmr_Tick(object sender, EventArgs e)
        {
            this.Tick();
        }

        public PingPong()
        {
            InitializeComponent();
            this.InitializeComponent();
            this.Init();
            this.Paint += PingPongBall_Paint;
            PingPongBallSpeed(01);
            tmr.Interval = 20; // Adjust the interval as needed for smooth animation.
            tmr.Start();
            this.KeyDown += PingPong_KeyDown;
        }
        private void Init()
        {
            this.tmr.Enabled = false;
            this.Visible = false;
            // Pick a random start position and velocity.
            var rnd = new Random();
            this.BallVx = (5);
            this.BallVy = (5);
            this.BallX = rnd.Next(0, this.ClientSize.Width / 2);
            this.BallY = rnd.Next(0, this.ClientSize.Height /2);

            // Use double buffering to reduce flicker.
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            this.UpdateStyles();
        }
        private void PingPongBall_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(this.BackColor);
            e.Graphics.FillEllipse(this.BallColor, this.BallX, this.BallY, BallWidth, BallHeight);
            e.Graphics.DrawEllipse(Pens.Black, this.BallX, this.BallY, BallWidth, BallHeight);
            // Draw the ball
            e.Graphics.FillEllipse(BallColor, BallX, BallY, BallWidth, BallHeight);
            e.Graphics.DrawEllipse(Pens.Black, BallX, BallY, BallWidth, BallHeight);

            // Draw paddle 1 (left)
            e.Graphics.FillRectangle(Brushes.White, 0, Paddle1Y, PaddleWidth, PaddleHeight);

            // Draw paddle 2 (right)
            e.Graphics.FillRectangle(Brushes.White, this.ClientSize.Width - PaddleWidth, Paddle2Y, PaddleWidth, PaddleHeight);
            string scoreText = $"{leftSideLossCount} | {rightSideLossCount}";
            Font scoreFont = new Font("Arial", 14);
            SizeF textSize = e.Graphics.MeasureString(scoreText, scoreFont);
            PointF location = new PointF((this.ClientSize.Width - textSize.Width) / 2, 20);
            e.Graphics.DrawString(scoreText, scoreFont, Brushes.White, location);
        }
        public void StartStop(bool startStop)
        {
            this.tmr.Enabled = startStop;
            this.Visible = startStop;
        }
        public void PingPongBallSpeed(int speedValueIn)
        {
            this.tmr.Interval = speedValueIn;
        }
        private void Boing()
        {
            var color = Color.FromArgb((byte)this.RandomNumber.Next(), (byte)this.RandomNumber.Next(), (byte)this.RandomNumber.Next());
            this.BallColor = new SolidBrush(color);
        }
       


        private void Tick()
        {
            if (gameEnded) // If the game has ended, don't execute further ticks
                return;

            this.BallX += this.BallVx;
            this.BallY += this.BallVy;

            // Check collision with top or bottom wall
            if (this.BallY < 0 || this.BallY + BallHeight > this.ClientSize.Height)
            {
                this.BallVy = -this.BallVy;
                Boing();
            }

            // Check for collision with the left paddle
            if (this.BallX < PaddleWidth && this.BallY + BallHeight > Paddle1Y && this.BallY < Paddle1Y + PaddleHeight)
            {
                this.BallVx = -this.BallVx;
                Boing();
            }
            // Check for collision with the right paddle
            else if (this.BallX + BallWidth > this.ClientSize.Width - PaddleWidth && this.BallY + BallHeight > Paddle2Y && this.BallY < Paddle2Y + PaddleHeight)
            {
                this.BallVx = -this.BallVx;
                Boing();
            }
            // Ball goes out on the left side
            else if (this.BallX < 0)
            {
                rightSideLossCount++; // Increment for the right side because it's the left side where the ball was lost
                ResetBall();
                // Check for winner
                if (rightSideLossCount >= 5)
                {
                    gameEnded = true; // Set the game ended flag
                    MessageBox.Show("Player on the right side wins!");
                    ResetGame();
                }
                else if (leftSideLossCount >= 5)  // Check if the other side has already won
                {
                    gameEnded = true; // Set the game ended flag
                    ResetGame();
                }
            }
            // Ball goes out on the right side
            else if (this.BallX + BallWidth > this.ClientSize.Width)
            {
                leftSideLossCount++; // Increment for the left side because it's the right side where the ball was lost
                ResetBall();
                // Check for winner
                if (leftSideLossCount >= 5)
                {
                    gameEnded = true; // Set the game ended flag
                    MessageBox.Show("Player on the left side wins!");
                    ResetGame();
                }
                else if (rightSideLossCount >= 5) // Check if the other side has already won
                {
                    gameEnded = true; // Set the game ended flag
                    ResetGame();
                }
            }

            this.Refresh();
        }
        private void ResetGame()
            {
                // Reset scores and ball position
                leftSideLossCount = 0;
                rightSideLossCount = 0;
                ResetBall();
                gameEnded = false;
        }
            private void ResetBall()
        {
            // Reset the ball to the center of the play area, or use a random start position
            this.BallX = (this.ClientSize.Width - BallWidth) / 2;
            this.BallY = (this.ClientSize.Height - BallHeight) / 2;

            // Reset the ball's velocity to a random direction
            var rnd = new Random();
            this.BallVx = (5) * (rnd.Next(2) == 0 ? 1 : -1); // Random horizontal direction
            this.BallVy = (5) * (rnd.Next(2) == 0 ? 1 : -1); // Random vertical direction
        }
        private void PingPong_KeyDown(object sender, KeyEventArgs e)
        {
            // Move paddle 1 (left paddle) with W and S keys
            if (e.KeyCode == Keys.W)
            {
                Paddle1Y -= 10; // Move paddle up
            }
            else if (e.KeyCode == Keys.S)
            {
                Paddle1Y += 10; // Move paddle down
            }

            // Move paddle 2 (right paddle) with Up and Down arrow keys
            if (e.KeyCode == Keys.I)
            {
                Paddle2Y -= 10; // Move paddle up
            }
            else if (e.KeyCode == Keys.K)
            {
                Paddle2Y += 10; // Move paddle down
            }

            // Ensure paddle positions stay within bounds
            Paddle1Y = Math.Max(0, Math.Min(ClientSize.Height - PaddleHeight, Paddle1Y));
            Paddle2Y = Math.Max(0, Math.Min(ClientSize.Height - PaddleHeight, Paddle2Y));

            // Redraw the control to reflect paddle movements
            Refresh();
        }
    }
}
