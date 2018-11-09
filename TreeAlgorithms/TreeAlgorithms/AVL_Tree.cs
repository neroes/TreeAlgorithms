using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    class AVL_Tree<T>
    {
        private AVL_Node tree_Root;
        public void Insert(T value)
        {
            GetInsertParent().SetLeftChild(new AVL_Node(value));
            Sort();
        }
        private void Sort()
        {
            throw new NotImplementedException();
            while (tree_Root.GetParent() == null)
            {
                tree_Root = tree_Root.GetParent();// updateing which is root
            }
        }
        private AVL_Node GetInsertParent()// finds the parent to insert under
        {
            AVL_Node node = tree_Root;
            while (node.GetLeftChild() == null)
            {
                node = node.GetLeftChild();// we need to make children and parent same class as the main class
            }
            return node;
        }
        class AVL_Node : Node<T>
        {
            public AVL_Node(T value) : base(value)
            {
            }

            public bool RotateRight()
            {
                // function that rotates the node and its children så that left child becomes the new parent
                if (leftChild == null) { return false; }// we need a left child to become parent, may become exception later
                leftChild.SetParent(parent);
                if (parent == null) { }//update root of AVL_Tree object
                this.SetParent(leftChild);
                this.SetLeftChild(parent.GetRightChild());
                parent.SetRightChild(this);
                return true;
            }
            public bool RotateLeft()
            {
                // function that rotates the node and its children så that right child becomes the new parent
                if (rightChild == null) { return false; }// we need a right child to become parent, may become exception later
                rightChild.SetParent(parent);
                this.SetParent(rightChild);
                this.SetRightChild(parent.GetLeftChild());
                parent.SetLeftChild(this);
                return true;
            }
        }
    }
}
