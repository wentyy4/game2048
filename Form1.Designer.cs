using System.Windows.Forms;
using System.Drawing;
using System;

namespace Game_2048
{
    partial class Form1
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem settingsMenuItem;
        private ToolStripMenuItem newGameMenuItem;
        private ToolStripMenuItem aboutMenuItem;
        private ToolStripMenuItem howToPlayMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private Label scoreLabel;
        private Panel gameOverPanel;
        private Label gameOverLabel;
        private Button restartButton;
        private Button exitButton;

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToPlayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.gameOverPanel = new System.Windows.Forms.Panel();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.gameOverPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(400, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameMenuItem,
            this.aboutMenuItem,
            this.howToPlayMenuItem,
            this.exitMenuItem});
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(101, 20);
            this.settingsMenuItem.Text = "Налаштування";
            // 
            // newGameMenuItem
            // 
            this.newGameMenuItem.Name = "newGameMenuItem";
            this.newGameMenuItem.Size = new System.Drawing.Size(138, 22);
            this.newGameMenuItem.Text = "Нова гра";
            this.newGameMenuItem.Click += new System.EventHandler(this.NewGameMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(138, 22);
            this.aboutMenuItem.Text = "Інформація";
            this.aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // howToPlayMenuItem
            // 
            this.howToPlayMenuItem.Name = "howToPlayMenuItem";
            this.howToPlayMenuItem.Size = new System.Drawing.Size(138, 22);
            this.howToPlayMenuItem.Text = "Як грати";
            this.howToPlayMenuItem.Click += new System.EventHandler(this.HowToPlayMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(138, 22);
            this.exitMenuItem.Text = "Вихід";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.scoreLabel.Location = new System.Drawing.Point(10, 30);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(112, 22);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "Рахунок: 0";
            // 
            // gameOverPanel
            // 
            this.gameOverPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gameOverPanel.Controls.Add(this.gameOverLabel);
            this.gameOverPanel.Controls.Add(this.restartButton);
            this.gameOverPanel.Controls.Add(this.exitButton);
            this.gameOverPanel.Location = new System.Drawing.Point(0, 24);
            this.gameOverPanel.Name = "gameOverPanel";
            this.gameOverPanel.Size = new System.Drawing.Size(400, 450);
            this.gameOverPanel.TabIndex = 2;
            this.gameOverPanel.Visible = false;
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.gameOverLabel.Location = new System.Drawing.Point(72, 101);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(254, 37);
            this.gameOverLabel.TabIndex = 2;
            this.gameOverLabel.Text = "Гру завершено";
            this.gameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.LightGreen;
            this.restartButton.Location = new System.Drawing.Point(100, 200);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(200, 50);
            this.restartButton.TabIndex = 3;
            this.restartButton.Text = "Почати спочатку";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.NewGameMenuItem_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.LightCoral;
            this.exitButton.Location = new System.Drawing.Point(100, 300);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(200, 50);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Вийти";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.gameOverPanel);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "2048";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.gameOverPanel.ResumeLayout(false);
            this.gameOverPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
