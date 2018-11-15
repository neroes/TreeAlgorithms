using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    public class AVL_Tree<T> : BaseTree<T> where T : IComparable, IEquatable<T>
    {
        //private AVL_Node tree_Root;// our tree root
        private BaseTree<T> baseTree;
        private List<AVL_Node> markedForSorting = new List<AVL_Node>();// what nodes have made the tree unsorted
        public AVL_Tree()
        { 
            baseTree = (BaseTree<T>)this;
        }
        public new void Insert(T value)
        {
            InsertSingle(value);
            Sort();
        }
        public new void Insert(List<T> value)
        {
            foreach (T v in value)
            {
                InsertSingle(v);
            }
            Sort();
        }
        private void InsertSingle(T value)
        {
            AVL_Node newNode = new AVL_Node(value);
            baseTree.InsertSingleNode((Node<T>)newNode);
            markedForSorting.Add(newNode);
            /*AVL_Node insertParent = SearchNode(value);// we proberbly need some fix incase there is a matching value in the tree
            
            if (insertParent.CompareTo(value) < 0) { insertParent.SetRightChild(newNode); }
            else { insertParent.SetLeftChild(newNode); }
            markedForSorting.Add(newNode);*/
        }
        private void Sort()
        {
            throw new NotImplementedException();
            /*foreach (AVL_Node node in markedForSorting)
            {
                node.UpdateHeightChain();
            }
            while (tree_Root.Parent == null)
            {
                tree_Root = tree_Root.Parent;// updateing which is root
            }*/
        }
        public new AVL_Node SearchNode(T value)
        {
            return (AVL_Node)baseTree.SearchNode(value);
            /*AVL_Node current_Node = tree_Root;
            if (current_Node == null) { return null; }
            while(!current_Node.value.Equals(value))
            {
                if (current_Node.CompareTo(value) > 0)
                {
                    if (current_Node.RightChild != null) { current_Node = current_Node.RightChild; }
                    else { break; }
                }
                else {
                    if (current_Node.LeftChild != null) { current_Node = current_Node.LeftChild; }
                    else { break; }
                }
            }
            return current_Node;*/
        }
        public new T Search(T value)
        {
            return SearchNode(value).value;
        }
        private new void InsertSingleNode(Node<T> newNode) { }//hides member since it should only be used from baseclass
        public class AVL_Node : Node<T>
        {
            public new AVL_Node Parent { get => (AVL_Node)parent; }
            public new AVL_Node LeftChild { get => (AVL_Node)leftChild; }
            public new AVL_Node RightChild { get => (AVL_Node)rightChild; }
            public int BalancingFactor { get => RightChild.longest_Height - LeftChild.longest_Height; }
            public void SetParent(AVL_Node parent)// maybe remove setparent and incorporate it into setleft and right child
            {
                this.parent = parent;
            }
            public void SetLeftChild(AVL_Node child)
            {
                child.SetParent(this);
                this.leftChild = child;
            }
            public void SetRightChild(AVL_Node child)
            {
                child.SetParent(this);
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
