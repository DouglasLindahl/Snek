using System;
using System.Collections.Generic;
using System.Drawing;

public class Snake
{
    public string direction { get; set; } = "right";
    public string previousDirection = "right";
    public bool isAlive = true;
    public List<Point> body = new List<Point>();

    public void CreateSnake()
    {
        body.Add(new Point(5, 5));
    }

    public void Move()
    {
        Point nextPosition;
        switch (direction)
        {
            case "up":
                nextPosition = new Point(body[0].X, body[0].Y - 1);
                break;
            case "down":
                nextPosition = new Point(body[0].X, body[0].Y + 1);
                break;
            case "left":
                nextPosition = new Point(body[0].X - 1, body[0].Y);
                break;
            case "right":
                nextPosition = new Point(body[0].X + 1, body[0].Y);
                break;
            default:
                nextPosition = body[0];
                break;
        }
        if (nextPosition.X >= 0 && nextPosition.X < 20 && nextPosition.Y >= 0 && nextPosition.Y < 20)
        {
            if (direction == "up")
            {
                for (int i = body.Count - 1; i >= 0; i--)
                {
                    if (i > 0)
                    {
                        body[i] = body[i - 1];
                    }
                    else
                    {
                        body[i] = new Point(body[i].X, body[i].Y - 1);
                    }
                }
            }
            else if (direction == "down")
            {
                for (int i = body.Count - 1; i >= 0; i--)
                {
                    if (i > 0)
                    {
                        body[i] = body[i - 1];
                    }
                    else
                    {
                        body[i] = new Point(body[i].X, body[i].Y + 1);
                    }
                }
            }
            else if (direction == "left")
            {
                for (int i = body.Count - 1; i >= 0; i--)
                {
                    if (i > 0)
                    {
                        body[i] = body[i - 1];
                    }
                    else
                    {
                        body[i] = new Point(body[i].X - 1, body[i].Y);
                    }
                }
            }
            else if (direction == "right")
            {
                for (int i = body.Count - 1; i >= 0; i--)
                {
                    if (i > 0)
                    {
                        body[i] = body[i - 1];
                    }
                    else
                    {
                        body[i] = new Point(body[i].X + 1, body[i].Y);
                    }
                }
            }
        }
        else
        {
            isAlive = false;
        }
        for(int i = 0; i < body.Count; i ++)
        {
            for(int x = 0; x < body.Count; x++)
            {
                if(x != i)
                {
                    if (body[x] == body[i])
                    {
                        isAlive = false;
                    }
                }
            }
        }
    }
    public void SnakeEat()
    {
        Point newTail = new Point(body.Last().X, body.Last().Y);
        body.Add(newTail);
    }

}