using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_2_ASD
{
    public class AVLTree : IEnumerable
    {
        public AVLTreeNode Root { get; internal set; }
        public int Count { get; private set; }

        public void Add(int value)
        {
            // Якщо дерево пусте - створюємо корінь
            if (Root == null)
            {
                Root = new AVLTreeNode(value, null, this);
            }
            // Якщо дерево не пусте, то шукаємо місце для додавання елемента
            else
            {
                AddTo(Root, value);
            }

            Count++;
        }

        private void AddTo(AVLTreeNode node, int value)
        {
            // Значення вхідного елемента менше, ніж поточне значення вузла
            if (value.CompareTo(node.Value) < 0)
            {
                //Якщо лівого вузла немає, то створюємо його
                if (node.Left == null)
                {
                    node.Left = new AVLTreeNode(value, node, this);
                }
                else
                {
                    //Перехід до наступного лівого вузла
                    AddTo(node.Left, value);
                }
            }
            // Значення вхідного елемента більше або дорівнює поточному значенню вузла
            else
            {
                //Якщо правого вузла немає,то створюємо його       
                if (node.Right == null)
                {
                    node.Right = new AVLTreeNode(value, node, this);
                }
                else
                {
                    // Переході до наступного правого вузла            
                    AddTo(node.Right, value);
                }
            }
            node.Balance();
        }

        private AVLTreeNode Find(int value)
        {
            AVLTreeNode current = Root; // поміщаємо поточний елемент в корінь дерева
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
            AVLTreeNode current;
            current = Find(value); // шукаємо елемент, що треба видалити

            if (current == null) //елемент не знайдено
            {
                return false;
            }

            AVLTreeNode treeToBalance = current.Parent; // баланс дерева відносно вузла батька
            Count--;
            //Якщо елемент немає правого нащадка
            if (current.Right == null) 
            {
                if (current.Parent == null) // видаляємий вузол є коренем
                {
                    Root = current.Left;    // на місце кореня переміщуємо лівий нащадок
                    if (Root != null)
                    {
                        Root.Parent = null; // видаляємо силку на батька  
                    }
                }
                else // видаляємий вузол не є батьком
                {
                    int result = current.Parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // Якщо значення батьківського вузла більше, ніж значення видаляємого елемента
                        // То робиимо лівого нащадка видаляємого вузла - лівим нащадком батька
                        current.Parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        // Якщо значення батьківського вузла менше, ніж значення видаляємого               
                        // То робимо лівого нащадка видаляємого вузла - правим нащадком батьківського вузла           
                        current.Parent.Right = current.Left;
                    }
                }
            }

            //Якщо правий назадок видаляємого вузла немає лівого нащадка, то тоді назадок видаляємого вузла
            //робимо назадком батьківського вузла
            else if (current.Right.Left == null) // якщо у правого нащадка немає лівого нащадка
            {
                current.Right.Left = current.Left;
                if (current.Parent == null) // Поточний елемент є корнем
                {
                    Root = current.Right;
                    if (Root != null)
                    {
                        Root.Parent = null;
                    }
                }
                else
                {
                    int result = current.Parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // Якщо значення батьківського вузла більше, ніж значення видаляємого елемента
                        // То робиимо правого нащадка видаляємого вузла - лівим нащадком батька
                        current.Parent.Left = current.Right;
                    }

                    else if (result < 0)
                    {
                        // Якщо значення батьківського вузла менше, ніж значення видаляємого               
                        // То робимо правого нащадка видаляємого вузла - правим нащадком батьківського вузла           
                        current.Parent.Right = current.Right;
                    }
                }
            }

            // Якщо правий нащадок видаляємого вузла має лівого потомка     
            // міняжмо видаляємий вузол на крайній лівий нащадок правого нащадка    
            else
            {
                //знаходження крайнього лівого вузла для правого нащадка видаляємого вузла
                AVLTreeNode leftmost = current.Right.Left;
                while (leftmost.Left != null)
                {
                    leftmost = leftmost.Left;
                }
                // праве піддерево батьківського вузла стає лівим батьківським піддеревом         
                leftmost.Parent.Left = leftmost.Right;

                // Встановлюємо крайньому лівому вузлу силки на правого та лівого нащадка видаляємого вузла  
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;
                if (current.Parent == null)
                {
                    Root = leftmost;
                    if (Root != null)
                    {
                        Root.Parent = null;
                    }
                }
                else
                {
                    int result = current.Parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // Якщо значення батьківського вузла більше ніж значення видаляємого               
                        // то робимо лівий крайній нащадок - лівим нащадком батька видаляємого вузла
                        current.Parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        // Якщо значення батьківського вузла менше ніж значення видаляємого                   
                        // то робимо лівий крайній нащадок - правим нащадком батька видаляємого вузла
                        current.Parent.Right = leftmost;
                    }
                }
            }
            if (treeToBalance != null)
            {
                treeToBalance.Balance();
            }
            else
            {
                if (Root != null)
                {
                    Root.Balance();
                }
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
                Stack<AVLTreeNode> stack = new Stack<AVLTreeNode>();
                AVLTreeNode current = Root;
                //при рекурсивному переміщенні по дереву потрібно ще вказувати, який нащадок буде наступним(правий чи лівий)
                bool goLeftNext = true;
                // Вносимо корінь в стек
                stack.Push(current);
                while (stack.Count > 0)
                {
                    // Якщо йдем вліво
                    if (goLeftNext==true)
                    {
                        // Вносимо всіх лівих нащадків у стек
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current.Value;
                    // якщо йдем вправо
                    if (current.Right != null)
                    {
                        current = current.Right;
                        // Один раз йдемо вправо, після чого знову вліво
                        goLeftNext = true;
                    }
                    else
                    {
                        // Якщо не можемо піти вправо, то шукаємо батьківський вузол
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }
    }
}
