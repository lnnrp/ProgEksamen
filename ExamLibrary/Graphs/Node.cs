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
        public T Value { get; set; }

        /// <summary>
        /// Connections going out from the node
        /// </summary>
        public List<Edge<T>> Edges { get; } = new List<Edge<T>>();

        public Node(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Adds an edge between two nodes
        /// </summary>
        /// <param name="end">Other node to connect to</param>
        /// <param name="addReturn">Optional parameter, by default adds connection both ways</param>
        public void AddEdge(Node<T> end, bool addReturn = true)
        {
            Edges.Add(new Edge<T>(this, end));

            if (addReturn)
                end.AddEdge(this, false); 
        }

        /// <summary>
        /// Removes edge between two nodes
        /// </summary>
        public void RemoveEdge(Node<T> end)
        {
            Edge<T> edgeToRemove = null;
            foreach(Edge<T> edge in Edges)
            {
                if (edge.End == end)
                {
                    edgeToRemove = edge;
                    return;
                }
            }
            Edges.Remove(edgeToRemove);
        }

        public override string ToString()
        {
            return "Node: " + Value.ToString();
        }
    }
}
