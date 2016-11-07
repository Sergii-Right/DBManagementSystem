using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBManagementSystem.Models
{
    public class DBRow
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Content { get; set; }
        public int DBRowID { get; set; }
        public DBColumn DBColumn { get; set; }
    }
}