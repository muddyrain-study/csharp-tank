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
        public int HP { get; set; }
        public bool IsMoving { get; set; }
        private int originX;
        private int originY;

        public MyTank(int x, int y, int speed)
        {
            this.IsMoving = false;
            this.X = x;
            this.Y = y;
            this.originX = x;
            this.originY = y;
            this.Speed = speed;
            BitmapDown = Properties.Resources.MyTankDown;
            BitmapUp = Properties.Resources.MyTankUp;
            BitmapLeft = Properties.Resources.MyTankLeft;
            BitmapRight = Properties.Resources.MyTankRight;
            this.Dir = Direction.Up;
            this.HP = 4;
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
                case Keys.Space:
                    Attack();
                    break;
                default:
                    break;

            }
        }
        private void Attack()
        {
            SoundManager.PlayFire();
            // 发射子弹
            int x = this.X;
            int y = this.Y;

            switch (Dir)
            {
                case Direction.Up:
                    x += this.Width / 2;
                    break;
                case Direction.Down:
                    x += this.Width / 2;
                    y += this.Height;
                    break;
                case Direction.Left:
                    y += this.Height / 2;
                    break;
                case Direction.Right:
                    x += this.Width;
                    y += this.Height / 2;
                    break;
            }
            GameObjectManger.CreateBullet(x, y, Dir, Tag.MyTank);
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
        public void TankDamage()
        {
            this.HP--;
            if (HP <= 0)
            {
                this.X = this.originX;
                this.Y = this.originY;
            }
        }
    }
}
