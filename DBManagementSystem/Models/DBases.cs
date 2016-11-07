using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBManagementSystem.Models
{
    public class DBases
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<DBTable> DBTables { get; set; }
        public DBases()
        {
            DBTables = new List<DBTable>();
        }
    }
}