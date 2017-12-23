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
            :base()
        {
        }
        public override void Insert(Node newNode, Node start, Node parent)
        {
            start.height = start.findHeight();
            base.Insert(newNode, start, parent);
        }
        public override Node Search(int find, Node start)
        {
            start.height = start.findHeight();
            return base.Search(find, start);
        }
        public int Balance(Node unbalanced)
        {
            return unbalanced.right.height - unbalanced.left.height;
        }
        public void Rotation (Node unbalanced)
        {
            //LeftRotation
            if (Balance(unbalanced) > 1)
            {

            }
            //RightRotation
            if (Balance(unbalanced) < -1)
            {

            }
            //DoubleRotation
        }
    }
}
