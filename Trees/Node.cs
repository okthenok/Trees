using System;
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
        public int balance
        {
            get
            {
                if (right == null && left == null)
                {
                    return 0;
                }
                else if (right == null)
                {
                    return -left.height;
                }
                else if (left == null)
                {
                    return right.height;
                }

                return right.height - left.height;
            }
        }
        public Node(int Item)
        {
            item = Item;
            ignore = false;
        }
    }
}
