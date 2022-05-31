using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_2_ASD
{
    internal class Red_Black_Tree : IEnumerable
    {
        public Red_Black_Tree_Node Root { get; private set; }
        public int Count { get; private set; }

        public Red_Black_Tree()
        {
            Root = null;
        }

        public Red_Black_Tree(Red_Black_Tree_Node root)
        {
            Root = root;
        }

        public void Add(int value)
        {
            Red_Black_Tree_Node node = null;
            // Якщо дерево пусте - створюємо корінь
            if (Root == null)
            {
                Root = new Red_Black_Tree_Node(value);
                Root.Color = Color.Black;
                return;
            }
            // Якщо дерево не пусте, то шукаємо місце для додавання елемента
            else
                node = AddTo(Root, value);
            Count++;
            if (node.Parent.Parent == null)
                return;
            Fix(node);
        }
        private Red_Black_Tree_Node AddTo(Red_Black_Tree_Node node, int value)
        {
            // Значення вхідного елемента менше, ніж поточне значення вузла
            if (value.CompareTo(node.Data) < 0)
            {
                //Якщо лівого вузла немає, то створюємо його
                if (node.Left == null)
                {
                    node.Left = new Red_Black_Tree_Node(value);
                    node.Left.Parent = node;
                    return node.Left;
                }
                //Перехід до наступного лівого вузла
                else
                    node = AddTo(node.Left, value);
            }
            // Значення вхідного елемента більше або дорівнює поточному значенню вузла
            else
            {
                //Якщо правого вузла немає,то створюємо його      
                if (node.Right == null)
                {
                    node.Right = new Red_Black_Tree_Node(value);
                    node.Right.Parent = node;
                    return node.Right;
                }
                // Переході до наступного правого вузла    
                else
                    node = AddTo(node.Right, value);
            }
            return node;
        }

        private void Fix(Red_Black_Tree_Node node)
        {
            while (node.Parent.Color == Color.Red)
            {
                if(node.Parent == node.Parent.Parent.Left)
                {
                    var rightAunt = node.Parent.Parent.Right;
                    if(rightAunt != null && rightAunt.Color == Color.Red)
                    {
                        node.Parent.Color = Color.Black;
                        rightAunt.Color = Color.Black;
                        node.Parent.Parent.Color = Color.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if(node == node.Parent.Right)
                        {
                            node = node.Parent;
                            LeftRotate(node);
                        }
                        node.Parent.Color = Color.Black;
                        node.Parent.Parent.Color = Color.Red;
                        RightRotate(node.Parent.Parent);
                    }
                }
                else
                {
                    var leftAunt = node.Parent.Parent.Left;
                    if(leftAunt != null && leftAunt.Color == Color.Red)
                    {
                        node.Parent.Color = Color.Black;
                        leftAunt.Color = Color.Black;
                        node.Parent.Parent.Color = Color.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if(node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RightRotate(node);
                        }
                        node.Parent.Color = Color.Black;
                        node.Parent.Parent.Color = Color.Red;
                        LeftRotate(node);
                    }
                }
                if(node == Root)
                {
                    break;
                }
            }
            Root.Color = Color.Black;
        }

        private void LeftRotate(Red_Black_Tree_Node node)
        {
            if(node.Right == null)  //перевірка, чи є у нас взагалі гілки для повороту
                return;
            var rightSubtree = node.Right;
            node.Right = rightSubtree.Left;
            if(rightSubtree.Left != null)
            {
                rightSubtree.Left.Parent = node;
            }
            rightSubtree.Parent = node.Parent;
            if(node.Parent == null)
            {
                Root = rightSubtree;
            }
            else if (node.Parent.Left == node)
            {
                node.Parent.Left = rightSubtree;
            }
            else
            {
                node.Parent.Right = rightSubtree;
            }
            rightSubtree.Left = node;
            node.Parent = rightSubtree;
        }

        private void RightRotate(Red_Black_Tree_Node node)
        {
            if (node.Left == null) //перевірка, чи є у нас взагалі гілки для повороту
                return;
            var leftSubtree = node.Left;
            node.Left = leftSubtree.Right;
            if (leftSubtree.Right != node)
            {

                leftSubtree.Right.Parent = node;
            }
            leftSubtree.Parent = node.Parent;
            if (node.Parent == null)
            {
                Root = leftSubtree;
            }
            else if (node.Parent.Left == node)
            {
                node.Parent.Left = leftSubtree;
            }
            else
            {
                node.Parent.Right = leftSubtree;
            }
            leftSubtree.Right = node;
            node.Parent = leftSubtree;
        }

        public Red_Black_Tree_Node Find(int value)
        {
            var current = Root; // поміщаємо поточний елемент в корінь дерева
            // поки поточний вузол не пустий
            while (current != null)
            {
                int result = current.CompareTo(value); // порівняння значення поточного елемента із значенням що шукається
                if (result > 0)
                {
                    // якщо значення менше поточного, то переходимо вліво 
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // якщо значення менше поточного, то перехожимо вправо     
                    current = current.Right;
                }
                else
                {
                    // Елемент знайдено 
                    break;
                }
            }
            return current;
        }
        public bool Remove(int value)
        {
            Red_Black_Tree_Node current;
            current = Find(value); // шукаємо елемент, що треба видалити
            if (current == null) //елемент не знайдено
            {
                return false;
            }
            Count--;
            //Якщо елемент немає правого нащадка
            if(current.Right == null)
            {
                if(current.Parent == null) // видаляємий вузол є коренем
                {
                    Root = current.Left;  // на місце кореня переміщуємо лівий нащадок
                    current.Left.Parent = null; // видаляємо силку на батька  
                }
                else // видаляємий вузол не є батьком
                {
                    int result = current.Parent.CompareTo(current.Data);
                    // Якщо значення батьківського вузла більше, ніж значення видаляємого елемента
                    if (result > 0)
                    {
                        current.Parent.Left = current.Left;
                    }
                    // Якщо значення батьківського вузла менше, ніж значення видаляємого  
                    else if (result < 0)
                    {
                        current.Parent.Right = current.Left;
                    }
                }
            }
            //якщо елемент має правого нащадка, який не має лівого нащадка
            else if(current.Right.Left == null) // якщо у правого нащадка немає лівого нащадка
            {
                current.Right.Left = current.Left;
                if(current.Parent == null) // Поточний елемент є корнем
                {
                    Root = current.Right;
                    current.Right.Parent = null;
                }
                else
                {
                    int result = current.Parent.CompareTo(current.Data);
                    // Якщо значення батьківського вузла більше, ніж значення видаляємого елемента
                    if (result > 0)
                    {
                        current.Parent.Left = current.Right;
                        current.Right.Parent = current.Parent;
                    }
                    // Якщо значення батьківського вузла менше, ніж значення видаляємого     
                    else if (result < 0)
                    {
                        current.Parent.Right = current.Right;
                        current.Right.Parent = current.Parent;
                    }
                }
            }
            //якщо елемент має правого нащадка, який має лівого нащадка
            else
            {
                //знаходження крайнього лівого вузла для правого нащадка видаляємого вузла
                var leftmost = current.Right.Left;
                while(leftmost.Left != null)
                {
                    leftmost = leftmost.Left;
                }
                // праве піддерево батьківського вузла стає лівим батьківським піддеревом      
                leftmost.Parent.Left = leftmost.Right;
                // Встановлюємо крайньому лівому вузлу силки на правого та лівого нащадка видаляємого вузла  
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;
                if(current.Parent == null)
                {
                    Root = leftmost;
                    leftmost = null;
                }
                else
                {
                    int result = current.Parent.CompareTo(current.Data);
                    // Якщо значення батьківського вузла більше ніж значення видаляємого 
                    if (result > 0)
                    {
                        current.Parent.Left = leftmost;
                        leftmost.Parent = current.Parent;
                    }
                    // Якщо значення батьківського вузла менше ніж значення видаляємого 
                    else if (result < 0)
                    {
                        current.Parent.Right = leftmost;
                        leftmost.Parent = current.Parent;
                    }
                }
            }
            if(current.Parent == Root)
            {
                Fix(current.Parent);
            }
            return true;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return InOrderTraversal();
        }
        public IEnumerator<int> InOrderTraversal()
        {
            // рекурсиве переміщення по дереву
            if (Root != null) // перевірка, чи існує корінь дерева
            {
                Stack<Red_Black_Tree_Node> stack = new Stack<Red_Black_Tree_Node>();
                Red_Black_Tree_Node current = Root;
                //при рекурсивному переміщенні по дереву потрібно ще вказувати, який нащадок буде наступним(правий чи лівий)
                bool goleft = true;
                // Вносимо корінь в стек
                stack.Push(current);
                while(stack.Count>0)
                {
                    Console.ResetColor();
                    // Якщо йдем вліво
                    if (goleft == true)
                    {
                        // Вносимо всіх лівих нащадків у стек
                        while (current.Left !=null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    if(current.Color == Color.Black)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    yield return current.Data;
                    Console.ResetColor();
                    // якщо йдем вправо
                    if (current.Right != null)
                    {
                        current = current.Right;
                        // Один раз йдемо вправо, після чого знову вліво
                        goleft = true;
                    }
                    else
                    {
                        // Якщо не можемо піти вправо, то шукаємо батьківський вузол
                        current = stack.Pop();
                        goleft = false;
                    }
                }
            }
        }
    }
}
