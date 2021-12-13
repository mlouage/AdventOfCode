using System.Collections.Immutable;

namespace AOC._2021.Days;

public class Day12
{

    public PathWithSmallCavesMaxVisitOnce CreatePath(Node node, bool smallCaveMoreThanOnce = false) => smallCaveMoreThanOnce ? new PathWithSmallCaveTwiceOthersOnce(node) : new PathWithSmallCavesMaxVisitOnce(node);
    public PathWithSmallCavesMaxVisitOnce CreatePath(PathWithSmallCavesMaxVisitOnce path, Node node, bool smallCaveMoreThanOnce = false) => smallCaveMoreThanOnce ? new PathWithSmallCaveTwiceOthersOnce(path, node) : new PathWithSmallCavesMaxVisitOnce(path, node);

    public int Part1(string[] input)
    {
        var graph = Graph.Create(input);
        var paths = Traverse(graph).ToList();

        return paths.Count;
    }

    public int Part2(string[] input)
    {
        var graph = Graph.Create(input);
        var paths = Traverse(graph, smallCaveMoreThanOnce: true).ToList();

        return paths.Count;
    }

    private IEnumerable<PathWithSmallCavesMaxVisitOnce> Traverse(Graph graph, bool smallCaveMoreThanOnce = false)
    {
        var path = CreatePath(graph.Nodes["start"], smallCaveMoreThanOnce);
        var paths = new Queue<PathWithSmallCavesMaxVisitOnce>();
        paths.Enqueue(path);

        while (paths.Any())
        {
            var current = paths.Dequeue();
            var lastNode = current.Nodes.Last();
            foreach (var n in lastNode.GetConnectedNodes())
            {
                if (n.Name == "end")
                    yield return CreatePath(current, n, smallCaveMoreThanOnce);
                else if (current.CanVisit(n))
                    paths.Enqueue(CreatePath(current, n, smallCaveMoreThanOnce));
            }
        }
    }

    public class PathWithSmallCavesMaxVisitOnce
    {
        public PathWithSmallCavesMaxVisitOnce(Node startNode)
        {
            Visited = new() { [startNode] = 1 };
            Nodes = new() { startNode };
        }

        public PathWithSmallCavesMaxVisitOnce(PathWithSmallCavesMaxVisitOnce path, Node node)
        {
            Visited = new Dictionary<Node, int>(path.Visited);
            Nodes = new List<Node>(path.Nodes)
            {
                node
            };
            Visited[node] = Visited.GetValueOrDefault(node, 0) + 1;
        }

        protected Dictionary<Node, int> Visited { get; }
        public List<Node> Nodes { get; }


        public virtual bool CanVisit(Node node)
        {
            return !Visited.ContainsKey(node) || Visited[node] < node.MaxVisits;
        }

        public override string ToString()
        {
            return string.Join(",", Nodes);
        }
    }

    public class PathWithSmallCaveTwiceOthersOnce : PathWithSmallCavesMaxVisitOnce
    {
        public PathWithSmallCaveTwiceOthersOnce(Node startNode) : base(startNode)
        {
        }

        public PathWithSmallCaveTwiceOthersOnce(PathWithSmallCavesMaxVisitOnce path, Node node) : base(path, node)
        {
            if (path is PathWithSmallCaveTwiceOthersOnce p)
            {
                visitedSmallCaveTwice = p.visitedSmallCaveTwice;
            }
                

            if (node.MaxVisits == 1 && Visited.ContainsKey(node) && Visited[node] == 2)
            {
                visitedSmallCaveTwice = true;
            }
        }

        protected bool visitedSmallCaveTwice;

        public override bool CanVisit(Node node)
        {
            return base.CanVisit(node) || (node.MaxVisits == 1 && visitedSmallCaveTwice == false && node.Name != "start" && node.Name != "end");
        }

    }

    public class Graph
    {
        public Dictionary<string, Node> Nodes { get; } = new();

        public static Graph Create(string[] paths)
        {
            var graph = new Graph();

            foreach (var path in paths)
            {
                var nodes = path.Split('-', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                graph.AddConnection(nodes[0], nodes[1]);
            }

            return graph;
        }

        public void AddConnection(string node1, string node2)
        {
            var n1 = GetOrCreateNode(node1);
            var n2 = GetOrCreateNode(node2);

            n1.Connect(n2);
        }

        private Node GetOrCreateNode(string nodeName)
        {
            if (Nodes.ContainsKey(nodeName))
            {
                return Nodes[nodeName];
            }
                
            var node = CreateNode(nodeName);
            
            Nodes.Add(nodeName, node);
            
            return node;
        }

        public Node CreateNode(string node)
        {
            if (char.IsLower(node[0]))
            {
                return new Node(node, 1);
            }

            return new Node(node, int.MaxValue);
        }
    }

    public class Node
    {
        public Node(string name, int maxVisits)
        {
            Name = name;
            MaxVisits = maxVisits;
        }

        public string Name { get; }
        public int MaxVisits { get; }
        protected HashSet<Node> ConnectedNodes { get; } = new HashSet<Node>();

        public IEnumerable<Node> GetConnectedNodes()
        {
            return ConnectedNodes.ToImmutableHashSet();
        }

        public void Connect(Node node)
        {
            ConnectedNodes.Add(node);
            node.ConnectedNodes.Add(this);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

