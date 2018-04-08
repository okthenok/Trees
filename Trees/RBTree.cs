using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    //generics plz
    public class RBTree<T> where T:IComparable<T>
    {
        public RBNode<T> head = null;
        public RBTree () { }
        public void Insert(T value)
        {
            RBNode<T> node = new RBNode<T>(value);
            head = InsertHelper(node, head);
            head.isRed = false;
        }
        private RBNode<T> InsertHelper(RBNode<T> newNode, RBNode<T> search)
        {
            if (search == null)
            {
                return newNode;
            }

            if (IsRed(search.left) && IsRed(search.right))
            {
                FlipColor(search);
            }

            if (newNode.item.CompareTo(search.item) == 1)
            {
                search.right = InsertHelper(newNode, search.right);
            }
            else if (newNode.item.CompareTo(search.item) == -1)
            {
                search.left = InsertHelper(newNode, search.left);
            }
            else
            {
                throw new ArgumentException("Does not accept two of the same value");
            }

            search = LeanLeft(search);
      
            return search;
        }
        public void Remove(T value)
        {
            head = RemoveHelper(value, head);
        }

        /// <summary>
        /// Removes a value from the tree
        /// </summary>
        /// <param name="value">value to be removed</param>
        /// <param name="search"></param>
        /// <returns>the new root of the operation</returns>
        private RBNode<T> RemoveHelper(T value, RBNode<T> search)
        {
            if (value.CompareTo(search.item) == -1 && search.left != null)
            {
                if (!IsRed(search.left) && !IsRed(search.left.left))
                {
                    search = MoveRedLeft(search);
                }
                search.left = RemoveHelper(value, search.left);
            }
            else
            {
                if (IsRed(search.left))
                {
                    search = RightRotation(search);
                }
                //found leaf value
                if (value.CompareTo(search.item) == 0 && search.right == null)
                {
                    return null;
                }
                //if our right node is a 2 node, MoveRedRight
                if (!IsRed(search.right) && !IsRed(search.right.left))
                {
                    search = MoveRedRight(search);
                }
                //if the value is found as an internal node
                if (value.CompareTo(search.item) == 0 && IsRed(search.left))
                    //copy the candidate value into the current node
                    //recursivly delete the candidate value that was lower in the tree
                {
                    RBNode<T> candidate = search.right;
                    while (candidate.left != null)
                    {
                        candidate = candidate.left;
                    }
                    search.item = candidate.item;
                    RemoveHelper(candidate.item, head);
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
            node = LeanLeft(node.left);

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
    }
}
