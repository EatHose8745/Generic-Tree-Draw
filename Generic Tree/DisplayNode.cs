using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Tree
{
    public class DisplayNode<T>
    {
        public Node<T> Node { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public DisplayNode(Node<T> node, int x, int y)
        {
            this.Node = node;
            this.X = x;
            this.Y = y;
        }
    }
}
