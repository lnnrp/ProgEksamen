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
        /// Collections of all nodes in graph
        /// </summary>
        public List<Node<T>> Nodes { get; } = new List<Node<T>>();

        /// <summary>
        /// Search nodes by value ie string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> GetNodeByValue(T value)
        {
            return Nodes.FirstOrDefault(n => n.Value.Equals(value));
        }

        /// <summary>
        /// Adds new node to graph
        /// </summary>
        /// <param name="node"></param>
        /// <returns>Node added or exception</returns>
        /// <exception cref="Exception"></exception>
        public Node<T> AddNode(Node<T> node)
        {
            if (!Nodes.Contains(node))
            {
                Nodes.Add(node);
                return node;
            }
            else
                throw new Exception("Node is not part of graph");
        }

        public void RemoveNode(Node<T> nodeToRemove)
        {
            //Checks if node exists and removes if true
            if (Nodes.Contains(nodeToRemove))
            {
                Nodes.Remove(nodeToRemove);

                //Cleans up and removes all connections to node
                foreach (var node in Nodes)
                    node.RemoveEdge(nodeToRemove);
            }
            else
            {
                throw new Exception("Node doesn't exist in graph");
            }
        }

        public void AddEdge(Node<T> start, Node<T> end)
        {
            start.AddEdge(end);
        }

        public void RemoveEdge(Node<T> start, Node<T> end)
        {
            if (Nodes.Contains(start))
                start.RemoveEdge(end);
            else
                throw new Exception("Start node is not part of graph");
        }

        public void DisplayGraph()
        {
            foreach(Node<T> nodes in Nodes)
            {
                foreach (Edge<T> edge in nodes.Edges)
                    Console.WriteLine(edge.ToString());
            }
        }

    }
}
