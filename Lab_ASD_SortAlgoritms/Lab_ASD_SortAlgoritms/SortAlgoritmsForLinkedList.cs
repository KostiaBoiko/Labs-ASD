using System;
using System.Diagnostics;

namespace Lab_ASD_SortAlgoritms
{
    public class SortAlgoritmsForLinkedList
    {

        //-----------------------------Бульбашкове сортування------------------------------------------------------
        public static void BubbleSort(LinkedList NotSortedList)
        {
            LinkedList.CopyTo(NotSortedList, 0, out var SortedList, LinkedList.GetLength(NotSortedList));
            int lagreoflist = LinkedList.GetLength(SortedList);
            var timer = new Stopwatch();
            timer.Start();  //Початок таймера
            LinkedList current = null;
            bool swaped = false;
            do
            {
                current = SortedList;
                swaped = false;
                while (current != null && current.Next != null)
                {
                    if (current.Data > current.Next.Data)
                    {
                        current.Data = current.Data + current.Next.Data;
                        current.Next.Data = current.Data - current.Next.Data;
                        current.Data = current.Data - current.Next.Data;
                        swaped = true;
                    }
                    current = current.Next;
                }
            } while (swaped);
            timer.Stop();   //Кінець таймера
            Console.WriteLine("\nВитрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        //---------------------------------------------------------------------------------------------------

        //-------------------------------Сортування вставкою-------------------------------------------------
        public static void SortByInserts(LinkedList NotSortedList)
        {
            var timer = new Stopwatch();
            timer.Start();      //Початок таймера
            LinkedList.CopyTo(NotSortedList, 0, out var SortedList, LinkedList.GetLength(NotSortedList));
            int j, index = 0;
            while (SortedList != null)
            {
                var key = SortedList;
                j = index;
                while (j > 0 && SortedList.Previous.Data > key.Data)
                {
                    LinkedList.Swap(SortedList.Previous, SortedList);
                    j--;
                }
                SortedList = LinkedList.GetElement(LinkedList.GetFirst(SortedList), j);
                LinkedList.Swap(key, SortedList);
                SortedList = LinkedList.GetElement(LinkedList.GetFirst(SortedList), index);
                index++;
                if (SortedList.Next == null) break;
                SortedList = SortedList.Next;
            }
            timer.Stop();       //Кінець таймера
            Console.WriteLine("\nВитрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        //---------------------------------------------------------------------------------------------------

        //-------------------------------Сортування вибором-------------------------------------------------
        public static void SelectionSort(LinkedList NotSortedList)
        {
            var timer = new Stopwatch();
            timer.Start();  //Початок таймера
            LinkedList.CopyTo(NotSortedList, 0, out var SortedList, LinkedList.GetLength(NotSortedList));
            int indexmin, index = 0;
            while (SortedList.Next != null)
            {
                indexmin = index;
                var Temporary = SortedList.Next;
                while (Temporary != null)
                {
                    var Minimum = LinkedList.GetElement(LinkedList.GetFirst(SortedList), indexmin);
                    if (Temporary.Data < Minimum.Data)
                    {
                        indexmin = Temporary.IndexOf(SortedList, index);
                    }
                    Temporary = Temporary.Next;
                }
                if (index != indexmin)
                {
                    var node1 = LinkedList.GetElement(LinkedList.GetFirst(SortedList), index);
                    var node2 = LinkedList.GetElement(LinkedList.GetFirst(SortedList), indexmin);
                    LinkedList.Swap(node1, node2);
                    SortedList = node2;
                }
                index++;
                SortedList = SortedList.Next;
            }
            timer.Stop();       //Кінець таймера
            Console.WriteLine("\nВитрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        //---------------------------------------------------------------------------------------------------

        //-------------------------------Сортування злиттям--------------------------------------------------
        public static void MergeSort(LinkedList NotSortedList, bool start)
        {
            LinkedList.CopyTo(NotSortedList, 0, out var SortedList, LinkedList.GetLength(NotSortedList));
            var timer = new Stopwatch();
            timer.Start();  //Початок таймера
            SortedList = ExecutionOfMergeSort(SortedList);
            timer.Stop();       //Кінець таймера
            Program.ListOutput(ref SortedList);
            Console.WriteLine("\nВитрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        public static LinkedList ExecutionOfMergeSort(LinkedList List)
        {
            int Length = LinkedList.GetLength(List);
            if (Length <= 1)
            {
                return List;
            }
            int LeftSize = Length / 2;
            int RightSize = Length - LeftSize;
            LinkedList.CopyTo(List, 0, out var Left, LeftSize);
            LinkedList.CopyTo(List, LeftSize, out var Right, RightSize);
            Left = ExecutionOfMergeSort(Left);
            Right = ExecutionOfMergeSort(Right);
            return Merge(Left, Right);
        }

        private static LinkedList Merge(LinkedList left, LinkedList right)
        {
            LinkedList List = null;
            int leftIndex = 0;
            int rightIndex = 0;
            int leftLength = LinkedList.GetLength(left);
            int rightLength = LinkedList.GetLength(right);
            int Size = leftLength + rightLength;
            while (Size > 0)
            {
                if (leftIndex >= leftLength)
                {
                    List = LinkedList.Add(List, right.Data);
                    right = right.Next;
                    rightIndex++;
                }
                else if (rightIndex >= rightLength)
                {
                    List = LinkedList.Add(List, left.Data);
                    left = left.Next;
                    leftIndex++;
                }
                else if (LinkedList.GetElement(LinkedList.GetFirst(left), leftIndex).Data <= LinkedList.GetElement(LinkedList.GetFirst(right), rightIndex).Data)
                {
                    List = LinkedList.Add(List, left.Data);
                    left = left.Next;
                    leftIndex++;
                }
                else
                {
                    List = LinkedList.Add(List, right.Data);
                    right = right.Next;
                    rightIndex++;
                }
                Size--;
            }
            return LinkedList.GetFirst(List);
        }
        //---------------------------------------------------------------------------------------------------
    }
}
