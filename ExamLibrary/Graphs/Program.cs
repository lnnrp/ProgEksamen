using Graphs;

// Create graph
Graph<string> graph = new Graph<string>();

// Create nodes
Node<string> node1 = new Node<string>("Link");
Node<string> node2 = new Node<string>("Zelda");
Node<string> node3 = new Node<string>("Sidon");

// Add nodes
graph.AddNode(node1);
graph.AddNode(node2);
graph.AddNode(node3);

// Add edges (connections)
node1.AddEdge(node2);
node1.AddEdge(node3, false);

// Display graph
graph.DisplayGraph();

Console.ReadLine();