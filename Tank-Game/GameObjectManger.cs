using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Game
{

    internal class GameObjectManger
    {
        private static List<NotMovething> wallList = new List<NotMovething>();
        private static List<NotMovething> steelList = new List<NotMovething>();
        private static NotMovething boos;
        public static void DrawMap()
        {
            foreach (NotMovething wall in wallList)
            {
                wall.DrawSelf();
            }
            foreach (NotMovething steel in steelList)
            {
                steel.DrawSelf();
            }

            boos.DrawSelf();
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


            CreateWall(2, 7, 1, Properties.Resources.wall, wallList);
            CreateWall(3, 7, 1, Properties.Resources.wall, wallList);
            CreateWall(4, 7, 1, Properties.Resources.wall, wallList);

            CreateWall(6, 7, 1, Properties.Resources.wall, wallList);
            CreateWall(7, 6, 2, Properties.Resources.wall, wallList);
            CreateWall(8, 7, 1, Properties.Resources.wall, wallList);

            CreateWall(10, 7, 1, Properties.Resources.wall, wallList);
            CreateWall(11, 7, 1, Properties.Resources.wall, wallList);
            CreateWall(12, 7, 1, Properties.Resources.wall, wallList);



            CreateWall(1, 9, 5, Properties.Resources.wall, wallList);
            CreateWall(3, 9, 5, Properties.Resources.wall, wallList);
            CreateWall(5, 9, 3, Properties.Resources.wall, wallList);
            CreateWall(9, 9, 3, Properties.Resources.wall, wallList);
            CreateWall(6, 10, 1, Properties.Resources.wall, wallList);
            CreateWall(7, 10, 2, Properties.Resources.wall, wallList);
            CreateWall(8, 10, 1, Properties.Resources.wall, wallList);

            CreateWall(11, 9, 5, Properties.Resources.wall, wallList);
            CreateWall(13, 9, 5, Properties.Resources.wall, wallList);

            CreateWall(6, 13, 2, Properties.Resources.wall, wallList);
            CreateWall(7, 13, 1, Properties.Resources.wall, wallList);
            CreateWall(8, 13, 2, Properties.Resources.wall, wallList);

            createBoos(7, 14, Properties.Resources.Boss);
        }

        private static void createBoos(int x, int y, Image img)
        {
            int xPosition = x * 30;
            int yPosition = y * 30;
            boos = new NotMovething(xPosition, yPosition, img);
        }
        private static void CreateWall(int x, int y, int count, Image img, List<NotMovething> wallList, int size = 30)
        {
            int xPosition = x * size;
            int yPosition = y * size;
            for (int i = yPosition; i < yPosition + count * size; i += (size / 2))
            {
                // i xPosition   i xPosition + 15
                NotMovething wall1 = new NotMovething(xPosition, i, img);
                NotMovething wall2 = new NotMovething(xPosition + (size / 2), i, img);
                wallList.Add(wall1);
                wallList.Add(wall2);
            }
        }
    }
}
