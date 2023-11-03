using System.Collections.Generic;
using Graphs;

Graph<string> graph = new Graph<string>();

SetupGraph();

// Returns the end node or null if not found
Node<string> n = BFS(graph.GetNodeByValue("Entrance"), graph.GetNodeByValue("Ghost Train"));

// Tracks path through graph
List<Node<string>> path = graph.TrackPath(n, graph.GetNodeByValue("Entrance"));

// Writes path out to console
graph.DisplayGraph(path);

// Makes a graph with nodes and edges
void SetupGraph()
{
    graph.AddNode("Entrance");
    graph.AddNode("Ice Blaster");
    graph.AddNode("Funhouse");
    graph.AddNode("Slot Machines");
    graph.AddNode("Rocket Ships");
    graph.AddNode("3D Cinema");
    graph.AddNode("Hotdogs");
    graph.AddNode("Log Flume");
    graph.AddNode("Big Dipper");
    graph.AddNode("Ghost Train");
    graph.AddNode("Pirate Ship");
    graph.AddNode("Rollercoaster");
    graph.AddNode("Carousel");
    graph.AddNode("Flying Chairs");

    graph.AddEdge("Entrance", "Slot Machines");
    graph.AddEdge("Entrance", "Ice Blaster");
    graph.AddEdge("Entrance", "Funhouse");

    graph.AddEdge("Slot Machines", "Ice Blaster");
    graph.AddEdge("Slot Machines", "Hotdogs");
    graph.AddEdge("Slot Machines", "Rocket Ships");

    graph.AddEdge("Ice Blaster", "Rocket Ships");
    graph.AddEdge("Ice Blaster", "3D Cinema");
    graph.AddEdge("Ice Blaster", "Funhouse");

    graph.AddEdge("Funhouse", "3D Cinema");

    graph.AddEdge("3D Cinema", "Pirate Ship");

    graph.AddEdge("Rocket Ships", "3D Cinema");
    graph.AddEdge("Rocket Ships", "Ghost Train");

    graph.AddEdge("Hotdogs", "Log Flume");
    graph.AddEdge("Log Flume", "Big Dipper");

    graph.AddEdge("Big Dipper", "Rollercoaster");
    graph.AddEdge("Big Dipper", "Ghost Train");

    graph.AddEdge("Ghost Train", "Carousel");
    graph.AddEdge("Ghost Train", "Flying Chairs");

    graph.AddEdge("Carousel", "Flying Chairs");
}

// Virtually the same as DFS but uses a queue
Node<string> BFS(Node<string> start, Node<string> goal)
{ 
    Queue<Edge<string>> path = new Queue<Edge<string>>();

    path.Enqueue(new Edge<string>(start, start));

    while (path.Count > 0)
    {
        Edge<string> edge = path.Dequeue();

        if (!edge.To.Discovered)
        {
            edge.To.Discovered = true;
            edge.To.Parent = edge.From;
        }

        foreach (Edge<string> e in edge.To.Edges)
        {
            if (!e.To.Discovered)
                path.Enqueue(e);
        }

        if (edge.To == goal)
        {
            return edge.To;
        }
    }

    return null;
}
