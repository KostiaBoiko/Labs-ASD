using System;
namespace Lab_2_ASD
{
    public class AVLTreeNode : IComparable
    {
        AVLTree _tree;
        AVLTreeNode _left;  
        AVLTreeNode _right;  
        public AVLTreeNode Parent { get; internal set; }
        public int Value { get; private set; }

        public AVLTreeNode(int value, AVLTreeNode parent, AVLTree tree)
        {
            Value = value;
            Parent = parent;
            _tree = tree;
        }

        public AVLTreeNode Left
        {
            get
            {
                return _left;
            }
            internal set
            {
                _left = value;

                if (_left != null)
                {
                    _left.Parent = this;  // установка указателя на родительский элемент
                }
            }
        }

        public AVLTreeNode Right
        {
            get
            {
                return _right;
            }
            internal set
            {
                _right = value;
                if (_right != null)
                {
                    _right.Parent = this; // установка указателя на родительский элемент
                }
            }
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        private int MaxChildHeight(AVLTreeNode node)
        {
            if (node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
            }
            return 0;
        }

        private int LeftHeight { get { return MaxChildHeight(Left); } }
        
        private int RightHeight { get { return MaxChildHeight(Right); } }

        enum TreeState
        {
            Balanced,
            LeftHeavy,
            RightHeavy,
        }
        //Визначення стану для дерева
        private TreeState State
        {
            get
            {
                if (LeftHeight - RightHeight > 1)
                {
                    return TreeState.LeftHeavy;
                }

                if (RightHeight - LeftHeight > 1)
                {
                    return TreeState.RightHeavy;
                }

                return TreeState.Balanced;
            }
        }

        private int BalanceFactor
        {
            get
            {
                return RightHeight - LeftHeight;
            }
        }

        private void ReplaceRoot(AVLTreeNode newRoot)
        {
            if (Parent != null)
            {
                if (Parent.Left == this)
                {
                    Parent.Left = newRoot;
                }
                else if (Parent.Right == this)
                {
                    Parent.Right = newRoot;
                }
            }
            else
            {
                _tree.Root = newRoot;
            }
            newRoot.Parent = Parent;
            Parent = newRoot;
        }

        private void LeftRotation()
        {
            // Робимо правого нащадка новим коренем
            AVLTreeNode newRoot = Right;
            ReplaceRoot(newRoot);

            // Ставимо на місце правого нащадка - лівого нащадка нового кореня  
            Right = newRoot.Left;
            //Робимо поточний вузол лівимо потомком нового кореня
            newRoot.Left = this;
        }

        private void RightRotation()
        {
            // Робимо лівий нащадок поточного елемента новим коренем
            AVLTreeNode newRoot = Left;
            ReplaceRoot(newRoot);
            // Переміщення правого нащадка нового кореня на місце лівого нащадка старого кореня
            Left = newRoot.Right;
            // правим назадком нового кореня стає старий корінь    
            newRoot.Right = this;
        }

        private void LeftRightRotation()
        {
            Right.RightRotation();
            LeftRotation();
        }

        private void RightLeftRotation()
        {
            Left.LeftRotation();
            RightRotation();
        }

        internal void Balance()
        {
            if (State == TreeState.RightHeavy)
            {
                if (Right != null && Right.BalanceFactor < 0)
                {
                    LeftRightRotation();
                }
                else
                {
                    LeftRotation();
                }
            }
            else if (State == TreeState.LeftHeavy)
            {
                if (Left != null && Left.BalanceFactor > 0)
                {
                    RightLeftRotation();
                }
                else
                {
                    RightRotation();
                }
            }
        }
    }
}
