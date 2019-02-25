using System;
namespace Tree
{
    public class TwoThreeNode
    {
        TwoThreeNode left, right, middle1, middle2, parent;
        int val1, val2, val3;
        NodeType type;
        public TwoThreeNode(TwoThreeNode left, TwoThreeNode right, TwoThreeNode middle1, TwoThreeNode middle2, TwoThreeNode parent, int val1, int val2, int val3)
        {
            this.left = left;
            this.right = right;
            this.middle1 = middle1;
            this.middle2 = middle2;
            this.Parent = parent;
            this.val1 = val1;
            this.val2 = val2;
            this.val3 = val3;
            this.type = NodeType.FourNode;


        }

        public TwoThreeNode(TwoThreeNode left, TwoThreeNode right, TwoThreeNode parent, int val1)
        {
            this.left = left;
            this.right = right;
            this.Parent = parent;
            this.val1 = val1;
            this.type = NodeType.TwoNode;

        }

        public TwoThreeNode(TwoThreeNode left, TwoThreeNode middle1, TwoThreeNode right, TwoThreeNode parent, int val1, int val2)
        {
            this.left = left;
            this.middle1 = middle1;
            this.right = right;
            this.Parent = parent;
            this.val1 = val1;
            this.val2 = val2;
            this.type = NodeType.ThreeNode;


        }

        public TwoThreeNode(NodeType type){
            this.type = type;
        }
        public TwoThreeNode(int val1){
            this.Val1 = val1;
            this.type = NodeType.TwoNode;
        }
        public TwoThreeNode(int val1, int val2)
        {
            this.val1 = val1;
            this.val2 = val2;
            this.type = NodeType.ThreeNode;
        }

        public TwoThreeNode(int val1, int val2, int val3){
            this.val1 = val1;
            this.val2 = val2;
            this.val3 = val3;
            this.type = NodeType.FourNode;
        }

        public TwoThreeNode Left { get => left; set => left = value; }
        public TwoThreeNode Right { get => right; set => right = value; }
        public TwoThreeNode Middle1 { get => middle1; set => middle1 = value; }
        public TwoThreeNode Middle2 { get => middle2; set => middle2 = value; }
        public int Val1 { get => val1; set => val1 = value; }
        public int Val2 { get => val2; set => val2 = value; }
        public int Val3 { get => val3; set => val3 = value; }
        public NodeType Type { get => type; set => type = value; }
        public TwoThreeNode Parent { get => parent; set => parent = value; }
    }
}
