using System;
using System.Drawing;

public class GameMap
{
    public static int height = 20;
    public static int width = 20;
    public static int[,] map = new int[height, width];

    public Snake snake { get; set; } = new Snake();

    public void DrawMap()
    {
        snake.Move();
        AddSnake();

        bool foodExists = false; // Flag to check whether a food item exists on the map
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.SetCursorPosition(x, y);
                if (map[x, y] == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else if (map[x, y] == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else if (map[x, y] == 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    foodExists = true;
                }
                Console.Write(" ");
            }
        }

        if (!foodExists)
        {
            SpawnFood();
        }

        AddSnake();
    }



    public void AddSnake()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (map[x, y] != 2 && !snake.body.Any(p => p.X == x && p.Y == y))
                {
                    map[x, y] = 0;
                }
            }
        }
        if (map[snake.body.First().X, snake.body.First().Y] == 2)
        {
            snake.SnakeEat();
            SpawnFood();
        }
        foreach (var point in snake.body)
        {
            map[point.X, point.Y] = 1;
        }
    }



    public void SpawnFood()
    {
        Random rnd = new Random();
        int spawnX, spawnY;
        do
        {
            spawnX = rnd.Next(width - 1);
            spawnY = rnd.Next(height - 1);
        } while (map[spawnX, spawnY] == 1);

        map[spawnX, spawnY] = 2;
    }

}
