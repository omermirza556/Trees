using System;
namespace Tree
{
    /// <summary>
    /// This is an implementation of the Binary Search Tree data structure
    /// </summary>
    public class BinarySearchTree
    {
        BinaryNode head = null;
        public BinarySearchTree()
        {
            this.head = null;
        }


        /*
         * The following are display methods
         */
        public void dispInOrder(){
            inOrder(head);
            Console.WriteLine("");
        }

        public void dispPostOrder(){
            postOrder(head);
            Console.WriteLine("");
        }

        public void dispPreOrder(){
            preOrder(head);
            Console.WriteLine("");
        }

        /*
         * The following are private recursive helper algorithms, used to traverse the tree data structure
         */
        private void inOrder(BinaryNode currentNode){
            if(currentNode!= null){
                inOrder(currentNode.Left);
                Console.Write(currentNode.Value + " ");
                inOrder(currentNode.Right);
            }
        }
        private void postOrder(BinaryNode currentNode){
            if (currentNode != null)
            {
                postOrder(currentNode.Left);
                postOrder(currentNode.Right);
                Console.Write(currentNode.Value + " ");
            }
        }
        private void preOrder(BinaryNode currentNode){
            if (currentNode != null)
            {
                Console.Write(currentNode.Value + " ");
                preOrder(currentNode.Left);
                preOrder(currentNode.Right);
            }
        }

        /// <summary>
        /// Delete the specified val.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="val">Value.</param>
        public void Delete(int val){
            if (head == null){
                Console.WriteLine("The root is null dawg");
                return;
            }

            BinaryNode theParent = null, theIter = head;
            bool isLeft = false;

            /*
             * Finds the node to be deleted
             */
            while(theIter!= null && theIter.Value!= val){ 
                theParent = theIter;

                if(theIter.Value> val){
                    theIter = theIter.Left;
                    isLeft = true;
                }else{
                    theIter = theIter.Right;
                    isLeft = false;
                }

                if(theIter==null){
                    Console.WriteLine("Your value ain't here");
                    return;
                }
            }

            /*
             * The following readjusts the pointers 
             */

            //CASE 1: IF THE ITER HAS NO RIGHT CHILD, THEN THE ITER'S LEFT CHILD BECOMES POINTED AT BY THE PARENT

            if(theIter.Right== null){
                if(theParent == null){
                    head = theIter.Left;
                }else{
                    if (isLeft){
                        theParent.Left = theIter.Left;
                    }else{
                        theParent.Right = theIter.Left;
                    }
                }
            //CASE 2: If iter's right child has no left child, then iter's right child replaces iter in the tree
            }else if (theIter.Right.Left==  null){
                theIter.Right.Left = theIter.Left;

                if(theParent == null){
                    head = theIter.Right;
                }else{
                    if (isLeft){
                        theParent.Left = theIter.Right;
                    }else{
                        theParent.Right = theIter.Right;
                    }
                }
            //CASE 3: If current's right child has a left child, replace current with current's right child's left-most descendent
            }else{
                BinaryNode leftMost = theIter.Right.Left, lmParent = theIter.Right;

                while (leftMost.Left!=null){
                    lmParent = leftMost;
                    leftMost = leftMost.Left;
                }

                lmParent.Left = leftMost.Right;
                leftMost.Left = theIter.Left;
                leftMost.Right = theIter.Right;

                if(theParent==null){
                    head = leftMost;
                }else{
                    if (isLeft){
                        theParent.Left = leftMost; 
                    }else{
                        theParent.Right = leftMost;
                    }
                }
            }

            



        }
        /// <summary>
        /// Gets the max value in the tree.
        /// </summary>
        /// <returns>The max.</returns>

        public int getMax(){
            BinaryNode iter = head;
            BinaryNode parent = null;

            if(head == null){
                return -1; 
            }

            while(iter!= null){
                parent = iter;
                iter = iter.Right;
            }

            return parent.Value;
        }

        /// <summary>
        /// Search for the node of the specified val.
        /// </summary>
        /// <returns>if the value is in the tree or not.</returns>
        /// <param name="val">Value.</param>
        public bool search(int val){
            BinaryNode iter = head;

            if(head == null){
                return false;
            }

            while(iter!= null){
                if(iter.Value==val){
                    return true;
                }

                if(val<iter.Value){
                    iter = iter.Left;
                }else{
                    iter = iter.Right;
                }
            }
            return false;
            
        }
        /// <summary>
        /// Insert the specified value in the structure.
        /// </summary>
        /// <returns>The insert.</returns>
        /// <param name="val">Value.</param>
        public void insert(int val){
            BinaryNode newNode = new BinaryNode(val);

            if(head ==null){
                head = newNode;
                return;
            }

            BinaryNode iter = head;
            BinaryNode parent = null;

            while(true){
                parent = iter;


                if (val < iter.Value)
                {
                    iter = iter.Left;
                    if (iter == null)
                    {
                        parent.Left = newNode;
                        return;
                    }


                }else{
                    iter = iter.Right;

                    if(iter == null){
                        parent.Right = newNode;
                        return;
                    }
                   
                }
            }


            
        }
    }
}
