using System;
namespace Lab_2_ASD
{
    public class Binary_Search_Tree_Node
    {
        public Binary_Search_Tree_Node Left;
        public Binary_Search_Tree_Node Right;
        public Binary_Search_Tree_Node Parent;
        public int Data;
        public Binary_Search_Tree_Node(int data)
        {
            Left = null;
            Right = null;
            Parent = null;
            Data = data;
        }
    }
}
