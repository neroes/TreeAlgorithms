using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    class RedBlack_Tree<T> : BaseTree<T> where T : IComparable, IEquatable<T>
    {
        public new void Insert(T value)
        {
            throw new NotImplementedException();
        }

        public new void Insert(List<T> values)
        {
            throw new NotImplementedException();
        }

        public new void Delete(T value)
        {
            throw new NotImplementedException();
        }
        public new void Delete(Node<T> node)
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
