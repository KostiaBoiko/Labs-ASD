# Lab1 ASD Boiko K B




using System;
using System.Diagnostics;
namespace Lab1asd
{
    class Program
    {
        static void NumberGenerator(int[] Vals, int n)
        {
            Random aRand = new Random();
            for (int i = 0; i < Vals.Length; i++)
                Vals[i] = aRand.Next(n);
        }
       
        static void Task1()
        {
           // Console.Clear();
            Console.WriteLine("1. Пошук перебором");
            Console.WriteLine("Оберіть тип даних, з яким будемо працювати:");
            Console.WriteLine("1. Масив 2. Лінійний звʼязний список");

            int key = Convert.ToInt32(Console.ReadLine());
            if (key == 1)
            {
                int i, j=1 ,nom=0;
                bool found = false;
                Console.WriteLine("Введіть розмір масиву");
                int n = int.Parse(Console.ReadLine());
                int[] mas = new int[n]; 
                Console.WriteLine("Згенеруємо масив ");
                NumberGenerator(mas, n);
                for ( i = 0; i < n; i++)
                {
                    Console.Write(mas[i] + " ");
                }
                Console.WriteLine("\n Введіть шуканий елемент");
                int elem = int.Parse(Console.ReadLine());

                var timer = new Stopwatch();
                timer.Start();
                while ((j < n) && (found == false))
                {
                    if (mas[j]==elem)
                    {
                        nom = j;
                        found = true;
                    }
                    j++;
                }
                timer.Stop();

                if (found == true)
                    Console.WriteLine("Елемент знайдено з індексом " + nom);
                else if (j == n)
                    Console.WriteLine("Цього елементу немає у масиві");

                Console.WriteLine("Витрачено часу: " + timer.Elapsed);
                Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
                Console.ReadKey();
            }
            else if(key == 2)
            {
               Console.WriteLine("\n В процесі розробки :(");
            }
            else Console.WriteLine("\n Введіть 1 або 2");
        }


        static void Task2()
        {
            //Console.Clear();
            Console.WriteLine("2. Пошук з бар'єром\n");
            Console.WriteLine("Оберіть тип даних, з яким будемо працювати:");
            Console.WriteLine("1. Масив 2. Лінійний звʼязний список");
            int key = Convert.ToInt32(Console.ReadLine());

            if (key == 1)
            {
                int i;
                Console.WriteLine("Введіть розмір масиву");
                int n = int.Parse(Console.ReadLine());
                int[] mas = new int[n+2];
                Console.WriteLine("Згенеруємо масив ");
                NumberGenerator(mas, n);
                for (i = 0; i < n; i++)
                {
                    Console.Write(mas[i] + " ");
                }
                Console.WriteLine("\n Введіть шуканий елемент");
                int elem = int.Parse(Console.ReadLine());
                int j=1;
                mas[n+1] = elem;
                var timer = new Stopwatch();
                timer.Start();
                while (mas[j] != elem)
                    j++;
                timer.Stop();
                if (j <= n) Console.WriteLine("Елемент знайдено з індексом " + j);
                else Console.WriteLine("Цього елементу немає у масиві");

                Console.WriteLine("Витрачено часу: " + timer.Elapsed);
                Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
                Console.ReadKey();
            }

            else if (key == 2)
            {
                Console.WriteLine("\n В процесі розробки :(");
            }
            else Console.WriteLine("\n Введіть 1 або 2");

        }

