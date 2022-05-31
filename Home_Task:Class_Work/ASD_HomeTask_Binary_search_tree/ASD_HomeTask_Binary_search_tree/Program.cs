using System;

namespace ASD_HomeTask_Binary_search_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Бойко Костянтин Богданович ІПЗ-14\n");
            Console.WriteLine("Бінарні дерева пошуку");
            Binary_Tree Tree = new Binary_Tree();
            Console.WriteLine("Введіть кількість елементів у дереві");
            int numberofv = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberofv; i++)
            {
                int value = 0;
                Console.Write("Введіть елемент, який хочете додати ");
                value = Convert.ToInt32(Console.ReadLine());
                Tree.Add(value);
            }
            Tree.DisplayTree();
            Console.ReadKey();
            Console.WriteLine("\n");
            Tree.Tree_Minimun();
            Console.WriteLine();
            Tree.Tree_Maximum();
            Console.WriteLine("");
            Tree.Delete_value();
            Tree.DisplayTree();
            Console.ReadKey();
        }
    }
}
