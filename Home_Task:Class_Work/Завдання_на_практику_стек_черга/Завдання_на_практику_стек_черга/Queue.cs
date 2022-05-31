using System;

namespace Завдання_на_практику_стек_черга
{
    public class Queue<T> 
    {
        mylinkedlist<T> head;
        mylinkedlist<T> tail; 
        int count;

        public int Count
        {
            get { return count; }
        }
        public bool IsEmpty
        {
            get { return count == 0; }
        }
             // додавання в чергу
        public void Enqueue(T data)
        {
            mylinkedlist<T> node = new mylinkedlist<T>(data);
            mylinkedlist<T> tempNode = tail;
            tail = node;
            if (count == 0)
                head = tail;
            else
                tempNode.Next = tail;
            count++;
        }

        // видалення з черги
        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }

        // получаємо перший елемент
        public T FirstElement
        {
            get
            {
                return head.Data;
            }
        }

        // получаем останній элемент
        public T LastElement
        {
        get
        {
            return tail.Data;
        }
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            mylinkedlist<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void Outputqueue()
        {
            mylinkedlist<T> current = head;
            while(current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
}
