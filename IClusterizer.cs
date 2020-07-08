using System.Collections.Generic;

public interface IClusterizer<T>
{
    IEnumerable<Cluster<T>> Clusterize(IEnumerable<Point<T>> points, float groupDistance);
}