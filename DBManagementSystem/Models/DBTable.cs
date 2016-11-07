using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBManagementSystem.Models
{
    public class DBTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DBasesID { get; set; }
        public DBases DBases { get; set; }
        public List<DBColumn> DBColumns { get; set; }
        public DBTable()
        {
            DBColumns = new List<DBColumn>();
        }
    }
}