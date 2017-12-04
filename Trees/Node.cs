using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Node
    {
        public int item { get; }
        public Node parent { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public Node(int Item)
        {
            item = Item;
        }
    }
}
