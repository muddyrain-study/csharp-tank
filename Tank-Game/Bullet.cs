using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Game
{
    enum Tag
    {
        MyTank,
        EnemyTank,
    }
    internal class Bullet : Movething
    {
        public Tag Tag { get; set; }
        public bool IsDestory { get; set; }
        public Bullet(int x, int y, int speed, Direction dir, Tag tag)
        {
            this.IsDestory = false;
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            BitmapDown = Properties.Resources.BulletDown;
            BitmapUp = Properties.Resources.BulletUp;
            BitmapLeft = Properties.Resources.BulletLeft;
            BitmapRight = Properties.Resources.BulletRight;
            this.Dir = dir;
            this.Tag = tag;

            this.X -= this.Width / 2;
            this.Y -= this.Height / 2;
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
                if (Y + Height / 2 + 3 < 0)
                {
                    IsDestory = true;
                    return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y + Height / 2 - 3 > 450)
                {
                    IsDestory = true;
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X - Speed < 0)
                {
                    //ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X + Speed + Width > 450)
                {
                    //ChangeDirection();    
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
                //ChangeDirection();
                return;
            }
            if (GameObjectManger.IsColliedSteel(rect) != null)
            {
                //ChangeDirection();
                return;
            }
            if (GameObjectManger.IsColliedBoos(rect))
            {
                //ChangeDirection();
                return;
            }
        }
    }

}
