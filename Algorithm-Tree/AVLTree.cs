using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassLibrary.Tree
{
    


    public class AVLTree<T> : BinarySearchTree<T> where T:IComparable<T>
    {
        private TreeNode<T> root;

        private int Height(TreeNode<T> node)
        {
            if (node == null)
            {
                return -1;
            }
            else
            {
                return node.height;
            }
        }
        private void UpdateHeight(TreeNode<T> node)
        {
            node.height = Math.Max(Height(node.left), Height(node.right)) + 1;
        }
        public AVLTree()
        {
            this.root = null;
        }

        public void Rebalance(TreeNode<T> node)
       {
        while (node!=null)
	{
	     UpdateHeight(node); 
        if(Height(node.left) >= 2+ Height(node.right))
        {
            if(Height(node.left.left) >= Height(node.left.right))
            {
                    RightRotate(node);
                
            }
            else{
            
                   LeftRotate(node.left);
                   RightRotate(node);
            }
        }else if(Height(node.right) >= 2+ Height(node.left))
        {
             if(Height(node.right.right) >= Height(node.right.left))
             {
                    LeftRotate(node);
             }
               else {
                    RightRotate(node.right);
                    LeftRotate(node);
             }
        }
	        
            node = node.parent;
        
        }
        }
        private void LeftRotate(TreeNode<T> x)
        {
            TreeNode<T> y = x.right;
            y.parent = x.parent;
            if (y.parent == null)
            {
                root = y;
            }
            else
            {
                if (y.parent.left == x)
                {
                    y.parent.left = y;
                }
                else if (y.parent.right == x)
                {
                    y.parent.right = y;
                }
                x.right = y.left;
                if (x.right != null)
                {
                    x.right.parent = x;
                }
                y.left = x;
                x.parent = y;
                UpdateHeight(x);
                UpdateHeight(y);


            }






        }
        private void RightRotate(TreeNode<T> x)
        {
           TreeNode<T> y = x.left;
            y.parent = x.parent;
            if (y.parent == null)
            {
                root = y;
            }
            else
            {
                if (y.parent.left == x)
                {
                    y.parent.left = y;
                }
                else if (y.parent.right == x)
                {
                    y.parent.right = y;
                }
                x.left = y.right;
                if (x.left != null)
                {
                    x.left.parent = x;
                }
                y.right = x;
                x.parent = y;
                UpdateHeight(x);
                UpdateHeight(y);
            }
        }
    }
}