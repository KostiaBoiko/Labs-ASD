# Lab1 ASD Boiko K B







using System;
using System.Diagnostics;

namespace Lab1asd
{
class Program
    {
        static void Arrays()
        {
            Console.Clear();
            Console.WriteLine("\nМасив");
            Console.WriteLine("Введіть розмір масиву");
            int arrsize = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть діапазон значень елементів");
            int rangeofvalues = int.Parse(Console.ReadLine());
            int[] myarray = new int[arrsize+1];
            //генерація масиву
            Random aRand = new Random();
            for (int i = 0; i < arrsize; i++)
                myarray[i] = aRand.Next(rangeofvalues);
            Console.WriteLine("Згенерували масив");
            Arrayoutput(myarray, arrsize);
            menu();

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

        static void Arrayoutput(int[] array, int size)
        {
            Console.WriteLine("\nВивід масиву:");
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void Linearsearch(int[] array, int size)
        {
            Console.WriteLine("Пошук перебором");
            Console.WriteLine("Введіть шуканий елемент");
            int value = int.Parse(Console.ReadLine());
            var timer = new Stopwatch();
            int j = 0, index = 0;
            bool found = false;
            timer.Start();
            //пошук перебором
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
       static void Searchwithbarrier(int[] array, int size)
        {
            Console.WriteLine("\nПошук з барʼєром");
            Console.WriteLine("Введіть шуканий елемент");
            int value = int.Parse(Console.ReadLine());
            int j = 0;
            array[size] = value;
            var timer = new Stopwatch();
            timer.Start();
            //пошук із барʼєром
            while (array[j] != value)
                j++;
            timer.Stop();
            if (j < size) Console.WriteLine("Елемент знайдено з індексом " + j);
            else Console.WriteLine("Цього елементу немає у масиві");
            Console.WriteLine("Витрачено часу: " + timer.Elapsed);
            Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
            Console.ReadKey();
        }

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
            //бінарний пошук
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
            //бінарний пошук за правилом золотого перерізу
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


        static void Linked_list()
        {
            Console.Clear();
            Console.WriteLine("\nЛінійний звʼязний список");
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
