using System;
using System.Collections.Generic;
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
        public Bullet(int x, int y, int speed, Direction dir, Tag tag)
        {
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
    }

}
