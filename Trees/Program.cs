﻿using System;
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
            RBTree tree = new RBTree();
            Node node;
            string input;
            int numInput;
            while (true)
            {
                Console.WriteLine("Enter a number into the tree");
                input = Console.ReadLine();
                if (input.Contains("delete"))
                {
                    Console.WriteLine("Delete a number from the tree");
                    tree.Remove(Convert.ToInt32(Console.ReadLine()));
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
                tree.Insert(Convert.ToInt32(input));                
            }
        }
    }
}