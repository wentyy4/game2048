using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Game_2048
{
    public partial class Form1 : Form
    {
        private GameManager gameManager;

        public Form1(GameManager gameManager)
        {
            InitializeComponent();
            InitializeGameTiles();
            this.gameManager = gameManager;
            gameManager.Start();
            UpdateUI();
        }

        private void InitializeGameTiles()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Button btn = new Button();
                    btn.Name = $"button{row}{col}";
                    btn.Size = new Size(100, 100);
                    btn.Location = new Point(100 * col, 60 + 100 * row);
                    btn.Font = new Font("Arial", 24);
                    this.Controls.Add(btn);
                }
            }
        }

        private void UpdateUI()
        {
            Tile[,] board = gameManager.GetBoard();
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Button btn = Controls.Find($"button{row}{col}", true).FirstOrDefault() as Button;
                    if (btn != null)
                    {
                        btn.Text = board[row, col]?.Value.ToString() ?? string.Empty;
                        btn.BackColor = GetTileColor(board[row, col]?.Value ?? 0);
                    }
                }
            }
            scoreLabel.Text = $"Рахунок: {gameManager.Score}";

            if (gameManager.IsGameOver())
            {
                ShowGameOver();
            }
        }

        private Color GetTileColor(int value)
        {
            switch (value)
            {
                case 2: return Color.LightYellow;
                case 4: return Color.LightGoldenrodYellow;
                case 8: return Color.Orange;
                case 16: return Color.Coral; 
                case 32: return Color.OrangeRed; 
                case 64: return Color.Red;
                case 128: return Color.LightGreen;
                case 256: return Color.Green;
                case 512: return Color.DarkGreen;
                case 1024: return Color.LightBlue;
                case 2048: return Color.Blue;
                default: return Color.Gray;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    gameManager.Move(Direction.Up);
                    break;
                case Keys.Down:
                    gameManager.Move(Direction.Down);
                    break;
                case Keys.Left:
                    gameManager.Move(Direction.Left);
                    break;
                case Keys.Right:
                    gameManager.Move(Direction.Right);
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            UpdateUI();
            return true;
        }

        private void NewGameMenuItem_Click(object sender, EventArgs e)
        {
            gameManager = new GameManager(4);
            gameManager.Start();
            gameOverPanel.Visible = false;
            UpdateUI();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Проєкт Артема Коломійця на семестр 2024 року.", "Інформація");
        }

        private void HowToPlayMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Використовуйте клавіші стрілок, щоб переміщати плитки. Коли дві плитки з однаковими числами стикаються, вони об'єднуються в одну. Досягніть плитки з числом 2048, щоб виграти.", "Як грати");
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowGameOver()
        {
            gameOverPanel.Visible = true;
            gameOverPanel.BringToFront(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
