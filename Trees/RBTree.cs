using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class RBTree
    {
        public RBNode head = null;
        public RBTree () {}
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
                throw new ArgumentException("Does not accpet two of the same value");
            }
            LeanLeft(search);
            return search;
        }
        private void Remove(int value)
        {
            RBNode search = head;
            while (search.left != null)
            {
                if (!IsRed(search.left) && !IsRed(search.left.left) && search.item != value)
                {
                    MoveRedLeft(search);
                }
                else if (search.item == value || )
            }
        }
        private void MoveRedLeft (RBNode node)
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
        }
        private void MoveRedRight (RBNode node)
        {
            FlipColor(node);
            if (IsRed(node.left.left))
            {
                node = RightRotation(node);
                FlipColor(node);
            }
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
        public RBNode FlipColor(RBNode node)
        {
            node.left.isRed = !node.left.isRed;
            node.isRed = !node.isRed;
            node.right.isRed = !node.right.isRed;
            return node;
        }
        public bool IsRed (RBNode node)
        {
            if (node == null)
            {
                return false;
            }
            return node.isRed;
        }
        private void FixUp (RBNode node)
        {
            LeanLeft(node);
            if (IsRed(node.left) && IsRed(node.right))
            {
                FlipColor(node);
            }
            LeanLeft(node.left);
        }
        private void LeanLeft (RBNode node)
        {
            if (IsRed(node.right))
            {
                node = LeftRotation(node);
            }
            if (!IsRed(node.left) && !IsRed(node.left.left))
            {
                node = RightRotation(node);
            }
        }
    }
}
