using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Tree
{
    public class DisplayNode<T>
    {
        private List<DisplayNode<T>> displayChildren { get; set; }

        public Node<T> Node { get; set; }
        public int Size { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool DrawChildren { get; set; } = true;

        public List<DisplayNode<T>> DisplayChildren
        {
            get { return displayChildren ?? new List<DisplayNode<T>>(); }
        }

        public DisplayNode(Node<T> node, int x, int y, int size)
        {
            this.Node = node;
            this.X = x;
            this.Y = y;
            this.Size = size;
        }

        public void AddChild(Node<T> node, int x, int y, int size)
        {
            this.DisplayChildren.Add(new DisplayNode<T>(node, x, y, size));
        }
    }
}
