using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class HeapTree <T> where T : IComparable<T>
    {
        public HeapTree() { }
        public int[] heap = new int[50]; //make it base size 50, and when it runs out of size, add another 50
        int count = 0;
        public void Insert(int value)
        {
            if (count % 50 == 0)
            {
                var temp = new int[count + 50];
                for (int i = 0; i < heap.Length; i++)
                {
                    temp[i] = heap[i];
                }
                heap = temp;
            }
            heap[heap.Length - 1] = value;
            HeapifyUp(heap.Length - 1);

            count++;
        }
        public void HeapifyUp(int value)
        {
            if (value == 0)
            {
                return;
            }
            if (heap[value] < heap[(value - 1) / 2])
            {
                var temp = heap[value];
                heap[value] = heap[(value - 1) / 2];
                heap[(value - 1) / 2] = temp;
                HeapifyUp((value - 1) / 2);
            }
        }
        public int Pop()
        {
            heap[0] = heap[heap.Length - 1];
            HeapifyDown(0);
            count--;
            return 0;
        }
        public void HeapifyDown(int value)
        {
            if (value > heap.Length || heap[value] > heap[value * 2 + 1] || heap[value] > heap[value * 2 + 2])
            {
                return;
            }
            var temp = heap[value];
            if (heap[value] < heap[value * 2 + 1])
            {
                heap[value] = heap[value * 2 + 1];
                heap[value * 2 + 1] = temp;
                HeapifyDown(value * 2 + 1);
            }
            else if (heap[value] < heap[value * 2 + 2])
            {
                heap[value] = heap[value * 2 + 2];
                heap[value * 2 + 2] = temp;
                HeapifyDown(value * 2 + 2);
            }
        }
        public void DFSCheck(int value)
        {
            if (value * 2 + 1 > count)
            {
                return;
            }
            if (heap[value] > heap[value * 2 + 2] || heap[value] > heap[value * 2 + 1])
            {
                throw new SystemException("there is a big dumb");
            }
            if (value * 2 + 2 < heap.Length) DFSCheck(value * 2 + 2);
            if (value * 2 + 1 < heap.Length) DFSCheck(value * 2 + 1);
        }
    }
}
//i	    left	right	parent
//0	    1	    2	    -
//1	    3	    4	    0
//2	    5	    6	    0
//3	    7	    8	    1
//4	    9	    10	    1
//5	    11	    12	    2
//...

//3/2 = 1

//left = 1+2i
//right = 2i + 2
//parent = (i-1)/2
