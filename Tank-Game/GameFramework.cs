using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank_Game
{
    internal class GameFramework
    {
        public static Graphics g;
        public static void Start()
        {
            GameObjectManger.Start();
            GameObjectManger.CreatMap();
            GameObjectManger.CreateMyTank();
        }

        public static void Update()
        {
            // FPS
            GameObjectManger.Update();
        }

    }
}
