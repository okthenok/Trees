using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trees;

namespace TreesTestProject
{
    [TestClass]
    public class AVLTreeTest
    {
        [TestMethod]
        public void Insert20AVLTest()
        {
            AVLSearchTree avl = new AVLSearchTree();
            avl.Insert(61);
            avl.Insert(13);
            avl.Insert(1);
            avl.Insert(73);
            avl.Insert(49);
            avl.Insert(72);
            avl.Insert(61);
            avl.Insert(71);
            avl.Insert(51);
            avl.Insert(11);
            avl.Insert(60);
            avl.Insert(79);
            avl.Insert(16);
            avl.Insert(47);
            avl.Insert(75);
            avl.Insert(70);
            avl.Insert(79);
            avl.Insert(29);
            avl.Insert(78);
            avl.Insert(32);

            Assert.AreEqual(61, avl.head.item);
            Assert.AreEqual(72, avl.head.right.item);
            Assert.AreEqual(75, avl.head.right.right.item);
            Assert.AreEqual(79, avl.head.right.right.right.item);
            Assert.AreEqual(79, avl.head.right.right.right.right.item);
            Assert.AreEqual(78, avl.head.right.right.right.left.item);
            Assert.AreEqual(73, avl.head.right.right.left.item);
            Assert.AreEqual(70, avl.head.right.left.item);
            Assert.AreEqual(71, avl.head.right.left.right.item);
            Assert.AreEqual(61, avl.head.right.left.left);
            Assert.AreEqual(13, avl.head.left);
            Assert.AreEqual(1, avl.head.left.left);
            Assert.AreEqual(11, avl.head.left.left.right);
            Assert.AreEqual(47, avl.head.left.right);
            Assert.AreEqual(29, avl.head.left.right.left);
            Assert.AreEqual(16, avl.head.left.right.left.left);
            Assert.AreEqual(32, avl.head.left.right.left.right);
            Assert.AreEqual(51, avl.head.left.right.right);
            Assert.AreEqual(60, avl.head.left.right.right.right);
            Assert.AreEqual(49, avl.head.left.right.right.left);
        }
    }
}
