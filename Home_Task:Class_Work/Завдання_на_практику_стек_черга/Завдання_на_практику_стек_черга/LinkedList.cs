using System;
namespace Завдання_на_практику_стек_черга
{
    public class mylinkedlist<T>
    {
        public mylinkedlist(T dt)
        {
            Data = dt;
            Next = null;
        }

        public T Data;
        public mylinkedlist<T> Next;
    }
}
