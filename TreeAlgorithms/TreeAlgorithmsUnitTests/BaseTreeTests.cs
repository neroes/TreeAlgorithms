﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms.Tests
{
    [TestClass()]
    public class BaseTreeTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            BaseTree<int> baseTree = new BaseTree<int>();
            baseTree.Insert(50);
            baseTree.Insert(44);
            baseTree.Insert(45);
            baseTree.Insert(51);
            int result = baseTree.Search(48);
            int expected = 45;
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void InsertListTest()
        {
            BaseTree<float> baseTree = new BaseTree<float>();
            baseTree.Insert(new List<float>() { 4f, 3f, 10f, 20f, 50f });
            float result = baseTree.Search(48f);
            float expected = 50f;
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void SearchTest()
        {
            throw new NotImplementedException();
        }
        [TestMethod()]
        public void ContainsTest()
        {
            BaseTree<float> baseTree = new BaseTree<float>();
            baseTree.Insert(new List<float>() { 4f, 3f, 10f, 20f, 50f });
            bool result = baseTree.Contains(48f);
            bool expected = false;
            Assert.AreEqual(expected, result);
            result = baseTree.Contains(50f);
            expected = true;
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void DeleteTest()
        {
            BaseTree<float> baseTree = new BaseTree<float>();
            baseTree.Insert(new List<float>() { 4f, 3f, 10f, 20f, 50f });
            Assert.AreEqual(true,baseTree.Contains(10f));
            baseTree.Delete(10f);
            Assert.AreEqual(false, baseTree.Contains(10f));
            Assert.AreEqual(true, baseTree.Contains(4f));
            baseTree.Delete(4f);
            Assert.AreEqual(false, baseTree.Contains(4f));
            Assert.AreEqual(true, baseTree.Contains(50f));
            baseTree.Delete(50f);
            Assert.AreEqual(false, baseTree.Contains(50f));
        }
        [TestMethod()]
        public void ToStringTest()
        {
            BaseTree<float> baseTree = new BaseTree<float>();
            baseTree.Insert(new List<float>() { 4f, 3f, 10f, 20f, 50f });
            string result = baseTree.ToString();
            Assert.AreEqual(" 3 4 10 20 50", baseTree.ToString());
        }

        [TestMethod()]
        public void StabilityTest()// is proberbly a good idea to perform some sort of test checking that the tree still remains sorted even if unbalanced by deletion and random inserts
        {

        }
    }
}