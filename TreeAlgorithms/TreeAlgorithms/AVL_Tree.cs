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
        public void Insert(List<T> value)
        {
            AVL_Node current_lowest = GetInsertParent();
            foreach (T v in value)
            {
                current_lowest.SetLeftChild(new AVL_Node(v));
                current_lowest = current_lowest.LeftChild;
            }
            current_lowest.UpdateHeightChain();
            Sort();
        }
        private AVL_Node GetInsertParent()// returns the node to insert under
        {
            AVL_Node parentnode = tree_Root;
            while (parentnode.LeftChild == null)
            {
                parentnode = parentnode.LeftChild;// we need to make children and parent same class as the main class
            }
            return parentnode;
        }
        private void Sort()
        {
            throw new NotImplementedException();
            while (tree_Root.Parent == null)
            {
                tree_Root = tree_Root.Parent;// updateing which is root
            }
        }
        class AVL_Node : Node<T>
        {
            public new AVL_Node Parent { get => (AVL_Node)parent; }
            public new AVL_Node LeftChild { get => (AVL_Node)leftChild; }
            public new AVL_Node RightChild { get => (AVL_Node)rightChild; }
            public void SetParent(AVL_Node parent)
            {
                this.parent = parent;
            }
            public void SetLeftChild(AVL_Node child)
            {
                this.leftChild = child;
            }
            public void SetRightChild(AVL_Node child)
            {
                this.rightChild = child;
            }
            
            private int longest_Height = 0;
            public AVL_Node(T value) : base(value)
            {
            }
            public void UpdateHeightChain()
            {
                if (UpdateHeight()){ Parent.UpdateHeightChain(); }// only update parent if child changes
            }
            public bool UpdateHeight()
            {
                int old_hight = longest_Height;// save for later comparison
                int lefthight = 0;
                int righthight = 0;
                if (LeftChild != null) { lefthight = LeftChild.GetLongestHeight(); }
                if (rightChild != null) { righthight = RightChild.GetLongestHeight(); }
                longest_Height = lefthight > righthight ? lefthight : righthight;
                if (longest_Height != old_hight) { return true; }// returns true if we update height
                return false;// so we can just keep updating parents until we get false
            }
            public int GetLongestHeight() { return longest_Height; }
            public bool RotateRight()
            {
                // function that rotates the node and its children så that left child becomes the new parent
                if (LeftChild == null) { return false; }// we need a left child to become parent, may become exception later
                LeftChild.SetParent(Parent);
                if (Parent == null) { }//update root of AVL_Tree object
                this.SetParent(LeftChild);
                this.SetLeftChild(Parent.RightChild);
                parent.SetRightChild(this);
                return true;
            }
            public bool RotateLeft()
            {
                // function that rotates the node and its children så that right child becomes the new parent
                if (rightChild == null) { return false; }// we need a right child to become parent, may become exception later
                rightChild.SetParent(parent);
                this.SetParent(rightChild);
                this.SetRightChild(parent.LeftChild);
                parent.SetLeftChild(this);
                return true;
            }
        }
    }
}
