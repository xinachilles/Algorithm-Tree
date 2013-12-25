using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.Tree
{
    class BinaryTreeImprove 
    {
    
    
     #region 11.8
        /*
         Imagine you are reading in a stream of integers. Periodically, you wish to be able
         to look up the rank of a number x (the number of values less than or equal to x).
         Implement the data structures and algorithms to support these operations.That
         is, 
          
        1.implement the method track(int x), which is called when each number is generated
        2.implement the method getRankOfNumber(int x), which returns the  number of values less than or equal to x (not including x itself).
         
         */

        /*
       To find the rank of a number, we could do an in-order traversal, keeping a counter as
       we traverse. The goal is that, by the time we find x, counter will equal the number of
       elements less than x.
       * 
       As long as we're moving left during searching for x, the counter won't change. Why?
       Because all the values we're skipping on the right side are greater than x. After all, the
       very smallest element (with rank of 1) is the leftmost node.
       When we move to the right though, we skip over a bunch of elements on the left. All of
       these elements are less than x, so we'll need to increment counter by the number of
       elements in the left subtree.
       Rather than counting the size of the left subtree (which would be inefficient), we can
       track this information as we add new elements to the tree.*/
        public class RankNode
        {
       
            public int left_size = 0;
            public RankNode left, right;
            public int data = 0;
 
            public RankNode(int d) {
                    data = d;
            }

            public int getRank(int d)
            {
                if (d == data)
                {
                    return left_size;
                }
                else if (d < data)
                {
                    if (left == null) return -1;
                    else return left.getRank(d);
                }
                else
                {
                    int right_rank = right == null ? -1 : right.getRank(d);
                    if (right_rank == -1) return -1;
                    else return left_size + 1 + right_rank;
                }
            }
            public void Insert(int d)
            {
                if (d <= data)
                {
                    if (left != null) left.Insert(d);
                    else left = new RankNode(d);
                    left_size++;
                }
                else
                {
                    if (right != null) right.Insert(d);
                    else right = new RankNode(d);
                }
            }


        }

        private static RankNode root = null;
   
            public void Track(int number)
            {
                if (root == null)
                {
                    root = new RankNode(number);
                }
                else
                {
                    root.Insert(number);
                }
            }
            public static int GetRankOfNumber(int number)
            {
                return root.getRank(number);
            }
        }


        #endregion
    
    
    }

