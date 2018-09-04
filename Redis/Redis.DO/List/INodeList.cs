using System;
using System.Collections.Generic;
using System.Text;

namespace Redis.DO.List
{
    public interface INodeList
    {
         ListNode Head { get;  }
         ListNode Tail { get;  }
        ulong Length { get; }
        void Release();
        void Empty();
        void AddNodeHead( object value);
        void AddNodeTail( object value);
        void InsertNode( ListNode old_node, object value, int after);
        void DelNode( ListNode node);
        IEnumerable<ListNode> GetIterator( int direction);
        ListNode Next(IEnumerable<INodeList> iter);
        void ReleaseIterator(IEnumerable<INodeList> iter);
        void Dup();
        ListNode SearchKey(object key);
        ListNode Index( long index);
        void Rewind( IEnumerable<INodeList> li);
        void RewindTail(IEnumerable<INodeList> li);
        void Rotate();
        void Join( INodeList o);
    }
}

