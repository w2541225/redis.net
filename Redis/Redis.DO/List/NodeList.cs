using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Redis.DO.List
{
    public class NodeList : IEnumerable<ListNode>, INodeList
    {
        public ulong Length { get; private set; }

        public ListNode Head { get; private set; }

        public ListNode Tail { get; private set; }

        public void AddNodeHead(object value)
        {
            if (Head == null)
            {
                Head = new ListNode();
                Head.Value = value;
                Tail = Head;
                return;
            }
            var current = new ListNode();
            current.Value = value;
            current.Next = Head;
            Head.Prev = current;
        }

        public void AddNodeTail(object value)
        {
            if (Head == null)
            {
                Head = new ListNode();
                Head.Value = value;
                Tail = Head;
                Length = Length + 1;
                return;
            }
            var current = new ListNode();
            current.Value = value;
            current.Prev = Tail;
            Tail.Next = current;
            Tail = current;
            Length = Length + 1;
        }

        public void DelNode(ListNode node)
        {
            if (node == Head && node == Tail)
            {
                Head = null;
                Tail = Head;

            }
            else if (node == Head)
            {
                Head = node.Next;
                node.Next.Prev = null;


            }
            else if (node == Tail)
            {
                Tail = node.Prev;
                node.Prev.Next = null;
            }
            else
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }
            Length = Length - 1;

        }

        public void Dup()
        {
            throw new NotImplementedException();
        }

        public void Empty()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ListNode> GetEnumerator()
        {
            return new NodeListEnumerator(this);
        }

        public IEnumerable<ListNode> GetIterator(int direction)
        {
            return new NodeListEnumerable(this, direction);
        }

        public ListNode Index(long index)
        {
            throw new NotImplementedException();
        }

        public INodeList InsertNode(ListNode old_node, object value, int after)
        {
            throw new NotImplementedException();
        }

        public void Join(INodeList o)
        {
            throw new NotImplementedException();
        }

        public ListNode Next(IEnumerable<INodeList> iter)
        {
            throw new NotImplementedException();
        }

        public void Release()
        {
            throw new NotImplementedException();
        }

        public void ReleaseIterator(IEnumerable<INodeList> iter)
        {
            throw new NotImplementedException();
        }

        public void Rewind(IEnumerable<INodeList> li)
        {
            throw new NotImplementedException();
        }

        public void RewindTail(IEnumerable<INodeList> li)
        {
            throw new NotImplementedException();
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }

        public ListNode SearchKey(object key)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


}
