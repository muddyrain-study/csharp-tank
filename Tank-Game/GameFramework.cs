using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Game
{
    internal class GameFramework
    {
        public static Graphics g;
        public static void Start()
        {
            GameObjectManger.CreatMap();
        }

        public static void Update()
        {
            // FPS
            GameObjectManger.DrawMap();
        }
    }
}
