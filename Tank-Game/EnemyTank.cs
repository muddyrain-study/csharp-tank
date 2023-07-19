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
        private Random r = new Random();
        public EnemyTank(
            int x, int y, int speed,
            Bitmap BmpDown, Bitmap BmpUp, Bitmap BmpLeft, Bitmap BmpRight)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            BitmapDown = BmpDown;
            BitmapUp = BmpUp;
            BitmapLeft = BmpLeft;
            BitmapRight = BmpRight;
            this.Dir = Direction.Down;
        }
        public override void Update()
        {
            // 移动检查
            MoveCheck();
            Move();
            base.Update();

        }
        private void ChangeDirection()
        {
            Direction dir = (Direction)r.Next(0, 4);
            if (dir != this.Dir)
            {
                this.Dir = dir;
            }
            MoveCheck();
        }
        public void Move()
        {

            switch (this.Dir)
            {
                case Direction.Up:
                    Y -= Speed;
                    break;
                case Direction.Down:
                    Y += Speed;
                    break;
                case Direction.Left:
                    X -= Speed;
                    break;
                case Direction.Right:
                    X += Speed;
                    break;
                default:
                    break;
            }
        }
        private void MoveCheck()
        {
            // 检查有没有超出窗体边界
            if (Dir == Direction.Up)
            {
                if (Y - Speed < 0)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y + Speed + Height > 450)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X - Speed < 0)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X + Speed + Width > 450)
                {
                    ChangeDirection();
                    return;
                }
            }

            // 检查有没有和其他元素发生碰撞
            Rectangle rect = GetRectangle();
            switch (Dir)
            {
                case Direction.Up:
                    rect.Y -= Speed;
                    break;
                case Direction.Down:
                    rect.Y += Speed;
                    break;
                case Direction.Left:
                    rect.X -= Speed;
                    break;
                case Direction.Right:
                    rect.X += Speed;
                    break;
                default:
                    break;
            }
            if (GameObjectManger.IsColliedWall(rect) != null)
            {
                ChangeDirection();
                return;
            }
            if (GameObjectManger.IsColliedSteel(rect) != null)
            {
                ChangeDirection();
                return;
            }
            if (GameObjectManger.IsColliedBoos(rect))
            {
                ChangeDirection();
                return;
            }
        }
    }
}
