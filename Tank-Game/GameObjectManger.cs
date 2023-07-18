using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Game
{

    internal class GameObjectManger
    {
        private static List<NotMovething> wallList = new List<NotMovething>();
        public static void DrawMap()
        {
            foreach (NotMovething wall in wallList)
            {
                wall.DrawSelf();
            }
        }
        public static void CreatMap()
        {
            CreateWall(1, 1, 5, wallList);
        }

        private static List<NotMovething> CreateWall(int x, int y, int count, List<NotMovething> wallList)
        {
            int xPosition = x * 30;
            int yPosition = y * 30;
            for (int i = yPosition; i < yPosition + count * 30; i += 15)
            {
                // i xPosition   i xPosition + 15
                NotMovething wall1 = new NotMovething(xPosition, i, Properties.Resources.wall);
                NotMovething wall2 = new NotMovething(xPosition + 15, i, Properties.Resources.wall);
                wallList.Add(wall1);
                wallList.Add(wall2);
            }
            return wallList;
        }
    }
}
