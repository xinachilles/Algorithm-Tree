using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassLibrary.Tree
{


    class BinarySearchTree : BinaryTree<int>
    {


        private int count;


        public TreeNode<int> TreeSearch(TreeNode<int> x, int k)
        {
            if ((x == null) || (k == (x.Value)))
            {
                return x;
            }
            else if (k < x.Value)
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


        public new void Add(int data)
        {
            // create a new Node instance
            TreeNode<int> n = new TreeNode<int>(data);
            // now, insert n into the tree
            // trace down the tree until we hit a NULL
            TreeNode<int> current = root, parent = null;
            while (current != null)
            {
                 
                if (current.Value == data)
                    // they are equal - attempting to enter a duplicate - do nothing
                    return;
                else if (current.Value > data)
                {
                    // current.Value > data, must add n to current's left subtree
                    parent = current;
                    current = current.left;
                   
                }
                else if (current.Value < data)
                {
                    // current.Value < data, must add n to current's right subtree
                    parent = current;
                    current = current.right;
                }
            }

            // We're ready to add the node!
            count++;
            if (parent == null)
            {
                // the tree was empty, make n the root
                root = n;
                root.parent = null;
            }
            else
            {

                if (parent.Value > data)
                    // parent.Value > data, therefore n must be added to the left subtree
                    parent.left = n;
                    
                else
                    // parent.Value < data, therefore n must be added to the right subtree
                    parent.right = n;
            }

            n.parent = parent; 
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

        #region 4.9
        // You are given a binary tree in which each node contains a value. Design an algorithm
        // to print all paths which sum to a given value. The path does not need to start
        // or end at the root or a leaf.


        public void FindSum(TreeNode<int> current, int sum)
        {
            int depth = getHeight(current);
            TreeNode<int>[] path = new TreeNode<int>[depth];
            FindSum(current, path, 0, sum);

        }

        private void FindSum(TreeNode<int> current, TreeNode<int>[] path, int level, int sum)
        {
            if (current == null) return;

            // interst current level into path array
            path[level] = current;

            int t = 0;

            for (int i = level; i >= 0; i--)
            {
                t = path[i].Value + t;
                if (t == sum)
                {
                    printPath(path, i, level);

                }
            }

            FindSum(current.right, path, level + 1, sum);
            FindSum(current.left, path, level + 1, sum);





        }

        private void printPath(TreeNode<int>[] path, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine("the index is :{0}, the value is: {1}", i, path[i].Value);
            }

        }

        // determin if the t2 is sub-tree
        public bool containsTree(TreeNode<int> t1)
        {
            if (t1 == null) { return true; }

            return subTree(root, t1);

        }

        private bool subTree(TreeNode<int> t1, TreeNode<int> t2)
        {
            if (t1 == null) return false;

            if (t1.Value == t2.Value)
            {
                if (matchTree(t1, t2)) { return true; }

            }

            return (subTree(t1.left, t2) || subTree(t1.right, t2));
        }

        private bool matchTree(TreeNode<int> t1, TreeNode<int> t2)
        {
            if ((t1 == null) && (t2 == null))
            { return true; }

            if (t1.Value != t2.Value) return false;

            return (matchTree(t1.left, t2.left) && matchTree(t1.right, t2.right));

        }

        #endregion

        #region 4.3

        //4.3  Given a sorted (increasing order) array with unique integer elements, write an algorithm
        //to create a binary search tree with minimal height.


        public TreeNode<int> createMinimalBST(int[] arrj, int start, int end)
        {
            if (end < start)
            {
                return null;
            }
            int mid = (start + end) / 2;
            TreeNode<int> n = new TreeNode<int>(arrj[mid]);

            n.left = createMinimalBST(arrj, start, mid - 1);
            n.right = createMinimalBST(arrj, mid + 1, end);
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

                // n->left>right->left
                // the current value is n->left->right 
               
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


    }

}

