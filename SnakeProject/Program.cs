using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMPLib;

namespace SnakeProject
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.SetBufferSize(120, 30);

			Walls walls = new Walls(120, 30);
			walls.Draw();

			// Отрисовка точек			
			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(120, 30, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();

			Params settings = new Params();
			Sounds sound = new Sounds(settings.GetResourceFolder());
			sound.Play();

			Sounds sound1 = new Sounds(settings.GetResourceFolder());

			//Score
			Score score = new Score(settings.GetResourceFolder());

			//Timer
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();


			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					food = foodCreator.CreateFood();
					food.Draw(ConsoleColor.Red);
					sound1.PlayEat();
					score.UpCurrentPoints();
					score.ShowCurrentPoints();
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			WriteGameOver();
			Console.ReadLine();
		}


		static void WriteGameOver()
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("ИГРА ОКОНЧЕНА", xOffset + 1, yOffset++);
			yOffset++;
			WriteText("Автор: Alisa Krupenko", xOffset + 2, yOffset++);
			WriteText("============================", xOffset, yOffset++);
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}

	}
}


