using System;
namespace Lab_2_ASD
{
    public enum Color
    {
        Black,
        Red
    }
    internal class Red_Black_Tree_Node : IComparable
    {
        public Red_Black_Tree_Node Parent { get; set; }
        public Red_Black_Tree_Node Left { get; set; }
        public Red_Black_Tree_Node Right { get; set; }
        public int Data { get; set; }
        public Color Color { get; set; }

        public Red_Black_Tree_Node(int data)
        {
            Parent = null;
            Left = null;
            Right = null;
            Data = data;
            Color = Color.Red;
        }

        public Red_Black_Tree_Node(int data, Red_Black_Tree_Node parent, Red_Black_Tree_Node left, Red_Black_Tree_Node right)
        {
            Parent = parent;
            Left = left;
            Right = right;
            Data = data;
            Color = Color.Red;
        }
        public int CompareTo(object obj)
        {
            return Data.CompareTo(obj);
        }

    }
}
