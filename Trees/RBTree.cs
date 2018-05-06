using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class RBTree<T> where T : IComparable<T>
    {
        public RBNode<T> head = null;
        public int Count { get; private set; }

        public RBTree() { }
        public void Insert(T value)
        {
            RBNode<T> node = new RBNode<T>(value);
            head = InsertHelper(node, head);
            head.isRed = false;
            Count++;
        }
        private RBNode<T> InsertHelper(RBNode<T> newNode, RBNode<T> search)
        {
            if (search == null)
            {
                return newNode;
            }

            if (newNode.item.CompareTo(search.item) > 0)
            {
                search.right = InsertHelper(newNode, search.right);
            }
            else if (newNode.item.CompareTo(search.item) < 0)
            {
                search.left = InsertHelper(newNode, search.left);
            }
            else
            {
                throw new ArgumentException("Does not accept two of the same value");
            }

            if (IsRed(search.left) && IsRed(search.right))
            {
                FlipColor(search);
            }

            search = LeanLeft(search);

            return search;
        }
        public void Remove(T value)
        {
            head = RemoveHelper(value, head);
            Count--;
        }

        /// <summary>
        /// Removes a value from the tree
        /// </summary>
        /// <param name="value">value to be removed</param>
        /// <param name="search"></param>
        /// <returns>the new root of the operation</returns>
        private RBNode<T> RemoveHelper(T value, RBNode<T> search)
        {
            if (search == null)
            {
                return null;
            }
            if (value.CompareTo(search.item) < 0 && search.left != null) //moving left
            {
                if (!IsRed(search.left) && !IsRed(search.left.left)) //check if left node is 2 node
                {
                    search = MoveRedLeft(search);
                }
                search.left = RemoveHelper(value, search.left);
            }
            else //moving right
            {
                if (IsRed(search.left))
                {
                    search = RightRotation(search);
                }
                //found leaf value
                else if (value.CompareTo(search.item) == 0 && search.right == null)
                {
                    return null;
                }
                //if the value is found as an internal node
                else if (value.CompareTo(search.item) == 0 && (search.left != null || search.right != null))
                //copy the candidate value into the current node
                //recursivly delete the candidate value that was lower in the tree
                {
                    if (!IsRed(search.right) && !IsRed(search.right.left))
                    {
                        search = MoveRedRight(search);
                    }
                    RBNode<T> candidate = search.right;
                    while (candidate.left != null)
                    {
                        candidate = candidate.left; //bug here i think
                    }
                    search.item = candidate.item;
                    search.right = RemoveHelper(candidate.item, search.right);
                }
                //if our right node is a 2 node, MoveRedRight
                else if (!IsRed(search.right) && search.right != null && !IsRed(search.right.left))
                {
                    search = MoveRedRight(search);
                }
                //continue right
                search.right = RemoveHelper(value, search.right);
            }
            //fixup
            return FixUp(search);
        }
        private RBNode<T> MoveRedLeft(RBNode<T> node)
        {
            FlipColor(node);
            if (IsRed(node.right.left))
            {
                node.right = RightRotation(node.right);
                node = LeftRotation(node);
            }
            FlipColor(node);
            if (IsRed(node.right.right))
            {
                node.right = LeftRotation(node.right);
            }

            return node;
        }
        private RBNode<T> MoveRedRight(RBNode<T> node)
        {
            FlipColor(node);
            if (IsRed(node.left.left))
            {
                node = RightRotation(node);
                FlipColor(node);
            }

            return node;
        }
        private RBNode<T> LeftRotation(RBNode<T> node)
        {
            RBNode<T> temp = node.right;
            node.right = temp.left;
            temp.left = node;
            temp.isRed = node.isRed;
            temp.left.isRed = true;
            return temp;
        }
        private RBNode<T> RightRotation(RBNode<T> node)
        {
            RBNode<T> temp = node.left;
            node.left = temp.right;
            temp.right = node;
            temp.isRed = node.isRed;
            temp.right.isRed = true;
            return temp;
        }
        public void FlipColor(RBNode<T> node)
        {
            node.left.isRed = !node.left.isRed;
            node.isRed = !node.isRed;
            node.right.isRed = !node.right.isRed;
        }
        public bool IsRed(RBNode<T> node)
        {
            if (node == null)
            {
                return false;
            }
            return node.isRed;
        }
        private RBNode<T> FixUp(RBNode<T> node)
        {
            node = LeanLeft(node);
            if (IsRed(node.left) && IsRed(node.right))
            {
                FlipColor(node);
            }
            if (node.left != null && !IsRed(node.left.left) && IsRed(node.left.right))
            {
                node = LeanLeft(node.left);
            }

            return node;
        }
        private RBNode<T> LeanLeft(RBNode<T> node)
        {
            if (IsRed(node.right))
            {
                node = LeftRotation(node);
            }
            if (IsRed(node.left) && IsRed(node.left.left))
            {
                node = RightRotation(node);
            }

            return node;
        }

        //BFS (Breadth First Search)
        //For every node
        //if red, you have 2 black children
        //is a valid 2-node, left leaning 3-node, or valid 4-node
        [TestMethod]
        public void NonRecursiveBFS()
        {
            if (Count == 0) return;

            Queue<RBNode<T>> queue = new Queue<RBNode<T>>();
            queue.Enqueue(head);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                Console.WriteLine(node.item);

                if (IsRed(node))
                {
                    Assert.IsTrue(!IsRed(node.left) && !IsRed(node.right));
                }
                else
                {
                    Assert.IsTrue(
                        (!IsRed(node.left) && !IsRed(node.right)) || //2-node
                        (IsRed(node.left) && !IsRed(node.right)) || //3-node
                        (IsRed(node.left) && IsRed(node.right))//4-node 
                        );
                }
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
        }
        public void PreOrder()
        {
            PreOrder(head);
        }

        private void PreOrder(RBNode<T> node)
        {
            Console.WriteLine(node.item);
            if (node.left != null) PreOrder(node.left);
            if (node.right != null) PreOrder(node.right);
        }

        public void InOrder(RBNode<T> node)
        {
            if (node.left != null) InOrder(node.left);
            Console.WriteLine(node.item);
            if (node.right != null) InOrder(node.right);
        }

        public void PostOrder(RBNode<T> node)
        {
            if (node.left != null) PostOrder(node.left);
            if (node.right != null) PostOrder(node.right);
            Console.WriteLine(node.item);
        }

        void NonRecursiveDFS()
        {
            Stack<RBNode<T>> stack = new Stack<RBNode<T>>();
            stack.Push(head);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                Console.WriteLine(node.item);
                if (node.left != null) stack.Push(node.left);
                if (node.right != null) stack.Push(node.right);
            }
        }
    }
}