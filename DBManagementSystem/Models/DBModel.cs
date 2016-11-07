namespace DBManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public DbSet<DBases> DBases { get; set; }
        public DbSet<DBTable> DBTables { get; set; }
        public DbSet<DBColumn> DbColumns { get; set; }
        public DbSet<DBRow> DBRows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
