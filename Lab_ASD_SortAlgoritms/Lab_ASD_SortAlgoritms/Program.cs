using System;
using System.Diagnostics;

namespace Lab_ASD_SortAlgoritms
{
    class Program
    {
        public static void ArrayOutput(int[] array, int size)
        {
            Console.WriteLine("\nВивід масиву:");
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public static void ListOutput(ref LinkedList List)
        {
            Console.WriteLine("\nВивід списка:");
            LinkedList element = List;
            while (element != null)
            {
                Console.Write(element.Data + " ");
                element = element.Next;
            }
        }

        static void NumberGenerator(ref int[] array, int numberofelements, int rangeofvalues)
        {
            Random aRand = new Random();
            for (int i = 0; i < numberofelements; i++)
                array[i] = aRand.Next(rangeofvalues);
        }

        public static LinkedList GenerateList(int large, int rangeofvalues)
        {
            int[] Array = new int[large];
            NumberGenerator(ref Array, Array.Length, rangeofvalues);
            int index = Array.Length - 1;
            var List = new LinkedList(Array[index], null, null);
            while (index > 0)
            {
                index--;
                var temp = new LinkedList(Array[index], List, null);
                List.Previous = temp;
                List = temp;
            }
            return List;
        }

        static void ArraySortAlgoritms()
        {
            Console.WriteLine("\n\tМасив");
            Console.WriteLine("Введіть розмір масиву");
            int ArraySize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть діапазон значень елементів");
            int RangeOfValues = Convert.ToInt32(Console.ReadLine());
            int[] MyArray = new int[ArraySize];
            NumberGenerator(ref MyArray, ArraySize, RangeOfValues);
            Menu();
            void Menu()
            {
                Console.WriteLine("\n\tВиберіть алгоритм сортування, який будемо викорстовувати");
                Console.WriteLine("1. Бульбашкове сортування");
                Console.WriteLine("2. Сортування вставкою");
                Console.WriteLine("3. Сортування вибором");
                Console.WriteLine("4. Сортування злиттям");
                Console.WriteLine("9. Вивід масиву на екран");
                Console.WriteLine("0. Вихід в головне меню");
                int choosenoperation = Convert.ToInt32(Console.ReadLine());
                switch (choosenoperation)
                {
                    case 1: SortAlgoritmsForArray.BubbleSort(MyArray); Menu(); break;
                    case 2: SortAlgoritmsForArray.SortByInserts(MyArray); Menu(); break;
                    case 3: SortAlgoritmsForArray.SelectionSort(MyArray); Menu(); break;
                    case 4: SortAlgoritmsForArray.MergeSort(MyArray); Menu(); break;
                    case 9: ArrayOutput(MyArray, ArraySize); Menu(); break;
                    case 0: break;
                    default: Menu(); break;
                }
            }
        }

        static void LinkedListSortAlgoritms()
        {
            Console.WriteLine("\n\tЛінійний звʼязний список");
            Console.WriteLine("Введіть кількість елементів списку");
            int ListSize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть діапазон значень елементів");
            int RangeOfValues = Convert.ToInt32(Console.ReadLine());
            LinkedList MyList = GenerateList(ListSize, RangeOfValues);
            Menu();
            void Menu()
            {
                Console.WriteLine("\n\n\tВиберіть алгоритм сортування, який будемо викорстовувати");
                Console.WriteLine("1. Бульбашкове сортування");
                Console.WriteLine("2. Сортування вставкою");
                Console.WriteLine("3. Сортування вибором");
                Console.WriteLine("4. Сортування злиттям");
                Console.WriteLine("9. Вивід списка на екран");
                Console.WriteLine("0. Вихід в головне меню");
                int choosenoperation = Convert.ToInt32(Console.ReadLine());
                switch (choosenoperation)
                {
                    case 1: SortAlgoritmsForLinkedList.BubbleSort(MyList); Menu(); break;
                    case 2: SortAlgoritmsForLinkedList.SortByInserts(MyList); Menu(); break;
                    case 3: SortAlgoritmsForLinkedList.SelectionSort(MyList); Menu(); break;
                    case 4: SortAlgoritmsForLinkedList.MergeSort(MyList, true); Menu(); break;
                    case 9: ListOutput(ref MyList); Menu(); break;
                    case 0: break;
                    default: Menu(); break;
                }
            }
        }


        static void Main()
        {
            Console.WriteLine("Бойко Костянтин Богданович ІПЗ-14 \n\tДодаткова лабораторна робота. Сортування");
            Console.WriteLine("\n\tВиберіть структуру даних, з якою будемо працювати");
            Console.WriteLine("1. Масив");
            Console.WriteLine("2. Лінійний звʼязний список");
            Console.WriteLine("0. Вихід з програми");
            int choosenoperation = Convert.ToInt32(Console.ReadLine());
            switch (choosenoperation)
            {
                case 1: ArraySortAlgoritms(); Main(); break;
                case 2: LinkedListSortAlgoritms(); Main(); break;
                case 0: break;
                default: Main(); break;
            }
        }
    }
        
}

