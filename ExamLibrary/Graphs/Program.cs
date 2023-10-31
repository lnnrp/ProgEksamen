using Graphs;

// Create graph
Graph<string> graph = new Graph<string>();


// Add nodes
graph.AddNode("Link");
graph.AddNode("Zelda");
graph.AddNode("Sidon");

// Add edges (connections)
graph.AddEdge("Link", "Zelda");
graph.AddEdge("Zelda", "Sidon");
graph.AddDirectedEdge("Link", "Sidon");

// Display graph
graph.DisplayGraph(graph.NodeSet);

Console.ReadLine();