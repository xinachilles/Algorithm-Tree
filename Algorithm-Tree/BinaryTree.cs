using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace ClassLibrary.Tree
{

    public class TreeNode<T>
    {
        private T data;
        public TreeNode<T> left;
        public TreeNode<T> right;
        public TreeNode<T> parent;
        public TreeNode<T> next; // for Populating Next Right Pointers in Each Node I and II
        public int height;
        public TreeNode() { }
        public TreeNode(T value)
        {

            data = value;
        }





        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                
            }
        }



    }
    public class BinaryTree<T> : IEnumerable<TreeNode<T>> where T : IComparable<T>
    {
        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }



        public TreeNode<T> root;

        private Queue<TreeNode<T>> TreeRecords = new Queue<TreeNode<T>>();



        public void InorderTraversal(TreeNode<T> current)
        {
            if (current != null)
            {
                InorderTraversal(current.left);
                Console.WriteLine(current.Value);
                InorderTraversal(current.right);
            }

        }

        public void InorderTraversalWhileLoop(TreeNode<T> current)
        {

            bool done = false;
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            while (done == false)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {

                        TreeNode<T> node = stack.Pop();
                        Console.WriteLine(node.Value);
                        current = node.right;

                    }


                }


            }


        }


        public void PreorderTraversal(TreeNode<T> current)
        {
            if (current != null)
            {
                // Output the value of the current node
                Console.WriteLine(current.Value);

                // Recursively print the left and right children
                PreorderTraversal(current.left);
                PreorderTraversal(current.right);
            }
        }

        public void PreorderTraversalWhileLoop(TreeNode<T> current)
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            bool done = false;
            while (done == false)
            {
                if (current != null)
                {
                    Console.WriteLine(current.Value);
                    stack.Push(current);
                    current = current.left;
                }
                else
                {
                    if (stack.Count == 0) { done = true; }
                    else
                    {
                        TreeNode<T> node = stack.Pop();
                        current = node.right;
                    }

                }
            }


        }

        #region level order traver 
        public void LevelorderTraversal(TreeNode<int> root)
        {
            int h = getHeight(root);

            for (int i = 0; i < h; i++)
            {
                printGivenLevel(root, i);
            }

        }

        private void printGivenLevel(TreeNode<int> root, int level)
        {
            TreeNode<int> current = root;

            if (current == null)
                return;
            if (level == 1)
            {
                Console.WriteLine(root.Value);
            }

            else if (level > 1)
            {
                printGivenLevel(current.left, level - 1);
                printGivenLevel(current.right, level - 1);
            }

        }
        #endregion

        // create binary tree for testing 
        public void Add(T data)
        {

            TreeNode<T> current = new TreeNode<T>(data);

            if (root == null)
            {
                root = new TreeNode<T>(data);
                TreeRecords.Enqueue(root);

            }
            else
            {

                if (TreeRecords.Count > 0)
                {

                    TreeNode<T> node = TreeRecords.Peek();

                    if (node.right != null && node.left != null)
                    {
                        TreeRecords.Dequeue();
                        TreeRecords.Enqueue(node.left);
                        TreeRecords.Enqueue(node.right);
                        node = TreeRecords.Peek();

                    }



                    if (node.left == null)
                    {
                        node.left = current;

                    }

                    else if (node.right == null)
                    {
                        node.right = current;

                    }

                }
            }


        }

        #region 4.1
        //4.1 Implement a function to check if a binary tree is balanced. For the purposes of
        //this question, a balanced tree is defined to be a tree such that the heights of the
        //two subtrees of any node never differ by more than one.
        public int getHeight(TreeNode<int> node)
        {
            if (node == null) return 0; // Base case
            return Math.Max(getHeight(node.left), getHeight(node.right)) + 1;
        }

        public bool IsBalanced(TreeNode<int> node)
        {
            if (node == null) return true; // Base case
            int heightDiff = getHeight(node.left) - getHeight(node.right);

            if (Math.Abs(heightDiff) > 1)
            {
                return false;
            }
            else
            { // Recurse
                return IsBalanced(node.left) && IsBalanced(node.right);
            }
        }
        // second solution 
        int checkHeight(TreeNode<T> root)
        {
            if (root == null)
            {
                return 0; // Height of 0
            }

            /* Check if left is balanced. */
            int leftHeight = checkHeight(root.left);
            if (leftHeight == -1)
            {
                return -1; // Not balanced
            }
            /* Check if right is balanced. */
            int rightHeight = checkHeight(root.right);
            if (rightHeight == -1)
            {
                return -1; // Not balanced
            }

            /* Check if current node is balanced. */
            int heightDiff = leftHeight - rightHeight;
            if (Math.Abs(heightDiff) > 1)
            {
                return -1; // Not balanced
            }
            else
            {
                /* Return height */
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

        public bool IsBalancedTwo(TreeNode<T> root)
        {
            if (checkHeight(root) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }




        #endregion


        ArrayList createLevell_inkedList(TreeNode<T> root)
        {
            ArrayList result = new ArrayList();
            /* "Visit" the root */
            LinkedList<TreeNode<T>> current = new LinkedList<TreeNode<T>>();
            if (root != null)
            {
                current.AddFirst(root);
            }

            while (current.Count > 0)
            {
                result.Add(current); // Add previous level
                LinkedList<TreeNode<T>> parents = current; // Go to next level
                current = new LinkedList<TreeNode<T>>();

                foreach (TreeNode<T> parent in parents)
                {


                    /* Visit the children */
                    if (parent.left != null)
                    {
                        current.AddFirst(parent.left);
                    }
                    if (parent.right != null)
                    {
                        current.AddFirst(parent.right);
                    }
                }
            }
            return result;
        }

        #region 4.4
        //4.4 Given a binary tree, design an algorithm which creates a linked list of all the nodes at
        //each depth (e.g., if you have a tree with depth D, you'll have D linked lists).

        public void CreateLevelLinkedList(TreeNode<T> root, List<List<TreeNode<T>>> lists, int level)
        {
            if (root == null) return; // base case

            List<TreeNode<T>> list = null;
            if (lists.Count == level)
            { // Level not contained in list
                list = new List<TreeNode<T>>();
                /* Levels are always traversed in order. So., if this is the
                * first time we've visited level i, we must have seen levels
                 0 through i - 1. We can therefore safely add the level at
                i * the end. */
                lists.Add(list);
            }
            else
            {
                list = lists[level];
            }
            list.Add(root);
            CreateLevelLinkedList(root.left, lists, level + 1);
            CreateLevelLinkedList(root.right, lists, level + 1);
        }


        //Alternatively, we can also implement a modification of breadth first search. With this
        //implementation, we want to iterate through the root first, then level 2, then level 3, and
        //soon.
        //With each level i, we will have already fully visited all nodes on level i - 1.This means
        //that to get which nodes are on level i, we can simply look at all children of the nodes
        //of level i - 1



        public List<List<TreeNode<T>>> CreateLevellinkedListTwo(TreeNode<T> root)
        {
            List<List<TreeNode<T>>> result = new List<List<TreeNode<T>>>();
            /* "Visit" the root */
            List<TreeNode<T>> current = new List<TreeNode<T>>();
            if (root != null)
            {
                current.Add(root);
            }

            while (current.Count > 0)
            {
                result.Add(current); // Add previous level
                List<TreeNode<T>> parents = current; // Go to next level
                current = new List<TreeNode<T>>();
                foreach (TreeNode<T> parent in parents)
                {

                    /* Visit the children */
                    if (parent.left != null)
                    {
                        current.Add(parent.left);
                    }
                    if (parent.right != null)
                    {
                        current.Add(parent.right);
                    }
                }
            }
            return result;
        }
        #endregion

        #region 4.5

        //4.5 Impemen t a function to check if a binary tree is a binary search tree.
        //1 . in order travel -> copy to array -> check the array if sorted 
        // we must assume the tree don`t have duplicate value 

        public int index = 0;


        private void CopyBST(TreeNode<int> root, ref int[] array)
        {
            if (root == null) return;
            CopyBST(root.left, ref array);
            array[index] = root.Value;
            index++;
            CopyBST(root.right, ref array);
        }

        public bool CheckBST(int[] array, TreeNode<int> root)
        {
            CopyBST(root, ref array);
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] >= array[i])
                {
                    return false;
                }
            }

            return true;

        }

        // 4.5 second way that we remove the uncessary array 
        public int last_printed_value = int.MinValue;

        public bool CheckBST(TreeNode<int> root)
        {

            if (root == null) return true;
            //check  recurse left 

            if (!CheckBST(root.left)) return false;

            //check current 
            if (root.Value <= last_printed_value) return false;
            last_printed_value = root.Value;

            //check recurse rigt 
            if (!CheckBST(root.right)) return false;

            return true; // all good! 

        }


        // solution 3  

        public bool CheckBST(TreeNode<int> node, int min, int max)
        {
            if (root == null) return true;

            // check current value 
            if (node.Value > max || node.Value <= min) { return false; }

            if (!CheckBST(node.left, min, node.Value) || !CheckBST(node.right, node.Value, min))
            {
                return false;

            }

            return true;

        }

        #endregion


        #region 4.7
        //Design an algorithm and write code to find the first common ancestor of two nodes
        //in a binary tree. Avoid storing additional nodes in a data structure. NOTE: This is not
        //necessarily a binary search tree.

        // solution 2 : 
        public TreeNode<T> CommonAncerstorSoultionTwo(TreeNode<T> root, TreeNode<T> p, TreeNode<T> q)
        {
            // error check 
            if (covers(root, p) == false && covers(root, q) == false) return null;

            return CommonAncerstorHelper(root, p, q);


        }

        private bool covers(TreeNode<T> root, TreeNode<T> node)
        {
            if (root == null) return false;

            if (root == node) return true;

            return (covers(root.left, node) || covers(root.right, node));

        }

        private TreeNode<T> CommonAncerstorHelper(TreeNode<T> root, TreeNode<T> p, TreeNode<T> q)
        {
            if (root == null) return null; ;
            if ((p == root) || (q == root)) return root;
            bool is_root_left_p = covers(root.left, p);
            bool is_root_left_q = covers(root.left, q);

            if (is_root_left_p != is_root_left_q) return root;

            TreeNode<T> child_node = is_root_left_p ? root.left : root.right;

            return CommonAncerstorHelper(child_node, p, q);
        }


        // solution #3

        // Although the Solution #2 is optimal in its runtime, we may recognize that there is still
        // some inefficiency in how it operates. Specifically, covers searches all nodes under root
        // for p and q, including the nodes in each subtree (root. left and root. right).Then, it
        // picks one of those subtrees and searches all of its nodes. Each subtree is searched over
        //  and over again.
        // We may recognize that we should only need to search the entire tree once to find p and
        //q. We should then be able to "bubble up" the findings to earlier nodes in the stack. The
        //basic logic is the same as the earlier solution.
        //We recurse through the entire tree with a function called commonAncestor(TreeNode
        //root, TreeNode p, TreeNode q).This function returns values as follows:
        //• Returns p, if root's subtree includes p (and not q).
        //• Returns q, if root's subtree includes q (and not p).
        //• Returns null, if neither p nor q are in root's subtree.
        //• Else, returns the common ancestor of p and q.
        public class result
        {
            public TreeNode<T> node;
            public bool isAncestor;

        }

        private result CommonAncerstorHelperProved(TreeNode<T> root, TreeNode<T> p, TreeNode<T> q)
        {
            if (root == null) return new result { node = null, isAncestor = false };

            if (root == p && root == q) return new result { node = root, isAncestor = true };

            // check the right node
            result xr = CommonAncerstorHelperProved(root.right, p, q);
            if (xr.isAncestor) return xr;

            // check the left node
            result xl = CommonAncerstorHelperProved(root.left, p, q);
            if (xl.isAncestor) return xl;

            // check itself 
            if (xr.node != null && xl.node != null)
            {
                return new result { node = root, isAncestor = true };
            }
            else
            {
                if (p == root || q == root)
                {
                    bool ancestor = (xr.node != null || xl.node != null ? true : false);
                    return new result { node = root, isAncestor = ancestor };
                }
                else
                {
                    return new result
                    {
                        node = (xr.node != null ? xr.node : xl.node),
                        isAncestor = false
                    };
                }


            }

        }



        public TreeNode<T> CommonAncerstorProvedSolutionThree(TreeNode<T> root, TreeNode<T> p, TreeNode<T> q)
        {
            result r = CommonAncerstorHelperProved(root, p, q);
            if (r.isAncestor)
            {
                return r.node;
            }
            else
            {
                return null;
            }



        }
        #endregion

        // Given a binary tree, design an algorithm which creates a linked list of all the nodes at
        // each depth (e.g., if you have a tree with depth D, you'll have D linked lists).

        #region 4.8
        //4.8 You have two very large binary trees: Tl, with millions of nodes, and T2, with
        //hundreds of nodes. Create an algorithm to decide ifT2 is a subtree ofTl.
        //A tree T2 is a subtree of Tl if there exists a node n in Tl such that the subtree ofn
        //is identical to T2. That is, if you cut off the tree at node n, the two trees would be
        //identical.

        //        thoughts on that matter though:
        //1. The simple solution takes 0(n + m) memory. The alternative solution takes
        //0(log(n) + log(m)) memory. Remember: memory usage can be a very big deal
        //when it comes to scalability.

        //2. The simple solution is 0(n + m) time and the alternative solution has a worst case
        //time of 0(nm). However, the worst case time can be deceiving; we need to look
        //deeper than that.

        //3. A slightly tighter bound on the runtime, as explained earlier, is 0(n + km), where
        //k is the number of occurrences of T2's root in Tl. Let's suppose the node data for
        //Tl and T2 were random numbers picked between 0 and p. The value of k would
        //be approximately n/p. Why? Because each of n nodes in Tl has a 1/p chance of
        //equaling the root, so approximately n/p nodes in Tl should equal T2. root. So, let's
        //say p = 1000, n = 1000000 and m = 100. We would do somewhere around
        //1,100,000 node checks (1100000 = 1000000 + 100*1000000/1000).

        //4. More complex mathematics and assumptions could get us an even tighter bound.
        //We assumed in #3 above that if we call treeMatch, we will end up traversing all m
        //nodes of T2. It's far more likely though that we will find a difference very early on in
        //the tree and will then exit early.

        //In summary, the alternative approach is certainly more optimal in terms of space and
        //is likely more optimal in terms of time as well. It all depends on what assumptions you
        //make and whether you prioritize reducing the average case runtime at the expense of
        //the worst case runtime. This is an excellent point to make to your interviewer.
        public bool ContainsTree(TreeNode<T> t1, TreeNode<T> t2)
        {
            if (t2 == null)
            { // The empty tree is always a subtree
                return true;
            }

            if (t1 == null)
            {
                return false; // big tree empty & subtree still not found.
            }
            return SubTree(t1, t2);
        }

        private bool SubTree(TreeNode<T> r1, TreeNode<T> r2)
        {

            if (r1.Value.CompareTo(r2.Value) == 0)
            {
                if (MatchTree(r1, r2)) return true;
            }
            return (SubTree(r1.left, r2) || SubTree(r1.right, r2));
        }

        bool MatchTree(TreeNode<T> r1, TreeNode<T> r2)
        {
            if (r2 == null && r1 == null) // if both are empty
                return true; // nothing left in the subtree

            // if one, but not both, are empty
            if (r1 == null || r2 == null)
            {
                return false;
            }

            if (r1.Value.CompareTo(r2.Value) != 0) return false; // data doesn't match
            return (MatchTree(r1.left, r2.left) && MatchTree(r1.right, r2.right));
        }



        #endregion

        #region 4.9
        // You are given a biwnary tree in which each node contains a value. Design an algorithm
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

        #endregion

        #region leet Sum Root to Leaf Numbers
        /*
         Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number.
         An example is the root-to-leaf path 1->2->3 which represents the number 123.  
         Find the total sum of all root-to-leaf numbers.For example,
         *  1
            / \
            2   3
         * The root-to-leaf path 1->2 represents the number 12.
           The root-to-leaf path 1->3 represents the number 13.Return the sum = 12 + 13 = 25.
         */


        /*solution 1 */
        /*
            I try to use the way similar with perorder or inorder travel tree, It seems does`t work for this problem
         */
        int SumNumbers(TreeNode<int> root)
        {
            int n = 0;
            int level = 0;
            bool done = false;
            TreeNode<int> current = root;
            Stack<TreeNode<int>> temp = new Stack<TreeNode<int>>();
            int result = 0;
            while (done == false)
            {

                if (current != null)
                {
                    temp.Push(current);
                    current = current.left;
                }
                else if (temp.Count == 0)
                {

                    done = true;

                }
                else
                {
                    level = level + 1;
                    TreeNode<int> node = temp.Pop();
                    if (node.right != null)
                    {
                        result = result + (node.left.Value + node.right.Value + n) % 10 * level;
                        n = node.left.Value + node.right.Value > 10 ? 1 : 0;
                        node = node.right;
                    }
                    else
                    {
                        result = result + (node.left.Value + n) * level;
                    }



                } // end if

            }

            if (root != null)
            {
                result = root.Value * level + result;

            }
            return result;

        }
        /*end solution 1*/

        /*solution 2*/
        /*
         three situation 
         * 
         * 1. empty node
         * 2. leave node
         * 3. the node between root and leave
       */


        int dfs(TreeNode<int> root, int sum)
        {
            if (root == null) return 0;

            if (root.left == null && root.right == null) return sum = root.Value + 10 * sum;

            else return dfs(root.left, sum * 10 + root.Value) + dfs(root.right, sum * 10 + root.Value);
        }

        public int SumNumbers2(TreeNode<int> root)
        {
            
            return dfs(root, 0);
        }

        /*end solution 2*/

        /*solution 3  deap first while loop*/
       
        /**/

        #endregion

        #region leet Binary Tree Maximum path sum
        /*another solution from http://jane4532.blogspot.com/2013/09/binary-tree-maximum-path-sumleetcode.html */
        /*Given a binary tree, find the maximum path sum.
        The path may start and end at any node in the tree.
        For example:
         * For example:
        Given the below binary tree,
       1
      / \
     2   3
     Given the below binary tree, */
        /*solution 2*/
      private  int MaxPathSum2Help(TreeNode<int> root, int max)
        {
            if (root == null) return 0;

            int l = MaxPathSum2Help(root.left, max);
            int r = MaxPathSum2Help(root.right, max);

            int m = root.Value;

            if (l > 0) m = l + m;
            if (r > 0) m = r + m;

            if (m > max) max = m;

            return (Math.Max(l, r) > 0 ? Math.Max(l, r) + root.Value : root.Value);
        }

     public int maxPathSum2(TreeNode<int> root)
        {
            int max = int.MinValue;

            MaxPathSum2Help(root, max);

            return max;
        }

        /*solution 2*/

        /*solution 1*/
        int max;
        public int MaxPathSum(TreeNode<int> root)
        {
            max = (root == null) ? 0 : root.Value;
            findMax(root);
            return max;
        }

        private int findMax(TreeNode<int> node)
        {
            if (node == null)
                return 0;

            // recursively get sum of left and right path
            int left = Math.Max(findMax(node.left), 0);
            int right = Math.Max(findMax(node.right), 0);
             
            //update maximum here
            max = Math.Max(node.Value + left + right, max);

            // return sum of largest path of current node
            return node.Value + Math.Max(left, right);
        }

        /*solution 1*/
        #endregion

        #region Populating Next Right Pointers in Each Node

        /*
                         Given a binary tree
                    struct TreeLinkNode {
                      TreeLinkNode *left;
                      TreeLinkNode *right;
                      TreeLinkNode *next;
                    }
                Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set toNULL.
                Initially, all next pointers are set to NULL.
                Note:
                You may only use constant extra space.
                You may assume that it is a perfect binary tree (ie, all leaves are at the same level, and every parent has two children).
                For example,
                Given the following perfect binary tree,
                         1
                       /  \
                      2    3
                     / \  / \
                    4  5  6  7
                After calling your function, the tree should look like:
                         1 -> NULL
                       /  \
                      2 -> 3 -> NULL
                     / \  / \
                    4->5->6->7 -> NULL
         
         */

       

        public void Connect(TreeNode<T> root)
        {
            if (root == null) { return; }
            root.next = null;
            Dfs(root);
        }

        private void Dfs(TreeNode<T> root)
        {
            if (root == null) { return; }  // if current node is not valid return

            if (root.next == null)
            { // if current node is not in the right boundary of this level
                if (root.right != null)
                {   // if has right child, its next is null
                    root.right.next = null;
                }
                if (root.left != null)
                { //if has left child, its next is its right

                    root.left.next = root.right;

                }
            }
            else
            { // if the current node has next node in its right
                TreeNode<T> p = root.next; //the pointer travle along this level 
                TreeNode<T> q = null; // the next valid pointer in the level+1 , or NULL if not found
                while (p != null)
                { //find the next valid child of root node
                    if (p.left != null) { q = p.left; break; }
                    if (p.right != null) { q = p.right; break; }
                    p = p.next;
                }
                if (root.right != null) { root.right.next = q; } //set right child if exists
                if (root.left != null && root.right != null) { root.left.next = root.right; }//set left if right exists
                if (root.left != null && root.right == null) { root.left.next = q; } // set left if right not exist
            }

            Dfs(root.right); // search right child, order is important
            Dfs(root.left);  // search left child
        }


        #endregion

        #region Populating Next Right Pointers in Each Node II
        /*
                         Follow up for problem "Populating Next Right Pointers in Each Node".

                What if the given tree could be any binary tree? Would your previous solution still work?

                Note:

                You may only use constant extra space.
                For example,
                Given the following binary tree,
                         1l
                       /  \
                      2    3
                     / \    \
                    4   5    7
                After calling your function, the tree should look like:
                         1 -> NULL
                       /  \
                      2 -> 3 -> NULL
                     / \    \
                    4-> 5 -> 7 -> NULL
         
         */
        public void Connect1(TreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            Queue<TreeNode<T>> nextQueue = new Queue<TreeNode<T>>();
            queue.Enqueue(root);
            TreeNode<T> left = null;
            while (queue.Count != 0)
            {
                TreeNode<T> node = queue.Dequeue();
                if (left != null)
                {
                    left.next = node;
                }
                left = node;
                if (node.left != null)
                {
                    nextQueue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    nextQueue.Enqueue(node.right);
                }
                if (queue.Count == 0)
                {
                    Queue<TreeNode<T>> temp = queue;
                    queue = nextQueue;
                    nextQueue = temp;
                    left = null;
                }
            }
        }

        public void Connect2(TreeNode<T> root)
        {


        }
        #endregion

        #region Flatten Binary Tree to Linked List
        /*
                    Given a binary tree, flatten it to a linked list in-place.

            For example,
            Given

                     1
                    / \
                   2   5
                  / \   \
                 3   4   6
            The flattened tree should look like:

               1
                \
                 2
                  \
                   3
                    \
                     4
                      \
                       5
                        \
                         6

                   
             */
        /*not correct */
        public void Flatten(TreeNode<T> treeNode, ref TreeNode<T> n)
        {
            if (treeNode == null)
            {
                return;
            }

            //if (n == null)
            //{
            //    n = new TreeNode<T>();
            //}
            n = new TreeNode<T>(treeNode.Value);

            
                Flatten(treeNode.left, ref n.left);
           
           

                Flatten(treeNode.right, ref n.left);
            
        }

        public void FlattenBSF(TreeNode<T> treeNode,  ref TreeNode<T> n)
        {
            Queue<TreeNode<T>> currentQ = new Queue<TreeNode<T>>();
            
        
            currentQ.Enqueue(treeNode);
            TreeNode<T> temp = n;

            while(currentQ.Count !=0)
            {
                TreeNode<T> current = currentQ.Dequeue();
                if (current != null)
                {

                    currentQ.Enqueue(current.left);
                    currentQ.Enqueue(current.right);

                    if (n == null)
                    {
                        n = new TreeNode<T>(current.Value);

                        temp = n;
                    }
                    else
                    {
                        while (temp.left != null)
                        {
                            temp = temp.left;
                        }
                        temp.left = new TreeNode<T>(current.Value);
                    }
                }

                
            
            }


        
        }
        #endregion

        #region Path Sum I
            //        Path Sum I:

            //Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.
            //For example:
            //Given the below binary tree and sum = 22,
            //              5
            //             / \
            //            4   8
            //           /   / \
            //          11  13  4
            //         /  \      \
            //        7    2      1
            //return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.

        bool HasPathSum(TreeNode<int> root, int sum)
        {
            if (root == null) {
                return false;
            }

            if (root.right == null && root.left == null && sum-root.Value == 0)
            {
                return true;
            }
            return (HasPathSum(root.right, sum - root.Value) || HasPathSum(root.left, sum - root.Value));

        }
        #endregion
        #region Path Sum II

        /*
                     /** 
             *   
             *  
             * Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum. 
 
            For example: 
            Given the below binary tree and sum = 22, 
                          5 
                         / \ 
                        4    8 
                       /     / \ 
                      11  13  4 
                     /  \      / \ 
                    7    2   5   1 
            return 
            [ 
               [5,4,11,2], 
               [5,8,4,5] 
            ] 
             */

      public List<Stack<int>> PathSum2(TreeNode<int> root, int sum)
        {
            List<Stack<int>> result = new List<Stack<int>>();
            Stack<int> temp = new Stack<int>();
            PathSum2Help(root, sum, temp, result); 
            return result;
        }

        private void PathSum2Help(TreeNode<int> root, int sum, Stack<int> temp, List<Stack<int>> result)
        {
            if (root == null)
            {
                return;
            }

            temp.Push(root.Value);
            if (root.left == null && root.right == null && sum-root.Value == 0)
            {
                result.Add(new Stack<int>(temp));
                temp.Pop();
                
            }

           
                PathSum2Help(root.right, sum - root.Value, temp, result);
                PathSum2Help(root.left, sum - root.Value, temp, result);
         
            
                   // temp.Pop();
        }

        #endregion
        #region Minimum Depth of Binary Tree
        public int MinDepth(TreeNode<T> root)
        {
            if (root != null)
            {
                int min = int.MaxValue;
                MinDepthHelper(root, min, 0);
                return min;
            }
            else {

                return 0;
            }

        }
        private void MinDepthHelper(TreeNode<T> root, int min, int height)
        {
            if (root == null)
            {
                return;
            }
           
            if (root.right == null && root.left == null)
            {
                if (min > height )
                {
                    min = height;     
                }
            }

            MinDepthHelper(root.left, min, height+1);
            MinDepthHelper(root.right, min, height + 1);
        
        }

        /*solution 2*/
        public int MinDepth2(TreeNode<T> root)
        {
            if (root == null)
            {
                return 0;
            }

            return (Math.Min(MinDepth2(root.left), MinDepth2(root.right)) + 1);
        }
        /*end soultion 2 */
        #endregion 
        
       

    }

}
