using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public class LinkList<T> : IEnumerable<T>
    {
        public TreeNode<T> head;
        public TreeNode<T> tail;


        public void Push(T item)
        {
            var node = new TreeNode<T>(item);
            node.Next = head;
            head.Previous = node;
            head = node;
        }
        public T Peek()
        {
            if (tail != null)
            {
                T result = tail.Data;
                if (tail.Previous == null)
                {
                    head = null;
                    tail = null;
                }

                tail.Previous.Next = null;
                tail = tail.Previous;

                return result ?? default(T);
            }
            return default(T);

        }

        public T Pop()
        {
            if (tail != null)
            {
                T result = tail.Data;
                if (head.Next != null)
                    head = null;

                return result ?? default(T);
            }
            return default(T);
        }
        public void AddLast(T item)
        {
            TreeNode<T> node = new TreeNode<T>(item);

            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }
        }

        public void AddAfter(TreeNode<T> node, T item)
        {
            TreeNode<T> next = node.Next;
            TreeNode<T> newNode = new TreeNode<T>(item);

            node.Next = newNode;
            newNode.Previous = node;

            if (next == null)
            {
                tail = newNode;
            }
            else
            {
                next.Previous = newNode;
                newNode.Next = next;
            }

        }

        public void Remove(TreeNode<T> node)
        {
            TreeNode<T> previous = node.Previous;
            TreeNode<T> next = node.Next;

            if (previous == null)
            {
                next.Next.Previous = null;
                head = next;
            }
            else
            {
                if (next == null)
                {
                    previous.Next = null;
                    tail = previous;
                }
                else
                {
                    previous.Next = next;
                    next.Previous = previous;
                }
            }
        }

        public void Revert()
        {
            var currentNode = head;
            while (currentNode != null)
            {
                var next = currentNode.Next;
                var previous = currentNode.Previous;

                currentNode.Next = previous;
                currentNode.Previous = next;

                if (previous == null) tail = currentNode;
                if (next == null) head = currentNode;

                currentNode = next;
            }
        }

        public void Revert(int v = 0)
        {
            if (head != null && head.Next != null)
            {
                Revert(head.Next, head);
            }
        }
        private void Revert(TreeNode<T> currentNode, TreeNode<T> previousNode)
        {
            if (currentNode.Next == null) head = currentNode;
            else Revert(currentNode.Next, currentNode);

            currentNode.Next = previousNode;
            previousNode.Next = null;
        }

        public TreeNode<T> Find(T value)
        {
            if (value.GetType() == typeof(T))
            {
                TreeNode<T> currentNode = head;
                while (currentNode != null)
                {
                    if (currentNode.Data.Equals(value)) return currentNode;

                    currentNode = currentNode.Next;
                }
            }

            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
