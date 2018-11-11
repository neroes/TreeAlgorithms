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

        public Node<T> Parent { get => parent; }
        public Node<T> LeftChild { get => leftChild; }
        public Node<T> RightChild { get => rightChild; }
        public void SetParent(Node<T> parent)
        {
            this.parent = parent;
        }
        public void SetLeftChild(Node<T> child)
        {
            this.leftChild = child;
        }
        public void SetRightChild(Node<T> child)
        {
            this.rightChild = child;
        }
        
        public Node(T value)
        {
            this.value = value;
        }
        
        

    }
}