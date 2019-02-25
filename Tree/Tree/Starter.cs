using System;

namespace Tree
{
    public class Starter
    {
        public static void Main()
        {
            BinarySearchTree theTree = new BinarySearchTree();
            theTree.insert(14);
            theTree.insert(15);
            theTree.insert(59);
            theTree.insert(100);
            theTree.insert(10000);

            theTree.dispInOrder();
            theTree.dispPreOrder();
            theTree.dispPostOrder();

            theTree.Delete(14);

            theTree.dispInOrder();
            theTree.dispPreOrder();
            theTree.dispPostOrder();
            Console.WriteLine("********");
            Console.WriteLine("The max value in the tree is: " + theTree.getMax());
            theTree.Delete(10000);
            Console.WriteLine(theTree.getMax());
            theTree.Delete(1);
			Console.WriteLine("********");
			theTree.dispInOrder();
			theTree.dispPreOrder();
			theTree.dispPostOrder();
            Console.WriteLine("********");

            TwoThreeTree twoThreeTree = new TwoThreeTree();
            twoThreeTree.Insert(1);
            twoThreeTree.Insert(2);
            twoThreeTree.Insert(3);
            twoThreeTree.Insert(4);
            twoThreeTree.Insert(5);
            twoThreeTree.Insert(6);
            twoThreeTree.Insert(7);
            Console.WriteLine("*********");
            Console.WriteLine("The max value is " + twoThreeTree.GetMax());
            Console.WriteLine("*********");
            twoThreeTree.Print();



 




        }

    }
}
