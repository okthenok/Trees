using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    //generics plz
    public class RBTree
    {
        public RBNode head = null;
        public RBTree() { }
        public void Insert(int value)
        {
            RBNode node = new RBNode(value);
            head = InsertHelper(node, head);
            head.isRed = false;
        }
        private RBNode InsertHelper(RBNode newNode, RBNode search)
        {
            if (search == null)
            {
                search = newNode;
                return search;
            }

            if (IsRed(search.left) && IsRed(search.right))
            {
                FlipColor(search);
            }

            if (newNode.item > search.item)
            {
                search.right = InsertHelper(newNode, search.right);
            }
            else if (newNode.item < search.item)
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
        public void Remove(int value)
        {
            head = RemoveHelper(value, head);
        }

        /// <summary>
        /// Removes a value from the tree
        /// </summary>
        /// <param name="value">value to be removed</param>
        /// <param name="search"></param>
        /// <returns>the new root of the operation</returns>
        private RBNode RemoveHelper(int value, RBNode search)
        {
            if (value < search.item && search.left != null)
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
                if (value == search.item && search.right == null)
                {
                    return null;
                }
                //if our right node is a 2 node, MoveRedRight
                if (!IsRed(search.right) && !IsRed(search.right.left))
                {
                    search = MoveRedRight(search);
                }
                //if the value is found as an internal node
                if (value == search.item && IsRed(search.left))
                    //copy the candidate value into the current node
                    //recursivly delete the candidate value that was lower in the tree
                {
                    RBNode candidate = search.right;
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
        private RBNode MoveRedLeft(RBNode node)
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
        private RBNode MoveRedRight(RBNode node)
        {
            FlipColor(node);
            if (IsRed(node.left.left))
            {
                node = RightRotation(node);
                FlipColor(node);
            }

            return node;
        }
        private RBNode LeftRotation(RBNode node)
        {
            RBNode temp = node.right;
            node.right = temp.left;
            temp.left = node;
            temp.isRed = node.isRed;
            temp.left.isRed = true;
            return temp;
        }
        private RBNode RightRotation(RBNode node)
        {
            RBNode temp = node.left;
            node.left = temp.right;
            temp.right = node;
            temp.isRed = node.isRed;
            temp.right.isRed = true;
            return temp;
        }
        public void FlipColor(RBNode node)
        {
            node.left.isRed = !node.left.isRed;
            node.isRed = !node.isRed;
            node.right.isRed = !node.right.isRed;
        }
        public bool IsRed(RBNode node)
        {
            if (node == null)
            {
                return false;
            }
            return node.isRed;
        }
        private RBNode FixUp(RBNode node)
        {
            node = LeanLeft(node);
            if (IsRed(node.left) && IsRed(node.right))
            {
                FlipColor(node);
            }
            node = LeanLeft(node.left);

            return node;
        }
        private RBNode LeanLeft(RBNode node)
        {
            if (IsRed(node.right))
            {
                node = LeftRotation(node);
            }
            if (!IsRed(node.left) && !IsRed(node.left.left))
            {
                node = RightRotation(node);
            }

            return node;
        }
    }
}
