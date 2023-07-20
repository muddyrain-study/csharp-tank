using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank_Game
{
    enum GameState
    {
        Running,
        GameOver
    }
    internal class GameFramework
    {
        private static GameState gameState = GameState.Running;
        public static Graphics g;
        public static void Start()
        {
            GameObjectManger.Start();
            GameObjectManger.CreatMap();
            GameObjectManger.CreateMyTank();
        }

        public static void Update()
        {
            if (gameState == GameState.Running)
            {
                // FPS
                GameObjectManger.Update();
            }
            else if (gameState == GameState.GameOver)
            {
                GameOverUpdate();
            }
        }
        public static void GameOverUpdate()
        {
            Image image = Properties.Resources.GameOver;
            int x = 450 / 2 - image.Width / 2;
            int y = 450 / 2 - image.Height / 2;
            g.DrawImage(image, x, y);
        }
        public static void ChangeToGameOver()
        {
            gameState = GameState.GameOver;
        }


    }
}
