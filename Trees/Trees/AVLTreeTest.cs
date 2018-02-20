using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trees;

namespace TreesTestProject
{
    [TestClass]
    public class AVLTreeTest
    {
        [TestMethod]
        public void Insert10Test()
        {
            AVLSearchTree avl = new AVLSearchTree();
            avl.Insert(94);
            avl.Insert(81);
            avl.Insert(24);
            avl.Insert(22);
            avl.Insert(51);
            avl.Insert(42);
            avl.Insert(95);
            avl.Insert(75);
            avl.Insert(32);
            avl.Insert(6);

            Assert.AreEqual(51, avl.head.item);
            Assert.AreEqual(94, avl.head.right.item);
            Assert.AreEqual(95, avl.head.right.right.item);
            Assert.AreEqual(81, avl.head.right.left.item);
            Assert.AreEqual(75, avl.head.right.left.left.item);
            Assert.AreEqual(24, avl.head.left.item);
            Assert.AreEqual(42, avl.head.left.right.item);
            Assert.AreEqual(32, avl.head.left.right.left.item);
            Assert.AreEqual(22, avl.head.left.left.item);
            Assert.AreEqual(6, avl.head.left.left.left.item);
        }
    }
}
