using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassLibrary.Tree
{


    public class BinarySearchTree<T> where T : IComparable<T>
    {

        public TreeNode<T> root;
       // private int count;
  
       public BinarySearchTree(IEnumerable<T> data)
    {
        if (data ==null)
        {
            return;
        }
           foreach (T item in data)
        {
            Add(item);
        }
    
    }


       
        public TreeNode<T> TreeSearch(TreeNode<T> x, T k)
        {
            if ((x == null) || (x.Value.CompareTo(k) == 0))
            {
                return x;
            }
            else if (x.Value.CompareTo(k) == 1)
            {
                return TreeSearch(x.left, k);

            }
            else
            {
                return TreeSearch(x.right, k);
            }

        }

        public TreeNode<int> TreeMin(TreeNode<int> x)
        {
            while (x.left != null)
            {
                x = x.left;

            }

            return x;

        }

        public TreeNode<int> TreeMax(TreeNode<int> x)
        {
            while (x.right != null)
            {
                x = x.right;
            }

            return x;

        }


        private TreeNode<T> Add(T data)
        {
            // create a new Node instance
            TreeNode<T> n = new TreeNode<T>(data);
            // now, insert n into the tree
            // trace down the tree until we hit a NULL
            TreeNode<T> current = root, parent = null;
            

            while (current != null)
            {

                if (current.Value.CompareTo(data) == 0)
                    // they are equal - attempting to enter a duplicate - do nothing
                    return null;
                else if (current.Value.CompareTo(data) == 1)
                {
                    // current.Value > data, must add n to current's left subtree
                    parent = current;
                    current = current.left;

                }
                else if (current.Value.CompareTo(data) == -1)
                {
                    // current.Value < data, must add n to current's right subtree
                    parent = current;
                    current = current.right;
                }
            }

            // We're ready to add the node!
           // count++;
            if (parent == null)
            {
                // the tree was empty, make n the root
                root = n;
                root.parent = null;
            }
            else
            {

                if (parent.Value.CompareTo(data) == 1)
                    // parent.Value > data, therefore n must be added to the left subtree
                    parent.left = n;

                else
                    // parent.Value < data, therefore n must be added to the right subtree
                    parent.right = n;
            }

            n.parent = parent;

            return n;
        }


        public bool Contains(int data, TreeNode<int> root)
        {
            // search the tree for a node that contains data
            TreeNode<int> current = root;

            while (current != null)
            {

                if (current.Value == data)
                    // we found data
                    return true;
                else if (current.Value > data)
                    // current.Value > data, search current's left subtree
                    current = current.left;
                else if (current.Value < data)
                    // current.Value < data, search current's right subtree
                    current = current.right;
            }

            return false;       // didn't find data
        }

        // create binary tree 



        #region 4.3

        //4.3  Given a sorted (increasing order) array with unique integer elements, write an algorithm
        //to create a binary search tree with minimal height.


        public TreeNode<int> CreateMinimalBST(int[] arrj, int start, int end)
        {
            if (end < start)
            {
                return null;
            }
            int mid = (start + end) / 2;
            TreeNode<int> n = new TreeNode<int>(arrj[mid]);

            n.left = CreateMinimalBST(arrj, start, mid - 1);
            n.right = CreateMinimalBST(arrj, mid + 1, end);
            return n;
        }
        #endregion

        #region 4.6

        // Write an algorithm to find the 'next'node (i.e., in-order successor) of a given node in
        //a binary search tree. You may assume that each node has a link to its parent.



        public TreeNode<int> InorderSucc(TreeNode<int> n)
        {
            if (n == null) return null;

            /* Found right children -> return leftmost node of right
            5 * subtree. */
            if (n.right != null)
            {
                return leftMostChild(n.right);
            }
            else
            {
                TreeNode<int> precious = n;
                TreeNode<int> parent = precious.parent;


                // Go up until we're on left instead of right

                //1. We need to pick up where we left off with n's parent, which we'll call "parent".
                //   If n was to the left of "parent", then the next node we should traverse should be "parent" (again, since
                //   left -> current -> right).

                //2. If n were to the right of "parent", then we have fully traversed n's subtree as well. We need to
                //traverse upwards from n until we find a node x that we have not fully traversed. How
                //do we know that we have not fully traversed a node x? We know we have hit this case
                //when we move from a left node to its parent. The left node is fully traversed, but its
                //parent is not.

                // situation 1 
                // n->left>right->left
                // the current value is n->left->right


                // situation 2
                // n->right->right->right
                // the current value n->right->right->right

                while (parent != null && parent.left != precious)
                {
                    precious = parent;
                    parent = parent.parent;
                }
                return parent;
            }
        }

        private TreeNode<int> leftMostChild(TreeNode<int> n)
        {
            if (n == null)
            {
                return null;
            }
            while (n.left != null)
            {
                n = n.left;
            }
            return n;
        }

        #endregion

        #region

        /*
        Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
        */

        public TreeNode<int> SortedListToBST(LinkedList<int> head)
        {
            TreeNode<int> root = null;

            SortedListToBSTHelp(ref root, head, 0, head.Count - 1);

            return root;
        }

        public void SortedListToBSTHelp(ref TreeNode<int> root, LinkedList<int> head, int start, int end)
        {
            if (start > end)
            {
                return;
            }

            int mid = (start + end) / 2;
            root = new TreeNode<int>(head.ElementAt<int>(mid));

            SortedListToBSTHelp(ref root.left, head, start, mid - 1);
            SortedListToBSTHelp(ref root.right, head, mid + 1, end);

        }
        #endregion

        #region Validate Binary Search Tree
        /*
                Problem:

        Given a binary tree, determine if it is a valid binary search tree (BST).

        Assume a BST is defined as follows:

        The left subtree of a node contains only nodes with keys less than the node's key.
        The right subtree of a node contains only nodes with keys greater than the node's key.
        Both the left and right subtrees must also be binary search trees.
                */
        public bool IsBinarySearchTree(TreeNode<T> head)
        {
            bool IsBt = true;
            IsBinarySearchTreeHelper(head, ref IsBt);
            return IsBt;
        }
        public void IsBinarySearchTreeHelper(TreeNode<T> head, ref bool IsBt)
        {
            if (head != null)
            {
                IsBinarySearchTree(head.left);

                if (head.left != null)
                {
                    if (head.left.Value.CompareTo(head.Value) > 0)
                    {
                        IsBt = false;
                    }
                }
                    if (head.right != null)
                    {
                        if (head.right.Value.CompareTo(head.Value) < 0)
                        {
                            IsBt = false;
                        }
                        
                    }

              IsBinarySearchTree(head.right);        
               
            }

             

            }
        #endregion
        }

    }

