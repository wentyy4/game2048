using System;
using System.Windows.Forms;

namespace Game_2048
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameManager gameManager = new GameManager(4);
            Application.Run(new Form1(gameManager));
        }
    }
}
