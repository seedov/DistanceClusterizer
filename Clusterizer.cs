using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Point<T>
{
    public Vector2 Position;
    public T Data;
}


public class Cluster<T>
{
    public Vector2 Position;
    public List<Point<T>> Points = new List<Point<T>>();

    public void AddPoint(Point<T> point)
    {
        Points.Add(point);
        Position = new Vector2(Points.Sum(p=>p.Position.x)/Points.Count, Points.Sum(p=>p.Position.y)/Points.Count);
    }
}

public interface IClusterizer<T>
{
    IEnumerable<Cluster<T>> Clusterize(IEnumerable<Point<T>> points, float groupDistance);
}
public class Clusterizer<T>:IClusterizer<T>
{
   
    public IEnumerable<Cluster<T>> Clusterize(IEnumerable<Point<T>> points, float groupDistance)
    {
        var result = new List<Cluster<T>>();
        var processingPoints = points.ToList();
        var processedPoints = new List<Point<T>>();
        foreach (var processingPoint in processingPoints)
        {
            var newGroup = new Cluster<T>();
            newGroup.AddPoint(processingPoint);
            foreach (var point in processingPoints)
            {
                if(point == processingPoint || processedPoints.Contains(point))
                    continue;
                if (Vector2.SqrMagnitude(point.Position - processingPoint.Position) < groupDistance * groupDistance)
                {
                    newGroup.AddPoint(point);
                    processedPoints.Add(processingPoint);
                    processedPoints.Add(point);
                }
            }
            if(newGroup.Points.Count>1)
                result.Add(newGroup);
        }
        return result;
    }
}
