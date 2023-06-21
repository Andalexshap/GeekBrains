using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public class TreeNode
    {
        public int value;
        public Color color;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode? parent;

        public TreeNode(int value)
        {
            this.value = value;
            color = Color.Red;
            left = null;
            right = null;
            parent = null;
        }
    }
}
