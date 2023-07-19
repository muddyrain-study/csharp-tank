using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Game
{
    internal class EnemyTank : Movething
    {
        public EnemyTank(
            int x, int y, int speed,
            Bitmap BmpDown, Bitmap BmpUp, Bitmap BmpLeft, Bitmap BmpRight)
        {
            this.IsMoving = false;
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.Dir = Direction.Down;
            BitmapDown = BmpDown;
            BitmapUp = BmpUp;
            BitmapLeft = BmpLeft;
            BitmapRight = BmpRight;
        }
    }
}
