using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank_Game
{
    internal class MyTank : Movething
    {
        public MyTank(int x, int y, int speed)
        {
            this.IsMoving = false;
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.Dir = Direction.Up;
            BitmapDown = Properties.Resources.MyTankDown;
            BitmapUp = Properties.Resources.MyTankUp;
            BitmapLeft = Properties.Resources.MyTankLeft;
            BitmapRight = Properties.Resources.MyTankRight;
        }

        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    Dir = Direction.Up;
                    IsMoving = true;
                    break;
                case Keys.S:
                    Dir = Direction.Down;
                    IsMoving = true;
                    break;
                case Keys.A:
                    Dir = Direction.Left;
                    IsMoving = true;
                    break;
                case Keys.D:
                    Dir = Direction.Right;
                    IsMoving = true;
                    break;
                default:
                    break;

            }
        }
        public void KeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    IsMoving = false;
                    break;
                case Keys.S:
                    IsMoving = false;
                    break;
                case Keys.A:
                    IsMoving = false;
                    break;
                case Keys.D:
                    IsMoving = false;
                    break;
                default:
                    break;

            }
        }

        public override void Update()
        {
            // 移动检查
            MoveCheck();
            Move();
            base.Update();

        }
        public void Move()
        {
            if (this.IsMoving == false) return;

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
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y + Speed + Height > 450)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X - Speed < 0)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X + Speed + Width > 450)
                {
                    IsMoving = false;
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
                IsMoving = false;
                return;
            }
            if (GameObjectManger.IsColliedSteel(rect) != null)
            {
                IsMoving = false;
                return;
            }
            if (GameObjectManger.IsColliedBoos(rect))
            {
                IsMoving = false;
                return;
            }
        }
    }
}
