﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Node
    {
        public int item { get; set; }
        public int height { get; set; }
        public bool ignore { get; set; }
        public Node parent { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public Node(int Item)
        {
            item = Item;
            ignore = false;
            height = findHeight();
        }
        public int findHeight()
        {
            if (this == null)
            {
                return 0;
            }
            if (left == null && right == null)
            {
                return 1;
            }
            else if (left != null || right != null)
            {
                if (left.height > right.height)
                {
                    height = left.height + 1;
                }
                else
                {
                    height = right.height + 1;
                }
            }
            return height;
        }
    }
}
