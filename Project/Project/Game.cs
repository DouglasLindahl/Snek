//
// This is the game event logic that you can customize and cannibalize
// as needed. You should try to write your game in a modular way, avoid
// making one huge Game class.
//

class Game
{
    public GameMap gameMap = new GameMap();
    public Snake snake = new Snake();
    public string previousDirection = "";
    ScheduleTimer? _timer;

    public bool Paused { get; private set; }
    public bool GameOver { get; private set; }

    public void Start()
    {
        snake.CreateSnake();
        gameMap.snake = snake;
        gameMap.DrawMap();
        ScheduleNextTick();
    }

    public void Pause()
    {
        Console.WriteLine("Pause");
        Paused = true;
        _timer!.Pause();
    }

    public void Resume()
    {
        Console.WriteLine("Resume");
        Paused = false;
        _timer!.Resume();
    }

    public void Stop()
    {
        Console.WriteLine("Stop");
        GameOver = true;
    }

    public void Input(ConsoleKey key)
    {
        if(key == ConsoleKey.UpArrow)
        {
            if(snake.body.Count > 1)
            {
                if (previousDirection != "down")
                {
                    snake.direction = "up";
                    previousDirection = "up";
                }
            }
            else
            {
                snake.direction = "up";
                previousDirection = "up";
            }
        }
        if (key == ConsoleKey.DownArrow)
        {
            if (snake.body.Count > 1)
            {
                if (previousDirection != "up")
                {
                    snake.direction = "down";
                    previousDirection = "down";
                }
            }
            else
            {
                snake.direction = "down";
                previousDirection = "down";
            }
        }
        if (key == ConsoleKey.LeftArrow)
        {
            if (snake.body.Count > 1)
            {
                if (previousDirection != "right")
                {
                    snake.direction = "left";
                    previousDirection = "left";
                }
            }
            else
            {
                snake.direction = "left";
                previousDirection = "left";
            }
        }
        if (key == ConsoleKey.RightArrow)
        {
            if (snake.body.Count > 1)
            {
                if (previousDirection != "left")
                {
                    snake.direction = "right";
                    previousDirection = "right";
                }
            }
            else
            {
                snake.direction = "right";
                previousDirection = "right";
            }
        }
    }

    void Tick()
    {
        gameMap.DrawMap();
        if (!snake.isAlive)
        {
            Stop();
        }
        ScheduleNextTick();
    }

    void ScheduleNextTick()
    {
        // the game will automatically update itself every half a second, adjust as needed
        _timer = new ScheduleTimer(120, Tick);
    }
}