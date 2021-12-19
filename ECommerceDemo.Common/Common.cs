using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceDemo.Common
{
    public class DbResult
    {
        public DbResultType DbResultId { get; set; }
        public string Message { get; set; }
        public int TableId { get; set; }
        public string CustomReturn { get; set; }
    }

    public enum DbResultType
    {
        Inserted = 1,
        Updated = 2,
        Deleted = 3,
    }

    public enum Mode
    {
        Insert = 1,
        Update = 2,
        Delete = 3,
        GetAll = 4,
        Get = 5,
    }
}
