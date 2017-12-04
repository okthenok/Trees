using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class BinarySearchTree
    {
        List<int> input = new List<int>();
        Node head = null;
        public BinarySearchTree(List<int> Input)
        {
            input = Input;
        }
        public Node Search(int find, Node start)
        {
            Node search = start;
            if (search == null)
            {
                return null;
            }
            if (find == search.item)
            {
                return search;
            }
            else
            {
                if (find < search.item)
                {
                    Search(find, search.left);
                }
                else
                {
                    Search(find, search.right);
                }
            }
            return null;
        }
        public void Insert(Node newNode, Node start)
        {
            Node search = start;
            if (search == null)
            {
                search = newNode;
            }
            if (newNode.item < search.item)
            {
                Insert(newNode, search.left);
            }
            else
            {
                Insert(newNode, search.right);
            }
        }
        public void Delete(Node delNode)
        {
            Node target = Search(delNode.item, head);
            if (target.left == null && target.right == null)
            {
                if (target.parent.right.item == target.item)
                {
                    target.parent.right = null;
                }
                else if (target.parent.left.item == target.item)
                {
                    target.parent.left = null;
                }
            }
            if (!(target.left == null ^ target.right == null))
            {
                if (target.parent.right.item == target.item)
                {
                    if (target.left == null)
                    {
                        target.parent.right = target.parent.right.right;
                    }
                    if (target.right == null)
                    {
                        target.parent.right = target.parent.right.left;
                    }
                }
                if (target.parent.left.item == target.item)
                {
                    if (target.left == null)
                    {
                        target.parent.left = target.parent.left.right;
                    }
                    if (target.right == null)
                    {
                        target.parent.left = target.parent.left.left;
                    }
                }
            }
            if (target.left != null && target.right != null)
            {

            }
        }
    }
}
