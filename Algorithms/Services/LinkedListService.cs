using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Services
{
    public static class LinkedListService
    {
        public static void AddFirstRange<T>(this LinkedList<T> linkedList, IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                linkedList.AddFirst(item);
            }
        }

        public static void AddLastRange<T>(this LinkedList<T> linkedList, IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                linkedList.AddLast(item);
            }
        }
        public static void AddBeforeRange<T>(this LinkedList<T> linkedList, LinkedListNode<T> node, IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                linkedList.AddBefore(node,item);
            }
        }

        public static void Reverse<T>(this LinkedList<T> linkedList)
        {
            var result = new LinkedList<T>();
            while (linkedList.Count > 0)
            {
                result.AddFirst(linkedList.Last());
                linkedList.RemoveLast();
            }

            while (result.Count > 0)
            {
                linkedList.AddLast(result.Last());
                result.RemoveLast();
            }
        }

        public static void Revert(this LinkedList<LinkedListNode<char>> linkedList)
        {

            var a = linkedList.Select(x => x.Value);

            a.Reverse();
            a.Select(x =>
            {
                linkedList.RemoveFirst();
                linkedList.AddLast(new LinkedListNode<char>(x));
                return 1;
            } );
        }
    }
}
