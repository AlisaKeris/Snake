using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static void Main(string[] args)
    {
        Point p1 = new Point(1, 2, "o");
        Draw(p1);
    }
    
    public void Draw(Point p)
    {        
        Console.SetCursorPosition(p.x, p.y);
        Console.Write(p.sym);
    }
    
}