        static void Task3()
        {
            
            //Console.Clear();
            Console.WriteLine("3. Бінарний пошук\n");
            Console.WriteLine("Оберіть тип даних, з яким будемо працювати:");
            Console.WriteLine("1. Масив 2. Лінійний звʼязний список");
            int key = Convert.ToInt32(Console.ReadLine());

            if (key == 1)
            {
               
                int i, nom=0;
                Console.WriteLine("Введіть розмір масиву");
                int n = int.Parse(Console.ReadLine());
                int[] mas = new int[n+1];
                Console.WriteLine("Згенеруємо масив ");
                NumberGenerator(mas, n);
                Array.Sort(mas);
                for (i = 0; i < n; i++)
                {
                    Console.Write(mas[i] + " ");
                }
                Console.WriteLine("\n Введіть шуканий елемент");
                int elem = int.Parse(Console.ReadLine());
                int left = 0;
                int right = n;
                bool found = false;

                var timer = new Stopwatch();
                timer.Start();
                while ((left <= right) && (found == false))
                {
                    int m = (left + right) / 2;
                    if (mas[m] == elem)
                    {
                        found = true;
                        nom = m;
                    }
                    else if (mas[m] < elem)
                        left = m + 1;
                    else right = m - 1;
                }
                timer.Stop();
                if (found == true)
                    Console.WriteLine("Елемент знайдено з індексом " + nom);
                else if (found == false)
                    Console.WriteLine("Цього елементу немає у масиві");

                Console.WriteLine("Витрачено часу: " + timer.Elapsed);
                Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
                Console.ReadKey();
            }
            else if (key == 2)
            {
                Console.WriteLine("\n В процесі розробки :(");
            }
            else Console.WriteLine("\n Введіть 1 або 2");

        }

        static void Task4()
        {
            //Console.Clear();
            Console.WriteLine("4. Бінарний пошук за правилом золотого перерізу\n");
            Console.WriteLine("Оберіть тип даних, з яким будемо працювати:");
            Console.WriteLine("1. Масив 2. Лінійний звʼязний список");
            int key = Convert.ToInt32(Console.ReadLine());

            if (key == 1)
            {
                int i, nom = 0;
                Console.WriteLine("Введіть розмір масиву");
                int n = int.Parse(Console.ReadLine());
                int[] mas = new int[n + 1];
                Console.WriteLine("Згенеруємо масив ");
                NumberGenerator(mas, n);
                Array.Sort(mas);
                for (i = 0; i < n; i++)
                {
                    Console.Write(mas[i] + " ");
                }
                Console.WriteLine("\n Введіть шуканий елемент");
                int elem = int.Parse(Console.ReadLine());
                int left = 0;
                int right = n;
                bool found = false;
                var timer = new Stopwatch();
                timer.Start();
                while ((left <= right) && (found == false))
                {
                    int m = (int) (left + 0.618 * (right - left));
                    if (mas[m] == elem)
                    {
                        found = true;
                        nom = m;
                    }
                    else if (mas[m] < elem)
                        left = m + 1;
                    else right = m - 1;
                }
                timer.Stop();
                if (found == true)
                    Console.WriteLine("Елемент знайдено з індексом " + nom);
                else if (found == false)
                    Console.WriteLine("Цього елементу немає у масиві");

                Console.WriteLine("Витрачено часу: " + timer.Elapsed);
                Console.WriteLine("Витрачено часу в мілісекундах: " + timer.ElapsedTicks);
                Console.ReadKey();
            }
            else if (key == 2)
            {
                Console.WriteLine("\n В процесі розробки :(");
            }
            else Console.WriteLine("\n Введіть 1 або 2");
        }

        static void Test()
        {
            Console.Clear();
            Console.ReadKey();
            double phi = 1.6;
            Console.WriteLine("phi = " + phi);
        }
        static void Main()
        {
            Console.WriteLine("\n Бойко Костянтин Богданович \n");
            Console.WriteLine("\n \n Лабораторна робота 1");
            Console.ResetColor();
            Console.WriteLine("Завдання:");
            Console.WriteLine("1. Пошук перебором");
            Console.WriteLine("2. Пошук з бар'єром");
            Console.WriteLine("3. Бінарний пошук");
            Console.WriteLine("4. Бінарний пошук за правилом золотого перерізу");
            Console.WriteLine("Для завершення роботи натисність iншу клавiшу");
            Console.WriteLine("Виберiть завдання:");
                int key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1: Task1(); Main(); break;
                case 2: Task2(); Main(); break;
                case 3: Task3(); Main(); break;
                case 4: Task4(); Main(); break;
                case 5: Test(); Main(); break;
                default: break;
            }
        }
    }
}
