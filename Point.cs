using UnityEngine;

public class Point<T>
{
    public Vector2 Position { get; set; }
    public T Data { get; }

    public Point(T data)
    {
        Data = data;
    }
}