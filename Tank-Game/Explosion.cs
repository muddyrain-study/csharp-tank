using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Game
{
    internal class Explosion : GameObject
    {
        private int playSpeed = 2;
        private int playCount = -1;
        private int index = 0;
        private Bitmap[] bmpArray = new Bitmap[] {
            Properties.Resources.EXP1,
            Properties.Resources.EXP2,
            Properties.Resources.EXP3,
            Properties.Resources.EXP4,
            Properties.Resources.EXP5,
        };

        public Explosion(int x, int y)
        {
            foreach (Bitmap bmp in bmpArray)
            {
                bmp.MakeTransparent(Color.Black);
            }
            this.X = x - bmpArray[0].Width / 2;
            this.Y = y - bmpArray[0].Height / 2;
        }
        protected override Image GetImage()
        {
            if (index > bmpArray.Length - 1)
            {
                return bmpArray[bmpArray.Length - 1];
            }
            return bmpArray[index];
        }
        public override void Update()
        {
            playCount++;
            index = (playCount - 1) / playSpeed;
            base.Update();
        }

    }
}
