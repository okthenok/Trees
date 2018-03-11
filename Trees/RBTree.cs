using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class RBTree
    {
        public Node head = null;
        public RBTree()
        {
        }
        public void Insert(int value)
        {
            Node node = new Node(value);
            head = InsertHelper(node, head, null);
            head.isRed = false;
        }
        private Node InsertHelper(Node newNode, Node start, Node parent)
        {
            if (start == null)
            {
                start = newNode;
                if (head == null)
                {
                    return start;
                }
                start.parent = parent;
                if (IsLeftChild(start))
                {
                    start.parent.left = start;
                }
                else
                {
                    start.parent.right = start;
                }
                return start;
            }

            if (IsRed(start.left) && IsRed(start.right))
            {
                FlipColor(start);
            }

            if (start.item > newNode.item)
            {
                newNode = InsertHelper(newNode, start.right, start);
            }
            else if (start.item < newNode.item)
            {
                newNode = InsertHelper(newNode, start.left, start);
            }
            else
            {
                //figure out what to do when there is a copy
            }

            if (IsRed(start.right) && !IsRed(start.left))
            {
                start = LeftRotation(start);
            }
            if (IsRed(start.left) && IsRed(start.left.left))
            {
                start = RightRotation(start);
            }
            return start;
        }

        private Node LeftRotation(Node node)
        {
            Node temp = node.right;
            node.right = temp.left;
            temp.left = node;
            temp.isRed = node.isRed;
            temp.left.isRed = true;
            return node;
        }
        private Node RightRotation(Node node)
        {
            Node temp = node.left;
            node.left = temp.right;
            temp.right = node;
            temp.isRed = node.isRed;
            temp.right.isRed = true;
            return node;
        }
        public void FlipColor(Node node)
        {
            node.left.isRed = !node.left.isRed;
            node.isRed = !node.isRed;
            node.right.isRed = !node.right.isRed;
        }
        public bool IsLeftChild(Node node)
        {
            if (node.item < node.parent.item)
            {
                return true;
            }
            return false;
        }
        public bool IsRed(Node node)
        {
            if (node == null)
            {
                return false;
            }
            return node.isRed;
        }
    }
}
