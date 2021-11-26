using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Tree
{
    public class Node<T>
    {
        public T Data { get; set; }
        private List<Node<T>> children;

        public Node(T data)
        {
            this.Data = data;
        }

        public List<Node<T>> Children
        {
            get
            {
                return children = children ?? new List<Node<T>>();
            }
        }

        public void AddChild(Node<T> node)
        {
            Children.Add(node);
        }
    }
}