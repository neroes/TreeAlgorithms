using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    class RedBlack_Tree<T> : ITree<T> where T : IComparable
    {
        public void Insert(T value)
        {
            throw new NotImplementedException();
        }

        public void Insert(List<T> values)
        {
            throw new NotImplementedException();
        }

        public T Search(T value)
        {
            throw new NotImplementedException();
        }

        class RedBlack_Node : Node<T>
        {
            public RedBlack_Node(T value) : base(value)
            {
            }
        }
    }
}
