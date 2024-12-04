using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language_App_Medhavi.Components
{

    /// <summary>
    /// Represents a simple implementation of the classic Snake game in C# using Windows Forms.
    /// </summary>
    public class SnakeGame
    {
        /// <summary>
        /// The size of each tile in the game.
        /// </summary>
        private const int TileSize = 20;

        /// <summary>
        /// The interval for the game timer in milliseconds.
        /// </summary>
        private const int TimerInterval = 100;

        /// <summary>
        /// Enumerates the possible directions for the snake movement.
        /// </summary>
        private enum Direction { Up, Down, Left, Right, Pause }

        private List<Point> snake;
        private Direction direction;
        private Point food;
        private int score;
        private Timer gameTimer;
        private Panel gamePanel;
        private Label gameLabel;

        /// <summary>
        /// Initializes a new instance of the <see cref="SnakeGame"/> class.
        /// </summary>
        /// <param name="panel">The Panel control for rendering the game.</param>
        /// <param name="label">The Label control for displaying the score.</param>

        public SnakeGame(Panel panel, Label label)
        {
            gamePanel = panel;
            gameLabel = label;
            InitializeGame();
        }


        /// <summary>
        /// Initializes the game state.
        /// </summary>

        private void InitializeGame()
        {
            snake = new List<Point>();
            snake.Add(new Point(10, 10)); 
            direction = Direction.Pause; 
            GenerateFood();
            gameTimer = new Timer { Interval = TimerInterval };
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
            gamePanel.KeyDown += MainForm_KeyDown;
            gamePanel.Paint += GamePanel_Paint;
            gamePanel.TabStop = true; 
            gamePanel.Focus();
            score = 0;
            UpdateScoreLabel();
        }

        /// <summary>
        /// Generates food at a random location on the game panel.
        /// </summary>

        private void GenerateFood()
        {
            Random random = new Random();
            int maxX = gamePanel.Width / TileSize;
            int maxY = gamePanel.Height / TileSize;
            food = new Point(random.Next(maxX), random.Next(maxY));
        }

        /// <summary>
        /// Handles the game timer tick event, updating the game state.
        /// </summary>
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            MoveSnake();
            CheckCollision();
            gamePanel.Invalidate();
        }

        /// <summary>
        /// Moves the snake based on the current direction.
        /// </summary>
        private void MoveSnake()
        {
            Point newHead = snake.First();
            switch (direction)
            {
                case Direction.Up:
                    newHead = new Point(newHead.X, newHead.Y - 1);
                    break;
                case Direction.Down:
                    newHead = new Point(newHead.X, newHead.Y + 1);
                    break;
                case Direction.Left:
                    newHead = new Point(newHead.X - 1, newHead.Y);
                    break;
                case Direction.Right:
                    newHead = new Point(newHead.X + 1, newHead.Y);
                    break;
               
            }

            snake.Insert(0, newHead);
            if (snake.First() == food)
            {
                GenerateFood();
                score++;
                UpdateScoreLabel();
            }
            else
            {
                snake.RemoveAt(snake.Count -1);
            }
        }

        /// <summary>
        /// Checks for collisions with walls, itself, or food.
        /// </summary>
        private void CheckCollision()
        {
            Point head = snake.First();
            if (head.X < 0 || head.Y < 0 || head.X >= gamePanel.Width / TileSize || head.Y >= gamePanel.Height / TileSize || snake.Count != snake.Distinct().Count())
            {
                gameTimer.Stop();
                DialogResult result = MessageBox.Show("Game Over! Would you like to play again?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    InitializeGame(); // Restart the game
                }               
            }
        }



        /// <summary>
        /// Handles the keydown event for the game panel, allowing the player to control the snake.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The KeyEventArgs containing information about the key press.</param>

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (direction != Direction.Down)
                        direction = Direction.Up;
                    break;
                case Keys.S:
                    if (direction != Direction.Up)
                        direction = Direction.Down;
                    break;
                case Keys.A:
                    if (direction != Direction.Right)
                        direction = Direction.Left;
                    break;
                case Keys.D:
                    if (direction != Direction.Left)
                        direction = Direction.Right;
                    break;
                case Keys.Space:
                    if (direction != Direction.Pause)
                        direction = Direction.Pause;
                    break;
            }
        }

        /// <summary>
        /// Paints the game elements on the specified graphics object.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The PaintEventArgs containing information about the paint event.</param>

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;           
            DrawSnake(g);
            DrawFood(g);            
        }

        /// <summary>
        /// Draw the rectangle as a snake
        /// </summary>
        private void DrawSnake(Graphics g)
        {
            foreach (Point segment in snake)
            {
                g.FillRectangle(Brushes.Green, new Rectangle(segment.X * TileSize, segment.Y * TileSize, TileSize, TileSize));
            }
        }

        /// <summary>
        /// Draw a food as a random
        /// </summary>
        private void DrawFood(Graphics g)
        {
            g.FillRectangle(Brushes.Red, new Rectangle(food.X * TileSize, food.Y * TileSize, TileSize, TileSize));
        }

        /// <summary>
        /// Updates the label displaying the current score.
        /// </summary>
        private void UpdateScoreLabel()
        {
            gameLabel.Text = $"Score: {score}";
        }
    }

}
