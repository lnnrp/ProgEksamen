using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Node for storage of a value in a graph
    /// </summary>
    /// <typeparam name="T">Type of value stored</typeparam>
    public class Node<T>
    {

        /// <summary>
        /// The nodes data, IE an int, string etc
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// Has node been seen already
        /// </summary>
        public bool Discovered { get; set; }

        public Node<T> Parent { get; set; }

        /// <summary>
        /// All edged connected to the node
        /// </summary>
        public List<Edge<T>> Edges { get; private set; } = new List<Edge<T>>();

        public Node(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Adds edge from this node, to another
        /// </summary>
        /// <param name="other">The other node that the edge is between</param>
        public void AddEdge(Node<T> other, int weight = 1)
        {
            Edges.Add(new Edge<T>(this, other, weight));
        }

        /// <summary>
        /// Removes edge between two nodes
        /// </summary>
        /// <param name="end"></param>
        public void RemoveEdge(Node<T> end)
        {
            Edge<T> edgeToRemove = null;
            foreach(Edge<T> edge in Edges)
            {
                if (edge.To == end)
                {
                    edgeToRemove = edge;
                    return;
                }
            }
            Edges.Remove(edgeToRemove);
        }

        public override string ToString()
        {
            return "Node: " + Data.ToString();
        }
    }
}
