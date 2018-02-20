using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class AVLSearchTree : BinarySearchTree
    {
        public AVLSearchTree()
            : base()
        {
        }
        new public void Insert(int input)
        {
            Node node = new Node(input);
            InsertHelper(node, head, null);
        }
        new public void InsertHelper(Node newNode, Node start, Node parent)
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
                Rotations(newNode);
                return;
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
        public override Node Search(int find, Node start)
        {
            return base.Search(find, start);
        }
        public override void Delete(Node delNode)
        {
            var temp = delNode;
            if (delNode == head)
            {
                temp = head;
            }
            base.Delete(delNode);
            Rotations(temp);
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
        }
        public void Rotations(Node child)
        {
            findHeight(head);
            if (head.balance == 0)
            { }
            var currentNode = child;
            while (!(currentNode.balance > 1 || currentNode.balance < -1) && currentNode != head)
            {
                currentNode = currentNode.parent;
            }
            if (currentNode.right != null && currentNode.right.left != null && (currentNode.balance > 1 || currentNode.balance < -1))
            {
                RightRotation(currentNode.right);
                LeftRotation(currentNode);
            }
            else if (currentNode.left != null && currentNode.left.right != null && (currentNode.balance > 1 || currentNode.balance < -1))
            {
                LeftRotation(currentNode.left);
                RightRotation(currentNode);
            }
            else if (currentNode.left != null && currentNode.left.left != null && (currentNode.balance > 1 || currentNode.balance < -1))
            {
                RightRotation(currentNode);
            }
            else if (currentNode.right != null && currentNode.right.right != null && (currentNode.balance > 1 || currentNode.balance < -1))
            {
                LeftRotation(currentNode);
            }
            findHeight(head);
            if (head.balance == 0)
            { }
        }
        public int findHeight(Node node)
        {
            int leftHeight = 0;
            int rightHeight = 0;
            node.height = 1;
            if (node.left == null && node.right == null)
            {
                return node.height;
            }
            if (node.left != null)
            {
                leftHeight = findHeight(node.left);
            }
            if (node.right != null)
            {
                rightHeight = findHeight(node.right);
            }
            if (node.left == null ^ node.right == null)
            {
                if (node.left != null)
                {
                    node.height = leftHeight + 1;
                }
                else if (node.right != null)
                {
                    node.height = rightHeight + 1;
                }
            }
            else if (leftHeight > rightHeight)
            {
                node.height = leftHeight + 1;
            }
            else if (leftHeight < rightHeight)
            {
                node.height = rightHeight + 1;
            }
            else
            {
                node.height = leftHeight + 1;
            }
            return node.height;
        }
        public override bool IsLeftChild(Node child)
        {
            return base.IsLeftChild(child);
        }
    }
}
