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
        public int ChangeDirSpeed { get; set; }
        private int changeDirCount = 0; // 用于计算改变方向的间隔
        public int AttackSpeed { get; set; }
        private int attackCount = 0; // 用于计算攻击间隔
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
            this.AttackSpeed = 60;
            this.ChangeDirSpeed = 60;
        }
        public override void Update()
        {
            // 移动检查
            MoveCheck();
            Move();
            AttackCheck();
            AutoChangeDirection();
            base.Update();

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
        private void AutoChangeDirection()
        {
            // 改变方向检查
            changeDirCount++;
            if (changeDirCount >= ChangeDirSpeed)
            {
                ChangeDirection();
                changeDirCount = 0;
            }
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
        private void AttackCheck()
        {
            // 攻击检查
            attackCount++;
            if (attackCount >= AttackSpeed)
            {
                Attack();
                attackCount = 0;
            }
        }
        private void Attack()
        {
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
            GameObjectManger.CreateBullet(x, y, Dir, Tag.EnemyTank);
        }
    }
}
