using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Game
{
    internal class MyTank : Movething
    {
        public MyTank(int x, int y, int speed)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.Dir = Direction.Up;
            BitmapDown = Properties.Resources.MyTankDown;
            BitmapUp = Properties.Resources.MyTankUp;
            BitmapLeft = Properties.Resources.MyTankLeft;
            BitmapRight = Properties.Resources.MyTankRight;
        }
    }
}
