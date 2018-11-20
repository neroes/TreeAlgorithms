using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    public class Node<T> : IComparable
        where T : IComparable 
    {
        public readonly T value;
        protected Node<T> parent;
        protected Node<T> leftChild;
        protected Node<T> rightChild;

        public Node<T> Parent { get => parent; }
        public Node<T> LeftChild { get => leftChild; }
        public Node<T> RightChild { get => rightChild; }

        public Node(T value)
        {
            this.value = value;
        }

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

        public int CompareTo(object obj)
        {
            if (obj is Node<T>) { return value.CompareTo(((Node<T>)obj).value); }// is same type of Node and value is therefore compared
            else if (obj is T) { return value.CompareTo((T)obj); } // is same type as value and is therefore directy compared
            throw new Exception("object wasn't of same type of node or same type of value");// we don't know what to do with this type of input
        }
        public StringBuilder BuildValueString(StringBuilder st)
        {
            if(LeftChild != null) { LeftChild.BuildValueString(st); }
            st.Append(" " + value);
            if(RightChild != null) { RightChild.BuildValueString(st); }
            return st;
        }
    }
}