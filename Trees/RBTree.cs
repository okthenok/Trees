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
            InsertHelper(node, head, null);
            head.isRed = false;
        }
        public void InsertHelper(Node newNode, Node start, Node parent)
        {
            if (head == null)
            {
                head = newNode;
                return;
            }
            Node search = start;
            if (search == null)
            {
                search = newNode;
                search.parent = parent;
                if (IsLeftChild(search))
                {
                    search.parent.left = search;
                }
                else
                {
                    search.parent.right = search;
                }
                search.isRed = true;
                LeanLeft(search);
                return;
            }
            if (IsRed(search.left) && IsRed(search.right))
            {
                FlipColor(search);
            }
            if (newNode.item < search.item)
            {
                InsertHelper(newNode, search.left, search);
            }
            else
            {
                InsertHelper(newNode, search.right, search);
            }
        }
        public void LeanLeft(Node node)
        {
            Node search = node;
            while (search != head)
            {
                search = search.parent;
                if (IsRed(search.right))
                {
                    LeftRotation(search);
                }
                if (IsRed(search.left) && IsRed(search.left.left))
                {
                    RightRotation(search);
                }
            }
        }
        public void RightRotation(Node currentNode)
        {
            var temp = currentNode.left;
            if (currentNode == head)
            {
                head = temp;
            }
            else if (currentNode != head)
            {
                if (IsLeftChild(currentNode))
                {
                    currentNode.parent.left = temp;
                }
                else
                {
                    currentNode.parent.right = temp;
                }
            }
            temp.parent = currentNode.parent;
            currentNode.parent = temp;
            currentNode.left = temp.right;
            if (currentNode.left != null)
            {
                currentNode.left.parent = currentNode;
            }
            temp.right = currentNode;
            temp.isRed = currentNode.isRed;
        }
        public void LeftRotation(Node currentNode)
        {
            var temp = currentNode.right;
            if (currentNode == head)
            {
                head = temp;
            }
            else if (currentNode != head)
            {
                if (IsLeftChild(currentNode))
                {
                    currentNode.parent.left = temp;
                }
                else
                {
                    currentNode.parent.right = temp;
                }
            }
            temp.parent = currentNode.parent;
            currentNode.parent = temp;
            currentNode.right = temp.left;
            if (currentNode.right != null)
            {
                currentNode.right.parent = currentNode;
            }
            temp.left = currentNode;
            temp.isRed = currentNode.isRed;
        }
        public void FlipColor(Node node)
        {
            if (IsRed(node))
            {
                node.isRed = false;
                if (node.right != null)
                {
                    node.right.isRed = true;
                }
                if (node.left != null)
                {
                    node.left.isRed = true;
                }
            }
            else
            {
                node.isRed = true;
                if (node.right != null)
                {
                    node.right.isRed = false;
                }
                if (node.left != null)
                {
                    node.left.isRed = false;
                }
            }
        }
        public bool IsLeftChild(Node child)
        {
            if (child.item < child.parent.item)
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
            if (node.isRed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
