using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Clusterizer<T>:IClusterizer<T>
{
   
    public IEnumerable<Cluster<T>> Clusterize(IEnumerable<Point<T>> points, float groupDistance)
    {
        var result = new List<Cluster<T>>();
        var processingPoints = points.ToList();
        var processedPoints = new HashSet<Point<T>>();
        foreach (var processingPoint in processingPoints)
        {
            if(processedPoints.Contains(processingPoint))
                continue;
            
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
