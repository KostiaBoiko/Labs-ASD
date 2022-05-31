using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_ASD_SortAlgoritms
{
    public class LinkedList
    {
        public int Data { get; set; }
        public LinkedList Next { get; set; }
        public LinkedList Previous { get; set; }

        public LinkedList()
        {
            Data = 0;
            Next = null;
            Previous = null;
        }

        public LinkedList(int Data, LinkedList Next, LinkedList Previous)
        {
            this.Data = Data;
            this.Next = Next;
            this.Previous = Previous;
        }
        
        public static LinkedList Add(LinkedList List, int Value)
        {
            LinkedList newnode;
            newnode = new LinkedList(Value, null, List);
            if (List != null) List.Next = newnode;
            return newnode;
        }

        public int IndexOf(LinkedList List, int index)
        {
            while (List != null)
            {
                if (List.Data == Data)
                {
                    return index;
                }
                index++;
                List = List.Next;
            }
            return -1;
        }

        public static LinkedList GetFirst(LinkedList List)
        {
            while (List.Previous != null)
            {
                List = List.Previous;
            }
            return List;
        }

        public static void CopyTo(LinkedList sourceList, int start, out LinkedList destinationList, int length)
        {
            destinationList = new LinkedList();
            int index = 0;
            if (length <= LinkedList.GetLength(sourceList))
            {
                sourceList = LinkedList.GetElement(sourceList, start);
                destinationList = new LinkedList(sourceList.Data, null, null);
                sourceList = sourceList.Next;
                while (index < length - 1)
                {
                    var temporary = new LinkedList(sourceList.Data, null, destinationList);
                    destinationList.Next = temporary;
                    destinationList = temporary;
                    sourceList = sourceList.Next;
                    index++;
                }
                destinationList = GetFirst(destinationList);
            }
        }

        public static LinkedList GetElement(LinkedList head, int iterations)
        {
            int index = 0;
            for (index = 0; index < iterations; index++)
            {
                head = head.Next;
            }
            return head;
        }

        public static int GetLength(LinkedList head)
        {
            int Count = 0;
            while (head != null)
            {
                Count++;
                head = head.Next;
            }
            return Count;
        }

        public static void Swap(LinkedList node1, LinkedList node2)
        {
            var tempNext = node1.Next;
            var tempPrev = node1.Previous;
            node1.Next = node2.Next;
            if (node2.Next != null) node2.Next.Previous = node1;
            if (tempNext != node2)
            {
                node2.Next = tempNext;
                if (tempNext != null) tempNext.Previous = node2;
            }
            else
            {
                node2.Next = node1;
            }
            if (node2.Previous != node1)
            {
                node1.Previous = node2.Previous;
                if (node2.Previous != null) node2.Previous.Next = node1;
            }
            else
            {
                node1.Previous = node2;
            }
            node2.Previous = tempPrev;
            if (tempPrev != null) tempPrev.Next = node2;
        }
    }
}