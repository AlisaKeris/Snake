using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VisioForge.Shared.MediaFoundation.OPM;
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

			//Очки
			Score score = new Score(0);
			if (snake.Eat(food))
			{
				Console.ForegroundColor = ConsoleColor.Green;
				food = foodCreator.CreateFood();
				food.Draw();
			
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
				snake.Move();
			}
			


			int time = 100;
			Thread.Sleep(time);

			//Время
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			//Имя
			string name;



			Console.Write("Type your name: ");
			name = Console.ReadLine();






			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					food = foodCreator.CreateFood();
					food.Draw();

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


		static void WriteGameOver() //Конец игры
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("----------------------------", xOffset, yOffset++);
			WriteText("Игра окончена", xOffset + 1, yOffset++);
			yOffset++;
			WriteText("Автор: Alisa Krupenko", xOffset + 2, yOffset++);
			WriteText("----------------------------", xOffset, yOffset++);
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}

}
}



