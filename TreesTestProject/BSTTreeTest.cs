using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trees;

namespace TreesTestProject
{
    [TestClass]
    public class BSTTreeTest
    {
        [TestMethod]
        public void TestAdd3ItemsWorks()
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(3);

            Assert.AreEqual(5, bst.head.item);
            Assert.AreEqual(15, bst.head.right.item);
            Assert.AreEqual(3, bst.head.left.item);
        }



        [TestMethod]
        public void TestRemoveEmptyTree()
        {
            BinarySearchTree bst = new BinarySearchTree();
            try
            {
                bst.Delete(null);
                Assert.Fail("Should not be able to delete a null node");
            }
            catch (NullReferenceException)
            {

            }
        }
    }
}
