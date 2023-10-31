using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Graph<T>
    {
        /// <summary>
        /// List of all nodes on the graph
        /// </summary>
        public List<Node<T>> NodeSet { get; private set; } = new List<Node<T>>();

        /// <summary>
        /// Search nodes by value ie string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> GetNodeByValue(T value)
        {
            return NodeSet.FirstOrDefault(n => n.Data.Equals(value));
        }

        /// <summary>
        /// Adds a new node to the list of nodes
        /// </summary>
        /// <param name="value">The nodes data</param>
        public void AddNode(T value)
        {
            NodeSet.Add(new Node<T>(value));
        }

        /// <summary>
        /// Removes node from graph and its connected edges
        /// </summary>
        /// <param name="nodeToRemove"></param>
        public void RemoveNode(Node<T> nodeToRemove)
        {
            //Checks if node exists and removes if true
            if (NodeSet.Contains(nodeToRemove))
            {
                NodeSet.Remove(nodeToRemove);

                //Cleans up and removes all connections to node
                foreach (var node in NodeSet)
                    node.RemoveEdge(nodeToRemove);
            }
            else
            {
                Console.WriteLine("Node doesn't exist in graph");
            }
        }

        /// <summary>
        /// Adds a Directed Edge between two nodes
        /// </summary>
        /// <param name="from">The node that can only be walked from</param>
        /// <param name="to">The node that can only be walked to</param>
        public void AddDirectedEdge(T from, T to, int weight = 1)
        {
            //Finds the matching nodes in the list
            Node<T> fromNode = GetNodeByValue(from);
            Node<T> toNode = GetNodeByValue(to);

            if (!fromNode.Equals(default(T)) && !toNode.Equals(default(T)))
            {
                fromNode.AddEdge(toNode, weight);
            }
            else
            {
                Console.WriteLine("Node not found!");
            }
        }

        /// <summary>
        /// Adds an edge that goes both ways
        /// </summary>
        /// <param name="from">The first node to be linked</param>
        /// <param name="to">The second node to be linked</param>
        public void AddEdge(T from, T to, int weight = 1)
        {
            //Finds the matching nodes in the list
            Node<T> fromNode = GetNodeByValue(from);
            Node<T> toNode = GetNodeByValue(to);

            if (!fromNode.Equals(default(T)) && !toNode.Equals(default(T)))
            {
                fromNode.AddEdge(toNode, weight);
                toNode.AddEdge(fromNode, weight);
            }
            else
            {
                Console.WriteLine("Node not found!");
            }
        }

        public void RemoveEdge(Node<T> from, Node<T> to)
        {
            if (NodeSet.Contains(from))
                from.RemoveEdge(to);
            else
                throw new Exception("Start node is not part of graph");
        }

        /// <summary>
        /// Displays graph with its connections
        /// </summary>
        public void DisplayGraph(List<Node<T>> nodeList)
        {
            foreach(Node<T> nodes in nodeList)
            {
                foreach (Edge<T> edge in nodes.Edges)
                    Console.WriteLine(edge.ToString());
            }
        }

        /// <summary>
        /// Displays path found by algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lastNode"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public List<Node<T>> TrackPath<T>(Node<T> lastNode, Node<T> start)
        {
            List<Node<T>> trackedPath = new List<Node<T>>();

            while (!lastNode.Equals(start))
            {
                trackedPath.Add(lastNode);
                lastNode = lastNode.Parent;
            }

            trackedPath.Add(start);

            trackedPath.Reverse();

            return trackedPath;
        }
    }
}
