using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zmejka
{
    struct Coords
    {
        public int x, y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Coords[] snake = new Coords[100];
            snake[0].x = Console.WindowWidth / 2;
            snake[0].y = Console.WindowHeight / 2;
            snake[1].x = snake[0].x - 1;
            snake[1].y = snake[0].y;
            snake[2].x = snake[1].x - 1;
            snake[2].y = snake[1].y;
            Random random = new Random();
            int score = 0;

            int[,] pole = new int[Console.WindowWidth, Console.WindowHeight];//1 - apple, 2 - orange, 100 - wall

            pole[10, 5] = 1;
            pole[14, 6] = 1;
            pole[40, 2] = 2;
            pole[20, 17] = 2;
            pole[10, 15] = 100;

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                for (int j = 0; j < Console.WindowHeight; j++)
                {
                    Console.SetCursorPosition(i, j);
                    switch(pole[i,j])
                    {
                        case 1:
                            Console.Write("A");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 100:
                            Console.Write("|");
                            break;
                    }
                }
            }

            int speed = 500;
            int count = 3;
            int dx = 1;
            int dy = 0;
            ConsoleKeyInfo Key = new ConsoleKeyInfo();


            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Score: {score}");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < count; i++)
                {
                    Console.SetCursorPosition(snake[i].x, snake[i].y);
                    Console.Write("*");
                }

                Thread.Sleep(speed);


                Console.SetCursorPosition(snake[count - 1].x, snake[count - 1].y);
                Console.Write(" ");

                for (int i = count-1; i > 0 ; i--)
                {
                    snake[i] = snake[i - 1];
                }

                if (Console.KeyAvailable)
                    Key = Console.ReadKey();
                switch(Key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (dy == 1)
                            break;
                        dx = 0; dy = -1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (dy == -1)
                            break;
                        dx = 0; dy = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (dx == 1)
                            break;
                        dx = -1; dy = 0;
                        break;
                    case ConsoleKey.RightArrow:
                        if (dx == -1)
                            break;
                        dx = 1; dy = 0;
                        break;
                }
                
               
                snake[0].x += dx;
                snake[0].y += dy;

                if (pole[snake[0].x, snake[0].y] == 1)
                {
                    int a, b;
                    count++;
                    a = random.Next(Console.WindowWidth - 1);
                    b = random.Next(Console.WindowHeight - 1);
                    pole[a, b] = 1;
                    Console.SetCursorPosition(a, b);
                    Console.Write("A");
                }
            }

        }
    }
}
