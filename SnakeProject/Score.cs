using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    class Score
    {
        public int score;

        public Score(int x)
        {
            score = x;
            Console.SetCursorPosition(0, 25);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Score: " + score);
        }
        public Score AddPoint(Score score, bool soundSwitch)
        {
            this.score++;
            Console.SetCursorPosition(7, 25);
            Console.Write(this.score);
            Console.ForegroundColor = ConsoleColor.White;
            return score;
        }
    }
}
