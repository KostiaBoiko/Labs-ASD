using System;
namespace Завдання_на_практику_стек_черга
{
    public class Stack<T>
    {
        public T[] items; 
        private int count;  
        const int n = 10;  //початковий розмір
        public Stack()
        {
            items = new T[n];
        }
        public Stack(int length)
        {
            items = new T[length];
        }

        // перевіка, чи пустий стек
        public bool IsEmpty
        {
            get { return count == 0; }
        }
        // розмір стеку
        public int Count
        {
            get { return count; }
        }

        // додавання нового елемена
        public void Push(T item)
        {
            // коли стек завовнений, повідомляємо про це і повертаємось
            if (count == items.Length)
            {
                Console.WriteLine("Стек заповнений");
                return;
            }
            items[count++] = item;
        }

        // видалення елемента
        public T Pop()
        {
            if (IsEmpty)
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Стек пуст");
                T itm = items[0];
                return itm;
            }
                T item = items[--count];
                return item;
            
        }

        // повертаємо елемент з вершини
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            return items[count - 1];
        }
    }
}
