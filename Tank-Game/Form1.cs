using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank_Game
{
    public partial class Form1 : Form
    {
        private Thread thread;
        public Form1()
        {
            InitializeComponent();

            // 开始位置居中
            this.StartPosition = FormStartPosition.CenterScreen;

            // 阻塞

            Graphics g = this.CreateGraphics();
            GameFramework.g = g;

            thread = new Thread(new ThreadStart(GameMainThread));
            thread.Start();
        }
        public static void GameMainThread()
        {
            // GameFramework
            GameFramework.Start();
            int sleepTime = 1000 / 60;
            while (true)
            {
                GameFramework.g.Clear(Color.Black);
                GameFramework.Update(); // 60 FPS
                Thread.Sleep(sleepTime);
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            Image image = Properties.Resources.Boss;

            Bitmap bm = Properties.Resources.Star1;
            bm.MakeTransparent(Color.Black);
            g.DrawImage(image, 0, 0, 100, 100);
            g.DrawImage(bm, 100, 100, 100, 100);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
        }
    }
}
