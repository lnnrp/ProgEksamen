using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Edge<T>
    {
        public Node<T> Start { get; set; }
        public Node<T> End { get; set; }

        public Edge(Node<T> start, Node<T> end)
        {
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return "Edge: " + Start.Value.ToString() + " -> " + End.Value.ToString();
        }
    }
}
