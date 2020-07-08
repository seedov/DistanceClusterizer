using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cluster<T>
{
    public Vector2 Position { get; set; }
    public IReadOnlyCollection<Point<T>> Points => _points;
    private List<Point<T>> _points = new List<Point<T>>();

    public void AddPoint(Point<T> point)
    {
        _points.Add(point);
        Position = new Vector2(_points.Sum(p=>p.Position.x)/_points.Count, _points.Sum(p=>p.Position.y)/_points.Count);
    }
}