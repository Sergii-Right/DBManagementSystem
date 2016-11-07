using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBManagementSystem.Models
{
    public class DBColumn
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DBTableID { get; set; }
        public DBTable DBTable { get; set; }
        public List<DBRow> DBRows { get; set; }
        public DBColumn()
        {
            DBRows = new List<DBRow>();
        }
    }
}