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
        new public void Insert(Node newNode, Node start, Node parent)
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
                Insert(newNode, search.left, search);
            }
            else
            {
                Insert(newNode, search.right, search);
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
        public void RightRotation(Node root)
        {
            var temp = root.left;
            if (root.left.right != null)
            {
                root.left = root.left.right;
            }
            if (root == head)
            {
                head = temp;
            }
            temp.parent = root.parent;
            root.parent = temp;
            root.left = temp.right;
            temp.right = root;
        }
        public void LeftRotation(Node root)
        {
            var temp = root.right;
            if (root.right.left != null)
            {
                root.right = root.right.left;
            }
            if (root == head)
            {
                head = temp;
            }
            temp.parent = root.parent;
            root.parent = temp;
            temp.right = root.right.right;
            root.right = temp.left;
            temp.left = root;
        }
        public void Rotations(Node child)
        {
            findHeight(head);
            if (head.balance == 0) { }
            var root = child;
            while (!(root.balance > 1 || root.balance < -1) && root != head)
            {
                root = root.parent;
            }
            if (root.left != null && root.left.left != null && (root.balance > 1 || root.balance < -1))
            {
                RightRotation(root);
            }
            else if (root.left != null && root.left.right != null && (root.balance > 1 || root.balance < -1))
            {
                LeftRotation(root.left);
                RightRotation(root);
            }
            else if (root.right != null && root.right.right != null && (root.balance > 1 || root.balance < -1))
            {
                LeftRotation(root);
            }
            else if (root.right != null && root.right.left != null && (root.balance > 1 || root.balance < -1))
            {
                RightRotation(root.right);
                LeftRotation(root);
            }
            findHeight(head);
            if (head.balance == 0) { }
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
    }
}
