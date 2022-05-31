using System;

namespace Lab_2_ASD
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Бойко Костянтин Богданович ІПЗ-14");
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("\n\n\tМеню");
            Console.WriteLine("Виберіть дерева, з якими будемо працювати");
            Console.WriteLine("1. Бінарні дерева пошуку");
            Console.WriteLine("2. Червоно-чорні дерева ");
            Console.WriteLine("3. АВЛ дерева");
            Console.WriteLine("0. Вихід");
            int key = Convert.ToInt32(Console.ReadLine());
            switch(key)
            {
                case 1: BinarySearchTree(); Menu(); break;
                case 2: RedBlackTree(); Menu(); break;
                case 3: AVLTree(); Menu(); break;
                default: break;
            }
        }

        public static void BinarySearchTree()
        {
            Console.WriteLine("\n\n\tБінарні дерева пошуку");
            Binary_Search_Tree Tree = new Binary_Search_Tree();
            Console.WriteLine("Введіть кількість елементів у дереві");
            int numberofelements = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberofelements; i++)
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

        public static void RedBlackTree()
        {
            Console.WriteLine("\n\n\tЧервоно-чорні дерева");
            Red_Black_Tree redblacktree = new Red_Black_Tree();
            Console.WriteLine("Введіть кількість елементів у дереві");
            int numberofelements = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberofelements; i++)
            {
                int value = 0;
                Console.Write("Введіть елемент, який хочете додати ");
                value = Convert.ToInt32(Console.ReadLine());
                redblacktree.Add(value);
            }
            Console.WriteLine("\nВвивід дерева на екран");
            foreach(var item in redblacktree)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
            Console.WriteLine("\nВведіть елемент, який хочете видалити");
            int deletevalue = Convert.ToInt32(Console.ReadLine());
            redblacktree.Remove(deletevalue);
            Console.WriteLine("\nВведіть дерева на екран після видалення");
            foreach (var item in redblacktree)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }

        public static void AVLTree()
        {
            Console.WriteLine("\n\n\tАВЛ дерева");
            AVLTree avltree = new AVLTree();
            Console.WriteLine("Введіть кількість елементів у дереві");
            int numberofelements = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberofelements; i++)
            {
                int value = 0;
                Console.Write("Введіть елемент, який хочете додати ");
                value = Convert.ToInt32(Console.ReadLine());
                avltree.Add(value);
            }
            Console.WriteLine("\nВвивід дерева на екран");
            foreach (var item in avltree)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
            Console.WriteLine("\nВведіть елемент, який хочете видалити");
            int deletevalue = Convert.ToInt32(Console.ReadLine());
            avltree.Remove(deletevalue);
            Console.WriteLine("\nВведіть дерева на екран після видалення");
            foreach (var item in avltree)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
    }
}
