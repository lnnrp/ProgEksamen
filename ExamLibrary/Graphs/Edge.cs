using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Edge<T>
    {
        /// <summary>
        /// The node the edge goes to
        /// </summary>
        public Node<T> To { get; private set; }
        /// <summary>
        /// The node the edge goes from
        /// </summary>
        public Node<T> From { get; private set; }
        /// <summary>
        /// The edges weight, by default 1
        /// </summary>
        public int Weight { get; private set; }

        /// <summary>
        /// Makes a new edge
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public Edge(Node<T> from, Node<T> to, int weight = 1)
        {
            To = to;
            From = from;
            Weight = weight;
        }

        public override string ToString()
        {
            return "Edge: " + From.Data.ToString() + " -> " + To.Data.ToString();
        }
    }
}
