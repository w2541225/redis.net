using System;
using System.Collections.Generic;
using System.Text;

namespace Redis.DO.List
{
    public delegate bool NodeKeyMatch(object value, object key);
    public interface INodeList
    {
        ListNode Head { get; }
        ListNode Tail { get; }
        ulong Length { get; }
        NodeKeyMatch Match { get; set; }

        void Release();
        void Empty();
        void AddNodeHead(object value);
        void AddNodeTail(object value);
        void InsertNode(ListNode oldNode, object value, bool isAfter);
        void DelNode(ListNode node);
        IEnumerable<ListNode> GetIterator(int direction);
        void ReleaseIterator(IEnumerable<ListNode> iter);
        INodeList Dup();
        ListNode SearchKey(object key);
        ListNode Index(long index);
        void Rewind(IEnumerable<ListNode> li);
        void RewindTail(IEnumerable<ListNode> li);
        void Rotate();
        void Join(INodeList o);

    }


}

