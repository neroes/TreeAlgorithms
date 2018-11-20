using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    interface ITree<T> where T : IComparable, IEquatable<T>
    {
        //Node<T> SearchNode(T Value);
        T Search(T value);
        List<T> Search(T min, T max);
        void Insert(T value);
        void Insert(List<T> values);
        void Delete(T value);
        void Delete(Node<T> node);
        // can be implemented later
        /*ITree<T> Join(ITree<T> otherTree);// joins 2 trees together
        ITree<T> Split(T value);// splits one tree into 2 smaller trees, those higher than value and those lower than value*/
    }
}
