using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 开始位置居中
            this.StartPosition = FormStartPosition.CenterScreen;



        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            #region 画线
            //g.DrawLine(new Pen(Color.Red, 2), new Point(0, 0), new Point(100, 100));
            #endregion

            //g.DrawString(
            //    "Muddyrain",
            //    new Font("微软雅黑", 20),
            //    new SolidBrush(Color.Red),
            //    new Point(100, 100)
            //    );
            Image image = Properties.Resources.Boss;

            Bitmap bm = Properties.Resources.Star1;
            bm.MakeTransparent(Color.Black);
            g.DrawImage(image, 0, 0, 100, 100);
            g.DrawImage(bm, 100, 100, 100, 100);
        }
    }
}
