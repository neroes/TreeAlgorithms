using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    abstract class Node<T>
    {
        readonly T value;
        protected Node<T> parent;
        protected Node<T> leftChild;
        protected Node<T> rightChild;
        public Node(T value)
        {
            this.value = value;
        }
        public Node<T> GetParent()
        {
            return parent;
        }
        public Node<T> GetRightChild()
        {
            return rightChild;
        }
        public Node<T> GetLeftChild()
        {
            return leftChild;
        }
        public void SetParent(Node<T> parent)
        {
            this.parent = parent;
        }
        public void SetRightChild(Node<T> child)
        {
            this.rightChild = child;
        }
        public void SetLeftChild(Node<T> child)
        {
            this.leftChild = child;
        }

    }
}