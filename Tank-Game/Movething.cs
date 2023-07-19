using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Game
{
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    /*
     * 可移动的物体   
     */
    internal class Movething : GameObject
    {
        public Bitmap BitmapUp { get; set; }
        public Bitmap BitmapDown { get; set; }
        public Bitmap BitmapLeft { get; set; }
        public Bitmap BitmapRight { get; set; }

        public bool IsMoving { get; set; }


        public int Speed { get; set; }

        public Direction dir;
        public Direction Dir
        {
            get
            {
                return dir;
            }
            set
            {
                dir = value;
                Bitmap bitmap = null;
                switch (value)
                {
                    case Direction.Up:
                        bitmap = BitmapUp;
                        break;
                    case Direction.Down:
                        bitmap = BitmapDown;
                        break;
                    case Direction.Left:
                        bitmap = BitmapLeft;
                        break;
                    case Direction.Right:
                        bitmap = BitmapRight;
                        break;
                }
                if (bitmap != null)
                {
                    try
                    {
                        Width = bitmap.Width;
                        Height = bitmap.Height;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        protected override Image GetImage()
        {
            Bitmap bitmap;
            switch (Dir)
            {
                case Direction.Up:
                    bitmap = BitmapUp;
                    break;
                case Direction.Down:
                    bitmap = BitmapDown;
                    break;
                case Direction.Left:
                    bitmap = BitmapLeft;
                    break;
                case Direction.Right:
                    bitmap = BitmapRight;
                    break;
                default:
                    throw new Exception("方向错误");

            }
            bitmap.MakeTransparent(Color.Black);
            return bitmap;
        }

    }
}
