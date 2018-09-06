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
        private NodeKeyMatch _match;
        public NodeKeyMatch Match
        {
            get
            {
                return _match;
            }
            set
            {
                _match = value;
            }
        }

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

        public INodeList Dup()
        {

            INodeList clonedList = new NodeList();
            IEnumerator<ListNode> em = GetEnumerator();
            do
            {
                if (em.Current == null)
                {
                    break;
                }
                clonedList.AddNodeTail(em.Current.Value);
            } while (em.MoveNext());
            return clonedList;

        }

        public void Empty()
        {

            foreach (var item in this)
            {
                item.Dispose();
            }
            Head = null;
            Tail = null;
            Length = 0;
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
            if (index < 0)
            {
                index = -index - 1;
                ListNode node = Tail;
                while (index > 0 && node != null)
                {
                    node = node.Prev;
                    index--;
                }
                return node;
            }
            else
            {
                ListNode node = Head;
                while (index > 0 && node != null)
                {
                    node = node.Next;
                    index--;
                }
                return node;
            }

        }

        public void InsertNode(ListNode oldNode, object value, bool isAfter)
        {
            ListNode node = new ListNode();
            node.Value = value;
            if (isAfter)
            {
                node.Prev = oldNode;
                node.Next = oldNode.Next;


                if (oldNode == Tail)
                {
                    Tail = node;
                }

            }
            else
            {
                node.Next = oldNode;
                node.Prev = oldNode.Prev;
                if (oldNode == Head)
                {
                    Head = node;
                }
            }
            if (node.Prev != null)
            {
                node.Prev.Next = node;
            }
            if (node.Next != null)
            {
                node.Next.Prev = node;
            }

            Length++;
        }

        public void Join(INodeList o)
        {
            if (o.Head != null)
            {
                o.Head.Prev = Tail;

            }

            if (Tail != null)
            {
                Tail.Next = o.Head;
            }
            else
            {
                Head = o.Head;
            }

            if (o.Tail != null)
            {
                Tail = o.Tail;
            }

            Length += o.Length;
            o.Empty();
        }


        public void Release()
        {
            Empty();
        }

        public void ReleaseIterator(IEnumerable<ListNode> iter)
        {
            foreach (var item in iter)
            {
                item.Dispose();
            }
        }

        public void Rewind(IEnumerable<NodeList> li)
        {
            (li as NodeListEnumerable).Direction = NodeListEnumerator.AL_START_HEAD;
        }

        public void Rewind(IEnumerable<ListNode> li)
        {
            throw new NotImplementedException();
        }

        public void RewindTail(IEnumerable<NodeList> li)
        {
            (li as NodeListEnumerable).Direction = NodeListEnumerator.AL_START_TAIL;
        }

        public void RewindTail(IEnumerable<ListNode> li)
        {
            throw new NotImplementedException();
        }

        public void Rotate()
        {
            if (Length <= 1)
            {
                return;
            }
            var currentTail = Tail;
            Tail = Tail.Prev;
            Tail.Next = null;
            Head.Prev = currentTail;
            currentTail.Prev = null;
            currentTail.Next = Head;
            Head = currentTail;
        }

        public ListNode SearchKey(object key)
        {
            foreach (var item in this)
            {
                if (_match != null)
                {
                    if (_match(item.Value, key))
                    {
                        return item;
                    }
                }
                else
                {
                    if (item.Value == key)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }


}
