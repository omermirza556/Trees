using System;
namespace Tree
{
    /*
     * This class is an implementation of the Binary Search Node. 
     * It contains a pointer to a left and a right node. 
     * It contains one value
     */

    public class BinaryNode
    {
        BinaryNode left, right;
        private int val;

        public BinaryNode(int value)
        {
            this.val = value;
            this.left = null;
            this.right = null;
        }

        public BinaryNode(BinaryNode left, BinaryNode right, int value){
            this.left = left;
            this.right = right;
            this.val = value;
        }

        /*
         * The following are properties of a Binary Search Node
         */

        public int Value
        {
            get { return val; }
            set { this.val = value; }
        }

        public BinaryNode Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        public BinaryNode Right
        {
            get { return this.right; }
            set { this.right = value; }
        }


    }


}
