using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public class TreeNode<T>
    {
        public TreeNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public TreeNode<T>? Next { get; set; }
        public TreeNode<T>? Previous { get; set; }
    }
}
