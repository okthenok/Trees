using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class RBNode
    {
        public RBNode left { get; set; }
        public RBNode right { get; set; }
        public bool isRed { get; set; }
        public int item { get; set; }
        public RBNode (int value)
        {
            item = value;
            isRed = true;
        }
    }
}
