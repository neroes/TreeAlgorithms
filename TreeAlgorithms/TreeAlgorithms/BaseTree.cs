using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    public class BaseTree<T> : ITree<T> where T : IComparable, IEquatable<T>
    {
        private Node<T> tree_Root;
        public void Insert(T value)
        {
            InsertSingle(value);
        }
        public void Insert(List<T> value)
        {
            foreach (T v in value)
            {
                InsertSingle(v);
            }
        }
        private void InsertSingle(T value)
        {
            InsertSingleNode(new Node<T>(value));
        }
        protected void InsertSingleNode(Node<T> newNode)
        {
            Node<T> insertParent = SearchNode(newNode.value);
            if (insertParent.value.Equals(newNode.value)) { throw new Exception("values are the same"); }//our tree is limited to one node pr value (some trees alow for multiple instances of value)
            if (insertParent== null) { tree_Root = newNode; }
            else if (insertParent.CompareTo(newNode.value) < 0) { insertParent.SetRightChild(newNode); }
            else { insertParent.SetLeftChild(newNode); }
        }

        public Node<T> SearchNode(T value) {
            Node<T> current_Node = tree_Root;
            if (current_Node == null) { return null; }
            while (!current_Node.value.Equals(value))
            {
                if (current_Node.CompareTo(value) < 0)
                {
                    if (current_Node.RightChild != null) { current_Node = current_Node.RightChild; }
                    else { break; }
                }
                else
                {
                    if (current_Node.LeftChild != null) { current_Node = current_Node.LeftChild; }
                    else { break; }
                }
            }
            return current_Node;
        }
        public T Search(T value) {
            return SearchNode(value).value;
        }
        public bool Contains(T value)
        {
            return (Search(value).Equals(value));
        }
        public void Delete(Node<T> node)
        {
            bool isroot = (node != tree_Root);
            bool isRightChild = node.Parent.RightChild.Equals(node);
            if (node.LeftChild == null)
            {
                if (node.RightChild == null)// has no children
                {
                    if (isroot) { tree_Root = null; } // is only node in tree
                    else if (isRightChild){ node.Parent.SetRightChild(null); }
                    else { node.Parent.SetLeftChild(null); }
                }
                else// has only right child
                {
                    if (isRightChild) { node.Parent.SetRightChild(node.RightChild); }
                    else { node.Parent.SetLeftChild(node.RightChild); }
                }
            }
            else if (node.RightChild == null)//has only left child
            {
                if (isRightChild) { node.Parent.SetRightChild(node.LeftChild); }
                else { node.Parent.SetLeftChild(node.LeftChild); }
            }
            else// has 2 children
            {
                throw new NotImplementedException();
            }
        }
        public void Delete(T value)
        {
            Node<T> node = SearchNode(value);
            if (node.value.Equals(value))
            {
                Delete(node);
            }
            else
            {
                throw new Exception("no such value exists");
            }
            
        }
    }
}