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
            if (insertParent== null) { tree_Root = newNode; }
            else if (insertParent.value.Equals(newNode.value)) { throw new Exception("values are the same"); }//our tree is limited to one node pr value (some trees alow for multiple instances of value)
            else if (insertParent.CompareTo(newNode.value) < 0) { insertParent.SetRightChild(newNode); }
            else { insertParent.SetLeftChild(newNode); }
            newNode.SetParent(insertParent);
        }

        protected Node<T> SearchNode(T value) {
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
        public List<T> Search(T min, T max)
        {

        }
        public bool Contains(T value)
        {
            return (Search(value).Equals(value));
        }
        public void Delete(Node<T> node)
        {
            bool isroot = (node == tree_Root);
            bool isRightChild = false;
            if (!isroot)
            {
                isRightChild = node.Parent.RightChild.Equals(node);
            }
            
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
                    else if (isroot){ tree_Root = node.RightChild; }
                    else { node.Parent.SetLeftChild(node.RightChild); }
                }
            }
            else if (node.RightChild == null)//has only left child
            {
                if (isRightChild) { node.Parent.SetRightChild(node.LeftChild); }
                else if (isroot) { tree_Root = node.LeftChild; }
                else { node.Parent.SetLeftChild(node.LeftChild); }
            }
            else// has 2 children
            {
                Node<T> rightNearNode = node.RightChild;
                int rightNodeCount = 1;
                while (rightNearNode.LeftChild != null)// finds the dept distance to the nearest node on right side of node
                {
                    rightNodeCount++;
                    rightNearNode = rightNearNode.LeftChild;
                }
                Node<T> leftNearNode = node.LeftChild;
                int leftNodeCount = 1;
                while (leftNearNode.RightChild != null)// finds the dept distance to the nearest node on right side of node
                {
                    leftNodeCount++;
                    leftNearNode = leftNearNode.LeftChild;
                }
                Node<T> replacementNode;
                if (leftNodeCount < rightNodeCount)
                {
                    replacementNode = rightNearNode;
                    rightNearNode.Parent.SetRightChild(replacementNode.RightChild);// replaces replacement node with it's child if any at current position in tree
                    if (replacementNode.RightChild != null) { replacementNode.RightChild.SetParent(replacementNode.Parent); }
                }
                else
                {
                    replacementNode = leftNearNode;
                    leftNearNode.Parent.SetLeftChild(replacementNode.LeftChild);// replaces replacement node with it's child if any at current position in tree
                    if (replacementNode.LeftChild != null) { replacementNode.LeftChild.SetParent(replacementNode.Parent); }
                }
                    //? leftNearNode: rightNearNode;// repaces node with the deepest node that is next to it in value

                
                replacementNode.SetParent(node.Parent);
                replacementNode.SetLeftChild(node.LeftChild);
                replacementNode.SetRightChild(node.RightChild);
                if (node.LeftChild != null) { node.LeftChild.SetParent(replacementNode); }
                if (node.RightChild != null) { node.RightChild.SetParent(replacementNode); }
                if (isRightChild) { node.Parent.SetRightChild(replacementNode); }
                else if (isroot) { tree_Root = replacementNode; }
                else { node.Parent.SetLeftChild(replacementNode); }
                
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
        public override string ToString()
        {
            StringBuilder st = new StringBuilder();
            return tree_Root.BuildValueString(st).ToString();
        }
    }
}