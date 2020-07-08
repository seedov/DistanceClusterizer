# DistanceClusterizer
## Usage:
1. Create instance of clusterizer. Parameter means what kind of objects you wand to clusterize. For instance GameObject
~~~C#
private IClusterizer<GameObject> _clusterizer = new Clusterizer<GameObject>();
~~~
2. Create some points
~~~C#
for (var i = 0; i < 100; ++i)
{
    var p = new GameObject();
    var position = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
    p.transform.position = position;
    _points.Add(new Point<GameObject>(p){Position = position});
}
~~~      
3. Clusterize them
~~~C#
IEnumerable<Cluster<GameObject>> groups = _clusterizer.Clusterize(_points, _groupDistance);
~~~      
