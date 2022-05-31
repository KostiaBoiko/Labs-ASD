using System;
using System.Diagnostics;

namespace Lab_ASD_SortAlgoritms
{
    public class SortAlgoritmsForArray
    {
        //-----------------------------Метод, який переставляє місцями два значення масиву-------------------------
        public static void Swap(int[] items, int left, int right)
        {
            if (left != right)
            {
                int temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        //-----------------------------Бульбашкове сортування------------------------------------------------------
        public static void BubbleSort(int[] array)
        {
            int[] copyofarray = new int[array.Length];
            Array.Copy(array, copyofarray, array.Length);
            var timer = new Stopwatch();
            timer.Start();
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < copyofarray.Length; i++)
                {
                    if (copyofarray[i - 1].CompareTo(copyofarray[i]) > 0)
                    {
                        Swap(copyofarray, i - 1, i);
                        swapped = true;
                    }
                }
            }
            while (swapped != false);
            timer.Stop();
            //ArrayOutput(copyofarray, copyofarray.Length);
            Console.WriteLine("Витрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        //---------------------------------------------------------------------------------------------------

        //-------------------------------Сортування вставкою-------------------------------------------------
        public static void SortByInserts(int[] array)
        {
            int[] CopyOfArray = new int[array.Length];
            Array.Copy(array, CopyOfArray, array.Length);
            var timer = new Stopwatch();
            timer.Start();      //Початок таймера
            int sortedRangeEndIndex = 1;
            while (sortedRangeEndIndex < CopyOfArray.Length)
            {
                if (CopyOfArray[sortedRangeEndIndex].CompareTo(CopyOfArray[sortedRangeEndIndex - 1]) < 0)
                {
                    int insertIndex = FindInsertionIndex(CopyOfArray, CopyOfArray[sortedRangeEndIndex]);
                    Insert(CopyOfArray, insertIndex, sortedRangeEndIndex);
                }

                sortedRangeEndIndex++;
            }
            timer.Stop();       //Кінець таймера
            // ArrayOutput(CopyOfArray, CopyOfArray.Length);
            Console.WriteLine("Витрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }

        static private int FindInsertionIndex(int[] items, int valueToInsert)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].CompareTo(valueToInsert) > 0)
                {
                    return i;
                }
            }
            throw new InvalidOperationException("Індекс не знайдено");
        }

        static private void Insert(int[] itemArray, int indexInsertingAt, int indexInsertingFrom)
        {
            // Зберігаємо значення в додаткову змінну   
            int temp = itemArray[indexInsertingAt];

            // Вставляємо елемент у потрібне місце
            itemArray[indexInsertingAt] = itemArray[indexInsertingFrom];

            // Зсуваємо всі елементи вправо починаючи з наступного індекса після вставленого 
            for (int current = indexInsertingFrom; current > indexInsertingAt; current--)
            {
                itemArray[current] = itemArray[current - 1];
            }

            // Записуємо значення з temp по індексу, наступному після вставленого     
            itemArray[indexInsertingAt + 1] = temp;
        }
        //---------------------------------------------------------------------------------------------------

        //-------------------------------Сортування вибором-------------------------------------------------
        public static void SelectionSort(int[] array)
        {
            int[] CopyOfArray = new int[array.Length];
            Array.Copy(array, CopyOfArray, array.Length);
            var timer = new Stopwatch();
            timer.Start();
            int sortedRangeEnd = 0;
            while (sortedRangeEnd < CopyOfArray.Length)
            {
                int nextIndex = FindIndexOfSmallestFromIndex(CopyOfArray, sortedRangeEnd);
                Swap(CopyOfArray, sortedRangeEnd, nextIndex);
                sortedRangeEnd++;
            }
            timer.Stop();       //Кінець таймера
            //ArrayOutput(CopyOfArray, CopyOfArray.Length);
            Console.WriteLine("Витрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        //-----Метод знаходження мінімального значеня в масиві----------
        static private int FindIndexOfSmallestFromIndex(int[] items, int sortedRangeEnd)
        {
            int currentSmallest = items[sortedRangeEnd];
            int currentSmallestIndex = sortedRangeEnd;
            for (int i = sortedRangeEnd + 1; i < items.Length; i++)
            {
                if (currentSmallest.CompareTo(items[i]) > 0)
                {
                    currentSmallest = items[i];
                    currentSmallestIndex = i;
                }
            }
            return currentSmallestIndex;
        }
        //---------------------------------------------------------------------------------------------------

        //-------------------------------Сортування злиттям-------------------------------------------------
        public static void MergeSort(int[] array)
        {
            int[] CopyOfArray = new int[array.Length];
            Array.Copy(array, CopyOfArray, array.Length);
            var timer = new Stopwatch();
            timer.Start();
            ExecutionOfMergeSort(CopyOfArray);//саме виконання алгоритму
            timer.Stop();       //Кінець таймера
            Program.ArrayOutput(CopyOfArray, CopyOfArray.Length);
            Console.WriteLine("Витрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        private static void ExecutionOfMergeSort(int[] items)
        {
            // Коли масив буде мати 1 елемент, то перериваємо виконання метода 
            if (items.Length <= 1)
            {
                return;
            }
            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;
            int[] left = new int[leftSize];
            int[] right = new int[rightSize];
            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);
            // Рекурсивное ділення масива
            ExecutionOfMergeSort(left);
            ExecutionOfMergeSort(right);
            Merge(items, left, right);
        }
        static private void Merge(int[] items, int[] left, int[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;
            int remaining = left.Length + right.Length; // загальна довжина правої та лівої частини сортованого масива 
            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    items[targetIndex] = right[rightIndex++];
                }
                else if (rightIndex >= right.Length)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else
                {
                    items[targetIndex] = right[rightIndex++];
                }
                targetIndex++;
                remaining--;
            }
        }
    }
}
