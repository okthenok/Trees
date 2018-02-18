using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class BinarySearchTree
    {
        public Node head = null;

        public BinarySearchTree()
        {
        }
        public virtual Node Search(int find, Node start)
        {
            Node search = start;
            if (search == null)
            {
                return null;
            }
            if (find == search.item && search.ignore == false)
            {
                return search;
            }
            else
            {
                if (find <= search.item)
                {
                    return Search(find, search.left);
                }
                else
                {
                    return Search(find, search.right);
                }
            }
        }
        public virtual void Insert(int input)
        {
            Node node = new Node(input);
            InsertHelper(node, head, null);
        }
        public virtual void InsertHelper(Node newNode, Node start, Node parent)
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
        public virtual void Delete(Node delNode)
        {
            Node target = Search(delNode.item, head);
            Node find = target;
            if (target.left == null && target.right == null)
            {
                if (!IsLeftChild(target))
                {
                    target.parent.right = null;
                }
                else if (IsLeftChild(target))
                {
                    target.parent.left = null;
                }
            }
            else if (target.left == null ^ target.right == null)
            {
                if (!IsLeftChild(target))
                {
                    if (target.left == null)
                    {
                        target.right.parent = target.parent;
                        target.parent.right = target.parent.right.right;
                    }
                    if (target.right == null)
                    {
                        target.left.parent = target.parent;
                        target.parent.right = target.parent.right.left;
                    }
                }
                if (IsLeftChild(target))
                {
                    if (target.left == null)
                    {
                        target.right.parent = target.parent;
                        target.parent.left = target.parent.left.right;
                    }
                    if (target.right == null)
                    {
                        target.left.parent = target.parent;
                        target.parent.left = target.parent.left.left;
                    }
                }
            }
            else if (target.left != null && target.right != null)
            {
                find = target.left;
                while (find.right != null)
                {
                    find = find.right;
                }
                target.item = find.item;
                target.ignore = true;
                Delete(find);
                target.ignore = false;
            }
        }
        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }
            return false;
        }
        public int Maximum()
        {
            var find = head;
            while(find.right != null)
            {
                find = find.right;
            }
            return find.item;
        }
        public int Minimum()
        {
            var find = head;
            while (find.left != null)
            {
                find = find.left;
            }
            return find.item;
        }
        public virtual bool IsLeftChild(Node child)
        {
            if (child.item <= child.parent.item)
            {
                return true;
            }
            return false;
        }
    }
}
