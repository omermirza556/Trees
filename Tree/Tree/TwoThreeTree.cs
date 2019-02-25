using System;
namespace Tree
{
    /// <summary>
    /// This class is an implementation of the two three tree. Within the data structure a tree node can be a two or three node. A four node created in the tree will then be split into a parent node that contains pointers to two two-nodes
    /// </summary>summary
    public class TwoThreeTree
    {
        TwoThreeNode root;
        public TwoThreeTree()
        {
            root = null;
        }
        /// <summary>
        /// Prints the values in the tree
        /// </summary>
        public void Print()
        {
            PrintHelper(root);
        }
        /// <summary>
        /// Private recusive algorithm used to help print values in the tree
        /// </summary>
        /// <param name="node">Node.</param>
        private void PrintHelper(TwoThreeNode node)
        {
            if (node.Type == NodeType.TwoNode)
            {
                Console.Write(node.Val1 + " ");
            }
            else
            {
                Console.Write(node.Val1 + " " + node.Val2);
            }
            if (node.Left != null)
            {
                PrintHelper(node.Left);
            }
            if (node.Middle1 != null)
            {
                PrintHelper(node.Middle1);
            }

            if (node.Right != null)
            {
                PrintHelper(node.Right);
            }

        }

        public int GetMax()
        {
            TwoThreeNode node = FindNode(root, int.MaxValue);
            if (node.Type == NodeType.TwoNode)
            {
                return node.Val1;
            }
            else
            {
                return node.Val2;
            }
        }
        /// <summary>
        /// Insert the specified value.
        /// </summary>
        /// <returns>The insert.</returns>
        /// <param name="value">Value.</param>
        public void Insert(int value)
        {
            if (root == null)
            {
                Console.WriteLine("Create a new root");
                root = new TwoThreeNode(null, null, null, value);
                return;
            }

            if (!Search(root, value))
            {
                TwoThreeNode theNode = FindNode(root, value);
                if (theNode == root && theNode.Type == NodeType.TwoNode)
                {
                    Console.WriteLine("The root is a twoNode, converting it into a threenode");
                    root = createAThreeNode(theNode, value);
                    return;
                }

                if (theNode == root && theNode.Type == NodeType.ThreeNode)
                {
                    Console.WriteLine("The root is a three node, converting it into a four node, gonna split it");
                    root = createAFourNode(theNode, value);
                    Console.WriteLine("The type of node is" + root.Type);
                    root = Split(root);
                    Console.WriteLine("The type of the root node after splitting is" + root.Type);
                    return;
                }

                if (theNode.Type == NodeType.TwoNode)
                {
                    theNode = createAThreeNode(theNode, value);
                    Console.WriteLine("The Node is becoming a three node");
                    return;
                }

                if (theNode.Type == NodeType.ThreeNode)
                {
                    Console.WriteLine("The Node is becoming a FourNode and then being split");
                    theNode = createAFourNode(theNode, value);
                    TwoThreeNode justInCase = Split(theNode);
                    if (justInCase.Parent == null)
                    {
                        root = justInCase;
                    }
                }
            }
            else
            {
                Console.WriteLine("Looks like the value already exists bub");
            }

        }
        /// <summary>
        /// This method returns whether the value exists in the tree or not
        /// </summary>
        /// <returns>The search.</returns>
        /// <param name="node">Node.</param>
        /// <param name="value">Value.</param>
        public bool Search(TwoThreeNode node, int value)
        {
            if (node.Type == NodeType.TwoNode)
            {
                return Search2(node, value);
            }
            else if (node.Type == NodeType.ThreeNode)
            {
                return Search3(node, value);
            }
            return false;
        }
        /// <summary>
        /// private helper method which searches a two node
        /// </summary>
        /// <returns>The search2.</returns>
        /// <param name="node">Node.</param>
        /// <param name="value">Value.</param>
        private bool Search2(TwoThreeNode node, int value)
        {
            if (node.Val1 == value)
            {
                return true;
            }
            if (value < node.Val1)
            {
                if (node.Left != null)
                {
                    return Search(node.Left, value);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (node.Right != null)
                {
                    return Search(node.Right, value);
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// private helper method that searches a three node
        /// </summary>
        /// <returns>The search3.</returns>
        /// <param name="node">Node.</param>
        /// <param name="value">Value.</param>
        private bool Search3(TwoThreeNode node, int value)
        {
            if (node.Val1 == value)
            {
                return true;
            }
            if (node.Val2 == value)
            {
                return true;
            }

            if (value < node.Val1)
            {
                if (node.Left != null)
                {
                    return Search(node.Left, value);
                }
                else
                {
                    return false;
                }

            }
            else if (node.Val2 < value)
            {
                if (node.Right != null)
                {
                    return Search(node.Right, value);
                }
                else
                {
                    return false;
                }

            }
            else
            {
                if (node.Middle1 != null)
                {
                    return Search(node.Middle1, value);
                }
                else
                {
                    return false;
                }
            }

        }
        /// <summary>
        /// Finds the node.
        /// </summary>
        /// <returns>The node.</returns>
        /// <param name="node">Node.</param>
        /// <param name="value">Value.</param>
        public TwoThreeNode FindNode(TwoThreeNode node, int value)
        {
            if (node.Type == NodeType.TwoNode)
            {
                return FindNode2(node, value);
            }
            else if (node.Type == NodeType.ThreeNode)
            {
                return FindNode3(node, value);
            }
            return null;
        }
        /// <summary>
        /// Private recurisive algoritm that searches a two node.
        /// </summary>
        /// <returns>The node2.</returns>
        /// <param name="node">Node.</param>
        /// <param name="value">Value.</param>
        public TwoThreeNode FindNode2(TwoThreeNode node, int value)
        {
            if (node.Val1 == value)
            {
                return node;
            }

            if (value < node.Val1)
            {
                if (node.Left != null)
                {
                    return FindNode(node.Left, value);
                }
                else
                {
                    Console.WriteLine("It failed at a twoNode left");
                    return node;
                }
            }
            else
            {
                if (node.Right != null)
                {
                    return FindNode(node.Right, value);
                }
                else
                {
                    Console.WriteLine("It failed at a twoNode right");
                    return node;
                }
            }
        }
        /// <summary>
        /// private recursive algorithm that searches a three node
        /// </summary>
        /// <returns>The node3.</returns>
        /// <param name="node">Node.</param>
        /// <param name="value">Value.</param>
        public TwoThreeNode FindNode3(TwoThreeNode node, int value)
        {
            if (value < node.Val1)
            {
                if (node.Left != null)
                {
                    return FindNode(node.Left, value);
                }
                else
                {
                    Console.WriteLine("It failed at a ThreeNode left");
                    return node;
                }
            }
            else if (value > node.Val2)
            {
                if (node.Right != null)
                {
                    return FindNode(node.Right, value);

                }
                else
                {
                    Console.WriteLine("It failed at a threenode right");
                    return node;
                }
            }
            else
            {
                if (node.Middle1 != null)
                {
                    return FindNode(node.Middle1, value);
                }
                else
                {
                    Console.WriteLine("It failed at a threeNode middle");
                    return node;
                }
            }
        }
        /// <summary>
        /// creates a three node from a twonode
        /// </summary>
        /// <returns>The AT hree node.</returns>
        /// <param name="node">Node.</param>
        /// <param name="value">Value.</param>
        public TwoThreeNode createAThreeNode(TwoThreeNode node, int value)
        {
            TwoThreeNode newThreeNode;
            if (node.Val1 < value)
            {
                newThreeNode = new TwoThreeNode(node.Val1, value)
                {
                    Parent = node.Parent
                };
                if (node.Parent != null)
                {
                    if (node.Parent.Left == node)
                    {
                        node.Parent.Left = newThreeNode;
                    }
                    else if (node.Parent.Right == node)
                    {
                        node.Parent.Right = newThreeNode;
                    }
                    else
                    {
                        node.Parent.Middle1 = newThreeNode;
                    }
                }

            }
            else
            {
                newThreeNode = new TwoThreeNode(value, node.Val1)
                {
                    Parent = node.Parent
                };
                if (node.Parent != null)
                {
                    if (node.Parent.Left == node)
                    {
                        node.Parent.Left = newThreeNode;
                    }
                    else if (node.Parent.Right == node)
                    {
                        node.Parent.Right = newThreeNode;
                    }
                    else
                    {
                        node.Parent.Middle1 = newThreeNode;
                    }
                }


            }

            return newThreeNode;
        }
        /// <summary>
        /// creates a four node from a threenode
        /// </summary>
        /// <returns>The AF our node.</returns>
        /// <param name="node">Node.</param>
        /// <param name="value">Value.</param>
        public TwoThreeNode createAFourNode(TwoThreeNode node, int value)
        {
            TwoThreeNode newFourNode;
            if (value < node.Val1)
            {
                newFourNode = new TwoThreeNode(value, node.Val1, node.Val2)
                {
                    Parent = node.Parent
                };

                if (node.Parent != null)
                {
                    if (node.Parent.Left == node)
                    {
                        node.Parent.Left = newFourNode;
                    }
                    else if (node.Parent.Right == node)
                    {
                        node.Parent.Right = newFourNode;
                    }
                    else
                    {
                        node.Parent.Middle1 = newFourNode;
                    }

                }

            }
            else if (node.Val2 < value)
            {
                newFourNode = new TwoThreeNode(node.Val1, node.Val2, value)
                {
                    Parent = node.Parent
                };

                if (node.Parent != null)
                {
                    if (node.Parent.Left == node)
                    {
                        node.Parent.Left = newFourNode;
                    }
                    else if (node.Parent.Right == node)
                    {
                        node.Parent.Right = newFourNode;
                    }
                    else
                    {
                        node.Parent.Middle1 = newFourNode;
                    }

                }
            }
            else
            {
                newFourNode = new TwoThreeNode(node.Val1, value, node.Val2)
                {
                    Parent = node.Parent
                };

                if (node.Parent != null)
                {
                    if (node.Parent.Left == node)
                    {
                        node.Parent.Left = newFourNode;
                    }
                    else if (node.Parent.Right == node)
                    {
                        node.Parent.Right = newFourNode;
                    }
                    else
                    {
                        node.Parent.Middle1 = newFourNode;
                    }

                }
            }

            return newFourNode;
        }
        /// <summary>
        /// Split the specified node from a four node.
        /// </summary>
        /// <returns>The split.</returns>
        /// <param name="node">Node.</param>
        public TwoThreeNode Split(TwoThreeNode node)
        {
            TwoThreeNode a = new TwoThreeNode(node.Left, node.Middle1, node.Parent, node.Val1);
            TwoThreeNode b = new TwoThreeNode(node.Middle2, node.Right, node.Parent, node.Val3);
            TwoThreeNode x;
            if (node.Parent == null)
            {
                x = new TwoThreeNode(a, b, null, node.Val2);
                a.Parent = x;
                b.Parent = x;
                return x;
            }
            else if (node.Parent.Type == NodeType.TwoNode)
            {
                Console.WriteLine("Creating a three node");
                x = new TwoThreeNode(NodeType.ThreeNode)
                {
                    Parent = node.Parent.Parent
                };
                a.Parent = x;
                b.Parent = x;

                if (node.Parent.Right == node)
                {
                    x.Left = node.Parent.Left;
                    x.Middle1 = a;
                    x.Right = b;
                    x.Val1 = node.Parent.Val1;
                    x.Val2 = node.Val2;
                }
                else
                {
                    x.Left = a;
                    x.Middle1 = b;
                    x.Right = node.Parent.Right;
                    x.Val1 = node.Val2;
                    x.Val2 = node.Parent.Val1;
                }
                node.Parent = x;
                return x;
            }
            else
            {
                Console.WriteLine("Creating a fourNode");
                x = new TwoThreeNode(NodeType.FourNode)
                {
                    Parent = node.Parent.Parent
                };
                a.Parent = x;
                b.Parent = x;

                if (node.Parent.Right == node)
                {
                    x.Left = node.Parent.Left;
                    x.Middle1 = node.Parent.Middle1;
                    x.Middle2 = a;
                    x.Right = b;
                    x.Val1 = node.Parent.Val1;
                    x.Val2 = node.Parent.Val2;
                    x.Val3 = node.Val2;

                }
                else if (node.Parent.Left == node)
                {
                    x.Right = node.Parent.Right;
                    x.Middle2 = node.Parent.Middle1;
                    x.Middle1 = b;
                    x.Left = a;
                    x.Val3 = node.Parent.Val2;
                    x.Val2 = node.Parent.Val1;
                    x.Val1 = node.Val2;
                }
                else
                {
                    x.Left = node.Parent.Left;
                    x.Middle1 = a;
                    x.Middle2 = b;
                    x.Right = node.Parent.Right;
                    x.Val1 = node.Parent.Val1;
                    x.Val3 = node.Parent.Val2;
                    x.Val2 = node.Val2;
                }
                node.Parent = x;
                Console.WriteLine("Four node has been created, now is being split");
                return Split(x);
            }


        }
    }
}
