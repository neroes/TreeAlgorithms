using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms.Tests
{
    [TestClass()]
    public class NodeTests
    {
        [TestMethod()]
        public void SetParentTest()
        {
            Node<int> parent = new Node<int>(4);
            Node<int> child = new Node<int>(8);
            child.SetParent(parent);
            Assert.AreEqual(parent, child.Parent);
        }

        [TestMethod()]
        public void SetLeftChildTest()
        {
            Node<int> parent = new Node<int>(4);
            Node<int> child = new Node<int>(8);
            parent.SetLeftChild(child);
            Assert.AreEqual(child, parent.LeftChild);
        }

        [TestMethod()]
        public void SetRightChildTest()
        {
            Node<int> parent = new Node<int>(4);
            Node<int> child = new Node<int>(8);
            parent.SetRightChild(child);
            Assert.AreEqual(child, parent.RightChild);
        }

        [TestMethod()]
        public void CompareToTest()
        {
            Node<int> n1 = new Node<int>(5);
            Node<int> n2 = new Node<int>(20);
            Assert.AreEqual(-1,n1.CompareTo(n2));
            Assert.AreEqual(1, n2.CompareTo(n1));
        }

        [TestMethod()]
        public void NodeTest()
        {
            Node<float> node = new Node<float>(9999f);
            Assert.AreEqual(9999f, node.value);
        }
    }
}