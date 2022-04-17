# Lab1 ASD Boiko K B
/
/
/
using System;
using System.Diagnostics;

namespace Lab1asd
{
    //--------------------Клас для лінійних звʼязних списків--------------------
    public class Item
    {
        public Item(int dt)
        {
            data = dt;
            next = null;
        }
        public int data;
        public Item next;
    }
     
    public class Program
    {
        //---------------------Масиви-------------------
        static void Arrays()
        {
            Console.Clear();
            Console.WriteLine("\nМасив");
            Console.WriteLine("Введіть розмір масиву");
            int arrsize = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть діапазон значень елементів");
            int rangeofvalues = int.Parse(Console.ReadLine());
            int[] myarray = new int[arrsize+1];
            //----------Генерація масиву----------
            Random aRand = new Random();
            for (int i = 0; i < arrsize; i++)
                myarray[i] = aRand.Next(rangeofvalues);
            //------------------------------------
            Console.WriteLine("Згенерували масив");
            Arrayoutput(myarray, arrsize);
            menu();
            //--------------------Меню для масивів--------------------
            void menu()
            {
                Console.WriteLine("\n\nОберіть дію");
                Console.WriteLine("0. Вивід масиву");
                Console.WriteLine("1. Пошук перебором");
                Console.WriteLine("2. Пошук з барʼєром");
                Console.WriteLine("3. Бінарний пошук");
                Console.WriteLine("4. Бінарний пошук за правилом золотого перерізу");
                Console.WriteLine("Для виходу в меню - виберіть будь-яку іншу цифру");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 0: Arrayoutput(myarray, arrsize); menu(); break;
                    case 1: Linearsearch(myarray, arrsize); menu(); break;
                    case 2: Searchwithbarrier(myarray, arrsize); menu(); break;
                    case 3: Binarysearch(myarray, arrsize); menu(); break;
                    case 4: Binarysearchbygoldensection(myarray, arrsize); menu(); break;
                    default: Main(); break;
                }
            }
        }
        //---------------Вивід масиву на екран---------------
        static void Arrayoutput(int[] array, int size)
        {
            Console.WriteLine("\nВивід масиву:");
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        //--------------------Пошук перебором--------------------
        static void Linearsearch(int[] array, int size)
        {
            Console.WriteLine("Пошук перебором");
            Console.WriteLine("Введіть шуканий елемент");
            int value = int.Parse(Console.ReadLine());
            var timer = new Stopwatch();
            int j = 0, index = 0;
            bool found = false;
            timer.Start();
            while ((j < size) && (found == false))
            {
                if (array[j] == value)
                {
                    index = j;
                    found = true;
                }
                j++;
            }
            timer.Stop();
            if (found == true)
                Console.WriteLine("Елемент знайдено з індексом " + index);
            else if (j == size)
                Console.WriteLine("Цього елементу немає у масиві");
            Console.WriteLine("Витрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        //--------------------Пошук із барʼєром--------------------
        static void Searchwithbarrier(int[] array, int size)
        {
            Console.WriteLine("\nПошук з барʼєром");
            Console.WriteLine("Введіть шуканий елемент");
            int value = int.Parse(Console.ReadLine());
            int j = 0;
            array[size] = value;
            var timer = new Stopwatch();
            timer.Start();
            while (array[j] != value)
                j++;
            timer.Stop();
            if (j < size) Console.WriteLine("Елемент знайдено з індексом " + j);
            else Console.WriteLine("Цього елементу немає у масиві");
            Console.WriteLine("Витрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        //--------------------Бінарний пошук (стандартни1)---------------------
        static void Binarysearch(int[] array, int size)
        {
            Console.WriteLine("\nБінарний пошук");
            Array.Sort(array);
            Console.WriteLine("Відсортований масив\n");
            Arrayoutput(array, size);
            Console.WriteLine("\nВведіть шуканий елемент");
            int value = int.Parse(Console.ReadLine());
            int index = 0;
            int left = 0;
            int right = size;
            bool found = false;
            var timer = new Stopwatch();
            timer.Start();
            while ((left <= right) && (found == false))
            {
                int middle = (left + right) / 2;
                if (array[middle] == value)
                {
                    found = true;
                    index = middle;
                }
                else if (array[middle] < value)
                    left = middle + 1;
                else right = middle - 1;
            }
            timer.Stop();
            if (found == true)
                Console.WriteLine("Елемент знайдено з індексом " + index);
            else if (found == false)
                Console.WriteLine("Цього елементу немає у масиві");
            Console.WriteLine("Витрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        //----------Бінарний пошук (за правилом золотого перерізу)----------
        static void Binarysearchbygoldensection(int[] array, int size)
        {
            Console.WriteLine("\nБінарний пошук за золотим перерізом");
            Array.Sort(array);
            Console.WriteLine("Відсортований масив\n");
            Arrayoutput(array,size);
            Console.WriteLine("\nВведіть шуканий елемент");
            int value = int.Parse(Console.ReadLine());
            int index = 0;
            int left = 0;
            int right = size;
            bool found = false;
            var timer = new Stopwatch();
            timer.Start();
            while ((left <= right) && (found == false))
            {
                int m = (int)(left + 0.618 * (right - left));
                if (array[m] == value)
                {
                    found = true;
                    index = m;
                }
                else if (array[m] < value)
                    left = m + 1;
                else right = m - 1;
            }
            timer.Stop();
            if (found == true)
                Console.WriteLine("Елемент знайдено з індексом " + index);
            else if (found == false)
                Console.WriteLine("Цього елементу немає у масиві");
            Console.WriteLine("Витрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }

        //--------------------Лінійні звʼязні списки------------------------
        static void Linked_list()
        {
            int largeoflist;
            int rangeofvalues;
            Item head;
            Console.Clear();
            Console.WriteLine("\nЛінійний звʼязний список");
            Console.WriteLine("\nІніціалізація списку");
            Console.WriteLine("Введіть кількість елементів списку");
            largeoflist = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть діапазон значень елементів");
            rangeofvalues = Convert.ToInt32(Console.ReadLine());
            head = null;
            NumberGenerator(ref head, ref largeoflist, ref rangeofvalues);
            Console.WriteLine("\nУтворений список:");
            Listoutput(head);
            menu();
            //--------------------Меню для лініних звʼязних списків--------------------
            void menu()
            {
                Console.WriteLine("\n\nОберіть дію");
                Console.WriteLine("0. Вивід списка");
                Console.WriteLine("1. Пошук перебором");
                Console.WriteLine("2. Пошук з барʼєром");
                Console.WriteLine("3. Бінарний пошук");
                Console.WriteLine("4. Бінарний пошук за правилом золотого перерізу");
                Console.WriteLine("Для виходу в меню - виберіть будь-яку іншу цифру");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 0: Listoutput(head); menu(); break;
                    case 1: Roughsearch(head, largeoflist); menu(); break;
                    case 2: Searchwithbarrier(head); menu(); break;
                    case 3: sortList(head); StandartBinarySearch(head); menu(); break;
                    case 4: sortList(head); BinarySearchbygoldensection(head); menu(); break;
                    default: Main(); break;
                }
            }
        }
        //--------------зворотне створення списка---------------
        static Item push(Item head, int data)
        {
            Item newItem = new Item(data);
            newItem.next = head;
            head = newItem;
            return head;
        }
        //---------------генерація чисел в списку---------------
        static void NumberGenerator(ref Item head, ref int large, ref int range)
        {
            Random aRand = new Random();
            for (int i = 0; i < large; i++)
                head = push(head, (aRand.Next(range)));
        }
        //---------------вивід списка на екран---------------
        static void Listoutput(Item head)
        {
            Console.WriteLine("\nЗгенерований список: ");
            Item element = head;
            while (element != null)
            {
                Console.Write(" " + element.data);
                element = element.next;
            }
        }
        //--------------------Пошук перебором--------------------
        static void Roughsearch(Item head, int size)
        {
            Console.WriteLine("\nПошук перебором\n");
            Console.WriteLine("Введіть шуканий елемент");
            int x = Convert.ToInt32(Console.ReadLine());
            Item current = head;
            bool found = false;
            int i = 0;
            var timer = new Stopwatch();
            timer.Start();
            while ((i <= size) && (found == false))
            {
                if (current.data == x)
                {
                    found = true;
                }
                else
                    current = current.next;
            }
            timer.Stop();
            if (found)
                Console.WriteLine("\nЕлемент знайдено");
            else
                Console.WriteLine("\nЕлемент не знайдено");
            Console.WriteLine("Витрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        //--------------------Пошук з барʼєром--------------------
        static void Searchwithbarrier(Item head)
        {
            Console.WriteLine("\nПошук з барєром\n");
            Console.WriteLine("Введіть шуканий елемент");
            int x = Convert.ToInt32(Console.ReadLine());
            Item current = head;
            var timer = new Stopwatch();
            timer.Start();
            while (current.data != x)
                current = current.next;
            timer.Stop();
            if (current.data == x)
                Console.WriteLine("\nЕлемент знайдено");
            else
                Console.WriteLine("\nЕлемент не знайдено");
            Console.WriteLine("Витрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }

        //----------сортування включеням(порівняння поточного елемента з наступним)----------
        static void sortList(Item head)
        {
            Item current = head, index = null;
            int temp;

            if (head == null)
            {
                return;
            }
            else
            {
                while (current != null)
                {
                    index = current.next;
                    while (index != null)
                    {
                        if (current.data.CompareTo(index.data) > 0)
                        {
                            temp = current.data;
                            current.data = index.data;
                            index.data = temp;
                        }
                        index = index.next;
                    }
                    current = current.next;
                }
            }
        }

        //----------стандартний пошук середнього елементу----------
        static Item StandartMiddleItem(Item start, Item last)
        {
            if (start == null)
                return null;
            Item slow = start;
            Item fast = start.next;
            while (fast != last)
            {
                fast = fast.next;
                if (fast != last)
                {
                    slow = slow.next;
                    fast = fast.next;
                }
            }
            return slow;
        }
        //--------------------Бінарний пошук(стандартний)--------------------
        public static void StandartBinarySearch(Item head)
        {
            Console.WriteLine("\nБінарний пошук");
            Console.WriteLine("Введіть шуканий елемент");
            int value = Convert.ToInt32(Console.ReadLine());
            Item start = head;
            Item last = null;
            bool searchedvalue = false;
            var timer = new Stopwatch();
            timer.Start();
            do
            {
                Item mid = StandartMiddleItem(start, last);
                if (mid.data == value)
                {
                    searchedvalue = true;
                    break;
                }
                else if (mid.data < value)
                {
                    start = mid.next;
                }
                else
                    last = mid;
            } while (last == null || last != start);
            timer.Stop();

            if (searchedvalue)
                Console.WriteLine("\nЕлемент знайдено");
            else
                Console.WriteLine("\nЕлемент не знайдено");
            Console.WriteLine("Витрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        //----------пошук середнього елементу за золотим перерізом----------
        static Item Middlenodebygoldensection(Item start, Item last)
        {
            if (start == null)
                return null;
            Item slow = start;
            Item fast = start.next;
            while (fast != last)
            {
                fast = fast.next;
                if (fast != last)
                {
                    fast = fast.next;
                    if (fast != last)
                    {
                        fast = fast.next;
                        if (fast != last)
                        {
                            fast = fast.next;
                            if (fast != last)
                            {
                                fast = fast.next;
                                if (fast != last)
                                {
                                    fast = fast.next;
                                    if (fast != last)
                                    {
                                        slow = slow.next;
                                        fast = fast.next;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return slow;
        }
        //--------------------Бінарний пошук(за правилом золотого перерізу)--------------------
        public static void BinarySearchbygoldensection(Item head)
        {
            Console.WriteLine("\nБінарний пошук за золотим перерізом");
            Console.WriteLine("Введіть шуканий елемент");
            int value = Convert.ToInt32(Console.ReadLine());
            Item start = head;
            Item last = null;
            bool searchedvalue = false;
            var timer = new Stopwatch();
            timer.Start();
            do
            {
                Item mid = Middlenodebygoldensection(start, last);
                if (mid.data == value)
                {
                    searchedvalue = true;
                    break;
                }
                else if (mid.data < value)
                {
                    start = mid.next;
                }
                else
                    last = mid;
            } while (last == null || last != start);
            timer.Stop();

            if (searchedvalue)
                Console.WriteLine("\nЕлемент знайдено");
            else
                Console.WriteLine("\nЕлемент не знайдено");
            Console.WriteLine("Витрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        static void Main()
        {
            Console.WriteLine("\nБойко Костянтин Богданович \n");
            Console.WriteLine("\nЛабораторна робота 1");
            Console.WriteLine("\nОберіть тип даних, з яким будемо працювати:");
            Console.WriteLine("1. Масив");
            Console.WriteLine("2. Лінійний звʼзний список");
            int key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1: Arrays(); Main(); break;
                case 2: Linked_list(); Main(); break;
                default: break;
            }
        }
    }
}
