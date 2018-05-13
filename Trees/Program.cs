using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            HeapTree<int> tree = new HeapTree<int>();

            for (int i = 10; i > 0; i--)
            {
                tree.Insert(i);
            }

            //tree.NonRecursiveBFS();
            
            Node node;
            string input;
            string numInput;
            while (true)
            {
                Console.WriteLine("Enter a number into the tree");
                input = Console.ReadLine();
                if (Convert.ToString(input).Contains("delete"))
                {
                    tree.Pop();
                    //Console.WriteLine("Delete a number from the tree");
                    //tree.Remove(int.Parse(Console.ReadLine()));
                    //tree.NonRecursiveBFS();
                    continue;
                }
                //if (input.Contains("search"))
                //{
                //    Console.WriteLine("Search for a number in the tree");
                //    numInput = Convert.ToInt32(Console.ReadLine());
                //    tree.Search(numInput, tree.head);
                //    continue;
                //}
                //if (input.Contains("isempty"))
                //{
                //    Console.WriteLine(tree.IsEmpty());
                //    continue;
                //}
                tree.Insert(int.Parse(input));
                tree.DFSCheck(tree.heap[0]);
                //tree.NonRecursiveBFS();
            }
        }
    }
}