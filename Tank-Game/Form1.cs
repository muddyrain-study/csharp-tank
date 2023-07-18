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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tank_Game
{
    public partial class Form1 : Form
    {
        private Thread thread;
        private static Graphics windowG;
        private static Bitmap tmpBitmap;
        public Form1()
        {
            InitializeComponent();

            // 开始位置居中
            this.StartPosition = FormStartPosition.CenterScreen;

            // 阻塞
            windowG = this.CreateGraphics();

            tmpBitmap = new Bitmap(450, 450);
            Graphics bmpG = Graphics.FromImage(tmpBitmap);
            GameFramework.g = bmpG;
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
                windowG.DrawImage(tmpBitmap, 0, 0);
                Thread.Sleep(sleepTime);
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            GameObjectManger.KeyDown(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            GameObjectManger.KeyUp(e);
        }
    }
}
