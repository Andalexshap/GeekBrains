using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Algorithms.Models
{
    public class RedBlackTree
    {
        private TreeNode root;

        public RedBlackTree()
        {
            root = null;
        }

        private void RotateLeft(TreeNode x)
        {
            TreeNode y = x.right;
            x.right = y.left;
            if (y.left != null)
            {
                y.left.parent = x;
            }
            y.parent = x.parent;
            if (x.parent == null)
            {
                root = y;
            }
            else if (x == x.parent.left)
            {
                x.parent.left = y;
            }
            else
            {
                x.parent.right = y;
            }
            y.left = x;
            x.parent = y;
        }

        private void RotateRight(TreeNode x)
        {
            TreeNode y = x.left;
            x.left = y.right;
            if (y.right != null)
            {
                y.right.parent = x;
            }
            y.parent = x.parent;
            if (x.parent == null)
            {
                root = y;
            }
            else if (x == x.parent.right)
            {
                x.parent.right = y;
            }
            else
            {
                x.parent.left = y;
            }
            y.right = x;
            x.parent = y;
        }

        private void FixViolation(TreeNode node)
        {
            TreeNode parent = null;
            TreeNode grandparent = null;
            while (node != root && node.color != Color.Black && node.parent.color == Color.Red)
            {
                parent = node.parent;
                grandparent = node.parent.parent;
                if (parent == grandparent.left)
                {
                    TreeNode uncle = grandparent.right;
                    if (uncle != null && uncle.color == Color.Red)
                    {
                        grandparent.color = Color.Red;
                        parent.color = Color.Black;
                        uncle.color = Color.Black;
                        node = grandparent;
                    }
                    else
                    {
                        if (node == parent.right)
                        {
                            RotateLeft(parent);
                            node = parent;
                            parent = node.parent;
                        }
                        RotateRight(grandparent);
                        Color temp = parent.color;
                        parent.color = grandparent.color;
                        grandparent.color = temp;
                        node = parent;
                    }
                }
                else
                {
                    TreeNode uncle = grandparent.left;
                    if (uncle != null && uncle.color == Color.Red)
                    {
                        grandparent.color = Color.Red;
                        parent.color = Color.Black;
                        uncle.color = Color.Black;
                        node = grandparent;
                    }
                    else
                    {
                        if (node == parent.left)
                        {
                            RotateRight(parent);
                            node = parent;
                            parent = node.parent;
                        }
                        RotateLeft(grandparent);
                        Color temp = parent.color;
                        parent.color = grandparent.color;
                        grandparent.color = temp;
                        node = parent;
                    }
                }
            }
            root.color = Color.Black;
        }

        public void Insert(int value)
        {
            TreeNode node = new TreeNode(value);
            TreeNode parent = null, current = root;
            while (current != null)
            {
                parent = current;
                if (node.value < current.value)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }
            node.parent = parent;
            if (parent == null)
            {
                root = node;
            }
            else if (node.value < parent.value)
            {
                parent.left = node;
            }
            else
            {
                parent.right = node;
            }
            FixViolation(node);
            if (node.parent == null)
            {
                node.color = Color.Black;
            }
        }

        public TreeNode Search(int value)
        {
            TreeNode current = root;
            while (current != null && current.value != value)
            {
                if (value < current.value)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }
            return current;
        }
    }
}
