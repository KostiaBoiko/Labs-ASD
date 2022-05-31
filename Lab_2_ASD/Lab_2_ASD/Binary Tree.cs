using System;
namespace Lab_2_ASD
{
    public class Binary_Search_Tree
    {
       public Binary_Search_Tree_Node Root;

        private void PreOrderTraversal(Binary_Search_Tree_Node root)//прямий(префіксний) обхід
        {
            if (root == null)
                return;
            Console.Write(root.Data + " ");
            PreOrderTraversal(root.Left);
            PreOrderTraversal(root.Right);
        }
        private void InOrderTraversal(Binary_Search_Tree_Node root)//центрований(інфіксний) обхід
        {
            if (root == null)
                return;
            InOrderTraversal(root.Left);
            Console.Write(root.Data + " ");
            InOrderTraversal(root.Right);
        }
        private void PostOrderTraversal(Binary_Search_Tree_Node root)//центрований(інфіксний) обхід
        {
            if (root == null)
                return;
            PostOrderTraversal(root.Left);
            PostOrderTraversal(root.Right);
            Console.Write(root.Data + " ");
        }

        public void DisplayTree()
        {
            Console.WriteLine("\nПрямий(префіксний) обхід");
            PreOrderTraversal(Root);
            Console.WriteLine("\nЦентрований(інфіксний) обхід");
            InOrderTraversal(Root);
            Console.WriteLine("\nЗворотній(постфіксний) обхід");
            PostOrderTraversal(Root);
        }


        public void Add(int value)
        {
           Binary_Search_Tree_Node after = Root;
            while (after != null)
            {
                Root.Parent = after;
                if (value < after.Data)
                    after = after.Left;
                else if (value > after.Data)
                    after = after.Right;
                else
                    return;//появилось те ж саме число
            }
            Binary_Search_Tree_Node newValue = new Binary_Search_Tree_Node(value);
            if (Root == null)
                Root = newValue;
            else
            {
                if (value < Root.Parent.Data)
                    Root.Parent.Left = newValue;
                else
                    Root.Parent.Right = newValue;
            }
            return;
        }

        public void Tree_Minimun()
        {
            Binary_Search_Tree_Node temp2 = Find_Minimun(Root); 
            Console.WriteLine("Мінімальне значення - " + temp2.Data);
        }

        private Binary_Search_Tree_Node Find_Minimun(Binary_Search_Tree_Node root)
        {
            while (root.Left != null)
            {
                root = root.Left;
            }
            return root;
        }
        public void Tree_Maximum()
        {
            Binary_Search_Tree_Node temp = Root;
            while (temp.Right != null)
            {
                temp = temp.Right;
            }
            Console.WriteLine("Мінімальне значення - " + temp.Data);
        }

        public void Delete_value()
        {
            Console.WriteLine("Введіть значення, яке потрібно видалити");
            int value = Convert.ToInt32(Console.ReadLine());
            Root = Remove(Root, value);
        }

        private Binary_Search_Tree_Node Remove(Binary_Search_Tree_Node root, int key)
        {
            if (root == null) return root;

            if (key < root.Data)
                root.Left = Remove(root.Left, key);
            else if (key > root.Data)
               root.Right = Remove(root.Right, key);

            // коли знайшли введене значення, то видаляємо його
            else
            {
                // 1 та 2 випадок, коли елемент, що треба видалити, є листком або має одного нащадка
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;
                // 3 випадок, коли у нас є два нащадки
                Binary_Search_Tree_Node temp = Find_Minimun(root.Right);
                root.Data = temp.Data;

                // Видаляємо 
                root.Right = Remove(root.Right, root.Data);
            }
            return root;
        }
    }
}
