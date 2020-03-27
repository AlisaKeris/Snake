using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80,25);
            /*Point p2 = new Point(3, 2, '*');
            Point p3 = new Point(2, 1, '#');
            Point p1 = new Point(1, 2, 'o');*/
            //Point.Draw(p1);

            List<Point> pointList = new List<Point>();

            pointList.Add(new Point(1, 2, '*'));
            pointList.Add(new Point(3, 4, '*'));
            pointList.Add(new Point(3,2,'*'));
            pointList.Add(new Point(1, 4, '*'));
            foreach (Point p1 in pointList)
            {
                p1.Draw();
            }

            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
            upLine.Drow();
            downLine.Drow();
            leftLine.Drow();
            rightLine.Drow();

            Point p = new Point(4, 5, 'x');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();


            Console.ReadLine();
        }

    }
}


