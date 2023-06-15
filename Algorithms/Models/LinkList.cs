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
        public Node<T> head;
        public Node<T> tail;


        public void Push(T item)
        {
            var node = new Node<T>(item);
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
            Node<T> node = new Node<T>(item);

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

        public void AddAfter(Node<T> node, T item)
        {
            Node<T> next = node.Next;
            Node<T> newNode = new Node<T>(item);

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

        public void Remove(Node<T> node)
        {
            Node<T> previous = node.Previous;
            Node<T> next = node.Next;

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
        private void Revert(Node<T> currentNode, Node<T> previousNode)
        {
            if (currentNode.Next == null) head = currentNode;
            else Revert(currentNode.Next, currentNode);

            currentNode.Next = previousNode;
            previousNode.Next = null;
        }

        public Node<T> Find(T value)
        {
            if (value.GetType() == typeof(T))
            {
                Node<T> currentNode = head;
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
