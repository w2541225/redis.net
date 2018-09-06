using System;
using System.Collections.Generic;
using System.Text;

namespace Redis.DO.List
{
    public class ListNode :IDisposable
    {
        public ListNode Prev { get; set; }
        public ListNode Next { get; set; }
        public object Value { get; set; }

        public void Dispose()
        {
            Prev = null;
            Next = null;
            Value = null;
        }
    }
}
