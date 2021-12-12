using System.Collections.Immutable;

namespace AOC._2021.Days;

public class Day12
{

    public Path CreatePath(Node node, bool part2 = false) => part2 ? new Path2(node) : new Path(node);
    public Path CreatePath(Path path, Node node, bool part2 = false) => part2 ? new Path2(path, node) : new Path(path, node);

    public int Part1(string[] input)
    {
        var graph = Graph.Create(input);
        var paths = Traverse(graph).ToList();

        return paths.Count;
    }

    public int Part2(string[] input)
    {
        var graph = Graph.Create(input);
        var paths = Traverse(graph, part2: true).ToList();

        return paths.Count;
    }

    private IEnumerable<Path> Traverse(Graph graph, bool part2 = false)
    {
        var path = CreatePath(graph.Nodes["start"], part2);
        var paths = new Queue<Path>();
        paths.Enqueue(path);

        while (paths.Any())
        {
            var current = paths.Dequeue();
            var lastNode = current.Nodes.Last();
            foreach (var n in lastNode.GetConnectedNodes())
            {
                if (n.Name == "end")
                    yield return CreatePath(current, n, part2);
                else if (current.CanVisit(n))
                    paths.Enqueue(CreatePath(current, n, part2));
            }
        }
    }

    public class Path
    {
        public Path(Node startNode)
        {
            Visited = new() { [startNode] = 1 };
            Nodes = new() { startNode };
        }

        public Path(Path path, Node node)
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

    public class Path2 : Path
    {
        public Path2(Node startNode) : base(startNode)
        {
        }

        public Path2(Path path, Node node) : base(path, node)
        {
            if (path is Path2 p)
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

