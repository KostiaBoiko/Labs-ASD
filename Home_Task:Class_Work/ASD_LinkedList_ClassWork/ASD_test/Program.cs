using System;

namespace ASD_test
{

    public class Item
    {
        public Item(int dt, Item nx)
        {
            data = dt;
            next = nx;
        }
        public int data;
        public Item next;
    }

    class Program
    {
        static Item additemfirst(Item head, int data)
        {
            Item newItem = new Item(data, head);
            head = newItem;
            return head;
        }

        public static void additemlast(ref Item head, ref int data)
        {

            Item newItem;
            Item last = head;
            if (head == null)
            {
                newItem = new Item(data, null);
                head = newItem;
            }
            else
            {
                while (last.next != null)
                {
                    last = last.next;
                }
                newItem = new Item(data, null);
                last.next = newItem;
            }
        }
        public static void outputlist(ref Item head)
        {
            Item temp = head;
            while (temp != null)
            {
                Console.Write(" " + temp.data);
                temp = temp.next;
            }
        }

        public static void deleteelement(Item head, int index)
        {
            Item p = head;
            for (int i = 0; i < (index - 2); i++)
            {
                p = p.next;
            }
            p.next = p.next.next;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Завдання");
            Console.WriteLine("Введіть кількість елементів у списку");
            int lagreoflist = Convert.ToInt32(Console.ReadLine());
            Item head = null;
            Console.WriteLine("Як будемо створювати список?");
            Console.WriteLine("1. Зворотне створення");
            Console.WriteLine("2. Пряме створення");
            int key = Convert.ToInt32(Console.ReadLine());
            for (int i =0; i< lagreoflist; i++)
            {
                Console.Write("\nВведіть елемент списку: ");
                int element = Convert.ToInt32(Console.ReadLine());
                if(key == 1)
                    head = additemfirst(head, element);
                else if (key==2)
                   additemlast(ref head,ref element);
            }
            Console.WriteLine("\nУтворений список");
            outputlist(ref head);

            Console.WriteLine("\nВидалення елемента");
            Console.WriteLine("Введіть номер елемента, який потрібно видалити");
            int indexofelem = Convert.ToInt32(Console.ReadLine());
            deleteelement(head, indexofelem);
            Console.WriteLine("\nСписок після перетвореня");
            outputlist(ref head);
            Console.ReadKey();
        }
    }
}
