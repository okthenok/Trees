using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class RBNode<T>
    {
        public RBNode<T> left { get; set; }
        public RBNode<T> right { get; set; }
        public bool isRed { get; set; }
        public T item { get; set; }
        public RBNode (T value)
        {
            item = value;
            isRed = true;
        }
    }
}
