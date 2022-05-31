using System;
namespace Завдання_на_практику_стек_черга
{
    public class SetofStacks<T>
    {
        Stack<T>[] array;
        private int count;
        const int Mainlarge = 10;  //початковий розмір
        int largeofstacks;

        public SetofStacks()
        {
            array = new Stack<T>[Mainlarge];
        }

        public SetofStacks(int numberofstacks, int countofstacks)
        {
            count = numberofstacks;
            array = new Stack<T>[count];
            largeofstacks = countofstacks;
        }

        // розмір стеку
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public void Output()
        {
            for(int i =0; i < array.Length; i++)
            {
                Console.Write("\n\n\tСтопка номер {0} \n", (i+1) );
                for (int j = 0;  j < largeofstacks; j++)
                {
                    Console.Write(array[i].items[j] + " ");
                }
            }
        }


        // додавання нового елемена
        public void Push(T[] elements)
        {
            int k = 0;
            for (int i = 0; i < count; i++)
            {
                array[i] = new Stack<T>(largeofstacks);
                    // коли стек завовнений, повідомляємо про це і повертаємось
                    if (array[i].Count == array[i].items.Length)
                    {
                        Console.WriteLine("Стек номер {0} заповнений ", i);
                        return;
                    }

                    for (int j = 0; j < largeofstacks; j++)
                    {
                        if (elements.Length != k)
                        {
                            array[i].items[j] = elements[k];
                            k++;
                        }
                        else break;
                    }
            }
        }

        //public T Pop()
        //{
        //    if (IsEmpty)
        //    {
        //        if (IsEmpty)
        //            throw new InvalidOperationException("Стек пустий");
        //        T itm = items[0];
        //        return itm;
        //    }
        //    T item = items[--count];
        //    items[count] = default; // сбрасываем ссылку
        //    return item;

        //}

    }
}
