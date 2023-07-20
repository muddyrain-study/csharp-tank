using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank_Game
{

    internal class GameObjectManger
    {
        private static List<NotMovething> wallList = new List<NotMovething>();
        private static List<NotMovething> steelList = new List<NotMovething>();
        private static List<EnemyTank> tankList = new List<EnemyTank>();
        private static List<Bullet> bulletList = new List<Bullet>();
        private static List<Explosion> expList = new List<Explosion>();
        private static NotMovething boos;
        private static MyTank myTank;
        private static int enemyTankSpeed = 60;
        private static int enemyTankCount = 0;
        private static Point[] points = new Point[3];
        public static void Start()
        {
            points[0] = new Point(0, 0);
            points[1] = new Point(7 * 30, 0);
            points[2] = new Point(14 * 30, 0);  
        }
        public static void Update()
        {
            foreach (NotMovething wall in wallList)
            {
                wall.Update();
            }
            foreach (NotMovething steel in steelList)
            {
                steel.Update();
            }
            foreach (EnemyTank tank in tankList)
            {
                tank.Update();
            }
            foreach (Explosion exp in expList)
            {
                exp.Update();
            }
            CheckAndDestoryBullet();
            CheckAndDestoryExplosion();
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Update();
            }
            boos.Update();
            myTank.Update();

            EnemyBorn();
        }
        public static void CheckAndDestoryExplosion()
        {
            List<Explosion> needToDestory = new List<Explosion>();
            foreach (Explosion bullet in expList)
            {
                if (bullet.IsDestory)
                {
                    needToDestory.Add(bullet);
                }
            }
            foreach (Explosion exp in needToDestory)
            {
                expList.Remove(exp);
            }
        }
        public static void CheckAndDestoryBullet()
        {
            List<Bullet> needToDestory = new List<Bullet>();
            foreach (Bullet bullet in bulletList)
            {
                if (bullet.IsDestory)
                {
                    needToDestory.Add(bullet);
                }
            }
            foreach (Bullet bullet in needToDestory)
            {
                bulletList.Remove(bullet);
            }
        }
        public static void CreateExplosion(int x, int y)
        {
            Explosion exp = new Explosion(x, y);
            expList.Add(exp);
        }
        public static void CreateBullet(int x, int y, Direction dir, Tag tag)
        {
            Bullet bullet = new Bullet(x, y, 5, dir, tag);
            bulletList.Add(bullet);
        }

        public static void DestoryWall(NotMovething wall)
        {
            wallList.Remove(wall);
        }
        public static void DestoryTank(EnemyTank tank)
        {
            tankList.Remove(tank);
        }
        public static void EnemyBorn()
        {
            //if (tankList.Count >= 100)
            //{
            //    return;
            //} 
            enemyTankCount++;
            if (enemyTankCount < enemyTankSpeed)
            {
                return;
            }
            SoundManager.PlayAdd();
            // 产生敌人
            Random r = new Random();
            // 0-2 
            int index = r.Next(0, 3);
            Point position = points[index];
            int enemyType = r.Next(1, 5);
            switch (enemyType)
            {
                case 1:
                    CreateEnmey1(position.X, position.Y);
                    break;
                case 2:
                    CreateEnmey2(position.X, position.Y);
                    break;
                case 3:
                    CreateEnmey3(position.X, position.Y);
                    break;
                case 4:
                    CreateEnmey4(position.X, position.Y);
                    break;
                default:
                    break;
            }
            enemyTankCount = 0;
        }
        private static void CreateEnmey1(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 2,
                Properties.Resources.GrayDown,
                Properties.Resources.GrayUp,
                Properties.Resources.GrayLeft,
                Properties.Resources.GrayRight);
            tankList.Add(tank);
        }
        private static void CreateEnmey2(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 2,
                Properties.Resources.GreenDown,
                Properties.Resources.GreenUp,
                Properties.Resources.GreenLeft,
                Properties.Resources.GreenRight);
            tankList.Add(tank);
        }
        private static void CreateEnmey3(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 4,
                Properties.Resources.QuickDown,
                Properties.Resources.QuickUp,
                Properties.Resources.QuickLeft,
                Properties.Resources.QuickRight);
            tankList.Add(tank);
        }
        private static void CreateEnmey4(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 1,
                Properties.Resources.SlowDown,
                Properties.Resources.SlowUp,
                Properties.Resources.SlowLeft,
                Properties.Resources.SlowRight);
            tankList.Add(tank);
        }

        // 是否碰撞 砖墙
        public static NotMovething IsColliedWall(Rectangle rt)
        {
            foreach (NotMovething wall in wallList)
            {
                if (wall.GetRectangle().IntersectsWith(rt))
                {
                    return wall;
                }
            }
            return null;
        }
        // 是否碰撞 钢墙
        public static NotMovething IsColliedSteel(Rectangle rt)
        {
            foreach (NotMovething steel in steelList)
            {
                if (steel.GetRectangle().IntersectsWith(rt))
                {
                    return steel;
                }
            }
            return null;
        }
        // 是否碰撞 Boos
        public static bool IsColliedBoos(Rectangle rt)
        {
            return boos.GetRectangle().IntersectsWith(rt);
        }
        // 是否碰撞 我的坦克
        public static MyTank IsColliedMyTank(Rectangle rt)
        {
            if (myTank.GetRectangle().IntersectsWith(rt))
            {
                return myTank;
            }
            return null;
        }
        // 是否碰撞 敌人坦克
        public static EnemyTank IsColliedEnmeyTank(Rectangle rt)
        {
            foreach (EnemyTank tank in tankList)
            {
                if (tank.GetRectangle().IntersectsWith(rt))
                {
                    return tank;
                }
            }
            return null;
        }

        public static void CreateMyTank()
        {
            int x = 5 * 30;
            int y = 14 * 30;

            myTank = new MyTank(x, y, 2);
        }
        public static void CreatMap()
        {
            CreateWall(1, 1, 5, Properties.Resources.wall, wallList);
            CreateWall(3, 1, 5, Properties.Resources.wall, wallList);
            CreateWall(5, 1, 4, Properties.Resources.wall, wallList);
            CreateWall(7, 1, 3, Properties.Resources.wall, wallList);
            CreateWall(9, 1, 4, Properties.Resources.wall, wallList);
            CreateWall(11, 1, 5, Properties.Resources.wall, wallList);
            CreateWall(13, 1, 5, Properties.Resources.wall, wallList);

            CreateWall(7, 5, 1, Properties.Resources.steel, steelList);
            CreateWall(0, 7, 1, Properties.Resources.steel, steelList);
            CreateWall(14, 7, 1, Properties.Resources.steel, steelList);


            //CreateWall(2, 7, 1, Properties.Resources.wall, wallList);
            //CreateWall(3, 7, 1, Properties.Resources.wall, wallList);
            //CreateWall(4, 7, 1, Properties.Resources.wall, wallList);

            CreateWall(6, 7, 1, Properties.Resources.wall, wallList);
            CreateWall(7, 6, 2, Properties.Resources.wall, wallList);
            CreateWall(8, 7, 1, Properties.Resources.wall, wallList);

            //CreateWall(10, 7, 1, Properties.Resources.wall, wallList);
            //CreateWall(11, 7, 1, Properties.Resources.wall, wallList);
            //CreateWall(12, 7, 1, Properties.Resources.wall, wallList);



            CreateWall(1, 9, 5, Properties.Resources.wall, wallList);
            CreateWall(3, 9, 5, Properties.Resources.wall, wallList);
            CreateWall(5, 9, 3, Properties.Resources.wall, wallList);
            CreateWall(9, 9, 3, Properties.Resources.wall, wallList);
            CreateWall(6, 10, 1, Properties.Resources.wall, wallList);
            CreateWall(7, 10, 2, Properties.Resources.wall, wallList);
            CreateWall(8, 10, 1, Properties.Resources.wall, wallList);

            CreateWall(11, 9, 5, Properties.Resources.wall, wallList);
            CreateWall(13, 9, 5, Properties.Resources.wall, wallList);

            // 双层堡垒
            //CreateWall(6, 13, 2, Properties.Resources.wall, wallList);
            //CreateWall(7, 13, 1, Properties.Resources.wall, wallList);
            //CreateWall(8, 13, 2, Properties.Resources.wall, wallList);

            // 单层堡垒
            CreateSingleWall(13, 27, 3, Properties.Resources.wall, wallList);
            CreateSingleWall(14, 27, 1, Properties.Resources.wall, wallList);
            CreateSingleWall(15, 27, 1, Properties.Resources.wall, wallList);
            CreateSingleWall(16, 27, 3, Properties.Resources.wall, wallList);
            createBoos(7, 14, Properties.Resources.Boss);
        }

        private static void createBoos(int x, int y, Image img)
        {
            int xPosition = x * 30;
            int yPosition = y * 30;
            boos = new NotMovething(xPosition, yPosition, img);
        }
        private static void CreateWall(int x, int y, int count, Image img, List<NotMovething> wallList)
        {
            int size = 30;
            int xPosition = x * size;
            int yPosition = y * size;
            for (int i = yPosition; i < yPosition + count * size; i += (size / 2))
            {
                // i xPosition   i xPosition + 15
                NotMovething wall1 = new NotMovething(xPosition, i, img);
                wallList.Add(wall1);
                NotMovething wall2 = new NotMovething(xPosition + (size / 2), i, img);
                wallList.Add(wall2);
            }
        }
        private static void CreateSingleWall(int x, int y, int count, Image img, List<NotMovething> wallList)
        {
            int size = 15;
            int xPosition = x * size;
            int yPosition = y * size;
            for (int i = yPosition; i < yPosition + count * size; i += (size))
            {
                // i xPosition   i xPosition + 15
                NotMovething wall1 = new NotMovething(xPosition, i, img);
                wallList.Add(wall1);
            }
        }

        public static void KeyDown(KeyEventArgs e)
        {
            myTank.KeyDown(e);
        }
        public static void KeyUp(KeyEventArgs e)
        {
            myTank.KeyUp(e);
        }
    }
}
