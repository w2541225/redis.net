using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Redis.DO.List
{
    public class NodeListEnumerator : IEnumerator<ListNode>
    {
        public const int AL_START_HEAD = 0;
        public int Direction { get; private set; }
        private INodeList _nodeList;
        public NodeListEnumerator(INodeList nodeList, int direction = AL_START_HEAD)
        {
            Direction = direction;
            _nodeList = nodeList;
            Reset();
        }
        public ListNode Current { get; private set; }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public void Dispose()
        {
            _nodeList = null;
            Current = null;
        }

        public bool MoveNext()
        {
            if (Direction == AL_START_HEAD)
            {
                Current = Current.Next;
            }
            else
            {
                Current = Current.Prev;
            }
            return Current != null;
        }

        public void Reset()
        {
            if (Direction == AL_START_HEAD)
            {
                Current = _nodeList.Head;
            }
            else
            {
                Current = _nodeList.Tail;
            }
        }
    }

    public class NodeListEnumerable : IEnumerable<ListNode>
    {
        public int Direction { get; private set; }
        private INodeList _nodeList;
        public NodeListEnumerable(INodeList nodeList, int direction = NodeListEnumerator.AL_START_HEAD)
        {
            Direction = direction;
            _nodeList = nodeList;
        }
        public IEnumerator<ListNode> GetEnumerator()
        {
            return new NodeListEnumerator(_nodeList, Direction);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
