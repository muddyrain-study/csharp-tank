using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Game
{
    /*
     * 不可移动的物体
     */
    internal class NotMovething : GameObject
    {
        public Image Img { get; set; }

        protected override Image GetImage()
        {
            return Img;
        }

        public NotMovething(int x, int y, Image img)
        {
            this.X = x;
            this.Y = y;
            this.Img = img;
        }

    }
}
