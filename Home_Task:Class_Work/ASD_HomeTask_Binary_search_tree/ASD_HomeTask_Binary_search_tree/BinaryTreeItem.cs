using System;
namespace ASD_HomeTask_Binary_search_tree
{
    public class BinaryTreeItem
    {
        public BinaryTreeItem Left;
        public BinaryTreeItem Right;
        public BinaryTreeItem Parent;
        public int Data;
        public BinaryTreeItem(int data)
        {
            Left = null;
            Right = null;
            Parent = null;
            Data = data;
        }
    }
}
