using System;

namespace Завдання_на_практику_стек_черга
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Завдання на практику ІПЗ-14 Бойко Костянтин Богданович");
            Menu();
        }
        static public void Menu()
        {
            Console.WriteLine("\n\t\tМеню");
            Console.WriteLine("1. Завдання 1");
            Console.WriteLine("2. Завдання 2");
            Console.WriteLine("3. Завдання 3");
            Console.WriteLine("4. Завдання 4");
            int choosenoperation = Convert.ToInt32(Console.ReadLine());
            switch (choosenoperation)
            {
                case 1: Task1(); Menu(); break;
                case 2: Task2(); Menu(); break;
                case 3: Task3(); Menu(); break;
                case 4: Task4(); Menu(); break;
                default: break;
            }
        }
        static void Task1()
        {
            Console.WriteLine("\n\tЗавдання 1");
            Console.WriteLine("Введіть рядок послідовності символів '(' та ')' ");
            string mystring = Console.ReadLine();
            Stack<string> mystack1 = new Stack<string>(mystring.Length);
            bool canmakearif = true;
            for (int i = 0; i < mystring.Length; i++)
            {
                if(mystring[i]=='(' )
                {
                    mystack1.Push("(");
                }
                else if(mystring[i]==')')
                {
                    if(mystack1.IsEmpty)
                    {
                        canmakearif = false;
                        break;
                    }
                    mystack1.Pop();
                }
            }
            if(!mystack1.IsEmpty || !canmakearif)
                Console.WriteLine("\nЗ даного рядка не можна створити правильний арфиметичний вираз");
            else if (canmakearif)
                Console.WriteLine("\nЗ даного рядка можна створити правильний арфиметичний вираз");
            
            Console.ReadLine();
        }

        static void Task2()
        {
            Console.WriteLine("\n\tЗавдання 2");
            Console.WriteLine("Ініціалізуйте першу чергу ");
            Console.Write("Введіть розмір ");
            int firstqueuesize = Convert.ToInt32(Console.ReadLine());
            Queue<int> firstqueue = new Queue<int>();
            Console.WriteLine("Введіть значення ");
            for (int i = 0; i < firstqueuesize; i++)
            {
                firstqueue.Enqueue(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine("Ініціалізуйте другу чергу ");
            Console.Write("Введіть розмір ");
            int secondqueuesize = Convert.ToInt32(Console.ReadLine());
            Queue<int> secondqueue = new Queue<int>();
            for (int i = 0; i < secondqueuesize; i++)
            {
                secondqueue.Enqueue(Convert.ToInt32(Console.ReadLine()));
            }

            Console.WriteLine("Третя черга, створена обʼєднанням двої попередніх: ");
            Queue<int> thirdqueue = new Queue<int>();
            int thirdqueuesize = (firstqueue.Count + secondqueue.Count);

            for (int i = 0; i < thirdqueuesize; i++)
            {
                if (!firstqueue.IsEmpty && !secondqueue.IsEmpty)//коли перша і друга черга непуста
                {
                    if (firstqueue.FirstElement < secondqueue.FirstElement)
                    {
                        thirdqueue.Enqueue(firstqueue.FirstElement);
                        firstqueue.Dequeue();
                    }
                    else
                    {
                        thirdqueue.Enqueue(secondqueue.FirstElement);
                        secondqueue.Dequeue();
                    }
                }
                else if (firstqueue.IsEmpty)//коли перша черга пуста
                {
                    thirdqueue.Enqueue(secondqueue.FirstElement);
                    secondqueue.Dequeue();
                }
                else if (secondqueue.IsEmpty)//коли друга черга пуста
                {
                    thirdqueue.Enqueue(firstqueue.FirstElement);
                    firstqueue.Dequeue();
                }
                else//коли дві черги пусті
                    break;
            }
            thirdqueue.Outputqueue();
            Console.ReadLine();
        }

        static void Task3()
        {
            Console.WriteLine("\n\tЗавдання 3");
            Console.WriteLine("Введіть кількість споруд");
            int NumberOfAllBuildings = Convert.ToInt32(Console.ReadLine());
            int[] ArrayOfAllBuildings = new int[NumberOfAllBuildings];
            Console.WriteLine("");
            for (int i = 0; i < NumberOfAllBuildings; i++)
            {
                Console.Write("Введіть значення на позиції {0} - ",i);
                ArrayOfAllBuildings[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("\n\tВивід масива на екран");
            foreach (int item in ArrayOfAllBuildings)
            {
                Console.Write(item + " ");
            }

            int[] ArrayOfInvisibleBuildings = new int[NumberOfAllBuildings];
            for (int i = 1; i < NumberOfAllBuildings; i++)
            {
                if(ArrayOfAllBuildings[0]<ArrayOfAllBuildings[i])
                {
                    i++;
                    for (int j = i, k = 0; j < NumberOfAllBuildings; j++, k++)
                    {
                        ArrayOfInvisibleBuildings[k] = ArrayOfAllBuildings[j];
                    }
                    break;
                }
            }
            Console.WriteLine("\n\nВвивід споруд, які невидимі для споруди з висотою " + ArrayOfAllBuildings[0]);
            foreach (int item in ArrayOfInvisibleBuildings )
            {
                if(item!=0)
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        static void Task4()
        {
            Console.WriteLine("\n\tЗавдання 4");
            Console.WriteLine("Введіть кількість стопок");
            int numberofstacks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть розмір стопок");
            int largeofstacks = Convert.ToInt32(Console.ReadLine());
            SetofStacks<string> mysetofstacks = new SetofStacks<string>(numberofstacks, largeofstacks);

            Console.WriteLine("Введіть кількість тарілок");
            int numberofplates = Convert.ToInt32(Console.ReadLine());
            string[] plates = new string[numberofplates];
            for(int i =0; i < numberofplates; i++)
            {
                plates[i] = "Тарілка номер " + (i+1);
            }
            mysetofstacks.Push(plates);
            Console.WriteLine("\nВивід на екран ");
            mysetofstacks.Output();

         }
    }
}
